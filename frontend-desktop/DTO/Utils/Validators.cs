using System;
using System.Collections.Generic;

namespace DTO.Utils
{
    public static class Validators
    {
        /// <summary>
        /// Lấy giá trị từ dictionary theo kiểu `T`, nếu không có trả về giá trị mặc định.
        /// </summary>
        public static bool IsValidateUserId(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            return true;
        }
    }
}
