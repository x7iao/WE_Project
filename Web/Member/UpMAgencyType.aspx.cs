using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WE_Project.Web.Member
{
    public partial class UpMAgencyType : BasePage
    {
        protected string MyMAgencyTypeRdo;
        protected string MAgencyTypeColor;
        protected decimal maxUpMAgency;
        protected Model.Member sjmodel;
        protected string url = "Member/UpMAgencyType.aspx";

        protected override void SetValue(string id)
        {
            url = "Member/SHList.aspx";
            sjmodel = BllModel.GetModel(id);
            hdmid.Value = sjmodel.MID;
        }
        protected override void SetValue()
        {
            sjmodel = TModel;
            hdmid.Value = sjmodel.MID;
        }
        protected override void SetPowerZone()
        {
            //BindDdlPwdQuestion(ddl_PwdQuestion);
            foreach (Model.SHMoney item in BLL.Configuration.Model.SHMoneyList.Values.Where(emp => emp.MAgencyType != "001"))
            {
                MAgencyTypeColor += "<td style='width:60px;color:#00CCFF;'>" + item.MAgencyName + "<br />[" + item.Money + "]</td>";
                if (item.Money < sjmodel.MAgencyType.Money || !BLL.ChangeMoney.EnoughChange(TModel.MID, item.Money - sjmodel.MAgencyType.Money, "MJB"))
                    continue;
                else
                    MyMAgencyTypeRdo += "<input name='AgencyTypeList' id='" + item.MAgencyType + "' value='" + item.MAgencyType + "' type='radio' />" + item.MAgencyName + "[" + (item.Money - sjmodel.MAgencyType.Money) + "]&nbsp;";
            }
            if (string.IsNullOrEmpty(MyMAgencyTypeRdo))
                MyMAgencyTypeRdo += "暂不可升级";
        }

        protected override string btnModify_Click()
        {
            //if (Check_SQ_Answer())
            //{
            sjmodel = TModel;
            if (!string.IsNullOrEmpty(Request.Form["hdmid"]))
                sjmodel = BllModel.GetModel(Request.Form["hdmid"]);
            if (BLL.Configuration.Model.SHMoneyList.ContainsKey(Request.Form["AgencyTypeList"]))
            {
                Model.SHMoney shmoney = BLL.Configuration.Model.SHMoneyList[Request.Form["AgencyTypeList"]];
                if (BLL.ChangeMoney.EnoughChange(TModel.MID, shmoney.Money - sjmodel.MAgencyType.Money, "MJB"))
                {
                    try
                    {
                        if (BLL.Member.upmidlist.Contains(sjmodel.MID))
                            return "升级处理中，请等待！";
                        else
                            BLL.Member.upmidlist.Add(sjmodel.MID);
                        Hashtable MyHs = new Hashtable();
                        return BllModel.UpMAgencyType(shmoney, Request.Form["hdmid"], TModel, shmoney.Money - sjmodel.MConfig.SHMoney, MyHs);
                    }
                    finally
                    {
                        if (BLL.Member.upmidlist.Contains(sjmodel.MID))
                            BLL.Member.upmidlist.Remove(sjmodel.MID);
                    }
                }
                else
                {
                    return "您的账号余额不足";
                }
            }
            else
            {
                return "未知会员级别";
            }
            //}
            //else
            //    return "密保问题错误*";
        }
    }
}