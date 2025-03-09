using BLL.Repository;
using BLL.Services;
using DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.DataProviders
{
    public class PostDataProvider
    {
        private static PostDataProvider instance;
        private static readonly object padlock = new object();
        public static PostDataProvider Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PostDataProvider();
                    }
                    return instance;
                }
            }
        }

        private AppDataProvider appDataProvider = AppDataProvider.Instance;
        private RelationshipDataProvider relationshipDataProvider;

        private PostRepository postRepository;
        private PostService postService;

        private List<Post> recentPosts = null;
        public List<Post> RecentPosts
        {
            get => recentPosts;
        }

        public event Action RecentPostsDataLoaded;

        private List<Post> currentUserPosts = null;
        public List<Post> CurrentUserPosts
        {
            get => currentUserPosts;
        }

        public event Action CurrentUserPostsDataLoaded;

        //private string curentPostId = null;
        private List<Comment> commentsOfCurrentPost = null;
        public List<Comment> CommentsOfCurrentPost
        {
            get => commentsOfCurrentPost;
        }

        public event Action CommentsOfCurrentPostDataLoaded;

        private List<Post> otherUserPosts = null;
        public List<Post> OtherUserPosts
        {
            get => otherUserPosts;
        }

        public event Action OtherUserPostsDataLoaded;

        public event Action<string> OnLikePostSuccess;
        public event Action<string> OnUnlikePostSuccess;

        public event Action<string> OnLikeCommentSuccess;
        public event Action<string> OnUnlikeCommentSuccess;

        public event Action<string> OnLikeReplyCommentSuccess;
        public event Action<string> OnUnlikeReplyCommentSuccess;

        public event Action<string> OnDeletePostSuccess;
        public event Action<Post> OnCreatePostSuccess;

        public event Action<string> OnDeleteCommentSuccess;
        public event Action<Comment> OnCreateCommentSuccess;

        public event Action<string> OnDeleteReplyCommentSuccess;
        public event Action<Comment> OnCreateReplyCommentSuccess;

        private PostDataProvider()
        {
            postRepository = PostRepository.Instance;
            postService = new PostService(postRepository);

            appDataProvider.DataLoaded += Initialize;
        }

        public void Initialize()
        {
            relationshipDataProvider = RelationshipDataProvider.Instance;

            relationshipDataProvider.FollowingDataLoaded += FetchRecentPosts;
            AuthDataProvider.Instance.UserLoggedIn += FetchRecentPosts;
            FetchCurrentUserPosts();
        }

        public void FetchRecentPosts()
        {
            Task.Run(async () =>
            {
                try
                {
                    if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
                    {
                        var (list, errorMessage) = await postService.GetRecentsAsync(1, 10);

                        if (string.IsNullOrEmpty(errorMessage))
                        {
                            this.recentPosts = list;
                            RecentPostsDataLoaded?.Invoke();
                        }
                        else
                        {
                            MessageBox.Show("Error fetching recent posts: " + errorMessage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching recent posts: " + ex.Message);
                }
            });
        }

        public async void FetchCurrentUserPosts()
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token)
                && !string.IsNullOrEmpty(appDataProvider.User.UserID)
                )
            {
                var (list, errorMessage) = await postService.GetPostsByUserAsync(appDataProvider.User.UserID);

                if (string.IsNullOrEmpty(errorMessage))
                {
                    this.currentUserPosts = list;
                    CurrentUserPostsDataLoaded?.Invoke();
                }
                else
                {
                    MessageBox.Show("Error fetching current user posts: " + errorMessage);
                }
            }
        }

        public async Task<List<Post>> FetchOtherUserPosts(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var (list, errorMessage) = await postService.GetPostsByUserAsync(userId);

                if (string.IsNullOrEmpty(errorMessage))
                {
                    //this.otherUserPosts = list;
                    //OtherUserPostsDataLoaded?.Invoke();
                    return list;
                }
                else
                {
                    MessageBox.Show("Error fetching current user posts: " + errorMessage);
                }
            }
            return null;
        }

        public async void FetchCommentsOfCurrentPost(string postId)
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token)
                && !string.IsNullOrEmpty(postId)
                )
            {
                var (list, errorMessage) = await postService.GetCommentsByPostIDAsync(postId);

                if (string.IsNullOrEmpty(errorMessage))
                {
                    this.commentsOfCurrentPost = list;
                    CommentsOfCurrentPostDataLoaded?.Invoke();
                }
                else
                {
                    MessageBox.Show("Error fetching comments of current post: " + errorMessage);
                }
            }
        }

        //CRUD
        //Post
        public async Task<bool> CreatePostAsync(string description, string textToSpeech, IEnumerable<string> photoPaths)
        {
            if (string.IsNullOrEmpty(description))
            {
                return false;
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (post, errorMessage) = await postService.CreatePostAsync(description, textToSpeech, photoPaths);

                if (post == null)
                {
                    MessageBox.Show($"Create post failed: {errorMessage}");
                    return false;
                }
                OnCreatePostSuccess?.Invoke(post);
                return true;
            }
            return false;
        }

        public async Task<bool> DeletePostAsync(string postId)
        {
            if (string.IsNullOrEmpty(postId))
            {
                return false;
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (result, errorMessage) = await postService.DeletePostAsync(postId);

                if (!result)
                {
                    MessageBox.Show($"Delete failed: {errorMessage}");
                    return false;
                }
                OnDeletePostSuccess?.Invoke(postId);
                return result;
            }
            return false;
        }

        //Comment
        public async Task<Comment> CreateCommentAsync(string postId, string text, string textToSpeech, IEnumerable<string> photoPaths)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(postId))
            {
                return null;
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (result, errorMessage) = await postService.CreateCommentAsync(postId, text, textToSpeech, photoPaths);

                OnCreateCommentSuccess?.Invoke(result);
                return result;
            }
            return null;
        }

        public async Task<bool> DeleteCommentAsync(string commentId)
        {
            if (string.IsNullOrEmpty(commentId))
            {
                return false;
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (result, errorMessage) = await postService.DeleteCommentAsync(commentId);

                if (!result)
                {
                    MessageBox.Show($"Delete failed: {errorMessage}");
                    return false;
                }
                OnDeleteCommentSuccess?.Invoke(commentId);
                return result;
            }
            return false;
        }

        //Reply comment
        public async Task<Comment> CreateReplyCommentAsync(string commentId, string text, string textToSpeech, IEnumerable<string> photoPaths)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(commentId))
            {
                return null;
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (reply, errorMessage) = await postService.CreateReplyCommentAsync(commentId, text, textToSpeech, photoPaths);

                OnCreateReplyCommentSuccess?.Invoke(reply);
                return reply;
            }
            return null;
        }

        public async Task<bool> DeleteReplyCommentAsync(string commentId, string replyId)
        {
            if (string.IsNullOrEmpty(commentId) || string.IsNullOrEmpty(replyId))
            {
                return false;
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (result, errorMessage) = await postService.DeleteReplyCommentAsync(commentId, replyId);

                if (!result)
                {
                    MessageBox.Show($"Delete failed: {errorMessage}");
                    return false;
                }
                OnDeleteReplyCommentSuccess?.Invoke(replyId);
                return result;
            }
            return false;
        }

        //Interactions
        public async Task<bool> LikePostAsync(string postId)
        {
            if (string.IsNullOrEmpty(postId))
            {
                return false;
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (result, errorMessage) = await postService.LikePostAsync(postId);

                if (!result)
                {
                    MessageBox.Show($"Like failed: {errorMessage}");
                }
                else
                {
                    OnLikePostSuccess?.Invoke(postId);
                }
                return result;
            }
            return false;
        }

        public async Task<bool> UnlikePostAsync(string postId)
        {
            if (string.IsNullOrEmpty(postId))
            {
                return false;
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (result, errorMessage) = await postService.UnlikePostAsync(postId);

                if (!result)
                {
                    MessageBox.Show($"Unlike failed: {errorMessage}");
                }
                else
                {
                    OnUnlikePostSuccess?.Invoke(postId);
                }

                return result;
            }
            return false;
        }

        public async Task<bool> LikeCommentAsync(string commentId)
        {
            if (string.IsNullOrEmpty(commentId))
            {
                return false;
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (result, errorMessage) = await postService.LikeCommentAsync(commentId);

                if (!result)
                {
                    MessageBox.Show($"Like failed: {errorMessage}");
                }
                else
                {
                    OnLikeCommentSuccess?.Invoke(commentId);
                }

                return result;
            }
            return false;
        }

        public async Task<bool> UnlikeCommentAsync(string commentId)
        {
            if (string.IsNullOrEmpty(commentId))
            {
                return false;
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (result, errorMessage) = await postService.UnlikeCommentAsync(commentId);

                if (!result)
                {
                    MessageBox.Show($"Unlike failed: {errorMessage}");
                }
                else
                {
                    OnUnlikeCommentSuccess?.Invoke(commentId);
                }

                return result;
            }
            return false;
        }

        public async Task<bool> LikeReplyCommentAsync(string commentId, string replyId)
        {
            if (string.IsNullOrEmpty(commentId) || string.IsNullOrEmpty(replyId))
            {
                return false;
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (result, errorMessage) = await postService.LikeReplyCommentAsync(commentId, replyId);

                if (!result)
                {
                    MessageBox.Show($"Like failed: {errorMessage}");
                }
                else
                {
                    OnLikeReplyCommentSuccess?.Invoke(commentId);
                }

                return result;
            }
            return false;
        }

        public async Task<bool> UnlikeReplyCommentAsync(string commentId, string replyId)
        {
            if (string.IsNullOrEmpty(commentId) || string.IsNullOrEmpty(replyId))
            {
                return false;
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (result, errorMessage) = await postService.UnlikeReplyCommentAsync(commentId, replyId);

                if (!result)
                {
                    MessageBox.Show($"Unlike failed: {errorMessage}");
                }
                else
                {
                    OnUnlikeReplyCommentSuccess?.Invoke(commentId);
                }

                return result;
            }
            return false;
        }
    }
}
