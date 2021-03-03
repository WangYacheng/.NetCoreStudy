using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Dang.Domain.Core.Models;
namespace Dang.Domain.Models
{
    public class RelationDang:DangEntity<RelationDang,int>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名")]
        [Core.Dapper.Column(Name ="name")]
        public int Name { get; set; }
        /// <summary>
        /// 关系类型
        /// </summary>
        [DisplayName("关系类型")]
        [Core.Dapper.Column(Name = "relation_type")]
        public int RelationType { get; set; }
        /// <summary>
        /// 当评价
        /// </summary>
        [DisplayName("当评价")]
        [Core.Dapper.Column(Name = "estimate_dang")]
        public decimal EstimateDang { get; set; }
        /// <summary>
        /// 其他评价
        /// </summary>
        [DisplayName("其他评价")]
        [Core.Dapper.Column(Name = "estimate_other")]
        public string EstimateOther { get; set; }


        /// <summary>
        /// 关系类型
        /// </summary>
        [DisplayName("修改时间")]
        [Core.Dapper.Column(Name = "update_time")]
        public int UpdateTime { get; set; }
        /// <summary>
        /// 当评价
        /// </summary>
        [DisplayName("备注")]
        [Core.Dapper.Column(Name = "remark")]
        public decimal Remark { get; set; }

    }
}
