using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    public class MGetHelp
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
        /// SQCode
        /// </summary>		
        private string _sqcode;
        public string SQCode
        {
            get { return _sqcode; }
            set { _sqcode = value; }
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
        /// 匹配状态：(0-未匹配；2-部分匹配) :等待匹配中。 ；1-已成功匹配；3-已完成
        /// </summary>
        public int PPState
        {
            get { return _ppstate; }
            set { _ppstate = value; }
        }
        /// <summary>
        /// ConfirmState
        /// </summary>		
        private int _confirmstate;
        /// <summary>
        /// 匹配状态：(0-未匹配；2-部分匹配) :等待匹配中。 ；1-已成功匹配；3-已完成;5-已取消
        /// </summary>
        public int ConfirmState
        {
            get { return _confirmstate; }
            set { _confirmstate = value; }
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
        /// MatchMoney
        /// </summary>		
        private decimal _MatchMoney;
        public decimal MatchMoney
        {
            get { return _MatchMoney; }
            set { _MatchMoney = value; }
        }
        /// <summary>
        /// 订单类型
        /// </summary>
        public int HelpType { get; set; }

        /// <summary>
        /// 剩余未匹配(非数据库字段)
        /// </summary>
        public decimal Money
        {
            get
            {
                return SQMoney - MatchMoney;
            }
        }

        /// <summary>
        /// 钱包类型
        /// </summary>
        public string MoneyType { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime ComfirmDate { get; set; }
    }
}
