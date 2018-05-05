using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    /// <summary>
    /// 运行检测
    /// </summary>
    public class FDSellList
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int SellID { get; set; }

        /// <summary>
        /// 卖方
        /// </summary>
        public string SellMID { get; set; }

        /// <summary>
        /// 挂卖数量200
        /// </summary>
        public int SellTotalCount { get; set; }

        /// <summary>
        /// 已交易100
        /// </summary>
        public int SellCount { get; set; }

        /// <summary>
        /// 交易价格
        /// </summary>
        public decimal SellPrice { get; set; }

        /// <summary>
        /// 已成交10
        /// </summary>
        public decimal SellMoney { get; set; }

        /// <summary>
        /// 交易完成日期
        /// </summary>
        public DateTime SellDate { get; set; }

        /// <summary>
        /// 最后售出时间
        /// </summary>
        public DateTime LastSellDate { get; set; }

        /// <summary>
        /// 交易状态0未交易，1交易中，2已成交，3清仓
        /// </summary>
        public int SellState { get; set; }

        /// <summary>
        /// 买入记录
        /// </summary>
        public int BuyID { get; set; }

        /// <summary>
        /// 买入大盘
        /// </summary>
        public string SellFDName { get; set; }

        /// <summary>
        /// 买入大盘
        /// </summary>
        public DateTime BuyDate { get; set; }
        /// <summary>
        /// 拆分批次号
        /// </summary>
        public int ChaiFenCode { get; set; }
    }
}
