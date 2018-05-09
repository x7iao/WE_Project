using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.SysManage
{
    public partial class MMMConfigEdit : BasePage
    {
        protected override void SetPowerZone()
        {
            MMMModel = BLL.MMMConfig.Model;
        }

        public Model.MMMConfig MMMModel
        {
            get
            {
                Model.MMMConfig model = BLL.MMMConfig.Model;

                model.OfferHelpMin = decimal.Parse(Request.Form["txtOfferHelpMin"]);
                model.OfferHelpMax = decimal.Parse(Request.Form["txtOfferHelpMax"]);
                model.OfferHelpBase = decimal.Parse(Request.Form["txtOfferHelpBase"]);
                model.OfferHelpRangeTimes = int.Parse(Request.Form["txtOfferHelpRangeTimes"]);
                model.OfferHelpRangeCount = int.Parse(Request.Form["txtOfferHelpRangeCount"]);
                model.OfferHelpDayTotalMoney = decimal.Parse(Request.Form["txtOfferHelpDayTotalMoney"]);
                model.OfferHelpTimes = Request.Form["txtOfferHelpTimes"];
                model.OfferHelpSwitch = Request.Form["txtOfferHelpSwitch"] == "1";
                //model.OfferHelpNeedComplete = Request.Form["txtOfferHelpNeedComplete"] == "1";
                //model.OfferHelpFloat = decimal.Parse(Request.Form["txtOfferHelpFloat"]);
                model.GetHelpMin = decimal.Parse(Request.Form["txtGetHelpMin"]);
                model.GetHelpMax = decimal.Parse(Request.Form["txtGetHelpMax"]);
                model.GetHelpBase = decimal.Parse(Request.Form["txtGetHelpBase"]);
                model.GetHelpDayTotalMoney = decimal.Parse(Request.Form["txtGetHelpDayTotalMoney"]);
                model.GetHelpTimes = Request.Form["txtGetHelpTimes"];
                model.GetHelpSwitch = Request.Form["txtGetHelpSwitch"] == "1";
                model.GetHelpRangeTimes = int.Parse(Request.Form["txtGetHelpRangeTimes"]);
                model.GetHelpRangeCount = int.Parse(Request.Form["txtGetHelpRangeCount"]);
                //model.GetHelpNeedComplete = Request.Form["txtGetHelpNeedComplete"] == "1";
                model.GetHelpFloat = decimal.Parse(Request.Form["txtGetHelpFloat"]);
                model.ActiveCodePrice = decimal.Parse(Request.Form["txtActiveCodePrice"]);
                model.MCWPrice = decimal.Parse(Request.Form["txtMCWPrice"]);
                model.MOfferNeedMCW = int.Parse(Request.Form["txtMOfferNeedMCW"]);
                model.LineTimes = int.Parse(Request.Form["txtLineTimes"]);
                model.FreezeTimes = int.Parse(Request.Form["txtFreezeTimes"]);
                model.OutTimes = int.Parse(Request.Form["txtOutTimes"]);
                model.LiXi1 = decimal.Parse(Request.Form["txtLiXi1"]);
                model.LiXi2 = decimal.Parse(Request.Form["txtLiXi2"]);
                model.PayLimitTimes = int.Parse(Request.Form["txtPayLimitTimes"]);
                model.ConfirmLimitTimes = int.Parse(Request.Form["txtConfirmLimitTimes"]);
                model.HonestTimes = int.Parse(Request.Form["txtHonestTimes"]);
                model.HonestFloat = decimal.Parse(Request.Form["txtHonestFloat"]);
                model.NoLineTimesMoneyFloat = decimal.Parse(Request.Form["txtNoLineTimesMoneyFloat"]);
                model.PayLimitTimesPre = int.Parse(Request.Form["txtPayLimitTimesPre"]);
                model.ConfirmLimitTimesPre = int.Parse(Request.Form["txtConfirmLimitTimesPre"]);
                model.LastProportion = decimal.Parse(Request.Form["txtLastProportion"]);
                model.OfferTJKF = decimal.Parse(Request.Form["txtOfferTJKF"]);
                model.GetTJKF = decimal.Parse(Request.Form["txtGetTJKF"]);
                model.ReleaseConditionCount = int.Parse(Request.Form["txtReleaseConditionCount"]);
                model.ReleasePer = decimal.Parse(Request.Form["txtReleasePer"]);
                model.GLRewardFreezeTimes = int.Parse(Request.Form["txtGLRewardFreezeTimes"]);
                model.InterestPer = decimal.Parse(Request.Form["txtInterestPer"]);
                model.MacthSwitch = Request.Form["txtMacthSwitch"] == "1";
                model.MacthTimesRange = Request.Form["txtMacthTimesRange"];
                model.MHBBase = int.Parse(Request.Form["txtMHBBase"]);
                model.MHBRangeTimes = int.Parse(Request.Form["txtMHBRangeTimes"]);
                //model.MCWBase = int.Parse(Request.Form["txtMCWBase"]);
                //model.MCWRangeTimes = int.Parse(Request.Form["txtMCWRangeTimes"]);
                //model.MJBBase = int.Parse(Request.Form["txtMJBBase"]);
                //model.MJBRangeTimes = int.Parse(Request.Form["txtMJBRangeTimes"]);
                model.FreezeTimesOfRegister = int.Parse(Request.Form["txtFreezeTimesOfRegister"]);
                model.FreezeTimesOfOffer = int.Parse(Request.Form["txtFreezeTimesOfOffer"]);

                if (!SystemTimeRange.IsTimeList(model.MacthTimesRange))
                {
                    throw new Exception("匹配时间格式不正确");
                }
                if (!SystemTimeRange.IsTimeList(model.GetHelpTimes))
                {
                    throw new Exception("获得帮助时间格式不正确");
                }
                if (!SystemTimeRange.IsTimeList(model.OfferHelpTimes))
                {
                    throw new Exception("提供帮助时间格式不正确");
                }
                return model;
            }
            set
            {
                if (value != null)
                {
                    txtOfferHelpMin.Value = value.OfferHelpMin.ToString();
                    txtOfferHelpMax.Value = value.OfferHelpMax.ToString();
                    txtOfferHelpBase.Value = value.OfferHelpBase.ToString();
                    txtOfferHelpRangeTimes.Value = value.OfferHelpRangeTimes.ToString();
                    txtOfferHelpRangeCount.Value = value.OfferHelpRangeCount.ToString();
                    txtOfferHelpDayTotalMoney.Value = value.OfferHelpDayTotalMoney.ToString();
                    txtOfferHelpTimes.Value = value.OfferHelpTimes;
                    txtOfferHelpSwitch.Value = value.OfferHelpSwitch ? "1" : "0";
                    //txtOfferHelpNeedComplete.Value = value.OfferHelpNeedComplete ? "1" : "0";
                    //txtOfferHelpFloat.Value = value.OfferHelpFloat.ToString("F0");
                    txtGetHelpMin.Value = value.GetHelpMin.ToString();
                    txtGetHelpMax.Value = value.GetHelpMax.ToString();
                    txtGetHelpBase.Value = value.GetHelpBase.ToString();
                    txtGetHelpDayTotalMoney.Value = value.GetHelpDayTotalMoney.ToString();
                    txtGetHelpTimes.Value = value.GetHelpTimes;
                    txtGetHelpSwitch.Value = value.GetHelpSwitch ? "1" : "0";
                    txtGetHelpRangeTimes.Value = value.GetHelpRangeTimes.ToString();
                    txtGetHelpRangeCount.Value = value.GetHelpRangeCount.ToString();
                    //txtGetHelpNeedComplete.Value = value.GetHelpNeedComplete ? "1" : "0";
                    txtGetHelpFloat.Value = value.GetHelpFloat.ToString();
                    txtActiveCodePrice.Value = value.ActiveCodePrice.ToString();
                    txtMCWPrice.Value = value.MCWPrice.ToString();
                    txtMOfferNeedMCW.Value = value.MOfferNeedMCW.ToString("F0");
                    txtLineTimes.Value = value.LineTimes.ToString();
                    txtFreezeTimes.Value = value.FreezeTimes.ToString();
                    txtOutTimes.Value = value.OutTimes.ToString();
                    txtLiXi1.Value = value.LiXi1.ToString();
                    txtLiXi2.Value = value.LiXi2.ToString();
                    txtPayLimitTimes.Value = value.PayLimitTimes.ToString();
                    txtConfirmLimitTimes.Value = value.ConfirmLimitTimes.ToString();
                    txtHonestTimes.Value = value.HonestTimes.ToString();
                    txtHonestFloat.Value = value.HonestFloat.ToString();
                    txtNoLineTimesMoneyFloat.Value = value.NoLineTimesMoneyFloat.ToString();
                    txtPayLimitTimesPre.Value = value.PayLimitTimesPre.ToString();
                    txtConfirmLimitTimesPre.Value = value.ConfirmLimitTimesPre.ToString();

                    txtLastProportion.Value = value.LastProportion.ToString();
                    txtOfferTJKF.Value = value.OfferTJKF.ToString();
                    txtGetTJKF.Value = value.GetTJKF.ToString();
                    txtReleaseConditionCount.Value = value.ReleaseConditionCount.ToString();
                    txtReleasePer.Value = value.ReleasePer.ToString();
                    txtGLRewardFreezeTimes.Value = value.GLRewardFreezeTimes.ToString();
                    txtInterestPer.Value = value.InterestPer.ToString();
                    txtMacthSwitch.Value = value.MacthSwitch ? "1" : "0";
                    txtMacthTimesRange.Value = value.MacthTimesRange;
                    txtMHBBase.Value = value.MHBBase.ToString();
                    txtMHBRangeTimes.Value = value.MHBRangeTimes.ToString();
                    //txtMCWBase.Value = value.MCWBase.ToString();
                    //txtMCWRangeTimes.Value = value.MCWRangeTimes.ToString();
                    //txtMJBBase.Value = value.MJBBase.ToString();
                    //txtMJBRangeTimes.Value = value.MJBRangeTimes.ToString();
                    txtFreezeTimesOfRegister.Value = value.FreezeTimesOfRegister.ToString();
                    txtFreezeTimesOfOffer.Value = value.FreezeTimesOfOffer.ToString();
                }
            }
        }

        protected override string btnModify_Click()
        {
            if (BLL.MMMConfig.Update(MMMModel))
            {
                return "操作成功";
            }
            else
                return "操作失败";
        }

        protected override string btnOther_Click()
        {
            BLL.MMMConfig.ResetMMM(TModel);

            return "操作成功";
        }
    }
}