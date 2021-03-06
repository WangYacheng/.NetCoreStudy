using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Common.Qiniu
{
    public class QnySetting
    {
        /// <summary>
        /// 是否开启七牛云
        /// </summary>
        public bool enabled { get; set; }
        /// <summary>
        /// 静态访问域名
        /// </summary>
        public string staticPath { get; set; }
        public string qiniuyunAK { get; set; }
        public string qiniuyunSK { get; set; }
        public string qiniuyunBucket { get; set; }
        public string prefixPath { get; set; }
        public string prefixUrl { get; set; }
    
    }
}
