using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Security;
using System.Collections;
using System.Data;
using System.Text;
using CommonBLL;

namespace WE_Project.Web.Ajax
{
    public partial class AjaxM : BasePage
    {
        protected Model.Member memberModel = null;
        protected new void Page_Load(object sender, EventArgs e)
        {
            try
            {
                memberModel = TModel == null ? BllModel.TModel : TModel;
                BLL.Member.AddOnLine(memberModel.MID);
            }
            catch
            {

            }
            if (!BLL.CommonBase.TestSql(Request.QueryString.ToString() + Request.Form.ToString()))
            {
                Response.Write("非法字符");
                return;
            }
            if (!string.IsNullOrEmpty(Request["type"]))
                Operation(Request["type"]);
        }

        protected void Operation(string ope)
        {
            switch (ope)
            {
                case "TQJJ":
                    TQJJ();
                    break;
                case "enterMember":
                    enterMember();
                    break;
                case "del_MatchOff":
                    deleteMatchOff();
                    break;
                case "del_MatchGet":
                    deleteMatchGet();
                    break;
                case "DeleteOffer":
                    DeleteOffer();
                    break;
                case "getMName":
                    getMName();
                    break;
                case "FindMJB":
                    FindMJB();
                    break;
                case "FindMGP":
                    FindMGP();
                    break;
                case "Login":
                    getLogin();
                    break;
                case "SHMemberByActiveCode":
                    SHMemberByActiveCode();
                    break;
                case "ShMember":
                    ShMember();
                    break;
                case "SHTX":
                    SHTX();
                    break;
                case "DeleteMember":
                    DeleteMember();
                    break;
                case "DeleteMemberW":
                    DeleteMemberW();
                    break;
                case "getSecPsd":
                    GetSecPsd();
                    break;
                case "Verify":
                    Verify();
                    break;
                case "VerifyUrl":
                    VerifyUrl();
                    break;
                case "DeleteChangeMoney":
                    DeleteChangeMoney();
                    break;
                case "GetNotice":
                    GetNotice();
                    break;
                case "GetMessage":
                    GetMessage();
                    break;
                case "SendMessage":
                    SendMessage();
                    break;
                case "EndTask":
                    EndTask();
                    break;
                case "DeleteNotice":
                    DeleteNotice();
                    break;
                case "ShowNotice":
                    ShowNotice();
                    break;
                case "HideNotice":
                    HideNotice();
                    break;
                case "Del_Task":
                    DeleteTask();
                    break;
                case "ShowTask":
                    ShowTask();
                    break;
                case "HideTask":
                    HideTask();
                    break;
                case "ReadTask":
                    ReadTask();
                    break;
                case "NoReadTask":
                    NoReadTask();
                    break;
                case "FH":
                    FH();
                    break;
                case "SetVerify":
                    SetVerify();
                    break;
                case "shHKModel":
                    shHKModel();
                    break;
                case "deleteHKModel":
                    deleteHKModel();
                    break;
                case "DeleteBank":
                    DeleteBank();
                    break;
                case "GrantVerify":
                    GrantVerify();
                    break;
                case "SendCode":
                    SendCode();
                    break;
                case "sendCode2":
                    sendCode2();
                    break;
                case "SendCodeModifySecPsd":
                    SendCodeModifySecPsd();
                    break;
                case "SendCodeModifyFirstPsd":
                    SendCodeModifyFirstPsd();
                    break;
                case "SendSMSTest":
                    SendSMSTest();
                    break;
                case "SendEmailTest":
                    SendEmailTest();
                    break;
                case "DeleteAccounts":
                    DeleteAccounts();
                    break;
                case "Accounts":
                    Accounts();
                    break;
                case "Recover":
                    Recover();
                    break;
                case "isCanChangeByMember":
                    IsCanChangeByMember();
                    break;
                case "checkPwdAnswer":
                    checkPwdAnswer();
                    break;
                case "CheckContentID":
                    CheckContentID();
                    break;
                case "DeleteLanguage":
                    DeleteLanguage();
                    break;
                case "BCenter":
                    BCenter();
                    break;
                case "DeleteBCenter":
                    DeleteBCenter();
                    break;
                case "DealApply":
                    DealApply();
                    break;
                case "EPbuy"://买
                    EPbuy();
                    break;
                case "EPcancel"://取消
                    EPcancel();
                    break;
                case "EPpay"://确认付款
                    EPpay();
                    break;
                case "EPsellLast"://卖方确定
                    EPsellLast();
                    break;
                case "EPDelete"://卖方取消
                    EPDelete();
                    break;
                case "EPClose"://卖方关闭
                    EPClose();
                    break;
                case "FDReset":
                    FDReset();
                    break;
                //自动得到菜单的最大编号
                case "GetNewCid":
                    GetNewCid();
                    break;
                //校验手机号是否用过
                case "checkTel":
                    checkTel();
                    break;
                case "checkNumID":
                    checkNumID();
                    break;
                case "checkMTJ":
                    checkMTJ();
                    break;
                case "checkMID":
                    checkMID();
                    break;
                case "refarshMID":
                    refarshMID();
                    break;
                case "costMHB":
                    costMHB();
                    break;
                case "LockActiveCode":
                    LockActiveCode();
                    break;

                case "QDChange":
                    QDChange();
                    break;
                case "getIndexMsg":
                    getIndexMsg();
                    break;
                case "sendTelCodeForFindPwd":
                    sendTelCodeForFindPwd();
                    break;
                case "getIndexNews":
                    getIndexMsg();
                    break;
                case "checkTelCode":
                    checkTelCode();
                    break;
                case "isAdmin":
                    isAdmin();
                    break;

                #region 互助

                case "OfferSplit":
                    OfferSplit();
                    break;
                case "GetSplit":
                    GetSplit();
                    break;
                case "HandmatchHelp":
                    HandmatchHelp();
                    break;
                case "OfferPutScramble":
                    OfferPutScramble();
                    break;
                case "OfferScramble":
                    OfferScramble();
                    break;
                case "MatchGetMoney":
                    MatchGetMoney();
                    break;
                case "MatchGetLixiMoney":
                    MatchGetLixiMoney();
                    break;
                case "deleteMatch":
                    deleteMatch();
                    break;
                case "deleteMatchs":
                    deleteMatchs();
                    break;
                case "deleteOffer":
                    deleteOffer();
                    break;
                case "CancelOffer":
                    CancelOffer();
                    break;
                case "CancelHelp":
                    CancelHelp();
                    break;
                case "QDJ":
                    QDJ();
                    break;

                #endregion 互助
            }
        }

