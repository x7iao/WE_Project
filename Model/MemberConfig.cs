using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    public class MemberConfig
    {
        /// <summary>
        /// 会员账号
        /// </summary>
        public string MID { get; set; }
        /// <summary>
        /// 市场业绩数量
        /// </summary>
        public int YJCount { get; set; }
        /// <summary>
        /// 市场业绩
        /// </summary>
        public int YJMoney { get; set; }
        /// <summary>
        /// 推荐业绩数量总
        /// </summary>
        public int TJCount { get; set; }
        /// <summary>
        /// 推荐业绩
        /// </summary>
        public int TJMoney { get; set; }
        /// <summary>
        /// 有效投资额/累计投资额
        /// </summary>
        public int SHMoney { get; set; }
        /// <summary>
        /// 双轨对碰
        /// </summary>
        public int UpSumMoney { get; set; }
        /// <summary>
        /// 毛收益
        /// </summary>
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 实际收益
        /// </summary>
        public decimal RealMoney { get; set; }
        /// <summary>
        /// 奖金
        /// </summary>
        public string JJTypeList { get; set; }
        /// <summary>
        /// 扣税
        /// </summary>
        public decimal TakeOffMoney { get; set; }
        /// <summary>
        /// 重复消费
        /// </summary>
        public decimal ReBuyMoney { get; set; }
        /// <summary>
        /// 累计提现
        /// </summary>
        public decimal TotalTXMoney { get; set; }
        /// <summary>
        /// 许愿树 静态奖金
        /// </summary>
        public decimal MHB { get; set; }
        /// <summary>
        /// 静态钱包
        /// </summary>
        public decimal MJJ { get; set; }
        /// <summary>
        /// 许愿池  动态奖金
        /// </summary>
        public decimal MJB { get; set; }
        /// <summary>
        /// 许愿台   用来理财
        /// </summary>
        public decimal MJBF { get; set; }
        /// <summary>
        /// 许愿果  用来排单，2000元/颗
        /// </summary>
        public decimal MCW { get; set; }
        /// <summary>
        /// 许愿金 排单需要的手续费
        /// </summary>
        public decimal MGP { get; set; }
        /// <summary>
        /// 冻结费用
        /// </summary>
        public decimal MHBFreeze { get; set; }
        /// <summary>
        /// 动态分红开关
        /// </summary>
        public bool DTFHState { get; set; }
        /// <summary>
        /// 静态总开关
        /// </summary>
        public bool JTFHState { get; set; }
        /// <summary>
        /// 日分红
        /// </summary>
        public decimal TotalDFHMoney { get; set; }
        /// <summary>
        /// 周分红
        /// </summary>
        public decimal TotalZFHMoney { get; set; }
        /// <summary>
        /// 激活码
        /// </summary>
        public decimal TotalYFHMoney { get; set; }

        public Model.Member Member { get; set; }
        /// <summary>
        /// 已有股权数量
        /// </summary>
        public int StockCount { get; set; }
        /// <summary>
        /// 已领取花红周期数
        /// </summary>
        public int TotalFHCount { get; set; }

        /// <summary>
        /// 增加字段是否可提现
        /// </summary>
        public bool TXStatus { get; set; }
        /// <summary>
        /// 增加字段是否可转账
        /// </summary>
        public bool ZZStatus { get; set; }
        /// <summary>
        /// 可拿领导奖代数
        /// </summary>
        public int TJLDLevel { get; set; }
        /// <summary>
        /// 累计日分红收益
        /// </summary>
        public int ReadNoticeID { get; set; }
        /// <summary>
        /// 下次管理扣费日期
        /// </summary>
        public DateTime GLMoneyDate { get; set; }
        /// <summary>
        /// 已扣管理费
        /// </summary>
        public decimal GLMoney { get; set; }
        /// <summary>
        /// 累计投资奖
        /// </summary>
        public decimal TotalLDMoney { get; set; }
        /// <summary>
        /// 提供援助的额度
        /// </summary>
        public decimal OfferQuota { get; set; }
        /// <summary>
        /// 每月申请的数量
        /// </summary>
        public int SQCount { get; set; }
        /// <summary>
        /// 诚信达人奖总计
        /// </summary>
        public decimal TotalHLMoney { get; set; }
        /// <summary>
        /// 诚信达人奖冻结状态
        /// </summary>
        public bool HLMoneyState { get; set; }

        /// <summary>
        /// 匹配的优先级
        /// </summary>
        public int PPLeavel { get; set; }


        public string FDTrade { get; set; }
        /// <summary>
        /// 忠诚度
        /// </summary>
        public int EPXingCount { get; set; }//5

        public int EPTimeOutCount { get; set; }//0
        /// <summary>
        ///  普通会员的累计解冻金额
        /// </summary>
        public decimal NomalTotalThaw { get; set; }//0
        /// <summary>
        /// 经理级以上的会员累计解冻金额
        /// </summary>
        public decimal VIPTotalThaw { get; set; }//0

        public string EPXingJiStr
        {
            get
            {
                string str = "<span style='color:red;'>";
                for (int i = 0; i < this.EPXingCount; i++)
                {
                    str += "★";
                }
                return str + "</span>";
            }
        }

    }
}
