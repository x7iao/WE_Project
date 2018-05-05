using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.ChangeMoney
{
    public partial class HKChange : BasePage
    {
        protected Dictionary<string, Model.Reward> ListReward = BLL.Reward.List;
        protected override void SetPowerZone()
        {
            RioMJB.Checked = true;
            foreach (Model.BankModel item in BLL.Member.ManageMember.GetMyBankInfo())
            {
                ddlToBank.Items.Add(item.Bank);
            }
            Model.Member model = TModel;
            txtBankName.Value = model.BankCardName;
            txtFromBank.Value = model.Bank;
            txtHKDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }

        private Model.HKModel HKModel
        {
            get
            {
                Model.HKModel model = new Model.HKModel();
                model.HKCreateDate = DateTime.Now;
                model.BankName = Request.Form["txtBankName"];
                model.FromBank = Request.Form["txtFromBank"];
                model.HKDate = DateTime.Parse(Request.Form["txtHKDate"]);
                model.HKState = false;
                model.HKType = int.Parse(Request.Form["RioHK"]);
                model.HKType = 1;
                model.MID = TModel.MID;
                model.RealMoney = decimal.Parse(Request.Form["txtRealMoney"]);
                model.ToBank = Request.Form["ddlToBank"];
                model.ValidMoney = model.RealMoney * BLL.Configuration.Model.InFloat;
                model.IsAuto = false;
                return model;
            }
        }

        /// <summary>
        /// 货币转移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            Model.HKModel model = HKModel;
            if (BLL.HKModel.Insert(model))
            {
                BLL.Task.SendManage(TModel, "001", "会员账号：" + TModel.MID + "于当前时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                    "确认汇款信息，请注意查收，并及时审核！");
                return "操作成功，请等待财务审核";
            }
            return "操作失败";
        }
    }
}