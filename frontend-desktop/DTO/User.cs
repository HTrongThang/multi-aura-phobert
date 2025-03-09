using DTO.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DTO
{
    public class User
    {
        public string Token { get; set; }
        public string UserID { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Nation { get; set; }
        public string Province { get; set; }
        public string Avatar { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublic { get; set; }

        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                { "userID", UserID },
                { "fullname", FullName },
                { "username", Username },
                { "email", Email },
                { "password", Password },
                { "phone", PhoneNumber },
                { "birthday", Birthday.ToString("yyyy-MM-dd") },
                { "gender", Gender },
                { "nation", Nation },
                { "province", Province },
                { "avatar", Avatar },
                { "isAdmin", IsAdmin },
                { "isActive", IsActive },
                { "isPublic", IsPublic }
            };
        }

        public static User FromDictionary(Dictionary<string, object> data)
        {
            return new User
            {
                UserID = data.ContainsKey("userID") ? data["userID"] as string : string.Empty,
                FullName = data.ContainsKey("fullname") ? data["fullname"] as string : string.Empty,
                Username = data.ContainsKey("username") ? data["username"] as string : string.Empty,
                Email = data.ContainsKey("email") ? data["email"] as string : string.Empty,
                Password = data.ContainsKey("password") ? data["password"] as string : string.Empty,
                PhoneNumber = data.ContainsKey("phone") ? data["phone"] as string : string.Empty,
                Birthday = data.ContainsKey("birthday") && DateTime.TryParse(data["birthday"] as string, out DateTime birthday)
                    ? birthday
                    : DateTime.Now,
                Gender = data.ContainsKey("gender") ? data["gender"] as string : string.Empty,
                Nation = data.ContainsKey("nation") ? data["nation"] as string : string.Empty,
                Province = data.ContainsKey("province") ? data["province"] as string : string.Empty,
                Avatar = data.ContainsKey("avatar") ? data["avatar"] as string : string.Empty,
                IsAdmin = DictionaryConverter.GetValueOrDefault(data, "isAdmin", false),
                IsActive = DictionaryConverter.GetValueOrDefault(data, "isActive", false),
                IsPublic = DictionaryConverter.GetValueOrDefault(data, "isPublic", false),
            };
        }

    }

    public class RegisterRequest
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(3)]
        public string Password { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Birthday { get; set; }

        [Required]
        public string Gender { get; set; }

        public string Nation { get; set; }
        public string Province { get; set; }
    }

    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required, MinLength(3)]
        public string Password { get; set; }
    }

    public class UserSummary
    {
        public string UserID { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }
        public bool IsActive { get; set; }

        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                { "userID", UserID },
                { "fullname", FullName },
                { "username", Username },
                { "avatar", Avatar },
                { "isActive", IsActive },
            };
        }

        public static UserSummary FromDictionary(Dictionary<string, object> data)
        {
            return new UserSummary
            {
                UserID = DictionaryConverter.GetValueOrDefault(data, "userID", string.Empty),
                FullName = DictionaryConverter.GetValueOrDefault(data, "fullname", string.Empty),
                Username = DictionaryConverter.GetValueOrDefault(data, "username", string.Empty),
                Avatar = DictionaryConverter.GetValueOrDefault(data, "avatar", string.Empty),
                IsActive = DictionaryConverter.GetValueOrDefault(data, "isActive", false),
            };
        }

        public static UserSummary CopyFrom(User data)
        {
            return new UserSummary
            {
                UserID = data.UserID,
                FullName = data.FullName,
                Username = data.Username,
                Avatar = data.Avatar,
                IsActive = data.IsActive,
            };
        }

        public static UserSummary FromJObject(Newtonsoft.Json.Linq.JObject data)
        {
            var userSummary = new UserSummary
            {
                UserID = data.ContainsKey("userID") ? data["userID"]?.ToString() : string.Empty,
                FullName = data.ContainsKey("fullname") ? data["fullname"]?.ToString() : string.Empty,
                Username = data.ContainsKey("username") ? data["username"]?.ToString() : string.Empty,
                Avatar = data.ContainsKey("avatar") ? data["avatar"]?.ToString() : string.Empty,
                IsActive = data.ContainsKey("isActive") && bool.TryParse(data["isActive"]?.ToString(), out bool isActive) ? isActive : false
            };
            return userSummary;
        }

        public static async Task<(List<UserSummary>, string)> ParseUserSummaryListAsync(string jsonResponse)
        {
            try
            {
                // Parse JSON response thành Dictionary
                var jsonData = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonResponse);

                // Lấy phần "data" là danh sách user
                if (jsonData.ContainsKey("data") && jsonData["data"] is Newtonsoft.Json.Linq.JArray dataArray)
                {
                    var userList = new List<UserSummary>();

                    foreach (var item in dataArray)
                    {
                        var userDict = item.ToObject<Dictionary<string, object>>();
                        if (userDict != null)
                        {
                            // Tạo đối tượng UserSummary từ dictionary
                            var userSummary = UserSummary.FromDictionary(userDict);
                            userList.Add(userSummary);
                        }
                    }

                    return (userList, string.Empty);
                }

                return (null, "");
            }
            catch (Exception ex)
            {
                return (null, $"Error parsing response: {ex.Message}");
            }
        }
    }

    public class UserProfile
    {
        public User User { get; set; }
        public RelationshipStatus RelaStatus { get; set; }
        public List<UserSummary> Friends { get; set; }
        public List<UserSummary> Followings { get; set; }
        public List<UserSummary> Followers { get; set; }
        public List<UserSummary> MutualFollowings { get; set; }
        public List<UserSummary> MutualFriends { get; set; }
        public static UserProfile FromDictionary(Dictionary<string, object> data)
        {
            var userDict = new Dictionary<string, object>();

            if (data.ContainsKey("user"))
            {
                var user = data["user"];

                if (user is JObject jObject)
                {
                    // Nếu là JObject, chuyển thành Dictionary<string, object>
                    userDict = jObject.ToObject<Dictionary<string, object>>();
                }
                else if (user is Dictionary<string, object> dictionary)
                {
                    // Nếu đã là Dictionary<string, object>, chỉ cần gán trực tiếp
                    userDict = dictionary;
                }
            }

            return new UserProfile
            {
                //UserID = DictionaryConverter.GetValueOrDefault(userDict, "userID", string.Empty),
                //FullName = DictionaryConverter.GetValueOrDefault(userDict, "fullname", string.Empty),
                //Username = DictionaryConverter.GetValueOrDefault(userDict, "username", string.Empty),
                //Email = DictionaryConverter.GetValueOrDefault(userDict, "email", string.Empty),
                //Password = DictionaryConverter.GetValueOrDefault(userDict, "password", string.Empty),
                //PhoneNumber = DictionaryConverter.GetValueOrDefault(userDict, "phone", string.Empty),
                //Birthday = DictionaryConverter.ParseDateTime(userDict, "birthday", DateTime.Now),
                //Gender = DictionaryConverter.GetValueOrDefault(userDict, "gender", string.Empty),
                //Nation = DictionaryConverter.GetValueOrDefault(userDict, "nation", string.Empty),
                //Province = DictionaryConverter.GetValueOrDefault(userDict, "province", string.Empty),
                //Avatar = DictionaryConverter.GetValueOrDefault(userDict, "avatar", string.Empty),
                //IsAdmin = DictionaryConverter.GetValueOrDefault(userDict, "isAdmin", false),
                //IsActive = DictionaryConverter.GetValueOrDefault(userDict, "isActive", false),
                //IsPublic = DictionaryConverter.GetValueOrDefault(userDict, "isPublic", false),
                User = User.FromDictionary(userDict),
                //Parse RelationshipStatus
                RelaStatus = DictionaryConverter.ParseRelationshipStatus(data, "relationshipStatus"),

                // Parse Friends
                Friends = DictionaryConverter.ParseUserSummaryList(data, "friends"),

                // Parse Followings
                Followings = DictionaryConverter.ParseUserSummaryList(data, "followings"),

                // Parse Followers
                Followers = DictionaryConverter.ParseUserSummaryList(data, "followers"),

                // Parse MutualFollowings
                MutualFollowings = DictionaryConverter.ParseUserSummaryList(data, "mutualFollowings"),

                // Parse MutualFriends
                MutualFriends = DictionaryConverter.ParseUserSummaryList(data, "mutualFriends")
            };
        }
    }
}
