using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Message
{
    public partial class IndexShowMsg : BasePage
    {
        protected override void SetValue(string id)
        {
            NoticeModel = BLL.WriteEmail.GetModel(id);
        }
        private Model.WriteEmail NoticeModel
        {
            get
            {
                Model.WriteEmail model = new Model.WriteEmail();
                model.WriteTime = Convert.ToDateTime(Request.Form["txtPubTime"]);
                model.WriteContent = Request.Form["txtContent"];
                model.Code = GetGuid();
                model.PublishBy = TModel.MID;
                model.WriteBy = TModel.MID;
                model.PublishTime = DateTime.Now;
                if (!string.IsNullOrEmpty(Request.Form["hidId"]))
                    model.Id = int.Parse(Request.Form["hidId"]);
                return model;
            }
            set
            {
                hidId.Value = value.Id.ToString();
                txtPubTime.Value = value.PublishTime.ToString("yyyy-MM-dd");
                txtContent.Value = value.WriteContent;
            }
        }

        protected override string btnAdd_Click()
        {
            if (!string.IsNullOrEmpty(Request.Form["hidId"]))
            {
                if (BLL.WriteEmail.Update(NoticeModel))
                {
                    return "操作成功";
                }

            }
            else
            {
                if (BLL.WriteEmail.Insert(NoticeModel))
                {
                    return "操作成功";
                }
            }

            return "操作失败";
        }
    }
}