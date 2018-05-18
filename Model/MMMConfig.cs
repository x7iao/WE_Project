/**  版本信息模板在安装目录下，可自行修改。
* MMMConfig.cs
*
* 功 能： N/A
* 类 名： MMMConfig
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/16 16:13:43   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace WE_Project.Model
{
    /// <summary>
    /// MMMConfig:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class MMMConfig
    {
        public MMMConfig()
        { }
        #region Model
        private decimal _activecodeprice;
        private decimal _mcwprice;
        private decimal _mofferneedmcw;
        private decimal _offerhelpmin;
        private decimal _offerhelpmax;
        private decimal _offerhelpbase;
        private int _offerhelprangetimes;
        private int _offerhelprangecount;
        private bool _offerhelpneedcomplete;
        private decimal _gethelpmin;
        private decimal _gethelpmax;
        private decimal _gethelpbase;
        private int _gethelprangetimes;
        private int _gethelprangecount;
        private bool _gethelpneedcomplete;
        private int _linetimes;
        private int _freezetimes;
        private int _outtimes;
        private decimal _lixi1;
        private decimal _lixi2;
        private int _paylimittimes;
        private int _confirmlimittimes;
        private decimal _offerhelpfloat;
        private decimal _gethelpfloat;
        private decimal _nolinetimesmoneyfloat;
        private int _honesttimes;
        private decimal _honestfloat;
        private int _paylimittimespre;
        private int _confirmlimittimespre;
        private decimal _offertjkf;
        private decimal _gettjkf;
        private decimal _lastproportion;
        private decimal _offerhelpdaytotalmoney;
        private decimal _gethelpdaytotalmoney;
        private decimal _releaseper;
        private int _releaseconditioncount;
        private int _glrewardfreezetimes;
        private decimal _interestper;
        private string _gethelptimes;
        private string _offerhelptimes;
        private bool _gethelpswitch;
        private bool _offerhelpswitch;
        private string _macthtimesrange;
        private bool _macthswitch;
        private int _mhbbase;
        private int _mhbrangetimes;
        private int _mcwbase;
        private int _mcwrangetimes;
        private int _mjbbase;
        private int _mjbrangetimes;
        private int _freezetimesofregister;
        private int _freezetimesofoffer;
        /// <summary>
        /// 激活码价格
        /// </summary>
        public decimal ActiveCodePrice
        {
            set { _activecodeprice = value; }
            get { return _activecodeprice; }
        }
        /// <summary>
        /// 排单币价格
        /// </summary>
        public decimal MCWPrice
        {
            set { _mcwprice = value; }
            get { return _mcwprice; }
        }
        /// <summary>
        /// 排单所需排单币比例
        /// </summary>
        public decimal MOfferNeedMCW
        {
            set { _mofferneedmcw = value; }
            get { return _mofferneedmcw; }
        }
        /// <summary>
        /// 买入许愿果最小金额
        /// </summary>
        public decimal OfferHelpMin
        {
            set { _offerhelpmin = value; }
            get { return _offerhelpmin; }
        }
        /// <summary>
        /// 买入许愿果最大金额
        /// </summary>
        public decimal OfferHelpMax
        {
            set { _offerhelpmax = value; }
            get { return _offerhelpmax; }
        }
        /// <summary>
        /// 买入许愿果倍数
        /// </summary>
        public decimal OfferHelpBase
        {
            set { _offerhelpbase = value; }
            get { return _offerhelpbase; }
        }
        /// <summary>
        /// 买入许愿果间隔排单时间
        /// </summary>
        public int OfferHelpRangeTimes
        {
            set { _offerhelprangetimes = value; }
            get { return _offerhelprangetimes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OfferHelpRangeCount
        {
            set { _offerhelprangecount = value; }
            get { return _offerhelprangecount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool OfferHelpNeedComplete
        {
            set { _offerhelpneedcomplete = value; }
            get { return _offerhelpneedcomplete; }
        }
        /// <summary>
        /// 卖出许愿果最小金额
        /// </summary>
        public decimal GetHelpMin
        {
            set { _gethelpmin = value; }
            get { return _gethelpmin; }
        }
        /// <summary>
        /// 卖出许愿果最大金额
        /// </summary>
        public decimal GetHelpMax
        {
            set { _gethelpmax = value; }
            get { return _gethelpmax; }
        }
        /// <summary>
        /// 卖出许愿果倍数
        /// </summary>
        public decimal GetHelpBase
        {
            set { _gethelpbase = value; }
            get { return _gethelpbase; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int GetHelpRangeTimes
        {
            set { _gethelprangetimes = value; }
            get { return _gethelprangetimes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int GetHelpRangeCount
        {
            set { _gethelprangecount = value; }
            get { return _gethelprangecount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool GetHelpNeedComplete
        {
            set { _gethelpneedcomplete = value; }
            get { return _gethelpneedcomplete; }
        }
        /// <summary>
        /// 排队期
        /// </summary>
        public int LineTimes
        {
            set { _linetimes = value; }
            get { return _linetimes; }
        }
        /// <summary>
        /// 冻结期
        /// </summary>
        public int FreezeTimes
        {
            set { _freezetimes = value; }
            get { return _freezetimes; }
        }
        /// <summary>
        /// 出局时间
        /// </summary>
        public int OutTimes
        {
            set { _outtimes = value; }
            get { return _outtimes; }
        }
        /// <summary>
        /// 签到奖比例
        /// </summary>
        public decimal LiXi1
        {
            set { _lixi1 = value; }
            get { return _lixi1; }
        }
        /// <summary>
        /// 奖金烧伤比例
        /// </summary>
        public decimal LiXi2
        {
            set { _lixi2 = value; }
            get { return _lixi2; }
        }
        /// <summary>
        /// 打款时间
        /// </summary>
        public int PayLimitTimes
        {
            set { _paylimittimes = value; }
            get { return _paylimittimes; }
        }
        /// <summary>
        /// 收款时间
        /// </summary>
        public int ConfirmLimitTimes
        {
            set { _confirmlimittimes = value; }
            get { return _confirmlimittimes; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal OfferHelpFloat
        {
            set { _offerhelpfloat = value; }
            get { return _offerhelpfloat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal GetHelpFloat
        {
            set { _gethelpfloat = value; }
            get { return _gethelpfloat; }
        }
        /// <summary>
        /// 不打款扣推荐人比例
        /// </summary>
        public decimal OfferTJKF
        {
            set { _offertjkf = value; }
            get { return _offertjkf; }
        }
        /// <summary>
        /// 不收款扣推荐人比例
        /// </summary>
        public decimal GetTJKF
        {
            set { _gettjkf = value; }
            get { return _gettjkf; }
        }
        /// <summary>
        /// 排单不小于上一单的50%，利息不解冻
        /// </summary>
        public decimal LastProportion
        {
            set { _lastproportion = value; }
            get { return _lastproportion; }
        }
        /// <summary>
        /// 不排队匹配10%
        /// </summary>
        public decimal NoLineTimesMoneyFloat
        {
            set { _nolinetimesmoneyfloat = value; }
            get { return _nolinetimesmoneyfloat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int HonestTimes
        {
            set { _honesttimes = value; }
            get { return _honesttimes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal HonestFloat
        {
            set { _honestfloat = value; }
            get { return _honestfloat; }
        }
        /// <summary>
        /// 打款时间
        /// </summary>
        public int PayLimitTimesPre
        {
            set { _paylimittimespre = value; }
            get { return _paylimittimespre; }
        }
        /// <summary>
        /// 收款时间
        /// </summary>
        public int ConfirmLimitTimesPre
        {
            set { _confirmlimittimespre = value; }
            get { return _confirmlimittimespre; }
        }
        /// <summary>
        /// 买入许愿果日限额
        /// </summary>
        public decimal OfferHelpDayTotalMoney
        {
            set { _offerhelpdaytotalmoney = value; }
            get { return _offerhelpdaytotalmoney; }
        }
        /// <summary>
        /// 卖出许愿果日限额
        /// </summary>
        public decimal GetHelpDayTotalMoney
        {
            set { _gethelpdaytotalmoney = value; }
            get { return _gethelpdaytotalmoney; }
        }
        /// <summary>
        /// 奖金释放比例
        /// </summary>
        public decimal ReleasePer
        {
            set { _releaseper = value; }
            get { return _releaseper; }
        }
        /// <summary>
        /// 释放条件
        /// </summary>
        public int ReleaseConditionCount
        {
            set { _releaseconditioncount = value; }
            get { return _releaseconditioncount; }
        }
        /// <summary>
        /// 管理奖冻结时间
        /// </summary>
        public int GLRewardFreezeTimes
        {
            set { _glrewardfreezetimes = value; }
            get { return _glrewardfreezetimes; }
        }
        /// <summary>
        /// 利息比例
        /// </summary>
        public decimal InterestPer
        {
            set { _interestper = value; }
            get { return _interestper; }
        }
        /// <summary>
        /// 卖出许愿果时间段
        /// </summary>
        public string GetHelpTimes
        {
            set { _gethelptimes = value; }
            get { return _gethelptimes; }
        }
        /// <summary>
        /// 买入许愿果时间段
        /// </summary>
        public string OfferHelpTimes
        {
            set { _offerhelptimes = value; }
            get { return _offerhelptimes; }
        }
        /// <summary>
        /// 卖出许愿果开关
        /// </summary>
        public bool GetHelpSwitch
        {
            set { _gethelpswitch = value; }
            get { return _gethelpswitch; }
        }
        /// <summary>
        /// 买入许愿果开关
        /// </summary>
        public bool OfferHelpSwitch
        {
            set { _offerhelpswitch = value; }
            get { return _offerhelpswitch; }
        }
        /// <summary>
        /// 匹配时间范围
        /// </summary>
        public string MacthTimesRange
        {
            set { _macthtimesrange = value; }
            get { return _macthtimesrange; }
        }
        /// <summary>
        /// 自动匹配开关
        /// </summary>
        public bool MacthSwitch
        {
            set { _macthswitch = value; }
            get { return _macthswitch; }
        }
        /// <summary>
        /// 注册N天内不参加抢单
        /// </summary>
        public int MHBBase
        {
            set { _mhbbase = value; }
            get { return _mhbbase; }
        }
        /// <summary>
        /// 互助钱包提现间隔
        /// </summary>
        public int MHBRangeTimes
        {
            set { _mhbrangetimes = value; }
            get { return _mhbrangetimes; }
        }
        /// <summary>
        /// 回馈钱包提现倍数
        /// </summary>
        public int MCWBase
        {
            set { _mcwbase = value; }
            get { return _mcwbase; }
        }
        /// <summary>
        /// 回馈钱包提现倍数
        /// </summary>
        public int MCWRangeTimes
        {
            set { _mcwrangetimes = value; }
            get { return _mcwrangetimes; }
        }
        /// <summary>
        /// 爱心钱包提现倍数
        /// </summary>
        public int MJBBase
        {
            set { _mjbbase = value; }
            get { return _mjbbase; }
        }
        /// <summary>
        /// 爱心钱包提现间隔
        /// </summary>
        public int MJBRangeTimes
        {
            set { _mjbrangetimes = value; }
            get { return _mjbrangetimes; }
        }
        /// <summary>
        /// 注册不排单冻结时间
        /// </summary>
        public int FreezeTimesOfRegister
        {
            set { _freezetimesofregister = value; }
            get { return _freezetimesofregister; }
        }
        /// <summary>
        /// 卖出许愿果排队期
        /// </summary>
        public int FreezeTimesOfOffer
        {
            set { _freezetimesofoffer = value; }
            get { return _freezetimesofoffer; }
        }

        #endregion Model

    }
}

