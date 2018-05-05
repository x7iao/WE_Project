using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WE_Project.Web.Member
{
    public partial class GetActiveCode : BasePage
    {
        protected override string btnAdd_Click()
        {
            if (!TModel.Role.Super)
                return "0";
            int count = int.Parse(Request.Form["txtCodeNum"]);
            Hashtable hs = new Hashtable();
            for (int i = 0; i < count; i++)
            {
                Model.ActiveCode code = new Model.ActiveCode();
                string guid = Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "").ToUpper();
                code.Code = guid.Substring(0, 10);
                code.CreateTime = DateTime.Now;
                code.UseState = 0;
                code.MID = BLL.Member.ManageMember.TModel.MID;
                code.SwitchType = "生成";
                if (BLL.CommonBase.GetSingle("select id from ActiveCode where Code='" + code.Code + "'") == null)
                {
                    BLL.ActiveCode.Insert(code, hs);
                    BLL.CommonBase.RunHashtable(hs);
                    hs.Clear();
                }
            }
            return "1";
        }
        protected static object obj = new object();
        //分发
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
                            ac.SwitchType = "手动转移";
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


        protected override string btnOther_Click()
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
                    List<Model.ActiveCode> codeList = BLL.ActiveCode.GetTopList("UseState=0 and MID='" + mem.MID + "'", count);
                    if (codeList.Count >= count)
                    {
                        foreach (Model.ActiveCode ac in codeList)
                        {
                            ac.MID = BLL.Member.ManageMember.TModel.MID;
                            BLL.ActiveCode.Update(ac, hs);
                            BLL.ChangeMoney.InsertTran(new Model.ChangeMoney { FromMID = txtMID, ToMID = BLL.Member.ManageMember.TModel.MID, CompleteTime = DateTime.Now, ChangeType = "Active", MoneyType = "Active", CRemarks = ac.Code, ChangeDate = DateTime.Now, CState = true }, hs);
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