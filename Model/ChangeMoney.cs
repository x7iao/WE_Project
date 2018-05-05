using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    public class ChangeMoney
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int CID { get; set; }
        /// <summary>
        /// 来自会员账号
        /// </summary>
        public string FromMID { get; set; }
        /// <summary>
        /// 去向会员账号
        /// </summary>
        public string ToMID { get; set; }
        /// <summary>
        /// 货币数目
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime ChangeDate { get; set; }
        /// <summary>
        /// 转移类型
        /// </summary>
        public string ChangeType { get; set; }
        public string ChangeTypeStr { get; set; }
        /// <summary>
        /// 货币类型
        /// </summary>
        public string MoneyType { get; set; }
        /// <summary>
        /// 货币类型
        /// </summary>
        public string MoneyTypeStr { get; set; }
        /// <summary>
        /// 转移状态
        /// </summary>
        public bool CState { get; set; }
        /// <summary>
        /// 服务中心ID
        /// </summary>
        public string SHMID { get; set; }
        /// <summary>
        /// 管理扣费
        /// </summary>
        public decimal TakeOffMoney { get; set; }
        /// <summary>
        /// 复利币
        /// </summary>
        public decimal ReBuyMoney { get; set; }
        /// <summary>
        /// 产业积分
        /// </summary>
        public decimal MCWMoney { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string CRemarks { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string CFileds { get; set; }

        /// <summary>
        /// 申请帮助的SQCode
        /// </summary>
        public string CFileds2 { get; set; }
        /// <summary>
        /// 订单完成时间
        /// </summary>
        public DateTime CompleteTime { get; set; }
        /// <summary>
        /// 订单完成状态：1-已完成；0-未完成
        /// </summary>
        public int OrderState { get; set; }
    }
}
