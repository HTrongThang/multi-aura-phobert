using BLL.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Repositories.IRepositories
{
    public interface IPostRepository
    {
        //CRUD
        //Post
        Task<APIResponse<string>> CreatePostAsync(string description);
        Task<APIResponse<string>> DeletePostAsync(string postId);

        //Comment
        Task<APIResponse<string>> CreateCommentAsync(string postId, string text);
        Task<APIResponse<string>> DeleteCommentAsync(string commentId);

        //Reply comment
        Task<APIResponse<string>> CreateReplyCommentAsync(string commentId, string text);
        Task<APIResponse<string>> DeletReplyCommentAsync(string commentId, string replyId);

        //GET
        Task<APIResponse<string>> GetPostsByIdAsync(string postId);
        Task<APIResponse<string>> GetRecentsAsync(int page, int limit);
        Task<APIResponse<string>> GetPostsByUserAsync(string userId);
        Task<APIResponse<string>> GetCommentsByPostIDAsync(string postId);
        Task<APIResponse<string>> GetCommentByIDAsync(string commentId);
        Task<APIResponse<string>> GetReplyCommentByIDAsync(string commentId, string replyId);

        //Interactions
        Task<APIResponse<string>> LikePostAsync(string postId);
        Task<APIResponse<string>> UnlikePostAsync(string postId);
        Task<APIResponse<string>> LikeCommentAsync(string commentId);
        Task<APIResponse<string>> UnlikeCommentAsync(string commentId);
        Task<APIResponse<string>> LikeReplyCommentAsync(string commentId, string replyId);
        Task<APIResponse<string>> UnlikeReplyCommentAsync(string commentId, string replyId);

        //Upload medias
        Task<APIResponse<string>> UploadPostMediasAsync(string postId, string textToSpeech, IEnumerable<string> photoPaths);
        Task<APIResponse<string>> UploadCommentMediasAsync(string commentId, string textToSpeech, IEnumerable<string> photoPaths);
        Task<APIResponse<string>> UploadReplyCommentMediasAsync(string commentId, string replyId, string textToSpeech, IEnumerable<string> photoPaths);

        //Delete medias
        Task<APIResponse<string>> DeletePostMediaDataAsync(string postId);
        Task<APIResponse<string>> DeleteCommentMediaDataAsync(string commentId);
        Task<APIResponse<string>> DeleteReplyCommentMediaDataAsync(string commentId, string replyId);
    }
}
