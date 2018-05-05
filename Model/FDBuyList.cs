using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    /// <summary>
    /// 富达买入
    /// </summary>
    public class FDBuyList
    {
        /// <summary>
        /// ID
        /// </summary>
        public int BuyID { get; set; }

        /// <summary>
        /// 买方
        /// </summary>
        public string BuyMID { get; set; }

        /// <summary>
        /// 交易数量
        /// </summary>
        public int BuyCount { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal BuyMoney { get; set; }

        /// <summary>
        /// 交易日期
        /// </summary>
        public DateTime BuyDate { get; set; }

        /// <summary>
        /// 是否拆分
        /// </summary>
        public bool CFState { get; set; }

        /// <summary>
        /// 购买币种
        /// </summary>
        public string MoneyType { get; set; }

        /// <summary>
        /// 买入价格
        /// </summary>
        public decimal BuyPrice { get; set; }

        /// <summary>
        /// 交易状态0买入，1清盘
        /// </summary>
        public int BuyState { get; set; }

        /// <summary>
        /// 交易状态0买入，1清盘
        /// </summary>
        public string BuyStateStr
        {
            get
            {
                if (this.BuyState == 0)
                    return "正常买入";
                else
                    return "已清盘";
            }
        }

        /// <summary>
        /// 交易大厅
        /// </summary>
        public string BuyFDName { get; set; }
    }
}
