package models

import (
	"time"

	"go.mongodb.org/mongo-driver/bson/primitive"
)

type (
	ChatContent struct {
		Text     string `json:"text" bson:"text,omitempty" form:"text,omitempty"`
		Image    string `json:"image" bson:"image,omitempty" form:"image,omitempty"`
		VoiceURL string `json:"voice_url" bson:"voice_url,omitempty" form:"voice_url,omitempty"`
	}

	Chat struct {
		ID        primitive.ObjectID `json:"id_chat" bson:"id_chat,omitempty" form:"id_chat,omitempty"`
		Sender    OtherUser          `json:"sender" bson:"sender" form:"sender"`
		Content   ChatContent        `json:"content" bson:"content" form:"content"`
		Emotion   []string           `json:"emotion" bson:"emotion,omitempty" form:"emotion,omitempty"`
		CreatedAt time.Time          `json:"createdat" bson:"createdat" form:"createdat"`
		UpdatedAt time.Time          `json:"updatedat" bson:"updatedat" form:"updatedat"`
		Status    string             `json:"status" bson:"status" form:"status"`
		Unread    bool               `json:"unread" bson:"unread" form:"unread"`
	}

	Conversation struct {
		ID               primitive.ObjectID `json:"_id" bson:"_id,omitempty" form:"_id,omitempty"`
		Name             string             `json:"name_conversation" bson:"name_conversation" form:"name_conversation"`
		ConversationType string             `json:"conversation_type" bson:"conversation_type" form:"conversation_type"`
		Users            []OtherUser        `json:"users" bson:"users" form:"users"`
		Chats            []Chat             `json:"chats" bson:"chats" form:"chats"`
		SeenBy           []SeenBy           `json:"seen_by" bson:"seen_by" form:"seen_by"`
		Thumb_group      string             `json:"thumb_group" bson:"thumb_group" form:"thumb_group"`
		CreatedAt        time.Time          `json:"createdat" bson:"createdat" form:"createdat"`
		UpdatedAt        time.Time          `json:"updatedat" bson:"updatedat" form:"updatedat"`
	}

	SeenBy struct {
		UserID primitive.ObjectID `json:"user_id" bson:"user_id" form:"user_id"`
		SeenAt time.Time          `json:"seen_at" bson:"seen_at" form:"seen_at"`
	}
)

// ToMap cho ChatContent
func (c *ChatContent) ToMap() map[string]interface{} {
	return map[string]interface{}{
		"text":      c.Text,
		"image":     c.Image,
		"voice_url": c.VoiceURL,
	}
}

// FromMap cho ChatContent
func (c *ChatContent) FromMap(data map[string]interface{}) (*ChatContent, error) {
	return &ChatContent{
		Text:     data["text"].(string),
		Image:    data["image"].(string),
		VoiceURL: data["voice_url"].(string),
	}, nil
}

// ToMap cho Chat
func (c *Chat) ToMap() map[string]interface{} {
	return map[string]interface{}{
		"id_chat":   c.ID.Hex(),
		"sender":    c.Sender.ToMap(),
		"content":   c.Content.ToMap(),
		"emotion":   c.Emotion,
		"createdat": c.CreatedAt,
		"updatedat": c.UpdatedAt,
		"status":    c.Status,
		"unread":    c.Unread,
	}
}

// FromMap cho Chat
func (c *Chat) FromMap(data map[string]interface{}) (*Chat, error) {
	senderData := data["sender"].(map[string]interface{})
	contentData := data["content"].(map[string]interface{})

	sender, err := (&OtherUser{}).FromMap(senderData)
	if err != nil {
		return nil, err
	}

	content, err := (&ChatContent{}).FromMap(contentData)
	if err != nil {
		return nil, err
	}

	return &Chat{
		ID:        primitive.NewObjectID(),
		Sender:    *sender,
		Content:   *content,
		Emotion:   data["emotion"].([]string),
		CreatedAt: data["createdat"].(time.Time),
		UpdatedAt: data["updatedat"].(time.Time),
		Status:    data["status"].(string),
		Unread:    data["unread"].(bool),
	}, nil
}

// ToMap cho Conversation
func (c *Conversation) ToMap() map[string]interface{} {
	users := make([]map[string]interface{}, len(c.Users))
	for i, user := range c.Users {
		users[i] = user.ToMap()
	}

	chats := make([]map[string]interface{}, len(c.Chats))
	for i, chat := range c.Chats {
		chats[i] = chat.ToMap()
	}

	seenBy := make([]map[string]interface{}, len(c.SeenBy))
	for i, seen := range c.SeenBy {
		seenBy[i] = map[string]interface{}{
			"user_id": seen.UserID.Hex(),
			"seen_at": seen.SeenAt,
		}
	}

	return map[string]interface{}{
		"_id":               c.ID.Hex(),
		"name_conversation": c.Name,
		"conversation_type": c.ConversationType,
		"users":             users,
		"chats":             chats,
		"seen_by":           seenBy,
		"thumb_group":       c.Thumb_group,
		"createdat":         c.CreatedAt,
		"updatedat":         c.UpdatedAt,
	}
}

// FromMap cho Conversation
func (c *Conversation) FromMap(data map[string]interface{}) (*Conversation, error) {
	userData := data["users"].([]map[string]interface{})
	chatData := data["chats"].([]map[string]interface{})
	seenData := data["seen_by"].([]map[string]interface{})

	users := []OtherUser{}
	for _, u := range userData {
		user, err := (&OtherUser{}).FromMap(u)
		if err != nil {
			return nil, err
		}
		users = append(users, *user)
	}

	chats := []Chat{}
	for _, chat := range chatData {
		chatItem, err := (&Chat{}).FromMap(chat)
		if err != nil {
			return nil, err
		}
		chats = append(chats, *chatItem)
	}

	seenBy := []SeenBy{}
	for _, seen := range seenData {
		seenBy = append(seenBy, SeenBy{
			UserID: primitive.NewObjectID(),
			SeenAt: seen["seen_at"].(time.Time),
		})
	}

	return &Conversation{
		ID:               primitive.NewObjectID(),
		Name:             data["name_conversation"].(string),
		ConversationType: data["conversation_type"].(string),
		Users:            users,
		Chats:            chats,
		SeenBy:           seenBy,
		Thumb_group:      data["thumb_group"].(string),
		CreatedAt:        data["createdat"].(time.Time),
		UpdatedAt:        data["updatedat"].(time.Time),
	}, nil
}
