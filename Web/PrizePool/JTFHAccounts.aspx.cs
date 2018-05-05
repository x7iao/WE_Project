using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.PrizePool
{
    public partial class JTFHAccounts : BasePage
    {
        protected override void SetValue()
        {

            //获取本次结算信息
            string[] Fhinfo = BLL.Accounts.GetFHInfo("003", "").Split(',');

            txtMemberCount.Value = Fhinfo[3];
            txtTotalMoney.Value = Fhinfo[0];
            txtDayLineLnterest.Value = Fhinfo[1];
            txtHonestyLiXi.Value = Fhinfo[2];



            //日利息
            //txtDayLineLnterestPercent.Value = BLL.MMMConfig.Model.DayLineLnterest.ToString();
            //txtHonestyLiXiPercent.Value = BLL.MMMConfig.Model.HonestyLiXi.ToString();
 
            //获取上次结算信息
            Model.Accounts amodel = BLL.Accounts.GetTopModel("003", "");
            if (amodel != null)
            {
                lbAccountsDate.Value = amodel.AccountsDate.ToString("yyyy-MM-dd HH:mm:ss");
                lbFHCount.Value = amodel.FHCount.ToString();
                lbIsAuto.Value = amodel.IsAuto ? "自动" : "手动";
                lbTotalFHMoney.Value = amodel.TotalFHMoney.ToString();
            }
        }

        private Model.Accounts Model
        {
            get
            {
                Model.Accounts model = new Model.Accounts();
                model.CreateDate = DateTime.Now;
                model.IsAuto = false;
                model.PCode = "003";
                model.ARemark = Request.Form["txtFHMoney"];
                //此处应给AccountMember赋值，共有多少个会员进行日分红
                //model.AccountMember = BLL.ChangeMoney.GetFHListAndMoney();
                return model;
            }
        }

        protected override string btnAdd_Click()
        {
            if (BLL.Configuration.Model.AutoDFH)
            {
                if (BLL.Accounts.Insert(Model))
                    return "操作成功";
                return "操作失败";
            }
            else
            {
                return "操作失败，静态分红未开启";
            }
        }
    }
}