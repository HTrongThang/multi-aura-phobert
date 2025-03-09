package repositories

import (
	"context"
	"errors"
	"fmt"
	"math/rand"
	"multiaura/internal/databases"
	"multiaura/internal/models"
	"time"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/bson/primitive"
	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

type PostRepository interface {
	Repository[models.Post]
	GetRecentPosts(userIDs []string, limit, page int64) ([]*models.Post, error)
	GetPostsByUser(userID string) ([]*models.Post, error)
	GetCommentsByPostID(postID string) ([]*models.Comment, error)
	SearchTrendingPosts(query string, blockedUserIDs []string, limit, page int64) ([]*models.Post, error)
	SearchNewsMixedPosts(query string, userIDs []string, blockedUserIDs []string, limit, page int64) ([]*models.Post, error)
	SearchPostsForYou(query, userID string, friends []string, blockedUserIDs []string, limit, page int64) ([]*models.Post, error)
	Search(query string, blockedUserIDs []string, limit, page int64) ([]*models.Post, error)
	UploadPhotos(id string, url []string) (bool, error)
	UpdateVoice(id string, url string) (bool, error)
	GetPostByCommentID(commentID string) (*models.Post, error)
	GetCommentByID(commentID string) (*models.Comment, error)
	GetReplyCommentByID(commentID, replyID string) (*models.Comment, error)
	AddComment(postID string, comment models.Comment) error
	DeleteComment(postID, commentID string) error
	UpdateCommentPhotos(postID, commentID string, fileURLs []string) error
	UpdateCommentVoice(postID, commentID string, url string) (bool, error)
	AddReplyToComment(commentID string, reply models.Comment) error
	DeleteReplyFromComment(commentID, replyID string) error
	UpdateReplyCommentPhotos(commentID, replyID string, fileURLs []string) error
	UpdateReplyCommentVoice(commentID, replyID string, url string) (bool, error)
	LikePost(postID string, userSummary models.UserSummary) error
	UnlikePost(postID string, userID string) error
	LikeComment(commentID, username string) error
	UnlikeComment(commentID, username string) error
	LikeReplyComment(commentID, replyID, username string) error
	UnlikeReplyComment(commentID, replyID, username string) error
	GetToxicPosts(toxicityThreshold float64, limit, page int64) ([]*models.Post, error)
	GetToxicPostsByDate(toxicityThreshold float64, day, month, year int) ([]*models.Post, error)
}

type postRepository struct {
	db         *databases.MongoDB
	collection *mongo.Collection
}

func NewPostRepository(db *databases.MongoDB) PostRepository {
	return &postRepository{
		db:         db,
		collection: db.Database.Collection("posts"),
	}
}

func (repo *postRepository) GetByID(id string) (*models.Post, error) {
	var post models.Post

	objectID, err := primitive.ObjectIDFromHex(id)
	if err != nil {
		return &models.Post{}, err
	}

	filter := bson.M{"_id": objectID}

	err = repo.collection.FindOne(context.Background(), filter).Decode(&post)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return nil, nil
		}
		return nil, err
	}

	return &post, nil
}

func (repo *postRepository) Create(entity models.Post) error {
	_, err := repo.collection.InsertOne(context.Background(), entity)
	return err
}

