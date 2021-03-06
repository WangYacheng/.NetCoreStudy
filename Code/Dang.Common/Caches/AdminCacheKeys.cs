using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Common.Caches
{
    public static class AdminCacheKeys
    {
        const string prefix = "JLSys:AdminCacheKeys:";

        /// <summary>
        /// 获取config
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetConfigModelKey(int id)
        {
            return $"{prefix}Model:config_model:" + id;
        }

        /// <summary>
        /// 用户refreshToken获取用户名
        /// </summary>
        /// <returns></returns>
        public static string TokenAdminUserIdFromRefreshTokenKey(string refresToken)
        {
            return $"{prefix}LoginToken:admin_user_id_from_refresh_token:{refresToken}";
        }

        /// <summary>
        /// 用户accesstoken
        /// </summary>
        /// <returns></returns>
        public static string AdminTokenAccessTokenByRefreshTokenKey(string refresToken)
        {
            return $"{prefix}LoginToken:admin_access_token_by_refresh_token:{refresToken}";
        }

        /// <summary>
        /// 用户accesstoken
        /// </summary>
        /// <returns></returns>
        public static string TokenAccessTokenByAdminUserIdKey(int userId)
        {
            return $"{prefix}LoginToken:access_token_by_admin_userid:{userId}";
        }

        /// <summary>
        /// 用户accesstoken获取用户id
        /// </summary>
        /// <returns></returns>
        public static string TokenAdminUserIdFromAccessTokenKey(string accessToken)
        {
            var screctStr = Common.Helpers.Encrypt.Md5By32(accessToken);
            return $"{prefix}LoginToken:admin_user_id_from_access_token:{screctStr}";
        }

        /// <summary>
        /// 用户所有accesstoken
        /// </summary>
        /// <returns></returns>
        public static string TokenAccessTokenListByAdminUserIdKeyHSet(int userId)
        {
            return $"{prefix}LoginToken:access_token_list_by_admin_userid:{userId}";
        }

        #region 管理员

        /// <summary>
        /// 管理后台用户存入缓存 22
        /// </summary>
        /// <returns></returns>
        public static string GetAdminUserListKey()
        {
            return $"{prefix}List:admin_user_list:";
        }

        /// <summary>
        /// 后台用户id存model  11
        /// </summary> 
        /// <returns></returns>
        public static string GetAdminUserModelKey(int adminUserId)
        {
            return $"{prefix}Model:admin_user_model:" + adminUserId;
        }


        /// <summary>
        /// user_name对应user_id
        /// </summary>
        /// <returns></returns>
        public static string GetAdminUserNameMapIdKey(string user_name)
        {
            return $"{prefix}Map:admin_user_id_map:" + user_name;
        }

        #endregion

        #region 管理员角色

        /// <summary>
        /// 管理后台角色权限存入缓存 33
        /// </summary>
        /// <returns></returns>
        public static string GetAdminUserRoleValueModelKey(int roleId)
        {
            return $"{prefix}List:admin_user_role_value_model:" + roleId;
        }

        /// <summary>
        /// 管理员角色列表 22
        /// </summary>
        /// <returns></returns>
        public static string GetAdminUserRoleListKey()
        {
            return $"{prefix}List:admin_user_role_list:";
        }

        /// <summary>
        /// 后台用户id存model  11
        /// </summary>
        /// <returns></returns>
        public static string GetAdminUserRoleModelKey(int roleId)
        {
            return $"{prefix}Model:admin_user_role_model:" + roleId;
        }

        #endregion


        #region 会员
        /// <summary>
        /// 会员集合
        /// </summary>
        /// <returns></returns>
        public static string GetMemberUserListKey()
        {
            return $"{prefix}List:member_user_list:";
        }

        /// <summary>
        /// 根据会员ID 对应实体
        /// </summary>
        /// <returns></returns>
        public static string GetMemberUserModelKey(int memberId)
        {
            return $"{prefix}List:member_user_model:" + memberId;
        }


        /// <summary>
        /// member_name对应member_id
        /// </summary>
        /// <returns></returns>
        public static string GetMemberUserNameMapIdKey(string user_name)
        {
            return $"{prefix}Map:member_user_id_map:" + user_name;
        }

        /// <summary>
        /// 会员级别集合
        /// </summary>
        /// <returns></returns>
        public static string GetMemberUserLevelListKey()
        {
            return $"{prefix}List:member_user_level_list:";
        }

        /// <summary>
        /// 会员级别ID 对应实体
        /// </summary>
        /// <returns></returns>
        public static string GetMemberUserLevelModelKey(int memberLevelId)
        {
            return $"{prefix}List:member_user_level_model:"+ memberLevelId;
        }

        /// <summary>
        /// member_name对应member_id
        /// </summary>
        /// <returns></returns>
        public static string GetMemberUserLevelNameMapIdKey(string user_level_name)
        {
            return $"{prefix}Map:member_user_level_id_map:" + user_level_name;
        }
        #endregion
    }
}

