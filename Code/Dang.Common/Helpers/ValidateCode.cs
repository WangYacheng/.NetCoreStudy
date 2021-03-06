using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Common.Helpers
{
    public class ValidateCode
    {
        const string key = "ImgCod";

        /// <summary>
        /// 加密验证码
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string CreateToken(string timestamp, string code)
        {
            string d = DateTime.Now.ToString("yyyyMMdd");
            string encryptkey = string.Format("{0}{1}{2}", key, d, timestamp);
            return Encrypt.DesEncrypt(code, encryptkey);
        }

        /// <summary>
        /// 解密验证码
        /// </summary>
        /// <param name="token"></param>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static string GetCodeFromToken(string token, string timestamp)
        {
            string d = DateTime.Now.ToString("yyyyMMdd");
            string encryptkey = string.Format("{0}{1}{2}", key, d, timestamp);
            return Encrypt.DesDecrypt(token, encryptkey);
        }
    }
}
