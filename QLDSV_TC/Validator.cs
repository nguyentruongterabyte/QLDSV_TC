using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLDSV_TC
{
    internal class Validator
    {
        // Không chấp nhận chuỗi rỗng
        public static bool isEmptyText(string text)
        {
            if (text.Trim() == "")
                return true;
            return false;
        }

        // Không cho phép ký tự đặc biệt và khoảng trắng
        public static bool isContainSpecialCharacters(string text)
        {
            // Regex pattern không cho phép ký tự đặc biệt và khoảng trắng
            string pattern = "^[a-zA-Z0-9]*$";

            // Kiểm tra pattern với input
            Match match = Regex.Match(text, pattern);

            // trả về false nếu không có ký tự đặc biệt
            return !match.Success;
        }
    }
}
