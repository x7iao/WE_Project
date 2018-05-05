using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WE_Project.Web.Member
{
    public partial class RegionList : BasePage
    {
        protected override void SetPowerZone()
        {
            DataTable dt = BLL.Member.GetRegionHeaderList2("","");
            rep_List.DataSource = dt;
            rep_List.DataBind();
          
        }
        protected override string btnModify_Click()
        {
            string mid = Request.Form["txtMId"];
            string province = Request.Form["txtProvince"];
            DataTable dt = BLL.Member.GetRegionHeaderList2(province, mid);
            string html = "";
            foreach (DataRow dr in dt.Rows)
            {
                html += "<div class='listdiv'><p class='p1'>" + dr["Province"].ToString() + dr["Region"].ToString() + " 区</p> <p class='p2'>玩家：" + dr["MID"].ToString() + " &nbsp;QQ群：" + dr["MQQGroup"].ToString() + "</p>  </div>";
            }
            //contui.InnerHtml = html;
            return html;
        }
    }
}