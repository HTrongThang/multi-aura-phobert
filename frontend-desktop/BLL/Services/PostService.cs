using BLL.Network;
using BLL.Repositories.IRepositories;
using DTO;
using DTO.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        // CRUD
        // Post
        public async Task<(Post, string)> CreatePostAsync(string description, string textToSpeech, IEnumerable<string> photoPaths)
        {
            var response = await _postRepository.CreatePostAsync(description);

            if (response is SuccessResponse<string> successResponse)
            {
                var postData = JsonConvert.DeserializeObject<dynamic>(successResponse.Data);
                string postId = postData.data._id;

                if ((photoPaths != null && photoPaths.Any()) || !string.IsNullOrEmpty(textToSpeech))
                {
                    var (result, errorMessage) = await UploadPostMediasAsync(postId, textToSpeech, photoPaths);

                    if (!result)
                    {
                        await DeletePostAsync(postId);
                        return (null, errorMessage);
                    }
                }

                var (post, error) = await GetPostsByIdAsync(postId);
                if(post != null)
                {
                    post.CreatedAt = DateTime.Now;
                    post.UpdatedAt = DateTime.Now;
                }

                return (post, error);
            }

            return (null, "Error creating post");
        }

        public async Task<(bool, string)> DeletePostAsync(string postId)
        {
            // First, delete the media associated with the post
            var (mediasDeleted, errorMessage) = await DeletePostMediaDataAsync(postId);
            if (!mediasDeleted)
            {
                return (false, $"Error deleting post medias: {errorMessage}");
            }

            // If media deletion is successful, proceed to delete the post
            var response = await _postRepository.DeletePostAsync(postId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error deleting post");
        }

        // Comment
        public async Task<(Comment, string)> CreateCommentAsync(string postId, string text, string textToSpeech, IEnumerable<string> photoPaths)
        {
            var response = await _postRepository.CreateCommentAsync(postId, text);

            if (response is SuccessResponse<string> successResponse)
            {
                var commentData = JsonConvert.DeserializeObject<dynamic>(successResponse.Data);
                string commentId = commentData.data._id;

                if ((photoPaths != null && photoPaths.Any()) || !string.IsNullOrEmpty(textToSpeech))
                {
                    var (result, errorMessage) = await UploadCommentMediasAsync(commentId, textToSpeech, photoPaths);
                    if (!result)
                    {
                        (result, errorMessage) = await DeleteCommentAsync(commentId);
                        return (null, errorMessage);
                    }
                }

                var (comment, error) = await GetCommentByIDAsync(commentId);
                if (comment != null)
                {
                    comment.CreatedAt = DateTime.Now;
                    comment.UpdatedAt = DateTime.Now;
                }

                return (comment, error);
            }

            return (null, "Error creating comment");
        }

        public async Task<(bool, string)> DeleteCommentAsync(string commentId)
        {
            // First, delete the media associated with the comment
            var (mediasDeleted, errorMessage) = await DeleteCommentMediaDataAsync(commentId);
            if (!mediasDeleted)
            {
                return (false, $"Error deleting comment medias: {errorMessage}");
            }

            // If media deletion is successful, proceed to delete the comment
            var response = await _postRepository.DeleteCommentAsync(commentId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error deleting comment");
        }

        // Reply comment
        public async Task<(Comment, string)> CreateReplyCommentAsync(string commentId, string text, string textToSpeech, IEnumerable<string> photoPaths)
        {
            var response = await _postRepository.CreateReplyCommentAsync(commentId, text);

            if (response is SuccessResponse<string> successResponse)
            {
                var replyData = JsonConvert.DeserializeObject<dynamic>(successResponse.Data);
                string replyId = replyData.data._id;

                if ((photoPaths != null && photoPaths.Any()) || !string.IsNullOrEmpty(textToSpeech))
                {
                    var (result, errorMessage) = await UploadReplyCommentMediasAsync(commentId, replyId, textToSpeech, photoPaths);
                    if (!result)
                    {
                        (result, errorMessage) = await DeleteReplyCommentAsync(commentId, replyId);
                        return (null, errorMessage);
                    }
                }

                var (reply, error) = await GetReplyCommentByIDAsync(commentId, replyId);
                if (reply != null)
                {
                    reply.CreatedAt = DateTime.Now;
                    reply.UpdatedAt = DateTime.Now;
                }

                return (reply, error);
            }

            return (null, "Error creating reply comment");
        }

        public async Task<(bool, string)> DeleteReplyCommentAsync(string commentId, string replyId)
        {
            // First, delete the media associated with the reply comment
            var (mediasDeleted, errorMessage) = await DeleteReplyCommentMediaDataAsync(commentId, replyId);
            if (!mediasDeleted)
            {
                return (false, $"Error deleting reply comment medias: {errorMessage}");
            }

            // If media deletion is successful, proceed to delete the reply comment
            var response = await _postRepository.DeletReplyCommentAsync(commentId, replyId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error deleting reply comment");
        }

        //GET BY ID
        public async Task<(Post, string)> GetPostsByIdAsync(string commentId)
        {
            var response = await _postRepository.GetPostsByIdAsync(commentId);

            if (response is SuccessResponse<string> successResponse)
            {
                if (string.IsNullOrEmpty(successResponse.Data))
                {
                    return (null, string.Empty);
                }

                var jsonObject = JsonConvert.DeserializeObject<dynamic>(successResponse.Data);

                var post = new Post();
                if (jsonObject.data != null)
                {
                    var postData = jsonObject.data.ToObject<Dictionary<string, object>>();
                    post = Post.FromDictionary(postData);
                    return (post, string.Empty);
                }
                else
                {
                    return (null, "Post not found");
                }
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }

        public async Task<(Comment, string)> GetCommentByIDAsync(string commentId)
        {
            var response = await _postRepository.GetCommentByIDAsync(commentId);

            if (response is SuccessResponse<string> successResponse)
            {
                if (string.IsNullOrEmpty(successResponse.Data))
                {
                    return (null, string.Empty);
                }

                var jsonObject = JsonConvert.DeserializeObject<dynamic>(successResponse.Data);

                var result = new Comment();
                if (jsonObject.data != null)
                {
                    var jsonData = jsonObject.data.ToObject<Dictionary<string, object>>();
                    result = Comment.FromDictionary(jsonData);
                    return (result, string.Empty);
                }
                else
                {
                    return (null, "Comment not found");
                }
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }

        public async Task<(Comment, string)> GetReplyCommentByIDAsync(string commentId, string replyId)
        {
            var response = await _postRepository.GetReplyCommentByIDAsync(commentId, replyId);

            if (response is SuccessResponse<string> successResponse)
            {
                if (string.IsNullOrEmpty(successResponse.Data))
                {
                    return (null, string.Empty);
                }

                var jsonObject = JsonConvert.DeserializeObject<dynamic>(successResponse.Data);

                var result = new Comment();
                if (jsonObject.data != null)
                {
                    var jsonData = jsonObject.data.ToObject<Dictionary<string, object>>();
                    result = Comment.FromDictionary(jsonData);
                    return (result, string.Empty);
                }
                else
                {
                    return (null, "Reply comment not found");
                }
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }

        public async Task<(List<Post>, string)> GetRecentsAsync(int page = 1, int limit = 10)
        {
            var response = await _postRepository.GetRecentsAsync(page, limit);

            if (response is SuccessResponse<string> successResponse)
            {
                if (string.IsNullOrEmpty(successResponse.Data))
                {
                    return (new List<Post>(), string.Empty);
                }

                var posts = await Post.ParsePostListAsync(successResponse.Data);
                return (posts, string.Empty);
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }

        public async Task<(List<Post>, string)> GetPostsByUserAsync(string userId)
        {
            var response = await _postRepository.GetPostsByUserAsync(userId);

            if (response is SuccessResponse<string> successResponse)
            {
                if (string.IsNullOrEmpty(successResponse.Data))
                {
                    return (new List<Post>(), string.Empty);
                }

                var posts = await Post.ParsePostListAsync(successResponse.Data);
                return (posts, string.Empty);
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }

        public async Task<(List<Comment>, string)> GetCommentsByPostIDAsync(string postId)
        {
            try
            {
                var response = await _postRepository.GetCommentsByPostIDAsync(postId);

                if (response is SuccessResponse<string> successResponse)
                {
                    var jsonObject = JsonConvert.DeserializeObject<dynamic>(successResponse.Data);
                    var commentsData = jsonObject.ToObject<Dictionary<string, object>>();
                    var list = DictionaryConverter.ParseCommentList(commentsData, "data");
                    return (list, string.Empty);
                }

                if (response is ErrorResponse<string> errorResponse)
                {
                    return (null, errorResponse.Message);
                }

                return (null, "Unknown error");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        //  Interactions
        public async Task<(bool, string)> LikePostAsync(string postId)
        {
            var response = await _postRepository.LikePostAsync(postId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error liking post");
        }

        public async Task<(bool, string)> UnlikePostAsync(string postId)
        {
            var response = await _postRepository.UnlikePostAsync(postId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error unliking post");
        }

        public async Task<(bool, string)> LikeCommentAsync(string commentId)
        {
            var response = await _postRepository.LikeCommentAsync(commentId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error liking comment");
        }

        public async Task<(bool, string)> UnlikeCommentAsync(string commentId)
        {
            var response = await _postRepository.UnlikeCommentAsync(commentId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error unliking comment");
        }

        public async Task<(bool, string)> LikeReplyCommentAsync(string commentId, string replyId)
        {
            var response = await _postRepository.LikeReplyCommentAsync(commentId, replyId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error liking reply comment");
        }

        public async Task<(bool, string)> UnlikeReplyCommentAsync(string commentId, string replyId)
        {
            var response = await _postRepository.UnlikeReplyCommentAsync(commentId, replyId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error unliking reply comment");
        }

        // Upload medias
        public async Task<(bool, string)> UploadPostMediasAsync(string postId, string textToSpeech, IEnumerable<string> photoPaths)
        {
            var response = await _postRepository.UploadPostMediasAsync(postId, textToSpeech, photoPaths);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error uploading medias");
        }

        public async Task<(bool, string)> UploadCommentMediasAsync(string commentId, string textToSpeech, IEnumerable<string> photoPaths)
        {
            var response = await _postRepository.UploadCommentMediasAsync(commentId, textToSpeech, photoPaths);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error uploading comment medias");
        }

        public async Task<(bool, string)> UploadReplyCommentMediasAsync(string commentId, string replyId, string textToSpeech, IEnumerable<string> photoPaths)
        {
            var response = await _postRepository.UploadReplyCommentMediasAsync(commentId, replyId, textToSpeech, photoPaths);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error uploading reply comment medias");
        }

        // Delete medias
        public async Task<(bool, string)> DeletePostMediaDataAsync(string postId)
        {
            var response = await _postRepository.DeletePostMediaDataAsync(postId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            else if (response is ErrorResponse<string> errorResponse)
            {
                return (false, errorResponse.Message);
            }
            return (false, "Error delete post medias");
        }

        public async Task<(bool, string)> DeleteCommentMediaDataAsync(string commentId)
        {
            var response = await _postRepository.DeleteCommentMediaDataAsync(commentId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error deleting comment medias");
        }

        public async Task<(bool, string)> DeleteReplyCommentMediaDataAsync(string commentId, string replyId)
        {
            var response = await _postRepository.DeleteReplyCommentMediaDataAsync(commentId, replyId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error deleting reply comment medias");
        }
    }
}
