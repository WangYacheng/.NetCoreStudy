using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Common.Caches
{
    public static class TradeCacheKeys
    {
        const string prefix = "JLSys:Trade:";

        /// <summary>
        /// 获取币币的最新成交价
        /// </summary>
        /// <returns></returns>
        public static string GetTradeLastPriceKeyHset()
        {
            return $"{prefix}price:trade_last_price";
        }

        /// <summary>
        /// 币币交易基本信息
        /// </summary>
        /// <returns></returns>
        public static string GetModelTradeExchangeInfoKey(int tradeId)
        {
            return $"{prefix}Model:trade_exchange_info:{tradeId}";
        }

        /// <summary>
        /// 币币交易用户发布队列（买入委托set)
        /// </summary>
        /// <returns></returns>
        public static string GetSetTradeExchangeBidsUserPubKey(int currencyId)
        {
            return $"{prefix}set:trade_exchange_bids_user_pub:{currencyId}";
        }

        /// <summary>
        /// 币币交易用户发布队列（卖出委托set)
        /// </summary>
        /// <returns></returns>
        public static string GetSetTradeExchangeAsksUserPubKey(int currencyId)
        {
            return $"{prefix}set:trade_exchange_asks_user_pub:{currencyId}";
        }

        /// <summary>
        /// 币币委托买方向深度哈希集合,存储价格和对应的数量（hset)
        /// </summary>
        /// <returns></returns>
        public static string GetCurrencyTradeBidsDepthKeyHSet(int currencyId)
        {
            return $"{prefix}depth:currecny_trade_bids_depth:{currencyId}";
        }

        /// <summary>
        /// 币币委托卖方向深度哈希集合,存储价格和对应的数量（hset)
        /// </summary>
        /// <returns></returns>
        public static string GetCurrencyTradeAsksDepthKeyHSet(int currencyId)
        {
            return $"{prefix}depth:currecny_trade_asks_depth:{currencyId}";
        }

        /// <summary>
        /// 币币交易价格排序队列（买入待交易队列，set）
        /// </summary>
        /// <returns></returns>
        public static string GetSetTradeExchangeBidsNormalKey(int userLevel, int currencyId)
        {
            return $"{prefix}set:trade_exchange_bids_normal_{userLevel}:{currencyId}";
        }

        /// <summary>
        /// 币币交易价格排序队列（卖出待交易队列，set）
        /// </summary>
        /// <returns></returns>
        public static string GetSetTradeExchangeAsksNormalKey(int userLevel, int currencyId)
        {
            return $"{prefix}set:trade_exchange_asks_normal_{userLevel}:{currencyId}";
        }

        /// <summary>
        /// 币币交易对手价交易队列(买入待交易队列,set)
        /// </summary>
        /// <returns></returns>
        public static string GetSetTradeExchangeBidsImmediatelyKey(int userLevel, int currencyId)
        {
            return $"{prefix}set:trade_exchange_bids_immediately_{userLevel}:{currencyId}";
        }

        /// <summary>
        /// 币币交易对手价交易队列(卖出待交易队列,set)
        /// </summary>
        /// <returns></returns>
        public static string GetSetTradeExchangeAsksImmediatelyKey(int userLevel, int currencyId)
        {
            return $"{prefix}set:trade_exchange_asks_immediately_{userLevel}:{currencyId}";
        }

        /// <summary>
        /// 币币委托订单剩余数量(Hset)
        /// </summary>
        /// <returns></returns>
        public static string GetTradeExchangeLeftNumKeyHset()
        {
            return $"{prefix}Num:trade_exchange_left_num";
        }

        /// <summary>
        /// 币币委托止盈止损待触发订单(Set)
        /// </summary>
        /// <returns></returns>
        public static string GetSetTradeExchangeUnTriggerEntrustKey()
        {
            return $"{prefix}set:trade_exchange_untrigger_entrust";
        }

        /// <summary>
        /// 币币委托用户发布订单(list，先进先出，从右入队)
        /// </summary>
        /// <returns></returns>
        public static string GetListTradeExchangeUserPubQueueKey()
        {
            return $"{prefix}list:trade_exchange_user_pub_queue";
        }

        /// <summary>
        /// 币币委托用户发布订单撮合成功
        /// </summary>
        /// <returns></returns>
        public static string GetListTradeExchangeSuccessKey()
        {
            return $"{prefix}list:user_trade_exchange_success";
        }

        /// <summary>
        /// 币币委托用户发布订单撮合成功日期已分钟
        /// </summary>
        /// <returns></returns>
        public static string GetListTradeExchangeSuccessDateMinKey()
        {
            return $"{prefix}list:user_trade_exchange_success_date_min";
        }

    }
}
