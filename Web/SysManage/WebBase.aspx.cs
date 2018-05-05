using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.SysManage
{
    public partial class WebBase : BasePage
    {
        protected Model.WebBase WebBaseModel
        {
            get
            {
                Model.WebBase model = BLL.WebBase.Model;
                model.SMSState = Request.Form["chkSMSState"] == "on";
                model.SMSName = Request.Form["txtSMSName"];
                model.SMSPassword = Request.Form["txtSMSPassword"];
                model.TelVerify = Request.Form["chkTelVerify"] == "on";
                model.SMSTitle = Request.Form["txtSMSTitle"];
                model.MonitorTel = Request.Form["txtMonitorTel"];
                model.SMSMinCount = int.Parse(Request.Form["txtSMSMinCount"]);
                model.EmailSmtp = Request.Form["txtEmailSmtp"];
                model.EmailName = Request.Form["txtEmailName"];
                model.EmailPassword = Request.Form["txtEmailPassword"];
                model.EmailTitle = Request.Form["txtEmailTitle"];
                model.EmailVerify = Request.Form["chkEmailVerify"] == "on";
                model.EmailState = Request.Form["chkEmailState"] == "on";
                model.DaySMSCount = int.Parse(Request.Form["txtDaySMSCount"]);
                model.RandPassword = Request.Form["chkRandPassword"] == "on";
                model.MonitorEmail = Request.Form["txtMonitorEmail"];
                model.AutoID = Request.Form["chkAutoID"] == "on";
                return model;
            }
            set
            {
                this.chkSMSState.Checked = value.SMSState;
                this.txtSMSName.Value = value.SMSName;
                this.txtSMSPassword.Value = value.SMSPassword;
                this.chkTelVerify.Checked = value.TelVerify;
                this.txtSMSTitle.Value = value.SMSTitle;
                this.txtMonitorTel.Value = value.MonitorTel;
                this.txtSMSMinCount.Value = value.SMSMinCount.ToString();
                this.txtEmailSmtp.Value = value.EmailSmtp;
                this.txtEmailName.Value = value.EmailName;
                this.txtEmailPassword.Value = value.EmailPassword;
                this.txtEmailTitle.Value = value.EmailTitle;
                this.chkEmailVerify.Checked = value.EmailVerify;
                this.chkEmailState.Checked = value.EmailState;
                this.txtDaySMSCount.Value = value.DaySMSCount.ToString();
                this.chkRandPassword.Checked = value.RandPassword;
                this.txtMonitorEmail.Value = value.MonitorEmail;
                this.txtShengYu.Value = BLL.SMS.ShengYu();
                this.chkAutoID.Checked = value.AutoID;
            }
        }
        protected override void SetValue()
        {
            WebBaseModel = BLL.WebBase.Model;
        }
        protected override string btnModify_Click()
        {
            if (BLL.WebBase.Update(WebBaseModel))
                return "操作成功";
            return "操作失败";
        }
    }
}