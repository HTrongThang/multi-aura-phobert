using BLL.Network;
using BLL.Repositories.IRepositories;
using BLL.Repositories.Repositories;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        private static PostRepository instance;
        private static readonly object padlock = new object();
        public static PostRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PostRepository();
                    }
                    return instance;
                }
            }
        }

        private PostRepository() : base()
        {
        }
        //CRUD
        //Post
        public async Task<APIResponse<string>> CreatePostAsync(string description)
        {
            var requestBody = new
            {
                description = description
            };

            return await PostAsync(NetworkUrls.Post.CreatePost, requestBody);
        }

        public async Task<APIResponse<string>> DeletePostAsync(string postId)
        {
            string url = $"{NetworkUrls.Post.DeletePost}/{postId}";
            return await DeleteAsync(url);
        }

        //Comment
        public async Task<APIResponse<string>> CreateCommentAsync(string postId, string text)
        {
            var requestBody = new
            {
                text = text
            };
            string url = $"{NetworkUrls.Post.CreateComment}/{postId}";
            return await PostAsync(url, requestBody);
        }

        public async Task<APIResponse<string>> DeleteCommentAsync(string commentId)
        {
            string url = $"{NetworkUrls.Post.DeleteComment}/{commentId}";
            return await DeleteAsync(url);
        }

        //Reply comment
        public async Task<APIResponse<string>> CreateReplyCommentAsync(string commentId, string text)
        {
            var requestBody = new
            {
                text = text
            };
            string url = $"{NetworkUrls.Post.AddReplyToComment}/{commentId}";
            return await PostAsync(url, requestBody);
        }

        public async Task<APIResponse<string>> DeletReplyCommentAsync(string commentId, string replyId)
        {
            string url = $"{NetworkUrls.Post.DeleteReplyFromComment}/{commentId}/{replyId}";
            return await DeleteAsync(url);
        }
        
        //GET
        public async Task<APIResponse<string>> GetPostsByIdAsync(string postId)
        {
            string url = $"{NetworkUrls.Post.GetPostByID}/{postId}";
            return await GetAsync(url);
        }

        public async Task<APIResponse<string>> GetRecentsAsync(int page, int limit)
        {
            var requestBody = new
            {
                limit = limit,
                page = page
            };

            return await PostAsync(NetworkUrls.Post.GetRecentPosts, requestBody);
        }

        public async Task<APIResponse<string>> GetPostsByUserAsync(string userId)
        {
            string url = $"{NetworkUrls.Post.GetPostsByUser}/{userId}";
            return await PostAsync(url);
        }

        public async Task<APIResponse<string>> GetCommentsByPostIDAsync(string postId)
        {
            string url = $"{NetworkUrls.Post.GetCommentsByPostID}/{postId}";
            return await PostAsync(url);
        }

        public async Task<APIResponse<string>> GetCommentByIDAsync(string commentId)
        {
            string url = $"{NetworkUrls.Post.GetCommentByID}/{commentId}";
            return await GetAsync(url);
        }

        public async Task<APIResponse<string>> GetReplyCommentByIDAsync(string commentId, string replyId)
        {
            string url = $"{NetworkUrls.Post.GetReplyCommentByID}/{commentId}/{replyId}";
            return await GetAsync(url);
        }

        //Interactions
        public async Task<APIResponse<string>> LikePostAsync(string postId)
        {
            string url = $"{NetworkUrls.Post.LikePost}/{postId}";
            return await PostAsync(url);
        }

        public async Task<APIResponse<string>> UnlikePostAsync(string postId)
        {
            string url = $"{NetworkUrls.Post.UnlikePost}/{postId}";
            return await DeleteAsync(url);
        }

        public async Task<APIResponse<string>> LikeCommentAsync(string commentId)
        {
            string url = $"{NetworkUrls.Post.LikeComment}/{commentId}";
            return await PostAsync(url);
        }

        public async Task<APIResponse<string>> UnlikeCommentAsync(string commentId)
        {
            string url = $"{NetworkUrls.Post.UnlikeComment}/{commentId}";
            return await DeleteAsync(url);
        }

        public async Task<APIResponse<string>> LikeReplyCommentAsync(string commentId, string replyId)
        {
            string url = $"{NetworkUrls.Post.LikeReplyComment}/{commentId}/{replyId}";
            return await PostAsync(url);
        }

        public async Task<APIResponse<string>> UnlikeReplyCommentAsync(string commentId, string replyId)
        {
            string url = $"{NetworkUrls.Post.UnlikeReplyComment}/{commentId}/{replyId}";
            return await DeleteAsync(url);
        }

        //Upload medias
        public async Task<APIResponse<string>> UploadPostMediasAsync(string postId, string textToSpeech, IEnumerable<string> photoPaths)
        {
            string url = $"{NetworkUrls.Upload.PostMedias}/{postId}";

            using (var formData = new MultipartFormDataContent())
            {
                if (!string.IsNullOrEmpty(textToSpeech))
                {
                    formData.Add(new StringContent(textToSpeech), "text");
                }

                foreach (var photoPath in photoPaths)
                {
                    var fileContent = new ByteArrayContent(File.ReadAllBytes(photoPath));
                    fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                    formData.Add(fileContent, "photos", Path.GetFileName(photoPath));
                }

                return await PostAsync(url, formData, isFormData: true);
            }
        }

        public async Task<APIResponse<string>> UploadCommentMediasAsync(string commentId, string textToSpeech, IEnumerable<string> photoPaths)
        {
            string url = $"{NetworkUrls.Upload.CommentMedias}/{commentId}";

            using (var formData = new MultipartFormDataContent())
            {
                if (!string.IsNullOrEmpty(textToSpeech))
                {
                    formData.Add(new StringContent(textToSpeech), "text");
                }

                foreach (var photoPath in photoPaths)
                {
                    var fileContent = new ByteArrayContent(File.ReadAllBytes(photoPath));
                    fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                    formData.Add(fileContent, "photos", Path.GetFileName(photoPath));
                }

                return await PostAsync(url, formData, isFormData: true);
            }
        }

        public async Task<APIResponse<string>> UploadReplyCommentMediasAsync(string commentId, string replyId, string textToSpeech, IEnumerable<string> photoPaths)
        {
            string url = $"{NetworkUrls.Upload.ReplyCommentMedias}/{commentId}/{replyId}";

            using (var formData = new MultipartFormDataContent())
            {
                if (!string.IsNullOrEmpty(textToSpeech))
                {
                    formData.Add(new StringContent(textToSpeech), "text");
                }
                
                foreach (var photoPath in photoPaths)
                {
                    var fileContent = new ByteArrayContent(File.ReadAllBytes(photoPath));
                    fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                    formData.Add(fileContent, "photos", Path.GetFileName(photoPath));
                }

                return await PostAsync(url, formData, isFormData: true);
            }
        }

        //Delete medias
        public async Task<APIResponse<string>> DeletePostMediaDataAsync(string postId)
        {
            string url = $"{NetworkUrls.Upload.PostMedias}/{postId}";
            return await DeleteAsync(url);
        }

        public async Task<APIResponse<string>> DeleteCommentMediaDataAsync(string commentId)
        {
            string url = $"{NetworkUrls.Upload.CommentMedias}/{commentId}";
            return await DeleteAsync(url);
        }

        public async Task<APIResponse<string>> DeleteReplyCommentMediaDataAsync(string commentId, string replyId)
        {
            string url = $"{NetworkUrls.Upload.ReplyCommentMedias}/{commentId}/{replyId}";
            return await DeleteAsync(url);
        }
    }
}
