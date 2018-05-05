using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.ChangeMoney
{
    public partial class HBChange : BasePage
    {
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
            {
                txtFromMID.Value = TModel.MID;
                txtFromMID.Attributes.Add("readonly", "readonly");
                //if (!TModel.MConfig.ZZStatus)
                //{
                //    //不能提现
                //    btnOK.Visible = false;
                //}
                //else
                //{
                divTips.Visible = false;
                //}
            }
            //BindDdlPwdQuestion(ddl_PwdQuestion);
        }

        /// <summary>
        /// 货币转移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            //验证身份证号
            //if (Request.Form["txtNumID"].Trim() != TModel.NumID)
            //{
            //    return "身份证号校验失败！";
            //}

            //if (Check_SQ_Answer())
            {
                string MType = "MGP";
                //if (Request.Form["RioHK"] == "1")
                //{
                //    MType = "MJB";
                //}
                //else
                //{
                //    MType = "MGP";
                //}

                Model.Member fmodel = null;
                Model.Member tmodel = null;
                if (!TModel.Role.IsAdmin)
                    fmodel = TModel;
                else
                    fmodel = BllModel.GetModel(Request.Form["txtFromMID"]);
                tmodel = BllModel.GetModel(Request.Form["txtMID"]);
                if (fmodel == null || tmodel == null)
                {
                    return "转入或转出会员不存在！";
                }
                if (tmodel.IsClock)
                {
                    return "对方账户已冻结,无法转账！";
                }
                if (!string.IsNullOrEmpty(Request.Form["txtMHB"]))
                {
                    int money = int.Parse(Request.Form["txtMHB"]);
                    return BLL.ChangeMoney.ZZMoneyChange(money, fmodel.MID, Request.Form["txtMID"], "ZZ", MType);
                }
                else
                {
                    return "转账金额不能为空";
                }
            }
            //else
            //    return "密保问题错误";
        }
    }
}