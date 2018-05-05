using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace WE_Project.Web.Message
{
    public partial class NewNoticeView : BasePage
    {
        public Model.Notice model;
        protected override void SetValue(string id)
        {
            model = BLL.Notice.Select(int.Parse(id), true);
        }

        protected override string btnAdd_Click()
        {
            string str = Request.Params["nid"];
            Hashtable hs = new Hashtable();
            BLL.Member.UpdateConfigTran(TModel.MID, "ReadNoticeID", str, TModel, true, SqlDbType.Int, hs);
            if (BLL.CommonBase.RunHashtable(hs))
            {
                return "1";
            }

            return "0";
        }
    }
}