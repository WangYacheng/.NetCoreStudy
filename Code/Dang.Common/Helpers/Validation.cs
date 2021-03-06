using System.Text.RegularExpressions;

namespace Dang.Common.Helpers
{
    /// <summary>
    /// 验证操作
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// 是否数字
        /// </summary>
        /// <param name="input">输入值</param>        
        public static bool IsNumber(string input)
        {
            if (input.IsEmpty())
                return false;
            const string pattern = @"^(-?\d*)(\.\d+)?$";
            return Regex.IsMatch(input, pattern);
        }

        /// <summary>
        /// 检测是否符合mobile格式
        /// </summary>
        /// <param name="strMobile">要判断的mobile字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsValidMobile(string strMobile)
        {
            //return Regex.IsMatch(strMobile, @"^(\d{1,3})?(1[3456789]\d{9})$");
            //if (strMobile.StartsWith("852"))
            //{
            //    return Regex.IsMatch(strMobile, @"^(\+?852\-?)?[5689]\d{3}\-?\d{4}$");
            //}
            //else if (strMobile.StartsWith("86"))
            //{
            //    return Regex.IsMatch(strMobile, @"^(\+?86\-?)?1[3456789]\d{9}$");
            //}
            //else if (strMobile.StartsWith("81"))
            //{
            //    return Regex.IsMatch(strMobile, @"^(\+?81|0)\d{1,4}[\-]?\d{1,4}[\-]?\d{4}$");
            //}
            //else if (strMobile.StartsWith("82"))
            //{
            //    return Regex.IsMatch(strMobile, @"^(\+?82\-?)0[71](?:\d{8,9})$");
            //}
            //else if (strMobile.StartsWith("1"))
            //{
            //    return Regex.IsMatch(strMobile, @"^(\+?1)?[2-9]\d{2}[2-9](?!11)\d{6}$");
            //}
            //else
            //{
            //    return Regex.IsMatch(strMobile, @"^(\d{1,3})?(1[3456789]\d{9})$");
            //}
            return Regex.IsMatch(strMobile, @"^[1-9]\d*$");
        }


        /// <summary>
        /// 检测是否符合mobile格式
        /// </summary>
        /// <param name="strMobile">要判断的mobile字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsValidEmail(string strMobile)
        {
            return Regex.IsMatch(strMobile, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }
    }
}
