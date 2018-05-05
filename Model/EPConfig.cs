using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    /// <summary>
    /// EP配置
    /// </summary>
    public class EPConfig
    {
        /// <summary>
        /// EP状态
        /// </summary>
        public bool EPState { get; set; }

        /// <summary>
        /// 交易开始时间
        /// </summary>
        public DateTime EPStartTime { get; set; }

        /// <summary>
        /// 交易结束时间
        /// </summary>
        public DateTime EPEndTime { get; set; }

        /// <summary>
        /// 交易类型0任意金额，1限额最低，2以下金额
        /// </summary>
        public int EPJYType { get; set; }

        /// <summary>
        /// 最少交易金额
        /// </summary>
        public int EPJYMinMoney { get; set; }

        /// <summary>
        /// 最少交易金额倍数
        /// </summary>
        public int EPJYBaseMoney { get; set; }

        /// <summary>
        /// 以下交易金額
        /// </summary>
        public string EPMoneyStr { get; set; }

        /// <summary>
        /// 用户协议
        /// </summary>
        public string EPProtocol { get; set; }

        /// <summary>
        /// 交易币种
        /// </summary>
        public string EPMoneyType { get; set; }

        /// <summary>
        /// 超时时长（分钟）
        /// </summary>
        public int EPTimeOut { get; set; }

        /// <summary>
        /// 超时次数降星
        /// </summary>
        public int EPTimeOutCount { get; set; }

        /// <summary>
        /// 重复消费累计
        /// </summary>
        public int EPTimeOutJXCount { get; set; }

        /// <summary>
        /// EP交易级别
        /// </summary>
        public string EPJYMAgencyTypeStr { get; set; }

        /// <summary>
        /// EP交易手续费
        /// </summary>
        public decimal EPTakeOffMoney { get; set; }
    }
}
