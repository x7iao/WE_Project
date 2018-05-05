using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Member
{
    public partial class BuyActiveCode : BasePage
    {
        protected int activeCodeCount = 0;
        protected override void SetPowerZone()
        {
            //List<Model.ActiveCode> codeList = BLL.ActiveCode.GetList("UseState=0 and MID='" + BLL.Member.ManageMember.TModel.MID + "'");
            //activeCodeCount = codeList.Count;
            Model.Member model = TModel;
            txtBankName.Value = model.BankCardName;
            txtHKDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }

        private Model.HKModel HKModel
        {
            get
            {
                Model.HKModel model = new Model.HKModel();
                model.HKCreateDate = DateTime.Now;
                model.BankName = Request.Form["txtBankName"];
                model.HKDate = DateTime.Parse(Request.Form["txtHKDate"]);
                model.HKState = false;
                if (Request.Form["RioHK"] == "2")
                {
                    model.HKType = 2;
                }
                else
                {
                    model.HKType = 1;
                }
                model.MID = TModel.MID;
                model.RealMoney = decimal.Parse(Request.Form["txtValidMoney"]);
                if (model.HKType == 1)
                {
                    model.ValidMoney = (int)(model.RealMoney / BLL.MMMConfig.Model.MCWPrice);
                }
                else
                {
                    model.ValidMoney = (int)(model.RealMoney / BLL.MMMConfig.Model.ActiveCodePrice);
                }
                model.IsAuto = false;
                return model;
            }
        }

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