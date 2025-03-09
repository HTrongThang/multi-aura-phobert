using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO.Utils
{
    public static class DictionaryConverter
    {
        /// <summary>
        /// Lấy giá trị từ dictionary theo kiểu `T`, nếu không có trả về giá trị mặc định.
        /// </summary>
        public static T GetValueOrDefault<T>(Dictionary<string, object> data, string key, T defaultValue)
        {
            if (data.ContainsKey(key))
            {
                try
                {
                    // Thử ép kiểu giá trị sang kiểu `T`
                    return (T)Convert.ChangeType(data[key], typeof(T));
                }
                catch
                {
                    return defaultValue;
                }
            }
            return defaultValue;
        }

        /// <summary>
        /// Parse giá trị từ dictionary thành DateTime, nếu không thành công trả về giá trị mặc định.
        /// </summary>
        public static DateTime ParseDateTime(Dictionary<string, object> data, string key, DateTime defaultValue)
        {
            if (data.ContainsKey(key) && DateTime.TryParse(data[key]?.ToString(), out DateTime result))
            {
                return result;
            }
            return defaultValue;
        }

        /// <summary>
        /// Parse giá trị thành String List
        /// </summary>
        public static List<string> ParseStringList(Dictionary<string, object> data, string key)
        {
            if (data.ContainsKey(key) && data[key] is Newtonsoft.Json.Linq.JArray stringArray)
            {
                return stringArray.Select(item =>
                {
                    if (item is JValue jValue && jValue.Type == JTokenType.String)
                    {
                        return jValue.ToString();
                    }
                    return null;
                })
                .Where(str => str != null)
                .ToList();
            }
            return new List<string>();
        }

        /// <summary>
        /// Parse giá trị thành Comment List
        /// </summary>
        public static List<Comment> ParseCommentList(Dictionary<string, object> data, string key)
        {
            if (data.ContainsKey(key) && data[key] is Newtonsoft.Json.Linq.JArray commentsArray)
            {
                return commentsArray.Select(item =>
                {
                    if (item is JObject commentObject)
                    {
                        var commentDict = commentObject.ToObject<Dictionary<string, object>>();
                        return Comment.FromDictionary(commentDict);
                    }
                    return null;
                })
                .Where(comment => comment != null)
                .ToList();
            }
            return new List<Comment>();
        }

        /// <summary>
        /// Parse giá trị thành ImageModel List
        /// </summary>
        public static List<ImageModel> ParseImageModelList(Dictionary<string, object> data, string key)
        {
            if (data.ContainsKey(key) && data[key] is Newtonsoft.Json.Linq.JArray imagesArray)
            {
                return imagesArray.Select(item =>
                {
                    if (item is JObject imageObject)
                    {
                        var imageDict = imageObject.ToObject<Dictionary<string, object>>();
                        return ImageModel.FromDictionary(imageDict);
                    }
                    return null;
                })
                .Where(image => image != null)
                .ToList();
            }
            return new List<ImageModel>();
        }

        /// <summary>
        /// Lấy một đối tượng UserSummary từ Dictionary.
        /// </summary>
        /// <param name="data">Dictionary chứa dữ liệu</param>
        /// <param name="key">Key của đối tượng trong dictionary</param>
        /// <returns>Đối tượng UserSummary nếu tồn tại, ngược lại trả về null</returns>
        public static UserSummary ParseUserSummary(Dictionary<string, object> data, string key)
        {
            if (data.ContainsKey(key) && data[key] is JObject jObject)
            {
                return UserSummary.FromJObject(jObject);
            }
            return null;
        }

        public static List<UserSummary> ParseUserSummaryList(Dictionary<string, object> data, string key)
        {
            if (data.ContainsKey(key) && data[key] is Newtonsoft.Json.Linq.JArray array)
            {
                return array.Select(item =>
                {
                    if (item is JObject jObject)
                    {
                        var dictFromJObject = jObject.ToObject<Dictionary<string, object>>();
                        return UserSummary.FromDictionary(dictFromJObject);
                    }
                    return null;
                })
                .Where(user => user != null)
                .ToList();
            }

            return new List<UserSummary>();
        }

        public static RelationshipStatus ParseRelationshipStatus(Dictionary<string, object> data, string key)
        {
            if (data.ContainsKey(key) && data[key] is JObject relationshipStatusObject)
            {
                try
                {
                    var relationshipDict = relationshipStatusObject.ToObject<Dictionary<string, object>>();

                    if (relationshipDict.ContainsKey("status") && relationshipDict["status"] is string statusStr)
                    {
                        // Thay vì sử dụng Enum.TryParse, gọi hàm ParseRelationshipStatusType
                        RelationshipStatusType status = RelationshipStatus.ParseRelationshipStatusType(statusStr);

                        return new RelationshipStatus
                        {
                            Status = status,
                            Since = ParseDateTime(relationshipDict, "since", DateTime.Now)
                        };
                    }
                }
                catch
                {
                    return new RelationshipStatus
                    {
                        Status = RelationshipStatusType.NoRelationship,
                        Since = null
                    };
                }
            }

            return new RelationshipStatus
            {
                Status = RelationshipStatusType.NoRelationship,
                Since = null
            };
        }

    }
}
