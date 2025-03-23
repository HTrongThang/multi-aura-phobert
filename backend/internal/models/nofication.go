package models

import (
	"errors"
	"multiaura/pkg/utils"
	"time"

	"github.com/neo4j/neo4j-go-driver/v5/neo4j/dbtype"
)

type Notification struct {
	ID          primitive.ObjectID `bson:"_id,omitempty" json:"_id,omitempty"`
	PostID      primitive.ObjectID `bson:"postID" json:"postID"`
	AuthorID	UserSummary        `bson:"authorID" json:"authorID"`
	UserID      UserSummary        `bson:"userID" json:"userID"`
	CreateTime  time.Time          `bson:"createTime" json:"createTime"`
	Type        string             `bson:"type" json:"type"`
	Description string             `bson:"description" json:"description"`
}

type CreateNotificationRequest struct {
	PostID      string `bson:"postID" json:"postID"`
	UserID      string `bson:"userID" json:"userID"`
	Type        string `bson:"type" json:"type"`
	Description string `bson:"description" json:"description"`
}

func NewNotification(postID primitive.ObjectID, userID UserSummary, notifType string, description string) *Notification {
	return &Notification{
		ID:          primitive.NewObjectID(),
		PostID:      postID,
		UserID:      userID,
		CreateTime:  time.Now(),
		Type:        notifType,
		Description: description,
	}
}