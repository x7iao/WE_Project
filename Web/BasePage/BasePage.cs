using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace WE_Project.Web
{
    public class BasePage : System.Web.UI.Page
    {
        protected Model.WebSetInfo WebModel = BLL.WebSetInfo.Model;
        //protected Model.Member TModel;
        //protected BLL.Member BllModel
        //{
        //    get
        //    {
        //        if (Session["Member"] == null)
        //        {
        //            if (!string.IsNullOrEmpty(User.Identity.Name))
        //            {
        //                Model.Member model = BLL.Member.ManageMember.GetModel(User.Identity.Name);
        //                if (model != null)
        //                {
        //                    Session["Member"] = new BLL.Member { TModel = model };
        //                }
        //            }
        //        }
        //        BLL.Member bllmodel = (Session["Member"] as BLL.Member);
        //        if (bllmodel != null)
        //        {
        //            bllmodel.TModel = bllmodel.GetSelf();
        //            if (bllmodel.TModel == null)
        //                bllmodel = null;
        //            else
        //                TModel = bllmodel.TModel;
        //        }
        //        Session["Member"] = bllmodel;
        //        return bllmodel;
        //    }
        //    set
        //    {
        //        Session["Member"] = value;
        //    }
        //}

        public string GetPromoteLink()
        {
            //int mbdIndex;
            //var mbd = MemberBLL.GetSuitableLocation(TModel.MID, out mbdIndex);
            return string.Format("{0}?mid={1}", HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, "/Regedit/Index.aspx"), TModel.MID);
        }

        /// <summary>
        /// 获取逻辑上登陆的用户是否是管理员
        /// </summary>
        public bool IsAdmin
        {
            get
            {
                return TModel.Role.IsAdmin;
            }
        }

        /// <summary>
        /// 实际登陆的用户是否是管理员
        /// </summary>
        public bool ActualUserIsAdmin
        {
            get
            {
                return ActualTModel.Role.IsAdmin;
            }
        }

        private Model.Member _actualTModel;

        /// <summary>
        /// 实际上当前登陆的用户
        /// </summary>
        protected Model.Member ActualTModel
        {
            get
            {
                if (_actualTModel == null)
                {
                    _actualTModel = BLL.Member.GetModelByMID(CurrentUserName);
                }

                return _actualTModel;
            }
        }

        private static readonly string LoggedInFlag = "LoggedInMID";

        private Model.Member _tModel;

        private static readonly Regex loggedInUserRegex = new Regex("LoggedInMID=(?<MID>[^&]+)&*");


        private string _loggedInMID;

        /// <summary>
        /// 在参数中指定的当前登陆的用户的账号
        /// </summary>
        protected string LoggedInMID
        {
            get
            {
                if (_loggedInMID == null)
                {
                    var request = HttpContext.Current.Request;
                    var referer = request.Headers["Referer"];
                    if (string.IsNullOrEmpty(referer))
                    {
                        _loggedInMID = string.Empty;
                    }
                    else
                    {
                        var matchResult = loggedInUserRegex.Match(referer);
                        if (!matchResult.Success)
                        {
                            _loggedInMID = string.Empty;
                        }
                        else
                        {
                            _loggedInMID = matchResult.Groups["MID"].Value;
                        }
                    }
                    if (string.IsNullOrEmpty(_loggedInMID))
                    {
                        _loggedInMID = request.Params[LoggedInFlag];
                        _loggedInMID = _loggedInMID ?? string.Empty;
                    }
                }
                return _loggedInMID;
            }
        }


        /// <summary>
        /// 逻辑上当前登陆的用户
        /// </summary>
        protected Model.Member TModel
        {
            get
            {
                if (_tModel == null)
                {
                    if (ActualTModel == null)
                    {
                        _tModel = null;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(LoggedInMID) && ActualUserIsAdmin)
                        {
                            _tModel = BLL.Member.GetModelByMID(LoggedInMID);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(LoggedInMID))
                            {
                                Model.Member urlm = BLL.Member.GetModelByMID(LoggedInMID);//要操作的托管会员

                                if (ActualTModel.MID != urlm.MTJ)//如果当前会员不是要托管账号的推荐人就不能托管进入
                                {
                                    _tModel = ActualTModel;
                                }
                                else {
                                    _tModel = BLL.Member.GetModelByMID(LoggedInMID);
                                }
                            }
                            else
                            {
                                _tModel = ActualTModel;
                            }
                        }
                    }
                }
                return _tModel;
            }
        }

        /// <summary>
        /// 当前的用户的名字
        /// </summary>
        protected string CurrentUserName
        {
            get
            {
                return User.Identity.Name;
            }
        }

        private BLL.Member _bllModel;
        protected BLL.Member BllModel
        {
            get
            {
                //if (Session["Member"] == null)
                //{
                //	if (!string.IsNullOrEmpty(User.Identity.Name))
                //	{
                //		Model.Member model = BLL.Member.ManageMember.GetModel(User.Identity.Name);
                //		if (model != null)
                //		{
                //			Session["Member"] = new BLL.Member { TModel = model };
                //		}
                //	}
                //}
                //BLL.Member bllmodel = (Session["Member"] as BLL.Member);
                //if (bllmodel != null)
                //{
                //	bllmodel.TModel = bllmodel.GetSelf();
                //	if (bllmodel.TModel == null)
                //		bllmodel = null;
                //	else
                //		TModel = bllmodel.TModel;
                //}
                //Session["Member"] = bllmodel;
                //return bllmodel;

                if (_bllModel == null)
                {
                    if (TModel == null)
                    {
                        _bllModel = null;
                    }
                    else
                    {
                        _bllModel = new BLL.Member();
                        _bllModel.TModel = TModel;
                    }
                }

                return _bllModel;
            }
            //set
            //{
            //	Session["Member"] = value;
            //}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            if (BllModel != null && BllModel.TModel != null)
            {
                //TModel = BllModel.TModel;
                if (TModel.IsClose)
                {
                    Response.Write("<script>window.top.location.href='/SysManage/Out.aspx'</script>");
                    Response.End();
                    return;
                }
            }
            //else
            //    TModel = null;
            //if (!IsPostBack)
            //{
                if (!WebModel.WebState || !TestCloseTime())
                {
                    if ((BllModel == null || !TModel.Role.IsAdmin) && !Context.Request.Url.AbsolutePath.ToUpper().Contains("MANAGEMENTORS/LOGIN.ASPX"))
                    {
                        Response.Write("<script>window.top.location.href='/SysManage/Out.aspx'</script>");
                        Response.End();
                    }
                    else
                    {
                        VerifyPower();
                    }
                }
                else
                {
                    VerifyPower();
                }
            //}
        }
        /// <summary>
        /// 验证授权
        /// </summary>
        private void VerifyPower()
        {
            string error = "";
            if (!BLL.CommonBase.TestSql(Request.QueryString.ToString() + Request.Form.ToString(), ref error))
            {
                Response.Write("非法关键字符[" + error + "]");
                Response.End();
                return;
            }
            if (BLL.Member.VerifyPower(HttpContext.Current, BllModel))
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Action"]))
                {
                    try
                    {
                        if (Request.QueryString["Action"].ToUpper() == "ADD")
                        {
                            Response.Write(btnAdd_Click());
                        }
                        else if (Request.QueryString["Action"].ToUpper() == "MODIFY")
                        {
                            Response.Write(btnModify_Click());
                        }
                        else if (Request.QueryString["Action"].ToUpper() == "OTHER")
                        {
                            Response.Write(btnOther_Click());
                        }
                        else
                        {
                            Response.Write("未提供该操作的函数");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                    finally
                    {
                        BLL.Configuration.Model = null;
                        Response.End();
                    }
                    return;
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    SetValue(Request.QueryString["ID"]);
                }
                else
                {
                    SetValue();
                }
                SetPowerZone();
            }
            else
            {
                if (NoPower())
                {
                    if (BllModel != null && BllModel is BLL.Member)
                    {
                        Response.Write("<script>window.top.location.href='/Default.aspx'</script>");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("<script>window.top.location.href='/Login.aspx'</script>");
                        Response.End();
                    }
                }
            }
        }

        protected virtual string btnAdd_Click()
        {
            return "未重载";
        }

        protected virtual string btnModify_Click()
        {
            return "未重载";
        }

        protected virtual string btnOther_Click()
        {
            return "未重载";
        }

        protected virtual void SetValue(string id)
        {

        }

        protected virtual void SetValue()
        {

        }

        protected virtual void SetPowerZone()
        {

        }

        protected virtual bool NoPower()
        {
            return true;
        }

        private bool TestCloseTime()
        {
            string nowDate = DateTime.Now.ToString("yyyy-MM-dd ");
            foreach (string time in WebModel.OpenTimeList)
            {
                string[] times = time.Split('-');
                if (DateTime.Parse(nowDate + times[0]) < DateTime.Now && DateTime.Parse(nowDate + times[1]) > DateTime.Now)
                    return true;
            }
            return false;
        }

        public bool TestCloseTime(List<string> list)
        {
            string nowDate = DateTime.Now.ToString("yyyy-MM-dd ");
            foreach (string time in list)
            {
                string[] times = time.Split('-');
                if (DateTime.Parse(nowDate + times[0]) < DateTime.Now && DateTime.Parse(nowDate + times[1]) > DateTime.Now)
                    return true;
            }
            return false;
        }

        //Add by zhuxy,其他页面可能公众的方法
        protected IList<string> GetSetedGuid(IList<string> newDetailListTrain)
        {
            IList<string> strFlagsTrain = new List<string>();
            foreach (string str in newDetailListTrain)
            {
                string keyFlags = string.Empty;
                keyFlags = str.Split('_')[1];
                if (!strFlagsTrain.Contains(keyFlags))
                {
                    strFlagsTrain.Add(keyFlags);
                }
            }
            return strFlagsTrain;
        }
        public long ToNullLong(object l)
        {
            long ret;
            try
            {
                if (long.TryParse(l.ToString(), out ret))
                {
                    return ret;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        public bool EditTableNeedSaveKeys(string key, string[] EditTableKeys)
        {
            if (EditTableKeys != null && EditTableKeys.Length > 0)
            {
                foreach (string o in EditTableKeys)
                {
                    if (o.Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 校验密保问题
        /// </summary>
        /// <returns></returns>
        public bool Check_SQ_Answer()
        {
            bool flag = true;
            //找到该会员的密保问题及答案
            Model.Sys_SQ_Answer obj = null;
            BLL.Sys_SQ_Answer bll = new BLL.Sys_SQ_Answer();
            string whereStr = " IsDeleted=0 and Status=1 and MID=" + TModel.ID;
            IList<Model.Sys_SQ_Answer> list = bll.GetList(whereStr);
            if (list != null && list.Count > 0)
            {
                obj = list[0];
                if (obj.QId != long.Parse(Request.Form["ddl_PwdQuestion"]))
                {
                    flag = false;
                }
                if (obj.Answer != Request.Form["pwdAnswer"])
                {
                    flag = false;
                }
            }
            return flag;
        }
        protected void BindDdlPwdQuestion(System.Web.UI.HtmlControls.HtmlSelect ddl_PwdQuestion)
        {
            BLL.Sys_SecurityQuestion bll = new BLL.Sys_SecurityQuestion();
            string whereStr = " IsDeleted=0 and Status=1";
            IList<Model.Sys_SecurityQuestion> list = bll.GetList(whereStr);
            ddl_PwdQuestion.DataSource = list;
            ddl_PwdQuestion.DataTextField = "Question";
            ddl_PwdQuestion.DataValueField = "ID";
            ddl_PwdQuestion.DataBind();
        }

        protected string GetGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "").ToUpper().Substring(0, 15);
        }

        # region 互助

        /// <summary>
        /// 是否可以申请(一天一次)
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        protected bool CanApplyHelp(string mid)
        {
            string sql = " select COUNT(*) from MOfferHelp where PPState <> 5 and SQMID = '" + mid + "' and DATEDIFF(DD,GETDATE(),SQDate) = 0 ";
            object obj = BLL.CommonBase.GetSingle(sql);
            if (obj != null)
            {
                return Convert.ToInt32(obj) <= 0;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 是否可以申请(指定时间指定数量)
        /// </summary>
        protected bool CanApplyHelp(string mid, int time, int count, bool isOffer)
        {
            string tableName = "MOfferHelp";
            if (!isOffer)
            {
                tableName = "MGetHelp";
            }
            DateTime now = DateTime.Now.AddMinutes(-time);
            string sql = " select COUNT(*) from " + tableName + " where PPState <> 5 and SQMID = '" + mid + "' and SQDate > '" + now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' ";
            object obj = BLL.CommonBase.GetSingle(sql);
            if (obj != null)
            {
                return Convert.ToInt32(obj) < count;
            }
            else
            {
                return 0 < count;
            }
        }

        # region 时间

        /// <summary>
        /// 时间差
        /// </summary>
        /// <param name="datepart">时间类型</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <returns></returns>
        protected int DateDiff(DateDiffType datepart, DateTime startdate, DateTime enddate)
        {
            int diff = 0;
            switch (datepart)
            {
                case DateDiffType.DD:
                    diff = (int)(enddate - startdate).TotalDays;
                    break;
                case DateDiffType.HH:
                    diff = (int)(enddate - startdate).TotalHours;
                    break;
                case DateDiffType.MI:
                    diff = (int)(enddate - startdate).TotalMinutes;
                    break;
                case DateDiffType.SS:
                    diff = (int)(enddate - startdate).TotalSeconds;
                    break;
                default:
                    diff = -1;
                    break;
            }
            return diff;
        }

        /// <summary>
        /// 剩余时间
        /// </summary>
        /// <param name="datepart">时间类型</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="time"></param>
        /// <returns></returns>
        protected int DateDiff(DateDiffType datepart, DateTime startdate, int time)
        {
            int diff = 0;
            switch (datepart)
            {
                case DateDiffType.DD:
                    diff = time - (int)(DateTime.Now - startdate).TotalDays;
                    break;
                case DateDiffType.HH:
                    diff = time - (int)(DateTime.Now - startdate).TotalHours;
                    break;
                case DateDiffType.MI:
                    diff = time - (int)(DateTime.Now - startdate).TotalMinutes;
                    break;
                case DateDiffType.SS:
                    diff = time - (int)(DateTime.Now - startdate).TotalSeconds;
                    break;
                default:
                    diff = -1;
                    break;
            }
            return diff;
        }

        /// <summary>
        /// 生成倒计时字符串
        /// </summary>
        /// <param name="datepart">类型</param>
        /// <param name="remaintime">剩余时间</param>
        private string DiffString(DateDiffType datepart, int remaintime)
        {
            string result = "";

            switch (datepart)
            {
                case DateDiffType.DD:
                    result = GetShowString(remaintime, DateDiffType.DD);
                    break;
                case DateDiffType.HH:
                    result = GetShowString(remaintime / 24, DateDiffType.DD) + GetShowString(remaintime % 24, DateDiffType.HH);
                    break;
                case DateDiffType.MI:
                    result = GetShowString(remaintime / 1440, DateDiffType.DD) + GetShowString(remaintime % 1440 / 60, DateDiffType.HH) + GetShowString(remaintime % 60, DateDiffType.MI);
                    break;
                case DateDiffType.SS:
                    result = remaintime / 3600 + "时" + remaintime % 3600 / 60 + "分" + remaintime % 60 + "秒";
                    result = GetShowString(remaintime / 3600, DateDiffType.HH) + GetShowString(remaintime % 3600 / 60, DateDiffType.MI) + GetShowString(remaintime % 60, DateDiffType.SS);
                    break;
                default:
                    break;
            }

            return result;
        }

        private string GetShowString(int time, DateDiffType datepart, bool isShow = false)
        {
            string result = "";

            switch (datepart)
            {
                case DateDiffType.DD:
                    result = "天";
                    break;
                case DateDiffType.HH:
                    result = "时";
                    break;
                case DateDiffType.MI:
                    result = "分";
                    break;
                case DateDiffType.SS:
                    result = "秒";
                    break;
                default:
                    break;
            }
            if (!isShow && time <= 0)
            {
                return "";
            }

            return time + result;
        }

        /// <summary>
        /// 剩余时间字符串
        /// </summary>
        /// <param name="datepart">时间类型</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="time">审核时间</param>
        /// <param name="prefixStr">未超时前缀</param>
        /// <param name="overtimeStr">超时提醒</param>
        protected string DateDiffStr(DateDiffType datepart, DateTime startdate, int time, string prefixStr = "倒计时：", string overtimeStr = "已超时")
        {
            int remain = DateDiff(datepart, startdate, time);
            if (remain <= 0)
            {
                return overtimeStr;
            }
            return prefixStr + DiffString(datepart, remain);
        }

        /// <summary>
        /// 匹配时间剩余
        /// </summary>
        /// <param name="match">匹配实例</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        protected string MatchTimeLeave(Model.MHelpMatch match, MMMMatchTimeType type, string prefixStr = "倒计时：", string overtimeStr = "已超时", DateDiffType ddType = DateDiffType.MI)
        {
            string result = "";
            if (type == MMMMatchTimeType.PayLimitTime)
            {
                if (match.MatchType == 1)//预付款
                {
                    //result = DateDiffStr(ddType, match.MatchTime, BLL.MMMConfig.Model.PayLimitTimesPre, prefixStr, overtimeStr);
                    result = DateDiffStr(ddType, match.MatchTime, BLL.MMMConfig.Model.PayLimitTimes, prefixStr, overtimeStr);
                }
                else if (match.MatchType == 2)//抢单
                {
                    //result = DateDiffStr(ddType, match.MatchTime, BLL.MMMConfig.Model.MHBBase, prefixStr, overtimeStr);
                    result = DateDiffStr(ddType, match.MatchTime, BLL.MMMConfig.Model.PayLimitTimes, prefixStr, overtimeStr);
                }
                else
                {
                    result = DateDiffStr(ddType, match.MatchTime, BLL.MMMConfig.Model.PayLimitTimes, prefixStr, overtimeStr);
                }
            }
            else if (type == MMMMatchTimeType.ConfirmLimitTime)
            {
                if (match.MatchType == 1)
                {
                    //result = DateDiffStr(ddType, match.PayTime.Value, BLL.MMMConfig.Model.ConfirmLimitTimesPre, prefixStr, overtimeStr);
                    result = DateDiffStr(ddType, match.PayTime.Value, BLL.MMMConfig.Model.ConfirmLimitTimes, prefixStr, overtimeStr);
                }
                else if (match.MatchType == 2)
                {
                    //result = DateDiffStr(ddType, match.PayTime.Value, BLL.MMMConfigScramble.Model.ConfirmLimitTimes, prefixStr, overtimeStr);
                    result = DateDiffStr(ddType, match.PayTime.Value, BLL.MMMConfig.Model.ConfirmLimitTimes, prefixStr, overtimeStr);
                }
                else
                {
                    result = DateDiffStr(ddType, match.PayTime.Value, BLL.MMMConfig.Model.ConfirmLimitTimes, prefixStr, overtimeStr);
                }
            }
            return result;
        }

        /// <summary>
        /// 时间剩余
        /// </summary>
        /// <param name="match">买入许愿果实例</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        protected string OfferTimeLeave(Model.MOfferHelp offer, MMMOfferTimeType type, string prefixStr = "倒计时：", string overtimeStr = "已超时", DateDiffType ddType = DateDiffType.MI)
        {
            string result = "";
            if (type == MMMOfferTimeType.LineTime)
            {
                if (offer.HelpType == 0)
                {
                    result = DateDiffStr(ddType, offer.SQDate, BLL.MMMConfig.Model.LineTimes, prefixStr, overtimeStr);
                }
                else if (offer.HelpType == 1)//抢单
                {
                    result = DateDiffStr(ddType, offer.SQDate, BLL.MMMConfig.Model.MHBRangeTimes, prefixStr, overtimeStr);
                }
            }
            else if (type == MMMOfferTimeType.FreezeTime)
            {
                if (offer.HelpType == 0)
                {
                    if (offer.SincerityState == 1)
                    {
                        result = DateDiffStr(ddType, offer.CompleteTime.Value, BLL.MMMConfig.Model.FreezeTimes, prefixStr, overtimeStr);
                    }
                    else
                    {
                        result = DateDiffStr(ddType, offer.CompleteTime.Value, BLL.MMMConfig.Model.MHBRangeTimes, prefixStr, overtimeStr);
                    }
                    //result = DateDiffStr(ddType, offer.CompleteTime.Value, BLL.MMMConfig.Model.FreezeTimes, prefixStr, overtimeStr);
                }
                else if (offer.HelpType == 1)
                {
                    if (offer.SincerityState == 1)
                    {
                        result = DateDiffStr(ddType, offer.CompleteTime.Value, BLL.MMMConfig.Model.FreezeTimesOfRegister, prefixStr, overtimeStr);
                    }
                    else
                    {
                        result = DateDiffStr(ddType, offer.CompleteTime.Value, BLL.MMMConfig.Model.MHBRangeTimes, prefixStr, overtimeStr);
                    }
                    //result = DateDiffStr(ddType, offer.CompleteTime.Value, BLL.MMMConfigScramble.Model.FreezeTimes, prefixStr, overtimeStr);
                }
            }
            return result;
        }

        # endregion 时间

        /// <summary>
        /// 匹配表中的状态信息
        /// </summary>
        /// <param name="matchState"></param>
        /// <returns></returns>
        protected string GetMatchState(object matchState, object jujuemessage)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(matchState.ToString()))
            {
                if (matchState.ToString() == "1")
                {
                    result = "未付款";
                    if (!string.IsNullOrEmpty(jujuemessage.ToString()))
                        result += "，付款方拒绝交易：" + jujuemessage;
                }
                else if (matchState.ToString() == "2")
                {
                    result = "已打款等待确认";
                    if (!string.IsNullOrEmpty(jujuemessage.ToString()))
                        result += "，收款方拒绝交易：" + jujuemessage;
                }
                else if (matchState.ToString() == "3")
                {
                    result = "收款方已确认";
                }
                else if (matchState.ToString() == "4")
                {
                    result = "已完成";
                }
            }
            return result;
        }

        /// <summary>
        /// 状态
        /// </summary>
        protected string GetHelpState(object PPState)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(PPState.ToString()))
            {
                if (PPState.ToString() == "0" || PPState.ToString() == "2")
                    result = "等待匹配中";
                else if (PPState.ToString() == "1")
                    result = "已成功匹配";
                else if (PPState.ToString() == "3")
                    result = "交易完成";
                else if (PPState.ToString() == "4")
                    result = "已提款";
            }
            return result;
        }

        # endregion 互助
    }
}