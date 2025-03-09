package services

import (
	"errors"
	"fmt"
	"multiaura/internal/models"
	"multiaura/internal/repositories"
	"time"

	"go.mongodb.org/mongo-driver/bson/primitive"
)

type ConversationService interface {
	CreateConversation(userIDs []string, name string) (*models.Conversation, error)
	GetConversationByID(id string) (*models.Conversation, error)
	GetListConversations(id string) ([]models.Conversation, error)
	AddMembers(conversationID string, userIDs []string) ([]models.OtherUser, error)
	RemoveMemberConversation(conversationID string, userID string) error
	MarkMessagesAsRead(conversationID string, userID string) error
	CheckExistingConversation(userIDs []string) (*models.Conversation, error)
	SendMessage(conversationID, userID string, content models.ChatContent) (*models.Chat, error)
	GetMessages(conversationID string) ([]models.Chat, error)
	MarkMessageAsDeleted(conversationID string, messageID string) error
}

type conversationService struct {
	repo     repositories.ConversationRepository
	userRepo repositories.UserRepository
}

func NewConversationService(repo repositories.ConversationRepository, userRepo repositories.UserRepository) ConversationService {
	return &conversationService{
		repo:     repo,
		userRepo: userRepo,
	}
}
func removeDuplicateIDs(userIDs []string) []string {
	idMap := make(map[string]bool)
	var uniqueIDs []string

	for _, id := range userIDs {
		if !idMap[id] {
			idMap[id] = true
			uniqueIDs = append(uniqueIDs, id)
		}
	}

	return uniqueIDs
}

func (c *conversationService) CreateConversation(userIDs []string, name string) (*models.Conversation, error) {
	uniqueUserIDs := removeDuplicateIDs(userIDs)

	conversationType := "Private"
	if len(uniqueUserIDs) > 2 {
		conversationType = "Group"
	}

	// Lấy thông tin người dùng và thêm vào danh sách
	var users []models.OtherUser
	for _, id := range uniqueUserIDs {
		user, err := c.userRepo.GetByID(id)
		if err != nil {
			return nil, errors.New("error fetching user information")
		}
		if user == nil {
			return nil, errors.New("user not found: " + id)
		}

		userData := user.ToMap()
		otherUser, err := (&models.OtherUser{}).FromMap(userData)
		if err != nil {
			return nil, errors.New("error processing user data")
		}

		users = append(users, *otherUser)
	}

	// Tạo cuộc trò chuyện mới
	newConversation := models.Conversation{
		ID:               primitive.NewObjectID(),
		Name:             name,
		ConversationType: conversationType,
		Users:            users,
		Chats:            []models.Chat{},
		CreatedAt:        time.Now().UTC(),
		UpdatedAt:        time.Now().UTC(),
	}

	if err := c.repo.Create(newConversation); err != nil {
		return nil, errors.New("failed to create conversation")
	}

	return &newConversation, nil
}
func (c *conversationService) CheckExistingConversation(userIDs []string) (*models.Conversation, error) {
	if len(userIDs) != 2 {
		return nil, nil // Không kiểm tra với nhóm
	}

	existingConversation, err := c.repo.FindPrivateConversation(userIDs[0], userIDs[1])
	if err != nil {
		return nil, err
	}

	return existingConversation, nil
}

func (c *conversationService) GetConversationByID(conversationID string) (*models.Conversation, error) {
	if conversationID == "" {
		return nil, errors.New("conversationID not found")
	}

	conversation, err := c.repo.GetByID(conversationID)
	if err != nil {
		return nil, err
	}
	if conversation == nil {
		return nil, errors.New("conversation not found")
	}

	return conversation, nil
}

func (c *conversationService) GetListConversations(id string) ([]models.Conversation, error) {
	if id == "" {
		return nil, errors.New("id not found")
	}
	listConversation, err := c.repo.GetListConversations(id)
	if err != nil {
		return nil, errors.New("error getting list of conversations")
	}
	if len(listConversation) == 0 {
		return nil, errors.New("no conversations")
	}
	return listConversation, nil

}

