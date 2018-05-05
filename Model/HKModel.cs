using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    public class HKModel
    {
        private string _hkCode;
        /// <summary>
        /// 汇款流水
        /// </summary>
        public string HKCode
        {
            get
            {
                if (string.IsNullOrEmpty(_hkCode))
                    _hkCode = HKCreateDate.ToString("yyyyMMddHHmmss") + (new Random().Next(100000, 999999)).ToString();
                return _hkCode;
            }
            set
            {
                _hkCode = value;
            }
        }
        /// <summary>
        /// 汇款创建时间
        /// </summary>
        public DateTime HKCreateDate { get; set; }
        /// <summary>
        /// 汇款审核时间
        /// </summary>
        public DateTime? ConfirmTime { get; set; }
        /// <summary>
        /// 汇款日期
        /// </summary>
        public DateTime HKDate { get; set; }
        /// <summary>
        /// 汇款会员账号
        /// </summary>
        public string MID { get; set; }
        /// <summary>
        /// 汇款类型：1排单币，2激活码
        /// </summary>
        public int HKType { get; set; }
        public string HKTypeStr { get; set; }
        /// <summary>
        /// 实际汇款
        /// </summary>
        public decimal RealMoney { get; set; }
        /// <summary>
        /// 有效金额
        /// </summary>
        public decimal ValidMoney { get; set; }
        /// <summary>
        /// 汇款银行
        /// </summary>
        public string FromBank { get; set; }
        /// <summary>
        /// 汇款人姓名
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 到账银行
        /// </summary>
        public string ToBank { get; set; }
        /// <summary>
        /// 是否通过
        /// </summary>
        public bool HKState { get; set; }
        /// <summary>
        /// 是否即时到账
        /// </summary>
        public bool IsAuto { get; set; }

        public bool Sign { get; set; }
        /// <summary>
        /// 汇款留言
        /// </summary>
        public string Remark { get; set; }

    }
}