func (repo *postRepository) Delete(id string) error {
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

func (repo *postRepository) Update(entityMap *map[string]interface{}) error {
	objectID, err := primitive.ObjectIDFromHex((*entityMap)["postID"].(string))
	if err != nil {
		return err
	}

	filter := bson.M{"_id": objectID}

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

func (repo *postRepository) GetRecentPosts(userIDs []string, limit, page int64) ([]*models.Post, error) {
	var posts []*models.Post
	sort := bson.D{{Key: "createdAt", Value: -1}}
	skip := (page - 1) * limit

	findOptions := options.Find()
	findOptions.SetSort(sort)
	findOptions.SetLimit(limit)
	findOptions.SetSkip(skip)
	findOptions.SetProjection(bson.M{
		"comments": bson.M{"$slice": 2},
	})

	filter := bson.M{"createdBy.userID": bson.M{"$in": userIDs}}

	cursor, err := repo.collection.Find(context.Background(), filter, findOptions)
	if err != nil {
		return nil, err
	}
	defer cursor.Close(context.Background())

	for cursor.Next(context.Background()) {
		var data map[string]interface{}
		if err := cursor.Decode(&data); err != nil {
			return nil, err
		}

		post, err := new(models.Post).FromMap(data)
		if err != nil {
			return nil, err
		}

		posts = append(posts, post)
	}

	if err := cursor.Err(); err != nil {
		return nil, err
	}

	return posts, nil
}

func (repo *postRepository) GetPostsByUser(userID string) ([]*models.Post, error) {
	var posts []*models.Post

	// Tạo filter để tìm bài viết của người dùng
	filter := bson.M{"createdBy.userID": userID}

	// Cài đặt tùy chọn tìm kiếm
	findOptions := options.Find()
	findOptions.SetSort(bson.D{{Key: "createdAt", Value: -1}}) // Sắp xếp bài viết mới nhất
	findOptions.SetProjection(bson.M{
		"comments": bson.M{"$slice": 2}, // Chỉ lấy 2 bình luận đầu tiên
	})

	// Thực hiện truy vấn
	cursor, err := repo.collection.Find(context.Background(), filter, findOptions)
	if err != nil {
		return nil, err
	}
	defer cursor.Close(context.Background())

	// Lấy dữ liệu từ cursor và decode
	for cursor.Next(context.Background()) {
		var data map[string]interface{}
		if err := cursor.Decode(&data); err != nil {
			return nil, err
		}

		// Convert dữ liệu sang struct Post
		post, err := new(models.Post).FromMap(data)
		if err != nil {
			return nil, err
		}

		posts = append(posts, post)
	}

	// Kiểm tra lỗi cursor (nếu có)
	if err := cursor.Err(); err != nil {
		return nil, err
	}

	return posts, nil
}

func (repo *postRepository) GetCommentsByPostID(postID string) ([]*models.Comment, error) {
	var comments []*models.Comment

	// Chuyển đổi postID từ string sang ObjectID
	objID, err := primitive.ObjectIDFromHex(postID)
	if err != nil {
		return nil, fmt.Errorf("invalid postID: %v", err)
	}

	// Tạo bộ lọc để tìm post theo ID
	filter := bson.M{"_id": objID}

	projection := bson.M{"comments": 1, "_id": 0}

	var result map[string]interface{}
	findOptions := options.FindOne().
		SetProjection(projection).
		SetSort(bson.M{"comments.createdAt": -1})

	err = repo.collection.FindOne(context.Background(), filter, findOptions).Decode(&result)
	if err != nil {
		if errors.Is(err, mongo.ErrNoDocuments) {
			return nil, fmt.Errorf("post not found")
		}
		return nil, fmt.Errorf("failed to query comments: %v", err)
	}

	commentsData, ok := result["comments"].(primitive.A)
	if !ok {
		return nil, nil
	}

	// Chuyển đổi từng comment từ map vào struct Comment
	for _, commentItem := range commentsData {
		// Kiểm tra kiểu của commentItem
		commentMap, ok := commentItem.(map[string]interface{})
		if !ok {
			return nil, fmt.Errorf("failed to cast comment item to map[string]interface{}")
		}

		// Sử dụng FromMap để chuyển đổi từ map sang Comment
		comment, err := new(models.Comment).FromMap(commentMap)
		if err != nil {
			return nil, fmt.Errorf("failed to parse comment: %v", err)
		}
		comments = append(comments, comment)
	}

	return comments, nil
}

func (repo *postRepository) SearchTrendingPosts(query string, blockedUserIDs []string, limit, page int64) ([]*models.Post, error) {
	var posts []*models.Post
	skip := (page - 1) * limit

	// Tạo pipeline
	pipeline := mongo.Pipeline{}

	// Nếu query không rỗng, thêm điều kiện tìm kiếm bằng regex
	if query != "" {
		pipeline = append(pipeline, bson.D{
			{Key: "$match", Value: bson.M{"description": bson.M{"$regex": query, "$options": "i"}}},
		})
	}

	if len(blockedUserIDs) > 0 {
		pipeline = append(pipeline, bson.D{
			{Key: "$match", Value: bson.M{"createdBy.userID": bson.M{"$nin": blockedUserIDs}}},
		})
	}

	// Tính tổng số lượng likes và shares
	pipeline = append(pipeline, bson.D{
		{Key: "$addFields", Value: bson.D{
			{Key: "totalLikes", Value: bson.M{"$size": bson.M{"$ifNull": []interface{}{"$likedBy", []interface{}{}}}}},
			{Key: "totalShares", Value: bson.M{"$size": bson.M{"$ifNull": []interface{}{"$sharedBy", []interface{}{}}}}},
		}},
	})

	// Tạo điểm (score) dựa trên lượt like, share và thời gian tạo (createdAt)
	pipeline = append(pipeline, bson.D{
		{Key: "$addFields", Value: bson.D{
			{Key: "score", Value: bson.M{
				"$add": []interface{}{
					bson.M{"$multiply": []interface{}{"$totalLikes", 2}},  // Mỗi like nhân với 2 điểm
					bson.M{"$multiply": []interface{}{"$totalShares", 1}}, // Mỗi share nhân với 1 điểm
					bson.M{"$divide": []interface{}{
						1,
						bson.M{"$subtract": []interface{}{time.Now(), "$createdAt"}},
					}}, // Thời gian càng gần hiện tại, điểm càng cao
				},
			}},
		}},
	})

	// Sắp xếp theo điểm
	pipeline = append(pipeline, bson.D{
		{Key: "$sort", Value: bson.D{{Key: "score", Value: -1}}},
	})

	// Giới hạn số lượng kết quả
	if limit > 0 {
		pipeline = append(pipeline, bson.D{{Key: "$limit", Value: limit}})
	}

	if skip > 0 {
		pipeline = append(pipeline, bson.D{{Key: "$skip", Value: skip}})
	}

	// Lấy 2 comment đầu tiên
	pipeline = append(pipeline, bson.D{
		{Key: "$project", Value: bson.M{
			"comments":    bson.M{"$slice": []interface{}{"$comments", 2}},
			"totalLikes":  1,
			"totalShares": 1,
			"score":       1,
			"description": 1,
			"createdAt":   1,
			"createdBy":   1,
			"likedBy":     1,
			"sharedBy":    1,
			"images":      1,
		}},
	})

	cursor, err := repo.collection.Aggregate(context.Background(), pipeline)
	if err != nil {
		return nil, err
	}
	defer cursor.Close(context.Background())

	for cursor.Next(context.Background()) {
		var data map[string]interface{}
		if err := cursor.Decode(&data); err != nil {
			return nil, err
		}

		post, err := new(models.Post).FromMap(data)
		if err != nil {
			return nil, err
		}

		posts = append(posts, post)
	}

	if err := cursor.Err(); err != nil {
		return nil, err
	}

	return posts, nil
}

func (repo *postRepository) SearchNewsMixedPosts(query string, userIDs []string, blockedUserIDs []string, limit, page int64) ([]*models.Post, error) {
	var friendPosts []*models.Post
	var otherPosts []*models.Post
	sort := bson.D{{Key: "createdAt", Value: -1}}
	skip := (page - 1) * limit
	// Bước 1: Lấy bài viết từ bạn bè
	friendFilter := bson.M{"createdBy.userID": bson.M{"$in": userIDs}}
	if query != "" {
		// Sử dụng $regex để tìm kiếm description chứa query
		friendFilter["description"] = bson.M{"$regex": query, "$options": "i"} // "i" để tìm kiếm không phân biệt hoa thường
	}
	friendOptions := options.Find().SetSort(sort).SetLimit(limit).SetSkip(skip)
	friendOptions.SetProjection(bson.M{
		"comments": bson.M{"$slice": 2},
	})
	friendCursor, err := repo.collection.Find(context.Background(), friendFilter, friendOptions)
	if err != nil {
		return nil, err
	}
	defer friendCursor.Close(context.Background())

	for friendCursor.Next(context.Background()) {
		var data map[string]interface{}
		if err := friendCursor.Decode(&data); err != nil {
			return nil, err
		}

		post, err := new(models.Post).FromMap(data)
		if err != nil {
			return nil, err
		}

		friendPosts = append(friendPosts, post)
	}
	// Bước 2: Lấy bài viết từ những người khác
	otherFilter := bson.M{"createdBy.userID": bson.M{"$nin": userIDs}}

	if len(blockedUserIDs) > 0 {
		otherFilter["createdBy.userID"] = bson.M{"$nin": append(userIDs, blockedUserIDs...)} // Thêm $nin nếu blockedUserIDs không rỗng
	}

	if query != "" {
		// Sử dụng $regex để tìm kiếm description chứa query
		otherFilter["description"] = bson.M{"$regex": query, "$options": "i"}
	}
	otherOptions := options.Find().SetSort(sort).SetLimit(limit).SetSkip(skip)

	otherCursor, err := repo.collection.Find(context.Background(), otherFilter, otherOptions)
	if err != nil {
		return nil, err
	}
	defer otherCursor.Close(context.Background())
	for otherCursor.Next(context.Background()) {
		var data map[string]interface{}
		if err := otherCursor.Decode(&data); err != nil {
			return nil, err
		}

		post, err := new(models.Post).FromMap(data)
		if err != nil {
			return nil, err
		}

		otherPosts = append(otherPosts, post)
	}
	// Bước 3: Trộn bài viết theo quy tắc đã nêu
	var mixedPosts []*models.Post
	friendCount := 0
	otherCount := 0

	for len(mixedPosts) < int(limit) {
		// Nếu cả hai danh sách friendPosts và otherPosts đều đã hết bài viết, thoát vòng lặp
		if friendCount >= len(friendPosts) && otherCount >= len(otherPosts) {
			break
		}

		// Thêm các bài viết từ friendPosts, đảm bảo 3 bài đầu tiên và xen kẽ 2 bài tiếp theo
		if friendCount < len(friendPosts) {
			// 3 bài đầu tiên từ bạn bè
			if len(mixedPosts) < 3 {
				mixedPosts = append(mixedPosts, friendPosts[friendCount])
				friendCount++
			} else if (len(mixedPosts)-3)%2 == 0 && len(mixedPosts) < int(limit) {
				// Xen kẽ bài viết từ bạn bè sau 3 bài đầu tiên
				mixedPosts = append(mixedPosts, friendPosts[friendCount])
				friendCount++
			}
		}

		// Thêm bài viết từ otherPosts, đảm bảo xen kẽ 2 bài mỗi chu kỳ
		if otherCount < len(otherPosts) {
			// Thêm 2 bài từ những người khác sau các bài viết của bạn bè
			if len(mixedPosts) < 2 || (len(mixedPosts)-3)%2 == 1 {
				mixedPosts = append(mixedPosts, otherPosts[otherCount])
				otherCount++
			}
		}

		// Nếu không còn đủ bài từ friendPosts hoặc otherPosts, lấy hết bài còn lại từ danh sách còn lại
		if friendCount >= len(friendPosts) && otherCount < len(otherPosts) {
			// Nếu friendPosts hết, lấy hết bài còn lại từ otherPosts
			remainingPosts := otherPosts[otherCount:]
			mixedPosts = append(mixedPosts, remainingPosts...)
			break
		}

		if otherCount >= len(otherPosts) && friendCount < len(friendPosts) {
			// Nếu otherPosts hết, lấy hết bài còn lại từ friendPosts
			remainingPosts := friendPosts[friendCount:]
			mixedPosts = append(mixedPosts, remainingPosts...)
			break
		}
	}

	rand.Seed(time.Now().UnixNano())
	rand.Shuffle(len(mixedPosts), func(i, j int) {
		mixedPosts[i], mixedPosts[j] = mixedPosts[j], mixedPosts[i]
	})

	if int64(len(mixedPosts)) > limit {
		mixedPosts = mixedPosts[:limit]
	}

	return mixedPosts, nil
}

func (repo *postRepository) SearchPostsForYou(query, userID string, friends []string, blockedUserIDs []string, limit, page int64) ([]*models.Post, error) {
	var posts []*models.Post
	skip := (page - 1) * limit

	// Điều kiện loại trừ blockedUserIDs và chính userID
	excludedIDs := append(blockedUserIDs, userID)
	seenPostIDs := make(map[string]bool) // Để theo dõi bài viết đã thêm

	// ------------------------------
	// Lấy bài viết từ bạn bè
	// ------------------------------
	friendFilter := bson.M{
		"createdBy.userID": bson.M{"$in": friends, "$nin": excludedIDs},
	}

	if query != "" {
		friendFilter["description"] = bson.M{"$regex": query, "$options": "i"}
	}

	friendSort := bson.D{{Key: "createdAt", Value: -1}} // Sắp xếp mới nhất trước

	friendOptions := options.Find().
		SetSort(friendSort).
		SetLimit(limit).
		SetSkip(skip).
		SetProjection(bson.M{
			"comments": bson.M{"$slice": 2}, // Lấy 2 comment đầu tiên
		})

	// Lấy bài viết từ bạn bè
	cursor, err := repo.collection.Find(context.Background(), friendFilter, friendOptions)
	if err != nil {
		return nil, err
	}
	defer cursor.Close(context.Background())

	for cursor.Next(context.Background()) {
		var post models.Post
		if err := cursor.Decode(&post); err != nil {
			return nil, err
		}

		// Chỉ thêm bài viết nếu chưa tồn tại trong tập hợp
		if !seenPostIDs[post.ID.Hex()] {
			posts = append(posts, &post)
			seenPostIDs[post.ID.Hex()] = true
		}
	}

	// ------------------------------
	// Lấy bài viết phổ biến từ người khác
	// ------------------------------
	otherFilter := bson.M{
		"createdBy.userID": bson.M{"$nin": excludedIDs}, // Loại trừ các blockedUserIDs và chính userID
	}

	if query != "" {
		otherFilter["description"] = bson.M{"$regex": query, "$options": "i"}
	}

	otherSort := bson.D{{Key: "likesCount", Value: -1}} // Sắp xếp theo lượt thích

	otherOptions := options.Find().
		SetSort(otherSort).
		SetLimit(limit).
		SetSkip(skip).
		SetProjection(bson.M{
			"comments": bson.M{"$slice": 2}, // Lấy 2 comment đầu tiên
		})

	// Lấy bài viết phổ biến từ người khác
	cursor, err = repo.collection.Find(context.Background(), otherFilter, otherOptions)
	if err != nil {
		return nil, err
	}
	defer cursor.Close(context.Background())

	for cursor.Next(context.Background()) {
		var post models.Post
		if err := cursor.Decode(&post); err != nil {
			return nil, err
		}

		// Chỉ thêm bài viết nếu chưa tồn tại trong tập hợp
		if !seenPostIDs[post.ID.Hex()] {
			posts = append(posts, &post)
			seenPostIDs[post.ID.Hex()] = true
		}
	}

	// ------------------------------
	// Giới hạn kết quả trả về
	// ------------------------------
	if int64(len(posts)) > limit {
		posts = posts[:limit]
	}

	return posts, nil
}

func (repo *postRepository) Search(query string, blockedUserIDs []string, limit int64, page int64) ([]*models.Post, error) {
	var posts []*models.Post
	sort := bson.D{{Key: "createdAt", Value: -1}}
	skip := (page - 1) * limit

	findOptions := options.Find()
	findOptions.SetSort(sort)
	findOptions.SetLimit(limit)
	findOptions.SetSkip(skip)
	findOptions.SetProjection(bson.M{
		"comments": bson.M{"$slice": 2},
	})
	// log.Println(blockedUserIDs)

	filter := bson.M{
		"$and": []bson.M{
			{
				"description": bson.M{"$regex": query, "$options": "i"},
			},
		},
	}

	if len(blockedUserIDs) > 0 {
		filter["createdBy.userID"] = bson.M{"$nin": blockedUserIDs}
	}

	cursor, err := repo.collection.Find(context.Background(), filter, findOptions)
	if err != nil {
		return nil, err
	}
	defer cursor.Close(context.Background())

	for cursor.Next(context.Background()) {
		var data map[string]interface{}
		if err := cursor.Decode(&data); err != nil {
			return nil, err
		}

		post, err := new(models.Post).FromMap(data)
		if err != nil {
			return nil, err
		}

		posts = append(posts, post)
	}

	if err := cursor.Err(); err != nil {
		return nil, err
	}

	return posts, nil
}

func (repo *postRepository) UploadPhotos(id string, urls []string) (bool, error) {
	objID, err := primitive.ObjectIDFromHex(id)
	if err != nil {
		return false, err
	}

	var images []models.Image
	for _, url := range urls {
		images = append(images, models.Image{
			URL: url,
			ID:  primitive.NewObjectID(),
		})
	}

	filter := bson.M{
		"_id": objID,
	}

	update := bson.M{
		"$set": bson.M{
			"images": images,
		},
	}

	result, err := repo.collection.UpdateOne(context.Background(), filter, update)
	if err != nil {
		return false, err
	}

	if result.MatchedCount == 0 {
		return false, nil
	}

	return true, nil
}

func (repo *postRepository) UpdateVoice(id string, url string) (bool, error) {
	objID, err := primitive.ObjectIDFromHex(id)
	if err != nil {
		return false, err
	}

	filter := bson.M{
		"_id": objID,
	}

	update := bson.M{
		"$set": bson.M{
			"voice": url,
		},
	}

	result, err := repo.collection.UpdateOne(context.Background(), filter, update)
	if err != nil {
		return false, err
	}

	if result.MatchedCount == 0 {
		return false, nil
	}

	return true, nil
}

func (r *postRepository) AddComment(postID string, comment models.Comment) error {
	objPostID, err := primitive.ObjectIDFromHex(postID)
	if err != nil {
		return fmt.Errorf("invalid post ID: %w", err)
	}

	filter := bson.M{"_id": objPostID}
	update := bson.M{"$push": bson.M{"comments": comment}}

	_, err = r.collection.UpdateOne(context.TODO(), filter, update)
	if err != nil {
		return err
	}
	return nil
}

func (repo *postRepository) GetPostByCommentID(commentID string) (*models.Post, error) {
	objCommentID, err := primitive.ObjectIDFromHex(commentID)
	if err != nil {
		return nil, fmt.Errorf("invalid comment ID: %w", err)
	}
	filter := bson.M{
		"comments": bson.M{
			"$elemMatch": bson.M{
				"_id": objCommentID,
			},
		},
	}

	var post models.Post
	err = repo.collection.FindOne(context.TODO(), filter).Decode(&post)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return nil, fmt.Errorf("no post found with comment ID: %s", commentID)
		}
		return nil, fmt.Errorf("failed to fetch post by comment ID: %w", err)
	}

	return &post, nil
}

