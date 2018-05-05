using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WE_Project.Web.Member
{
    public partial class MyActiveCode : BasePage
    {
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
            {
                DivSearch.InnerHtml = "";
            }
        }

        protected static object obj = new object();
        protected override string btnModify_Click()
        {
            int count = int.Parse(Request.Form["txtCount"]);
            string txtMID = Request.Form["txtMID"];
            //校验是否存在该会员
            Model.Member mem = BllModel.GetModel(txtMID);
            if (mem == null)
            {
                return "不存在该会员";
            }
            else
            {
                lock (obj)
                {
                    Hashtable hs = new Hashtable();
                    List<Model.ActiveCode> codeList = BLL.ActiveCode.GetTopList("UseState=0 and MID='" + TModel.MID + "'", count);
                    if (codeList.Count >= count)
                    {
                        foreach (Model.ActiveCode ac in codeList)
                        {
                            ac.MID = txtMID;
                            BLL.ActiveCode.Update(ac, hs);
                            BLL.ChangeMoney.InsertTran(new Model.ChangeMoney { FromMID = TModel.MID, ToMID = txtMID, CompleteTime = DateTime.Now, ChangeType = "Active", MoneyType = "Active", CRemarks = ac.Code, ChangeDate = DateTime.Now, CState = true }, hs);
                        }
                        if (BLL.CommonBase.RunHashtable(hs))
                        {
                            return "1";
                        }
                    }
                    return "0";
                }
            }


            //return BLL.MemberApply.DeleteApply(CheckHasApplyed(TModel.MID, 1, int.Parse(Request.Form["hidtype"])).Id.ToString());
        }
    }
}