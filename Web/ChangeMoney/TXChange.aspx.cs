using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.ChangeMoney
{
    public partial class TXChange : BasePage
    {
        protected override void SetPowerZone()
        {
            Model.Member model = TModel;
            if (!TModel.MConfig.TXStatus)
            {
                //不能提现
                Button1.Visible = false;
            }
            else
            {
                divTips.Visible = false;
            }
            //BindDdlPwdQuestion(ddl_PwdQuestion);
        }
        /// <summary>
        /// 申请提现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            //if (Check_SQ_Answer())
            //{
                //验证身份证号
                //if (Request.Form["txtNumID"].Trim() != TModel.NumID)
                //{
                //    return "身份证号校验失败！";
                //}

                Model.Member model = TModel;
                if (model.IsClock)
                    return "您已被冻结账号，不可提现或转移";
                if (!CheckTXCount(model.MID))
                    return "您今日的提现次数已超过系统规定的次数，今日不可再次提现";
                if (!string.IsNullOrEmpty(Request.Form["txtMHB"]))
                {
                    int money = int.Parse(Request.Form["txtMHB"]);
                    if (money > 0)
                    {
                        return BLL.ChangeMoney.TXChange(int.Parse(Request.Form["txtMHB"]), model);
                    }
                    else
                    {
                        return "参数异常";
                    }
                }
                else
                {
                    return "参数异常";
                }
            //}
            //else
            //    return "密保问题错误";
        }
        /// <summary>
        /// 计算每日的提现次数是否超过规定的次数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected bool CheckTXCount(string mid)
        {
            bool result = true;
            int checkCount =6;
            int count = BLL.ChangeMoney.GetDayTXCount(mid);
            if (count >= checkCount)
                result = false;
            return result;
        }
        protected Model.BankModel GetBankModel(string mid)
        {
            List<Model.BankModel> list = BLL.BankModel.GetList("MID='" + mid + "' and IsPrimary=1");
            if (list != null && list.Count > 0)
            {
                return list[0];
            }
            else return null;
        }
    }
}