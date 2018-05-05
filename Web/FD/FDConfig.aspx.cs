using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.FD
{
    public partial class FDConfig : BasePage
    {
        protected override void SetPowerZone()
        {
            FDModelA = BLL.FDConfig.FDConfigModel["A"];
            FDModelB = BLL.FDConfig.FDConfigModel["B"];
            FDModelC = BLL.FDConfig.FDConfigModel["C"];
            FDModelD = BLL.FDConfig.FDConfigModel["D"];
        }

        private Model.FDConfig FDModelA
        {
            get
            {
                Model.FDConfig fda = BLL.FDConfig.FDConfigModel["A"];
                fda.FDCFFloat = Convert.ToDecimal(Request.Form["txtFDCFFloatA"]);
                fda.FDCloseRemark = Request.Form["txtFDCloseRemarkA"];
                fda.FDEndTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + Request.Form["txtFDEndTimeA"]);
                fda.FDMCWFloat = Convert.ToDecimal(Request.Form["txtFDMCWFloatA"]);
                fda.FDMGPFloat = Convert.ToDecimal(Request.Form["txtFDMGPFloatA"]);
                fda.FDMHBFloat = Convert.ToDecimal(Request.Form["txtFDMHBFloatA"]);
                fda.FDPrice = Convert.ToDecimal(Request.Form["txtFDPriceA"]);
                fda.FDSellCount = Convert.ToInt32(Request.Form["txtFDSellCountA"]);
                fda.FDStartTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + Request.Form["txtFDStartTimeA"]);
                fda.FDState = Convert.ToBoolean(Request.Form["ddlFDStateA"]);
                return fda;
            }
            set
            {
                txtFDCFFloatA.Value = value.FDCFFloat.ToString();
                txtFDCloseRemarkA.Value = value.FDCloseRemark;
                txtFDEndTimeA.Value = value.FDEndTime.ToString("HH:mm");
                txtFDMCWFloatA.Value = value.FDMCWFloat.ToString();
                txtFDMGPFloatA.Value = value.FDMGPFloat.ToString();
                txtFDMHBFloatA.Value = value.FDMHBFloat.ToString();
                txtFDPriceA.Value = value.FDPrice.ToString();
                txtFDSellCountA.Value = value.FDSellCount.ToString();
                txtFDStartTimeA.Value = value.FDStartTime.ToString("HH:mm");
                ddlFDStateA.Value = value.FDState.ToString();
            }
        }

        private Model.FDConfig FDModelB
        {
            get
            {
                Model.FDConfig fda = BLL.FDConfig.FDConfigModel["B"];
                fda.FDCFFloat = Convert.ToDecimal(Request.Form["txtFDCFFloatB"]);
                fda.FDCloseRemark = Request.Form["txtFDCloseRemarkB"];
                fda.FDEndTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + Request.Form["txtFDEndTimeB"]);
                fda.FDMCWFloat = Convert.ToDecimal(Request.Form["txtFDMCWFloatB"]);
                fda.FDMGPFloat = Convert.ToDecimal(Request.Form["txtFDMGPFloatB"]);
                fda.FDMHBFloat = Convert.ToDecimal(Request.Form["txtFDMHBFloatB"]);
                fda.FDPrice = Convert.ToDecimal(Request.Form["txtFDPriceB"]);
                fda.FDSellCount = Convert.ToInt32(Request.Form["txtFDSellCountB"]);
                fda.FDStartTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + Request.Form["txtFDStartTimeB"]);
                fda.FDState = Convert.ToBoolean(Request.Form["ddlFDStateB"]);
                return fda;
            }
            set
            {
                txtFDCFFloatB.Value = value.FDCFFloat.ToString();
                txtFDCloseRemarkB.Value = value.FDCloseRemark;
                txtFDEndTimeB.Value = value.FDEndTime.ToString("HH:mm");
                txtFDMCWFloatB.Value = value.FDMCWFloat.ToString();
                txtFDMGPFloatB.Value = value.FDMGPFloat.ToString();
                txtFDMHBFloatB.Value = value.FDMHBFloat.ToString();
                txtFDPriceB.Value = value.FDPrice.ToString();
                txtFDSellCountB.Value = value.FDSellCount.ToString();
                txtFDStartTimeB.Value = value.FDStartTime.ToString("HH:mm");
                ddlFDStateB.Value = value.FDState.ToString();
            }
        }

        private Model.FDConfig FDModelC
        {
            get
            {
                Model.FDConfig fda = BLL.FDConfig.FDConfigModel["C"];
                fda.FDCFFloat = Convert.ToDecimal(Request.Form["txtFDCFFloatC"]);
                fda.FDCloseRemark = Request.Form["txtFDCloseRemarkC"];
                fda.FDEndTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + Request.Form["txtFDEndTimeC"]);
                fda.FDMCWFloat = Convert.ToDecimal(Request.Form["txtFDMCWFloatC"]);
                fda.FDMGPFloat = Convert.ToDecimal(Request.Form["txtFDMGPFloatC"]);
                fda.FDMHBFloat = Convert.ToDecimal(Request.Form["txtFDMHBFloatC"]);
                fda.FDPrice = Convert.ToDecimal(Request.Form["txtFDPriceC"]);
                fda.FDSellCount = Convert.ToInt32(Request.Form["txtFDSellCountC"]);
                fda.FDStartTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + Request.Form["txtFDStartTimeC"]);
                fda.FDState = Convert.ToBoolean(Request.Form["ddlFDStateC"]);
                return fda;
            }
            set
            {
                txtFDCFFloatC.Value = value.FDCFFloat.ToString();
                txtFDCloseRemarkC.Value = value.FDCloseRemark;
                txtFDEndTimeC.Value = value.FDEndTime.ToString("HH:mm");
                txtFDMCWFloatC.Value = value.FDMCWFloat.ToString();
                txtFDMGPFloatC.Value = value.FDMGPFloat.ToString();
                txtFDMHBFloatC.Value = value.FDMHBFloat.ToString();
                txtFDPriceC.Value = value.FDPrice.ToString();
                txtFDSellCountC.Value = value.FDSellCount.ToString();
                txtFDStartTimeC.Value = value.FDStartTime.ToString("HH:mm");
                ddlFDStateC.Value = value.FDState.ToString();
            }
        }

        private Model.FDConfig FDModelD
        {
            get
            {
                Model.FDConfig fda = BLL.FDConfig.FDConfigModel["D"];
                fda.FDCFFloat = Convert.ToDecimal(Request.Form["txtFDCFFloatD"]);
                fda.FDCloseRemark = Request.Form["txtFDCloseRemarkD"];
                fda.FDEndTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + Request.Form["txtFDEndTimeD"]);
                fda.FDMCWFloat = Convert.ToDecimal(Request.Form["txtFDMCWFloatD"]);
                fda.FDMGPFloat = Convert.ToDecimal(Request.Form["txtFDMGPFloatD"]);
                fda.FDMHBFloat = Convert.ToDecimal(Request.Form["txtFDMHBFloatD"]);
                fda.FDPrice = Convert.ToDecimal(Request.Form["txtFDPriceD"]);
                fda.FDSellCount = Convert.ToInt32(Request.Form["txtFDSellCountD"]);
                fda.FDStartTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + Request.Form["txtFDStartTimeD"]);
                fda.FDState = Convert.ToBoolean(Request.Form["ddlFDStateD"]);
                return fda;
            }
            set
            {
                txtFDCFFloatD.Value = value.FDCFFloat.ToString();
                txtFDCloseRemarkD.Value = value.FDCloseRemark;
                txtFDEndTimeD.Value = value.FDEndTime.ToString("HH:mm");
                txtFDMCWFloatD.Value = value.FDMCWFloat.ToString();
                txtFDMGPFloatD.Value = value.FDMGPFloat.ToString();
                txtFDMHBFloatD.Value = value.FDMHBFloat.ToString();
                txtFDPriceD.Value = value.FDPrice.ToString();
                txtFDSellCountD.Value = value.FDSellCount.ToString();
                txtFDStartTimeD.Value = value.FDStartTime.ToString("HH:mm");
                ddlFDStateD.Value = value.FDState.ToString();
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        protected override string btnModify_Click()
        {
            BLL.FDConfig.FDConfigModel = null;
            if (Request.QueryString["formid"] == "form1")
            {
                if (BLL.FDConfig.Update(FDModelA))
                    return "保存A盘成功";
            }
            else if (Request.QueryString["formid"] == "form2")
            {
                if (BLL.FDConfig.Update(FDModelB))
                    return "保存B盘成功";
            }
            else if (Request.QueryString["formid"] == "form3")
            {
                if (BLL.FDConfig.Update(FDModelC))
                    return "保存C盘成功";
            }
            else if (Request.QueryString["formid"] == "form4")
            {
                if (BLL.FDConfig.Update(FDModelD))
                    return "保存D盘成功";
            }
            return "保存失败";
        }
        /// <summary>
        /// 增发，清仓
        /// </summary>
        /// <returns></returns>
        protected override string btnAdd_Click()
        {
            BLL.FDConfig.FDConfigModel = null;
            if (Request.QueryString["type"] == "qc")
            {
                if (Request.QueryString["formid"] == "form1")
                {
                    if (BLL.FDConfig.QingCang("A"))
                        return "清仓A盘成功";
                }
                else if (Request.QueryString["formid"] == "form2")
                {
                    if (BLL.FDConfig.QingCang("B"))
                        return "清仓B盘成功";
                }
                else if (Request.QueryString["formid"] == "form3")
                {
                    if (BLL.FDConfig.QingCang("C"))
                        return "清仓C盘成功";
                }
                else if (Request.QueryString["formid"] == "form4")
                {
                    if (BLL.FDConfig.QingCang("D"))
                        return "清仓D盘成功";
                }
                return "清仓失败";
            }
            else if (Request.QueryString["type"] == "zf")
            {
                if (Request.QueryString["formid"] == "form1")
                {
                    if (BLL.FDSellList.Insert(new Model.FDSellList
                    {
                        LastSellDate = DateTime.MaxValue,
                        SellCount = 0,
                        SellDate = DateTime.Now,
                        BuyDate = DateTime.Now,
                        SellFDName = "A",
                        SellMID = BLL.Member.ManageMember.TModel.MID,
                        SellPrice = BLL.FDConfig.FDConfigModel["A"].FDPrice,
                        SellTotalCount = Convert.ToInt32(Request.Form["txtZFCountA"]),
                        ChaiFenCode = 0
                    }))
                        return "增发A盘成功";
                }
                else if (Request.QueryString["formid"] == "form2")
                {
                    if (BLL.FDSellList.Insert(new Model.FDSellList
                    {
                        LastSellDate = DateTime.MaxValue,
                        SellCount = 0,
                        SellDate = DateTime.Now,
                        BuyDate = DateTime.Now,
                        SellFDName = "B",
                        SellMID = BLL.Member.ManageMember.TModel.MID,
                        SellPrice = BLL.FDConfig.FDConfigModel["B"].FDPrice,
                        SellTotalCount = Convert.ToInt32(Request.Form["txtZFCountB"]),
                        ChaiFenCode = 0
                    }))
                        return "增发B盘成功";
                }
                else if (Request.QueryString["formid"] == "form3")
                {
                    if (BLL.FDSellList.Insert(new Model.FDSellList
                    {
                        LastSellDate = DateTime.MaxValue,
                        SellCount = 0,
                        SellDate = DateTime.Now,
                        BuyDate = DateTime.Now,
                        SellFDName = "C",
                        SellMID = BLL.Member.ManageMember.TModel.MID,
                        SellPrice = BLL.FDConfig.FDConfigModel["C"].FDPrice,
                        SellTotalCount = Convert.ToInt32(Request.Form["txtZFCountC"]),
                        ChaiFenCode = 0
                    }))
                        return "增发C盘成功";
                }
                else if (Request.QueryString["formid"] == "form4")
                {
                    if (BLL.FDSellList.Insert(new Model.FDSellList
                    {
                        LastSellDate = DateTime.MaxValue,
                        SellCount = 0,
                        SellDate = DateTime.Now,
                        BuyDate = DateTime.Now,
                        SellFDName = "D",
                        SellMID = BLL.Member.ManageMember.TModel.MID,
                        SellPrice = BLL.FDConfig.FDConfigModel["D"].FDPrice,
                        SellTotalCount = Convert.ToInt32(Request.Form["txtZFCountD"]),
                        ChaiFenCode = 0
                    }))
                        return "增发D盘成功";
                }
                return "增发失败";
            }
            else if (Request.QueryString["type"] == "csh")
            {
                if (Request.QueryString["formid"] == "form1")
                {
                    if (BLL.FDConfig.Reset("A"))
                        return "初始化A盘成功";
                }
                else if (Request.QueryString["formid"] == "form2")
                {
                    if (BLL.FDConfig.Reset("B"))
                        return "初始化B盘成功";
                }
                else if (Request.QueryString["formid"] == "form3")
                {
                    if (BLL.FDConfig.Reset("C"))
                        return "初始化C盘成功";
                }
                else if (Request.QueryString["formid"] == "form4")
                {
                    if (BLL.FDConfig.Reset("D"))
                        return "初始化D盘成功";
                }
                return "初始化失败";
            }
            else
            {
                return "参数有误";
            }
        }
        /// <summary>
        /// 拆分
        /// </summary>
        /// <returns></returns>
        protected override string btnOther_Click()
        {
            BLL.FDConfig.FDConfigModel = null;
            if (Request.QueryString["formid"] == "form1")
            {
                if (BLL.FDConfig.ChaiFen("A"))
                    return "拆分A盘成功";
            }
            else if (Request.QueryString["formid"] == "form2")
            {
                if (BLL.FDConfig.ChaiFen("B"))
                    return "拆分B盘成功";
            }
            else if (Request.QueryString["formid"] == "form3")
            {
                if (BLL.FDConfig.ChaiFen("C"))
                    return "拆分C盘成功";
            }
            else if (Request.QueryString["formid"] == "form4")
            {
                if (BLL.FDConfig.ChaiFen("D"))
                    return "拆分D盘成功";
            }
            return "初始化失败";
        }
    }
}