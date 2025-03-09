package controllers

import (
	"mime/multipart"
	"multiaura/internal/services"
	APIResponse "multiaura/pkg/api_response"
	"strings"

	"github.com/gofiber/fiber/v2"
)

type UploadController struct {
	service services.UploadService
}

func NewUploadController(service services.UploadService) *UploadController {
	return &UploadController{service}
}

func (uc *UploadController) UploadProfilePhoto(c *fiber.Ctx) error {
	userID := c.Locals("userID").(string)
	if userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	fileHeader, err := c.FormFile("image")
	if err != nil {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Invalid file",
			Error:   err.Error(),
		})
	}

	file, err := fileHeader.Open()
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Unable to open file",
			Error:   err.Error(),
		})
	}
	defer file.Close()

	url, err := uc.service.UploadProfilePhoto(userID, file, fileHeader)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Failed to upload profile picture",
			Error:   err.Error(),
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Profile picture uploaded successfully",
		Data:    fiber.Map{"url": url},
	})
}

func (uc *UploadController) UploadPostMediaData(c *fiber.Ctx) error {
	userID := c.Locals("userID").(string)
	if userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	postID := c.Params("postID")
	if postID == "" {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Missing post ID",
			Error:   "PostIDMissing",
		})
	}

	form, err := c.MultipartForm()
	if err != nil {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Invalid form data",
			Error:   err.Error(),
		})
	}

	files := form.File["photos"]

	text := ""
	if val, ok := form.Value["text"]; ok && len(val) > 0 {
		text = val[0]
	}

	if len(files) == 0 && text == "" {
		return c.Status(fiber.StatusFailedDependency).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusFailedDependency,
			Message: "No media or text provided",
			Error:   "NoMediaOrTextProvided",
		})
	}

	var openedFiles []multipart.File
	if len(files) > 0 {
		for _, fileHeader := range files {
			file, err := fileHeader.Open()
			if err != nil {
				return c.Status(fiber.StatusUnsupportedMediaType).JSON(APIResponse.ErrorResponse{
					Status:  fiber.StatusUnsupportedMediaType,
					Message: "Unable to open file",
					Error:   err.Error(),
				})
			}
			defer file.Close()
			openedFiles = append(openedFiles, file)
		}
	}

	fileURLs, err := uc.service.UploadPostMediaData(postID, userID, text, openedFiles, files)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Failed to upload post medias",
			Error:   err.Error(),
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Post medias uploaded successfully",
		Data:    fiber.Map{"urls": fileURLs},
	})
}
func (uc *UploadController) UploadConversationImageData(c *fiber.Ctx) error {
	userID := c.Locals("userID").(string)
	if userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	conversatinID := c.Params("conversatinID")
	if conversatinID == "" {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Missing conversationID",
			Error:   "conversationID Missing",
		})
	}

	form, err := c.MultipartForm()
	if err != nil {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Invalid form data",
			Error:   err.Error(),
		})
	}

	files := form.File["photos"]
	if len(files) == 0 {
		return c.Status(fiber.StatusFailedDependency).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusFailedDependency,
			Message: "No image provided",
			Error:   "No image",
		})
	}

	if len(files) > 1 {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Only one image allowed",
			Error:   "Multiple files not allowed",
		})
	}

	fileHeader := files[0]

	if !isValidImage(fileHeader) {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Invalid file type, only images allowed",
			Error:   "InvalidFileType",
		})
	}

	file, err := fileHeader.Open()
	if err != nil {
		return c.Status(fiber.StatusUnsupportedMediaType).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnsupportedMediaType,
			Message: "Unable to open file",
			Error:   err.Error(),
		})
	}
	defer file.Close()

	fileURLs, err := uc.service.UploadConversationImageData(conversatinID, []multipart.File{file}, files)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Failed to upload image",
			Error:   err.Error(),
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Image uploaded successfully",
		Data:    fiber.Map{"urls": fileURLs},
	})
}

func isValidImage(fileHeader *multipart.FileHeader) bool {
	contentType := fileHeader.Header.Get("Content-Type")
	return strings.HasPrefix(contentType, "image/")
}

