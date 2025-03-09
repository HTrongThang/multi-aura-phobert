package services

import (
	"errors"
	"fmt"
	"log"
	"mime/multipart"
	"multiaura/internal/models"
	"multiaura/internal/repositories"
	"multiaura/pkg/utils"
	"os"
	"strings"
	"time"

	"github.com/google/uuid"
	httgotts "github.com/hegedustibor/htgo-tts"
)

type UploadService interface {
	UploadProfilePhoto(userID string, file multipart.File, fileHeader *multipart.FileHeader) (string, error)
	UploadPostMediaData(postID, userID, text string, files []multipart.File, fileHeaders []*multipart.FileHeader) ([]string, error)
	UploadCommentMediaData(commentID, userID, text string, files []multipart.File, fileHeaders []*multipart.FileHeader) ([]string, error)
	UploadReplyCommentMediaData(commentID, replyID, userID, text string, files []multipart.File, fileHeaders []*multipart.FileHeader) ([]string, error)
	DeletePostMediaData(postID string) error
	DeleteCommentMediaData(commentID string) error
	DeleteReplyCommentMediaData(commentID, replyID string) error
	UploadConversationImageData(conversatinID string, files []multipart.File, fileHeaders []*multipart.FileHeader) ([]string, error)
}

type uploadService struct {
	userRepo         *repositories.UserRepository
	postRepo         *repositories.PostRepository
	storageRepo      *repositories.StorageRepository
	conversationRepo repositories.ConversationRepository
}

func NewUploadService(userRepo *repositories.UserRepository, postRepo *repositories.PostRepository, storageRepo *repositories.StorageRepository, conversationRepo repositories.ConversationRepository) UploadService {
	return &uploadService{userRepo, postRepo, storageRepo, conversationRepo}
}

func (s *uploadService) UploadProfilePhoto(userID string, file multipart.File, fileHeader *multipart.FileHeader) (string, error) {
	url, err := (*s.storageRepo).UploadFile(file, fileHeader, "profile-photos")
	if err != nil {
		return "", err
	}

	result, err := (*s.userRepo).UploadProfilePhoto(userID, url)
	if err != nil {
		return "", err
	}

	if !result {
		fileName, err := utils.ExtractPublicID(url)
		if err != nil {
			return "", err
		} else {
			fmt.Println("File name:", fileName)
		}
		if deleteErr := (*s.storageRepo).DeleteFile(fileName, "image"); deleteErr != nil {
			return "", errors.New("failed to upload profile photo, and unable to delete file")
		}
		return "", errors.New("failed to update your profile photo")
	}

	return url, nil
}

