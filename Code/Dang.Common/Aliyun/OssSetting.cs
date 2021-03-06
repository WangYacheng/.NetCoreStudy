using System;
using System.Collections.Generic;
using System.Text;

namespace JLSys.Common.Aliyun
{
    public class OssSetting
    {
        /*
            var accessKeyId = "";
            var accessKeySecret = "";
            var endpoint = "oss-cn-shenzhen.aliyuncs.com";
            var bucketName = "service-img";
        */
        /// <summary>
        ///  Access Key 
        /// </summary>
        public string accessKeyId { get; set; }
        /// <summary>
        /// Secret Key
        /// </summary>
        public string accessKeySecret { get; set; }
        /// 节点
        /// 基本目录
        /// </summary>
        public string endpoint { get; set; }
        /// <summary>
        /// 空间名称
        /// </summary>
        public string bucketName { get; set; }

    }
}
