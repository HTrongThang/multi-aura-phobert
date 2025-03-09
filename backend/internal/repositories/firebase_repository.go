package repositories

import (
	"context"
	"fmt"
	"io"
	"mime/multipart"
	configs "multiaura/internal/configs/firebase"
	"net/url"
	"time"

	"cloud.google.com/go/storage"
	"github.com/google/uuid"
	"google.golang.org/api/iterator"
)

type FirebaseStorageRepository interface {
	UploadFile(file multipart.File, fileHeader *multipart.FileHeader, folder string) (string, error)
	DeleteFile(fileName string) error
	DeleteFilesInFolder(folder string) error
}

type firebaseStorageRepository struct {
	bucketName string
}

func NewFirebaseStorageRepository() FirebaseStorageRepository {
	return &firebaseStorageRepository{
		bucketName: configs.FirebaseStorageBucketName,
	}
}

func (repo *firebaseStorageRepository) UploadFile(file multipart.File, fileHeader *multipart.FileHeader, folder string) (string, error) {
	ctx := context.Background()

	client, err := configs.InitializeFirebaseApp().Storage(ctx)
	if err != nil {
		return "", err
	}

	bucket, err := client.Bucket(repo.bucketName)
	if err != nil {
		return "", err
	}

	fileName := fmt.Sprintf("%s/%d_%s", folder, time.Now().Unix(), uuid.New().String())

	writer := bucket.Object(fileName).NewWriter(ctx)

	token := generateUUID()
	writer.Metadata = map[string]string{
		"firebaseStorageDownloadTokens": token,
	}
	defer writer.Close()

	if _, err := io.Copy(writer, file); err != nil {
		return "", err
	}

	encodedFileName := url.QueryEscape(fileName)

	fileUrl := fmt.Sprintf("https://firebasestorage.googleapis.com/v0/b/%s/o/%s?alt=media&token=%s", repo.bucketName, encodedFileName, token)

	return fileUrl, nil
}

func (repo *firebaseStorageRepository) DeleteFile(fileName string) error {
	ctx := context.Background()

	// Khởi tạo Firebase Storage client
	client, err := configs.InitializeFirebaseApp().Storage(ctx)
	if err != nil {
		return fmt.Errorf("failed to initialize Firebase storage client: %w", err)
	}

	// Lấy bucket từ Firebase
	bucket, err := client.Bucket(repo.bucketName)
	if err != nil {
		return fmt.Errorf("failed to get Firebase storage bucket: %w", err)
	}

	// Xóa object từ Firebase Storage
	object := bucket.Object(fileName)
	if err := object.Delete(ctx); err != nil {
		return fmt.Errorf("failed to delete file %s: %w", fileName, err)
	}

	return nil
}

func (repo *firebaseStorageRepository) DeleteFilesInFolder(folder string) error {
	ctx := context.Background()

	client, err := configs.InitializeFirebaseApp().Storage(ctx)
	if err != nil {
		return fmt.Errorf("failed to initialize Firebase storage client: %w", err)
	}

	bucket, err := client.Bucket(repo.bucketName)
	if err != nil {
		return fmt.Errorf("failed to get Firebase storage bucket: %w", err)
	}

	// List all objects (files) with the given folder prefix
	it := bucket.Objects(ctx, &storage.Query{
		Prefix: folder + "/",
	})

	// Iterate over the objects and delete them
	for {
		objAttrs, err := it.Next()
		if err == iterator.Done {
			break
		}
		if err != nil {
			return fmt.Errorf("failed to list files in folder: %w", err)
		}

		// Delete each file
		object := bucket.Object(objAttrs.Name)
		if err := object.Delete(ctx); err != nil {
			return fmt.Errorf("failed to delete file %s: %w", objAttrs.Name, err)
		}
	}

	return nil
}

func generateUUID() string {
	return uuid.New().String()
}
