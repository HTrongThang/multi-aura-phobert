package models

import (
	"multiaura/pkg/utils"
	"time"

	"go.mongodb.org/mongo-driver/bson/primitive"
)

type Image struct {
	URL string             `bson:"url" json:"url" form:"url"`
	ID  primitive.ObjectID `bson:"_id,omitempty" json:"_id,omitempty" form:"_id,omitempty"`
}

type Post struct {
	ID            primitive.ObjectID `bson:"_id,omitempty" json:"_id,omitempty" form:"_id,omitempty"`
	Description   string             `bson:"description" json:"description" form:"description"`
	Voice         string             `bson:"voice,omitempty" json:"voice,omitempty" form:"voice,omitempty"`
	Images        []Image            `bson:"images" json:"images" form:"images"`
	CreatedAt     time.Time          `bson:"createdAt" json:"createdAt" form:"createdAt"`
	CreatedBy     UserSummary        `bson:"createdBy" json:"createdBy" form:"createdBy"`
	LikedBy       []UserSummary      `bson:"likedBy" json:"likedBy" form:"likedBy"`
	SharedBy      []string           `bson:"sharedBy" json:"sharedBy" form:"sharedBy"`
	UpdatedAt     time.Time          `bson:"updatedAt" json:"updatedAt" form:"updatedAt"`
	Comments      []Comment          `bson:"comments,omitempty" json:"comments,omitempty" form:"comments,omitempty"`
	ToxicityScore float64            `bson:"toxicityScore,omitempty" json:"toxicityScore,omitempty" form:"toxicityScore,omitempty"`
}

type CreatePostRequest struct {
	UserID      string `bson:"_id,omitempty" json:"_id,omitempty" form:"_id,omitempty"`
	Description string `bson:"description" json:"description" form:"description"`
	// Images      []Image `bson:"images" json:"images" form:"images"`
}

func (p *Post) ToMap() map[string]interface{} {
	images := make([]map[string]interface{}, len(p.Images))
	for i, img := range p.Images {
		images[i] = map[string]interface{}{
			"url": img.URL,
			"_id": img.ID,
		}
	}

	likedBy := make([]map[string]interface{}, len(p.LikedBy))
	for i, user := range p.LikedBy {
		likedBy[i] = user.ToMap()
	}

	comments := make([]map[string]interface{}, len(p.Comments))
	for i, comment := range p.Comments {
		comments[i] = comment.ToMap()
	}

	return map[string]interface{}{
		"_id":           p.ID,
		"description":   p.Description,
		"voice":         p.Voice,
		"images":        images,
		"createdAt":     p.CreatedAt,
		"createdBy":     p.CreatedBy.ToMap(),
		"likedBy":       likedBy,
		"sharedBy":      p.SharedBy,
		"updatedAt":     p.UpdatedAt,
		"comments":      comments,
		"toxicityScore": p.ToxicityScore,
	}
}

func (p *Post) FromMap(data map[string]interface{}) (*Post, error) {
	imageData := utils.GetArrayMap(data, "images")
	images := make([]Image, len(imageData))
	for i, img := range imageData {
		imgMap := img
		images[i] = Image{
			URL: utils.GetString(imgMap, "url"),
			ID:  utils.GetObjectID(imgMap, "_id"),
		}
	}

	likedByData := utils.GetArrayMap(data, "likedBy")
	likedBy := make([]UserSummary, len(likedByData))
	if len(likedByData) > 0 {
		for i, usr := range likedByData {
			userSummary, err := new(UserSummary).FromMap(usr)
			if err != nil {
				return nil, err
			}
			likedBy[i] = *userSummary
		}
	}

	// Chuyển đổi CreatedBy
	createdByData := utils.GetMap(data, "createdBy")
	createdBy, err := new(UserSummary).FromMap(createdByData)
	if err != nil {
		return nil, err
	}

	commentData := utils.GetArrayMap(data, "comments")
	comments := make([]Comment, len(commentData))
	for i, comment := range commentData {
		commentMap := comment
		comm, err := new(Comment).FromMap(commentMap)
		if err != nil {
			return nil, err
		}
		comments[i] = *comm
	}

	return &Post{
		ID:            utils.GetObjectID(data, "_id"),
		Description:   utils.GetString(data, "description"),
		Voice:         utils.GetString(data, "voice"),
		Images:        images,
		CreatedAt:     utils.GetTime(data, "createdAt"),
		CreatedBy:     *createdBy,
		LikedBy:       likedBy,
		SharedBy:      utils.GetStringArrayFromPrimitiveAMap(data, "sharedBy"),
		UpdatedAt:     utils.GetTime(data, "updatedAt"),
		Comments:      comments,
		ToxicityScore: utils.GetFloat64(data, "toxicityScore"),
	}, nil
}
