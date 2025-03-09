FROM python:3.10.2

# Cài đặt curl và tải grpcurl
RUN apt-get update && apt-get install -y curl \
    && curl -Lo grpcurl_1.8.2_linux_x86_64.tar.gz https://github.com/fullstorydev/grpcurl/releases/download/v1.8.2/grpcurl_1.8.2_linux_x86_64.tar.gz \
    && ls -l grpcurl_1.8.2_linux_x86_64.tar.gz \   
    # Kiểm tra tệp có tồn tại không
    && tar -xzvf grpcurl_1.8.2_linux_x86_64.tar.gz \
    && mv grpcurl /usr/local/bin/ \
    && rm grpcurl_1.8.2_linux_x86_64.tar.gz

WORKDIR /app

COPY requirements.txt .

RUN pip install --no-cache-dir -r requirements.txt

COPY . .

CMD ["python", "server.py"]
