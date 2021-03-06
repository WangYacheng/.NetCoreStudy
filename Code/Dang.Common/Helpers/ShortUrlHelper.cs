using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dang.Common.Helpers
{
    public class ShortUrlHelper
    {
        public class sina_short_url
        {
            public string url_short { get; set; }

            public string url_long { get; set; }
            public int type { get; set; }
        }

        /// <summary>
        /// 新浪转换短链接
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<string> Convert_SINA_Short_Url(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return "";
            }
            try
            {
                //api地址
                var address = "http://api.t.sina.com.cn/short_url/shorten.json?source=2815391962";
                address += "&url_long=" + HttpUtility.UrlEncode(url);
                //http请求
                var urls = await new Webs.Clients.WebClient().Get(address).ResultFromJsonAsync<List<sina_short_url>>();
                if (urls != null && urls.Count > 0)
                {
                    return urls[0].url_short;
                }
            }
            catch {

            }
            return url;
        }
    }
}
