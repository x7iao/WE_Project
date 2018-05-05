using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    //Remind
    public class Remind
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
        /// RType
        /// </summary>		
        private int _rtype;
        public int RType
        {
            get { return _rtype; }
            set { _rtype = value; }
        }
        /// <summary>
        /// RTypeName
        /// </summary>		
        private string _rtypename;
        public string RTypeName
        {
            get { return _rtypename; }
            set { _rtypename = value; }
        }
        /// <summary>
        /// RemindMsg
        /// </summary>		
        private string _remindmsg;
        public string RemindMsg
        {
            get { return _remindmsg; }
            set { _remindmsg = value; }
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
