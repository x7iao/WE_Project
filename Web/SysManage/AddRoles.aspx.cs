using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.SysManage
{
    public partial class AddRoles : BasePage
    {
        private Model.Roles RolesInfo
        {
            get
            {
                Model.Roles model = new Model.Roles();
                model.CanLogin = bool.Parse(Request.Form["ddlCanLogin"]);
                model.CanSH = bool.Parse(Request.Form["ddlCanSH"]);
                model.CMessage = bool.Parse(Request.Form["ddlCMessage"]);
                model.IsAdmin = bool.Parse(Request.Form["ddlIsAdmin"]);
                model.RColor = Request.Form["txtRColor"];
                model.RName = Request.Form["txtRName"];
                model.RType = Request.Form["txtRType"];
                model.Super = false;
                model.VState = true;
                if (BLL.Roles.RolsList.Values.Where(emp => emp.Super).Count() > 0)
                    model.Super = false;
                return model;
            }
        }
        protected override string btnAdd_Click()
        {
            if (BLL.Roles.Insert(RolesInfo))
                return "操作成功";
            return "操作失败";
        }
    }
}