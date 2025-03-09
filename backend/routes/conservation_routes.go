package routes

import (
	"multiaura/internal/controllers"
	"multiaura/internal/repositories"
	"multiaura/internal/services"

	"github.com/gofiber/fiber/v2"
)

func SetupConversationRoutes(app *fiber.App) {
	repository := repositories.NewConversationRepository(mongoDB)
	userrepository := repositories.NewUserRepository(neo4jDB)

	service := services.NewConversationService(repository, userrepository)
	controller := controllers.NewConversationController(service)

	conversation := app.Group("/conversation")
	conversation.Get("/get-user-conversations/:userID", controller.GetListConversation)
	conversation.Get("/detais-coversation/:conversationID/:userID", controller.GetConversationByID)
	conversation.Post("/create-conversation", controller.CreateConversation)
	conversation.Post("/add-member-message", controller.AddMember)
	conversation.Delete("/remove-member-conversation/:conversationID/:userID", controller.RemoveMemberConversation)
	conversation.Post("/send-message/:conversationID", controller.SendMessage)
	conversation.Get("/get-conversation-messages/:conversationID", controller.GetMessages)
	conversation.Delete("/delete-message/:conversationID/:messageID", controller.MarkMessageAsDeleted)

}
