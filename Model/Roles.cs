using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    public class Roles
    {
        public string RType { get; set; }
        public string RName { get; set; }
        public bool CMessage { get; set; }//是否可修改其权限
        public bool IsAdmin { get; set; }//是否是管理员
        public bool CanSH { get; set; }//是否有审核权限
        public bool CanLogin { get; set; }//是否可以登录
        public bool VState { get; set; }
        public bool Super { get; set; }
        public string RColor { get; set; }
        public List<Model.RolePowers> PowersList { get; set; }
    }
}
