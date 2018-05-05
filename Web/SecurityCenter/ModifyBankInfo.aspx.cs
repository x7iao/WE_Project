using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonBLL;

namespace WE_Project.Web.SecurityCenter
{
    public partial class ModifyBankInfo : BasePage
    {
        protected override void SetValue(string id)
        {
            Sys_BankInfoBLL bll = new Sys_BankInfoBLL();
            txtBank.DataSource = bll.GetList(" 1=1 and  IsDeleted=0 order by ID desc");
            txtBank.DataTextField = "Name";
            txtBank.DataValueField = "Id";
            txtBank.DataBind();
            hdBankCode.Value = id;
            BankInfo = BLL.BankModel.GetModel(id);
        }

        private Model.BankModel BankInfo
        {
            get
            {
                Model.BankModel model = BLL.BankModel.GetModel(Request.Form["hdBankCode"]);
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
            set
            {
               
                txtBank.Value = value.Bank;
                txtBankCardName.Value = value.BankCardName;
                txtBankNumber.Value = value.BankNumber;
                txtBranch.Value = value.Branch;
                txtMID.Value = value.MID;
                chkIsPrimary.Checked = value.IsPrimary;
            }
        }

        protected override string btnModify_Click()
        {
            if (BLL.BankModel.Update(BankInfo))
                return "操作成功";
            return "操作失败";
        }
    }
}