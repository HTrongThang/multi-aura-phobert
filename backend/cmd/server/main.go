package main

import (
	"context"
	"fmt"
	"log"
	config "multiaura/internal/configs/dev"
	"multiaura/internal/databases"
	"multiaura/routes"
	"os"
	"os/signal"
	"syscall"
	"time"

	"github.com/gofiber/fiber/v2"
	"github.com/joho/godotenv"
)

func main() {
	err := godotenv.Load()
	if err != nil {
		log.Fatalf("Could not load env: %v", err)
	}

	// Tạo Fiber app
	app := fiber.New()

	// Nạp cấu hình từ file config.yaml
	cfg, err := config.Instance()
	if err != nil {
		log.Fatalf("Could not load config: %v", err)
	}

	// Tạo kết nối Neo4j với cấu hình đã nạp
	DB, err := databases.NewNeo4jDB(&cfg.Neo4j)
	if err != nil {
		log.Fatalf("Could not connect to Neo4j: %v", err)
	}
	fmt.Println("Connected to Neo4j successfully!")

	// Tạo kết nối MongoDB với cấu hình đã nạp
	mongoDB, err := databases.NewMongoDB(&cfg.Mongo)
	if err != nil {
		log.Fatalf("Could not connect to MongoDB: %v", err)
	}
	fmt.Println("Connected to MongoDB successfully!")

	fmt.Printf("Cloudinary URL: %s\n", cfg.GetCloudinaryURL())

	// Thiết lập các route
	routes.SetupRoutes(app)

	// Khởi động server trong một goroutine để có thể chờ tín hiệu dừng
	go func() {
		if err := app.Listen(":3000"); err != nil {
			log.Fatalf("Error starting server: %v", err)
		}
	}()

	// Channel chờ tín hiệu dừng (SIGINT, SIGTERM)
	quit := make(chan os.Signal, 1)
	signal.Notify(quit, syscall.SIGINT, syscall.SIGTERM)

	// Chờ tín hiệu dừng từ hệ thống
	<-quit
	fmt.Println("Gracefully shutting down server...")

	// Tạo context với thời gian chờ khi tắt ứng dụng
	_, cancel := context.WithTimeout(context.Background(), 10*time.Second)
	defer cancel()

	// Đóng Fiber app một cách sạch sẽ
	if err := app.Shutdown(); err != nil {
		log.Fatalf("Error shutting down server: %v", err)
	}

	// Ngắt kết nối với Neo4j
	fmt.Println("Disconnecting from Neo4j...")
	DB.Disconnect()

	// Ngắt kết nối với MongoDB
	fmt.Println("Disconnecting from MongoDB...")
	mongoDB.Disconnect()

	// Ngắt kết nối với gRPC
	fmt.Println("Disconnecting from gRPC...")

	routes.ShutdownGRPC()

	fmt.Println("Server shutdown and databases disconnected successfully")
}
