using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    public class RolePowers
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int RID { get; set; }
        /// <summary>
        /// 会员类型
        /// </summary>
        public string RType { get; set; }
        /// <summary>
        /// 目录ID
        /// </summary>
        public string CID { get; set; }
        /// <summary>
        /// 页面信息
        /// </summary>
        public Model.Contents Content { get; set; }
        /// <summary>
        /// 是否需要二级密码验证
        /// </summary>
        public bool IFVerify { get; set; }
   
    }
}
