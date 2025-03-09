using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomControl.Utils
{
    public static class NetworkLoader
    {
        /// <summary>
        /// Lấy giá trị từ dictionary theo kiểu `T`, nếu không có trả về giá trị mặc định.
        /// </summary>
        public static async Task<Image> LoadImageFromUrlAsync(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var stream = await httpClient.GetStreamAsync(url);
                    return Image.FromStream(stream);
                }
                catch
                {
                    // Xử lý lỗi nếu cần
                    return null;
                }
            }
        }
    }
}
