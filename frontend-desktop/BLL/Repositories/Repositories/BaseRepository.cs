using BLL.DataProviders;
using BLL.Network;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;

namespace BLL.Repositories.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly HttpClient _httpClient;
        private readonly string _token;

        // Singleton HttpClient
        private static readonly Lazy<HttpClient> _lazyHttpClient = new Lazy<HttpClient>(() =>
        {
            var client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30) // Thiết lập timeout
            };

            // Thiết lập Header mặc định
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        });

        // Property để lấy instance HttpClient
        protected static HttpClient HttpClientInstance => _lazyHttpClient.Value;

        // Constructor protected mà không cần truyền HttpClient
        protected BaseRepository()
        {
            _httpClient = HttpClientInstance;            
        }

        /// <summary>
        /// Lấy token và thiết lập lại Authorization Header cho mỗi yêu cầu
        /// </summary>
        private void SetAuthorizationHeader()
        {
            // Lấy token từ AppDataProvider
            var token = AppDataProvider.Instance.HasUser() ? AppDataProvider.Instance.User.Token : null;

            // Thiết lập Authorization Header nếu token tồn tại
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                // Nếu không có token, xóa header Authorization
                _httpClient.DefaultRequestHeaders.Authorization = null;
            }
        }

        /// <summary>
        /// Deserialize JSON từ response content
        /// </summary>
        private T DeserializeResponse<T>(string jsonData)
        {
            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        /// <summary>
        /// GET Request
        /// </summary>
        protected async Task<APIResponse<string>> GetAsync(string url)
        {
            try
            {
                SetAuthorizationHeader();
                var response = await Task.Run(() => _httpClient.GetAsync(url));
                return await HandleResponse(response);
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine($"Request timed out: {ex.Message}");
                // Handle timeout exception
                throw ex;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request failed: {ex.Message}");
                // Handle general HTTP request exception
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                // Catch any other exceptions
                throw ex;
            }
        }

        /// <summary>
        /// POST Request (có thể gửi JSON hoặc Form Data)
        /// </summary>
        protected async Task<APIResponse<string>> PostAsync(string url, object data = null, bool isFormData = false)
        {
            try
            {
                SetAuthorizationHeader();

                HttpContent content = null;

                // Kiểm tra nếu là Form Data (Multipart Form)
                if (data != null)
                {
                    if (isFormData)
                    {
                        content = data as MultipartFormDataContent; // Nếu dữ liệu là MultipartFormDataContent, dùng nó trực tiếp
                    }
                    else
                    {
                        // Nếu không phải Form Data thì mặc định là JSON
                        content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                    }
                }

                var response = await _httpClient.PostAsync(url, content).ConfigureAwait(false);
                return await HandleResponse(response).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// PUT Request
        /// </summary>
        protected async Task<APIResponse<string>> PutAsync(string url, string data)
        {
            try
            {
                SetAuthorizationHeader();

                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(url, content);

                return await HandleResponse(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PutAsync] Error while sending PUT request to {url}: {ex.Message}");
                return new ErrorResponse<string>(500, "An error occurred while sending PUT request", ex.Message);
            }
        }

        /// <summary>
        /// DELETE Request
        /// </summary>
        protected async Task<APIResponse<string>> DeleteAsync(string url)
        {            
            try
            {
                SetAuthorizationHeader();
                var response = await _httpClient.DeleteAsync(url);
                return await HandleResponse(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// Handle HTTP Response
        /// </summary>
        private async Task<APIResponse<string>> HandleResponse(HttpResponseMessage response)
        {
            var responseData = await response.Content.ReadAsStringAsync();

            try
            {
                // Nếu là thành công (status code 2xx)
                if (response.IsSuccessStatusCode)
                {
                    return new SuccessResponse<string>(
                        status: (int)response.StatusCode,
                        message: response.ReasonPhrase ?? "Request Successful",
                        data: responseData
                    );

                    // Deserialize thành SuccessResponse<T>
                    //var successResponse = DeserializeResponse<SuccessResponse<T>>(responseData);

                    //if (successResponse != null && successResponse.Status >= 200 && successResponse.Status < 300)
                    //{
                    //    return successResponse;
                    //}
                    //else
                    //{
                    //    // Trả về ErrorResponse nếu không parse được thành công
                    //    return new ErrorResponse<T>(successResponse?.Status ?? 500,
                    //                                successResponse?.Message ?? "Unexpected response",
                    //                                "Invalid success response format");
                    //}
                }
                else
                {
                    return new ErrorResponse<string>(
                        status: (int)response.StatusCode,
                        message: response.ReasonPhrase ?? "Request Failed",
                        error: response.RequestMessage?.RequestUri.ToString() ?? "Unknown error occurred"
                    );
                    // Nếu response là lỗi (status code không phải 2xx)
                    //var errorResponse = DeserializeResponse<ErrorResponse<T>>(responseData);

                    // Trả về ErrorResponse đã parse được hoặc ErrorResponse mặc định
                    //return errorResponse ?? new ErrorResponse<T>(response.StatusCode.GetHashCode(),
                    //                                             "Request Failed",
                    //                                             response.ReasonPhrase ?? "Unknown error occurred");
                }
            }
            catch (HttpRequestException httpEx)
            {
                // Trả về ErrorResponse cho lỗi HTTP
                return new ErrorResponse<string>(
                    status: 500, 
                    message: "HTTP Error", 
                    error: httpEx.Message
                );
            }
            catch (JsonException jsonEx)
            {
                // Trả về ErrorResponse cho lỗi JSON
                return new ErrorResponse<string>(
                    status: 500, 
                    message: "JSON Parsing Error", 
                    error: jsonEx.Message
                );
            }
        }
    }
}
