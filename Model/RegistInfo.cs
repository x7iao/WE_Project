using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    //RegistInfo
    public class RegistInfo
    {

        /// <summary>
        /// GId
        /// </summary>		
        private string _gid;
        public string GId
        {
            get { return _gid; }
            set { _gid = value; }
        }
        /// <summary>
        /// MID
        /// </summary>		
        private string _mid;
        public string MID
        {
            get { return _mid; }
            set { _mid = value; }
        }
        /// <summary>
        /// MEmail
        /// </summary>		
        private string _memail;
        public string MEmail
        {
            get { return _memail; }
            set { _memail = value; }
        }
        /// <summary>
        /// MCreateTime
        /// </summary>		
        private DateTime _mcreatetime;
        public DateTime MCreateTime
        {
            get { return _mcreatetime; }
            set { _mcreatetime = value; }
        }
        /// <summary>
        /// UseTime
        /// </summary>		
        private DateTime? _usetime;
        public DateTime? UseTime
        {
            get { return _usetime; }
            set { _usetime = value; }
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

    }
}
