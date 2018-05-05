using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Web.Security;

namespace WE_Project.Web.Mafull
{
    public partial class PayMoney : BasePage
    {
        protected Model.MHelpMatch match;
        protected Model.Member getMemberModel;
        protected Model.Member getTJMemberModel;
        protected double MillSecond = 0;
        protected override void SetPowerZone()
        {

        }

        protected override void SetValue(string id)
        {
            match = BLL.MHelpMatch.GetModel(id);
            hidId.Value = id;
            if (match != null)
            {
                getMemberModel = BllModel.GetModel(match.GetMID);
                getTJMemberModel = BllModel.GetModel(getMemberModel.MTJ);

                spLeaveTime.InnerHtml = MatchTimeLeave(match, MMMMatchTimeType.PayLimitTime, "", "", DateDiffType.SS);
                ////剩余付款时间
                //DateTime matchTime = match.MatchTime;
                //DateTime matchTimeAdd = matchTime.AddMinutes(BLL.MMMConfig.Model.PayLimitTimes);
                //if (match.ChangeCount == 1)
                //{
                //    matchTimeAdd = matchTime.AddMinutes(BLL.MMMConfig.Model.PayLimitTimesPre);
                //}
                //TimeSpan d3 = matchTimeAdd.Subtract(DateTime.Now);

                //long totalMM = Convert.ToInt64(Math.Round(d3.TotalMilliseconds, 0).ToString());
                //spLeaveTime.InnerHtml = (totalMM / 3600000).ToString() + "小时" + ((totalMM / 60000) % 60).ToString() + "分钟" + ((totalMM / 1000) % 60).ToString() + "秒";
            }
        }

        protected override string btnAdd_Click()
        {
            Model.MHelpMatch match = BLL.MHelpMatch.GetModel(Request.Form["hidId"]);
            if (match != null)
            {
                //DateTime payDate = DateTime.Parse(Request.Form["txtPayTime"]);
                string remark = Request.Form["txtRemark"];
                string pic1 = Request.Form["hduploadPic1"];
                string pic2 = Request.Form["uploadPic2"];
                string pic3 = Request.Form["uploadPic3"];
                //打款必须上传一张图片，否则不能打款
                if (string.IsNullOrEmpty(pic1) && string.IsNullOrEmpty(pic2) && string.IsNullOrEmpty(pic3))
                {
                    return "2";
                }

                match.MatchState = 2;
                match.PayTime = DateTime.Now;
                match.PicUrl = pic1;
                match.PicUrl1 = pic2;
                match.PicUrl2 = pic3;

                Hashtable MyHs = new Hashtable();

                ///不需要达人奖
                ///
                //Model.MOfferHelp off = BLL.MOfferHelp.GetModel(match.OfferId);
                //if (Convert.ToDecimal(((DateTime)match.PayTime - match.MatchTime).TotalMinutes) <= BLL.MMMConfig.Model.HonestyHour)
                //{
                //    if (off.SincerityState == 0)
                //    {
                //        off.SincerityState = 1;
                //        BLL.MOfferHelp.Update(off, MyHs);
                //    }
                //}

                if (BLL.CommonBase.RunHashtable(BLL.MHelpMatch.Update(match, MyHs)))
                {
                    Model.Member getMember = BLL.Member.GetModelByMID(match.GetMID);
                    Model.MGetHelp get = BLL.MGetHelp.GetModel(match.GetId);
                    string Msg = "尊敬的会员您好！您订单号" + get.SQCode + "得到帮助的订单对方已汇款(匹配编号[" + match.MatchCode + "])，核实无误后请确认，感谢您的参与！祝您生活愉快！";
                    Model.SMS model = new Model.SMS { SType = Model.SMSType.ZCYZ, Tel = getMember.Tel, SContent = Msg };
                    string error = "";
                    BLL.SMS.Insert(model, ref error);
                    return "1";
                }
            }
            return "0";
        }

        protected override string btnModify_Click()
        {
            lock (BLL.MHelpMatch.thisLock)
            {
                Model.MHelpMatch match = BLL.MHelpMatch.GetModel(Request.Form["hidId"]);
                if (match != null)
                {
                    if (match.MatchState != 1)
                    {
                        return "您已确认过付款，申请拒绝付款失败";
                    }
                    match.PicUrl1 = Request.Form["txtjujuemessage"];

                    if (BLL.MHelpMatch.Update(match))
                    {
                        return "1";
                    }
                    else
                    {
                        return "提交失败！";
                    }
                }
                return "付款记录不存在！";
            }
        }
    }
}