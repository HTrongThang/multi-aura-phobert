package models

import (
	"multiaura/pkg/utils"
	"time"

	"go.mongodb.org/mongo-driver/bson/primitive"
)

// Comment model
type Comment struct {
	ID            primitive.ObjectID `bson:"_id,omitempty" json:"_id,omitempty" form:"_id,omitempty"`
	ReplyFor      string             `bson:"replyFor,omitempty" json:"replyFor,omitempty" form:"replyFor,omitempty"`
	Text          string             `bson:"text" json:"text" form:"text"`
	Voice         string             `bson:"voice,omitempty" json:"voice,omitempty" form:"voice,omitempty"`
	Images        []Image            `bson:"images,omitempty" json:"images,omitempty" form:"images,omitempty"`
	CreatedAt     time.Time          `bson:"createdAt" json:"createdAt" form:"createdAt"`
	UpdatedAt     time.Time          `bson:"updatedAt" json:"updatedAt" form:"updatedAt"`
	LikedBy       []string           `bson:"likedBy" json:"likedBy" form:"likedBy"`
	Status        string             `bson:"status" json:"status" form:"status"`
	Replies       []Comment          `bson:"replies,omitempty" json:"replies,omitempty" form:"replies,omitempty"`
	CreatedBy     UserSummary        `bson:"createdBy" json:"createdBy" form:"createdBy"`
	ToxicityScore float64            `bson:"toxicityScore,omitempty" json:"toxicityScore,omitempty" form:"toxicityScore,omitempty"`
}

// CreateCommentRequest represents the structure of the request to create a new comment
type CreateCommentRequest struct {
	Text     string `bson:"text" json:"text" form:"text"`
	ReplyFor string `bson:"replyFor,omitempty" json:"replyFor,omitempty" form:"replyFor,omitempty"`
	// Voice string `bson:"voice,omitempty" json:"voice,omitempty" form:"voice,omitempty"`
}

func (c *Comment) ToMap() map[string]interface{} {
	images := make([]map[string]interface{}, len(c.Images))
	for i, img := range c.Images {
		images[i] = map[string]interface{}{
			"url": img.URL,
			"_id": img.ID,
		}
	}

	replies := make([]map[string]interface{}, len(c.Replies))
	for i, reply := range c.Replies {
		replies[i] = reply.ToMap()
	}

	return map[string]interface{}{
		"_id":           c.ID,
		"replyFor":      c.ReplyFor,
		"text":          c.Text,
		"voice":         c.Voice,
		"images":        images,
		"createdAt":     c.CreatedAt,
		"updatedAt":     c.UpdatedAt,
		"likedBy":       c.LikedBy,
		"status":        c.Status,
		"replies":       replies,
		"createdBy":     c.CreatedBy.ToMap(),
		"toxicityScore": c.ToxicityScore,
	}
}

func (c *Comment) FromMap(data map[string]interface{}) (*Comment, error) {
	imageData := utils.GetArrayMap(data, "images")
	images := make([]Image, len(imageData))
	for i, img := range imageData {
		images[i] = Image{
			URL: utils.GetString(img, "url"),
			ID:  utils.GetObjectID(img, "_id"),
		}
	}

	replyData := utils.GetArrayMap(data, "replies")
	replies := make([]Comment, len(replyData))
	for i, reply := range replyData {
		replyMap := reply
		rep, err := new(Comment).FromMap(replyMap)
		if err != nil {
			return nil, err
		}
		replies[i] = *rep
	}

	createdByData := utils.GetMap(data, "createdBy")
	createdBy, err := new(UserSummary).FromMap(createdByData)
	if err != nil {
		return nil, err
	}

	return &Comment{
		ID:            utils.GetObjectID(data, "_id"),
		ReplyFor:      utils.GetString(data, "replyFor"),
		Text:          utils.GetString(data, "text"),
		Voice:         utils.GetString(data, "voice"),
		Images:        images,
		CreatedAt:     utils.GetTime(data, "createdAt"),
		UpdatedAt:     utils.GetTime(data, "updatedAt"),
		LikedBy:       utils.GetStringArrayFromPrimitiveAMap(data, "likedBy"),
		Status:        utils.GetString(data, "status"),
		Replies:       replies,
		CreatedBy:     *createdBy,
		ToxicityScore: utils.GetFloat64(data, "toxicityScore"),
	}, nil
}
