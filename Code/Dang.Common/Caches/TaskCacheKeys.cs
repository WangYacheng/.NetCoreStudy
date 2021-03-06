using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Common.Caches
{
    public static class TaskCacheKeys
    {
        const string prefix = "JLSys:Task:";

        /// <summary>
        /// 今日完成提升额度
        /// </summary>
        /// <returns></returns>
        public static string GetAmountDateTaskBuyFinishKey(string strDate)
        {
            return $"{prefix}Amount:date_task_buy_finish:{strDate}";
        }

        /// <summary>
        /// 总完成提升额度
        /// </summary>
        /// <returns></returns>
        public static string GetAmountTaskBuyTotalFinishKey()
        {
            return $"{prefix}Amount:task_buy_total_finish";
        }

        /// <summary>
        /// 今日完成助力信用额度
        /// </summary>
        /// <returns></returns>
        public static string GetAmountDateTaskSellFinishKey(string strDate)
        {
            return $"{prefix}Amount:date_task_sell_finish:{strDate}";
        }

        /// <summary>
        /// 总完成助力额度
        /// </summary>
        /// <returns></returns>
        public static string GetAmountTaskSellTotalFinishKey()
        {
            return $"{prefix}Amount:task_sell_total_finish";
        }


        /// <summary>
        /// 兑换额度允许卖出小时，设置标记,同时设置过期时间为参数指定时间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetTaskUSDTToSellHourKey(int userId)
        {
            return $"{prefix}Switch:task_usdtto_sell_hour:" + userId;
        }

        /// <summary>
        /// 买入额度允许兑换小时，设置标记,同时设置过期时间为参数指定时间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetTaskBuyToUSDTHourKey(int userId)
        {
            return $"{prefix}Switch:task_buy_tousdt_hour:" + userId;
        }

        /// <summary>
        /// 兑入额度允许兑出小时，设置标记,同时设置过期时间为参数指定时间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetTaskInToUSDTHourKey(int userId)
        {
            return $"{prefix}Switch:task_in_tousdt_hour:" + userId;
        }


    }
}
