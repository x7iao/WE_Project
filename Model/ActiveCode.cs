using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    public class ActiveCode
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
        /// ActiveCode
        /// </summary>		
        private string _code;
        public string Code
        {
            get { return _code; }
            set { _code = value; }
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
        /// UseState
        /// </summary>		
        private int _usestate;
        /// <summary>
        /// 激活码状态：0-创建未使用；1:-已发放出去未使用；2-已被会员激活使用;4-被限制，不能使用
        /// </summary>
        public int UseState
        {
            get { return _usestate; }
            set { _usestate = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// UseMID
        /// </summary>		
        private string _usemid;
        public string UseMID
        {
            get { return _usemid; }
            set { _usemid = value; }
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
        /// 转换方式
        /// </summary>		
        private string _switchType;
        public string SwitchType
        {
            get { return _switchType; }
            set { _switchType = value; }
        }

    }
}
