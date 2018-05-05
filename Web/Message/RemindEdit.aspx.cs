using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Message
{
    public partial class RemindEdit : BasePage
    {
        protected string txtNContent = "";
        protected override void SetValue(string id)
        {
            NoticeModel = BLL.Remind.GetModel(id);
        }

        private Model.Remind NoticeModel
        {
            get
            {
                Model.Remind model = BLL.Remind.GetModel(Request.Form["hidId"]);
                model.RTypeName = Request.Form["txtNTitle"];
                model.RemindMsg = HttpUtility.UrlDecode(Request.Form["hdContent"]);
                model.State = 1;
                return model;
            }
            set
            {
                hidId.Value = value.Id.ToString();
                txtNTitle.Value = value.RTypeName;
                txtNContent = value.RemindMsg;
            }
        }

        protected override string btnModify_Click()
        {
            if (BLL.Remind.Update(NoticeModel))
            {
                return "操作成功";
            }
            return "操作失败";
        }
    }
}