func (s *uploadService) UploadPostMediaData(postID, userID, text string, files []multipart.File, fileHeaders []*multipart.FileHeader) ([]string, error) {
	post, err := (*s.postRepo).GetByID(postID)
	if post == nil {
		return nil, errors.New("post not found")
	}

	if post.CreatedBy.ID != userID {
		return nil, errors.New("user is not authorized to upload medias to this post")
	}

	var fileURLs []string
	folder := fmt.Sprintf("posts/%s", postID)

	if len(files) > 0 {
		for i, file := range files {
			fileURL, err := (*s.storageRepo).UploadFile(file, fileHeaders[i], folder)
			if err != nil {
				s.DeleteMedias(fileURLs)
				return nil, errors.New("failed to upload files")
			}
			fileURLs = append(fileURLs, fileURL)
		}

		uploadPhotosResult, err := (*s.postRepo).UploadPhotos(postID, fileURLs)
		if err != nil {
			s.DeleteMedias(fileURLs)
			return nil, err
		}

		if !uploadPhotosResult {
			s.DeleteMedias(fileURLs)
			return nil, errors.New("failed to update post with uploaded photos")
		}
	}

	var audioFilePath string

	if strings.TrimSpace(text) != "" {
		text = strings.Replace(text, "\n", " ", -1)    // Loại bỏ tất cả ký tự xuống dòng
		text = strings.TrimSpace(text)                 // Loại bỏ khoảng trắng thừa ở đầu và cuối
		text = strings.Join(strings.Fields(text), " ") // Loại bỏ khoảng trắng thừa
		// Tạo tệp âm thanh từ văn bản
		audioFilePath, err = CreateSpeechFile(text)
		if err != nil {
			s.DeleteMedias(fileURLs)
			return nil, err
		}

		// Mở tệp âm thanh
		audioFile, err := os.Open(audioFilePath)
		if err != nil {
			s.DeleteMedias(fileURLs)
			return nil, fmt.Errorf("failed to open audio file: %w", err)
		}
		defer func() {
			if err := audioFile.Close(); err != nil {
				log.Println("failed to close audio file:", err)
			}

			asyncDeleteFile(audioFilePath)
		}()

		// Upload file âm thanh lên cloud
		audioFileURL, err := (*s.storageRepo).UploadFile(audioFile, nil, folder)
		if err != nil {
			s.DeleteMedias(fileURLs)
			return nil, errors.New("failed to upload audio file")
		}

		fileURLs = append(fileURLs, audioFileURL)

		updateVoiceResult, err := (*s.postRepo).UpdateVoice(postID, audioFileURL)
		if err != nil {
			s.DeleteMedias(fileURLs)
			return nil, err
		}

		if !updateVoiceResult {
			s.DeleteMedias(fileURLs)
			return nil, errors.New("failed to update post with voice")
		}
	}

	return fileURLs, nil
}
func (s *uploadService) UploadConversationImageData(conversatinID string, files []multipart.File, fileHeaders []*multipart.FileHeader) ([]string, error) {
	conversation, err := s.conversationRepo.GetByID(conversatinID)
	if err != nil {
		return nil, errors.New("failed to retrieve conversation: " + err.Error())
	}
	if conversation == nil {
		return nil, errors.New("conversation not found")
	}

	var fileURLs []string
	folder := fmt.Sprintf("conversation/%s", conversatinID)

	if len(files) > 0 {
		file := files[0]
		fileHeader := fileHeaders[0]

		fileURL, err := (*s.storageRepo).UploadFile(file, fileHeader, folder)
		if err != nil {
			s.DeleteMedias(fileURLs)
			return nil, errors.New("failed to upload file: " + err.Error())
		}

		fileURLs = append(fileURLs, fileURL)

		uploadPhotosResult, err := s.conversationRepo.UploadPhotos(conversatinID, fileURLs)
		if err != nil {
			s.DeleteMedias(fileURLs)
			return nil, err
		}

		if !uploadPhotosResult {
			s.DeleteMedias(fileURLs) // Xóa các file nếu việc cập nhật không thành công
			return nil, errors.New("failed to update conversation with uploaded photo")
		}
	}

	return fileURLs, nil
}

func (s *uploadService) UploadCommentMediaData(commentID, userID, text string, files []multipart.File, fileHeaders []*multipart.FileHeader) ([]string, error) {
	post, err := (*s.postRepo).GetPostByCommentID(commentID)
	if err != nil {
		return nil, fmt.Errorf("failed to find post by comment ID: %w", err)
	}

	var targetComment *models.Comment
	for _, comment := range post.Comments {
		if comment.ID.Hex() == commentID {
			targetComment = &comment
			break
		}
	}

	if targetComment == nil {
		return nil, errors.New("comment not found in the post")
	}

	if targetComment.CreatedBy.ID != userID {
		return nil, errors.New("user is not authorized to upload photos to this comment")
	}

	folder := fmt.Sprintf("posts/%s/comments/%s", post.ID.Hex(), commentID)

	var fileURLs []string

	if len(files) > 0 {
		for i, file := range files {
			fileURL, err := (*s.storageRepo).UploadFile(file, fileHeaders[i], folder)
			if err != nil {

				s.DeleteMedias(fileURLs)
				return nil, fmt.Errorf("failed to upload file: %w", err)
			}
			fileURLs = append(fileURLs, fileURL)
		}

		if err := (*s.postRepo).UpdateCommentPhotos(post.ID.Hex(), commentID, fileURLs); err != nil {
			s.DeleteMedias(fileURLs)
			return nil, fmt.Errorf("failed to update comment with photo URLs: %w", err)
		}
	}

	var audioFilePath string

	if strings.TrimSpace(text) != "" {
		text = strings.Replace(text, "\n", " ", -1)    // Loại bỏ tất cả ký tự xuống dòng
		text = strings.TrimSpace(text)                 // Loại bỏ khoảng trắng thừa ở đầu và cuối
		text = strings.Join(strings.Fields(text), " ") // Loại bỏ khoảng trắng thừa
		audioFilePath, err = CreateSpeechFile(text)
		if err != nil {
			s.DeleteMedias(fileURLs)
			return nil, err
		}

		// Mở tệp âm thanh
		audioFile, err := os.Open(audioFilePath)
		if err != nil {
			s.DeleteMedias(fileURLs)
			return nil, fmt.Errorf("failed to open audio file: %w", err)
		}
		defer func() {
			if err := audioFile.Close(); err != nil {
				log.Println("failed to close audio file:", err)
			}

			asyncDeleteFile(audioFilePath)
		}()

		audioFileURL, err := (*s.storageRepo).UploadFile(audioFile, nil, folder)
		if err != nil {
			s.DeleteMedias(fileURLs)
			return nil, errors.New("failed to upload audio file")
		}

		fileURLs = append(fileURLs, audioFileURL)
		updateVoiceResult, err := (*s.postRepo).UpdateCommentVoice(post.ID.Hex(), commentID, audioFileURL)
		if err != nil {
			s.DeleteMedias(fileURLs)
			return nil, err
		}

		if !updateVoiceResult {
			s.DeleteMedias(fileURLs)
			return nil, errors.New("failed to update with voice")
		}
	}

	return fileURLs, nil
}

