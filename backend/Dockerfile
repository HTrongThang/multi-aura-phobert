# Use a base image for Go
FROM golang:1.23 AS build

# Install necessary dependencies (e.g., alsa for audio libraries)
RUN apt-get update && apt-get install -y \
    libasound2-dev \
    pkg-config \
    && rm -rf /var/lib/apt/lists/*

# Set the working directory inside the container
WORKDIR /app

# Copy the Go modules files and install dependencies
COPY go.mod go.sum ./
RUN go mod download

# Copy the rest of the application files
COPY . .

# Build the Go application
RUN go build -o main ./cmd/server

# Expose the port
EXPOSE 8080

# Command to run the application
CMD ["./main"]
