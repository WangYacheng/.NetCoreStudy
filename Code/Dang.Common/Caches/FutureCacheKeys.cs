using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Common.Caches
{
    public static class FutureCacheKeys
    {
        const string prefix = "JLSys:Future:";

        /// <summary>
        /// Kline分钟待统计队列(先进先出，从右入队)
        /// </summary>
        /// <returns></returns>
        public static string GetQueueFutureKlineMinStaKeyList(int currencyId, int second)
        {
            return $"{prefix}queue:future_kline_min_sta:{currencyId}:{second}s";
        }

        /// <summary>
        /// 合约委托基本信息
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        public static string GetFutureTradeModelInfoKey(int tradeId)
        {
            return $"{prefix}Model:future_trade_info:{tradeId}";
        }

        /// <summary>
        /// 合约委托订单剩余数量
        /// </summary>
        /// <returns></returns>
        public static string GetFutureTradeLeftNumKeyHset()
        {
            return $"{prefix}Num:future_trade_left_num";
        }

        /// <summary>
        /// 合约持仓剩余数量
        /// </summary>
        /// <returns></returns>
        public static string GetFutureHoldPositionLeftNumKeyHset()
        {
            return $"{prefix}Num:future_hold_position_left_num";
        }

        /// <summary>
        /// 合约持仓剩余可平仓数量
        /// </summary>
        /// <returns></returns>
        public static string GetFutureHoldPositionLeftCoverKeyHset()
        {
            return $"{prefix}Num:future_hold_position_left_cover";
        }

        /// <summary>
        /// 合约委托用户发布待交易队列（买入委托set)
        /// </summary>
        /// <returns></returns>
        public static string GetFutureTradeBuyUserPubKeySet(int currencyId)
        {
            return $"{prefix}set:future_trade_buy_user_pub:{currencyId}";
        }

        /// <summary>
        /// 合约委托用户发布待交易队列（卖出委托set)
        /// </summary>
        /// <returns></returns>
        public static string GetFutureTradeSellUserPubKeySet(int currencyId)
        {
            return $"{prefix}set:future_trade_sell_user_pub:{currencyId}";
        }

        /// <summary>
        /// 合约委托止盈止损待触发订单(Set)
        /// </summary>
        /// <returns></returns>
        public static string GetFutureTradeUnTriggerEntrustSetKey(int currencyId)
        {
            return $"{prefix}set:future_trade_untrigger_entrust:{currencyId}";
        }

        /// <summary>
        /// 合约委托买方向深度哈希集合,存储价格和对应的数量（hset)
        /// </summary>
        /// <returns></returns>
        public static string GetFutureTradeBuyDepthKeyHSet(int currencyId)
        {
            return $"{prefix}hset:future_trade_buy_depth:{currencyId}";
        }

        /// <summary>
        /// 合约委托卖方向深度哈希集合,存储价格和对应的数量（hset)
        /// </summary>
        /// <returns></returns>
        public static string GetFutureTradeSellDepthKeyHSet(int currencyId)
        {
            return $"{prefix}hset:future_trade_sell_depth:{currencyId}";
        }

        /// <summary>
        /// 合约委托买方向深度排序集合,存储价格的排序（sorted set)
        /// </summary>
        /// <returns></returns>
        public static string GetFutureTradeBuyDepthKeySortedSet(int currencyId)
        {
            return $"{prefix}sortedset:future_trade_buy_sorted_price:{currencyId}";
        }

        /// <summary>
        /// 合约委托卖方向深度排序集合,存储价格的排序（sorted set)
        /// </summary>
        /// <returns></returns>
        public static string GetFutureTradeSellDepthKeySortedSet(int currencyId)
        {
            return $"{prefix}sortedset:future_trade_sell_sorted_price:{currencyId}";
        }

        /// <summary>
        /// 合约委托用户发布订单(list，先进先出，从右入队)
        /// </summary>
        /// <returns></returns>
        public static string GetFutureTradeUserPubQueueKeylist()
        {
            return $"{prefix}queue:future_trade_user_pub_queue";
        }

        /// <summary>
        /// 持仓强平队列(list，先进先出，从右入队)
        /// </summary>
        /// <returns></returns>
        public static string GetHoldPositionStopOutQueueKeylist(int currencyId, int type)
        {
            return $"{prefix}queue:hold_position_stop_out_queue:{currencyId}:{type}";
        }

        /// <summary>
        /// 持仓止盈止损队列(list，先进先出，从右入队)
        /// </summary>
        /// <returns></returns>
        public static string GetHoldPositionStopProfitOrLossQueueKeylist(int currencyId, int type)
        {
            return $"{prefix}queue:hold_position_stop_profit_or_loss_queue:{currencyId}:{type}";
        }

        /// <summary>
        /// 获取最新指数价格
        /// </summary>
        /// <returns></returns>
        public static string GetFutureIndexPriceKeyHset()
        {
            return $"{prefix}price:future_index_price";
        }

        /// <summary>
        /// 用户持仓主键Id
        /// </summary>
        /// <returns></returns>
        public static string GetHoldPositionIdKeyHset(int currencyId, int leverRate, int userId)
        {
            return $"{prefix}Map:user_hold_position_buysell_id:{currencyId}:{leverRate}:{userId}";
        }

        /// <summary>
        /// 用户合约收益
        /// </summary>
        /// <returns></returns>
        public static string GetUserAwardFutureTradeHset()
        {
            return $"{prefix}award:user_award_future_trade";
        }

        /// <summary>
        /// 交易行情涨跌幅
        /// </summary>
        /// <returns></returns>
        public static string GetMarketChangeInfoHset()
        {
            return $"{prefix}marketchange:market_change_data";
        }

        /// <summary>
        /// 产品用户持有保证金
        /// </summary>
        /// <returns></returns>
        public static string GetHoldPositionUserSumHoldHset(int currencyId, int leverRate)
        {
            return $"{prefix}Sum:hold_position_user_sum_hold:{currencyId}:{leverRate}";
        }

        /// <summary>
        /// 产品用户持仓盈亏
        /// </summary>
        /// <returns></returns>
        public static string GetHoldPositionUserUnRealProfitHset(int currencyId, int leverRate)
        {
            return $"{prefix}Award:hold_position_user_unreal_profit:{currencyId}:{leverRate}";
        }

    }
}
