using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.ChangeMoney
{
    public partial class JJList : BasePage
    {
        protected List<Model.Reward> list = new List<Model.Reward>();
        protected string date = "";
        protected string mKey = "";
        protected override void SetPowerZone()
        {
            //if (!TModel.Role.IsAdmin)
            //    DivSearch.InnerHtml = "";
            if (!TModel.Role.Super)
                DivDelete.InnerHtml = "";

            foreach (KeyValuePair<string, Model.Reward> item in BLL.Reward.List)
            {
                if (item.Value.NeedProcess)
                    list.Add(item.Value);
            }
            date = Request.QueryString["date"];
        }

        protected override void SetValue(string id)
        {
            mKey = id;
        }
    }
}