import torch
import torch.nn as nn
from transformers import AutoModel, AutoTokenizer
from flask import Flask, request, jsonify
from flask_cors import CORS  # Import Flask-CORS

# Load PhoBERT và Tokenizer
phobert = AutoModel.from_pretrained("vinai/phobert-base-v2")
tokenizer = AutoTokenizer.from_pretrained("vinai/phobert-base-v2")

# PhoBERT Model Class
class PhoBERT_Classifier(nn.Module):
    def __init__(self, num_classes=3):
        super(PhoBERT_Classifier, self).__init__()
        self.phobert = phobert
        self.rnn = nn.RNN(768, 128, batch_first=True)
        self.fc = nn.Linear(128, num_classes)

    def forward(self, input_ids, attention_mask):
        outputs = self.phobert(input_ids=input_ids, attention_mask=attention_mask)
        rnn_out, _ = self.rnn(outputs.last_hidden_state)
        out = self.fc(rnn_out[:, -1, :])
        return out

# Load trained model
device = torch.device("cpu")  # Sử dụng CPU
model = PhoBERT_Classifier().to(device)
model.load_state_dict(torch.load("data/phobert_sentiment_vsmec.pth", map_location=torch.device('cpu')))
model.eval()

# Flask app setup
app = Flask(__name__)

# Enable CORS for frontend at http://localhost:3001
CORS(app, resources={r"/predict": {"origins": "http://localhost:3001"}})

# Hàm dự đoán cảm xúc
def predict_sentiment(text):
    encoding = tokenizer(text, padding='max_length', truncation=True, max_length=128, return_tensors="pt")
    input_ids, attention_mask = encoding['input_ids'].to(device), encoding['attention_mask'].to(device)

    with torch.no_grad():
        output = model(input_ids, attention_mask)
        sentiment = torch.argmax(output, dim=1).item()

    return sentiment

@app.route('/predict', methods=['POST'])
def predict():
    data = request.get_json()  
    text = data.get('text')    
    
    if not text:
        return jsonify({
            "status": "error",
            "value": None,
            "message": "No text provided"
        }), 400

    # Dự đoán cảm xúc
    sentiment = predict_sentiment(text)
    
    return jsonify({
        "status": "success",
        "value": sentiment,
        "message": "Sentiment prediction successful"
    })

# Chạy Flask app trên cổng 6000
if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)
