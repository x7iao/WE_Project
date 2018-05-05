using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    //MemberApply
    public class MemberApply
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
        /// MID
        /// </summary>		
        private string _mid;
        public string MID
        {
            get { return _mid; }
            set { _mid = value; }
        }
        /// <summary>
        /// MQQ
        /// </summary>		
        private string _mqq;
        public string MQQ
        {
            get { return _mqq; }
            set { _mqq = value; }
        }
        /// <summary>
        /// QQ群
        /// </summary>		
        private string _mqqgroup;
        public string MQQGroup
        {
            get { return _mqqgroup; }
            set { _mqqgroup = value; }
        }
        /// <summary>
        /// 电话
        /// </summary>		
        private string _mtel;
        public string MTel
        {
            get { return _mtel; }
            set { _mtel = value; }
        }
        /// <summary>
        /// ApplyTime
        /// </summary>		
        private DateTime _applytime;
        public DateTime ApplyTime
        {
            get { return _applytime; }
            set { _applytime = value; }
        }
      
        private int _state;
        /// <summary>
        /// 状态：1:-已申请；2:-审核通过；3-审核未通过；4-用户取消申请
        /// </summary>		
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        /// <summary>
        /// ConfirmTime
        /// </summary>		
        private DateTime? _confirmtime;
        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime? ConfirmTime
        {
            get { return _confirmtime; }
            set { _confirmtime = value; }
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
        /// ApplyType
        /// </summary>		
        private string _applytype;
        /// <summary>
        /// 申请类型：1-区域总监；2-服务中心；3-报单中心
        /// </summary>
        public string ApplyType
        {
            get { return _applytype; }
            set { _applytype = value; }
        }
      
    }
}