func (repo *postRepository) GetCommentByID(commentID string) (*models.Comment, error) {
	objCommentID, err := primitive.ObjectIDFromHex(commentID)
	if err != nil {
		return nil, fmt.Errorf("invalid comment ID: %w", err)
	}

	filter := bson.M{
		"comments": bson.M{
			"$elemMatch": bson.M{
				"_id": objCommentID,
			},
		},
	}

	var post models.Post
	err = repo.collection.FindOne(context.TODO(), filter).Decode(&post)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return nil, fmt.Errorf("no comment found with ID: %s", commentID)
		}
		return nil, fmt.Errorf("failed to fetch comment by ID: %w", err)
	}

	for _, comment := range post.Comments {
		if comment.ID == objCommentID {
			return &comment, nil
		}
	}

	return nil, fmt.Errorf("comment not found with ID: %s", commentID)
}

func (repo *postRepository) GetReplyCommentByID(commentID, replyID string) (*models.Comment, error) {
	comment, err := repo.GetCommentByID(commentID)
	if err != nil {
		return nil, fmt.Errorf("failed to find comment for ID %s: %w", commentID, err)
	}

	objReplyID, err := primitive.ObjectIDFromHex(replyID)
	if err != nil {
		return nil, fmt.Errorf("invalid reply ID: %w", err)
	}

	for _, reply := range comment.Replies {
		if reply.ID == objReplyID {
			return &reply, nil
		}
	}

	return nil, fmt.Errorf("reply not found with ID: %s", replyID)
}

