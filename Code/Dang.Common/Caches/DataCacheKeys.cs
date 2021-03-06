using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Common.Caches
{
    public static class DataCacheKeys
    {
        const string prefix = "JLSys:Data:";

        #region 系统基本信息

      

        /// <summary>
        /// 获取config_bonus_distributionlist
        /// </summary>
        /// <returns></returns>
        public static string GetConfigBonusDistributionKey()
        {
            return $"{prefix}List:config_bonus_distribution:";
        }

        /// <summary>
        /// 获取config_bonus_distribution
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetConfigBonusDistributionModelKey(int id)
        {
            return $"{prefix}Model:config_bonus_distribution_model:" + id;
        }

        /// <summary>
        /// 账户信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetAccountModelKey(int account_id)
        {
            return $"{prefix}Model:account_model:" + account_id;
        }

        /// <summary>
        /// 账户信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetAccountListKey()
        {
            return $"{prefix}List:account_list:";
        }

        /// <summary>
        /// 获取Account价格Key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetAccountNewPriceKey(int id)
        {
            return $"{prefix}Price:account_new_price:" + id;
        }

        /// <summary>
        /// 获取Account价格Key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetAccountCnyPriceKey(int id)
        {
            return $"{prefix}Price:account_cny_price:" + id;
        }

        /// <summary>
        /// 账户兑换信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetAccountExchangeModelKey(int account_id, int to_account_id)
        {
            return $"{prefix}Model:account_exchange_attr_model:" + account_id + ":" + to_account_id;
        }

        /// <summary>
        /// 账户兑换信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetAccountExchangeListKey()
        {
            return $"{prefix}List:account_exchange_attr_list:";
        }

        /// <summary>
        /// 账户兑换信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetAccountUserLevelModelKey(int account_id, int level_id)
        {
            return $"{prefix}Model:account_user_level_attr_model:" + account_id + ":" + level_id;
        }

        /// <summary>
        /// 账户兑换信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetAccountUserLevelListKey()
        {
            return $"{prefix}List:account_user_level_attr_list:";
        }

        /// <summary>
        /// 用户group存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetGroupModelKey(int group_id)
        {
            return $"{prefix}Model:user_group_model:" + group_id;
        }

        /// <summary>
        /// 用户group存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetShoppingGroupModelKey(int group_id)
        {
            return $"{prefix}Model:user_shopping_group_model:" + group_id;
        }

        /// <summary>
        /// group存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetGroupKey()
        {
            return $"{prefix}List:user_group_list:";
        }

        /// <summary>
        /// 用户level存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetLevelModelKey(int level_id)
        {
            return $"{prefix}Model:user_level_model:" + level_id;
        }

        /// <summary>
        /// level存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetUserLevelListKey()
        {
            return $"{prefix}List:user_level_list:";
        }

        /// <summary>
        /// 用户level1存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetLevel1ModelKey(int level_id)
        {
            return $"{prefix}Model:user_level1_model:" + level_id;
        }

        /// <summary>
        /// level1存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetUserLevel1ListKey()
        {
            return $"{prefix}List:user_level1_list:";
        }

        /// <summary>
        /// 用户level2存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetLevel2ModelKey(int level_id)
        {
            return $"{prefix}Model:user_level2_model:" + level_id;
        }

        /// <summary>
        /// level2存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetUserLevel2ListKey()
        {
            return $"{prefix}List:user_level2_list:";
        }

        /// <summary>
        /// 用户level3存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetLevel3ModelKey(int level_id)
        {
            return $"{prefix}Model:user_level3_model:" + level_id;
        }

        /// <summary>
        /// level3存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetUserLevel3ListKey()
        {
            return $"{prefix}List:user_level3_list:";
        }

        /// <summary>
        /// 用户level4存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetLevel4ModelKey(int level_id)
        {
            return $"{prefix}Model:user_level4_model:" + level_id;
        }

        /// <summary>
        /// level4存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetUserLevel4ListKey()
        {
            return $"{prefix}List:user_level4_list:";
        }

        /// <summary>
        /// 矿机购买数量存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetUserMinerCountKey()
        {
            return $"{prefix}Count:user_miner_count";
        }

        /// <summary>
        /// 提成参数存入缓存list
        /// </summary>
        /// <returns></returns>
        public static string GetUserProfitConfigListKey()
        {
            return $"{prefix}List:user_profit_config_list:";
        }


        /// <summary>
        /// 提成参数存入缓存model
        /// </summary>
        /// <returns></returns>
        public static string GetUserProfitConfigModelKey(int cid)
        {
            return $"{prefix}Model:user_profit_config_model:" + cid;
        }


        /// <summary>
        /// 提成参数存入缓存model
        /// </summary>
        /// <returns></returns>
        public static string GetUserProfitConfigDetailsModelKey(int did)
        {
            return $"{prefix}Model:user_profit_config_details_model:" + did;
        }

        /// <summary>
        /// 提成参数存入缓存list
        /// </summary>
        /// <returns></returns>
        public static string GetUserProfitConfigDetailsListKey()
        {
            return $"{prefix}List:user_profit_config_details_list:";
        }

        #endregion

        #region 用户相关KEY

        #region 用户体系人数

        /// <summary>
        /// 用户一级人数
        /// </summary>
        /// <returns></returns>
        public static string GetUserFirstCountKey()
        {
            return $"{prefix}Count:user_recommend_count";
        }

        /// <summary>
        /// 用户二级人数
        /// </summary>
        /// <returns></returns>
        public static string GetUserSecondCountKey()
        {
            return $"{prefix}Count:user_child_recommend_count";
        }

        /// <summary>
        /// 用户三级人数
        /// </summary>
        /// <returns></returns>
        public static string GetUserThirdCountKey()
        {
            return $"{prefix}Count:user_third_recommend_count";
        }

        /// <summary>
        /// 用户团队人数
        /// </summary>
        /// <returns></returns>
        public static string GetUserTeamCountKey()
        {
            return $"{prefix}Count:user_team_count";
        }

        #endregion

        #region 用户(体系)购买次数

        /// <summary>
        /// 用户购买次数
        /// </summary>
        /// <returns></returns>
        public static string GetUserSelfBuyCountKey()
        {
            return $"{prefix}Count:user_self_buy_count";
        }

        /// <summary>
        /// 用户一级购买次数
        /// </summary>
        /// <returns></returns>
        public static string GetUserFirstBuyCountKey()
        {
            return $"{prefix}Count:user_recommend_buy_count";
        }

        /// <summary>
        /// 用户二级购次数
        /// </summary>
        /// <returns></returns>
        public static string GetUserSecondBuyCountKey()
        {
            return $"{prefix}Count:user_child_recommend_buy_count";
        }

        /// <summary>
        /// 用户三级购买次数
        /// </summary>
        /// <returns></returns>
        public static string GetUserThirdBuyCountKey()
        {
            return $"{prefix}Count:user_third_recommend_buy_count";
        }

        /// <summary>
        /// 用户团级购买次数
        /// </summary>
        /// <returns></returns>
        public static string GetUserTeamBuyCountKey()
        {
            return $"{prefix}Count:user_team_buy_count";
        }


        #endregion

        #region 用户（体系）购买数量

        /// <summary>
        /// 用户购买数量
        /// </summary>
        /// <returns></returns>
        public static string GetUserSelfBuyQuatityKey()
        {
            return $"{prefix}Count:user_self_buy_quatity";
        }

        /// <summary>
        /// 用户一级购买数量
        /// </summary>
        /// <returns></returns>
        public static string GetUserFirstBuyQuatityKey()
        {
            return $"{prefix}Count:user_recommend_buy_quatity";
        }

        /// <summary>
        /// 用户二级购买数量
        /// </summary>
        /// <returns></returns>
        public static string GetUserSecondBuyQuatityKey()
        {
            return $"{prefix}Count:user_child_recommend_buy_quatity";
        }

        /// <summary>
        /// 用户三级购买数量
        /// </summary>
        /// <returns></returns>
        public static string GetUserThirdBuyQuatityKey()
        {
            return $"{prefix}Count:user_third_recommend_buy_quatity";
        }

        /// <summary>
        /// 用户团级购买数量
        /// </summary>
        /// <returns></returns>
        public static string GetUserTeamBuyQuatityKey()
        {
            return $"{prefix}Count:user_team_buy_quatity";
        }

        #endregion

        #region 用户体系购买人数

        /// <summary>
        /// 用户一级购买人数
        /// </summary>
        /// <returns></returns>
        public static string GetUserFirstBuyPersonCountKey()
        {
            return $"{prefix}Count:user_recommend_buy_person_count";
        }

        /// <summary>
        /// 用户二级购买人数
        /// </summary>
        /// <returns></returns>
        public static string GetUserSecondBuyPersonCountKey()
        {
            return $"{prefix}Count:user_child_recommend_buy_person_count";
        }

        /// <summary>
        /// 用户三级购买人数
        /// </summary>
        /// <returns></returns>
        public static string GetUserThirdBuyPersonCountKey()
        {
            return $"{prefix}Count:user_third_recommend_buy_person_count";
        }

        /// <summary>
        /// 用户团级购买人数
        /// </summary>
        /// <returns></returns>
        public static string GetUserTeamBuyPersonCountKey()
        {
            return $"{prefix}Count:user_team_buy_person_count";
        }

        #endregion

        #region 用户（体系）业绩

        /// <summary>
        /// 用户业绩
        /// </summary>
        /// <returns></returns>
        public static string GetUserSelfResultsKey()
        {
            return $"{prefix}Result:user_self_results";
        }

        /// <summary>
        /// 用户业绩
        /// </summary>
        /// <returns></returns>
        public static string GetUserSelfAccountResultsKey(int accountId)
        {
            return $"{prefix}Result:user_self_account_results:" + accountId;
        }

        /// <summary>
        /// 用户一级业绩
        /// </summary>
        /// <returns></returns>
        public static string GetUserFirstResultsKey()
        {
            return $"{prefix}Result:user_recommend_results";
        }

        /// <summary>
        /// 用户二级业绩
        /// </summary>
        /// <returns></returns>
        public static string GetUserSecondResultsKey()
        {
            return $"{prefix}Result:user_child_recommend_results";
        }

        /// <summary>
        /// 用户三级业绩
        /// </summary>
        /// <returns></returns>
        public static string GetUserThirdResultsKey()
        {
            return $"{prefix}Result:user_third_recommend_results";
        }

        /// <summary>
        /// 用户团级业绩
        /// </summary>
        /// <returns></returns>
        public static string GetUserTeamResultsKey()
        {
            return $"{prefix}Result:user_team_results";
        }
        /// <summary>
        /// 用户团级业绩
        /// </summary>
        /// <returns></returns>
        public static string GetUserTeamAccountResultsKey(int accountId)
        {
            return $"{prefix}Result:user_team_results:" + accountId;
        }


        #endregion

        #region 用户(体系)交易业绩

        /// <summary>
        /// 用户业绩
        /// </summary>
        /// <returns></returns>
        public static string GetUserTradeSelfResultsKey()
        {
            return $"{prefix}Result:user_trade_self_results";
        }

        /// <summary>
        /// 用户业绩
        /// </summary>
        /// <returns></returns>
        public static string GetUserTradeTeamResultsKey()
        {
            return $"{prefix}Result:user_trade_team_results";
        }

        #endregion

        #region 用户天奖励

        /// <summary>
        /// 用户天奖励
        /// </summary>
        /// <returns></returns>
        public static string GetUserTodayAmountKey(string date_time)
        {
            return $"{prefix}Result:user_today_accttype_amount_date_time:" + date_time;
        }

        #endregion

        #region 用户账户

        /// <summary>
        /// 用户当前的钱包地址
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public static string GetUserAccountWalletAddressKeyHset(int accountId)
        {
            return $"{prefix}Address:user_account_wallet_address:{accountId}";
        }

        /// <summary>
        /// 用户账户钱包地址对应user_id
        /// </summary>
        /// <returns></returns>
        public static string GetUserWalletAddressMapIdKeyHset(int account_id)
        {
            return $"{prefix}Map:user_id_map_by_wallet_address:" + account_id;
        }

        /// <summary>
        /// 用户账户信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetUserAccountModelKey(int user_id, int account_id)
        {
            return $"{prefix}Model:user_account_model:" + user_id + "account_id:" + account_id;
        }

        /// <summary>
        /// 用户账户余额信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetUserAccountAmountKey(int account_id)
        {
            return $"{prefix}Amount:user_account_amount:" + account_id;
        }

        /// <summary>
        /// 用户账户余额累计信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetUserAccountAmountTotalKey(int account_id)
        {
            return $"{prefix}Amount:user_account_amount_total:" + account_id;
        }

        /// <summary>
        /// 用户账户余额冻结信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetUserAccountAmountFreezeKey(int account_id)
        {
            return $"{prefix}Amount:user_account_amount_freeze:" + account_id;
        }

        #endregion

        /// <summary>
        /// 用户refreshToken获取用户名
        /// </summary>
        /// <returns></returns>
        public static string TokenUserIdFromRefreshTokenKey(string refresToken)
        {
            return $"{prefix}LoginToken:user_id_from_refresh_token:{refresToken}";
        }

        /// <summary>
        /// 用户accesstoken获取用户id
        /// </summary>
        /// <returns></returns>
        public static string TokenUserIdFromAccessTokenKey(string accessToken)
        {
            var screctStr = Common.Helpers.Encrypt.Md5By32(accessToken);
            return $"{prefix}LoginToken:user_id_from_access_token:{screctStr}";
        }

        /// <summary>
        /// 用户accesstoken
        /// </summary>
        /// <returns></returns>
        public static string TokenAccessTokenByUserIdKey(int userId)
        {
            return $"{prefix}LoginToken:access_token_by_userid:{userId}";
        }

        /// <summary>
        /// 用户所有accesstoken
        /// </summary>
        /// <returns></returns>
        public static string TokenAccessTokenListByUserIdKeyHSet(int userId)
        {
            return $"{prefix}LoginToken:access_token_list_by_userid:{userId}";
        }

        /// <summary>
        /// 用户accesstoken
        /// </summary>
        /// <returns></returns>
        public static string TokenAccessTokenByRefreshTokenKey(string refresToken)
        {
            return $"{prefix}LoginToken:access_token_by_refresh_token:{refresToken}";
        }

        /// <summary>
        /// 获取Payment实体Key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetPaymentModelKey(int id)
        {
            return $"{prefix}Model:payment_model:" + id;
        }

        /// <summary>
        /// user_name对应user_id
        /// </summary>
        /// <returns></returns>
        public static string GetUserNameMapIdKey(string user_name)
        {
            return $"{prefix}Map:user_id_map:" + user_name;
        }

        /// <summary>
        /// user_ticket对应user_id
        /// </summary>
        /// <returns></returns>
        public static string GetUserTicketMapIdKey(string user_ticket)
        {
            return $"{prefix}Map:user_id_map:" + user_ticket;
        }

        /// <summary>
        /// 用户id存model
        /// </summary>
        /// <returns></returns>
        public static string GetUserModelKey(int user_id)
        {
            return $"{prefix}Model:user_model:" + user_id;
        }

        /// <summary>
        /// 用户id
        /// </summary>
        /// <returns></returns>
        public static string GetUserIdKey(int account_id, string date)
        {
            return $"{prefix}SAdd:user_id:account_id:" + account_id + ":date:" + date;
        }

        /// <summary>
        /// 用户id
        /// </summary>
        /// <returns></returns>
        public static string GetUserResultKey(string date)
        {
            return $"{prefix}SAdd:user_id:account_id:date:" + date;
        }

        /// <summary>
        /// 用户id存UserNumModel
        /// </summary>
        /// <returns></returns>
        public static string GetUserNumModelKey(int user_id)
        {
            return $"{prefix}Model:user_num_model:" + user_id;
        }

        /// <summary>
        /// 用户id存UserAttrModel
        /// </summary>
        /// <returns></returns>
        public static string GetUserAttrModelKey(int user_id)
        {
            return $"{prefix}Model:user_attr_model:" + user_id;
        }

        /// <summary>
        /// 用户banner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetAdvertBannerModelKey(int id)
        {
            return $"{prefix}List:advert_banner_model:" + id;
        }

        /// <summary>
        /// 用户推荐信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetUserParentPathModelKey(int user_id)
        {
            return $"{prefix}Model:user_parent_path_model:" + user_id;
        }

        /// <summary>
        /// 全网真实算力信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetUserAccountTotalKey(int account_id)
        {
            return $"{prefix}Amount:user_account_amount_total_power:" + account_id;
        }

        /// <summary>
        /// 用户信息卡表
        /// </summary>
        /// <returns></returns>
        public static string GetUserCreaditCardKey(int user_id)
        {
            return $"{prefix}Amount:user_credit_card_model:" + user_id;
        }

        /// <summary>
        /// 用户实名存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetUserVerifyModelKey(int user_id)
        {
            return $"{prefix}Model:user_verify_model:" + user_id;
        }

        /// <summary>
        /// 用户交易限制缓存
        /// </summary>
        /// <returns></returns>
        public static string GetUserTradeSettingModelKey(int user_id)
        {
            return $"{prefix}Model:user_trade_setting_model:" + user_id;
        }

        /// <summary>
        /// 矿机信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetMinerModelKey(int mid)
        {
            return $"{prefix}Model:miner_model:" + mid;
        }

        /// <summary>
        /// 账户信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetMinerListKey()
        {
            return $"{prefix}List:miner_list:";
        }

        /// <summary>
        /// 交易对信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetCurrencyModelIdKey(int id)
        {
            return $"{prefix}Model:currency_model:" + id;
        }

        /// <summary>
        /// 交易对信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetCurrencyModelSymbolKey(string symbol)
        {
            return $"{prefix}Model:currency_model:" + symbol;
        }

        /// <summary>
        /// 更新用户业绩
        /// </summary>
        /// <returns></returns>
        public static string GetPerformanceUpdateKey()
        {
            return $"{prefix}Performance:performance_update";
        }

        /// <summary>
        /// 提成参数
        /// </summary>
        /// <returns></returns>
        public static string GetUserProfitConfigDetailsListKey(int userProfitId)
        {
            return $"{prefix}List:user_profit_config_details:{userProfitId}";
        }

        #endregion

        #region 新零售产品相关KEY

        /// <summary>
        /// 新零售产品存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetNewRetailModelKey(int id)
        {
            return $"{prefix}Model:new_retail_model:" + id;
        }

        /// <summary>
        /// 新零售产品存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetNewRetailListKey()
        {
            return $"{prefix}List:new_retail:";
        }

        /// <summary>
        /// 秒杀券存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetOrderCouponCountKey()
        {
            return $"{prefix}List:order_coupon_count:";
        }

        /// <summary>
        /// 抢购次数存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetRushToCountKey(int user_id)
        {
            return $"{prefix}Count:rush_to_count:" + user_id;
        }

        /// <summary>
        /// 秒杀次数存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetDaySpikeCount(int user_id)
        {
            return $"{prefix}Count:day_spike_count:" + user_id;
        }

        /// <summary>
        /// 获取秒杀资格列表存入缓存
        /// </summary>
        /// <param name="strSkipData"></param>
        /// <returns></returns>
        public static string GetSpikeQueueDataListKey(string spike_date)
        {
            return $"{prefix}List:spike_queue_list:{spike_date}";
        }

        #endregion

        #region 配置相关KEY

        /// <summary>
        /// 配置相关KEY存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetSysSettingModelKey(string title)
        {
            return $"{prefix}Model:sys_setting_model:" + title;
        }

        public static string GetSystemConfigModelKey(int id)
        {
            return $"{prefix}Model:system_config_model:" + id;
        }

        #endregion

        /// <summary>
        /// 获取Currency实体Key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetCurrencyModelKey(int id)
        {
            return $"{prefix}Model:currency_model:" + id;
        }

        /// <summary>
        /// 账户信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetCurrencyListKey()
        {
            return $"{prefix}List:currency_list:";
        }

        /// <summary>
        /// 获取Currency价格Key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetCurrencyNewPriceKey(int id)
        {
            return $"{prefix}Price:currency_new_price:" + id;
        }

        /// <summary>
        /// 用户买入UTC后，设置标记,同时设置过期时间为参数指定时间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetUserUTCBuyIsRightTimeKey(int userId)
        {
            return $"{prefix}Switch:user_utc_buy_is_right_time:" + userId;
        }

        /// <summary>
        /// 按人数自动增长的价格
        /// </summary>
        /// <returns></returns>
        public static string GetUtcNewCnyPrice()
        {
            return GetSysSettingModelKey("UTC_NEW_CNY_PRICE");
        }

        /// <summary>
        /// 标记用户是否是第一次购买UTC（币币，法币）(0:未购买，1：交易中，2：已购买)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetUserIsFirstBuyUTCKey()
        {
            return $"{prefix}Bool:user_is_first_buy_utc";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetUserFirstBuyUTCIdKey()
        {
            return $"{prefix}Key:user_first_buy_utc_id";
        }


        /// <summary>
        /// 用户账户信息存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetMarketDepthModelKey(string symbol)
        {
            return $"{prefix}Model:market_depth:" + symbol;
        }

        /// <summary>
        /// 获取某一条新闻是否阅读
        /// </summary>
        /// <returns></returns>
        public static string GetUserNewsReadStatus(int user_id, int article_id)
        {
            return $"{prefix}Article:user_article_read_status:" + user_id + ":" + article_id;
        }


        /// <summary>
        /// 拼团人数存入缓存
        /// </summary>
        /// <returns></returns>
        public static string GetShopPingGroupCountKey()
        {
            return $"{prefix}Mark:shoppin_group_count:";
        }

        /// <summary>
        /// 商品拼团成功
        /// </summary>
        /// <returns></returns>
        public static string GetUserShoppingGroupKey()
        {
            return $"{prefix}Mark:user_shopping_group:";
        }


        /// <summary>
        /// 用户商城推荐提成奖励
        /// </summary>
        /// <returns></returns>
        public static string GetUserShopRecommendAwardKey()
        {
            return $"{prefix}Award:user_shop_recommend_award:";
        }

        /// <summary>
        /// 用户商城团队提成奖励
        /// </summary>
        /// <returns></returns>
        public static string GetUserShopTeamAwardKey()
        {
            return $"{prefix}Award:user_shop_team_award:";
        }

        /// <summary>
        /// 交易对kline信息缓存
        /// </summary>
        /// <returns></returns>
        public static string GetKlineCacheKey(string symbol, string period, int page = 1)
        {
            return $"{prefix}List:Kline:{symbol}:{period}:page:{page}";
        }

        #region 奖励相关

        /// <summary>
        /// 类型天收益记录
        /// </summary>
        /// <returns></returns>
        public static string GetUserTodayBonusKey(string date_time, int award_id, int type_id)
        {
            return $"{prefix}Award:user_today_bonus_date_time:date:" + date_time + ":award:" + award_id + ":type_id:" + type_id;
        }


        /// <summary>
        /// 会员管理费
        /// </summary>
        /// <returns></returns>
        public static string GeReduceManageKey()
        {
            return $"{prefix}Mark:reduce_manage";
        }

        /// <summary>
        /// 推荐奖励
        /// </summary>
        /// <returns></returns>
        public static string GetUserRecommendAwardKey()
        {
            return $"{prefix}Mark:user_recommend_award:";
        }

        /// <summary>
        /// 星级奖励
        /// </summary>
        /// <returns></returns>
        public static string GetUserStarAwardKey()
        {
            return $"{prefix}Mark:user_star_award:";
        }

        /// <summary>
        /// ERC2.0充值转入TRC2.0
        /// </summary>
        /// <returns></returns>
        public static string GetUserRechargeErcToTrc()
        {
            return $"{prefix}Mark:user_recharge_erc_to_trc:";
        }

        /// <summary>
        /// 购买投资项目
        /// </summary>
        /// <returns></returns>
        public static string GetUserPeerCoachingAwardKey()
        {
            return $"{prefix}Award:user_peer_coaching_award:";
        }

        /// <summary>
        /// 会员标记实名
        /// </summary>
        /// <returns></returns>
        public static string GetUserVerifyKey()
        {
            return $"{prefix}Mark:user_verify";
        }

        /// 购买矿机
        /// </summary>
        /// <returns></returns>
        public static string GetUserBuyMinerKey()
        {
            return $"{prefix}Mark:user_buy_miner";
        }


        /// <summary>
        /// 用户天奖励
        /// </summary>
        /// <returns></returns>
        public static string GetUserTodayMinerAmountKey(string date_time)
        {
            return $"{prefix}Award:user_today_miner_amount_date_time:" + date_time;
        }

        /// <summary>
        /// 用户矿机奖励
        /// </summary>
        /// <returns></returns>
        public static string GetUserMinerTotalAmountKey(int user_id)
        {
            return $"{prefix}Award:user_miner_total_amount:" + user_id;
        }

        #endregion


        /// <summary>
        /// i18n
        /// </summary>
        /// <returns></returns>
        public static string GetI18nBaiDuListKey(string key)
        {
            return $"{prefix}List:i18nBaiDuList:{key}:";
        }

        public static string GetCurrencyRobotListKey()
        {
            return $"{prefix}List:currency_robot_list";
        }


        #region 会员级别相关

        /// <summary>
        /// 会员级别列表缓存Key
        /// </summary>
        /// <returns></returns>
        public static string GetMemberUserLevelListKey()
        {
            return $"{prefix}List:member_user_level_list";
        }

        /// <summary>
        /// 会员级别缓存Key
        /// </summary>
        /// <returns></returns>
        public static string GetMemberUserLevelModelKey(int id)
        {
            return $"{prefix}Model:member_user_level_model:{id}";
        }

        #endregion


        #region 区域城市相关

        /// <summary>
        /// 城市级别列表缓存Key
        /// </summary>
        /// <returns></returns>
        public static string GetCmsCityLevelListKey()
        {
            return $"{prefix}List:cms_city_level_list";
        }

        /// <summary>
        /// 城市列表缓存Key
        /// </summary>
        /// <returns></returns>
        public static string GetCmsCityManageListKey()
        {
            return $"{prefix}List:cms_city_manage_list";
        }

        /// <summary>
        /// 城市区域列表缓存Key
        /// </summary>
        /// <returns></returns>
        public static string GetCmsCityRegionListKey()
        {
            return $"{prefix}List:cms_city_region_list";
        }

        #endregion
    }
}

