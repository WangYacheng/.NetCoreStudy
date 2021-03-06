using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Common
{
    public class VIPKeys
    {
        //系统版本
        /// <summary>
        /// 版本号全称
        /// </summary>
        public const string ASSEMBLY_VERSION = "4.0.0";
        /// <summary>
        /// 版本年号
        /// </summary>
        public const string ASSEMBLY_YEAR = "2015";

        //File======================================================
        /// <summary>
        /// 插件配制文件名
        /// </summary>
        public const string FILE_PLUGIN_XML_CONFING = "plugin.config";
        /// <summary>
        /// 站点配置文件名
        /// </summary>
        public const string FILE_SITE_XML_CONFING = "Configpath";
        /// <summary>
        /// URL配置文件名
        /// </summary>
        public const string FILE_URL_XML_CONFING = "Urlspath";
        /// <summary>
        /// 用户配置文件名
        /// </summary>
        public const string FILE_USER_XML_CONFING = "Userpath";
        /// <summary>
        /// 订单配置文件名
        /// </summary>
        public const string FILE_ORDER_XML_CONFING = "Orderpath";
        /// <summary>
        /// 升级代码
        /// </summary>
        public const string FILE_URL_UPGRADE_CODE = "267C2643EE401DD2F0A06084F7931C4DEC76E7CAA1996481FE8F5081A8936409058D07A6F5E2941C";
        /// <summary>
        /// 消息代码
        /// </summary>
        public const string FILE_URL_NOTICE_CODE = "267C2643EE401DD2F0A06084F7931C4DEC76E7CAA1996481FE8F5081A8936409D037BEA6A623A0A1";
        /// <summary>
        /// 原始快递单
        /// </summary>
        public const string FILE_ORIGINAL_COURIER_RECEIPT = "base.grf";

        //Directory==================================================
        /// <summary>
        /// ASPX目录名
        /// </summary>
        public const string DIRECTORY_REWRITE_ASPX = "aspx";
        /// <summary>
        /// HTML目录名
        /// </summary>
        public const string DIRECTORY_REWRITE_HTML = "html";
        /// <summary>
        /// 插件目录名
        /// </summary>
        public const string DIRECTORY_REWRITE_PLUGIN = "plugin";
        /// <summary>
        /// 原始快递单目录名
        /// </summary>
        public const string DIRECTORY_ORIGINAL_COURIER_RECEIPT = "basegrf";
        /// <summary>
        /// 生成快递单目录名
        /// </summary>
        public const string DIRECTORY_COURIER_RECEIPT = "grf";

        //Cache======================================================
        /// <summary>
        /// 站点配置
        /// </summary>
        public const string CACHE_SITE_CONFIG = "vip_cache_site_config";
        /// <summary>
        /// 用户配置
        /// </summary>
        public const string CACHE_USER_CONFIG = "vip_cache_user_config";
        /// <summary>
        /// 订单配置
        /// </summary>
        public const string CACHE_ORDER_CONFIG = "vip_cache_order_config";
        /// <summary>
        /// 微信支付
        /// </summary>
        public const string CACHE_PAY_WEIXIN = "vip_cache_pay_weixin";
        /// <summary>
        /// HttpModule映射类
        /// </summary>
        public const string CACHE_SITE_HTTP_MODULE = "vip_cache_http_module";
        /// <summary>
        /// 绑定域名
        /// </summary>
        public const string CACHE_SITE_HTTP_DOMAIN = "vip_cache_http_domain";
        /// <summary>
        /// 站点一级目录名
        /// </summary>
        public const string CACHE_SITE_DIRECTORY = "vip_cache_site_directory";
        /// <summary>
        /// 站点ASPX目录名
        /// </summary>
        public const string CACHE_SITE_ASPX_DIRECTORY = "vip_cache_site_aspx_directory";
        /// <summary>
        /// URL重写映射表
        /// </summary>
        public const string CACHE_SITE_URLS = "vip_cache_site_urls";
        /// <summary>
        /// URL重写LIST列表
        /// </summary>
        public const string CACHE_SITE_URLS_LIST = "vip_cache_site_urls_list";
        /// <summary>
        /// 升级通知
        /// </summary>
        //public const string CACHE_OFFICIAL_UPGRADE = "vip_official_upgrade";
        /// <summary>
        /// 官方消息
        /// </summary>
        //public const string CACHE_OFFICIAL_NOTICE = "vip_official_notice";

        //Session=====================================================
        /// <summary>
        /// 网页验证码
        /// </summary>
        public const string SESSION_CODE = "vip_session_code";
        /// <summary>
        /// 短信验证码
        /// </summary>
        public const string SESSION_SMS_CODE = "vip_session_sms_code";
        /// <summary>
        /// 后台管理员
        /// </summary>
        public const string SESSION_ADMIN_INFO = "vip_session_admin_info";
        /// <summary>
        /// 会员用户
        /// </summary>
        public const string SESSION_USER_INFO = "vip_session_user_info";
        /// <summary>
        /// 会员用户
        /// </summary>
        public const string SESSION_EXPORT_COLUMN_NAME = "vip_session_export_column_name";

        //Cookies=====================================================
        /// <summary>
        /// 防重复顶踩KEY
        /// </summary>
        public const string COOKIE_DIGG_KEY = "vip_cookie_digg_key";
        /// <summary>
        /// 防重复评论KEY
        /// </summary>
        public const string COOKIE_COMMENT_KEY = "vip_cookie_comment_key";
        /// <summary>
        /// 记住会员用户名
        /// </summary>
        public const string COOKIE_USER_NAME_REMEMBER = "vip_cookie_user_name_remember";
        /// <summary>
        /// 记住会员密码
        /// </summary>
        public const string COOKIE_USER_PWD_REMEMBER = "vip_cookie_user_pwd_remember";
        /// <summary>
        /// 用户手机号码
        /// </summary>
        public const string COOKIE_USER_MOBILE = "vip_cookie_user_mobile";
        /// <summary>
        /// 用户电子邮箱
        /// </summary>
        public const string COOKIE_USER_EMAIL = "vip_cookie_user_email";
        /// <summary>
        /// 购物车
        /// </summary>
        public const string COOKIE_SHOPPING_CART = "vip_cookie_shopping_cart";
        /// <summary>
        /// 结账清单
        /// </summary>
        public const string COOKIE_SHOPPING_BUY = "vip_cookie_shopping_buy";
        /// <summary>
        /// 购物车
        /// </summary>
        public const string COOKIE_SHOPPING_CART_REGISTER = "vip_cookie_shopping_cart_register";
        /// <summary>
        /// 结账清单
        /// </summary>
        public const string COOKIE_SHOPPING_BUY_REGISTER = "vip_cookie_shopping_buy_register";
        /// <summary>
        /// 返回上一页
        /// </summary>
        public const string COOKIE_URL_REFERRER = "vip_cookie_url_referrer";

        /// <summary>
        /// 二级密码
        /// </summary>
        public const string SESSION_USER_PASSWORD2 = "vip_session_user_password2";
        /// <summary>
        /// 后台二级密码
        /// </summary>
        public const string SESSION_ADMIN_USER_PASSWORD2 = "vip_session_admin_user_password2";
        /// <summary>
        /// 上次地址
        /// </summary>
        public const string SESSION_USER_TURL = "vip_session_user_turl";
        /// <summary>
        /// 上次地址
        /// </summary>
        public const string SESSION_ADMIN_USER_TURL = "vip_session_admin_user_turl";

        /// <summary>
        /// 自动审核或者是手动审核
        /// </summary>
        public const string SYS_AUTO_ADUIT_CURRENCY_DRAW = "auto_aduit_currency_tx";

        /// <summary>
        /// APP首页视频地址
        /// </summary>
        public const string SYS_PAGE_VOIDE_URL = "frist_page_voide_url";

        /// <summary>
        /// 设置服务每次生成的补充记录部分
        /// </summary>
        public const string AUTO_DATA_COUNT_DTRAW_ADDRESS = "auto_data_count_draw_address";
        /// <summary>
        /// 排队奖励百分比
        /// </summary>
        public const string UTC_LINE_UP_RAWARD = "utc_line_up_reward";
        /// <summary>
        /// 交易限制白名单设置
        /// </summary>
        public const string UTC_TRAD_NO_EQU_USERIDS = "utc_trad_amout_with_no_equ_userids";
        /// <summary>
        /// 是否开启手动审核交易
        /// </summary>
        public const string UTC_AUTO_TRADE_MAPPING = "utc_auto_trade_mapping";


        /// <summary>
        /// 玩家取消交易，超时取消记录标记识别
        /// 0 用户id 1 数据类型 （0 正常取消，超时取消 1 延时30分钟，的取消）
        /// </summary>
        public const string USER_UTC_CANEL_TRADE = "userid_{0}_{1}_utc_canel_trade";

        /// <summary>
        /// 玩家取消交易，超时取消记录标记识别
        /// 0 用户取消连续取消多天内次数 1 延时取消连续多少天，多少次
        /// </summary>
        public const string USER_UTC_CANEL_TRADE_SETTING = "canel_trade_{0}_setting_utc";


        /// <summary>
        /// 交易行情列表 保存10秒
        /// </summary>
        public const string USER_TRADE_DETIAL_LIIST = "sq_9208_system_user_trade_detial_list_forten_seconds";
        /// <summary>
        /// 交易行情列表 保存10秒
        /// </summary>
        public const string USER_TRADE_DETIAL_NEW_LIIST = "sq_9208_system_user_trade_new_detial_list_forten_seconds";
        /// <summary>
        /// K线图 保存10秒
        /// </summary>
        public const string UTC_MARKT_LIN_LIIST = "sq_9208_system_utc_markt_list_forten_seconds_{0}";
        /// <summary>
        /// 交易价格变动行情列表 保存10秒
        /// </summary>
        public const string USER_TRADE_DETIAL_PRICE_LIIST = "sq_9208_system_user_trade_detial_price_list_frive_seconds_{0}";


        /// <summary>
        /// UTC代币挂买最高匹配订单额度设置
        /// </summary>
        public const string UTC_TRADE_ORDER_LIMIT_AMOUNT = "UTC_TRADE_ORDER_LIMIT_AMOUNT";

        /// <summary>
        /// 币东设置 平台利润值
        /// </summary>
        public const string SYSTEM_PROFIT_AMOUNT = "SYSTEM_PROFIT_AMOUNT";

        /// <summary>
        /// 币东设置编号
        /// </summary>
        public const string SYS_BIDONG_NO_INCRIPT_NO = "SYS_BIDONG_NO_INCRIPT_NO";

        /// <summary>
        /// OTC限价
        /// </summary>
        public const string SYS_OTC_PRICE_UP_DOWN_RATE = "SYS_OTC_PRICE_UP_DOWN_RATE";

        /// <summary>
        /// OTC交易限制账户类型涨跌幅
        /// </summary>
        public const string OTC_DOWN_UP_REWARD_RATE = "OTC_PRICE_RATE_{0}";

        /// <summary>
        /// OTC交易限制账户类型涨跌幅
        /// </summary>
        public const string OTC_SHOP_FROZEN_NUM = "otc_shop_frozen_num";

        /// <summary>
        /// 交易行情设置
        /// </summary>
        public const string KLINE_MARKET_PRICE_SETTING = "KLINE_MARKET_PRICE_SETTING_{0}";

        /// <summary>
        /// 配售购买获取比例
        /// </summary>
        public const string SYS_RATION_BUY_RATE = "ration_buy_rate";

        /// <summary>
        /// 配售购买获取比例
        /// </summary>
        public const string SYS_RATION_PERIOD = "ration_period";

        /// <summary>
        /// 卖出配售扣除比例
        /// </summary>
        public const string SYS_RATION_SELL_RATE = "ration_sell_rate";

        /// <summary>
        /// 是否开启配售消耗
        /// </summary>
        public const string SYS_RATION_ENABLE = "ration_enable";

        /// <summary>
        /// 配售团队挖矿最低配售中余额
        /// </summary>
        public const string SYS_RATION_TEAM_MIN_RATIONING = "ration_team_min_rationing";

        /// <summary>
        /// 推荐激活区购买配售比例
        /// </summary>
        public const string SYS_RATION_RECOMMEND_RATE = "ration_recommend_rate";

        /// <summary>
        /// 配售团队挖矿代数
        /// </summary>
        public const string SYS_RATION_TEAM_LAYER = "ration_team_layer";

        /// <summary>
        /// 配售团队挖矿代数
        /// </summary>
        public const string SYS_RATION_ISSUE_RATE = "ration_issue_rate";

        /// <summary>
        /// 投入配售中最小数量
        /// </summary>
        public const string SYS_MIN_QUOTA_QUA = "min_quota_qua";

        /// <summary>
        /// 投入配售中最大数量
        /// </summary>
        public const string SYS_MAX_QUOTA_QUA = "max_quota_qua";

        /// <summary>
        /// 矿机最少配售中
        /// </summary>
        public const string SYS_MINER_MIN_QUOTA = "miner_min_quota";

        /// <summary>
        /// 配售动态收益封顶倍数
        /// </summary>
        public const string SYS_TIMES_QUOTA_DYNAMIC_AWARD = "times_quota_dynamic_award";

        /// <summary>
        /// UTC第一次买入最大数量(币币、法币)
        /// </summary>
        public const string SYS_USER_FIRST_BUY_MAX_NUM = "user_first_buy_max_num";

        /// <summary>
        /// 撮合买入成功后，多少分钟之内必须要支付并上传付款截图
        /// </summary>
        public const string MATCH_BUY_PAYMENT_TIME = "match_buy_payment_time";

        /// <summary>
        /// 买方支付成功后，多少分钟之内必须要手动确认，过时将自动确认
        /// </summary>
        public const string MATCH_SELL_PAYMENT_TIME = "match_sell_payment_time";

        /// <summary>
        /// 是否启用交易短信通知
        /// </summary>
        public const string TRADE_SMS_NOTICE = "trade_sms_notice";

        /// <summary>
        /// 有买入的交易后，允许发布卖出间隔时间
        /// </summary>
        public const string PUBLISH_SELL_INTERVAL = "publish_sell_interval";

        /// <summary>
        /// 买入撮合的未完成数
        /// </summary>
        public const string MATCH_BUY_INCOMPLETE_NUMBER = "match_buy_incomplete_number";

        /// <summary>
        /// 卖出撮合的未完成数
        /// </summary>
        public const string MATCH_SELL_INCOMPLETE_NUMBER = "match_sell_incomplete_number";

        /// <summary>
        /// 可取消交易次数,撮合成功的交易，每天用户可以取消几次,超过就停止撮合
        /// </summary>
        public const string CANCEL_TRADE_NUMBER = "cancel_trade_number";

        /// <summary>
        /// 是否白名单匹配,白名单用户才会互相进行交易匹配
        /// </summary>
        public const string MATCH_IS_WHITE = "match_is_white";

        /// <summary>
        /// 是否黑名单匹配,黑名单用户才会互相进行交易匹配
        /// </summary>
        public const string MATCH_IS_BLACK = "match_is_black";


        /// <summary>
        /// OTC发布购买是否验证是否是商家
        /// </summary>
        public const string OTC_BUY_IS_VERIFY = "otc_buy_is_verify";

        /// <summary>
        /// 数据宝图片API
        /// </summary>
        public const string CHINADATAPAY_IMG_API = "chinadatapay_img_api";

        /// <summary>
        /// 数据宝key
        /// </summary>
        public const string CHINADATAPAY_KEY = "chinadatapay_key";

        /// <summary>
        /// 身份证认证数
        /// </summary>
        public const string ID_CARD_VERIFY_NUM = "id_card_verify_num";

        /// <summary>
        /// 数据宝人像比对API
        /// </summary>
        public const string CHINADATAPAY_VERIFY_API = "chinadatapay_verify_api";
        /// <summary>
        /// 数据宝密钥
        /// </summary>
        public const string CHINADATAPAY_SECRET_KEY = "chinadatapay_secret_key";

        /// <summary>
        /// 直推总计多少矿机获得同类型矿机
        /// </summary>
        public const string USER_SHARE_MINER_BASE_NUM = "user_share_miner_base_num";

        /// <summary>
        /// 开启人脸认证,不启用身份证人工实名
        /// </summary>
        public const string USER_FACE_VERIFY = "user_face_verify";

        /// <summary>
        /// 大单区数量区间
        /// </summary>
        public const string OTC_MAX_AMOUNT = "otc_max_amount";

        /// <summary>
        /// 小单区数量区间
        /// </summary>
        public const string OTC_MIN_AMOUNT = "otc_min_amount";

        /// <summary>
        /// OTC交易出售手续费
        /// </summary>
        public const string OTC_SELL_FEE = "otc_sell_fee";

        /// <summary>
        /// 图片上传位置
        /// </summary>
        public const string IMAGE_UPLOAD_ADDRESS = "image_upload_address";

        /// <summary>
        /// 文件图片版本号
        /// </summary>
        public const string FILE_AND_IMAGE_VERSION = "file_and_image_version";

        /// <summary>
        /// 接口地址
        /// </summary>
        public const string API_URL = "api_url";

        /// <summary>
        /// H5推广地址
        /// </summary>
        public const string H5_URL = "h5_url";

        /// <summary>
        /// 图片访问地址
        /// </summary>
        public const string IMG_URL = "img_url";

        /// <summary>
        /// 人民币兑美元汇率
        /// </summary>
        public const string USD_CNY = "usd_cny";

        /// <summary>
        /// 大小单区卖出需要积分
        /// </summary>
        public const string OTC_MAX_MIN_POINT = "otc_max_min_point";

        /// <summary>
        /// 大单区是否要矿机
        /// </summary>
        public const string OTC_MAX_MINER = "otc_max_miner";

        /// <summary>
        /// 是否自动实名
        /// </summary>
        public const string IS_AUTO_VERIFY = "is_auto_verify";

        /// <summary>
        /// 后台操作API ,KEY
        /// </summary>
        public const string MANAGER_KEY = "manager_key";

        /// <summary>
        /// 管理费比例
        /// </summary>
        public const string REDUCE_MANAGE_RATIO = "reduce_manage_ratio";

        /// <summary>
        /// 激活码扣除金额
        /// </summary>
        public const string ACTIVATION_CODE = "activation_code";

        /// <summary>
        /// 激活码扣除金额
        /// </summary>
        public const string CALCULATION_RECHARGE = "calculation_recharge";

        /// <summary>
        /// 推荐五单
        /// </summary>
        public const string TEMP_RECOMMEND_FIVE = "temp_recommend_five";

        /// <summary>
        /// 推荐十单
        /// </summary>
        public const string TEMP_RECOMMEND_TEN = "temp_recommend_ten";

        /// <summary>
        /// 推荐
        /// </summary>
        public const string TEMP_RECOMMEND_ONE = "temp_recommend_one";


        /// <summary>
        /// 交易五单
        /// </summary>
        public const string TEMP_TRADE_FIVE = "temp_trade_five";

        /// <summary>
        /// 交易十单
        /// </summary>
        public const string TEMP_TRADE_TEN = "temp_trade_ten";

        /// <summary>
        /// 交易首单
        /// </summary>
        public const string TEMP_TRADE_ONE = "temp_trade_one";

        /// <summary>
        /// 推荐
        /// </summary>
        public const string TEMP_RECOMMEND = "temp_recommend";

        /// <summary>
        /// 交易
        /// </summary>
        public const string TEMP_TRADE = "temp_trade";

        /// <summary>
        /// 用户节点投票手续费
        /// </summary>
        public const string TEMP_NODE_VOTE_FEE = "temp_node_vote_fee";
        /// <summary>
        /// 节点投票节点奖励
        /// </summary>
        public const string TEMP_NODE_VOTE_NODE_REWARD = "temp_node_vote_node_reward";
        /// <summary>
        /// 节点投票退回比例
        /// </summary>
        public const string TEMP_NODE_VOTE_RETURN_RATE = "temp_node_vote_return_rate";

        /// <summary>
        /// 投票返回天数
        /// </summary>
        public const string TEMP_USER_VOTE_RETURN_DAY = "temp_user_vote_return_day";
        /// <summary>
        /// 投票返回比例
        /// </summary>
        public const string TEMP_USER_VOTE_RETURN_RATE = "temp_user_vote_return_rate";

        /// <summary>
        /// 执行付款收益减半
        /// </summary>
        public const string TEMP_SCHEDUING_PROFIT_REDUCE = "temp_scheduing_profit_reduce";
        /// <summary>
        /// 执行付款收益取消
        /// </summary>
        public const string TEMP_SCHEDUING_PROFIT_CANCEL = "temp_scheduing_profit_cancel";
        /// <summary>
        /// 执行尾款后多少小时结算
        /// </summary>
        public const string TEMP_SCHEDUING_PROFIT_SETTLEMENT_HOUR = "temp_scheduing_profit_settlement_hour";
        /// <summary>
        /// 定金比例
        /// </summary>
        public const string TEMP_DEPOSIT_RATIO = "temp_deposit_ratio";
        /// <summary>
        /// 每人每天预约抢单数量
        /// </summary>
        public const string DAY_ADD_USER_SCHEDULE_COUNT = "DAY_ADD_USER_SCHEDULE_COUNT";
        /// <summary>
        /// MACY转积分比例
        /// </summary>
        public const string MACY_CHANGE_INTEGRAL_RATIO = "MACY_CHANGE_INTEGRAL_RATIO";


        public const string SYS_DATE_TASK_BUY_MAX = "SYS_DATE_TASK_BUY_MAX";

        public const string SYS_TASK_BUY_FEE = "SYS_TASK_BUY_FEE";
        public const string SYS_TIMES_UTC_DYNAMIC_AWARD = "SYS_TIMES_UTC_DYNAMIC_AWARD";
        public const string SYS_USER_FIRST_BUY_AWARD_RATE = "SYS_USER_FIRST_BUY_AWARD_RATE";
        public const string SYS_TASK_USDTTO_SELL_HOUR = "SYS_TASK_USDTTO_SELL_HOUR";
        public const string SYS_DATE_TASK_SELL_MAX = "SYS_DATE_TASK_SELL_MAX";

        public const string SYS_TASK_BUY_TOUSDT_HOUR ="SYS_TASK_BUY_TOUSDT_HOUR";
        public const string SYS_TASK_PUB_NEED_APC ="SYS_TASK_PUB_NEED_APC";
        public const string SYS_TASK_IN_TOUSDT_HOUR ="SYS_TASK_IN_TOUSDT_HOUR";

        /// <summary>
        /// 系统客服账号ID
        /// </summary>
        public const string SYS_CUSTOMER_SERVICE_ID = "sys_customer_service_id";

        /// <summary>
        /// 服务通知账号ID
        /// </summary>
        public const string SYS_SERVICE_NOTIFY_ID = "sys_service_notify_id";
    }
}
