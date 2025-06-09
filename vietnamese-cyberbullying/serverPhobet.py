# -*- coding: utf-8 -*-

import torch
import torch.nn as nn
from transformers import AutoModel, AutoTokenizer
from flask import Flask, request, jsonify
from flask_cors import CORS
import re
import logging

# --- 1. THIẾT LẬP LOGGING ---
# Thiết lập để ghi lại các thông tin quan trọng khi server hoạt động
logging.basicConfig(level=logging.INFO, 
                    format='%(asctime)s - %(levelname)s - %(message)s',
                    handlers=[logging.StreamHandler()]) # In log ra console
logger = logging.getLogger(__name__)

# --- 2. ĐỊNH NGHĨA KIẾN TRÚC MODEL CHÍNH XÁC ---
# Class này phải khớp 100% với class đã dùng để huấn luyện và lưu file .bin
class PhoBERT_Classifier(nn.Module):
    def __init__(self, n_classes=3, dropout_rate=0.3):
        super(PhoBERT_Classifier, self).__init__()
        logger.info("Khởi tạo kiến trúc PhoBERT_Classifier...")
        
        # Tải PhoBERT-large bên trong class để đóng gói tốt hơn
        self.phobert = AutoModel.from_pretrained("vinai/phobert-large")
        
        # Đây là kiến trúc Mạng Nơ-ron Nhân tạo (ANN) khớp với file .bin của bạn
        self.ann_classifier = nn.Sequential(
            nn.Dropout(p=dropout_rate),
            nn.Linear(self.phobert.config.hidden_size, 512), # hidden_size của phobert-large là 1024
            nn.ReLU(),
            nn.Dropout(p=dropout_rate),
            nn.Linear(512, 128),
            nn.ReLU(),
            nn.Dropout(p=dropout_rate),
            nn.Linear(128, n_classes)
        )

    def forward(self, input_ids, attention_mask):
        # Lấy output từ PhoBERT
        outputs = self.phobert(input_ids=input_ids, attention_mask=attention_mask)
        # Lấy vector đại diện của token [CLS] (ở vị trí 0) để phân loại
        pooled_output = outputs.last_hidden_state[:, 0]
        # Đưa qua bộ phân loại ANN để có được logits
        logits = self.ann_classifier(pooled_output)
        return logits

# --- 3. TẢI MODEL VÀ TOKENIZER (CHỈ MỘT LẦN KHI SERVER KHỞI ĐỘNG) ---
try:
    # Xác định thiết bị (ưu tiên GPU nếu có, không thì dùng CPU)
    # device = torch.device("cuda" if torch.cuda.is_available() else "cpu")
    # Để an toàn cho server, mặc định dùng CPU để tránh lỗi nếu không có CUDA
    device = torch.device("cpu")
    logger.info(f"Sử dụng thiết bị: {device}")

    # Tải tokenizer tương ứng với model
    logger.info("Đang tải PhoBERT Tokenizer (vinai/phobert-large)...")
    tokenizer = AutoTokenizer.from_pretrained("vinai/phobert-large")
    logger.info("Tải Tokenizer thành công!")

    # Khởi tạo model với kiến trúc chính xác
    model = PhoBERT_Classifier(n_classes=3).to(device)

    # Tải trọng số đã huấn luyện
    model_path = "data/huit_cfs_phoBERT_ANN_dict_augmentation.bin"
    logger.info(f"Đang tải trọng số từ file: {model_path}")
    model.load_state_dict(torch.load(model_path, map_location=device))
    
    # Chuyển model sang chế độ đánh giá (inference mode)
    # Điều này rất quan trọng để tắt các lớp như Dropout
    model.eval()
    logger.info("Tải model và trọng số thành công! Server đã sẵn sàng.")

except FileNotFoundError:
    logger.error(f"LỖI: Không tìm thấy file trọng số '{model_path}'. Vui lòng kiểm tra lại đường dẫn.")
    exit()
except Exception as e:
    logger.error(f"LỖI KHÔNG MONG MUỐN KHI TẢI MODEL: {e}")
    exit()


# --- 4. CÁC HÀM TIỀN XỬ LÝ VĂN BẢN ---

# Dictionary các từ viết tắt
abbreviation_dict = {
    'ko': 'không', 'k': 'không', 'hok': 'không', 'khong': 'không', 'kg': 'không',
    'dc': 'được', 'đc': 'được', 'đz': 'được', 'dkk': 'được không',
    'j': 'gì', 'cj': 'cái gì', 'z': 'rồi', 'r': 'rồi', 'zô': 'vào', 'zui': 'vui',
    'thik': 'thích', 'vs': 'với', 'mk': 'mình', 'm': 'mày', 'b': 'bạn',
    'bj': 'bây giờ', 'bh': 'bây giờ', 'jz': 'giờ',
    'ntn': 'như thế nào', 'vl': 'vãi lồn', 'vkl': 'vãi cả lồn',
    'đt': 'điện thoại', 'nx': 'nhé', 'okie': 'ok', 'p': 'phải', 'pk': 'phải không',
    'cx': 'cũng', 'wá': 'quá', 'ngta': 'người ta', 'hix': 'buồn', 'hihi': 'cười',
    'zậy': 'vậy', 'dm': 'địt mẹ', 'đm': 'địt mẹ', 'cc': 'cặc cụ',
    'vk': 'vợ', 'ck': 'chồng', 'cf': 'cà phê', 'gấu': 'người yêu',
    'tks': 'thanks', 'thx': 'thanks', 'ty': 'thank you', 'plz': 'please',
    'mn': 'mọi người', 'fb': 'facebook', 'yt': 'youtube', 'ig': 'instagram',
    'lol': 'laugh out loud', 'omg': 'oh my god', 'idk': 'I don’t know', 'btw': 'by the way',
    'tui': 'tôi', 'cmt': 'comment', 'ns': 'nói', 'lm': 'làm', 'bik': 'biết', 'bjt': 'biết'
    # Bạn có thể thêm các từ viết tắt khác vào đây
}

