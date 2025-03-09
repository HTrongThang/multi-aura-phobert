package routes

import (
	"multiaura/internal/controllers"
	"multiaura/internal/middlewares"
	"multiaura/internal/repositories"
	"multiaura/internal/services"

	"github.com/gofiber/fiber/v2"
)

func SetupPostRoutes(app *fiber.App) {
	userRepository := repositories.NewUserRepository(neo4jDB)
	postRepository := repositories.NewPostRepository(mongoDB)
	service := services.NewPostService(&postRepository, &userRepository, &toxicityClient)
	controller := controllers.NewPostController(service)

	posts := app.Group("/post")

	posts.Post("/user/:userID", middlewares.AuthMiddleware(), controller.GetPostsByUser)

	posts.Post("/like/:postID", middlewares.AuthMiddleware(), controller.LikePost)
	posts.Delete("/unlike/:postID", middlewares.AuthMiddleware(), controller.UnlikePost)

	posts.Post("/comment/like/:commentID", middlewares.AuthMiddleware(), controller.LikeComment)
	posts.Delete("/comment/unlike/:commentID", middlewares.AuthMiddleware(), controller.UnlikeComment)

	posts.Post("/reply/like/:commentID/:replyID", middlewares.AuthMiddleware(), controller.LikeReplyComment)
	posts.Delete("/reply/unlike/:commentID/:replyID", middlewares.AuthMiddleware(), controller.UnlikeReplyComment)

	posts.Post("/comments/:postID", middlewares.AuthMiddleware(), controller.GetCommentsByPostID)
	posts.Get("/comment/:commentID", middlewares.AuthMiddleware(), controller.GetCommentByID)
	posts.Get("/reply/:commentID/:replyID", middlewares.AuthMiddleware(), controller.GetReplyCommentByID)

	posts.Post("/add-comment/:postID", middlewares.AuthMiddleware(), controller.CreateComment)
	posts.Delete("/delete-comment/:commentID", middlewares.AuthMiddleware(), controller.DeleteComment)

	posts.Post("/add-reply/:commentID", middlewares.AuthMiddleware(), controller.AddReplyToComment)
	posts.Delete("/delete-reply/:commentID/:replyID", middlewares.AuthMiddleware(), controller.DeleteReplyFromComment)

	posts.Post("/toxic-posts/:toxicity", middlewares.AuthMiddleware(), controller.GetToxicPosts)
	posts.Get("/toxic-posts/:toxicity/date", middlewares.AuthMiddleware(), controller.GetToxicPostsByDate)
	posts.Post("/recents", middlewares.AuthMiddleware(), controller.GetRecentPosts)
	posts.Post("/create", middlewares.AuthMiddleware(), controller.CreatePost)
	posts.Delete("/delete/:postID", middlewares.AuthMiddleware(), controller.DeletePost)
	posts.Get("/:id", controller.GetPostByID)
}
