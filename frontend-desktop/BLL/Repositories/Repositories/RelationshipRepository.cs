using BLL.Network;
using BLL.Repositories.IRepositories;
using BLL.Repositories.Repositories;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class RelationshipRepository : BaseRepository, IRelationshipRepository
    {
        private static RelationshipRepository instance;
        private static readonly object padlock = new object();
        public static RelationshipRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new RelationshipRepository();
                    }
                    return instance;
                }
            }
        }

        private RelationshipRepository() : base()
        {
        }

        // Get Methods
        public async Task<APIResponse<string>> GetProfileAsync(string username = "")
        {
            string url = !string.IsNullOrWhiteSpace(username)
                ? $"{NetworkUrls.Relationships.GetProfile}/{username}"
                : NetworkUrls.Relationships.AuthProfile;
            return await GetAsync(url);
        }

        public async Task<APIResponse<string>> GetFriendsAsync()
        {
            return await GetAsync(NetworkUrls.Relationships.GetFriends);
        }

        public async Task<APIResponse<string>> GetFollowersAsync()
        {
            return await GetAsync(NetworkUrls.Relationships.GetFollowers);
        }

        public async Task<APIResponse<string>> GetFollowingsAsync()
        {
            return await GetAsync(NetworkUrls.Relationships.GetFollowing);
        }

        public async Task<APIResponse<string>> GetBlockedUsersAsync()
        {
            return await GetAsync(NetworkUrls.Relationships.GetBlockedUsers);
        }

        public async Task<APIResponse<string>> GetRelationshipStatusAsync(string userId)
        {
            string url = $"{NetworkUrls.Relationships.GetRelationshipStatus}/{userId}";
            return await PostAsync(url);
        }

        // Action Methods
        public async Task<APIResponse<string>> FollowUserAsync(string userId)
        {
            string url = $"{NetworkUrls.Relationships.Follow}/{userId}";
            return await PostAsync(url);
        }

        public async Task<APIResponse<string>> UnfollowUserAsync(string userId)
        {
            string url = $"{NetworkUrls.Relationships.UnFollow}/{userId}";
            return await DeleteAsync(url);
        }

        public async Task<APIResponse<string>> BlockUserAsync(string userId)
        {
            string url = $"{NetworkUrls.Relationships.Block}/{userId}";
            return await PostAsync(url);
        }

        public async Task<APIResponse<string>> UnblockUserAsync(string userId)
        {
            string url = $"{NetworkUrls.Relationships.UnBlock}/{userId}";
            return await DeleteAsync(url);
        }
    }
}
