package routes

import (
	config "multiaura/internal/configs/dev"
	"multiaura/internal/controllers"
	"multiaura/internal/middlewares"
	"multiaura/internal/repositories"
	"multiaura/internal/services"

	"github.com/gofiber/fiber/v2"
)

func SetupUploadRoutes(app *fiber.App) {
	config, err := config.Instance()
	if err != nil {
		panic("Failed to load config: " + err.Error())
	}

	storageRepository, err := repositories.NewCloudinaryRepository(config.GetCloudinaryURL())
	if err != nil {
		panic("Failed to initialize Cloudinary repository: " + err.Error())
	}

	userRepository := repositories.NewUserRepository(neo4jDB)
	postRepository := repositories.NewPostRepository(mongoDB)
	conversationRepository := repositories.NewConversationRepository(mongoDB)

	service := services.NewUploadService(&userRepository, &postRepository, &storageRepository, conversationRepository)
	controller := controllers.NewUploadController(service)

	uploadGroup := app.Group("/upload")

	uploadGroup.Post("/profile-photo", middlewares.AuthMiddleware(), controller.UploadProfilePhoto)
	uploadGroup.Post("/post/medias/:postID", middlewares.AuthMiddleware(), controller.UploadPostMediaData)
	uploadGroup.Post("/conversation/image/:conversatinID", middlewares.AuthMiddleware(), controller.UploadConversationImageData)

	uploadGroup.Post("/comment/medias/:commentID", middlewares.AuthMiddleware(), controller.UploadCommentsMediaData)
	uploadGroup.Post("/reply/medias/:commentID/:replyID", middlewares.AuthMiddleware(), controller.UploadReplyCommentMediaData)

	//Delete from cloud
	uploadGroup.Delete("/post/medias/:postID", middlewares.AuthMiddleware(), controller.DeletePostMediaData)
	uploadGroup.Delete("/comment/medias/:commentID", middlewares.AuthMiddleware(), controller.DeleteCommentMediaData)
	uploadGroup.Delete("/reply/medias/:commentID/:replyID", middlewares.AuthMiddleware(), controller.DeleteReplyCommentMediaData)
}
