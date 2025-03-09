using BLL.DataProviders;
using BLL.Network;
using BLL.Repositories.IRepositories;
using BLL.Repository;
using DTO;
using DTO.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RelationshipService
    {
        private readonly IRelationshipRepository _relationshipRepository;

        public RelationshipService(IRelationshipRepository relationshipRepository)
        {
            _relationshipRepository = relationshipRepository;
        }

        // Get Methods
        public async Task<(UserProfile, string)> GetProfileAsync(string username)
        {
            var response = await _relationshipRepository.GetProfileAsync(username);

            // Kiểm tra nếu response là thành công
            if (response is SuccessResponse<string> successResponse)
            {
                try
                {
                    // Parse JSON thành JObject
                    var jsonData = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(successResponse.Data);

                    // Lấy phần "data" từ JSON response
                    var data = jsonData["data"] as Newtonsoft.Json.Linq.JObject;
                    var dataDict = data.ToObject<Dictionary<string, object>>();

                    if (dataDict != null)
                    {
                        // Parse thông tin user
                        var userProfile = UserProfile.FromDictionary(dataDict);

                        return (userProfile, string.Empty);
                    }

                    return (null, "Failed to parse user profile");
                }
                catch (Exception ex)
                {
                    return (null, $"Error parsing response: {ex.Message}");
                }
            }

            // Nếu là lỗi
            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }

        public async Task<(User, string)> GetAuthProfileAsync()
        {
            var response = await _relationshipRepository.GetProfileAsync();

            // Kiểm tra nếu response là thành công
            if (response is SuccessResponse<string> successResponse)
            {
                try
                {
                    // Parse JSON thành JObject
                    var jsonData = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(successResponse.Data);

                    // Lấy phần "data" từ JSON response
                    var data = jsonData["data"] as Newtonsoft.Json.Linq.JObject;
                    var dataDict = data.ToObject<Dictionary<string, object>>();

                    if (dataDict != null)
                    {
                        // Parse thông tin user
                        var userProfile = User.FromDictionary(dataDict);

                        return (userProfile, string.Empty);
                    }

                    return (null, "Failed to parse auth profile");
                }
                catch (Exception ex)
                {
                    return (null, $"Error parsing response: {ex.Message}");
                }
            }

            // Nếu là lỗi
            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }

        public async Task<(List<UserSummary>, string)> GetFriendsAsync()
        {
            var response = await _relationshipRepository.GetFriendsAsync();

            if (response is SuccessResponse<string> successResponse)
            {
                if (string.IsNullOrEmpty(successResponse.Data))
                {
                    return (new List<UserSummary>(), "");
                }
                var jsonData = JsonConvert.DeserializeObject<Dictionary<string, object>>(successResponse.Data);
                var data = DictionaryConverter.ParseUserSummaryList(jsonData, "data");
                return (data, string.Empty);
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }

        public async Task<(List<UserSummary>, string)> GetFollowersAsync()
        {
            var response = await _relationshipRepository.GetFollowersAsync();

            if (response is SuccessResponse<string> successResponse)
            {
                if (string.IsNullOrEmpty(successResponse.Data))
                {
                    return (new List<UserSummary>(), "");
                }
                var jsonData = JsonConvert.DeserializeObject<Dictionary<string, object>>(successResponse.Data);
                var data = DictionaryConverter.ParseUserSummaryList(jsonData, "data");
                return (data, string.Empty);
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }

        public async Task<(List<UserSummary>, string)> GetFollowingsAsync()
        {
            var response = await _relationshipRepository.GetFollowingsAsync();

            if (response is SuccessResponse<string> successResponse)
            {
                if (string.IsNullOrEmpty(successResponse.Data))
                {
                    return (new List<UserSummary>(), "");
                }
                var jsonData = JsonConvert.DeserializeObject<Dictionary<string, object>>(successResponse.Data);
                var data = DictionaryConverter.ParseUserSummaryList(jsonData, "data");
                return (data, string.Empty);
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }

        public async Task<(List<UserSummary>, string)> GetBlockedUsersAsync()
        {
            var response = await _relationshipRepository.GetBlockedUsersAsync();

            if (response is SuccessResponse<string> successResponse)
            {
                if (string.IsNullOrEmpty(successResponse.Data))
                {
                    return (new List<UserSummary>(), "");
                }
                var jsonData = JsonConvert.DeserializeObject<Dictionary<string, object>>(successResponse.Data);
                var data = DictionaryConverter.ParseUserSummaryList(jsonData, "data");
                return (data, string.Empty);
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }

        public async Task<(RelationshipStatus, string)> GetRelationshipStatusAsync(string userId)
        {
            //IsValidateUserId(userId);
            var response = await _relationshipRepository.GetRelationshipStatusAsync(userId);

            if (response is SuccessResponse<string> successResponse)
            {
                try
                {
                    // Deserialize JSON response vào đối tượng RelationshipStatus
                    var jsonData = JsonConvert.DeserializeObject<Dictionary<string, object>>(successResponse.Data);

                    if (jsonData != null && jsonData.ContainsKey("data"))
                    {
                        var dataJson = JsonConvert.SerializeObject(jsonData["data"]);

                        var relationshipStatus = JsonConvert.DeserializeObject<RelationshipStatus>(dataJson);

                        return (relationshipStatus, string.Empty);
                    }

                    return (null, "Failed to parse relationship status");
                }
                catch (Exception ex)
                {
                    return (null, $"Error parsing response: {ex.Message}");
                }
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }

        // Action Methods
        public async Task<(bool, string)> FollowUserAsync(string userId)
        {
            //IsValidateUserId(userId);

            var response = await _relationshipRepository.FollowUserAsync(userId);

            if (response is SuccessResponse<string> successResponse)
            {
                // Trả về true nếu thành công, và thông báo message
                return (true, successResponse.Message ?? "User followed successfully");
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (false, errorResponse.Message);
            }

            return (false, "Unknown error");
        }

        public async Task<(bool, string)> UnfollowUserAsync(string userId)
        {
            //IsValidateUserId(userId);

            var response = await _relationshipRepository.UnfollowUserAsync(userId);

            if (response is SuccessResponse<string> successResponse)
            {
                // Trả về true nếu thành công, và thông báo message
                return (true, successResponse.Message ?? "User unfollowed successfully");
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (false, errorResponse.Message);
            }

            return (false, "Unknown error");
        }

        public async Task<(bool, string)> BlockUserAsync(string userId)
        {
            //IsValidateUserId(userId);

            var response = await _relationshipRepository.BlockUserAsync(userId);

            if (response is SuccessResponse<string> successResponse)
            {
                // Trả về true nếu thành công, và thông báo message
                return (true, successResponse.Message ?? "User blocked successfully");
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (false, errorResponse.Message);
            }

            return (false, "Unknown error");
        }

        public async Task<(bool, string)> UnblockUserAsync(string userId)
        {
            //IsValidateUserId(userId);

            var response = await _relationshipRepository.UnblockUserAsync(userId);

            if (response is SuccessResponse<string> successResponse)
            {
                // Trả về true nếu thành công, và thông báo message
                return (true, successResponse.Message ?? "User unblocked successfully");
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (false, errorResponse.Message);
            }

            return (false, "Unknown error");
        }        
    }
}