func (uc *UploadController) UploadCommentsMediaData(c *fiber.Ctx) error {
	userID := c.Locals("userID").(string)
	if userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	commentID := c.Params("commentID")
	if commentID == "" {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Missing comment ID",
			Error:   "CommentIDMissing",
		})
	}

	form, err := c.MultipartForm()
	if err != nil {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Invalid form data",
			Error:   err.Error(),
		})
	}

	files := form.File["photos"]

	text := ""
	if val, ok := form.Value["text"]; ok && len(val) > 0 {
		text = val[0]
	}

	if len(files) == 0 && text == "" {
		return c.Status(fiber.StatusFailedDependency).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusFailedDependency,
			Message: "No media or text provided",
			Error:   "NoMediaOrTextProvided",
		})
	}

	var openedFiles []multipart.File
	if len(files) > 0 {
		for _, fileHeader := range files {
			file, err := fileHeader.Open()
			if err != nil {
				return c.Status(fiber.StatusUnsupportedMediaType).JSON(APIResponse.ErrorResponse{
					Status:  fiber.StatusUnsupportedMediaType,
					Message: "Unable to open file",
					Error:   err.Error(),
				})
			}
			defer file.Close()
			openedFiles = append(openedFiles, file)
		}
	}

	fileURLs, err := uc.service.UploadCommentMediaData(commentID, userID, text, openedFiles, files)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Failed to upload comment medias",
			Error:   err.Error(),
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Comment medias uploaded successfully",
		Data:    fiber.Map{"urls": fileURLs},
	})
}

func (uc *UploadController) UploadReplyCommentMediaData(c *fiber.Ctx) error {
	userID := c.Locals("userID").(string)
	if userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	commentID := c.Params("commentID")
	if commentID == "" {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Missing comment ID",
			Error:   "CommentIDMissing",
		})
	}

	replyID := c.Params("replyID")
	if replyID == "" {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Missing reply ID",
			Error:   "ReplyIDMissing",
		})
	}

	form, err := c.MultipartForm()
	if err != nil {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Invalid form data",
			Error:   err.Error(),
		})
	}

	files := form.File["photos"]

	text := ""
	if val, ok := form.Value["text"]; ok && len(val) > 0 {
		text = val[0]
	}

	if len(files) == 0 && text == "" {
		return c.Status(fiber.StatusFailedDependency).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusFailedDependency,
			Message: "No media or text provided",
			Error:   "NoMediaOrTextProvided",
		})
	}

	var openedFiles []multipart.File
	if len(files) > 0 {
		for _, fileHeader := range files {
			file, err := fileHeader.Open()
			if err != nil {
				return c.Status(fiber.StatusUnsupportedMediaType).JSON(APIResponse.ErrorResponse{
					Status:  fiber.StatusUnsupportedMediaType,
					Message: "Unable to open file",
					Error:   err.Error(),
				})
			}
			defer file.Close()
			openedFiles = append(openedFiles, file)
		}
	}

	fileURLs, err := uc.service.UploadReplyCommentMediaData(commentID, replyID, userID, text, openedFiles, files)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Failed to upload reply comment medias",
			Error:   err.Error(),
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Reply comment medias uploaded successfully",
		Data:    fiber.Map{"urls": fileURLs},
	})
}

func (uc *UploadController) DeletePostMediaData(c *fiber.Ctx) error {
	userID := c.Locals("userID").(string)
	if userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	postID := c.Params("postID")
	if postID == "" {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Missing post ID",
			Error:   "PostIDMissing",
		})
	}

	err := uc.service.DeletePostMediaData(postID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Failed to delete post medias",
			Error:   err.Error(),
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Post medias deleted successfully",
		Data:    nil,
	})
}

func (uc *UploadController) DeleteCommentMediaData(c *fiber.Ctx) error {
	userID := c.Locals("userID").(string)
	if userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	commentID := c.Params("commentID")
	if commentID == "" {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Missing comment ID",
			Error:   "CommentIDMissing",
		})
	}

	err := uc.service.DeleteCommentMediaData(commentID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Failed to delete comment medias",
			Error:   err.Error(),
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Comment medias deleted successfully",
		Data:    nil,
	})
}

func (uc *UploadController) DeleteReplyCommentMediaData(c *fiber.Ctx) error {
	userID := c.Locals("userID").(string)
	if userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	commentID := c.Params("commentID")
	if commentID == "" {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Missing comment ID",
			Error:   "CommentIDMissing",
		})
	}

	replyID := c.Params("replyID")
	if replyID == "" {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Missing reply ID",
			Error:   "ReplyIDMissing",
		})
	}

	err := uc.service.DeleteReplyCommentMediaData(commentID, replyID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Failed to delete reply comment medias",
			Error:   err.Error(),
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Reply comment medias deleted successfully",
		Data:    nil,
	})
}
