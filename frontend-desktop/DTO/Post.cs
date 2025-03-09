using DTO.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO
{
    public class Post
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Content { get; set; }
        [JsonProperty("voice")]
        public string Voice { get; set; }

        [JsonProperty("createdBy")]
        public UserSummary Author { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; } = new List<Comment>();

        [JsonProperty("likedBy")]
        public List<UserSummary> LikedBy { get; set; } = new List<UserSummary>();

        [JsonProperty("images")]
        public List<ImageModel> Images { get; set; } = new List<ImageModel>();

        [JsonProperty("sharedBy")]
        public List<string> SharedBy { get; set; } = new List<string>();

        // Convert Post to Dictionary
        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                { "_id", Id },
                { "description", Content },
                { "voice", Voice },
                { "createdBy", Author?.ToDictionary() },
                { "createdAt", CreatedAt },
                { "updatedAt", UpdatedAt },
                { "status", Status },
                { "comments", Comments.ConvertAll(comment => comment.ToDictionary()) },
                { "likedBy", LikedBy.ConvertAll(user => user.ToDictionary()) },
                { "images", Images.ConvertAll(image => image.ToDictionary()) },
                { "sharedBy", SharedBy }
            };
        }

        public static Post FromDictionary(Dictionary<string, object> data)
        {
            var post = new Post
            {
                Id = DictionaryConverter.GetValueOrDefault(data, "_id", string.Empty),
                Content = DictionaryConverter.GetValueOrDefault(data, "description", string.Empty),
                Voice = DictionaryConverter.GetValueOrDefault(data, "voice", string.Empty),
                Author = DictionaryConverter.ParseUserSummary(data, "createdBy"),
                CreatedAt = DictionaryConverter.ParseDateTime(data, "createdAt", DateTime.MinValue),
                UpdatedAt = DictionaryConverter.ParseDateTime(data, "updatedAt", DateTime.MinValue),
                Status = DictionaryConverter.GetValueOrDefault(data, "status", string.Empty),
                Comments = DictionaryConverter.ParseCommentList(data, "comments"),
                LikedBy = DictionaryConverter.ParseUserSummaryList(data, "likedBy"),
                Images = DictionaryConverter.ParseImageModelList(data, "images"),
                SharedBy = DictionaryConverter.ParseStringList(data, "sharedBy")
            };

            return post;
        }

        public static async Task<List<Post>> ParsePostListAsync(string jsonData)
        {
            try
            {
                var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);
                var postList = new List<Post>();

                if (jsonObject.data != null)
                {
                    // Loop through each post item and create Post object
                    foreach (var item in jsonObject.data)
                    {
                        var postData = item.ToObject<Dictionary<string, object>>();
                        var post = Post.FromDictionary(postData);
                        postList.Add(post);
                    }
                }

                return postList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
                return new List<Post>();
            }
        }

    }
}
