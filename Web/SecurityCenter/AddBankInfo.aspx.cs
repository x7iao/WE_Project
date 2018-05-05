using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonBLL;
using System.Collections;

namespace WE_Project.Web.SecurityCenter
{
    public partial class AddBankInfo : BasePage
    {
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
                txtMID.Attributes.Add("readonly", "readonly");
            else
                lb_Tip.Visible = false;
            chkIsPrimary.Checked = true;
            txtBankCardName.Value = TModel.MName;
            txtMID.Value = TModel.MID;
            Sys_BankInfoBLL bll = new Sys_BankInfoBLL();
            txtBank.DataSource = bll.GetList(" 1=1 and  IsDeleted=0 and Status=1 order by ID desc");
            txtBank.DataTextField = "Name";
            txtBank.DataValueField = "Id";
            txtBank.DataBind();
            txtBankCardName.Value = TModel.MName;
        }
        private Model.BankModel BankInfo
        {
            get
            {
                Model.BankModel model = new Model.BankModel();
                model.Bank = Request.Form["txtBank"];
                model.BankCardName = Request.Form["txtBankCardName"];
                model.BankCreateDate = DateTime.Now;
                model.BankNumber = Request.Form["txtBankNumber"];
                model.Branch = Request.Form["txtBranch"];
                model.MID = Request.Form["txtMID"];
                if (!TModel.Role.IsAdmin)
                    model.MID = TModel.MID;
                model.IsPrimary = Request.Form["chkIsPrimary"] == "on";
                return model;
            }
        }
        protected override string btnAdd_Click()
        {
            Hashtable hs = new Hashtable();
            Model.BankModel bank = BankInfo;
            BLL.BankModel.Insert(bank, hs);
            bank.Bank = "3";
            bank.BankCardName = "支付宝";
            bank.BankNumber = Request.Form["txtAlPay"];
            bank.Branch = "支付宝";
            BLL.BankModel.Insert(bank, hs);
            if (BLL.CommonBase.RunHashtable(hs))
                return "操作成功";
            return "操作失败";
        }
    }
}