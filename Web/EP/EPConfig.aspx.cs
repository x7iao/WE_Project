using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.EP
{
    public partial class EPConfig : BasePage
    {
        protected string _content = "";
        protected Model.EPConfig EPModel
        {
            get
            {
                Model.EPConfig model = BLL.EPConfig.EPConfigModel;
                model.EPStartTime = DateTime.Parse(Request.Form["txtEPStartTime"]);
                model.EPEndTime = DateTime.Parse(Request.Form["txtEPEndTime"]);
                model.EPJYBaseMoney = int.Parse(Request.Form["txtEPJYBaseMoney"]);
                model.EPJYMAgencyTypeStr = Request.Form["txtEPJYMAgencyTypeStr"];
                model.EPJYMinMoney = int.Parse(Request.Form["txtEPJYMinMoney"]);
                model.EPJYType = int.Parse(Request.Form["ddlEPJYType"]);
                model.EPMoneyStr = Request.Form["txtEPMoneyStr"];
                model.EPMoneyType = Request.Form["ddlEPMoneyType"];
                model.EPProtocol = HttpUtility.UrlDecode(Request.Form["hdEPProtocol"]);
                model.EPState = bool.Parse(Request.Form["ddlEPState"]);
                model.EPTimeOut = int.Parse(Request.Form["txtEPTimeOut"]);
                model.EPTimeOutCount = int.Parse(Request.Form["txtEPTimeOutCount"]);
                model.EPTimeOutJXCount = int.Parse(Request.Form["txtEPTimeOutJXCount"]);
                model.EPTakeOffMoney = decimal.Parse(Request.Form["txtEPTakeOffMoney"]);

                return model;
            }
            set
            {
                txtEPJYBaseMoney.Value = value.EPJYBaseMoney.ToString();
                txtEPJYMAgencyTypeStr.Value = value.EPJYMAgencyTypeStr;
                txtEPJYMinMoney.Value = value.EPJYMinMoney.ToString();
                txtEPMoneyStr.Value = value.EPMoneyStr;
                txtEPStartTime.Value = value.EPStartTime.ToString("HH:mm");
                txtEPEndTime.Value = value.EPEndTime.ToString("HH:mm");
                txtEPTimeOut.Value = value.EPTimeOut.ToString();
                txtEPTimeOutCount.Value = value.EPTimeOutCount.ToString();
                txtEPTimeOutJXCount.Value = value.EPTimeOutJXCount.ToString();
                ddlEPJYType.Value = value.EPJYType.ToString();
                ddlEPMoneyType.Value = value.EPMoneyType;
                ddlEPState.Value = value.EPState.ToString();
                _content = value.EPProtocol;

                txtEPTakeOffMoney.Value = value.EPTakeOffMoney.ToString();
            }
        }

        protected override void SetPowerZone()
        {
            BLL.EPJX service = new BLL.EPJX();
            service.CheckedTimeOut();
            EPModel = BLL.EPConfig.EPConfigModel;
        }

        protected override string btnModify_Click()
        {
            if (BLL.EPConfig.Update(EPModel))
            {
                BLL.EPConfig.EPConfigModel = null;
                return "操作成功";
            }
            return "操作失败";
        }
    }
}