func (repo *postRepository) DeleteComment(postID, commentID string) error {
	objPostID, err := primitive.ObjectIDFromHex(postID)
	if err != nil {
		return fmt.Errorf("invalid post ID: %w", err)
	}

	filter := bson.M{
		"_id": objPostID,
	}

	objCommentID, err := primitive.ObjectIDFromHex(commentID)
	if err != nil {
		return fmt.Errorf("invalid comment ID: %w", err)
	}

	update := bson.M{
		"$pull": bson.M{
			"comments": bson.M{
				"_id": objCommentID,
			},
		},
	}

	result, err := repo.collection.UpdateOne(context.TODO(), filter, update)
	if err != nil {
		return fmt.Errorf("failed to delete comment: %w", err)
	}

	if result.ModifiedCount == 0 {
		return fmt.Errorf("no comment found with ID: %s in post: %s", commentID, postID)
	}

	return nil
}

func (repo *postRepository) AddReplyToComment(commentID string, reply models.Comment) error {
	post, err := repo.GetPostByCommentID(commentID)
	if err != nil {
		return fmt.Errorf("failed to find post for comment ID %s: %w", commentID, err)
	}

	objPostID := post.ID

	objCommentID, err := primitive.ObjectIDFromHex(commentID)
	if err != nil {
		return err
	}
	filter := bson.M{
		"_id":          objPostID,
		"comments._id": objCommentID,
	}

	update := bson.M{
		"$push": bson.M{
			"comments.$.replies": reply,
		},
	}

	result, err := repo.collection.UpdateOne(context.TODO(), filter, update)
	if err != nil {
		return fmt.Errorf("failed to add reply to comment: %w", err)
	}

	if result.ModifiedCount == 0 {
		return fmt.Errorf("no comment found with ID: %s in post: %s", commentID, objPostID.Hex())
	}

	return nil
}

