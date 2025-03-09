using System;
using System.Collections.Generic;
using System.Linq;
using DTO.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DTO
{
    public class Comment
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("replyFor")]
        public string ReplyFor { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("voice")]
        public string Voice { get; set; }

        [JsonProperty("images")]
        public List<ImageModel> Images { get; set; } = new List<ImageModel>();

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("likedBy")]
        public List<string> LikedBy { get; set; } = new List<string>();

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("replies")]
        public List<Comment> Replies { get; set; } = new List<Comment>();

        [JsonProperty("createdBy")]
        public UserSummary Author { get; set; }

        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                { "_id", Id },
                { "replyFor", ReplyFor },
                { "text", Text },
                { "voice", Voice },
                { "images", Images.ConvertAll(img => img.ToDictionary()) },
                { "createdAt", CreatedAt },
                { "updatedAt", UpdatedAt },
                { "likedBy", LikedBy },
                { "status", Status },
                { "replies", Replies.ConvertAll(reply => reply.ToDictionary()) },
                { "createdBy", Author?.ToDictionary() }
            };
        }

        public static Comment FromDictionary(Dictionary<string, object> data)
        {
            var comment = new Comment
            {
                Id = DictionaryConverter.GetValueOrDefault(data, "_id", string.Empty),
                ReplyFor = DictionaryConverter.GetValueOrDefault(data, "replyFor", string.Empty),
                Text = DictionaryConverter.GetValueOrDefault(data, "text", string.Empty),
                Voice = DictionaryConverter.GetValueOrDefault(data, "voice", string.Empty),
                Images = DictionaryConverter.ParseImageModelList(data, "images"),
                CreatedAt = DictionaryConverter.ParseDateTime(data, "createdAt", DateTime.MinValue),
                UpdatedAt = DictionaryConverter.ParseDateTime(data, "updatedAt", DateTime.MinValue),
                LikedBy = DictionaryConverter.ParseStringList(data, "likedBy"),
                Status = DictionaryConverter.GetValueOrDefault(data, "status", string.Empty),
                Replies = DictionaryConverter.ParseCommentList(data, "replies"),
                Author = DictionaryConverter.ParseUserSummary(data, "createdBy"),
            };

            return comment;
        }

    }
    
}
