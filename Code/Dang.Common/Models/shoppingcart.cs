using System;
using System.Collections.Generic;
using System.Text;

namespace Dang.Common.Models
{
    /// <summary>
    /// 购物车实体类
    /// </summary>
    public partial class cart_keys
    {
        #region Model
        public int shop_id
        {
            get; set;
        }
        /// <summary>
        /// 文章ID
        /// </summary>
        public int article_id { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int goods_id { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int quantity { get; set; }
        #endregion
    }

    /// <summary>
    /// 购物车列表
    /// </summary>
    public partial class cart_items
    {
        #region Model
        public int shop_id
        {
            get; set;
        }
        /// <summary>
        /// 文章ID
        /// </summary>
        public int article_id { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int goods_id { get; set; }
        /// <summary>
        /// 商品货号
        /// </summary>
        public string goods_no { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 商品规格
        /// </summary>
        public string spec_text { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string img_url { get; set; }
        /// <summary>
        /// 销售单价
        /// </summary>
        public decimal sell_price { get; set; }
        /// <summary>
        /// 会员单价
        /// </summary>
        public decimal user_price { get; set; }
        /// <summary>
        /// 所需/获得综合积分
        /// </summary>
        public int point { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int quantity { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public int stock_quantity { get; set; }
        public decimal cost_price { get; set; }

        public decimal used_reg_money { get; set; }

        //public int is_screen { get; set; }

        /// <summary>
        /// 产品类别 1:投资产品    2:商城产品  3：积分产品
        /// </summary>
        public int goods_type { get; set; }

        /// <summary>
        /// 是否拼团产品
        /// </summary>
        public int is_group { get; set; }

        /// <summary>
        /// 拼团单价
        /// </summary>
        public decimal group_price { get; set; }
        #endregion
    }

    /// <summary>
    /// 购物车统计
    /// </summary>
    public partial class cart_total
    {

        #region Model

        /// <summary>
        /// 商品种数
        /// </summary>
        public int total_num { get; set; }
        /// <summary>
        /// 商品总数量
        /// </summary>
        public int total_quantity { get; set; }
        /// <summary>
        /// 应付商品总金额
        /// </summary>
        public decimal payable_amount { get; set; }
        /// <summary>
        /// 实付商品总金额
        /// </summary>
        public decimal real_amount { get; set; }
        /// <summary>
        /// 总综合积分
        /// </summary>
        public int total_point { get; set; }
        public decimal cost_amount { get; set; }

        /// <summary>
        /// 总抵扣
        /// </summary>
        public decimal total_used_reg_money { get; set; }

        /// <summary>
        /// 总拼团价格
        /// </summary>
        public decimal total_group_price { get; set; }
        #endregion
    }
}
