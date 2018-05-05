using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    /// <summary>
    /// 福利奖
    /// </summary>
    public class SHMoney
    {
        #region 基本属性
        /// <summary>
        /// 会员级别
        /// </summary>
        public string MAgencyType { get; set; }

        /// <summary>
        /// 级别名称
        /// </summary>
        public string _MAgencyName;
        public string MAgencyName
        {
            get
            {
                return "<b style='color:" + this.MColor + ";font-weight: bold;'>" + this._MAgencyName + "</b>";
            }
            set
            {
                _MAgencyName = value;
            }
        }

        /// <summary>
        /// 审核费用
        /// </summary>
        public int Money { get; set; }

        /// <summary>
        /// 报单补贴
        /// </summary>
        public decimal BTFloat { get; set; }

        /// <summary>
        /// 提现手续费
        /// </summary>
        public decimal TXFloat { get; set; }

        /// <summary>
        /// 税扣
        /// </summary>
        public decimal TakeOffFloat { get; set; }

        /// <summary>
        /// 平台管理费
        /// </summary>
        public int GLMoney { get; set; }

        /// <summary>
        /// 图谱层数
        /// </summary>
        public int ViewLevel { get; set; }

        /// <summary>
        /// 重复消费
        /// </summary>
        public decimal ReBuyFloat { get; set; }

        /// <summary>
        /// 重复消费
        /// </summary>
        public decimal MCWFloat { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string MColor { get; set; }

        /// <summary>
        /// 推荐奖/直推奖
        /// </summary>
        public decimal TJFloat { get; set; }
        #endregion
        /// <summary>
        /// 推荐单数
        /// </summary>
        public int TJCount { get; set; }

        private string _tjagency;
        public string TJAgency
        {
            get { return _tjagency; }
            set { _tjagency = value; }
        }
        /// <summary>
        /// TemaCount
        /// </summary>		
        private int _temacount;
        public int TemaCount
        {
            get { return _temacount; }
            set { _temacount = value; }
        }
        /// <summary>
        /// DTopMoney
        /// </summary>		
        private decimal _dtopmoney;
        public decimal DTopMoney
        {
            get { return _dtopmoney; }
            set { _dtopmoney = value; }
        }

        /// <summary>
        /// InitMaxTZ
        /// </summary>		
        private decimal _initmaxtz;
        public decimal InitMaxTZ
        {
            get { return _initmaxtz; }
            set { _initmaxtz = value; }
        }

        /// <summary>
        /// XYLastMemberCount
        /// </summary>		
        private int _xylastmembercount;
        public int XYLastMemberCount
        {
            get { return _xylastmembercount; }
            set { _xylastmembercount = value; }
        }
        /// <summary>
        /// XYFloat
        /// </summary>		
        private decimal _xyfloat;
        public decimal XYFloat
        {
            get { return _xyfloat; }
            set { _xyfloat = value; }
        }

        /// <summary>
        /// XFMouthMinHelpMoney
        /// </summary>		
        private decimal _xfmouthminhelpmoney;
        /// <summary>
        /// 最小投资额
        /// </summary>
        public decimal XFMouthMinHelpMoney
        {
            get { return _xfmouthminhelpmoney; }
            set { _xfmouthminhelpmoney = value; }
        }
        /// <summary>
        /// XFMounthMoney
        /// </summary>		
        private decimal _xfmounthmoney;
        /// <summary>
        /// 最大投资额
        /// </summary>
        public decimal XFMounthMoney
        {
            get { return _xfmounthmoney; }
            set { _xfmounthmoney = value; }
        }

        /// <summary>
        /// SQHelpCount
        /// </summary>		
        private int _sqhelpcount;
        public int SQHelpCount
        {
            get { return _sqhelpcount; }
            set { _sqhelpcount = value; }
        }

    }
}
