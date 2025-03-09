package repositories

import (
	"context"
	"errors"
	"log"
	"multiaura/internal/databases"
	"multiaura/internal/models"
	"time"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/bson/primitive"
	"go.mongodb.org/mongo-driver/mongo"
)

type ConversationRepository interface {
	Repository[models.Conversation]
	GetListConversations(userID string) ([]models.Conversation, error)
	AddMemberToConversation(user []models.OtherUser, id_conversation string) error
	GetMessagesByConversationID(conversationID string) ([]models.Chat, error)
	MarkMessagesAsRead(conversationID string, userID string) error
	FindPrivateConversation(userID1, userID2 string) (*models.Conversation, error)
	UpdateRemoveUser(conversation *models.Conversation) error
	AddMessageToConversation(message *models.Chat, conversationID string) error
	MarkMessageAsDeleted(conversationID string, messageID string) error
	UploadPhotos(conversationID string, fileURLs []string) (bool, error)
}

type conversationRepository struct {
	db         *databases.MongoDB
	collection *mongo.Collection
}

func NewConversationRepository(db *databases.MongoDB) ConversationRepository {
	if db == nil || db.Database == nil {
		log.Fatal("MongoDB instance or database is nil")
	}

	return &conversationRepository{
		db:         db,
		collection: db.Database.Collection("chats"),
	}
}

func (repo *conversationRepository) GetByID(conversationID string) (*models.Conversation, error) {
	var conversation models.Conversation

	objectID, err := primitive.ObjectIDFromHex(conversationID)
	if err != nil {
		log.Printf("Invalid conversationID format: %s", conversationID)
		return nil, err
	}

	filter := bson.M{"_id": objectID}

	err = repo.collection.FindOne(context.Background(), filter).Decode(&conversation)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return nil, nil
		}
		return nil, err
	}

	return &conversation, nil
}

func (repo *conversationRepository) Create(conversation models.Conversation) error {
	ctx, cancel := context.WithTimeout(context.Background(), 60*time.Second)
	defer cancel()

	_, err := repo.collection.InsertOne(ctx, conversation)
	if err != nil {
		return err
	}

	return nil
}

func (repo *conversationRepository) Delete(id string) error {
	objectID, err := primitive.ObjectIDFromHex(id)
	if err != nil {
		return err
	}

	filter := bson.M{"_id": objectID}

	result, err := repo.collection.DeleteOne(context.Background(), filter)
	if err != nil {
		return err
	}
	if result.DeletedCount == 0 {
		return mongo.ErrNoDocuments
	}

	return nil
}

func (repo *conversationRepository) Update(entityMap *map[string]interface{}) error {
	filter := bson.M{"_id": (*entityMap)["_id"].(string)}

	updateQuery := bson.M{"$set": entityMap}

	result, err := repo.collection.UpdateOne(context.Background(), filter, updateQuery)
	if err != nil {
		return err
	}

	if result.MatchedCount == 0 {
		return mongo.ErrNoDocuments
	}

	return nil
}

func (repo *conversationRepository) FindPrivateConversation(userID1, userID2 string) (*models.Conversation, error) {
	var conversation models.Conversation

	// Tìm cuộc trò chuyện có cả hai người dùng
	filter := bson.M{
		"conversation_type": "Private",
		"$and": []bson.M{
			{"users.userID": userID1},
			{"users.userID": userID2},
		},
	}

	err := repo.collection.FindOne(context.Background(), filter).Decode(&conversation)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return nil, nil // Không tìm thấy cuộc trò chuyện
		}
		return nil, err // Lỗi khác
	}

	return &conversation, nil
}

func (repo *conversationRepository) GetListConversations(userID string) ([]models.Conversation, error) {
	var conversations []models.Conversation

	filter := bson.M{"users.userID": userID}

	cursor, err := repo.collection.Find(context.Background(), filter)
	if err != nil {
		return nil, err
	}
	defer cursor.Close(context.Background())

	if err = cursor.All(context.Background(), &conversations); err != nil {
		return nil, err
	}

	return conversations, nil
}
func (repo *conversationRepository) AddMemberToConversation(users []models.OtherUser, conversationID string) error {
	idConversation, err := primitive.ObjectIDFromHex(conversationID)
	if err != nil {
		return errors.New("invalid conversation ID format")
	}

	filter := bson.M{"_id": idConversation}

	update := bson.M{
		"$push": bson.M{
			"users": bson.M{
				"$each": users,
			},
		},
		"$set": bson.M{
			"updatedat":         time.Now().UTC(),
			"conversation_type": "Group",
		},
	}

	_, err = repo.collection.UpdateOne(context.Background(), filter, update)
	if err != nil {
		return errors.New("failed to add members and update conversation type")
	}

	return nil
}

