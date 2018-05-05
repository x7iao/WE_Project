using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    /// <summary>
    /// 富达币配置
    /// </summary>
    public class FDConfig
    {
        /// <summary>
        /// 大盘名称ABCD
        /// </summary>
        public string FDName { get; set; }

        /// <summary>
        /// 拆分倍数
        /// </summary>
        public decimal FDCFFloat { get; set; }

        /// <summary>
        /// EP拨出
        /// </summary>
        public decimal FDMHBFloat { get; set; }

        /// <summary>
        /// FD拨出
        /// </summary>
        public decimal FDMGPFloat { get; set; }

        /// <summary>
        /// 购物币拨出
        /// </summary>
        public decimal FDMCWFloat { get; set; }

        /// <summary>
        /// 大盘发行
        /// </summary>
        public int FDSellCount { get; set; }

        /// <summary>
        /// 发行价格
        /// </summary>
        public decimal FDPrice { get; set; }

        /// <summary>
        /// 开盘时间
        /// </summary>
        public DateTime FDStartTime { get; set; }

        /// <summary>
        /// 关盘时间
        /// </summary>
        public DateTime FDEndTime { get; set; }

        /// <summary>
        /// 关盘提示
        /// </summary>
        public string FDCloseRemark { get; set; }

        /// <summary>
        /// 大盘状态
        /// </summary>
        public bool FDState { get; set; }

        /// <summary>
        /// 大盘状态
        /// </summary>
        public int ChaiFenCode { get; set; }

        public bool ISOpen
        {
            get
            {
                if (this.FDState && (DateTime.Now.TimeOfDay - this.FDStartTime.TimeOfDay).TotalSeconds > 0 && (DateTime.Now.TimeOfDay - this.FDEndTime.TimeOfDay).TotalSeconds < 0)
                    return true;
                return false;
            }
        }
    }
}