func (repo *postRepository) DeleteReplyFromComment(commentID, replyID string) error {
	objCommentID, err := primitive.ObjectIDFromHex(commentID)
	if err != nil {
		return err
	}

	filter := bson.M{
		"comments._id": objCommentID,
	}

	objReplyID, err := primitive.ObjectIDFromHex(replyID)
	if err != nil {
		return err
	}

	update := bson.M{
		"$pull": bson.M{
			"comments.$.replies": bson.M{
				"_id": objReplyID,
			},
		},
	}

	result, err := repo.collection.UpdateOne(context.TODO(), filter, update)
	if err != nil {
		return fmt.Errorf("failed to delete reply from comment: %w", err)
	}

	if result.ModifiedCount == 0 {
		return fmt.Errorf("no reply found with ID: %s in comment: %s", replyID, commentID)
	}

	return nil
}

func (repo *postRepository) UpdateCommentPhotos(postID, commentID string, fileURLs []string) error {
	objPostID, err := primitive.ObjectIDFromHex(postID)
	if err != nil {
		return fmt.Errorf("invalid post ID: %w", err)
	}

	// Tạo đối tượng ảnh
	var images []models.Image
	for _, url := range fileURLs {
		images = append(images, models.Image{
			URL: url,
			ID:  primitive.NewObjectID(),
		})
	}

	objCommentID, err := primitive.ObjectIDFromHex(commentID)
	if err != nil {
		return err
	}

	// Filter để tìm đúng comment trong mảng comments
	filter := bson.M{
		"_id":          objPostID,
		"comments._id": objCommentID,
	}

	// Update để thêm URLs vào comment
	update := bson.M{
		"$push": bson.M{
			"comments.$.images": bson.M{"$each": images},
		},
	}

	_, err = repo.collection.UpdateOne(context.TODO(), filter, update)
	if err != nil {
		return fmt.Errorf("failed to update comment photos: %w", err)
	}

	return nil
}

