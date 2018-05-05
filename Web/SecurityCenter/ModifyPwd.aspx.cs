using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.SecurityCenter
{
    public partial class ModifyPwd : BasePage
    {
        protected override void SetPowerZone()
        {
            txtNumID.Value = TModel.Tel;
        }

        /// <summary>
        /// 货币转移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnModify_Click()
        {
            //string code = BLL.SMS.GetSKeyBuyTel(Request.Form["txtNumID"].Trim(), Model.SMSType.MMYZ);
            //if ((string.IsNullOrEmpty(code) || code != Request.Form["txtTelCode"].Trim()))
            //{
            //    return "手机验证码错误";
            //}

            Model.Member model = TModel;
            if (System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Request.Form["lbOPassword"].Trim() + model.Salt, "MD5").ToUpper() == model.Password)
            {
                model.Password = Request.Form["lbNPassword"].Trim();
                model.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password + model.Salt, "MD5").ToUpper();
                if (BllModel.Update(model))
                    return "操作成功";
                return "操作失败";
            }
            else
            {
                return "原密码不正确";
            }

        }

    }
}