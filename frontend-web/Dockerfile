# frontend-web/Dockerfile
FROM node:20.18.0

WORKDIR /app

# Sao chép package.json và package-lock.json để cài đặt dependencies
COPY package*.json ./

# Cài đặt dependencies với npm 10.9.0
RUN npm install -g npm@10.9.0 && npm install

# Sao chép toàn bộ mã nguồn
COPY . .

# Mở cổng 3000 để truy cập ứng dụng
EXPOSE 3000

# Chạy ứng dụng
CMD ["npm", "start"]
