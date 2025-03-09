using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Repositories.IRepositories;
using BLL.Network;
using DTO;
using DTO.Utils;
using Newtonsoft.Json;
using BLL.Repository;
namespace BLL.Services
{
    public class AuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public async Task<(User, string)> LoginAsync(LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                throw new ArgumentNullException(nameof(loginRequest), "LoginRequest is null.");
            }

            var response = await _authRepository.LoginAsync(loginRequest);

            if (response == null)
            {
                return (null, "API response is null.");
            }

            if (response is SuccessResponse<string> successResponse)
            {
                try
                {
                    var userData = JsonConvert.DeserializeObject<dynamic>(successResponse.Data);
                    Console.WriteLine($"[INFO] SuccessResponse Received - Data: {successResponse.Data}");

                    if (userData?.data?.data == null)
                    {
                        return (null, "API response data is empty or invalid.");
                    }

                    var userDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(userData.data.data.ToString());
                    var token = userData.data.token?.ToString();

                    var userProfile = User.FromDictionary(userDict);

                    if (userProfile != null)
                    {
                        userProfile.Token = token;
                        return (userProfile, string.Empty);
                    }

                    return (null, "Failed to parse user profile.");
                }
                catch (JsonException ex)
                {
                    return (null, $"Error parsing response: {ex.Message}");
                }
                catch (Exception ex)
                {
                    return (null, $"Unexpected error: {ex.Message}");
                }
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error.");
        }

        public async Task<(bool, string)> UpdateProfileAsync(string photoPath = "", Dictionary<string, object> changes = null)
        {
            try
            {
                var tasks = new List<Task<APIResponse<string>>>();

                if (!string.IsNullOrWhiteSpace(photoPath))
                {
                    tasks.Add(_authRepository.UploadProfilePhotoAsync(photoPath));
                }

                if (changes != null && changes.Count > 0)
                {
                    tasks.Add(_authRepository.UdateProfileAsync(changes));
                }

                if (tasks.Count == 0)
                {
                    return (true, "No updates needed");
                }

                var responses = await Task.WhenAll(tasks);

                bool allSuccess = true;
                string errorMessage = "";

                foreach (var response in responses)
                {
                    if (response is ErrorResponse<string> errorResponse)
                    {
                        allSuccess = false;
                        errorMessage += $"{errorResponse.Message}. ";
                    }
                }

                if (allSuccess)
                {
                    return (true, "Profile updated successfully");
                }
                else
                {
                    return (false, errorMessage.Trim());
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error occurred: {ex.Message}");
            }
        }

    }
}
