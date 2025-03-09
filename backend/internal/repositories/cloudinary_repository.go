package repositories

import (
	"bytes"
	"context"
	"fmt"
	"mime/multipart"
	"time"

	"github.com/cloudinary/cloudinary-go/v2"
	"github.com/cloudinary/cloudinary-go/v2/api/uploader"
	"github.com/google/uuid"
)

type cloudinaryRepository struct {
	cloudinary *cloudinary.Cloudinary
}

func NewCloudinaryRepository(cloudinaryURL string) (StorageRepository, error) {
	cld, err := cloudinary.NewFromURL(cloudinaryURL)
	if err != nil {
		return nil, fmt.Errorf("failed to initialize Cloudinary client: %w", err)
	}

	return &cloudinaryRepository{
		cloudinary: cld,
	}, nil
}

func (repo *cloudinaryRepository) UploadFile(file multipart.File, fileHeader *multipart.FileHeader, folder string) (string, error) {
	ctx := context.Background()

	// Đọc nội dung file
	buffer := bytes.NewBuffer(nil)
	if _, err := buffer.ReadFrom(file); err != nil {
		return "", fmt.Errorf("failed to read file: %w", err)
	}

	// Tạo tên file với UUID và thời gian
	fileName := fmt.Sprintf("%s/%d_%s", folder, time.Now().Unix(), uuid.New().String())

	// Upload file lên Cloudinary
	uploadParams := uploader.UploadParams{
		PublicID: fileName,
		Folder:   folder,
	}
	uploadResult, err := repo.cloudinary.Upload.Upload(ctx, buffer, uploadParams)
	if err != nil {
		return "", fmt.Errorf("failed to upload file to Cloudinary: %w", err)
	}

	// Trả về URL của file đã tải lên
	return uploadResult.SecureURL, nil
}

func (repo *cloudinaryRepository) DeleteFile(fileName, resourceType string) error {
	ctx := context.Background()

	// Đặt loại tài nguyên dựa vào tham số truyền vào
	_, err := repo.cloudinary.Upload.Destroy(ctx, uploader.DestroyParams{
		PublicID:    fileName,
		ResourceType: resourceType, // "image", "video", hoặc "raw"
	})
	if err != nil {
		return fmt.Errorf("failed to delete file %s from Cloudinary: %w", fileName, err)
	}

	return nil
}
