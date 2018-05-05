using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    //BuyActiveCode
    public class BuyActiveCode
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
        /// CodeCount
        /// </summary>		
        private int _codecount;
        public int CodeCount
        {
            get { return _codecount; }
            set { _codecount = value; }
        }
        /// <summary>
        /// FromMID
        /// </summary>		
        private string _frommid;
        public string FromMID
        {
            get { return _frommid; }
            set { _frommid = value; }
        }
        /// <summary>
        /// ToMID
        /// </summary>		
        private string _tomid;
        public string ToMID
        {
            get { return _tomid; }
            set { _tomid = value; }
        }
        /// <summary>
        /// PayTime
        /// </summary>		
        private DateTime _paytime;
        public DateTime PayTime
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
        /// State
        /// </summary>		
        private int _state;
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }        

    }
}
