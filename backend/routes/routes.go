package routes

import (
	"log"
	"multiaura/internal/databases"
	toxicity "multiaura/plugins/proto"

	"github.com/gofiber/fiber/v2"
	"github.com/gofiber/fiber/v2/middleware/cors"
	"google.golang.org/grpc"
)

var neo4jDB *databases.Neo4jDB
var mongoDB *databases.MongoDB
var cloudinaryURL string
var toxicityClient toxicity.ToxicityServiceClient
var conn *grpc.ClientConn

func SetupRoutes(app *fiber.App) {

	app.Use(cors.New(cors.Config{
		AllowOrigins:     "http://localhost:3001",       // Cho phép từ frontend chạy trên localhost:3001
		AllowCredentials: true,                          // Nếu bạn dùng cookies hay thông tin xác thực
		AllowMethods:     "GET,POST,PUT,DELETE",         // Các phương thức được cho phép
		AllowHeaders:     "Content-Type, Authorization", // Các headers được phép
	}))

	neo4jDB = databases.Neo4jInstance()
	mongoDB = databases.MongoInstance()

	// Tạo kết nối gRPC
	conn, err := grpc.Dial("localhost:50051", grpc.WithInsecure(), grpc.WithBlock())
	if err != nil {
		log.Fatalf("could not connect to gRPC server: %v", err)
	}

	// Tạo kết nối gRPC
	// conn, err := grpc.Dial("vietnamese-cyberbullying:50051", grpc.WithInsecure(), grpc.WithBlock())
	// if err != nil {
	// 	log.Fatalf("could not connect to vietnamese-cyberbullying:50051: %v", err)
	// }

	log.Printf("connect to gRPC server successfully: %v", conn)

	// Tạo gRPC client
	toxicityClient = toxicity.NewToxicityServiceClient(conn)

	SetupUserRoutes(app)
	SetupRelationshipRoutes(app)
	SetupPostRoutes(app)
	SetupSearchRoutes(app)
	SetupUploadRoutes(app)
	SetupConversationRoutes(app)

}

func ShutdownGRPC() {
	if conn != nil {
		conn.Close()
	}
}
