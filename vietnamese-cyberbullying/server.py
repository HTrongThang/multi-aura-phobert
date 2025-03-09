import grpc
from concurrent import futures
import toxicity_pb2
import toxicity_pb2_grpc
from transformers import AutoTokenizer, AutoModelForSequenceClassification
import torch
import torch.nn.functional as F
import json

# Load configuration
with open("config/test_config.json", "r") as f:
    config = json.load(f)

# Load tokenizer and model
tokenizer = AutoTokenizer.from_pretrained(config["model_dir"])
model = AutoModelForSequenceClassification.from_pretrained(config["model_dir"])
model.eval()

# gRPC service implementation
class ToxicityService(toxicity_pb2_grpc.ToxicityServiceServicer):
    def AnalyzeText(self, request, context):
        text = request.text
        toxicity_score = predict_single_text_with_toxicity(model, tokenizer, text, max_length=config["max_length"])
        return toxicity_pb2.AnalyzeResponse(toxicity_score=toxicity_score)

def predict_single_text_with_toxicity(model, tokenizer, text, max_length):
    tokens = tokenizer(
        text,
        padding="max_length",
        truncation=True,
        max_length=max_length,
        return_tensors="pt"
    )
    with torch.no_grad():
        outputs = model(input_ids=tokens["input_ids"], attention_mask=tokens["attention_mask"])
        probabilities = F.softmax(outputs.logits, dim=-1)
        toxicity_score = probabilities[0][1].item() + probabilities[0][2].item()
        toxicity_score = min(toxicity_score, 1.0)  # Clamp to 1.0
    return toxicity_score

# Run the gRPC server
def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    toxicity_pb2_grpc.add_ToxicityServiceServicer_to_server(ToxicityService(), server)
    server.add_insecure_port('[::]:50051')
    print("Server listening on port 50051...")
    server.start()
    server.wait_for_termination()

if __name__ == '__main__':
    serve()
