using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl.Extensions
{
    public static class NumberExtensions
    {
        /// <summary>
        /// Rút gọn số thành định dạng K, M, B.
        /// </summary>
        /// <param name="number">Số cần rút gọn</param>
        /// <returns>Chuỗi đã rút gọn</returns>
        public static string ToShortNumber(this int number)
        {
            return ((long)number).ToShortNumber();
        }

        /// <summary>
        /// Rút gọn số thành định dạng K, M, B.
        /// </summary>
        /// <param name="number">Số cần rút gọn</param>
        /// <returns>Chuỗi đã rút gọn</returns>
        public static string ToShortNumber(this long number)
        {
            if (number >= 1_000_000_000)
                return $"{(number / 1_000_000_000.0):0.#} B";
            if (number >= 1_000_000)
                return $"{(number / 1_000_000.0):0.#} M";
            if (number >= 1_000)
                return $"{(number / 1_000.0):0.#} K";

            return number.ToString();
        }

        /// <summary>
        /// Rút gọn số từ chuỗi thành định dạng K, M, B.
        /// </summary>
        /// <param name="numberString">Chuỗi số cần rút gọn</param>
        /// <returns>Chuỗi đã rút gọn</returns>
        public static string ToShortNumber(this string numberString)
        {
            if (long.TryParse(numberString, out long number))
            {
                return number.ToShortNumber();
            }

            return numberString;
        }
    }
}
