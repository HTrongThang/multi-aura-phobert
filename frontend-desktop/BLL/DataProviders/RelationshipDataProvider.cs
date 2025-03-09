using BLL.Repository;
using BLL.Services;
using DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.DataProviders
{
    public class RelationshipDataProvider
    {
        private static RelationshipDataProvider instance;
        private static readonly object padlock = new object();
        public static RelationshipDataProvider Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new RelationshipDataProvider();
                    }
                    return instance;
                }
            }
        }

        private AppDataProvider appDataProvider = AppDataProvider.Instance;
        private SearchDataProvider searchDataProvider;

        private RelationshipRepository relationshipRepository;
        private RelationshipService relationshipService;

        private List<UserSummary> suggestedFriends = null;
        public List<UserSummary> SuggestedFriends
        {
            get => suggestedFriends;
        }

        private List<UserSummary> followers = null;
        public List<UserSummary> Followers
        {
            get => followers;
        }

        private List<UserSummary> followings = null;
        public List<UserSummary> Followings
        {
            get => followings;
        }

        private List<UserSummary> friends = null;
        public List<UserSummary> Friends
        {
            get => friends;
        }

        private List<UserSummary> blockedList = null;
        public List<UserSummary> BlockedList
        {
            get => blockedList;
        }

        private UserProfile otherProfile = null;
        public UserProfile OtherProfile
        {
            get => otherProfile;
        }

        public event Action FriendDataLoaded;
        public event Action BlockedDataLoaded;
        public event Action SuggestDataLoaded;
        public event Action FollowerDataLoaded;
        public event Action FollowingDataLoaded;

        public event Action<string> OnFollowEvent;
        public event Action<string> OnUnfollowEvent; 
        public event Action<string> OnBlockEvent;
        public event Action<string> OnUnblockEvent;

        public event Action OnGetOtherProfileSuccess;

        public event Action RequestReloadByBlockEvent;

        private RelationshipDataProvider()
        {
            searchDataProvider = SearchDataProvider.Instance;

            relationshipRepository = RelationshipRepository.Instance;
            relationshipService = new RelationshipService(relationshipRepository);

            appDataProvider.DataLoaded += Initialize;
        }

        public void Initialize()
        {
            searchDataProvider = SearchDataProvider.Instance;

            relationshipRepository = RelationshipRepository.Instance;
            relationshipService = new RelationshipService(relationshipRepository);

            FetchUserFriends();
            FetchSuggestedFriends();
            FetchFollowers();
            FetchFollowings();
            FetchBlockedList();
        }

        public void RefetchUserProfile()
        {
            FetchUserFriends();
            FetchFollowers();
            FetchFollowings();
            FetchBlockedList();
        }

        public async void GetProfileDetails(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var (profile, errorMessage) = await GetProfileAsync(username);

                if (string.IsNullOrEmpty(errorMessage))
                {
                    otherProfile = profile;
                    OnGetOtherProfileSuccess?.Invoke();
                }
                else
                {
                    MessageBox.Show("Error fetching other profile: " + errorMessage);
                }
            }

        }

        public async void FetchUserFriends()
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (list, errorMessage) = await relationshipService.GetFriendsAsync();

                if (string.IsNullOrEmpty(errorMessage))
                {
                    this.friends = list;
                    FriendDataLoaded?.Invoke(); // Gọi sự kiện khi dữ liệu đã tải xong
                }
                else
                {
                    MessageBox.Show("Error fetching friends: " + errorMessage);
                }
            }
        }

        public async void FetchBlockedList()
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (list, errorMessage) = await relationshipService.GetBlockedUsersAsync();

                if (string.IsNullOrEmpty(errorMessage))
                {
                    this.blockedList = list;
                    BlockedDataLoaded?.Invoke();
                }
                else
                {
                    MessageBox.Show("Error fetching blocked list: " + errorMessage);
                }
            }
        }
        public async void FetchSuggestedFriends()
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (list, errorMessage) = await searchDataProvider.SearchSuggestedPeople();

                if (string.IsNullOrEmpty(errorMessage))
                {
                    this.suggestedFriends = list;
                    SuggestDataLoaded?.Invoke();
                }
                else
                {
                    MessageBox.Show("Error fetching suggested friends: " + errorMessage);
                }
            }
        }

        public async Task<(List<UserSummary>, string)> FetchSuggestedUsers(int page = 1, int limit = 10)
        {
            try
            {
                if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
                {
                    var (list, errorMessage) = await searchDataProvider.SearchSuggestedPeople(page, limit);

                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        return (list, errorMessage);
                    }
                    else
                    {
                        MessageBox.Show("Error fetching suggested friends: " + errorMessage);
                        return (new List<UserSummary>(), errorMessage);
                    }
                }
            }
            catch (Exception ex) {
                return(new List<UserSummary>(), ex.Message);
            }
            return (new List<UserSummary>(), "Unkown error");
        }


        private async void FetchFollowers()
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (list, errorMessage) = await relationshipService.GetFollowersAsync();

                if (string.IsNullOrEmpty(errorMessage))
                {
                    this.followers = list;
                    FollowerDataLoaded?.Invoke();
                }
                else
                {
                    MessageBox.Show("Error fetching followers: " + errorMessage);
                }
            }
        }

        private async void FetchFollowings()
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (list, errorMessage) = await relationshipService.GetFollowingsAsync();

                if (string.IsNullOrEmpty(errorMessage))
                {
                    this.followings = list;
                    FollowingDataLoaded?.Invoke();
                }
                else
                {
                    MessageBox.Show("Error fetching followings: " + errorMessage);
                }
            }
        }

        public async Task<(UserProfile, string)> GetProfileAsync(string username = "")
        {
            try
            {
                var result = await relationshipService.GetProfileAsync(username);
                if (!string.IsNullOrEmpty(result.Item2))
                {
                    throw new Exception(result.Item2);  // Lỗi khi lấy profile
                }
                return result;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine($"Error fetching profile: {ex.Message}");
                return (null, ex.Message);
            }
        }

        public async Task<(User, string)> GetAuthProfileAsync()
        {
            try
            {
                var result = await relationshipService.GetAuthProfileAsync();
                if (!string.IsNullOrEmpty(result.Item2))
                {
                    throw new Exception(result.Item2);  // Lỗi khi lấy profile
                }
                return result;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine($"Error fetching profile: {ex.Message}");
                return (null, ex.Message);
            }
        }

        public async Task<(bool, RelationshipStatus)> Follow(UserSummary user, RelationshipStatus relationshipStatus = null)
        {
            if (user == null && string.IsNullOrEmpty(user.UserID))
            {
                return (false, relationshipStatus);
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (result, errorMessage) = await relationshipService.FollowUserAsync(user.UserID);

                if (!result)
                {
                    MessageBox.Show($"Follow failed: {errorMessage}");
                }
                else
                {
                    if (this.followings == null)
                    {
                        this.followings = new List<UserSummary>();
                    }
                    this.followings.Add(user);
                    FollowingDataLoaded?.Invoke();
                    (relationshipStatus, _) = await relationshipService.GetRelationshipStatusAsync(user.UserID);

                    if (relationshipStatus != null && relationshipStatus.Status != null && relationshipStatus.Status == RelationshipStatusType.Follower)
                    {
                        if (this.friends == null)
                        {
                            this.friends = new List<UserSummary>();
                        }
                        this.friends.Add(user);
                        FriendDataLoaded?.Invoke();
                    }

                    OnFollowEvent?.Invoke(user.UserID);
                }
                
                return (result, relationshipStatus);
            }
            return (false, relationshipStatus);
        }

        public async Task<(bool, RelationshipStatus)> Unfollow(UserSummary user, RelationshipStatus relationshipStatus = null)
        {
            if (user == null && string.IsNullOrEmpty(user.UserID))
            {
                return (false, relationshipStatus);
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (result, errorMessage) = await relationshipService.UnfollowUserAsync(user.UserID);
                
                if (!result)
                {
                    MessageBox.Show($"Unfollow failed: {errorMessage}");
                }
                else
                {
                    if (this.followings != null)
                    {
                        this.followings.RemoveAll(f => f.UserID == user.UserID);
                        FollowingDataLoaded?.Invoke();
                    }

                    (relationshipStatus, _) = await relationshipService.GetRelationshipStatusAsync(user.UserID);

                    if (relationshipStatus != null && relationshipStatus.Status != null && relationshipStatus.Status == RelationshipStatusType.Friend)
                    {
                        if (this.friends != null)
                        {
                            this.friends.RemoveAll(f => f.UserID == user.UserID);
                            FriendDataLoaded?.Invoke();
                        }
                    }

                    OnUnfollowEvent?.Invoke(user.UserID);
                }

                return (result, relationshipStatus);
            }
            return (false, relationshipStatus);
        }

        public async Task<(bool, RelationshipStatus)> Block(UserSummary user, RelationshipStatus relationshipStatus = null)
        {
            if (user == null && string.IsNullOrEmpty(user.UserID))
            {
                return (false, relationshipStatus);
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                if(relationshipStatus == null)
                {
                    (relationshipStatus, _) = await relationshipService.GetRelationshipStatusAsync(user.UserID);
                }

                var (result, errorMessage) = await relationshipService.BlockUserAsync(user.UserID);

                if (!result)
                {
                    MessageBox.Show($"Block failed: {errorMessage}");
                }
                else
                {
                    if (relationshipStatus != null && relationshipStatus.Status != null)
                    {
                        if (relationshipStatus.Status == RelationshipStatusType.Friend)
                        {
                            if (this.friends != null)
                            {
                                this.friends.RemoveAll(f => f.UserID == user.UserID);
                                FriendDataLoaded?.Invoke();
                            }

                            if (this.followings != null)
                            {
                                this.followings.RemoveAll(f => f.UserID == user.UserID);
                                FollowingDataLoaded?.Invoke();
                            }

                            if (this.followers != null)
                            {
                                this.followers.RemoveAll(f => f.UserID == user.UserID);
                                FollowerDataLoaded?.Invoke();
                            }
                        }
                        else if (relationshipStatus.Status == RelationshipStatusType.Following)
                        {
                            if (this.followings != null)
                            {
                                this.followings.RemoveAll(f => f.UserID == user.UserID);
                                FollowingDataLoaded?.Invoke();
                            }
                        }
                        else if (relationshipStatus.Status == RelationshipStatusType.Follower)
                        {
                            if (this.followers != null)
                            {
                                this.followers.RemoveAll(f => f.UserID == user.UserID);
                                FollowerDataLoaded?.Invoke();
                            }
                        }

                        //searchDataProvider.Search(searchDataProvider.Query, 1, 10);
                        RequestReloadByBlockEvent?.Invoke();
                    }
                    relationshipStatus.Status = RelationshipStatusType.Blocking;

                    if (this.blockedList == null)
                    {
                        this.blockedList = new List<UserSummary>();
                    }

                    this.blockedList.Add(user);
                    BlockedDataLoaded?.Invoke();

                    OnBlockEvent?.Invoke(user.UserID);
                }

                return (result, relationshipStatus);
            }
            return (false, relationshipStatus);
        }

        public async Task<(bool, RelationshipStatus)> Unblock(UserSummary user, RelationshipStatus relationshipStatus = null)
        {
            if (user == null && string.IsNullOrEmpty(user.UserID))
            {
                return (false, relationshipStatus);
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (result, errorMessage) = await relationshipService.UnblockUserAsync(user.UserID);

                if (!result)
                {
                    MessageBox.Show($"Unblock failed: {errorMessage}");
                }
                else
                {
                    (relationshipStatus, _) = await relationshipService.GetRelationshipStatusAsync(user.UserID);

                    if(relationshipStatus != null && relationshipStatus.Status != null)
                    {
                        if (relationshipStatus.Status == RelationshipStatusType.Friend)
                        {
                            if (this.friends == null)
                            {
                                this.friends = new List<UserSummary>();
                            }
                            this.friends.Add(user);
                            FriendDataLoaded?.Invoke();

                            if (this.followings == null)
                            {
                                this.followings = new List<UserSummary>();
                            }
                            this.followings.Add(user);
                            FollowingDataLoaded?.Invoke();

                            if (this.followers == null)
                            {
                                this.followers = new List<UserSummary>();
                            }
                            this.followers.Add(user);
                            FollowerDataLoaded?.Invoke();
                        }
                        else if (relationshipStatus.Status == RelationshipStatusType.Following)
                        {
                            if (this.followings == null)
                            {
                                this.followings = new List<UserSummary>();
                            }
                            this.followings.Add(user);
                            FollowingDataLoaded?.Invoke();
                        }
                        else if (relationshipStatus.Status == RelationshipStatusType.Follower)
                        {
                            if (this.followers == null)
                            {
                                this.followers = new List<UserSummary>();
                            }
                            this.followers.Add(user);
                            FollowerDataLoaded?.Invoke();
                        }

                        searchDataProvider.Search(searchDataProvider.Query, 1, 10);
                    }

                    if (this.blockedList != null)
                    {
                        this.blockedList.RemoveAll(f => f.UserID == user.UserID);
                        BlockedDataLoaded?.Invoke();
                    }

                    OnUnblockEvent?.Invoke(user.UserID);
                }

                return (result, relationshipStatus);
            }
            return (false, relationshipStatus);
        }
    }
}