def normalize_text(text):
    """Hàm chuẩn hóa văn bản: xóa URL, icon, tag HTML và thay thế từ viết tắt."""
    if not isinstance(text, str):
        return ""
    # Xóa tag HTML
    text = re.sub(r'<.*?>', '', text)
    # Xóa URL
    text = re.sub(r'https?://\S+|www\.\S+', '', text)
    # Xóa icon, emoji
    emoji_pattern = re.compile(
        "["
        u"\U0001F600-\U0001F64F"  # emoticons
        u"\U0001F300-\U0001F5FF"  # symbols & pictographs
        u"\U0001F680-\U0001F6FF"  # transport & map symbols
        u"\U0001F1E0-\U0001F1FF"  # flags (iOS)
        u"\U00002702-\U000027B0"
        u"\U000024C2-\U0001F251"
        "]+",
        flags=re.UNICODE,
    )
    text = emoji_pattern.sub(r'', text)
    # Thay thế từ viết tắt
    def replace_abbr(match):
        word = match.group(0)
        return abbreviation_dict.get(word.lower(), word)
    
    pattern = re.compile(r'\b(' + '|'.join(re.escape(k) for k in abbreviation_dict.keys()) + r')\b', re.IGNORECASE)
    text = pattern.sub(replace_abbr, text)
    # Chuẩn hóa khoảng trắng
    text = re.sub(r'\s+', ' ', text).strip()
    return text

# --- 5. HÀM DỰ ĐOÁN ---
def predict_sentiment(text):
    """
    Hàm nhận một câu văn bản, tiền xử lý, token hóa và đưa qua model để dự đoán.
    Returns:
        int: Nhãn dự đoán (0, 1, hoặc 2).
    """
    # Token hóa văn bản
    encoding = tokenizer(
        text, 
        padding='max_length',      # Pad câu đến max_length
        truncation=True,           # Cắt câu nếu dài hơn max_length
        max_length=128,            # Độ dài tối đa của câu
        return_tensors="pt"        # Trả về Pytorch tensors
    )
    
    # Chuyển tensors sang thiết bị đã chọn (CPU/GPU)
    input_ids = encoding['input_ids'].to(device)
    attention_mask = encoding['attention_mask'].to(device)

    # Thực hiện dự đoán (không cần tính gradient)
    with torch.no_grad():
        output = model(input_ids, attention_mask)
        # Lấy nhãn có xác suất cao nhất bằng torch.argmax
        sentiment_id = torch.argmax(output, dim=1).item()

    return sentiment_id

# --- 6. KHỞI TẠO FLASK APP VÀ ĐỊNH NGHĨA API ENDPOINT ---
app = Flask(__name__)

# Kích hoạt CORS để cho phép frontend (ví dụ: chạy ở port 3001) gọi đến API này
CORS(app, resources={r"/predict": {"origins": "http://localhost:3001"}})

@app.route('/predict', methods=['POST'])
def predict_api():
    """API endpoint để nhận văn bản và trả về kết quả dự đoán."""
    try:
        data = request.get_json()
        text = data.get('text')
        
        # Kiểm tra dữ liệu đầu vào
        if not text:
            logger.warning("Yêu cầu không hợp lệ: Thiếu trường 'text'.")
            return jsonify({
                "status": "error",
                "value": None,
                "message": "Không có văn bản nào được cung cấp. Vui lòng gửi JSON có trường 'text'."
            }), 400 # Bad Request

        logger.info(f"Nhận được yêu cầu dự đoán cho câu: '{text}'")

        # 1. Chuẩn hóa văn bản
        normalized_text = normalize_text(text)
        logger.info(f"Văn bản sau khi chuẩn hóa: '{normalized_text}'")

        # 2. Dự đoán cảm xúc
        if not normalized_text:
             prediction_id = 1 # Coi là Neutral nếu sau khi xử lý không còn chữ
        else:
            prediction_id = predict_sentiment(normalized_text)

        # Map id sang nhãn chữ (tùy chọn, để response dễ đọc hơn)
        # Dựa trên file train của bạn, giả sử: 0: Tiêu cực, 1: Trung tính, 2: Tích cực
        # Hãy điều chỉnh lại cho đúng với ý nghĩa nhãn của bạn
        label_map = {0: "Tiêu cực", 1: "Trung tính", 2: "Tích cực"}
        prediction_label = label_map.get(prediction_id, "Không xác định")

        logger.info(f"Kết quả dự đoán: ID = {prediction_id}, Nhãn = {prediction_label}")

        # 3. Trả về kết quả
        response = {
            "status": "success",
            "value": prediction_id,
            "label": prediction_label,
            "message": "Dự đoán thành công"
        }
        return jsonify(response), 200 # OK

    except Exception as e:
        logger.exception(f"Một lỗi đã xảy ra trong quá trình xử lý API: {e}")
        return jsonify({
            "status": "error",
            "value": None,
            "message": f"Lỗi máy chủ nội bộ: {e}"
        }), 500 # Internal Server Error

# --- 7. CHẠY FLASK APP ---
if __name__ == '__main__':
    # Chạy server ở port 5000 và cho phép truy cập từ mọi địa chỉ IP (host='0.0.0.0')
    app.run(host='0.0.0.0', port=5000, debug=False)