func (r *conversationRepository) MarkMessageAsDeleted(conversationID string, messageID string) error {
	conversationObjectID, err := primitive.ObjectIDFromHex(conversationID)
	if err != nil {
		return err
	}

	messageObjectID, err := primitive.ObjectIDFromHex(messageID)
	if err != nil {
		return err
	}

	filter := bson.M{"_id": conversationObjectID, "chats.id_chat": messageObjectID}
	update := bson.M{"$set": bson.M{"chats.$.status": "deleted"}}

	result, err := r.collection.UpdateOne(context.Background(), filter, update)
	if err != nil {
		return err

	}
	if result.ModifiedCount == 0 {
		log.Println("No document was updated.")
	}
	return nil
}
func (repo *conversationRepository) MarkMessagesAsRead(conversationID string, userID string) error {
	objectID, err := primitive.ObjectIDFromHex(conversationID)
	if err != nil {
		return err
	}

	// Cập nhật tất cả tin nhắn `unread = true` thành `false` cho userID
	filter := bson.M{"_id": objectID, "chats.unread": true, "chats.sender.userID": bson.M{"$ne": userID}}
	update := bson.M{"$set": bson.M{"chats.$[].unread": false}}

	_, err = repo.collection.UpdateMany(context.Background(), filter, update)
	if err != nil {
		return err
	}

	// Đặt lại `unreadCount` về 0 cho người dùng
	filterUser := bson.M{"_id": objectID, "users.userID": userID}
	updateUser := bson.M{"$set": bson.M{"users.$.unreadCount": 0}}

	_, err = repo.collection.UpdateOne(context.Background(), filterUser, updateUser)
	if err != nil {
		return err
	}

	return nil
}
func (repo *conversationRepository) UpdateRemoveUser(conversation *models.Conversation) error {
	filter := bson.M{"_id": conversation.ID}

	update := bson.M{
		"$set": bson.M{
			"users":     conversation.Users,
			"updatedat": conversation.UpdatedAt,
		},
	}

	result, err := repo.collection.UpdateOne(context.Background(), filter, update)
	if err != nil {
	}

	if result.MatchedCount == 0 {
		return errors.New("no matching conversation found to update")
	}

	return nil
}
func (repo *conversationRepository) AddMessageToConversation(message *models.Chat, conversationID string) error {
	conversationObjectID, err := primitive.ObjectIDFromHex(conversationID)
	if err != nil {
		return errors.New("invalid conversation ID format")
	}

	filter := bson.M{"_id": conversationObjectID}
	update := bson.M{
		"$push": bson.M{"chats": message},              // Thêm tin nhắn trực tiếp
		"$set":  bson.M{"updatedat": time.Now().UTC()}, // Cập nhật thời gian
	}

	_, err = repo.collection.UpdateOne(context.Background(), filter, update)
	if err != nil {
		return errors.New("failed to update conversation with new message")
	}

	return nil
}

func (r *conversationRepository) GetMessagesByConversationID(conversationID string) ([]models.Chat, error) {
	objectID, err := primitive.ObjectIDFromHex(conversationID)
	if err != nil {
		return nil, errors.New("invalid conversation ID format")
	}

	filter := bson.M{"_id": objectID}
	var conversation models.Conversation

	err = r.collection.FindOne(context.Background(), filter).Decode(&conversation)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return nil, errors.New("conversation not found")
		}
		return nil, errors.New("error retrieving conversation: " + err.Error())
	}

	return conversation.Chats, nil
}
func (repo *conversationRepository) UploadPhotos(conversationID string, fileURLs []string) (bool, error) {
	objectID, err := primitive.ObjectIDFromHex(conversationID)
	if err != nil {
		return false, errors.New("invalid conversation ID format")
	}

	filter := bson.M{"_id": objectID}

	if len(fileURLs) == 0 {
		return false, errors.New("no file URL provided")
	}

	update := bson.M{
		"$set": bson.M{
			"thumb_group": fileURLs[0],    
			"updatedat":   time.Now().UTC(), 
		},
	}

	result, err := repo.collection.UpdateOne(context.Background(), filter, update)
	if err != nil {
		return false, errors.New("failed to upload photos to conversation: " + err.Error())
	}

	if result.MatchedCount == 0 {
		return false, errors.New("no conversation found with the provided ID")
	}

	return true, nil
}
