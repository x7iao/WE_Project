using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WE_Project.Model
{
    public partial class BCenter
    {
        public BCenter()
        { }
        #region Model
        private string _mid;
        private string _mname;
        private string _des;
        private DateTime _adddate;
        /// <summary>
        /// 
        /// </summary>
        public string MID
        {
            set { _mid = value; }
            get { return _mid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MName
        {
            set { _mname = value; }
            get { return _mname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Des
        {
            set { _des = value; }
            get { return _des; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }

        public string Flag
        { get; set; }
        #endregion Model

    }
}
