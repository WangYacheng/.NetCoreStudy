using System;
using System.IO;

namespace Dang.Common.Helpers {
    /// <summary>
    /// 常用公共操作
    /// </summary>
    public static class Common {
        /// <summary>
        /// 获取类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static Type GetType<T>() {
            return GetType( typeof( T ) );
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="type">类型</param>
        public static Type GetType( Type type ) {
            return Nullable.GetUnderlyingType( type ) ?? type;
        }

        /// <summary>
        /// 换行符
        /// </summary>
        public static string Line => Environment.NewLine;

        /// <summary>
        /// 获取物理路径
        /// </summary>
        /// <param name="relativePath">相对路径</param>
        public static string GetPhysicalPath( string relativePath ) {
            if( string.IsNullOrWhiteSpace( relativePath ) )
                return string.Empty;
            var rootPath = Web.RootPath;
            if( string.IsNullOrWhiteSpace( rootPath ) )
                return Path.GetFullPath( relativePath );
            return $"{Web.RootPath}\\{relativePath.Replace( "/", "\\" ).TrimStart( '\\' )}";
        }

        /// <summary>
        /// 获取wwwroot路径
        /// </summary>
        /// <param name="relativePath">相对路径</param>
        public static string GetWebRootPath( string relativePath ) {
            if( string.IsNullOrWhiteSpace( relativePath ) )
                return string.Empty;
            var rootPath = Web.WebRootPath;
            if( string.IsNullOrWhiteSpace( rootPath ) )
                return Path.GetFullPath( relativePath );
            return $"{Web.WebRootPath}\\{relativePath.Replace( "/", "\\" ).TrimStart( '\\' )}";
        }


        /// <summary>
        /// 获取收款类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetCardCode(int id)
        {
            string res = "";
            switch (id)
            {
                case 1:
                    res = "bank-card";
                    break;
                case 2:
                    res = "qianbao";
                    break;
                case 3:
                    res = "contact31";
                    break;
            }
            return res;
        }



        /// <summary>
        /// 生成随机字母字符串(数字字母混和)
        /// </summary>
        /// <param name="codeCount">待生成的位数</param>
        public static string GetCheckCode(int codeCount)
        {
            string str = string.Empty;
            int rep = 0;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            System.Random random = new System.Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codeCount; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }
    }
}
