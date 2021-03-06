using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Common.Caches
{
    public static class MarketCacheKeys
    {
        const string prefix = "JLSys:Market:";

        /// <summary>
        /// 获取交易详情实体Key
        /// </summary>
        /// <returns></returns>
        public static string GetMarketTickerModelKey(int currencyId)
        {
            return $"{prefix}Model:market_ticker_model:{currencyId}";
        }

        /// <summary>
        /// 深度5卖队列
        /// </summary>
        /// <param name="currencyId"></param>
        /// <returns></returns>
        public static string GetMarketAsksDepth5DataKey(int currencyId)
        {
            return $"{prefix}Depth5:market_asks_depth5_data:{currencyId}";
        }

        /// <summary>
        /// 深度5买队列
        /// </summary>
        /// <param name="currencyId"></param>
        /// <returns></returns>
        public static string GetMarketBidsDepth5DataKey(int currencyId)
        {
            return $"{prefix}Depth5:market_bids_depth5_data:{currencyId}";
        }

        /// <summary>
        /// 交易成交数据队列
        /// </summary>
        /// <param name="currencyId"></param>
        /// <returns></returns>
        public static string GetQueueMarketTradeDataKey(int currencyId)
        {
            return $"{prefix}Queue:market_trade_data:{currencyId}";
        }

        /// <summary>
        /// 交易最新ticker数据
        /// </summary>
        /// <param name="currencyId"></param>
        /// <returns></returns>
        public static string GetLastestMarketTickerDataKey(int currencyId, string action)
        {
            return $"{prefix}Ticker:lastest_market_ticker_data:{currencyId}:{action}";
        }

    }
}
