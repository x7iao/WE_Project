using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    /// <summary>
    /// EP交易表
    /// </summary>
    public class EPList
    {
        public int EPID { get; set; }
        /// <summary>
        /// 卖方
        /// </summary>
        public string SellMID { get; set; }
        /// <summary>
        /// 挂卖日期
        /// </summary>
        public DateTime SellDate { get; set; }
        /// <summary>
        /// 交易币种
        /// </summary>
        public string MoneyType { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 交易状态0挂单中，1订购中，2等待交易，3交易已完成，4交易已关闭
        /// </summary>
        public int SellState { get; set; }
        /// <summary>
        /// 买方MID
        /// </summary>
        public string BuyMID { get; set; }
        /// <summary>
        /// 购买日期
        /// </summary>
        public DateTime? BuyDate { get; set; }
        /// <summary>
        /// 买方最后操作日期
        /// </summary>
        public DateTime? LastBuyDate { get; set; }
        /// <summary>
        /// 卖方最后操作日期
        /// </summary>
        public DateTime? LastSellDate { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal TakeOffMoney { get; set; }
    }
}
