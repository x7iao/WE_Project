using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.SysManage
{
    public partial class ModifyRoles : BasePage
    {
        protected override void SetValue(string id)
        {
            RolesInfo = BLL.Roles.GetModel(id);
            hdRType.Value = id;
        }

        private Model.Roles RolesInfo
        {
            get
            {
                Model.Roles model = BLL.Roles.GetModel(Request.Form["hdRType"]);
                model.CanLogin = bool.Parse(Request.Form["ddlCanLogin"]);
                model.CanSH = bool.Parse(Request.Form["ddlCanSH"]);
                model.CMessage = bool.Parse(Request.Form["ddlCMessage"]);
                model.IsAdmin = bool.Parse(Request.Form["ddlIsAdmin"]);
                model.RColor = Request.Form["txtRColor"];
                model.RName = Request.Form["txtRName"];
                model.RType = Request.Form["txtRType"];
                if (BLL.Roles.RolsList.Values.Where(emp => emp.Super).Count() > 0)
                    model.Super = false;
                return model;
            }
            set
            {
                txtRColor.Value = value.RColor;
                txtRType.Value = value.RType;
                txtRName.Value = value.RName;
                ddlCanLogin.SelectedIndex = ddlCanLogin.Items.IndexOf(ddlCanLogin.Items.FindByValue(value.CanLogin.ToString().ToLower()));
                ddlCanSH.SelectedIndex = ddlCanSH.Items.IndexOf(ddlCanSH.Items.FindByValue(value.CanSH.ToString().ToLower()));
                ddlCMessage.SelectedIndex = ddlCMessage.Items.IndexOf(ddlCMessage.Items.FindByValue(value.CMessage.ToString().ToLower()));
                ddlIsAdmin.SelectedIndex = ddlIsAdmin.Items.IndexOf(ddlIsAdmin.Items.FindByValue(value.IsAdmin.ToString().ToLower()));
                ddlSuper.SelectedIndex = ddlSuper.Items.IndexOf(ddlSuper.Items.FindByValue(value.Super.ToString().ToLower()));
            }
        }

        protected override string btnModify_Click()
        {
            if (BLL.Roles.Update(RolesInfo))
                return "操作成功";
            return "操作失败";
        }
    }
}