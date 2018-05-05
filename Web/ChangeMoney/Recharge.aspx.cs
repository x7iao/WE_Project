using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WE_Project.Web.ChangeMoney
{
    public partial class Recharge : BasePage
    {
        protected string type = "";
        protected string hktypeflag = "1";
        protected override void SetPowerZone()
        {
            type = Request.QueryString["type"];
            if (!string.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    case "qq":
                        spTitle.InnerHtml = "财付通充值";
                        spReceiveName.InnerHtml = "财付通";
                        spReceiveName2.InnerHtml = "财付通";
                        spReceiveName3.InnerHtml = "财付通";
                        hkType.Value = "1";
                        hktypeflag = "1";
                        //Model.BankModel bank = GetBankModel("cft");
                        //if (bank != null)
                        //{
                        //    chargeName.InnerHtml = bank.BankNumber;
                        //}
                        break;
                    case "alipay":
                        spTitle.InnerHtml = "支付宝充值";
                        spReceiveName.InnerHtml = "支付宝";
                        spReceiveName2.InnerHtml = "支付宝";
                        spReceiveName3.InnerHtml = "支付宝";
                        hkType.Value = "2";
                        hktypeflag = "2";
                        //Model.BankModel bank1 = GetBankModel("zfb");
                        //if (bank1 != null)
                        //{
                        //    chargeName.InnerHtml = bank1.BankNumber;
                        //}
                        break;
                    case "bank":
                        spTitle.InnerHtml = "网银充值";
                        spReceiveName.InnerHtml = "银行卡";
                        spReceiveName2.InnerHtml = "银行卡";
                        spReceiveName3.InnerHtml = "银行卡";
                        hkType.Value = "3";
                        hktypeflag = "3";
                        //Model.BankModel bank2 = GetBankModel("VISA");
                        //if (bank2 != null)
                        //{
                        //    chargeName.InnerHtml = bank2.BankNumber;
                        //}
                        break;
                }
            }
        }

        protected Model.BankModel GetBankModel(string type)
        {
            return BLL.BankModel.GetList("MID='" + BLL.Member.ManageMember.TModel.MID + "' and Bank in (select Id from [Sys_BankInfo] where Code='" + type + "' and IsDeleted=0)").FirstOrDefault();
        }

        private Model.HKModel HKModel
        {
            get
            {
                Model.HKModel model = new Model.HKModel();
                model.HKCreateDate = DateTime.Now;
                model.BankName = Request.Form["txtFromName"];
                model.FromBank = Request.Form["txtFrom"];
                model.HKDate = DateTime.Parse(Request.Form["txtTime"]);
                model.HKState = false;
                model.HKType = int.Parse(Request.Form["hkType"]);
                model.MID = TModel.MID;
                model.RealMoney = decimal.Parse(Request.Form["txtMoney"]);
                //model.ToBank = Request.Form["ddlToBank"];
                //model.ValidMoney = model.RealMoney / BLL.Configuration.Model.InFloat;
                model.Remark = Request.Form["txtRemark"];
                model.IsAuto = false;
                return model;
            }
        }


        protected override string btnAdd_Click()
        {
            Model.HKModel model = HKModel;
            if (BLL.HKModel.Insert(model))
            {
                //BLL.Task.SendManage(TModel, "001", "会员账号：" + TModel.MID + "于当前时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                //    "确认汇款信息，请注意查收，并及时审核！");
                return "操作成功，请公司财务审核";
            }
            return "操作失败";
        }
    }
}