using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Common
{
    public class FutureStatus
    {
        const string shortdelivery = "买入交割";
        const string forcedliquidationbuy = "买入强平";
        const string closeallshort = "买入全平";
        const string longdelivery = "卖出交割";
        const string forcedliquidationsell = "卖出强平";
        const string closealllong = "卖出全平";

        public static string GetFutureTradeTypeName(int type)
        {
            string str = string.Empty;
            switch (type)
            {
                case 1:
                    str = "开多";
                    break;
                case 2:
                    str = "开空";
                    break;
                case 3:
                    str = "平多";
                    break;
                case 4:
                    str = "平空";
                    break;
            }
            return str;
        }

        public static string GetFutureTradeTypeString(int type, int systemType)
        {
            string str = string.Empty;
            switch (type)
            {
                case 1:
                    str = "买入开多";
                    switch (systemType)
                    {
                        case 1:
                            str = shortdelivery;
                            break;
                        case 2:
                            str = forcedliquidationbuy;
                            break;
                        case 3:
                            str = "买入强减";
                            break;
                        case 4:
                            str = closeallshort;
                            break;
                        case 5:
                            str = "系统反单";
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    str = "卖出开空";
                    switch (systemType)
                    {
                        case 1:
                            str = longdelivery;
                            break;
                        case 2:
                            str = forcedliquidationsell;
                            break;
                        case 3:
                            str = "卖出强减";
                            break;
                        case 4:
                            str = closealllong;
                            break;
                        case 5:
                            str = "系统反单";
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    str = "卖出平多";
                    switch (systemType)
                    {
                        case 1:
                            str = longdelivery;
                            break;
                        case 2:
                            str = forcedliquidationsell;
                            break;
                        case 3:
                            str = "卖出强减";
                            break;
                        case 4:
                            str = closealllong;
                            break;
                        case 5:
                            str = "系统反单";
                            break;
                        default:
                            break;
                    }
                    break;
                case 4:
                    str = "买入平空";
                    switch (systemType)
                    {
                        case 1:
                            str = shortdelivery;
                            break;
                        case 2:
                            str = forcedliquidationbuy;
                            break;
                        case 3:
                            str = "买入强减";
                            break;
                        case 4:
                            str = closeallshort;
                            break;
                        case 5:
                            str = "系统反单";
                            break;
                        default:
                            break;
                    }
                    break;
            }
            return str;
        }

        /// <summary>
        /// 普通委托状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetFutureTradeStatusString(int status)
        {
            string str = string.Empty;
            switch (status)
            {
                case 0:
                    str = "等待成交";
                    break;
                case 1:
                    str = "部分成交";
                    break;
                case 2:
                    str = "完全成交";
                    break;
                case 3:
                    str = "已委托";
                    break;
                case 4:
                    str = "暂停";
                    break;
                case -1:
                    str = "已撤销";
                    break;
                case -2:
                    str = "委托失败";
                    break;
            }
            return str;
        }

        /// <summary>
        /// 计划委托状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetFutureTradeListPlanStatusString(int status)
        {
            string str = string.Empty;
            switch (status)
            {
                case 0:
                    str = "等待委托";
                    break;
                case 1:
                    str = "已委托";
                    break;
                case -1:
                    str = "已撤销";
                    break;
                case -2:
                    str = "委托失败";
                    break;
            }
            return str;
        }

    }
}
