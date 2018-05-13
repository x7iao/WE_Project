using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    public class BMember
    {
        public int ID { get; set; }
        public string AMID { get; set; }
        /// <summary>
        /// 批次
        /// </summary>
        public string BMID { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string BMBD { get; set; }
       /// <summary>
       /// 创建时间
       /// </summary>
        public DateTime BMCreateDate { get; set; }
        /// <summary>
        /// 初始值为创建日期：出局日期
        /// </summary>
        public DateTime BMDate { get; set; }
        /// <summary>
        /// 是否出局
        /// </summary>
        public bool BMState { get; set; }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool BIsClock { get; set; }
        /// <summary>
        /// 购买的股数
        /// </summary>
        public decimal YJCount { get; set; }
        /// <summary>
        /// 已分红的金额
        /// </summary>
        public decimal YJMoney { get; set; }
        /// <summary>
        /// 日分红金额
        /// </summary>
        public decimal BCount { get; set; }
        /// <summary>
        /// 出局天数
        /// </summary>
        public decimal BOutMoney { get; set; }
        public Member AMember { get; set; }
        /// <summary>
        /// 该股已分红的天数
        /// </summary>
        public int FHDays { get; set; }
    }
}
