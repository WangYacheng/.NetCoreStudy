using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Common.Caches
{
    public static class AutoDataCacheKeys
    {
        const string prefix = "JLSys:AutoData:";

        /// <summary>
        /// 自动生成的充币地址
        /// </summary>
        /// <returns></returns>
        public static string GetDrawAddressList()
        {
            return $"{prefix}draw_address_list:";
        } 
    }
}

