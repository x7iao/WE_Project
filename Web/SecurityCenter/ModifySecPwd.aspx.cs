using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.SecurityCenter
{
    public partial class ModifySecPwd : BasePage
    {
        protected override void SetPowerZone()
        {
            txtNumID.Value = TModel.Tel;
        }

        protected override string btnModify_Click()
        {
            //string code = BLL.SMS.GetSKeyBuyTel(Request.Form["txtNumID"].Trim(), Model.SMSType.MMYZ);
            //if ((string.IsNullOrEmpty(code) || code != Request.Form["txtTelCode"].Trim()))
            //{
            //    return "手机验证码错误";
            //}

            Model.Member model = TModel;
            model.SecPsd = Request.Form["lbNSecPsd"].Trim();
            model.SecPsd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.SecPsd + model.Salt, "MD5").ToUpper();
            if (BllModel.Update(model))
                return "操作成功";
            return "操作失败";
        }
    }
}