func (repo *postRepository) UpdateCommentVoice(postID string, commentID string, url string) (bool, error) {
	objPostID, err := primitive.ObjectIDFromHex(postID)
	if err != nil {
		return false, err
	}

	objCommentID, err := primitive.ObjectIDFromHex(commentID)
	if err != nil {
		return false, err
	}

	filter := bson.M{
		"_id":          objPostID,
		"comments._id": objCommentID,
	}

	// Cập nhật URL voice của bình luận
	update := bson.M{
		"$set": bson.M{
			"comments.$.voice": url,
		},
	}

	result, err := repo.collection.UpdateOne(context.TODO(), filter, update)
	if err != nil {
		return false, err
	}

	if result.MatchedCount == 0 {
		return false, nil
	}

	return true, nil
}

func (repo *postRepository) UpdateReplyCommentPhotos(commentID, replyID string, fileURLs []string) error {
	post, err := repo.GetPostByCommentID(commentID)
	if err != nil {
		return fmt.Errorf("failed to find post for comment ID %s: %w", commentID, err)
	}

	objPostID := post.ID

	var images []models.Image
	for _, url := range fileURLs {
		images = append(images, models.Image{
			URL: url,
			ID:  primitive.NewObjectID(),
		})
	}

	objCommentID, err := primitive.ObjectIDFromHex(commentID)
	if err != nil {
		return err
	}

	filter := bson.M{
		"_id":          objPostID,
		"comments._id": objCommentID,
	}

	update := bson.M{
		"$push": bson.M{
			"comments.$[comment].replies.$[reply].images": bson.M{
				"$each": images,
			},
		},
	}

	objReplyID, err := primitive.ObjectIDFromHex(replyID)
	if err != nil {
		return err
	}

	arrayFilters := options.ArrayFilters{
		Filters: []interface{}{
			bson.M{"comment._id": objCommentID},
			bson.M{"reply._id": objReplyID},
		},
	}

	updateOptions := options.UpdateOptions{
		ArrayFilters: &arrayFilters,
	}

	_, err = repo.collection.UpdateOne(context.TODO(), filter, update, &updateOptions)
	if err != nil {
		return fmt.Errorf("failed to update reply photos: %w", err)
	}

	return nil
}

func (repo *postRepository) UpdateReplyCommentVoice(commentID string, replyID string, url string) (bool, error) {
	post, err := repo.GetPostByCommentID(commentID)
	if err != nil {
		return false, fmt.Errorf("failed to find post for comment ID %s: %w", commentID, err)
	}

	objPostID := post.ID

	objCommentID, err := primitive.ObjectIDFromHex(commentID)
	if err != nil {
		return false, err
	}

	objReplyID, err := primitive.ObjectIDFromHex(replyID)
	if err != nil {
		return false, err
	}

	filter := bson.M{
		"_id":                  objPostID,
		"comments._id":         objCommentID,
		"comments.replies._id": objReplyID,
	}

	update := bson.M{
		"$set": bson.M{
			"comments.$[comment].replies.$[reply].voice": url,
		},
	}

	arrayFilters := options.ArrayFilters{
		Filters: []interface{}{
			bson.M{"comment._id": objCommentID},
			bson.M{"reply._id": objReplyID},
		},
	}

	updateOptions := options.UpdateOptions{
		ArrayFilters: &arrayFilters,
	}

	result, err := repo.collection.UpdateOne(context.TODO(), filter, update, &updateOptions)
	if err != nil {
		return false, fmt.Errorf("failed to update reply comment voice: %w", err)
	}

	if result.MatchedCount == 0 {
		return false, nil
	}

	return true, nil
}

func (repo *postRepository) LikePost(postID string, userSummary models.UserSummary) error {
	objPostID, err := primitive.ObjectIDFromHex(postID)
	if err != nil {
		return fmt.Errorf("invalid post ID: %w", err)
	}

	filter := bson.M{"_id": objPostID}
	update := bson.M{
		"$addToSet": bson.M{"likedBy": userSummary},
	}

	_, err = repo.collection.UpdateOne(context.TODO(), filter, update)
	if err != nil {
		return fmt.Errorf("failed to like post: %w", err)
	}

	return nil
}

func (repo *postRepository) UnlikePost(postID string, userID string) error {
	objPostID, err := primitive.ObjectIDFromHex(postID)
	if err != nil {
		return fmt.Errorf("invalid post ID: %w", err)
	}

	filter := bson.M{"_id": objPostID}
	update := bson.M{
		"$pull": bson.M{"likedBy": bson.M{"userID": userID}},
	}

	_, err = repo.collection.UpdateOne(context.TODO(), filter, update)
	if err != nil {
		return fmt.Errorf("failed to unlike post: %w", err)
	}

	return nil
}

func (repo *postRepository) LikeComment(commentID, username string) error {
	post, err := repo.GetPostByCommentID(commentID)
	if err != nil {
		return fmt.Errorf("failed to find post for comment ID %s: %w", commentID, err)
	}

	objCommentID, err := primitive.ObjectIDFromHex(commentID)
	if err != nil {
		return fmt.Errorf("invalid comment ID: %w", err)
	}

	filter := bson.M{
		"_id":          post.ID,
		"comments._id": objCommentID,
	}

	update := bson.M{
		"$addToSet": bson.M{
			"comments.$.likedBy": username,
		},
	}

	result, err := repo.collection.UpdateOne(context.TODO(), filter, update)
	if err != nil {
		return fmt.Errorf("failed to like comment: %w", err)
	}

	if result.ModifiedCount == 0 {
		return fmt.Errorf("no comment found with ID: %s in post: %s", commentID, post.ID)
	}

	return nil
}

