using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dang.Common
{
    public class VIPStatus
    {
        public static string GetTradeStatus(int status)
        {
            string result = string.Empty;
            switch (status)
            {
                case 0:
                    result = "等待中";
                    break;
                case 1:
                    result = "交易中";
                    break;
                case 2:
                    result = "已完成";
                    break;
                case 3:
                    result = "已作废";
                    break;
                case 4:
                    result = "已取消";
                    break;
                default:
                    result = "等待中";
                    break;
            }
            return result;
        }

        /// <summary>
        /// 发布交易订单状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetTradeOrderStatus(int status)
        {
            string result = string.Empty;
            switch (status)
            {
                case 0:
                    result = "待打款";
                    break;
                case 1:
                    result = "待确认";
                    break;
                case 2:
                    result = "已完成";
                    break;
                case 3:
                    result = "申诉中";
                    break;
                case 4:
                    result = "已超时";
                    break;
                case 5:
                    result = "已取消";
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// 交易成交状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetTradeDetailsStatus(int status)
        {
            string result = string.Empty;
            switch (status)
            {
                case 0:
                    result = "待打款";
                    break;
                case 1:
                    result = "待确认";
                    break;
                case 2:
                    result = "已完成";
                    break;
                case 3:
                    result = "申诉中";
                    break;
                case 4:
                    result = "已超时";
                    break;
                case 5:
                    result = "已取消";
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// 获取发布法币和币币交易冻结类型
        /// </summary>
        /// <param name="account_id"></param>
        /// <returns></returns>
        public static (int, int) GetTradeFreezeType(int account_id)
        {
            switch (account_id)
            {
                case 1:
                    return (1, 2);
                case 5:
                    return (50, 51);
                case 6:
                    return (60, 61);
                case 7:
                    return (70, 71);
                case 8:
                    return (1, 2);
                case 9:
                    return (3014, 3015);
                case 10:
                    return (50, 51);
                case 11:
                    return (60, 61);
                case 12:
                    return (70, 71);
                case 15:
                    return (90, 91);
                case 16:
                    return (80, 81);
                default:
                    return (0, 0);
            }
        }

        /// <summary>
        /// 返回委托方式
        /// </summary>
        /// <param name="trustType"></param>
        /// <returns></returns>
        public static string GetTrustType(int trustType)
        {
            switch (trustType)
            {
                case 1:
                    return "限价委托";
                case 2:
                    return "市价委托";
                case 3:
                    return "止盈止损";
                default:
                    return string.Empty;
            }
        }

    }

    public class VIPSysEnums
    {

        public enum AwardFengdingUserType
        {
            /// <summary>
            /// 算力
            /// </summary>
            CalcPower = 0,
            /// <summary>
            /// 分享算力
            /// </summary>
            SharePower = 1,
            /// <summary>
            /// 配售额度
            /// </summary>
            RationPower = 3
        }

        /// <summary>
        /// 账户类型
        /// </summary>
        public enum AccountType
        {
            /// <summary>
            /// 系统账户
            /// </summary>
            [Description("系统账户")]
            System = 0,
            /// <summary>
            /// 币币账户
            /// </summary>
            [Description("币币账户")]
            Currency = 1,
            /// <summary>
            /// 法币账户
            /// </summary>
            [Description("法币账户")]
            Fiat = 2,
            /// <summary>
            /// 合约账户
            /// </summary>
            [Description("合约账户")]
            Future = 3
        }

        /// <summary>
        /// 币种类型
        /// </summary>
        public enum BlockchainType
        {
            /// <summary>
            /// 系统
            /// </summary>
            [Description("系统")]
            System = 0,
            /// <summary>
            /// BTC
            /// </summary>
            [Description("BTC")]
            BTC = 1,
            /// <summary>
            /// BTCToken
            /// </summary>
            [Description("BTCToken")]
            BTCToken = 2,
            /// <summary>
            /// ETH
            /// </summary>
            [Description("ETH")]
            ETH = 3,
            /// <summary>
            /// ETHToken
            /// </summary>
            [Description("ETHToken")]
            ETHToken = 4,
            /// <summary>
            /// TRX
            /// </summary>
            [Description("TRX")]
            TRX = 5,
            /// <summary>
            /// TRXToken
            /// </summary>
            [Description("TRXToken")]
            TRXToken = 6,
            /// <summary>
            /// EOS
            /// </summary>
            [Description("EOS")]
            EOS = 7,
            /// <summary>
            /// XRP
            /// </summary>
            [Description("XRP")]
            XRP = 8
        }

        /// <summary>
        /// 交易对类型
        /// </summary>
        public enum CurrencyType
        {
            /// <summary>
            /// 法币交易
            /// </summary>
            [Description("法币交易")]
            TradeTransaction = 1,
            /// <summary>
            /// 币币交易
            /// </summary>
            [Description("币币交易")]
            CurrencyTransaction = 2,
            /// <summary>
            /// 合约交易
            /// </summary>
            [Description("合约交易")]
            FutureTransaction = 3
        }

        /// <summary>
        /// 法币交易类型
        /// </summary>
        public enum TradeType
        {
            /// <summary>
            /// 买入
            /// </summary>
            [Description("买入")]
            Buy = 1,
            /// <summary>
            /// 卖出
            /// </summary>
            [Description("卖出")]
            Sell = 2
        }

        /// <summary>
        /// 币币委托类型
        /// </summary>
        public enum TradeTrustType
        {
            /// <summary>
            /// 限价委托
            /// </summary>
            [Description("限价委托")]
            LimitOrder = 1,

            /// <summary>
            /// 市价委托
            /// </summary>
            [Description("市价委托")]
            MarketOrder = 2,

            /// <summary>
            /// 止盈止损
            /// </summary>
            [Description("止盈止损")]
            StopLimit = 3
        }

        public enum InOutType
        {
            待定 = 0,
            入库 = 1,
            出库 = 2,
            代理商购买 = 3,
            发布交易出售 = 4,
            交易购买成交 = 5,
            交易订单撤消 = 6,
            用户提货 = 7,
            代理商赠送 = 8,
            会员购买 = 9,
        }


        /// <summary>
        /// 钱包交易类型
        /// </summary>
        public enum WalletTradeType
        {
            /// <summary>
            /// 兑换
            /// </summary>
            Exchange = 3,
            /// <summary>
            /// 转出
            /// </summary>
            SendOut = 1,
            /// <summary>
            /// 转入
            /// </summary>
            SendIn = 2,
            /// <summary>
            /// 矿机收益
            /// </summary>
            Storage = 4,
            /// <summary>
            /// 提取
            /// </summary>
            Extract = 5,
            /// <summary>
            /// 手续费
            /// </summary>
            Cost = 6,
            /// <summary>
            /// 交易
            /// </summary>
            Trade = 7,
            /// <summary>
            /// 购物支付
            /// </summary>
            Shopping = 8,
            /// <summary>
            /// 矿机收益
            /// </summary>
            MinerProfit = 9,
            /// <summary>
            /// 购买矿机
            /// </summary>
            BuyMiner = 10,

        }

        /// <summary>
        /// 合约订单类型
        /// </summary>
        public enum FutureType
        {
            /// <summary>
            /// 开多
            /// </summary>
            OpenLong = 1,
            /// <summary>
            /// 开空
            /// </summary>
            OpenShort = 2,
            /// <summary>
            /// 平多
            /// </summary>
            CloseLong = 3,
            /// <summary>
            /// 平空
            /// </summary>
            CloseShort = 4
        }

        /// <summary>
        /// 统一管理操作枚举
        /// </summary>
        [Flags]
        public enum ActionEnum
        {
            /// <summary>
            /// 查看
            /// </summary>
            [Description("查看")]
            View = 1,
            /// <summary>
            /// 添加
            /// </summary>
            [Description("添加")]
            Add = 2,
            /// <summary>
            /// 修改
            /// </summary>
            [Description("修改")]
            Edit = 4,
            /// <summary>
            /// 删除
            /// </summary>
            [Description("删除")]
            Delete = 8,
            /// <summary>
            /// 审核
            /// </summary>
            [Description("审核")]
            Audit = 16,
            /// <summary>
            /// 回复
            /// </summary>
            [Description("回复")]
            Reply = 32,
            /// <summary>
            /// 确认
            /// </summary>
            [Description("确认")]
            Confirm = 64,
            /// <summary>
            /// 取消
            /// </summary>
            [Description("取消")]
            Cancel = 128,
            /// <summary>
            /// 作废
            /// </summary>
            [Description("作废")]
            Invalid = 256,
            /// <summary>
            /// 生成
            /// </summary>
            [Description("生成")]
            Build = 512,
            /// <summary>
            /// 备份
            /// </summary>
            [Description("备份")]
            Back = 1024,
            /// <summary>
            /// 还原
            /// </summary>
            [Description("还原")]
            Restore = 2048,
            /// <summary>
            /// 替换
            /// </summary>
            [Description("替换")]
            Replace = 4096,
            /// <summary>
            /// 复制
            /// </summary>
            [Description("复制")]
            Copy = 8192
        }
    }
}
