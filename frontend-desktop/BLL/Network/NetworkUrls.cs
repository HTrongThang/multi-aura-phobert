using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Network
{
    public static class NetworkUrls
    {
        public static string BaseUrl { get; private set; }

        public static AuthUrls Auth { get; private set; }
        public static RelationshipsUrls Relationships { get; private set; }
        public static ConversationUrls Conversation { get; private set; }
        public static PostUrls Post { get; private set; }
        public static SearchUrls Search { get; private set; }
        public static UploadUrls Upload { get; private set; }

        static NetworkUrls()
        {
            string environment = Environment.GetEnvironmentVariable("ENV") ?? "DEV";

            BaseUrl = environment == "PROD"
                ? "https://prod-api.example.com"
                : "http://localhost:3000";

            Auth = new AuthUrls();
            Relationships = new RelationshipsUrls();
            Conversation = new ConversationUrls();
            Post = new PostUrls();
            Search = new SearchUrls();
            Upload = new UploadUrls();
        }

        public class AuthUrls
        {
            private readonly string _Route = $"{BaseUrl}/user";

            public string Login => $"{_Route}/login";
            public string Register => $"{_Route}/register";
            public string Logout => $"{_Route}/logout";
            public string Delete => $"{_Route}/delete";
            public string Update => $"{_Route}/update";
        }

        public class RelationshipsUrls
        {
            private readonly string _Route = $"{BaseUrl}/relationships";

            //Get
            public string GetProfile => $"{BaseUrl}";
            public string AuthProfile => $"{BaseUrl}/auth/profile";
            public string GetFriends => $"{_Route}/friends";
            public string GetFollowers => $"{_Route}/followers";
            public string GetFollowing => $"{_Route}/followings";
            public string GetBlockedUsers => $"{_Route}/blocked";
            public string GetRelationshipStatus => $"{_Route}/status";

            //Action
            public string Follow => $"{_Route}/follow";
            public string UnFollow => $"{_Route}/unfollow";
            public string Block => $"{_Route}/block";
            public string UnBlock => $"{_Route}/unblock";
        }

        public class ConversationUrls
        {
            private readonly string _Route = $"{BaseUrl}/conversation";

            public string GetMessages => $"{_Route}/messages";
            public string SendMessage => $"{_Route}/send";
            public string DeleteMessage => $"{_Route}/delete";
        }

        public class PostUrls
        {
            private readonly string _Route = $"{BaseUrl}/post";

            //CRUD
            public string CreatePost => $"{_Route}/create";
            public string DeletePost => $"{_Route}/delete";


            //Get
            public string GetPostByID => $"{_Route}";
            public string GetRecentPosts => $"{_Route}/recents";
            public string GetPostsByUser => $"{_Route}/user";

            //Comments
            public string GetCommentsByPostID => $"{_Route}/comments";
            public string GetCommentByID => $"{_Route}/comment";
            public string CreateComment => $"{_Route}/add-comment";
            public string DeleteComment => $"{_Route}/delete-comment";

            //Reply Comments
            public string GetReplyCommentByID => $"{_Route}/reply";
            public string AddReplyToComment => $"{_Route}/add-reply";
            public string DeleteReplyFromComment => $"{_Route}/delete-reply";

            //Interactions
            //Like
            public string LikePost => $"{_Route}/like";
            public string LikeComment => $"{_Route}/comment/like";
            public string LikeReplyComment => $"{_Route}/reply/like";

            //Unlike
            public string UnlikePost => $"{_Route}/unlike";
            public string UnlikeComment => $"{_Route}/comment/unlike";
            public string UnlikeReplyComment => $"{_Route}/reply/unlike";
        }

        public class SearchUrls
        {
            private readonly string _Route = $"{BaseUrl}/search";

            public string SearchPeople => $"{_Route}/people";
            public string SearchPosts => $"{_Route}/posts";
            public string SearchNews => $"{_Route}/news";
            public string SearchTrending => $"{_Route}/trending";
            public string SearchForYou => $"{_Route}/for-you";
        }

        public class UploadUrls
        {
            private readonly string _Route = $"{BaseUrl}/upload";

            public string ProfilePhoto => $"{_Route}/profile-photo";

            // Medias
            public string PostMedias => $"{_Route}/post/medias";
            public string CommentMedias => $"{_Route}/comment/medias";
            public string ReplyCommentMedias => $"{_Route}/reply/medias";
        }
    }
}
