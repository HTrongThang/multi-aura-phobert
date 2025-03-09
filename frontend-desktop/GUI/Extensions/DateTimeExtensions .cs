using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Chuyển đổi thời gian thành định dạng tương đối, ví dụ: "•30s", "•10m", "•1h", "•3d", "•2w", "•5mo", "•1y".
        /// Phương thức này tính toán khoảng thời gian giữa ngày giờ hiện tại và giá trị <paramref name="dateTime"/>
        /// và trả về định dạng thời gian tương đối.
        /// </summary>
        /// <param name="dateTime">Ngày giờ cần chuyển đổi thành thời gian tương đối.</param>
        /// <returns>Chuỗi chứa thời gian tương đối, ví dụ "•30s", "•1m", "•1h", "•3d", "•2w", "•5mo", "•2y".</returns>
        public static string ToRelativeTime(this DateTime dateTime)
        {
            var timeSpan = DateTime.Now - dateTime;

            if (timeSpan.TotalSeconds < 60)
                return $"•{(int)timeSpan.TotalSeconds}s";
            else if (timeSpan.TotalMinutes < 60)
                return $"•{(int)timeSpan.TotalMinutes}m";
            else if (timeSpan.TotalHours < 24)
                return $"•{(int)timeSpan.TotalHours}h";
            else if (timeSpan.TotalDays < 7)
                return $"•{(int)timeSpan.TotalDays}d";
            else if (timeSpan.TotalDays < 30)
                return $"•{(int)(timeSpan.TotalDays / 7)}w";
            else if (timeSpan.TotalDays < 365)
                return $"•{(int)(timeSpan.TotalDays / 30)}mo";
            else
                return $"•{(int)(timeSpan.TotalDays / 365)}y";
        }
    }
}