func (c *conversationService) AddMembers(conversationID string, userIDs []string) ([]models.OtherUser, error) {
	if conversationID == "" {
		return nil, errors.New("conversation ID is required")
	}

	conversation, err := c.repo.GetByID(conversationID)
	if err != nil {
		return nil, fmt.Errorf("failed to get conversation: %w", err)
	}
	if conversation == nil {
		return nil, errors.New("conversation not found")
	}

	existingUserMap := make(map[string]bool)
	for _, user := range conversation.Users {
		existingUserMap[user.ID] = true
	}

	var newUsers []models.OtherUser
	for _, userID := range userIDs {
		user, err := c.userRepo.GetByID(userID)
		if err != nil {
			return nil, fmt.Errorf("failed to fetch user: %w", err)
		}
		if user == nil {
			return nil, fmt.Errorf("user not found: %s", userID)
		}

		if !existingUserMap[userID] {
			userData := user.ToMap()
			otherUser, err := (&models.OtherUser{}).FromMap(userData)
			if err != nil {
				return nil, fmt.Errorf("error processing user data: %w", err)
			}

			newUsers = append(newUsers, *otherUser)
		}
	}

	if len(newUsers) == 0 {
		return nil, errors.New("no new users to add")
	}

	err = c.repo.AddMemberToConversation(newUsers, conversationID)
	if err != nil {
		return nil, fmt.Errorf("failed to add members to conversation: %w", err)
	}

	return newUsers, nil
}

func (cs *conversationService) MarkMessagesAsRead(conversationID string, userID string) error {
	if conversationID == "" || userID == "" {
		return errors.New("missing conversationID or userID")
	}

	err := cs.repo.MarkMessagesAsRead(conversationID, userID)
	if err != nil {
		return err
	}

	return nil
}
func (c *conversationService) RemoveMemberConversation(conversationID string, userID string) error {
	if conversationID == "" {
		return errors.New("no conversation ID specified")
	}
	if userID == "" {
		return errors.New("no user ID specified")
	}

	// Lấy thông tin cuộc trò chuyện
	conversation, err := c.repo.GetByID(conversationID)
	if err != nil {
		return fmt.Errorf("conversation not found: %v", err)
	}

	var updatedUsers []models.OtherUser
	userFound := false

	for _, user := range conversation.Users {
		if user.ID == userID {
			userFound = true
			continue
		}
		updatedUsers = append(updatedUsers, user)
	}

	if !userFound {
		return errors.New("user not found in conversation")
	}

	conversation.Users = updatedUsers
	conversation.UpdatedAt = time.Now().UTC()

	err = c.repo.UpdateRemoveUser(conversation)
	if err != nil {
		return errors.New("failed to update conversation")
	}

	return nil
}
func (cs *conversationService) SendMessage(conversationID, userID string, content models.ChatContent) (*models.Chat, error) {
	// Lấy thông tin người dùng
	user, err := cs.userRepo.GetByID(userID)
	if err != nil {
		return nil, errors.New("failed to retrieve user information")
	}
	if user == nil {
		return nil, errors.New("user does not exist")
	}

	// Chuyển đổi thông tin người dùng thành OtherUser
	userData := user.ToMap()
	sender, err := (&models.OtherUser{}).FromMap(userData)
	if err != nil {
		return nil, errors.New("failed to process user data")
	}

	// Tạo tin nhắn mới
	newMessage := &models.Chat{
		ID:        primitive.NewObjectID(),
		Sender:    *sender,
		Content:   content,
		CreatedAt: time.Now().UTC(),
		UpdatedAt: time.Now().UTC(),
		Status:    "sent",
		Unread:    true,
	}

	// Lưu tin nhắn trực tiếp
	err = cs.repo.AddMessageToConversation(newMessage, conversationID)
	if err != nil {
		return nil, errors.New("failed to add message to conversation")
	}

	return newMessage, nil
}

func (s *conversationService) GetMessages(conversationID string) ([]models.Chat, error) {
	if conversationID == "" {
		return nil, errors.New("conversation ID cannot be empty")
	}

	messages, err := s.repo.GetMessagesByConversationID(conversationID)
	if err != nil {
		return nil, errors.New("failed to retrieve messages: " + err.Error())
	}

	if len(messages) == 0 {
		return nil, errors.New("no messages found in the conversation")
	}

	return messages, nil
}
func (s *conversationService) MarkMessageAsDeleted(conversationID string, messageID string) error {
	if conversationID == "" {
		return errors.New("conversation ID is required")
	}

	if messageID == "" {
		return errors.New("message ID is required")
	}

	err := s.repo.MarkMessageAsDeleted(conversationID, messageID)
	if err != nil {
		return err
	}

	return nil
}
