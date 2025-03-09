using BLL.Network;
using System.Threading.Tasks;

namespace BLL.Repositories.IRepositories
{
    public interface IRelationshipRepository
    {
        // Get methods
        //Task<APIResponse<string>> GetProfileAsync();
        Task<APIResponse<string>> GetProfileAsync(string username = "");
        Task<APIResponse<string>> GetFriendsAsync();
        Task<APIResponse<string>> GetFollowersAsync();
        Task<APIResponse<string>> GetFollowingsAsync();
        Task<APIResponse<string>> GetBlockedUsersAsync();
        Task<APIResponse<string>> GetRelationshipStatusAsync(string userId);

        // Action methods
        Task<APIResponse<string>> FollowUserAsync(string userId);
        Task<APIResponse<string>> UnfollowUserAsync(string userId);
        Task<APIResponse<string>> BlockUserAsync(string userId);
        Task<APIResponse<string>> UnblockUserAsync(string userId);
    }
}
