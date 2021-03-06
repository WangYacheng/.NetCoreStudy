using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Common.Caches
{
    public static class SyncCacheKeys
    {
        const string prefix = "JLSys:Sync:";

        /// <summary>
        /// 修改用户存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetUpdateUserRecord()
        {
            return $"{prefix}update_user_record:";
        }

        /// <summary>
        /// 修改用户密码存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetAddUserRecord()
        {
            return $"{prefix}update_user_add_record:";
        }

        /// <summary>
        /// 修改用户交易密码存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetAddUserAccountRecord()
        {
            return $"{prefix}update_user_account_add_record:";
        }

        /// <summary>
        /// 修改账户信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetUpdateUserAccountRecord()
        {
            return $"{prefix}update_user_account_record:";
        }
    }
}

