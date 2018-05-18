using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.FuTou
{
    public partial class FTAdd : BasePage
    {
        public string remain2 = "<select id=\"TranDate\" name=\"TranDate\" runat=\"server\" style=\"width:150px;\">";
        protected override void SetPowerZone()
        {
            DataTable dt= BLL.CommonBase.GetTable("select * from ConfigDictionary where DType='TranConfig';");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                remain2 += "<option value=\""+ dt.Rows[i]["StartLevel"]+ "\">"+ dt.Rows[i]["StartLevel"] + "天[总收益"+ Convert.ToDecimal(dt.Rows[i]["DKey"])*100 + "%]</option>";
            }
            remain2 += "</select>";

            //offerrdo.DataSource = dt;
            //offerrdo.DataTextField = "StartLevel";
            //offerrdo.DataValueField = "StartLevel";
        }

        private static object obj = new object();

        protected override string btnAdd_Click()
        {
            lock (obj)
            {
                string moneyStr = Request.Form["txtCount"];
                decimal money = 0;
                try
                {
                    money = Convert.ToDecimal(moneyStr);
                    if (money < 0)
                    {
                        return "复投金额必须大于0";
                    }
                }
                catch
                {
                    return "请输入正确的复投金额";
                }
                int cdday = 0;
                try
                {
                    cdday =Convert.ToInt32(Request.Form["TranDate"]);
                }
                catch (Exception e)
                {
                    return e.Message;
                }

                Model.ConfigDictionary cd = BLL.Configuration.GetConfigDictionary(cdday, "TranConfig", "");
                if (cd == null)
                    return "请选择正确的投资天数";
                //剩余可复投钱数
                string MoneyType = "MHB";
                if (Request.Form["rdo"] == "MHB")
                {
                    MoneyType = "MHB";
                }
                else if (Request.Form["rdo"] == "MJB")
                {
                    MoneyType = "MJB";
                }
                if (BLL.ChangeMoney.EnoughChange(TModel.MID, money, MoneyType))
                {
                    Model.BMember model = new Model.BMember();
                    model.AMID = TModel.MID;
                    model.BMID = TModel.MID + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    model.BMCreateDate = DateTime.Now;
                    model.BMDate = DateTime.MaxValue;
                    model.BMBD = MoneyType;
                    model.FHDays = 0;
                    model.YJMoney = 0;
                    model.YJCount = money;
                    model.BOutMoney = cd.StartLevel;
                    model.BMState = false;
                    model.BCount =Convert.ToDecimal( cd.DValue);
                    if (BLL.BMember.Insert(model))
                    {
                        return "转入成功";
                    }
                    else
                    {
                        return "转入失败";
                    }
                }
                else
                {
                    return "您的" + BLL.Reward.List[MoneyType].RewardName + "不足";
                }
            }
        }
    }
}