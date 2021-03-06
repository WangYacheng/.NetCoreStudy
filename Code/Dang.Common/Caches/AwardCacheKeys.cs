using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Common.Caches
{
    public class AwardCacheKeys
    {
        const string prefix = "JLSys:Award:";

        /// <summary>
        /// 统计用户收益类型
        /// </summary>
        /// <returns></returns>
        public static string GetSumUserAwardKey(int typeId)
        {
            return $"{prefix}Sum:user_award:{typeId}";
        }

        /// <summary>
        /// 统计用户动态收益类型
        /// </summary>
        /// <returns></returns>
        public static string GetSumUserDynamicAwardKey(int accountId)
        {
            return $"{prefix}Sum:user_dynamic_award:{accountId}";
        }

        /// <summary>
        /// 用户币币交易卖出收益队列
        /// </summary>
        /// <returns></returns>
        public static string GetUserCurrencySellAwardKey()
        {
            return $"{prefix}Queue:user_currency_sell_award:";
        }

        /// <summary>
        /// 用户VIP释放收益队列
        /// </summary>
        /// <returns></returns>
        public static string GetUserVIPReleaseAwardKey()
        {
            return $"{prefix}Queue:user_vip_release_award:";
        }

    }
}
