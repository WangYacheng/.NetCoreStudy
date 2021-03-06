using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Common.Caches
{
    public class BlockchainCacheKeys
    {
        const string prefix = "JLSys:Blockchain:";

        #region Eth

        /// <summary>
        /// 获取已扫描的最新高度
        /// </summary>
        /// <returns></returns>
        public static string GetEthScanLastHeightKey()
        {
            return $"{prefix}Eth:ScanHeight:scan_last_height";
        }

        #endregion

        #region Btc

        /// <summary>
        /// 获取已扫描的最新高度
        /// </summary>
        /// <returns></returns>
        public static string GetBtcScanLastHeightKey()
        {
            return $"{prefix}Btc:ScanHeight:scan_last_height";
        }

        #endregion

    }
}