func (repo *postRepository) UnlikeComment(commentID, username string) error {
	post, err := repo.GetPostByCommentID(commentID)
	if err != nil {
		return fmt.Errorf("failed to find post for comment ID %s: %w", commentID, err)
	}

	objCommentID, err := primitive.ObjectIDFromHex(commentID)
	if err != nil {
		return fmt.Errorf("invalid comment ID: %w", err)
	}

	filter := bson.M{
		"_id":          post.ID,
		"comments._id": objCommentID,
	}

	update := bson.M{
		"$pull": bson.M{
			"comments.$.likedBy": username,
		},
	}

	result, err := repo.collection.UpdateOne(context.TODO(), filter, update)
	if err != nil {
		return fmt.Errorf("failed to unlike comment: %w", err)
	}

	if result.ModifiedCount == 0 {
		return fmt.Errorf("no comment found with ID: %s in post: %s", commentID, post.ID)
	}

	return nil
}

func (repo *postRepository) LikeReplyComment(commentID, replyID, username string) error {
	post, err := repo.GetPostByCommentID(commentID)
	if err != nil {
		return fmt.Errorf("failed to find post for comment ID %s: %w", commentID, err)
	}

	objCommentID, err := primitive.ObjectIDFromHex(commentID)
	if err != nil {
		return fmt.Errorf("invalid comment ID: %w", err)
	}

	objReplyID, err := primitive.ObjectIDFromHex(replyID)
	if err != nil {
		return fmt.Errorf("invalid reply ID: %w", err)
	}

	filter := bson.M{
		"_id":          post.ID,
		"comments._id": objCommentID,
	}

	update := bson.M{
		"$addToSet": bson.M{
			"comments.$[comment].replies.$[reply].likedBy": username,
		},
	}

	arrayFilters := options.ArrayFilters{
		Filters: []interface{}{
			bson.M{"comment._id": objCommentID},
			bson.M{"reply._id": objReplyID},
		},
	}

	updateOptions := options.UpdateOptions{
		ArrayFilters: &arrayFilters,
	}

	result, err := repo.collection.UpdateOne(context.TODO(), filter, update, &updateOptions)
	if err != nil {
		return fmt.Errorf("failed to like reply comment: %w", err)
	}

	if result.ModifiedCount == 0 {
		return fmt.Errorf("no reply comment found with ID: %s in comment: %s", replyID, commentID)
	}

	return nil
}

func (repo *postRepository) UnlikeReplyComment(commentID, replyID, username string) error {
	post, err := repo.GetPostByCommentID(commentID)
	if err != nil {
		return fmt.Errorf("failed to find post for comment ID %s: %w", commentID, err)
	}

	objCommentID, err := primitive.ObjectIDFromHex(commentID)
	if err != nil {
		return fmt.Errorf("invalid comment ID: %w", err)
	}

	objReplyID, err := primitive.ObjectIDFromHex(replyID)
	if err != nil {
		return fmt.Errorf("invalid reply ID: %w", err)
	}

	filter := bson.M{
		"_id":          post.ID,
		"comments._id": objCommentID,
	}

	update := bson.M{
		"$pull": bson.M{
			"comments.$[comment].replies.$[reply].likedBy": username,
		},
	}

	arrayFilters := options.ArrayFilters{
		Filters: []interface{}{
			bson.M{"comment._id": objCommentID},
			bson.M{"reply._id": objReplyID},
		},
	}

	updateOptions := options.UpdateOptions{
		ArrayFilters: &arrayFilters,
	}

	result, err := repo.collection.UpdateOne(context.TODO(), filter, update, &updateOptions)
	if err != nil {
		return fmt.Errorf("failed to unlike reply comment: %w", err)
	}

	if result.ModifiedCount == 0 {
		return fmt.Errorf("no reply comment found with ID: %s in comment: %s", replyID, commentID)
	}

	return nil
}

