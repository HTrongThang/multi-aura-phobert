using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BLL.Network;
using BLL.Repositories.IRepositories;
using BLL.Repositories.Repositories;
using DTO;
using Newtonsoft.Json;
namespace BLL.Repository
{
    public class AuthRepository : BaseRepository, IAuthRepository
    {
        private static AuthRepository instance;
        private static readonly object padlock = new object();
        public static AuthRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AuthRepository();
                    }
                    return instance;
                }
            }
        }
        private AuthRepository() : base()
        {

        }

        public async Task<APIResponse<string>> LoginAsync(LoginRequest loginRequest)
        {
            if (string.IsNullOrEmpty(NetworkUrls.Auth.Login))
            {
                throw new Exception("Auth login URL is not configured or is empty.");
            }

            if (loginRequest == null)
            {
                throw new ArgumentNullException(nameof(loginRequest), "LoginRequest is null.");
            }
            if (string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                throw new ArgumentException("Username or Password in LoginRequest is empty.");
            }

            try
            {
                var response = await PostAsync(NetworkUrls.Auth.Login, loginRequest);

                if (response == null)
                {
                    throw new Exception("API response is null.");
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during login API call: {ex.Message}", ex);
            }
        }


        public async Task<APIResponse<string>> UploadProfilePhotoAsync(string photoPath)
        {
            using (var formData = new MultipartFormDataContent())
            {
                var fileContent = new ByteArrayContent(File.ReadAllBytes(photoPath));
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                formData.Add(fileContent, "image", Path.GetFileName(photoPath));

                return await PostAsync(NetworkUrls.Upload.ProfilePhoto, formData, isFormData: true);
            }
        }

        public async Task<APIResponse<string>> UdateProfileAsync(Dictionary<string, object> changes)
        {
            if (changes == null)
            {
                return new ErrorResponse<string>(400, "No any changes requested", "StatusBadRequest");
            }

            string jsonBody = JsonConvert.SerializeObject(changes);

            return await PutAsync(NetworkUrls.Auth.Update, jsonBody);
        }

    }
}