func (s *uploadService) UploadReplyCommentMediaData(commentID, replyID, userID, text string, files []multipart.File, fileHeaders []*multipart.FileHeader) ([]string, error) {
	post, err := (*s.postRepo).GetPostByCommentID(commentID)
	if err != nil {
		return nil, fmt.Errorf("failed to find post by comment ID: %w", err)
	}

	var targetComment *models.Comment
	for _, comment := range post.Comments {
		if comment.ID.Hex() == commentID {
			targetComment = &comment
			break
		}
	}

	if targetComment == nil {
		return nil, errors.New("comment not found in the post")
	}

	var targetReply *models.Comment
	for _, reply := range targetComment.Replies {
		if reply.ID.Hex() == replyID {
			targetReply = &reply
			break
		}
	}

	if targetReply == nil {
		return nil, errors.New("reply not found in the comment")
	}

	if targetReply.CreatedBy.ID != userID {
		return nil, errors.New("user is not authorized to upload photos to this reply comment")
	}

	folder := fmt.Sprintf("posts/%s/comments/%s/replies/%s", post.ID.Hex(), commentID, replyID)

	var fileURLs []string

	if len(files) > 0 {
		for i, file := range files {
			fileURL, err := (*s.storageRepo).UploadFile(file, fileHeaders[i], folder)
			if err != nil {
				s.DeleteMedias(fileURLs)
				return nil, fmt.Errorf("failed to upload file: %w", err)
			}
			fileURLs = append(fileURLs, fileURL)
		}

		if err := (*s.postRepo).UpdateReplyCommentPhotos(commentID, replyID, fileURLs); err != nil {
			s.DeleteMedias(fileURLs)
			return nil, fmt.Errorf("failed to update reply with photo URLs: %w", err)
		}
	}

	var audioFilePath string

	if strings.TrimSpace(text) != "" {
		text = strings.Replace(text, "\n", " ", -1)    // Loại bỏ tất cả ký tự xuống dòng
		text = strings.TrimSpace(text)                 // Loại bỏ khoảng trắng thừa ở đầu và cuối
		text = strings.Join(strings.Fields(text), " ") // Loại bỏ khoảng trắng thừa
		audioFilePath, err = CreateSpeechFile(text)
		if err != nil {
			s.DeleteMedias(fileURLs)
			return nil, err
		}

		audioFile, err := os.Open(audioFilePath)
		if err != nil {
			s.DeleteMedias(fileURLs)
			return nil, fmt.Errorf("failed to open audio file: %w", err)
		}
		defer func() {
			if err := audioFile.Close(); err != nil {
				log.Println("failed to close audio file:", err)
			}

			asyncDeleteFile(audioFilePath)
		}()

		audioFileURL, err := (*s.storageRepo).UploadFile(audioFile, nil, folder)
		if err != nil {
			s.DeleteMedias(fileURLs)
			return nil, errors.New("failed to upload audio file")
		}

		fileURLs = append(fileURLs, audioFileURL)
		updateVoiceResult, err := (*s.postRepo).UpdateReplyCommentVoice(commentID, replyID, audioFileURL)
		if err != nil {
			s.DeleteMedias(fileURLs)
			return nil, err
		}

		if !updateVoiceResult {
			s.DeleteMedias(fileURLs)
			return nil, errors.New("failed to update with voice")
		}
	}

	return fileURLs, nil
}

func (s *uploadService) DeletePostMediaData(postID string) error {
	post, err := (*s.postRepo).GetByID(postID)
	if err != nil || post == nil {
		return fmt.Errorf("failed to retrieve post: %w", err)
	}

	var mediaUrls []string

	for _, image := range post.Images {
		mediaUrls = append(mediaUrls, image.URL)
	}

	if post.Voice != "" {
		mediaUrls = append(mediaUrls, post.Voice)
	}

	for _, comment := range post.Comments {
		for _, image := range comment.Images {
			mediaUrls = append(mediaUrls, image.URL)
		}

		if comment.Voice != "" {
			mediaUrls = append(mediaUrls, comment.Voice)
		}

		for _, reply := range comment.Replies {
			for _, image := range reply.Images {
				mediaUrls = append(mediaUrls, image.URL)
			}

			if reply.Voice != "" {
				mediaUrls = append(mediaUrls, reply.Voice)
			}
		}
	}

	return s.DeleteMedias(mediaUrls)
}

