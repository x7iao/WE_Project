using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WE_Project.Web.Member
{
    public partial class UpMember : BasePage
    {
        protected string MyMAgencyTypeRdo;
        protected string MAgencyTypeColor;
        protected decimal maxUpMAgency;
        protected Model.Member sjmodel;
        protected decimal NeedTotalMJB = 0;
        //protected string url = "Member/UpMember.aspx";

        protected override void SetValue(string id)
        {
            //url = "Member/SHList.aspx";
            //sjmodel = BllModel.GetModel(id);
            //hdmid.Value = sjmodel.MID;
        }

        protected override void SetValue()
        {
            //sjmodel = TModel;
            //hdmid.Value = sjmodel.MID;
        }

        protected override void SetPowerZone()
        {
            //NeedTotalMJB = sjmodel.GCount * BLL.Configuration.Model.GPrice;
            //BindDdlPwdQuestion(ddl_PwdQuestion);
            //foreach (Model.SHMoney item in BLL.Configuration.Model.SHMoneyList.Values.Where(emp => emp.MAgencyType != "001"))
            //{
            //    MAgencyTypeColor += "<td style='width:60px;color:#00CCFF;'>" + item.MAgencyName + "<br />[" + item.Money + "]</td>";
            //    //if (item.Money < sjmodel.MAgencyType.Money || !BLL.ChangeMoney.EnoughChange(TModel.MID, item.Money - sjmodel.MAgencyType.Money, "MJB"))
            //    //    continue;
            //    //else
            //    if (item.MAgencyType == "002")
            //        MyMAgencyTypeRdo += "<input name='AgencyTypeList' id='" + item.MAgencyType + "' value='" + item.MAgencyType + "' type='radio' checked='checked' />" + item.MAgencyName + "[" + (sjmodel.GCount * BLL.Configuration.Model.GPrice) + "]&nbsp;";
            //}
            //if (string.IsNullOrEmpty(MyMAgencyTypeRdo))
            //    MyMAgencyTypeRdo += "暂不可升级";
        }

        protected override string btnModify_Click()
        {
            //判断是否信息完整
            if (string.IsNullOrEmpty(TModel.BankCardName) || (string.IsNullOrEmpty(TModel.BankNumber) && string.IsNullOrEmpty(TModel.NumID)))
            {
                return "请先完善资料";
            }

            //校验激活码
            string activeCode = Request.Form["txtActiveCode"];
            Model.ActiveCode list = BLL.ActiveCode.GetList("Code='" + activeCode + "' and UseState not in (2,4)").FirstOrDefault();
            if (list == null)
            {
                return "激活码无效";
            }

            Model.SHMoney shmoney = BLL.Configuration.Model.SHMoneyList["002"];//默认002
            //if (BLL.ChangeMoney.EnoughChange(TModel.MID, BLL.Configuration.Model.YLMoney, "MHB"))
            //{
            try
            {
                if (BLL.Member.upmidlist.Contains(TModel.MID))
                    return "2";
                else
                    BLL.Member.upmidlist.Add(TModel.MID);

                Hashtable MyHs = new Hashtable();
                list.UseMID = TModel.MID;
                list.UseState = 2;
                list.UseTime = DateTime.Now;
                BLL.ActiveCode.Update(list, MyHs);
                return BllModel.UpMAgencyType(shmoney, TModel.MID, TModel, 0, MyHs);
            }
            finally
            {

                if (BLL.Member.upmidlist.Contains(TModel.MID))
                    BLL.Member.upmidlist.Remove(TModel.MID);
            }
            //}
            //else
            //{
            //    return "您的激活币账号余额不足";
            //}
        }
    }
}