        private void OfferSplit()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                if (TModel.Role.IsAdmin)
                {
                    var list = Request["pram"].Split('~');
                    if (list.Count() == 2)
                    {
                        Model.MOfferHelp moffer = BLL.MOfferHelp.GetModel(list[1]);
                        if (moffer.PPState != 0 || moffer.DKState != 0)
                        {
                            Response.Write("拆分失败，该订单不能拆分");
                            return;
                        }
                        string[] cflist = list[0].Split(',');
                        decimal money = 0;
                        for (int i = 0; i < cflist.Length; i++)
                        {
                            try
                            {
                                money += decimal.Parse(cflist[i]);
                            }
                            catch (Exception)
                            {
                                Response.Write("输入数据有误，请确认");
                                return;
                                throw;
                            }
                        }
                        if (money != moffer.SQMoney)
                        {
                            Response.Write("拆分金额总数不正确，请确认");
                            return;
                        }
                        Hashtable MyHs = new Hashtable();
                        //拆分
                        for (int i = 0; i < cflist.Length; i++)
                        {
                            if (i == 0)
                            {
                                moffer.SQMoney = decimal.Parse(cflist[0]);
                                moffer.MFLMoney = moffer.SQMoney * BLL.MMMConfig.Model.NoLineTimesMoneyFloat;
                                BLL.MOfferHelp.Update(moffer, MyHs);
                            }
                            else
                            {
                                Model.MOfferHelp insertoffer = new Model.MOfferHelp();
                                insertoffer.SQCode = GetGuid();//订单匹配编号
                                //校验编号是否重复，重复的话重新生成
                                while (BLL.CommonBase.GetSingle("select SQCode from MOfferHelp where SQCode='" + insertoffer.SQCode + "'") != null)
                                {
                                    insertoffer.SQCode = GetGuid();//订单匹配编号
                                }
                                insertoffer.SQDate = moffer.SQDate;
                                insertoffer.SQMID = moffer.SQMID;
                                insertoffer.SQMoney = decimal.Parse(cflist[i]);
                                insertoffer.DayInterest = 0;// BLL.MMMConfig.Model.InterestPer* sqMoney;//订单利息(插入数据库前获取)
                                insertoffer.TotalInterest = 0;
                                insertoffer.TotalInterestDays = 0;
                                insertoffer.TotalSincerity = 0;
                                insertoffer.TotalSincerityDays = 0;
                                insertoffer.SincerityState = 0;
                                insertoffer.TotalSincerity = 0;
                                insertoffer.InterestState = 1;
                                insertoffer.MatchMoney = 0;
                                insertoffer.MFLMoney = insertoffer.SQMoney * BLL.MMMConfig.Model.NoLineTimesMoneyFloat;
                                insertoffer.HelpType = moffer.HelpType;
                                insertoffer.DKState = 0;
                                insertoffer.PPState = 0;

                                BLL.MOfferHelp.Insert(insertoffer, MyHs);
                            }
                        }

                        if (BLL.CommonBase.RunHashtable(MyHs))
                        {
                            Response.Write("1");
                            return;
                        }
                    }
                }
                else
                {
                    Response.Write("权限不足");
                    return;
                }
            }
            Response.Write("参数错误");
            return;
        }

        private void GetSplit()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                if (TModel.Role.IsAdmin)
                {
                    var list = Request["pram"].Split('~');
                    if (list.Count() == 2)
                    {
                        Model.MGetHelp mget = BLL.MGetHelp.GetModel(list[1]);
                        if (mget.PPState != 0 || mget.ConfirmState != 0)
                        {
                            Response.Write("拆分失败，该订单不能拆分");
                            return;
                        }
                        string[] cflist = list[0].Split(',');
                        decimal money = 0;
                        for (int i = 0; i < cflist.Length; i++)
                        {
                            try
                            {
                                money += decimal.Parse(cflist[i]);
                            }
                            catch (Exception)
                            {
                                Response.Write("输入数据有误，请确认");
                                return;
                                throw;
                            }
                        }
                        if (money != mget.SQMoney)
                        {
                            Response.Write("拆分金额总数不正确，请确认");
                            return;
                        }
                        Hashtable MyHs = new Hashtable();
                        //拆分
                        for (int i = 0; i < cflist.Length; i++)
                        {
                            if (i == 0)
                            {
                                mget.SQMoney = decimal.Parse(cflist[0]);
                                //mget.MFLMoney = mget.SQMoney * BLL.MMMConfig.Model.NoLineTimesMoneyFloat;
                                BLL.MGetHelp.Update(mget, MyHs);
                            }
                            else
                            {
                                Model.MGetHelp insertGet = new Model.MGetHelp();
                                insertGet.SQCode = GetGuid();//订单匹配编号
                                //校验编号是否重复，重复的话重新生成
                                while (BLL.CommonBase.GetSingle("select SQCode from MOfferHelp where SQCode='" + insertGet.SQCode + "'") != null)
                                {
                                    insertGet.SQCode = GetGuid();//订单匹配编号
                                }
                                insertGet.ConfirmState = 0;
                                insertGet.PPState = 0;
                                insertGet.MoneyType = mget.MoneyType;
                                insertGet.SQDate = mget.SQDate;
                                insertGet.SQMID = mget.SQMID;
                                insertGet.SQMoney = decimal.Parse(cflist[i]);
                                BLL.MGetHelp.Insert(insertGet, MyHs);
                            }
                        }

                        if (BLL.CommonBase.RunHashtable(MyHs))
                        {
                            Response.Write("1");
                            return;
                        }
                    }
                }
                else
                {
                    Response.Write("权限不足");
                    return;
                }
            }
            Response.Write("参数错误");
            return;
        }

        private void TQJJ()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Model.ChangeMoney model = BLL.ChangeMoney.GetModel(int.Parse(Request["pram"]));
                if (model != null && model.ToMID == TModel.MID)
                {
                    Hashtable MyHs = new Hashtable();
                    BLL.ChangeMoney.JDChangeTran(new List<Model.ChangeMoney>() { model }, MyHs);
                    if (BLL.CommonBase.RunHashtable(MyHs))
                    {
                        Response.Write("1");
                        return;
                    }
                    else
                    {
                        Response.Write("提取失败");
                        return;
                    }
                }
            }
            Response.Write("参数错误");
            return;
        }

        private void enterMember()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                if (TModel.Role.IsAdmin)
                {
                    Model.Member model = BLL.Member.GetModelByMID(Request["pram"]);
                    FormsAuthentication.SetAuthCookie(model.MID, true);
                    BLL.Member bllmodel = new BLL.Member { TModel = model };
                    Session["Member"] = bllmodel;
                    BLL.Member.AddOnLine(model.MID);
                    Response.Write("1");
                    return;
                }
            }
            Response.Write("");
            return;
        }

        public void HandmatchHelp()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                var pram = Request["pram"].Split('|');
                string offer = "'" + pram[0].Replace(",", "','") + "'";
                string get = "'" + pram[1].Replace(",", "','") + "'";
                Response.Write(BLL.MHelpMatch.MatchingHelp4(offer, get));
                return;
            }
            Response.Write("非法操作");
            return;
        }

        private void isAdmin()
        {
            if (BllModel.TModel.Role.IsAdmin)
            {
                Response.Write("1");
            }
        }

        /// <summary>
        /// 打款方违规
        /// </summary>
        public void deleteMatchOff()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Hashtable MyHs = new Hashtable();
                //管理员可以根据记录编号删除，收款方已匹配金额自动补回。
                Model.MHelpMatch match = BLL.MHelpMatch.GetModel(Request["pram"]);
                if (match.MatchState < 3)
                {
                    //BLL.MHelpMatch.Delete(match.Id, MyHs);
                    Model.MOfferHelp offer = BLL.MOfferHelp.GetModel(match.OfferId);

                    BLL.MHelpMatch.freezeMember(offer, MyHs, "违规打款");
                    //offer.MatchMoney = offer.MatchMoney - match.MatchMoney;
                    //if (offer.MatchMoney == 0)
                    //{
                    //    offer.PPState = 0;
                    //    offer.DKState = 0;
                    //    //删除订单
                    //    MyHs.Add(" delete from MOfferHelp where SQCode = '" + offer.SQCode + "' ", null);
                    //}
                    //else if (offer.Money > 0)
                    //{
                    //    offer.PPState = 2;
                    //    BLL.MOfferHelp.Update(offer, MyHs);
                    //}

                    //Model.MGetHelp get = BLL.MGetHelp.GetModel(match.GetId);
                    //get.MatchMoney = get.MatchMoney - match.MatchMoney;
                    //if (get.MatchMoney == 0)
                    //{
                    //    get.PPState = 0;
                    //}
                    //else if (get.Money > 0)
                    //{
                    //    get.PPState = 2;
                    //}
                    //BLL.MGetHelp.Update(get, MyHs);
                    //Model.Member offMemer = BLL.Member.GetModelByMID(offer.SQMID);
                    ////冻结打款方
                    //MyHs.Add("update member set IsClock='1',IsClose='1' where mid='" + offer.SQMID + "'", null);

                    if (BLL.CommonBase.RunHashtable(MyHs))
                    {
                        Response.Write("1");
                        return;
                    }
                }
            }

            Response.Write("处理失败");
            return;
        }

        /// <summary>
        /// 收款方违规(自动确认)
        /// </summary>
        public void deleteMatchGet()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Hashtable MyHs = new Hashtable();
                //管理员可以根据记录编号删除，收款方已匹配金额自动补回。
                Model.MHelpMatch match = BLL.MHelpMatch.GetModel(Request["pram"]);
                if (match != null && match.MatchState < 3)
                {
                    //收款
                    string result = BLL.MHelpMatch.GetMoney(match, Request.Form["ddlPicUrl3"], MyHs);
                    if (string.IsNullOrEmpty(result))
                    {
                        //冻结收款人
                        MyHs.Add("update member set IsClock='1',IsClose='1' where mid='" + match.GetMID + "'", null);
                        if (BLL.CommonBase.RunHashtable(MyHs))
                        {
                            Response.Write("1");
                            return;
                        }
                        else
                        {
                            Response.Write("处理失败");
                            return;
                        }
                    }
                    else
                    {
                        Response.Write(result);
                        return;
                    }
                }
            }

            Response.Write("参数异常");
            return;
        }

        private void CancelHelp()
        {
            lock (BLL.MHelpMatch.thisLock)
            {
                if (!string.IsNullOrEmpty(Request["pram"]))
                {
                    Hashtable hs = new Hashtable();
                    //
                    Model.MGetHelp get = BLL.MGetHelp.GetModel(Request["pram"]);
                    if (get.PPState == 5)
                    {
                        Response.Write("该订单已取消");
                        return;
                    }
                    if (get.PPState == 0)
                    {
                        get.PPState = 5;
                        BLL.MGetHelp.Update(get, hs);
                        if (BLL.CommonBase.RunHashtable(hs))
                        {
                            Response.Write("1");
                            return;
                        }
                    }
                }

                Response.Write("取消失败,非法操作");
                return;
            }
        }

        private void CancelOffer()
        {
            lock (BLL.MHelpMatch.thisLock)
            {
                if (!string.IsNullOrEmpty(Request["pram"]))
                {
                    Hashtable hs = new Hashtable();
                    //
                    Model.MOfferHelp offer = BLL.MOfferHelp.GetModel(Request["pram"]);
                    if (offer.PPState == 5)
                    {
                        Response.Write("该订单已取消");
                        return;
                    }
                    if (offer.PPState == 0)
                    {
                        offer.PPState = 5;
                        BLL.MOfferHelp.Update(offer, hs);


                        if (BLL.CommonBase.RunHashtable(hs))
                        {
                            Response.Write("1");
                            return;
                        }
                    }
                }

                Response.Write("取消失败,非法操作");
                return;
            }
        }

        private void QDJ()
        {
            //Model.MOfferHelp off = BLL.MOfferHelp.GetQDOfferMoney(TModel.MID);
            //if (off != null)
            //{
            //    BLL.ChangeMoney.R_QD(TModel);
            //}

            //Response.Write("无可领取签到奖");
            //return;
        }

        private void checkTelCode()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                string[] parm = Request["pram"].Split('_');
                if (parm.Length == 2)
                {
                    string code = BLL.SMS.GetSKeyBuyTel(parm[0], Model.SMSType.ZCYZ);
                    if ((string.IsNullOrEmpty(code) || code != parm[1]))
                    {
                        Response.Write("错误的验证码");
                        return;
                    }
                    else
                    {
                        Response.Write("");
                        return;
                    }
                }
            }
            Response.Write("错误的验证码");
            return;
        }
        public struct writeemail
        {
            public string text { get; set; }
            public string datetime { get; set; }
            public string siteName { get; set; }
        }
        public void getIndexMsg()
        {
            List<Model.WriteEmail> listWE = BLL.WriteEmail.GetList(10, "");
            List<writeemail> list = new List<writeemail>();
            string result = string.Empty;
            foreach (Model.WriteEmail em in listWE)
            {
                list.Add(new writeemail { text = em.WriteContent, datetime = em.WriteTime.ToString("yyyy-MM-dd"), siteName = "false" });
                //result += "{\"text\":\"" + em.WriteContent + "\",\"datetime\":\"" + em.WriteTime.ToShortDateString() + "\",\"siteName\":false},";

            }
            if (list.Count > 0)
            {
                result = JavaScriptConvert.SerializeObject(list);
            }
            Response.Write(result);
            return;
        }
        public void deleteOffer()
        {
            lock (BLL.MHelpMatch.thisLock)
            {
                if (!string.IsNullOrEmpty(Request["pram"]))
                {
                    Hashtable hs = new Hashtable();
                    //
                    Model.MOfferHelp offer = BLL.MOfferHelp.GetModel(Request["pram"]);
                    if (offer.PPState == 5)
                    {
                        Response.Write("该订单已取消");
                        return;
                    }
                    if (offer.PPState == 0)
                    {
                        offer.PPState = 5;
                        BLL.MOfferHelp.Update(offer, hs);


                        if (BLL.CommonBase.RunHashtable(hs))
                        {
                            Response.Write("1");
                            return;
                        }
                    }
                }

                Response.Write("删除失败");
                return;
            }
        }
        public void QDChange()
        {
            Hashtable hs = new Hashtable();
            string msg = "";
            if (TModel.MState)
            {
                if (Convert.ToInt32(BLL.CommonBase.GetSingle("select count(1) from Changemoney where Tomid='" + TModel.MID + "' and changetype='QD' and changedate>'" + DateTime.Now.ToString("yyyy-MM-dd") + "'")) > 0)
                {
                    msg = "您已签到！";
                }
                else
                {
                    int qd = TModel.MConfig.TJCount + 1;
                    if (qd > 30)
                        qd = 30;
                    BLL.ChangeMoney.HBChangeTran(qd, BLL.Member.ManageMember.TModel.MID, TModel.MID, "QD", null, "MJB", "", hs);
                    if (BLL.CommonBase.RunHashtable(hs))
                        msg = "签到成功";
                    else
                        msg = "签到失败";
                }
            }
            else
            {
                msg = "请先激活账号";
            }

            Response.Write(msg);
            return;
        }
        public void deleteMatchs()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Hashtable MyHs = new Hashtable();
                //管理员可以根据记录编号删除，收款方已匹配金额自动补回。
                var strList = Request["pram"].Split(',');
                foreach (string id in strList)
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        Model.MHelpMatch match = BLL.MHelpMatch.GetModel(id);
                        if (match.MatchState < 3)
                        {
                            BLL.MHelpMatch.Delete(match.Id, MyHs);
                            Model.MOfferHelp offer = BLL.MOfferHelp.GetModel(match.OfferId);
                            offer.MatchMoney = offer.MatchMoney - match.MatchMoney;
                            if (offer.MatchMoney == 0)
                            {
                                offer.PPState = 0;
                                offer.DKState = 0;
                            }
                            else if (offer.Money > 0)
                            {
                                offer.PPState = 2;
                            }
                            BLL.MOfferHelp.Update(offer, MyHs);

                            Model.MGetHelp get = BLL.MGetHelp.GetModel(match.GetId);
                            get.MatchMoney = get.MatchMoney - match.MatchMoney;
                            if (get.MatchMoney == 0)
                            {
                                get.PPState = 0;
                            }
                            else if (get.Money > 0)
                            {
                                get.PPState = 2;
                            }
                            BLL.MGetHelp.Update(get, MyHs);

                            string sql = "update member set IsClock='1',IsClose='1' where mid='" + offer.SQMID + "'";
                            if (!MyHs.ContainsKey(sql))
                            {
                                MyHs.Add(sql, null);
                                MyHs.Add("update member set IsClock='1',IsClose='1' where mid='" + offer.SQMID + "'; select '" + Guid.NewGuid() + "'", null);
                            }
                        }

                    }
                }
                if (BLL.CommonBase.RunHashtable(MyHs))
                {
                    Response.Write("删除成功");
                    return;
                }
            }

            Response.Write("删除失败");
            return;
        }
        public void deleteMatch()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Hashtable hs = new Hashtable();
                //管理员可以根据记录编号删除，收款方已匹配金额自动补回。
                Model.MHelpMatch match = BLL.MHelpMatch.GetModel(Request["pram"]);
                if (match.MatchState < 3)
                {
                    BLL.MHelpMatch.Delete(match.Id, hs);
                    //
                    Model.MOfferHelp offer = BLL.MOfferHelp.GetModel(match.OfferId);
                    offer.MatchMoney = offer.MatchMoney - match.MatchMoney;
                    if (offer.MatchMoney == 0)
                    {
                        offer.PPState = 0;
                        offer.DKState = 0;
                    }
                    else if (offer.Money > 0)
                    {
                        offer.PPState = 2;
                    }
                    BLL.MOfferHelp.Update(offer, hs);

                    Model.MGetHelp get = BLL.MGetHelp.GetModel(match.GetId);
                    get.MatchMoney = get.MatchMoney - match.MatchMoney;
                    if (get.MatchMoney == 0)
                    {
                        get.PPState = 0;
                    }
                    else if (get.Money > 0)
                    {
                        get.PPState = 2;
                    }
                    BLL.MGetHelp.Update(get, hs);

                    hs.Add("update member set IsClock='1',IsClose='1' where mid='" + offer.SQMID + "'", null);

                    if (BLL.CommonBase.RunHashtable(hs))
                    {
                        Response.Write("1");
                        return;
                    }
                }
            }

            Response.Write("删除失败");
            return;
        }

        private static object objOfferScramble = new object();

        public void OfferScramble()
        {
            if (!BLL.MMMConfigScramble.Model.OpenSwitch || !TestCloseTime(BLL.MMMConfigScramble.Model.OpenTimeList))
            {
                Response.Write("暂不开放抢单");
                return;
            }
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                lock (objOfferScramble)
                {
                    Model.MOfferHelp off = BLL.MOfferHelp.GetScrambleQDOfferMoney(TModel.MID);
                    if (off != null)
                    {
                        Response.Write("您有在冻结期内的订单，请冻结期后再进行抢单");
                        return;
                    }
                    Hashtable MyHs = new Hashtable();
                    Model.MOfferHelp offer = BLL.MOfferHelp.GetModel(Request["pram"]);
                    offer.HelpType = 1;
                    offer.SQMID = TModel.MID;
                    offer.DKState = 0;
                    offer.InterestState = 1;
                    offer.MatchMoney = 0;
                    offer.PPState = 0;
                    offer.SQDate = DateTime.Now;
                    offer.TotalInterest = 0;
                    offer.TotalInterestDays = 0;
                    offer.TotalSincerity = 0;
                    offer.TotalSincerityDays = 0;

                    BLL.MOfferHelp.Update(offer, MyHs);
                    if (BLL.CommonBase.RunHashtable(MyHs))
                    {
                        Response.Write("抢单成功");
                        return;
                    }
                }
            }

            Response.Write("抢单失败");
            return;
        }

        public void OfferPutScramble()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                if (TModel.Role.IsAdmin)
                {
                    var list = Request["pram"].Split(',');
                    Hashtable MyHs = new Hashtable();
                    foreach (var mm in list)
                    {
                        Model.MOfferHelp offer = BLL.MOfferHelp.GetModel(mm);

                        offer.HelpType = 98;
                        offer.SQDate = DateTime.Now;

                        BLL.MOfferHelp.Update(offer, MyHs);
                    }
                    if (BLL.CommonBase.RunHashtable(MyHs))
                    {
                        Response.Write("放入抢单列表成功");
                        return;
                    }
                }
            }

            Response.Write("放入抢单列表失败");
            return;
        }

        public void MatchGetLixiMoney()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Hashtable MyHs = new Hashtable();
                Model.MOfferHelp offer = BLL.MOfferHelp.GetModel(Request["pram"]);

                if (TModel.Role.IsAdmin)
                {
                    if (offer.PPState == 4)
                    {
                        //更新该提供帮助的匹配记录
                        decimal changeMoney = offer.TotalInterest;
                        BLL.ChangeMoney.HBChangeTran(changeMoney, BLL.Member.ManageMember.TModel.MID, offer.SQMID, "TGBZ", TModel, "MHB", "提供帮助(" + offer.SQCode + ")利息", MyHs);
                    }
                    offer.InterestState = 1;

                    BLL.MOfferHelp.Update(offer, MyHs);
                    if (BLL.CommonBase.RunHashtable(MyHs))
                    {
                        Response.Write("1");
                        return;
                    }
                }
            }

            Response.Write("解冻失败");
            return;
        }

        public void MatchGetMoney()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Hashtable MyHs = new Hashtable();
                Model.MOfferHelp offer = BLL.MOfferHelp.GetModel(Request["pram"]);
                //查看是否已转入马夫罗
                if (offer.PPState == 4)
                {
                    Response.Write("您已提款");
                    return;
                }
                //if (Convert.ToInt32(BLL.CommonBase.GetSingle("select count(1) from mhelpmatch where offerid=" + offer.Id + " and datalength(isnull(picurl2,''))=0")) > 0)
                //{
                //    Response.Write("您还有交易未完成评价，请先对收款方进行评价");
                //    return;
                //}
                //校验转入时间是否已到
                string op = OfferTimeLeave(offer, MMMOfferTimeType.FreezeTime, "解冻倒计时", "");
                if (!string.IsNullOrEmpty(op))
                {
                    Response.Write(op);
                    return;
                }
                //if (offer.HelpType == 0 && (DateTime.Now - (DateTime)offer.SQDate).TotalMinutes < BLL.MMMConfig.Model.FreezeTimes)
                //{
                //    string op = "解冻倒计时：" + LeaveTime((DateTime)offer.SQDate, BLL.MMMConfig.Model.FreezeTimes);
                //    Response.Write(op);
                //    return;
                //}
                //else if (offer.HelpType == 1 && (DateTime.Now - (DateTime)offer.SQDate).TotalMinutes < BLL.MMMConfigScramble.Model.FreezeTimes)
                //{
                //    string op = "解冻倒计时：" + LeaveTime((DateTime)offer.SQDate, BLL.MMMConfigScramble.Model.FreezeTimes);
                //    Response.Write(op);
                //    return;
                //}
                if (offer.SQMID == TModel.MID)
                {
                    //更新该提供帮助的匹配记录
                    decimal changeMoney = offer.SQMoney;
                    //if (offer.InterestState == 1)
                    {
                        changeMoney += offer.TotalInterest;
                        BLL.ChangeMoney.HBChangeTran(changeMoney, BLL.Member.ManageMember.TModel.MID, offer.SQMID, "TGBZ", TModel, "MHB", "提供帮助(" + offer.SQCode + ")本金加利息", MyHs);
                    }
                    //else
                    //{
                    //    BLL.ChangeMoney.HBChangeTran(changeMoney, BLL.Member.ManageMember.TModel.MID, offer.SQMID, "TGBZ", TModel, "MHB", "提供帮助(" + offer.SQCode + ")本金", MyHs);
                    //}

                    //BLL.ChangeMoney.HBChangeTran(offer.TotalSincerity, BLL.Member.ManageMember.TModel.MID, offer.SQMID, "R_DK", TModel, "MHB", "诚信奖", MyHs);
                    //List<Model.ChangeMoney> listChangeMoney = BllModel.GetChangeMoneyEntityList(" ChangeType in ('R_QD') and CState=0 and CRemarks = '" + offer.SQCode + "' ");
                    //BLL.ChangeMoney.JDChangeTran(listChangeMoney, MyHs);

                    //if (offer.SincerityState == 1)
                    //{
                    //    BLL.ChangeMoney.HBChangeTran(offer.TotalSincerity, BLL.Member.ManageMember.TModel.MID, offer.SQMID, "R_DK", TModel, "MHB", "诚信奖(" + offer.SQCode + ")", MyHs);
                    //}
                    offer.PPState = 4;
                    offer.InterestState = 2;
                    offer.SincerityState = 2;
                    BLL.MOfferHelp.Update(offer, MyHs);
                    if (BLL.CommonBase.RunHashtable(MyHs))
                    {
                        Response.Write("1");
                        return;
                    }
                }
            }

            Response.Write("提款失败");
            return;
        }

        /// <summary>
        /// 锁定激活码
        /// </summary>
        public void LockActiveCode()
        {
            string result = "";
            Hashtable hs = new Hashtable();
            BLL.ActiveCode.LockActiveCode(Request["pram"], hs);
            if (BLL.CommonBase.RunHashtable(hs))
            {
                result = "操作成功";
            }
            else
            {
                result = "操作失败";
            }

            Response.Write(result);
            return;
        }

        public void refarshMID()
        {
            string result = "";
            result = new BLL.Member().GetRandMemberMID("CX");
            Response.Write(result);
            return;
        }
        public void checkTel()
        {
            string result = "";
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                if (new BLL.Member().GetMemberEntityList("Tel='" + Request["pram"] + "'").Count > 0)
                {
                    result = "该手机号已被注册";
                }
            }
            Response.Write(result);
            return;
        }
        public void checkNumID()
        {
            string result = "";
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                if (new BLL.Member().GetMemberEntityList("NumID='" + Request["pram"] + "'").Count > 0)
                {
                    result = "该支付宝已被注册";
                }
            }
            Response.Write(result);
            return;
        }
        public void checkMTJ()
        {
            string result = "";
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Model.Member obj = new BLL.Member().GetModel(Request["pram"]);
                if (obj != null)
                {
                    result = obj.MName;
                }
            }
            Response.Write(result);
            return;
        }
        public void checkMID()
        {
            string result = "";
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Model.Member obj = new BLL.Member().GetModel(Request["pram"]);
                if (obj != null)
                {
                    result = "该会员ID已存在";
                }
            }
            Response.Write(result);
            return;
        }

        /// <summary>
        /// 权限管理编辑菜单的时候自动得到菜单编号
        /// </summary>
        private void GetNewCid()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    string cfid = Request["pram"];
                    Response.Write(BLL.Contents.GetNewCid(cfid));
                    return;
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    return;
                }
            }
            else
            {
                Response.Write("参数异常");
                return;
            }
        }
        /// <summary>
        /// 报单中心
        /// </summary>
        private void DealApply()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    string mid = Request["pram"];
                    string applyId = Request["appid"];
                    string isAgree = Request["isAgree"];
                    Model.MemberApply apply = BLL.MemberApply.GetModel(applyId);
                    if (isAgree == "1")
                        apply.State = 1;
                    else if (isAgree == "0")
                        apply.State = 2;
                    apply.ConfirmTime = DateTime.Now;
                    //string result = BllModel.SHMember(mid);
                    Hashtable myhs = new Hashtable();
                    BLL.MemberApply.Update(apply, myhs);
                    if (isAgree == "1") //是否审核同意
                    {
                        Model.Member mod = BLL.Member.GetModelByMID(mid);
                        mod.AgencyCode = BLL.Configuration.Model.SHMoneyList[apply.ApplyType].MAgencyType;
                        BLL.Member.ChangeMemberAgencyCode(mod, myhs);

                        //else if (apply.ApplyType == "2")//服务中心
                        //{
                        //    BLL.Member.UpdateConfigTran(mod.MID, "IsServerCenter", "1", mod, true, SqlDbType.Int, myhs);
                        //}
                    }
                    else
                    {  //管理员对审核过的再取消
                        Model.Member mod = BLL.Member.GetModelByMID(mid);
                        //if (apply.ApplyType == "3")
                        //{
                        mod.RoleCode = "Nomal";
                        BLL.Member.ChangeMemberAgencyCode(mod, myhs);
                        //}
                        //else if (apply.ApplyType == "1")//区域总监
                        //{
                        //    BLL.Member.UpdateConfigTran(mod.MID, "IsRegionalDirector", "0", mod, true, SqlDbType.Bit, myhs);
                        //    BLL.Member.UpdateConfigTran(mod.MID, "Region", "0", mod, true, SqlDbType.Bit, myhs);
                        //}
                        //else if (apply.ApplyType == "2")//服务中心
                        //{
                        //    BLL.Member.UpdateConfigTran(mod.MID, "IsServerCenter", "0", mod, true, SqlDbType.Int, myhs);
                        //}
                    }
                    if (BLL.CommonBase.RunHashtable(myhs))
                    {
                        Response.Write("1");
                        return;
                    }
                    else
                    {
                        Response.Write("0");
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    return;
                }
            }
            else
            {
                Response.Write("参数异常");
                return;
            }
        }
        /// <summary>
        /// 报单中心
        /// </summary>
        private void BCenter()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    List<string> shmid = Request["pram"].Split(',').ToList();
                    int success = 0, fail = 0;
                    //string failstr = "";
                    foreach (string mid in shmid)
                    {
                        //string result = BllModel.SHMember(mid);
                        bool result = BLL.BCenter.SHBCenter(mid);
                        if (result)
                        {
                            Model.Member mod = BLL.Member.GetModelByMID(mid);
                            BLL.Task.ManageSend(mod, "您的报单中心申请成功！");//给管理员发消息
                            mod.RoleCode = "VIP";
                            BLL.Member.ChangeMemberRole(mod);
                            success++;
                        }
                        else
                        {
                            fail++;
                        }
                    }
                    Response.Write("成功：" + success + ";失败：" + fail + ";");
                    return;
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    return;
                }
            }
            else
            {
                Response.Write("参数异常");
                return;
            }
        }
        /// <summary>
        /// 删除报单中心
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public void DeleteBCenter()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Response.Write(BLL.MemberApply.DeleteApply((Request["pram"])));
                return;
            }
            Response.Write("");
            return;
        }
        /// <summary>
        /// 校验ContentID是否有重复的
        /// </summary>
        protected void CheckContentID()
        {
            string result = "";
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Model.Contents obj = BLL.Contents.GetModel(Request["pram"]);
                if (obj != null)
                {
                    result = "0";//不通过
                }
                else
                    result = "1";//通过
            }
            Response.Write(result);
            return;
        }
        protected void DeleteLanguage()
        {
            string result = "";
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                result = Sys_LanguageBLL.Delete(Request["pram"]);
            }
            Response.Write(result);
            return;
        }


        /// <summary>
        /// 校验密保问题是否正确
        /// </summary>
        protected void checkPwdAnswer()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                string question = Request["question"];
                string answer = Request["answer"];
                if (string.IsNullOrEmpty(question))
                {
                    Response.Write("-1");//参数错误
                    return;
                }
                else
                {
                    Model.Sys_SecurityQuestion objQues = new BLL.Sys_SecurityQuestion().GetModel(question);
                    List<Model.Sys_SQ_Answer> listAns = new BLL.Sys_SQ_Answer().GetList(" MID=" + memberModel.ID + " and IsDeleted=0 and QId=" + objQues.ID.ToString());
                    if (listAns != null && listAns.Count > 0)
                    {
                        string orgAns = listAns[0].Answer;
                        if (answer == orgAns)
                        {
                            Response.Write("1"); //验证通过
                            return;
                        }
                        else
                        {
                            Response.Write("0");//密保问题不正确
                            return;
                        }
                    }
                    else
                    {
                        Response.Write("2");//未设置密保问题
                        return;
                    }
                }
            }
            Response.Write("0");
            return;
        }

        private void Recover()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.Recover((Request["pram"])));
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void Accounts()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BLL.Member.Accounts(Request["pram"]));
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void DeleteAccounts()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    if (BLL.Accounts.Delete(Request["pram"]))
                        Response.Write("操作成功");
                    else
                        Response.Write("操作失败");
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void DeleteBank()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    string[] banks = Request["pram"].Split(',');
                    Hashtable MyHs = new Hashtable();
                    List<string> member = new List<string>();
                    foreach (string item in banks)
                    {
                        Model.BankModel bank = BLL.BankModel.GetModel(item);
                        if (!memberModel.Role.IsAdmin)
                        {
                            if (bank.MID == memberModel.MID)
                            {
                                BLL.BankModel.Delete(item, MyHs);
                            }
                        }
                        else
                        {
                            BLL.BankModel.Delete(item, MyHs);
                        }
                        if (!member.Contains(bank.MID))
                            member.Add(bank.MID);
                    }
                    if (BLL.CommonBase.RunHashtable(MyHs))
                    {
                        MyHs.Clear();
                        foreach (string mid in member)
                        {
                            List<Model.BankModel> list = BLL.BankModel.GetList("MID='" + mid);
                            if (list.Count > 0)
                            {
                                BLL.BankModel.Update(list[0]);
                            }
                            else
                            {
                                Model.Member model = BllModel.GetModel(mid);
                                model.Bank = "";
                                model.Branch = "";
                                model.BankNumber = "";
                                model.BankCardName = "";
                                BllModel.UpdateBankInfo(model, MyHs);
                            }
                        }
                        Response.Write("操作成功");
                    }
                    else
                        Response.Write("操作失败");
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void sendCode2()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    //if (!HttpContext.Current.Request.UrlReferrer.Authority.Contains(ConfigurationManager.AppSettings["domain"].ToString()))
                    //{
                    //    Response.Write("签约网址不对呀,别忙活了");
                    //    return;
                    //}
                    string TelCode = new Random().Next(421339, 999999).ToString();
                    string Msg = "尊敬的会员：您好，您的邮箱验证码为[" + TelCode + "]，请及时注册，谢谢!";
                    Model.SMS model = new Model.SMS { SType = Model.SMSType.ZCYZ, Email = Request["pram"], SContent = Msg, SMSKey = TelCode };
                    string error = "";
                    if (BLL.Email.Insert(model, ref error))
                    {
                        Msg = "尊敬的会员：" + memberModel.MID + "，您推广的新会员的邮箱验验证码已成功发送至他的邮箱,请通知他注意查收!";
                        BLL.Task.ManageSend(memberModel, Msg);
                        Response.Write("发送成功");
                    }
                    else
                    {
                        Response.Write(error);
                    }

                }
                catch
                {
                    Response.Write("发送失败");
                }
                return;
            }
            Response.Write("请输入邮箱");
            return;
        }

        private void SendEmailTest()
        {
            Model.SMS model = new Model.SMS { SType = Model.SMSType.CSYX, Email = BLL.WebBase.Model.MonitorEmail, SContent = "测试" };
            string error = "";
            if (BLL.Email.Insert(model, ref error))
                Response.Write("发送成功，请注意查收");
            else
                Response.Write(error);
            return;
        }

        private void SendSMSTest()
        {
            Model.SMS model = new Model.SMS { SType = Model.SMSType.CSDX, Tel = BLL.WebBase.Model.MonitorTel, SContent = "测试" };
            string error = "";
            if (BLL.SMS.Insert(model, ref error))
            {
                Response.Write("发送成功，请注意查收");
            }
            else
                Response.Write(error);
            return;
        }

        private void SendCodeModifySecPsd()
        {
            try
            {
                string TelCode = new Random().Next(421339, 999999).ToString();
                string Msg = "尊敬的会员：" + memberModel.MID + ",您好，您的验证码为[" + TelCode + "]，请及时修改二级密码，谢谢!";
                Model.SMS model = new Model.SMS { SType = Model.SMSType.MMYZ, Email = memberModel.Email, Tel = memberModel.Tel, SContent = Msg, SMSKey = TelCode, MID = memberModel.MID };
                string error = "";
                if (BLL.SMS.Insert(model, ref error) || BLL.Email.Insert(model, ref error))
                {
                    Msg = "尊敬的会员：" + memberModel.MID + "，您修改二级密码的验证码已成功发送至您的手机或邮箱,请注意查收!";
                    BLL.Task.ManageSend(memberModel, Msg);
                    Response.Write("发送成功");
                }
                else
                    Response.Write(error);

            }
            catch
            {
                Response.Write("发送失败");
            }
            return;
        }
        private void SendCodeModifyFirstPsd()
        {
            try
            {
                string TelCode = new Random().Next(421339, 999999).ToString();
                string Msg = "尊敬的会员：" + memberModel.MID + ",您好，您的验证码为[" + TelCode + "]，请及时修改密码，谢谢!";
                Model.SMS model = new Model.SMS { SType = Model.SMSType.MMYZ, Email = memberModel.Email, Tel = memberModel.Tel, SContent = Msg, SMSKey = TelCode, MID = memberModel.MID };
                string error = "";
                if (BLL.SMS.Insert(model, ref error) || BLL.Email.Insert(model, ref error))
                {
                    Msg = "尊敬的会员：" + memberModel.MID + "，您修改登录密码的验证码已成功发送至您的手机或邮箱,请注意查收!";
                    BLL.Task.ManageSend(memberModel, Msg);
                    Response.Write("发送成功");
                }
                else
                    Response.Write(error);

            }
            catch
            {
                Response.Write("发送失败");
            }
            return;
        }

        //注册发送验证码
        private void SendCode()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    //if (!HttpContext.Current.Request.UrlReferrer.Authority.Contains(ConfigurationManager.AppSettings["domain"].ToString()))
                    //{
                    //    Response.Write("签约网址不对呀,别忙活了");
                    //    return;
                    //}

                    var tel = Request["pram"];

                    //List<Model.Member> list = BllModel.GetMemberEntityList("Tel='" + tel.Trim() + "'");
                    //if (list.Count > BLL.Configuration.Model.MaxBuyGCount)
                    //{
                    //    Response.Write("该手机号注册的账号已达上限");
                    //    return;
                    //}

                    //判断手机号码是否存在
                    //if (BLL.Member.IsPhoneExist(Request["pram"]))
                    //               {
                    //                   Response.Write("该手机号码已被注册，请更换其它号码");
                    //               }
                    //else
                    {
                        string TelCode = new Random().Next(421339, 999999).ToString();
                        string Msg = "您的注册验证码是[" + TelCode + "]，欢迎携手皇家国际，祝您生活愉快！";
                        Model.SMS model = new Model.SMS { SType = Model.SMSType.ZCYZ, Tel = Request["pram"], SContent = Msg, SMSKey = TelCode };
                        string error = "";
                        if (BLL.SMS.Insert(model, ref error))
                        {
                            Response.Write("发送成功");
                        }
                        else
                        {
                            Response.Write(error);
                        }
                    }
                }
                catch
                {
                    Response.Write("发送失败");
                }
                return;
            }
            Response.Write("请输入手机号码");
            return;
        }

        //找回密码发送验证码
        private void sendTelCodeForFindPwd()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    //if (!HttpContext.Current.Request.UrlReferrer.Authority.Contains(ConfigurationManager.AppSettings["domain"].ToString()))
                    //{
                    //    Response.Write("签约网址不对呀,别忙活了");
                    //    return;
                    //}
                    string mid = Request["txtMID"];
                    if (string.IsNullOrEmpty(mid))
                    {
                        Response.Write("请输入要重置的账号");
                        return;
                    }
                    else
                    {
                        Model.Member mem = BLL.Member.GetModelByMID(mid);
                        if (mem == null)
                        {
                            Response.Write("不存在该账号");
                            return;
                        }
                        if (mem.Tel != Request["pram"])
                        {
                            Response.Write("该手机号与注册时手机不一样，请输入正确的手机号。");
                            return;
                        }

                        string TelCode = new Random().Next(421339, 999999).ToString();
                        string Msg = "您的注册验证码是[" + TelCode + "]，欢迎携手新浪社区，祝您生活愉快！";
                        Model.SMS model = new Model.SMS { SType = Model.SMSType.CZMM, Tel = Request["pram"], SContent = Msg, SMSKey = TelCode };
                        string error = "";
                        if (BLL.SMS.Insert(model, ref error))
                        {
                            Response.Write("发送成功");
                        }
                        else
                        {
                            Response.Write(error);
                        }
                    }
                }
                catch
                {
                    Response.Write("发送失败");
                }
                return;
            }
            Response.Write("请输入手机号码");
            return;
        }


        private void GrantVerify()
        {
            if (!string.IsNullOrEmpty(Request["pram"]) && !string.IsNullOrEmpty(Request.Params["mType"]))
            {
                try
                {
                    Response.Write(BllModel.GrantVerify(Request["pram"], Request.Params["mType"]));
                    return;

                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void deleteHKModel()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.DeleteHKModel((Request["pram"])));
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void shHKModel()
        {
            if (!string.IsNullOrEmpty(Request["pram"]) && memberModel.Role.IsAdmin)
            {
                try
                {
                    Response.Write(BllModel.SHHKModel((Request["pram"])));
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void SetVerify()
        {
            if (!string.IsNullOrEmpty(Request["pram"]) && !string.IsNullOrEmpty(Request.Params["mType"]))
            {
                try
                {
                    Response.Write(BllModel.SetVerify(Request["pram"], Request.Params["mType"]));
                    return;

                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void NoReadTask()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.NoReadTask(Request["pram"]));
                    return;

                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void ReadTask()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.ReadTask(Request["pram"]));
                    return;

                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void HideTask()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.HideTask(Request["pram"]));
                    return;

                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void ShowTask()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.ShowTask(Request["pram"]));
                    return;

                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }


        private void FH()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    string[] fhinfo = Request["pram"].Split('|');
                    //Model.FHList fhmodel = new Model.FHList()
                    //{
                    //    SumFHMoney = int.Parse(fhinfo[0]),
                    //    FHTotal = 0,
                    //    FHFloat = decimal.Parse(fhinfo[1]),
                    //    FHDate = DateTime.Now,
                    //    FHType = Model.ChangeType.YJFH,
                    //};
                    //Response.Write(bll.FH(fhmodel, true));
                    return;

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    return;
                }
            }
            Response.Write("");
            return;
        }

        private void HideNotice()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.HideNotice(Request["pram"]));
                    return;

                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("");
            return;
        }

        private void ShowNotice()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.ShowNotice(Request["pram"]));
                    return;

                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("");
            return;
        }

        private void DeleteNotice()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.DeleteNotice(Request["pram"]));
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("");
            return;
        }
        private void DeleteTask()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.DeleteTask(Request["pram"]));
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("");
            return;
        }

        private void DeleteOffer()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BLL.MOfferHelp.Delete(Request["pram"]));
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("");
            return;
        }

        private void EndTask()
        {
            try
            {
                if (!string.IsNullOrEmpty(Request["pram"]))
                {
                    Response.Write(BLL.Task.EndTask(Request["pram"], memberModel.MID));
                    return;
                }
                Response.Write("");
            }
            catch
            {
                Response.Write("");
                return;
            }
        }

        private void SendMessage()
        {
            try
            {
                Model.Task model = new Model.Task()
                {
                    TContent = HttpUtility.UrlDecode(Request["TContent"]),
                    TFromMID = memberModel.MID,
                    TFromMName = memberModel.MName,
                    TDateTime = DateTime.Now,
                    TToMID = HttpUtility.UrlDecode(Request["TToMID"]),
                    TToMName = HttpUtility.UrlDecode(Request["TToMName"]),
                    TType = "007"
                };
                Response.Write(BLL.Task.Add(model));
                return;
            }
            catch
            {
                Response.Write("");
                return;
            }
        }

        private void GetMessage()
        {
            try
            {
                string TFromMID = "";
                if (!string.IsNullOrEmpty(Request["pram"]))
                    TFromMID = Request["pram"];
                int ID = 0;
                if (!string.IsNullOrEmpty(Request["TaskID"]))
                    ID = int.Parse(Request["TaskID"]);
                List<Model.Task> modelList = BLL.Task.SelectNewTasks(memberModel.MID, TFromMID, ID);

                string retstr = "";
                if (modelList.Count > 0)
                {
                    retstr = JavaScriptConvert.SerializeObject(modelList);
                }
                Response.Write(retstr);
                Response.End();
                return;
            }
            catch
            {
                Response.Write("");
                Response.End();
                return;
            }
        }

        private void GetNotice()
        {
            try
            {
                BLL.Member.AddOnLine(memberModel.MID);
                Model.Notice model = BLL.Notice.GetNewNotice(7);
                string retstr = "";
                if (model != null)
                {
                    var info = new { ID = model.ID, Content = model.NContent };
                    retstr = JavaScriptConvert.SerializeObject(info);
                }
                Response.Write(retstr);
                return;
            }
            catch
            {
                Response.Write("");
                return;
            }
        }

        private void DeleteChangeMoney()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.DeleteChangeMoney(Request["pram"]));
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("");
            return;
        }

        private void Verify()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Model.Member model = TModel;
                    if (model.SecPsd == System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Request["pram"] + model.Salt, "MD5").ToUpper())
                    {
                        Session["pass"] = "pass";
                        Response.Write("pass");
                    }
                    return;

                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("");
            return;
        }

        private void VerifyUrl()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    if (Session["pass"] != null && Session["pass"].ToString() == "pass")
                    {
                        Response.Write("FALSE");
                        return;
                    }
                    string restr = BllModel.VerifyUrl(Request["pram"]).ToString().ToUpper();
                    Response.Write(restr);
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("");
            return;
        }

        private void GetSecPsd()
        {
            try
            {
                Model.Member model = TModel;
                Response.Write(model.Password + "|" + model.SecPsd);
                return;

            }
            catch
            {
                Response.Write("");
                return;
            }
        }

        /// <summary>
        /// 得到会员昵称,转移货币用
        /// </summary>
        private void getMName()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                if (BllModel != null)
                {
                    string mid = Request["pram"];
                    Model.Member model = BllModel.GetModel(mid);
                    if (model != null)
                    {
                        Response.Write(model.MName);
                        return;
                    }
                }
            }
            Response.Write("");
            return;
        }

        /// <summary>
        /// 得到会员昵称,转移货币用
        /// </summary>
        private void FindMGP()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                if (BllModel != null)
                {
                    string mid = Request["pram"];
                    Model.Member model = BllModel.GetModel(mid);
                    if (model != null)
                    {
                        Response.Write(model.MConfig.MGP.ToString("F0"));
                        return;
                    }
                }
            }
            Response.Write("0");
            return;
        }

        /// <summary>
        /// 得到会员昵称,转移货币用
        /// </summary>
        private void FindMJB()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                if (BllModel != null)
                {
                    string mid = Request["pram"];
                    Model.Member model = BllModel.GetModel(mid);
                    if (model != null)
                    {
                        Response.Write(model.MConfig.MJB.ToString("F0"));
                        return;
                    }
                }
            }
            Response.Write("0");
            return;
        }

        /// <summary>
        /// 登录
        /// </summary>
        private void getLogin()
        {
            try
            {
                if (!string.IsNullOrEmpty(Request["pram"]))
                {
                    string[] info = Request["pram"].Split('|');
                    if (Session["CheckCode"] == null || info[2].ToLower() != Session["CheckCode"].ToString().ToLower())
                    {
                        Response.Write("3");
                        return;
                    }
                    Model.Member model = BLL.Member.ManageMember.GetModel(info[0]);
                    if (model == null)
                    {
                        Response.Write("1");
                        return;
                    }
                    else if (model.Password != System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(info[1] + model.Salt, "MD5").ToUpper())
                    {
                        Response.Write("2");
                        return;
                    }
                    else if (!model.Role.CanLogin || model.IsClose || !string.IsNullOrEmpty(model.FMID))
                    {
                        Response.Write("-1");
                        return;
                    }
                    else
                    {
                        if (model.Role.IsAdmin && !info[3].ToLower().Contains("manage"))
                        {
                            Response.Write("-1");
                            return;
                        }
                        else if (!model.Role.IsAdmin && info[3].ToLower().Contains("manage"))
                        {
                            Response.Write("-1");
                            return;
                        }
                        FormsAuthentication.SetAuthCookie(model.MID, true);
                        BLL.Member bllmodel = new BLL.Member { TModel = model };
                        Session["Member"] = bllmodel;
                        BLL.Member.AddOnLine(model.MID);
                        Response.Write("0");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 审核会员,用激活码激活
        /// </summary>
        private void SHMemberByActiveCode()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    List<string> shmid = Request["pram"].Split(',').ToList();

                    //查看激活码是否足够
                    List<Model.ActiveCode> activeList = BLL.ActiveCode.GetTopList(" MID = '" + TModel.MID + "' and (UseMID = '' or UseMID is null ) ", shmid.Count);
                    if (activeList.Count < shmid.Count)
                    {
                        Response.Write("您当前可用激活码不足");
                        return;
                    }
                    int success = 0, fail = 0;
                    string failstr = "";
                    Model.SHMoney shmoney = WE_Project.BLL.Configuration.Model.SHMoneyList["002"];
                    foreach (string mid in shmid)
                    {
                        string result = BllModel.SHMemberByActiveCode(shmoney, mid, TModel, activeList[success + fail]);
                        if (result.Contains("恭喜您"))
                        {
                            success++;
                        }
                        else
                        {
                            failstr = result;
                            fail++;
                        }
                    }
                    Response.Write("成功：" + success + ";失败：" + fail + ";" + failstr);
                    return;
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    return;
                }
            }
            else
            {
                Response.Write("参数异常");
                return;
            }
        }

        /// <summary>
        /// 审核会员
        /// </summary>
        private void ShMember()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    List<string> shmid = Request["pram"].Split(',').ToList();

                    int success = 0, fail = 0;
                    string failstr = "";
                    foreach (string mid in shmid)
                    {
                        string result = BllModel.SHMember(mid);
                        if (result.Contains("操作成功"))
                        {
                            success++;
                        }
                        else
                        {
                            failstr = result;
                            fail++;
                        }
                    }
                    Response.Write("成功：" + success + ";失败：" + fail + ";" + failstr);
                    return;
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    return;
                }
            }
            else
            {
                Response.Write("参数异常");
                return;
            }
        }

        /// <summary>
        /// 审核提现
        /// </summary>
        private void SHTX()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    string result = BllModel.ShTx(Request["pram"]);
                    Response.Write(result);
                    return;
                }
                catch
                {
                    Response.Write("操作失败");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public void DeleteMember()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Response.Write(BllModel.DeleteMember((Request["pram"])));
                return;
            }
            Response.Write("");
            return;
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public void DeleteMemberW()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Response.Write(BllModel.DeleteMemberW((Request["pram"])));
                return;
            }
            Response.Write("");
            return;
        }

        /// <summary>
        /// 判断两个会员是否有推荐或被推荐关系
        /// </summary>
        public void IsCanChangeByMember()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                string fromAndTo = Request["pram"];
                if (string.IsNullOrEmpty(fromAndTo))
                {
                    Response.Write("-1");
                    return;
                }
                else
                {
                    Model.Member fromModel = BllModel.GetModel(fromAndTo.Split('|')[0]);
                    Model.Member toModel = BllModel.GetModel(fromAndTo.Split('|')[1]);
                    if (fromModel.MTJ == toModel.MID || toModel.MTJ == fromModel.MID)
                    {
                        Response.Write("1");
                        return;
                    }
                }
            }
            Response.Write("0");
            return;
        }

        public string DataTable2Json(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            // jsonBuilder.Append("{\"");
            // jsonBuilder.Append(dt.TableName);
            // jsonBuilder.Append("\":[");
            jsonBuilder.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            // jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        public void EPbuy()
        {
            string result = "";
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                result = BLL.EPList.EPbuy(Request["pram"], TModel.MID);
            }
            Response.Write(result);
            return;
        }

        public void EPcancel()
        {
            string result = "";
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                result = BLL.EPList.EPcancel(Request["pram"]);
            }
            Response.Write(result);
            return;
        }

        public void EPpay()
        {
            string result = "";
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                result = BLL.EPList.EPpay(Request["pram"]);
            }
            Response.Write(result);
            return;
        }

        public void EPsellLast()
        {
            string result = "";
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                result = BLL.EPList.EPsellLast(Request["pram"]);
            }
            Response.Write(result);
            return;
        }

        public void EPDelete()
        {
            string result = "";
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                result = BLL.EPList.EPDelete(Request["pram"]);
            }
            Response.Write(result);
            return;
        }

        public void EPClose()
        {
            string result = "";
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                result = BLL.EPList.EPClose(Request["pram"]);
            }
            Response.Write(result);
            return;
        }

        public void FDReset()
        {
            Response.Write(BLL.Member.ResetFDTrade(TModel.MID));
            return;
            //var wb = BLL.WebBase.Model;
            //wb.FDTrade = "A";
            //if (BLL.WebBase.Update(wb))
            //{
            //    Response.Write("富达交易重置成功");
            //}
            //else
            //{
            //    Response.Write("富达交易重置失败");
            //}
            //BLL.Member
        }
        public void costMHB()
        {
            string midList = Request["pram"];
            string money = Request["money"];
            Response.Write(BLL.Member.CostMHB(midList, money));
            return;
        }
    }
}