using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WE_Project.Web.Member
{
    public partial class ShortcutSet : BasePage
    {
        protected override void SetValue(string id)
        {
            foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => emp.VState).ToList())
                ddlMemberType.Items.Add(new ListItem(item.RName, item.RType));//角色

            //会员级别
            //ddlJXCode.DataSource = BLL.Configuration.Model.JXMoneyTable;
            //ddlJXCode.DataTextField = "JXName";
            //ddlJXCode.DataValueField = "JXType";
            //ddlJXCode.DataBind();
            //ddlJXCode.Items.Insert(0, new ListItem("", "0"));
            //ddlJXCode.Items.Insert(1, new ListItem("无称谓", ""));

            ddlSHMoney.DataSource = BLL.Configuration.Model.SHMoneyTable;
            ddlSHMoney.DataTextField = "MAgencyName";
            ddlSHMoney.DataValueField = "MAgencyType";
            ddlSHMoney.DataBind();
            ddlSHMoney.Items.Insert(0, new ListItem("", ""));

            txtJJTypeList.Value = BLL.Reward.RewardStr;

            hdMIDList.Value = HttpUtility.UrlDecode(Request["id"]);
        }

        protected override string btnModify_Click()
        {
            string midlist = Request.Form["hdMIDList"];
            Hashtable MyHs = new Hashtable();
            Model.Member model;
            foreach (string mid in midlist.Split(','))
            {
                model = BllModel.GetModel(mid);
                if (model.Role.Super)
                    continue;
                //if (Request.Form["ddlJXCode"] != "0" && model.MConfig != null)
                //    model.MConfig.JXCode = Request.Form["ddlJXCode"];
                if (!string.IsNullOrEmpty(Request.Form["ddlSHMoney"]))
                    model.AgencyCode = Request.Form["ddlSHMoney"];
                if (!string.IsNullOrEmpty(Request.Form["ddlMemberType"]))
                    model.RoleCode = Request.Form["ddlMemberType"];
                if (!string.IsNullOrEmpty(Request.Form["txtTel"].Trim()))
                    model.Tel = Request.Form["txtTel"].Trim();
                if (!string.IsNullOrEmpty(Request.Form["txtEmail"].Trim()))
                    model.Email = Request.Form["txtEmail"].Trim();
                if (!string.IsNullOrEmpty(Request.Form["txtMTJ"].Trim()))
                    model.MTJ = Request.Form["txtMTJ"].Trim();
                if (!string.IsNullOrEmpty(Request.Form["txtMSH"].Trim()))
                    model.MSH = Request.Form["txtMSH"].Trim();
                if (Request.Form["ddlProvince"].Trim() != "省名")
                    model.Province = Request.Form["ddlProvince"];
                if (Request.Form["ddlCity"] != "地市")
                    model.City = Request.Form["ddlCity"];
                if (Request.Form["ddlZone"] != "县市")
                    model.Zone = Request.Form["ddlZone"];
                if (!string.IsNullOrEmpty(Request.Form["txtAddress"].Trim()))
                    model.Address = Request.Form["txtAddress"].Trim();
                if (!string.IsNullOrEmpty(Request.Form["ddlIsClock"]))
                    model.IsClock = bool.Parse(Request.Form["ddlIsClock"]);
                if (!string.IsNullOrEmpty(Request.Form["ddlIsClose"]))
                    model.IsClose = bool.Parse(Request.Form["ddlIsClose"]);
                if (model.MConfig != null)
                    model.MConfig.JJTypeList = Request.Form["txtJJTypeList"].Trim();
                if (!string.IsNullOrEmpty(Request.Form["txtPassword"].Trim()))
                {
                    model.Password = Request.Form["txtPassword"].Trim();
                    model.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password + model.Salt, "MD5").ToUpper();
                }
                if (!string.IsNullOrEmpty(Request.Form["txtSecPsd"].Trim()))
                {
                    model.SecPsd = Request.Form["txtSecPsd"].Trim();
                    model.SecPsd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.SecPsd + model.Salt, "MD5").ToUpper();
                }
                BllModel.Update(model, MyHs);
            }

            if (BLL.CommonBase.RunHashtable(MyHs))
                return "操作成功";
            return "操作失败";
        }
    }
}