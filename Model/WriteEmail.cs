using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    public class WriteEmail
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
        /// Code
        /// </summary>		
        private string _code;
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        /// <summary>
        /// WriteTime
        /// </summary>		
        private DateTime _writetime;
        public DateTime WriteTime
        {
            get { return _writetime; }
            set { _writetime = value; }
        }
        /// <summary>
        /// WriteBy
        /// </summary>		
        private string _writeby;
        public string WriteBy
        {
            get { return _writeby; }
            set { _writeby = value; }
        }
        /// <summary>
        /// WriteContent
        /// </summary>		
        private string _writecontent;
        public string WriteContent
        {
            get { return _writecontent; }
            set { _writecontent = value; }
        }
        /// <summary>
        /// PublishBy
        /// </summary>		
        private string _publishby;
        public string PublishBy
        {
            get { return _publishby; }
            set { _publishby = value; }
        }
        /// <summary>
        /// PublishTime
        /// </summary>		
        private DateTime _publishtime;
        public DateTime PublishTime
        {
            get { return _publishtime; }
            set { _publishtime = value; }
        }

    }
}

