using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace WE_Project.Model
{
    public class Configuration
    {
        /// <summary>
        /// 激活费用
        /// </summary>
        public int YLMoney { get; set; }

        /// <summary>
        /// 接点人数
        /// </summary>
        public int BDCount { get; set; }

        /// <summary>
        /// 最少提现金额
        /// </summary>
        public int TXMinMoney { get; set; }

        /// <summary>
        /// 提现倍数
        /// </summary>
        public int TXBaseMoney { get; set; }

        /// <summary>
        /// 最少转账金额
        /// </summary>
        public int ZZMinMoney { get; set; }

        /// <summary>
        /// 转账倍数
        /// </summary>
        public int ZZBaseMoney { get; set; }

        /// <summary>
        /// 最少转账金额
        /// </summary>
        public int DHMinMoney { get; set; }

        /// <summary>
        /// 转账倍数
        /// </summary>
        public int DHBaseMoney { get; set; }

        /// <summary>
        /// 激活默认角色
        /// </summary>
        public string DefaultRole { get; set; }

        /// <summary>
        /// 审核费用
        /// </summary>
        public DataTable SHMoneyTable { get; set; }
        /// <summary>
        /// 审核费用列表
        /// </summary>
        public Dictionary<string, Model.SHMoney> SHMoneyList { get; set; }

        /// <summary>
        /// 组织奖数据源
        /// </summary>
        public DataTable ConfigDictionaryTable { get; set; }

        /// <summary>
        /// 字典
        /// </summary>
        public Dictionary<string, List<ConfigDictionary>> ConfigDictionaryList { get; set; }


        public List<ConfigDictionary> ConfigDictionaryLists { get; set; }


        /// <summary>
        /// 组织奖数据源
        /// </summary>
        public DataTable NConfigDictionaryTable { get; set; }
        /// <summary>
        /// 字典
        /// </summary>
        public Dictionary<string, List<NConfigDictionary>> NConfigDictionaryList { get; set; }


        /// <summary>
        /// 最大对碰次数
        /// </summary>
        public int MaxDPCount { get; set; }

        public decimal DPTopFloat { get; set; }
        /// <summary>
        /// 入账汇率
        /// </summary>
        public decimal InFloat { get; set; }
        /// <summary>
        /// 出账汇率
        /// </summary>
        public decimal OutFloat { get; set; }

        public Hashtable HaSh { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal GPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal DFHFloat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal DFHTopMoney { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal DMHBPart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal DMGPPart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal JMHBPart { get; set; }

        /// <summary>
        /// 复投单次发放比例
        /// </summary>
        public decimal JMGPPart { get; set; }

        /// <summary>
        /// 复投生产时间
        /// </summary>
        public int MinBuyGCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal GLMoney { get; set; }

        /// <summary>
        /// 静态分红开关
        /// </summary>
        public bool AutoDFH { get; set; }

        /// <summary>
        /// 一个手机号注册帐号数量
        /// </summary>
        public int MaxBuyGCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DFHXFCount { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int DFHOutCount { get; set; }
        /// <summary>
        /// 注册开关
        /// </summary>
        public bool CanRegedit
        {
            set;
            get;
        }
        /// <summary>
        /// 每天激活人数
        /// </summary>
        public int DayRegeditNumber
        {
            set;
            get;
        }
        /// <summary>
        /// 显示买入许愿果总金额
        /// </summary>
        public decimal ShowOfferTotalMoney
        {
            set;
            get;
        }
        /// <summary>
        /// 显示卖出许愿果总金额
        /// </summary>
        public decimal ShowGetTotalMoney
        {
            set;
            get;
        }
        /// <summary>
        /// 显示系统会员总量
        /// </summary>
        public int ShowTotalNumber
        {
            set;
            get;
        }
    }
}
