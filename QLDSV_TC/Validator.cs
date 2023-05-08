using DevExpress.XtraPrinting;
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

        public static bool isContainSpaceCharacters(string text)
        {
            string pattern = @"\s";

            // Trả về true nếu chứa khoảng trắng
            return Regex.IsMatch(text, pattern); 
        }

        public static bool checkConfirmPassword(string pass, string rePass) =>
            // Trả về true nếu 2 chuỗi khác nhau 
            pass != rePass;

        public static bool minLengthPassword(string pass, int minLength) =>
            // Trả về true nếu độ dài password chưa đạt tối thiểu
            pass.Length < minLength;

        public static bool isValidClassId(string  classId)
        {

            // Trả về true nếu mã lớp hợp lệ
            // các mã lớp hợp lệ
            // D15CQCP01, D15CQIS01, D15CQMT01, D16CQMT01, ..
            string pattern = @"^D\d{2}CQ[A-Z]{2}\d{2}$";
            return Regex.IsMatch(classId, pattern);
        }

        public static bool isValidYearRange(string yearRange)
        {
            string pattern = @"^\d{4}-\d{4}$";
            return Regex.IsMatch(yearRange, pattern);
        }
    }
}
