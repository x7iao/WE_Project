using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.PrizePool
{
    public partial class DTFHAccounts : BasePage
    {
        protected override void SetValue()
        {
            txtPCodeStr.Value = "鸿运宝结算";
            string[] Fhinfo = BLL.Accounts.GetFHInfo("007", "").Split(',');
            txtFHCount.Value = Fhinfo[0];
            //txtTotalFHMoney.Value = (int.Parse(txtFHCount.Value) * BLL.Configuration.Model.JJBEveryDayMoney).ToString();
            Model.Accounts amodel = BLL.Accounts.GetTopModel("007", "");
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
                model.PCode = "007";
                model.ARemark = Request.Form["txtFHMoney"];
                return model;
            }
        }

        protected override string btnAdd_Click()
        {
            if (BLL.Accounts.Insert(Model))
                return "操作成功";
            return "操作失败";
        }
    }
}