func (repo *postRepository) GetToxicPosts(toxicityThreshold float64, limit, page int64) ([]*models.Post, error) {
	var posts []*models.Post
	sort := bson.D{{Key: "createdAt", Value: -1}}
	skip := (page - 1) * limit

	findOptions := options.Find()
	findOptions.SetSort(sort)
	findOptions.SetLimit(limit)
	findOptions.SetSkip(skip)

	// Lọc các bài viết có toxicityScore vượt ngưỡng hoặc có comment/reply có toxicityScore vượt ngưỡng
	filter := bson.M{
		"$or": []bson.M{
			// Điều kiện 1: Bài viết có toxicityScore vượt ngưỡng
			{"toxicityScore": bson.M{"$gte": toxicityThreshold}},
			// Điều kiện 2: Có comment có toxicityScore vượt ngưỡng
			{"comments.toxicityScore": bson.M{"$gte": toxicityThreshold}},
			// Điều kiện 3: Có reply comment có toxicityScore vượt ngưỡng
			{"comments.replies.toxicityScore": bson.M{"$gte": toxicityThreshold}},
		},
	}

	cursor, err := repo.collection.Find(context.Background(), filter, findOptions)
	if err != nil {
		return nil, err
	}
	defer cursor.Close(context.Background())

	for cursor.Next(context.Background()) {
		var data map[string]interface{}
		if err := cursor.Decode(&data); err != nil {
			return nil, err
		}

		post, err := new(models.Post).FromMap(data)
		if err != nil {
			return nil, err
		}

		// Lọc các comment và reply comment có toxicityScore vượt ngưỡng
		for i, comment := range post.Comments {
			var filteredReplies []models.Comment

			// Nếu comment toxic, giữ lại tất cả reply toxic
			if comment.ToxicityScore >= toxicityThreshold {
				// Giữ lại tất cả reply toxic
				for _, reply := range comment.Replies {
					if reply.ToxicityScore >= toxicityThreshold {
						filteredReplies = append(filteredReplies, reply)
					}
				}
				// Cập nhật lại các reply đã lọc
				post.Comments[i].Replies = filteredReplies

			} else {
				// Nếu comment không toxic, chỉ giữ lại reply toxic
				for _, reply := range comment.Replies {
					if reply.ToxicityScore >= toxicityThreshold {
						filteredReplies = append(filteredReplies, reply)
					}
				}
				// Cập nhật lại reply, chỉ giữ lại reply toxic
				post.Comments[i].Replies = filteredReplies

				// Nếu không có reply toxic, loại bỏ comment này
				if len(filteredReplies) == 0 {
					post.Comments[i] = models.Comment{} // Xóa comment nếu không có reply toxic
				}
			}
		}

		// Nếu bài viết hoặc comment nào không thỏa mãn thì loại bỏ
		// Kiểm tra bài viết hoặc comment có toxicityScore vượt ngưỡng hoặc có comment/đã lọc với reply toxic
		if post.ToxicityScore >= toxicityThreshold || len(post.Comments) > 0 {
			// Lọc bỏ những comment không có reply thỏa mãn
			var validComments []models.Comment
			for _, comment := range post.Comments {
				if comment.ToxicityScore >= toxicityThreshold || len(comment.Replies) > 0 {
					validComments = append(validComments, comment)
				}
			}
			post.Comments = validComments

			// Nếu vẫn có comment hợp lệ, thêm bài viết vào kết quả
			if len(post.Comments) > 0 || post.ToxicityScore >= toxicityThreshold {
				posts = append(posts, post)
			}
		}
	}

	if err := cursor.Err(); err != nil {
		return nil, err
	}

	return posts, nil
}

func (repo *postRepository) GetToxicPostsByDate(toxicityThreshold float64, day, month, year int) ([]*models.Post, error) {
	var posts []*models.Post
	sort := bson.D{{Key: "createdAt", Value: -1}}

	findOptions := options.Find()
	findOptions.SetSort(sort)

	dateFilter := bson.M{}

	if day != 0 && month != 0 && year != 0 {
		// Tìm theo ngày, tháng, năm cụ thể
		startDate := time.Date(year, time.Month(month), day, 0, 0, 0, 0, time.UTC)
		endDate := startDate.AddDate(0, 0, 1)
		dateFilter["createdAt"] = bson.M{"$gte": startDate, "$lt": endDate}
	} else if day == 0 && month != 0 && year != 0 {
		// Tìm theo tháng, năm
		startDate := time.Date(year, time.Month(month), 1, 0, 0, 0, 0, time.UTC)
		endDate := startDate.AddDate(0, 1, 0)
		dateFilter["createdAt"] = bson.M{"$gte": startDate, "$lt": endDate}
	} else if day == 0 && month == 0 && year != 0 {
		// Tìm theo năm
		startDate := time.Date(year, 1, 1, 0, 0, 0, 0, time.UTC)
		endDate := startDate.AddDate(1, 0, 0)
		dateFilter["createdAt"] = bson.M{"$gte": startDate, "$lt": endDate}
	} else {
		// Điều kiện không hợp lệ
		return nil, fmt.Errorf("invalid date parameters: at least year must be specified")
	}

	// Tạo bộ lọc chính
	filter := bson.M{
		"$and": []bson.M{
			{"$or": []bson.M{
				{"toxicityScore": bson.M{"$gte": toxicityThreshold}},
				{"comments.toxicityScore": bson.M{"$gte": toxicityThreshold}},
				{"comments.replies.toxicityScore": bson.M{"$gte": toxicityThreshold}},
			}},
			dateFilter,
		},
	}

	cursor, err := repo.collection.Find(context.Background(), filter, findOptions)
	if err != nil {
		return nil, err
	}
	defer cursor.Close(context.Background())

	for cursor.Next(context.Background()) {
		var data map[string]interface{}
		if err := cursor.Decode(&data); err != nil {
			return nil, err
		}

		post, err := new(models.Post).FromMap(data)
		if err != nil {
			return nil, err
		}

		// Lọc các comment và reply comment có toxicityScore vượt ngưỡng
		for i, comment := range post.Comments {
			var filteredReplies []models.Comment

			if comment.ToxicityScore >= toxicityThreshold {
				for _, reply := range comment.Replies {
					if reply.ToxicityScore >= toxicityThreshold {
						filteredReplies = append(filteredReplies, reply)
					}
				}
				post.Comments[i].Replies = filteredReplies
			} else {
				for _, reply := range comment.Replies {
					if reply.ToxicityScore >= toxicityThreshold {
						filteredReplies = append(filteredReplies, reply)
					}
				}
				post.Comments[i].Replies = filteredReplies
				if len(filteredReplies) == 0 {
					post.Comments[i] = models.Comment{}
				}
			}
		}

		var validComments []models.Comment
		for _, comment := range post.Comments {
			if comment.ToxicityScore >= toxicityThreshold || len(comment.Replies) > 0 {
				validComments = append(validComments, comment)
			}
		}
		post.Comments = validComments

		if len(post.Comments) > 0 || post.ToxicityScore >= toxicityThreshold {
			posts = append(posts, post)
		}
	}

	if err := cursor.Err(); err != nil {
		return nil, err
	}

	return posts, nil
}
