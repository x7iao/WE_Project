using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Member
{
    public partial class BuyActive : BasePage
    {
        protected override string btnAdd_Click()
        {
            int count = int.Parse(Request.Form["txtCount"]);
            DateTime payDate = DateTime.Now;
            string msg = Request.Form["txtRemark"];
            string picurl = Request.Form["hduploadPic1"];
            if (string.IsNullOrEmpty(picurl))
            {
                return "请上传打款凭证";
            }
            Model.BuyActiveCode buy = new Model.BuyActiveCode();
            buy.CodeCount = count;
            buy.CreateTime = DateTime.Now;
            buy.FromMID = TModel.MID;
            buy.ToMID = BLL.Member.ManageMember.TModel.MID;
            buy.State = 0;
            buy.PicUrl = picurl;
            buy.Remark = msg;
            buy.PayTime = payDate;
            if (BLL.BuyActiveCode.Insert(buy))
            {
                return "1";
            }
            return "申请失败";
        }
    }
}