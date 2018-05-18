using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace WE_Project.Web.Mafull
{
    public partial class GetMoney : BasePage
    {
        protected Model.MHelpMatch match;
        protected Model.Member getMemberModel;
        protected Model.Member getTJMemberModel;

        protected override void SetPowerZone()
        {

        }

        protected override void SetValue(string id)
        {
            match = BLL.MHelpMatch.GetModel(id);
            hidId.Value = id;
            if (match != null)
            {
                getMemberModel = BllModel.GetModel(match.OfferMID);
                getTJMemberModel = BllModel.GetModel(getMemberModel.MTJ);

                spLeaveTime.InnerHtml = MatchTimeLeave(match, MMMMatchTimeType.ConfirmLimitTime, "收款确认倒计时", "");
                //DateTime PayTime = Convert.ToDateTime(match.PayTime);
                //DateTime matchTimeAdd = PayTime.AddMinutes(BLL.MMMConfig.Model.ConfirmLimitTimes);//以分钟计算
                //TimeSpan d3 = matchTimeAdd.Subtract(DateTime.Now);

                //long totalMM = Convert.ToInt64(Math.Round(d3.TotalMilliseconds, 0).ToString());
                ////totalMM = totalMM * 60000;
                //spLeaveTime.InnerHtml = (totalMM / 3600000).ToString() + "小时" + ((totalMM / 60000) % 60).ToString() + "分钟" + ((totalMM / 1000) % 60).ToString() + "秒";
                if (match.MatchState == 2)
                {
                    btnOK.Visible = true;
                }
                txtjujuemessage.Value = match.PicUrl1;
            }
        }

        protected override string btnAdd_Click()
        {
            lock (BLL.MHelpMatch.thisLock)
            {
                //匹配记录
                Model.MHelpMatch match = BLL.MHelpMatch.GetModel(Request.Form["hidId"]);
                if (match != null)
                {
                    Hashtable MyHs = new Hashtable();
                    //收款
                    string result = BLL.MHelpMatch.GetMoney(match, Request.Form["ddlPicUrl3"], MyHs);
                    if (string.IsNullOrEmpty(result))
                    {
                        if (BLL.CommonBase.RunHashtable(MyHs))
                        {
                            Model.Member member1 = BLL.Member.GetModelByMID(match.OfferMID);
                            Model.MOfferHelp offer = BLL.MOfferHelp.GetModel(match.OfferId);
                            //BLL.CommonBase.RunHashtable(BLL.Member.UpdateTran(member1.MID, "AgencyCode", "003", null, true, SqlDbType.VarChar, new Hashtable()));
                            //Model.SHMoney shmoney = BLL.Configuration.Model.SHMoneyList["003"];

                            //BllModel.UpMAgencyType(shmoney, member1.MID, member1, 0, new Hashtable());
                            //member1.AgencyCode = "003";
                            //member1.MAgencyType = shmoney;
                            //BLL.ChangeMoney.R_SJ(member1.MID);
                            string Msg = "尊敬的会员您好！您订单号" + offer.SQCode + "买入许愿果的订单已经确认收款(匹配编号[" + match.MatchCode + "])，请注意查看，感谢您的参与！祝您生活愉快！";
                            Model.SMS model = new Model.SMS { SType = Model.SMSType.QT, Tel = member1.Tel, SContent = Msg };
                            string error = "";
                            BLL.SMS.Insert(model, ref error);
                            return "1";
                        }
                        else
                        {
                            return "确认收款失败";
                        }
                    }
                    else
                    {
                        return result;
                    }
                }
                return "付款记录不存在！";
            }
        }

        protected override string btnModify_Click()
        {
            lock (BLL.MHelpMatch.thisLock)
            {
                Model.MHelpMatch match = BLL.MHelpMatch.GetModel(Request.Form["hidId"]);
                if (match != null)
                {
                    if (match.MatchState == 3)
                    {
                        return "您已确认过收款，申请拒绝交易失败";
                    }
                    match.PicUrl1 = Request.Form["txtjujuemessage"];
                    //string Msg = "尊敬的会员：您好，您的手机验证码为[" + match.GetMID + "," + new Random().Next(10000, 999999).ToString() + "]，请及时注册，谢谢!";
                    //Model.SMS model = new Model.SMS { SType = Model.SMSType.QT, Tel = BLL.MMMConfig.Model.JJJYTel, SContent = Msg, SMSKey = match.GetMID };
                    //string error = "";
                    //BLL.SMS.Insert(model, ref error);
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