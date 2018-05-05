using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    //MHelpMatch
    public class MHelpMatch
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
        /// MatchCode
        /// </summary>		
        private string _matchcode;
        public string MatchCode
        {
            get { return _matchcode; }
            set { _matchcode = value; }
        }
        /// <summary>
        /// OfferId
        /// </summary>		
        private int _offerid;
        public int OfferId
        {
            get { return _offerid; }
            set { _offerid = value; }
        }
        /// <summary>
        /// GetId
        /// </summary>		
        private int _getid;
        public int GetId
        {
            get { return _getid; }
            set { _getid = value; }
        }
        /// <summary>
        /// MatchTime
        /// </summary>		
        private DateTime _matchtime;
        public DateTime MatchTime
        {
            get { return _matchtime; }
            set { _matchtime = value; }
        }
        /// <summary>
        /// PayTime
        /// </summary>		
        private DateTime? _paytime;
        public DateTime? PayTime
        {
            get { return _paytime; }
            set { _paytime = value; }
        }
        /// <summary>
        /// ConfirmTime
        /// </summary>		
        private DateTime? _confirmtime;
        public DateTime? ConfirmTime
        {
            get { return _confirmtime; }
            set { _confirmtime = value; }
        }
        /// <summary>
        /// MatchState
        /// </summary>		
        private int _matchstate;
        /// <summary>
        /// 匹配状态；1-未打款；2-已打款；3-已确认；4-已完成
        /// </summary>
        public int MatchState
        {
            get { return _matchstate; }
            set { _matchstate = value; }
        }
        /// <summary>
        /// PicUrl
        /// </summary>		
        private string _picurl;
        public string PicUrl
        {
            get { return _picurl; }
            set { _picurl = value; }
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
        /// OfferMID
        /// </summary>		
        private string _offermid;
        public string OfferMID
        {
            get { return _offermid; }
            set { _offermid = value; }
        }
        /// <summary>
        /// GetMID
        /// </summary>		
        private string _getmid;
        public string GetMID
        {
            get { return _getmid; }
            set { _getmid = value; }
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
        /// 付款方评价
        /// </summary>
        public string PicUrl2
        {
            get;
            set;
        }
        /// <summary>
        /// 拒绝理由
        /// </summary>
        public string PicUrl1
        {
            get;
            set;
        }
        /// <summary>
        /// 收款方评价
        /// </summary>
        public string PicUrl3
        {
            get;
            set;
        }
        /// <summary>
        /// 1表示预付款打款
        /// </summary>
        public int ChangeCount
        {
            get;
            set;
        }
        public DateTime? ChangeMTJTime
        {
            get;
            set;
        }
        public DateTime? ChangeVIPTime
        {
            get;
            set;
        }
        /// <summary>
        /// 匹配类型(0:普通;1:预付款;2:抢单)
        /// </summary>
        public int MatchType { get; set; }
    }
}
