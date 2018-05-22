using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    public class MOfferHelp
    {

        /// <summary>
        /// Id
        /// </summary>		
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// SQCode
        /// </summary>		
        private string _sqcode;
        public string SQCode
        {
            get { return _sqcode; }
            set { _sqcode = value; }
        }
        /// <summary>
        /// SQMID
        /// </summary>		
        private string _sqmid;
        public string SQMID
        {
            get { return _sqmid; }
            set { _sqmid = value; }
        }
        /// <summary>
        /// SQMoney
        /// </summary>		
        private decimal _sqmoney;
        public decimal SQMoney
        {
            get { return _sqmoney; }
            set { _sqmoney = value; }
        }
        /// <summary>
        /// SQDate
        /// </summary>		
        private DateTime _sqdate;
        public DateTime SQDate
        {
            get { return _sqdate; }
            set { _sqdate = value; }
        }
        /// <summary>
        /// PPState
        /// </summary>		
        private int _ppstate;
        /// <summary>
        /// 匹配状态：(0-未匹配；2-部分匹配) :等待匹配中。 ；1-已成功匹配；3-已完成；4-已提款；5-已经取消
        /// </summary>
        public int PPState
        {
            get { return _ppstate; }
            set { _ppstate = value; }
        }
        /// <summary>
        /// DKState
        /// </summary>		
        private int _dkstate;
        /// <summary>
        /// 打款状态：0-未打款；1-已打款；2-已确认收款（只有所有的匹配记录都确认首收款，才出现此状态）；3-已取现
        /// </summary>
        public int DKState
        {
            get { return _dkstate; }
            set { _dkstate = value; }
        }
        /// <summary>
        /// MFLMoney
        /// </summary>		
        private decimal _mflmoney;
        public decimal MFLMoney
        {
            get { return _mflmoney; }
            set { _mflmoney = value; }
        }
        /// <summary>
        /// Remark
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// TotalInterest
        /// </summary>		
        private decimal _totalinterest;
        /// <summary>
        /// 总计利息
        /// </summary>
        public decimal TotalInterest
        {
            get { return _totalinterest; }
            set { _totalinterest = value; }
        }
        /// <summary>
        /// TotalInterestDays
        /// </summary>		
        private int _totalinterestdays;
        /// <summary>
        /// 产生利息的天数
        /// </summary>
        public int TotalInterestDays
        {
            get { return _totalinterestdays; }
            set { _totalinterestdays = value; }
        }
        /// <summary>
        /// TotalSincerity
        /// </summary>		
        private decimal _totalsincerity;
        /// <summary>
        /// 诚信达人奖总计
        /// </summary>
        public decimal TotalSincerity
        {
            get { return _totalsincerity; }
            set { _totalsincerity = value; }
        }
        /// <summary>
        /// TotalSincerityDays
        /// </summary>		
        private int _totalsinceritydays;
        /// <summary>
        /// 诚信达人奖产生天数
        /// </summary>
        public int TotalSincerityDays
        {
            get { return _totalsinceritydays; }
            set { _totalsinceritydays = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private int _sinceritystate;
        /// <summary>
        /// 诚信达人奖状态：0-不可用（冻结中）；1-正常产生；2-停止产生
        /// </summary>
        public int SincerityState
        {
            get { return _sinceritystate; }
            set { _sinceritystate = value; }
        }
        /// <summary>
        /// InterestState
        /// </summary>		
        private int _intereststate;
        /// <summary>
        /// 利息状态：0-不可用（冻结中）；1-正常产生；2-停止产生
        /// </summary>
        public int InterestState
        {
            get { return _intereststate; }
            set { _intereststate = value; }
        }

        private decimal _MatchMoney;
        /// <summary>
        /// 匹配金额
        /// </summary>
        public decimal MatchMoney
        {
            get { return _MatchMoney; }
            set { _MatchMoney = value; }
        }
        /// <summary>
        /// 剩余未匹配金额(非数据库字段)
        /// </summary>
        public decimal Money
        {
            get
            {
                return SQMoney - MatchMoney;
            }
        }

        /// <summary>
        /// 订单完成时间
        /// </summary>
        public DateTime? CompleteTime
        {
            get;
            set;
        }
        /// <summary>
        /// 该订单的日利息比例
        /// </summary>
        public decimal DayInterest { get; set; }
        /// <summary>
        /// 订单类型(0普通,1抢单,,99:超时订单,98:可抢订单,97:不可抢订单)
        /// </summary>
        public int HelpType { get; set; }

        /// <summary>
        /// 钱包类型
        /// </summary>
        public string MoneyType { get; set; }
        
    }
}
