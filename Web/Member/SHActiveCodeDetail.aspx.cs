using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WE_Project.Web.Member
{
    public partial class SHActiveCodeDetail : BasePage
    {
        protected Model.BuyActiveCode BuyActiveCodeModel;
        protected string picImgs = "";
        protected override void SetPowerZone()
        {
        }
        protected override void SetValue(string id)
        {
            BuyActiveCodeModel = BLL.BuyActiveCode.GetModel(id);
            if (BuyActiveCodeModel.State == 1)
            {
                btnOK.Visible = false;
            }
            hidId.Value = id;
            string picUrl = BuyActiveCodeModel.PicUrl;
            string[] array = picUrl.Split(',');
            foreach (string str in array)
            {
                picImgs += "<div class='appDiv'><img class='appImg' src='" + str + "'  style='max-width: 700px;'/></div>";
            }

        }

        protected override string btnAdd_Click()
        {
            if (!TModel.Role.IsAdmin)
            {
                return "失败";
            }
            BuyActiveCodeModel = BLL.BuyActiveCode.GetModel(Request.Form["hidId"]);
            if (BuyActiveCodeModel != null)
            {
                Hashtable hs = new Hashtable();
                BuyActiveCodeModel.ConfirmTime = DateTime.Now;
                BuyActiveCodeModel.State = 1;
                BLL.BuyActiveCode.Update(BuyActiveCodeModel, hs);
                //发送校验码
                lock (new object())
                {
                    //List<Model.ActiveCode> codeList = BLL.ActiveCode.GetTopList("UseState=0", BuyActiveCodeModel.CodeCount);
                    List<Model.ActiveCode> codeList = BLL.ActiveCode.GetTopList("UseState=0 and MID='" + BuyActiveCodeModel.ToMID + "'", BuyActiveCodeModel.CodeCount);
                    int i = 0;
                    foreach (Model.ActiveCode ac in codeList)
                    {
                        i++;
                        ac.MID = BuyActiveCodeModel.FromMID;
                        //ac.UseState = 1;
                        BLL.ChangeMoney.InsertTran(new Model.ChangeMoney { FromMID = BuyActiveCodeModel.ToMID, ToMID = BuyActiveCodeModel.FromMID, CompleteTime = DateTime.Now, ChangeType = "Active", MoneyType = "Active", CRemarks = ac.Code, ChangeDate = DateTime.Now, CState = true }, hs);
                        BLL.ActiveCode.Update(ac, hs);
                    }
                    if (i == BuyActiveCodeModel.CodeCount)
                    {
                        if (BLL.CommonBase.RunHashtable(hs))
                        {
                            return "1";
                        }
                    }
                    else
                    {
                        return "0";
                    }
                }
            }

            return "0";
        }
    }
}