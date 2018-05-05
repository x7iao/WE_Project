using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Text;
using Newtonsoft.Json;
using System.Data;

namespace WE_Project.Web.FD.Handler
{
    /// <summary>
    /// EPBuy 的摘要说明
    /// </summary>
    public class chartMorris : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            if (!string.IsNullOrEmpty(context.Request["type"]))
            {
                if (context.Request["type"] == "week" && !string.IsNullOrEmpty(context.Request["fd"]))
                {
                    int day = 6;
                    if (!string.IsNullOrEmpty(context.Request["day"]))
                        day = Convert.ToInt32(context.Request["day"]);
                    List<FDJYWeek> list = new List<FDJYWeek>();
                    DataTable table = BLL.CommonBase.GetTable("select CONVERT(varchar(100), BuyDate, 23),isnull(SUM(BuyCount),0) from FDBuyList where BuyFDName='" +
                        context.Request["fd"] + "' and BuyDate >DATEADD(DD,-" + day +
                        ",GETDATE()) group by CONVERT(varchar(100), BuyDate, 23) order by CONVERT(varchar(100), BuyDate, 23)");
                    foreach (DataRow dr in table.Rows)
                    {
                        list.Add(new FDJYWeek { Dday = Convert.ToDateTime(dr[0]), sales = Convert.ToInt32(dr[1]) });
                    }
                    List<FDJYWeek> list2 = new List<FDJYWeek>();
                    for (int i = day; i >= 0; i--)
                    {
                        if (list.Where(emp => emp.day == DateTime.Now.AddDays(-i).ToString("MM-dd")).Count() > 0)
                            list2.Add(list.Single(emp => emp.day == DateTime.Now.AddDays(-i).ToString("MM-dd")));
                        else
                            list2.Add(new FDJYWeek { Dday = DateTime.Now.AddDays(-i), sales = 0 });
                    }
                    string ss = JavaScriptConvert.SerializeObject(list2);
                    context.Response.Write(JavaScriptConvert.SerializeObject(list2));
                }
                else if (context.Request["type"] == "all")
                {
                    int day = 6;
                    if (!string.IsNullOrEmpty(context.Request["day"]))
                        day = Convert.ToInt32(context.Request["day"]);
                    List<FDJYAll> list = new List<FDJYAll>();
                    DataTable table = BLL.CommonBase.GetTable("select CONVERT(varchar(100), BuyDate, 23)," +
                        "isnull(SUM(case when BuyFDName='A' then BuyCount else 0 end),0)," +
                        "isnull(SUM(case when BuyFDName='B' then BuyCount else 0 end),0)," +
                        "isnull(SUM(case when BuyFDName='C' then BuyCount else 0 end),0)," +
                        "isnull(SUM(case when BuyFDName='D' then BuyCount else 0 end),0)" +
                        "from FDBuyList where BuyDate >DATEADD(DD,-" + day +
                        ",GETDATE()) group by CONVERT(varchar(100), BuyDate, 23) order by CONVERT(varchar(100), BuyDate, 23)");
                    foreach (DataRow dr in table.Rows)
                    {
                        list.Add(new FDJYAll { Dday = Convert.ToDateTime(dr[0]), afd = Convert.ToInt32(dr[1]), bfd = Convert.ToInt32(dr[2]), cfd = Convert.ToInt32(dr[3]), dfd = Convert.ToInt32(dr[4]) });
                    }
                    List<FDJYAll> list2 = new List<FDJYAll>();
                    for (int i = day; i >= 0; i--)
                    {
                        if (list.Where(emp => emp.day == DateTime.Now.AddDays(-i).ToString("MM-dd")).Count() > 0)
                            list2.Add(list.Single(emp => emp.day == DateTime.Now.AddDays(-i).ToString("MM-dd")));
                        else
                            list2.Add(new FDJYAll { Dday = DateTime.Now.AddDays(-i), afd = 0, bfd = 0, cfd = 0, dfd = 0 });
                    }
                    context.Response.Write(JavaScriptConvert.SerializeObject(list2));
                }
                else
                {
                    context.Response.Write("非法操作");
                }
            }

        }

        private class FDJYWeek
        {
            public DateTime Dday { get; set; }
            public string day
            {
                get
                {
                    return this.Dday.ToString("MM-dd");
                }
            }
            public int sales { get; set; }
        }
        private class FDJYAll
        {
            public DateTime Dday { get; set; }
            public string day
            {
                get
                {
                    return this.Dday.ToString("MM-dd");
                }
            }
            public int afd { get; set; }
            public int bfd { get; set; }
            public int cfd { get; set; }
            public int dfd { get; set; }
        }
    }
}