using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WE_Project.Web.Mafull
{
    public partial class MatchView : BasePage
    {
        protected Model.MHelpMatch match;
        protected Model.Member model;
        protected Model.Member tjmodel;
        protected Model.Member thismodel;
        protected string tdleft = "";
        protected string tdright = "";
        protected string returnURL = "";
        protected string returnTitle = "";
        protected override void SetPowerZone()
        {
            returnURL = Request.QueryString["returnURL"];
            returnTitle = Request.QueryString["returnTitle"];
        }
        //protected string GetMatchState(object matchState)
        //{
        //    string result = string.Empty;
        //    if (!string.IsNullOrEmpty(matchState.ToString()))
        //    {
        //        if (matchState.ToString() == "1")
        //            result = "未付款";
        //        else if (matchState.ToString() == "2")
        //            result = "已付款未确认";
        //        else if (matchState.ToString() == "3")
        //            result = "已确认";
        //    }
        //    return result;
        //}
        protected override void SetValue(string id)
        {
            match = BLL.MHelpMatch.GetModel(id);
            hidId.Value = id;
            if (match != null)
            {
                //付款方信息
                if (match.GetMID == TModel.MID)
                {
                    tdleft = "收款方";
                    tdright = "付款方";
                    model = BLL.Member.ManageMember.GetModel(match.OfferMID);
                    tjmodel = BLL.Member.ManageMember.GetModel(model.MTJ);
                    thismodel = BLL.Member.ManageMember.GetModel(match.GetMID);
                }
                else
                {
                    tdleft = "付款方";
                    tdright = "收款方";
                    model = BLL.Member.ManageMember.GetModel(match.GetMID);
                    tjmodel = BLL.Member.ManageMember.GetModel(model.MTJ);
                    thismodel = BLL.Member.ManageMember.GetModel(match.OfferMID);
                }
            }
        }

        public string getpingjia(string type)
        {
            switch (type)
            {
                case "0": return "未评价";
                case "1": return "一星";
                case "2": return "二星";
                case "3": return "三星";
                case "4": return "四星";
                case "5": return "五星";
            }
            return "";
        }

        protected override string btnAdd_Click()
        {
            lock (BLL.MHelpMatch.thisLock)
            {
                Model.MHelpMatch match = BLL.MHelpMatch.GetModel(Request.Form["hidId"]);
                if (match != null && match.OfferPJ==0)
                {
                    Hashtable hs = new Hashtable();
                    int countxj =Convert.ToInt32( Request.Form["ddlPicUrl2"]);
                    if (countxj <= 0)
                        return "请选择星星评价";
                    match.OfferPJ = countxj;

                    Model.Member mget = BLL.Member.GetModelByMID(match.GetMID);
                    int kfcount = 5 - countxj;
                    countxj = mget.MConfig.EPXingCount < kfcount ? mget.MConfig.EPXingCount : kfcount;
                    if (countxj > 0)
                    {
                        hs.Add("update MemberConfig set EPXingCount=EPXingCount-" + countxj + " where MID='" + mget.MID + "';", null);
                    }
                    BLL.MHelpMatch.Update(match, hs);
                    BLL.CommonBase.RunHashtable(hs);
                }
            }
            return "1";
        }

        protected override string btnModify_Click()
        {
            lock (BLL.MHelpMatch.thisLock)
            {
                Model.MHelpMatch match = BLL.MHelpMatch.GetModel(Request.Form["hidId"]);
                if (match != null &&match.GetPJ==0)
                {
                    Hashtable hs = new Hashtable();
                    int countxj = Convert.ToInt32(Request.Form["ddlPicUrl3"]);
                    if (countxj <= 0)
                        return "请选择星星评价";
                    match.GetPJ = countxj;

                    Model.Member mget = BLL.Member.GetModelByMID(match.OfferMID);
                    int kfcount = 5 - countxj;
                    countxj = mget.MConfig.EPXingCount < kfcount ? mget.MConfig.EPXingCount : kfcount;
                    if (countxj > 0)
                    {
                        hs.Add("update MemberConfig set EPXingCount=EPXingCount-" + countxj + " where MID='" + mget.MID + "';", null);
                    }
                    BLL.MHelpMatch.Update(match, hs);
                    BLL.CommonBase.RunHashtable(hs);
                }
            }
            return "1";
        }
    }
}