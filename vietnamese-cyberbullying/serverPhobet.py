from flask import Flask, request, jsonify
from flask_cors import CORS  # Import Flask-CORS
import torch
import torch.nn as nn
from transformers import AutoModel, AutoTokenizer
import numpy as np  # Import NumPy
import logging

# --- Thiết lập logging ---
logging.basicConfig(level=logging.INFO, format='%(asctime)s - %(levelname)s - %(message)s')
logger = logging.getLogger(__name__)

# 1. Định nghĩa kiến trúc mô hình PhoBERTANN
class PhoBERTANN(nn.Module):
    def __init__(self, phobert, num_classes=3, dropout_rate=0.5):
        super().__init__()
        self.phobert = phobert
        self.fc1 = nn.Linear(768, 512)
        self.relu1 = nn.ReLU()
        self.dropout1 = nn.Dropout(dropout_rate)
        self.fc2 = nn.Linear(512, 256)
        self.relu2 = nn.ReLU()
        self.dropout2 = nn.Dropout(dropout_rate)
        self.fc3 = nn.Linear(256, num_classes)

    def forward(self, input_ids, attention_mask):
        outputs = self.phobert(input_ids=input_ids, attention_mask=attention_mask)
        cls_token = outputs.last_hidden_state[:, 0, :]
        x = self.fc1(cls_token)
        x = self.relu1(x)
        x = self.dropout1(x)
        x = self.fc2(x)
        x = self.relu2(x)
        x = self.dropout2(x)
        x = self.fc3(x)
        return x

# 2. Load PhoBERT tokenizer và mô hình cơ sở (chỉ load một lần khi khởi động API)
try:
    phobert = AutoModel.from_pretrained("vinai/phobert-base-v2")
    tokenizer = AutoTokenizer.from_pretrained("vinai/phobert-base-v2")
    logger.info("PhoBERT model and tokenizer loaded successfully.")
except Exception as e:
    logger.error(f"Error loading PhoBERT: {e}")
    exit()

# 3. Xác định thiết bị (chỉ xác định một lần khi khởi động API)
device = torch.device("cuda" if torch.cuda.is_available() else "cpu")
logger.info(f"Using device: {device}")

# 4. Tạo instance của mô hình PhoBERTANN (chỉ tạo một lần khi khởi động API)
try:
    model = PhoBERTANN(phobert, num_classes=3).to(device)
    model.load_state_dict(torch.load("data/phobert_ann_v10_huit_cfs.pth", map_location=device))
    model.eval()  # Chuyển mô hình sang chế độ đánh giá
    logger.info("Trained model loaded successfully.")
except FileNotFoundError:
    logger.error("Error: Model file 'phobert_ann_v10_huit_cfs.pth' not found.  Make sure it is in the correct directory.")
    exit()
except RuntimeError as e:
    logger.error(f"Error loading model state_dict: {e}")
    logger.error("Ensure the model architecture in your code matches the architecture of the saved model.")
    exit()
except Exception as e:
    logger.exception(f"An unexpected error occurred while loading the model: {e}")
    exit()

# 5. Hàm dự đoán cảm xúc
def predict_single(sentence, model, tokenizer, device, threshold=0.6):
    """
    Predicts the sentiment of a single sentence using the loaded PhoBERT model.

    Args:
        sentence (str): The input sentence to predict sentiment for.
        model (nn.Module): The loaded PhoBERTANN model.
        tokenizer (AutoTokenizer): The PhoBERT tokenizer.
        device (torch.device): The device to use (CPU or GPU).
        threshold (float, optional):  Not used in the current version. Defaults to 0.6.

    Returns:
        int: The predicted sentiment label (0: positive, 1: neutral, 2: negative).
    """
    model.eval()
    try:
        encoded = tokenizer.encode_plus(
            sentence,
            add_special_tokens=True,
            max_length=256,
            padding='max_length',
            truncation=True,
            return_attention_mask=True,
            return_tensors='pt'
        )
        input_ids = encoded['input_ids'].to(device)
        attention_mask = encoded['attention_mask'].to(device)

        with torch.no_grad():
            output = model(input_ids, attention_mask)
            prob_model = torch.softmax(output, dim=1).cpu().numpy()[0]  # Shape: (3,)

        final_label = int(np.argmax(prob_model))  # Get the index of the max probability
        return final_label
    except Exception as e:
        logger.error(f"Error predicting sentiment for sentence: '{sentence}': {e}")
        return None  # Or raise the exception, depending on how you want to handle errors


# 6. Flask app setup
app = Flask(__name__)
CORS(app, resources={r"/predict": {"origins": "http://localhost:3001"}})  # Enable CORS

@app.route('/predict', methods=['POST'])
def predict_api():
    """
    API endpoint for predicting sentiment.  Accepts a POST request with a JSON payload
    containing the sentence to predict.

    Returns:
        jsonify: A JSON response containing the original sentence and the predicted
            sentiment label (0, 1, or 2).  Returns an error message if the request
            is invalid or an error occurs during prediction.
    """
    try:
        data = request.get_json()
        if not data or 'text' not in data:
            return jsonify({
                "status": "error",
                "value": None,
                "message": "No text provided.  Please send a JSON payload with a 'text' field."
            }), 400  # Bad Request
        sentence = data['text']
        logger.info(f"Received request for sentence: '{sentence}'")

        # Dự đoán cảm xúc
        prediction_id = predict_single(sentence, model, tokenizer, device)

        if prediction_id is None:
            return jsonify({
                "status": "error",
                "value": None,
                "message": f"Failed to predict sentiment for the given text."
            }), 500  # Internal Server Error

        label_map = {0: "positive", 1: "neutral", 2: "negative"}
        prediction_label = label_map[prediction_id]

        response_data = {
            "status": "success",
            "value": prediction_id,
            "message": "Sentiment prediction successful"
        }
        logger.info(f"Prediction: {response_data}")
        return jsonify(response_data), 200  # OK
    except Exception as e:
        logger.exception(f"An error occurred during prediction: {e}")
        return jsonify({
            "status": "error",
            "value": None,
            "message": f"An error occurred: {e}"
        }), 500  # Internal Server Error

# 7. Chạy Flask app trên cổng 5000
if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)