using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WE_Project.Web.Admin
{
    public partial class Index : BasePage
    {
        private List<Model.RolePowers> listPowers;
        protected string TotalFH = "0", DayFHMoney = "0", charData = "", charXaxis = "", isShowNotice = "0", showId = "0", leaveToOutCount = "0", todayFHMoney = "0", isMotifyInfo = "0", isHas23FHCounts = "0";
        protected string notcie = "";
        public List<Model.Notice> noticelist = null;
        protected Model.Member tjmodel = new Model.Member();
        protected bool qdstate = true;
        protected string ts = "";
        protected bool offQD = false;

        protected string pdtotalcount = "0";//排单总数
        protected string txtotalcount = "0";//提现总数
        protected string pddaymoney = "0";//日排单金额
        protected string txdaymoney = "0";//日提现金额
        protected string totalmembercount = "0";//平台总人数
        protected string daymembercount = "0";//日新增人数


        protected DataTable dtxxfloat = null;
        ////买入许愿果总额
        //protected decimal ShowOfferTotalMoney = 0;
        ////卖出许愿果总额
        //protected decimal ShowGetTotalMoney = 0;
        ////总人数
        //protected int ShowTotalNumber = 0;

        protected Dictionary<string, List<string>> FDlist = new Dictionary<string, List<string>>();

        protected override void SetPowerZone()
        {
            listPowers = TModel.Role.PowersList.Where(emp => emp.Content.VState).ToList();

            dtxxfloat= BLL.CommonBase.GetTable("select amid,bmbd,(case boutmoney when 0 then 0 else Convert(decimal(18,1),(fhdays/boutmoney)*100) end)  as xxfloat from bmember where bmstate=0 and amid='" + TModel.MID+"' order by BMCreateDate asc;");

            //排单总数
            //if (BLL.Configuration.Model.TXMinMoney < 0)
            //{
            //    pdtotalcount = BLL.CommonBase.GetSingle("select count(*) from mofferhelp where ppstate<>5;").ToString();
            //}
            //else {
                pdtotalcount = BLL.Configuration.Model.TXMinMoney.ToString();
            //}

            //提现总数
            //if (BLL.Configuration.Model.TXBaseMoney < 0)
            //{
            //    txtotalcount = BLL.CommonBase.GetSingle("select count(*) from mgethelp where ppstate<>5;").ToString();
            //}
            //else {
                txtotalcount = BLL.Configuration.Model.TXBaseMoney.ToString();
            //}

            //日排单金额
            //if (BLL.Configuration.Model.GPrice < 0)
            //{
            //    pddaymoney = BLL.CommonBase.GetSingle("select isnull(sum(sqmoney),0) from mofferhelp where ppstate<>5 and datediff(dd,sqdate,getdate())=0;").ToString();
            //}
            //else {
                pddaymoney = BLL.Configuration.Model.GPrice.ToString();
            //}
            //日提现金额
            //if (BLL.Configuration.Model.DFHFloat < 0)
            //{
            //    txdaymoney = BLL.CommonBase.GetSingle("select  isnull(sum(sqmoney),0) from mgethelp where ppstate<>5 and datediff(dd,sqdate,getdate())=0;").ToString();
            //}
            //else {
                txdaymoney = BLL.Configuration.Model.DFHFloat.ToString();
            //}

            //平台总人数
            //if (BLL.Configuration.Model.MinBuyGCount < 0)
            //{
            //    totalmembercount = BLL.CommonBase.GetSingle("select count(*) from member where mid<>'admin';").ToString();
            //}
            //else {
                totalmembercount = BLL.Configuration.Model.MinBuyGCount.ToString();
            //}

            //日新增人数
            //if (BLL.Configuration.Model.DFHOutCount < 0)
            //{
            //    daymembercount = BLL.CommonBase.GetSingle("select count(*) from member where mid<>'admin' and datediff(dd,mcreatedate,getdate())=0; ").ToString();
            //}
            //else {
                daymembercount = BLL.Configuration.Model.DFHOutCount.ToString();
            //}

            //txtTuiGuang.Value = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, "/Regedit/Index.aspx");
            //txtTuiGuang.Value += "?mid=" + TModel.MID;

            SetDefaultVal();

            var off = BLL.MOfferHelp.GetQDOfferMoney(TModel.MID);
            if (off != null)
            {
                var list = BLL.ChangeMoney.GetList(" CRemarks = '" + off.SQCode + "' and DATEDIFF(DD,ChangeDate,GETDATE()) = 0 ");
                if (list == null || !list.Any())
                {
                    offQD = true;
                }
            }

            //if (TModel.Role.IsAdmin)
            //{
            //    ShowOfferTotalMoney = BLL.MOfferHelp.GetSumMoney(" PPState <> 5 ");
            //    ShowGetTotalMoney = BLL.MGetHelp.GetSumMoney(" PPState <> 5 ");
            //    ShowTotalNumber = BLL.Member.GetSumCount(" RoleCode in ('Nomal') ");
            //}
            //else
            //{
            //    ShowOfferTotalMoney = BLL.Configuration.Model.ShowOfferTotalMoney;
            //    ShowGetTotalMoney = BLL.Configuration.Model.ShowGetTotalMoney;
            //    ShowTotalNumber = BLL.Configuration.Model.ShowTotalNumber;
            //}

            tjmodel = BLL.Member.ManageMember.GetModel(TModel.MTJ);
            //金口消息
            //Model.Notice obj = BLL.Notice.GetNewNotice(9999);
            //if (obj != null)
            //    notcie = obj.NContent;
            //消息
           noticelist = BLL.Notice.GetNoticeLists(10);
            //repNoticeList.DataBind();
        }

        protected string GetBankInfo(object mid)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(mid.ToString()))
            {
                Model.Member mem = BllModel.GetModel(mid.ToString());
                if (mem != null)
                {
                    result = "开户银行：" + mem.Bank + "&nbsp;&nbsp;&nbsp;开户名：" + mem.BankCardName + "<br/>开户支行：" + mem.Branch + "<br/>银行账号：" + mem.BankNumber + "<br/>手机号码：" + mem.Tel;
                }
            }
            return result;
        }

        protected string getMName(object mid, object Remark, object ChangeCount)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(mid.ToString()))
            {
                Model.Member mem = BllModel.GetModel(mid.ToString());
                if (mem != null)
                {
                    result = mem.MName;
                    if (ChangeCount.ToString() != "0")
                    {
                        result += "<b style='color:red;'>(" + Remark + ")</b>";
                    }
                }
            }
            return result;
        }

        protected string GetCommand(object state, object id, object PicUrl2)
        {
            if (state.ToString() == "1")
            {
                return "<input type='button' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/PayMoney.aspx?id=" + id.ToString() + "','订单付款');\" value='去付款>>'/>";
            }
            else
            {
                if (!string.IsNullOrEmpty(PicUrl2.ToString()))
                    return "<input type='button' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/MatchView.aspx?id=" + id.ToString() + "','订单详情');\" value='查看详细>>'/>";
                else
                    return "<input type='button' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/MatchView.aspx?id=" + id.ToString() + "','给收款方评价');\" value='给收款方评价>>'/>";
            }
        }


        protected string GetMatchPic(object state)
        {
            string retu = string.Empty;
            retu = "<img src='Admin/images/check.png'>";
            //1-未打款；2-已打款；3-已确认；4-已完成
            if (state.ToString() == "1")
            {
                retu = "<img src='Admin/images/orun.png'>";
            }
            else if (state.ToString() == "2")
            {
                retu = "<img src='Admin/images/ook-2.png'>";
            }
            else if (state.ToString() == "3")
            {
                retu = "<img src='Admin/images/check.png'>";
            }
            else if (state.ToString() == "4")
            {
                retu = "<img src='Admin/images/check.png'>";
            }
            return retu;
        }

        protected string GetCommand2(object state, object id)
        {
            if (state.ToString() == "2")
            {
                return "<input type='button' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/GetMoney.aspx?id=" + id.ToString() + "','确认收款');\" value='确认收款>>' />";
            }
            else
            {
                return "<input type='button' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/MatchView.aspx?id=" + id.ToString() + "','订单详情');\" value='查看详细>>' />";
            }
        }


        protected List<Model.RolePowers> GetPowers(string cfid)
        {

            return listPowers.Where(emp => emp.Content.CFID == cfid).ToList();
        }
        protected void SetDefaultVal()
        {
            //Model.StockConfig config = BLL.StockConfig.Model;
            //int splitCount = config.SplitCount;
            //for (int i = 0; i < splitCount; i++)
            //{
            //    //先查看这个价位的挂卖表中是否还有增值币
            //    decimal price = config.InitPrice + (config.SplitAddPrice * i);
            //    List<Model.MGP_Publish> listPublish = new BLL.MGP_Publish().GetList(" LeaveCount<>0 and CurrentPrice=" + price.ToString() + " order by PublishType desc");
            //    if (listPublish != null && listPublish.Count > 0)
            //    {
            //        CurrentPrice = listPublish[0].CurrentPrice.ToString();
            //        break;
            //    }
            //}

            ////计算个人的总计分红
            //TotalFH = BLL.ChangeMoney.GetTotalFHMoney(TModel.MID).ToString();
        }

        protected List<Model.RolePowers> GetQuickMenu()
        {
            List<Model.RolePowers> list = listPowers.Where(emp => emp.Content.IsQuickMenu).ToList();
            return list;
        }
    }
}