func (s *uploadService) DeleteCommentMediaData(commentID string) error {
	post, err := (*s.postRepo).GetPostByCommentID(commentID)
	if err != nil || post == nil {
		return fmt.Errorf("failed to retrieve post: %w", err)
	}

	var targetComment *models.Comment

	for _, comment := range post.Comments {
		if comment.ID.Hex() == commentID {
			targetComment = &comment
			break
		}
	}

	if targetComment == nil {
		return fmt.Errorf("comment not found")
	}

	var mediaUrls []string

	for _, image := range targetComment.Images {
		mediaUrls = append(mediaUrls, image.URL)
	}

	if targetComment.Voice != "" {
		mediaUrls = append(mediaUrls, targetComment.Voice)
	}

	for _, reply := range targetComment.Replies {
		for _, image := range reply.Images {
			mediaUrls = append(mediaUrls, image.URL)

			if reply.Voice != "" {
				mediaUrls = append(mediaUrls, reply.Voice)
			}
		}
	}

	return s.DeleteMedias(mediaUrls)
}

func (s *uploadService) DeleteReplyCommentMediaData(commentID, replyID string) error {
	post, err := (*s.postRepo).GetPostByCommentID(commentID)
	if err != nil || post == nil {
		return fmt.Errorf("failed to retrieve post: %w", err)
	}

	var targetComment *models.Comment
	for _, comment := range post.Comments {
		if comment.ID.Hex() == commentID {
			targetComment = &comment
			break
		}
	}

	if targetComment == nil {
		return fmt.Errorf("comment not found")
	}

	var targetReply *models.Comment
	for _, reply := range targetComment.Replies {
		if reply.ID.Hex() == replyID {
			targetReply = &reply
			break
		}
	}

	if targetReply == nil {
		return fmt.Errorf("reply not found")
	}

	var mediaUrls []string
	for _, image := range targetReply.Images {
		mediaUrls = append(mediaUrls, image.URL)
	}

	if targetReply.Voice != "" {
		mediaUrls = append(mediaUrls, targetReply.Voice)
	}

	return s.DeleteMedias(mediaUrls)
}

func (s *uploadService) DeleteMedias(medias []string) error {
	if len(medias) == 0 {
		return nil
	}

	for _, mediaURL := range medias {
		fileName, err := utils.ExtractPublicID(mediaURL)
		if err != nil {
			fmt.Printf("Error extracting file name from URL %s: %v\n", mediaURL, err)
			continue
		}

		resourceType := determineResourceType(mediaURL)
		// fmt.Printf("Deleting file: %s (type: %s)\n", fileName, resourceType)

		if err := (*s.storageRepo).DeleteFile(fileName, resourceType); err != nil {
			fmt.Printf("Error deleting file %s: %v\n", fileName, err)
		}
	}

	return nil
}

func determineResourceType(fileName string) string {
	if strings.HasSuffix(fileName, ".mp4") || strings.HasSuffix(fileName, ".mov") || strings.HasSuffix(fileName, ".mp3") {
		return "video"
	} else if strings.HasSuffix(fileName, ".wav") {
		return "raw"
	}
	return "image" // Mặc định là image
}

func CreateSpeechFile(text string) (string, error) {
	uniqueID := uuid.New().String()
	speech := httgotts.Speech{
		Folder:   "audio",
		Language: "vi",
	}

	filePath, err := speech.CreateSpeechFile(text, uniqueID)
	if err != nil {
		return "", fmt.Errorf("failed to create speech file: %v", err)
	}

	return filePath, nil
}

func asyncDeleteFile(filePath string) {
	go func() {
		if err := tryDeleteFile(filePath); err != nil {
			log.Println("Error deleting file:", err)
		}
	}()
}

func tryDeleteFile(filePath string) error {
	for i := 0; i < 5; i++ {
		time.Sleep(2 * time.Minute)
		err := os.Remove(filePath)
		if err == nil {
			return nil
		}
		log.Println("failed to delete file:", err)
		log.Println("Retrying to delete file:", filePath)
	}
	return fmt.Errorf("failed to delete file after retries: %s", filePath)
}
