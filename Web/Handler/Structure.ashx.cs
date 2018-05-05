using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Text;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// Structure 的摘要说明
    /// </summary>
    public class Structure : BaseHandler
    {
        string tempMysb = string.Empty;
        string tempEmptysb = string.Empty;
        string tempkwsb = string.Empty;

        public override void ProcessRequest(HttpContext context)
        {
            #region 双轨
            StringBuilder tempsb = new StringBuilder();
            tempsb.Append("<li><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"tablefilter\"><tbody>");
            tempsb.Append("<tr align=\"center\" bgcolor=\"{9}\"><td colspan=\"2\" class=\"tdfilter\"><a href=\"javascript:void(0);\" onclick=\"GetAjaxInfo('{0}')\">{1}</a></td></tr>");
            tempsb.Append("<tr align=\"center\"><td colspan=\"2\" class=\"tdfilter\"><table border=\"0\" cellspacing=\"1\" cellpadding=\"2\" width=\"100px\"><tbody>");
            tempsb.Append("<tr bgcolor=\"#C0C0C0\"><td colspan=\"3\">{2}</td></tr>");
            tempsb.Append("<tr bgcolor=\"#C0C0C0\"><td class=\"l\">{3}</td><td class=\"m\">人</td><td class=\"r\">{4}</td></tr>");
            tempsb.Append("<tr bgcolor=\"#C0C0C0\"><td class=\"l\">{7}</td><td class=\"m\">总</td><td class=\"r\">{8}</td></tr>");
            tempsb.Append("<tr bgcolor=\"#C0C0C0\"><td class=\"l\">{5}</td><td class=\"m\">余</td><td class=\"r\">{6}</td></tr>");
            tempsb.Append("</tbody></table></td></tr></tbody></table>");
            tempMysb = tempsb.ToString();
            tempEmptysb = "<li><table cellspacing=\"0\" cellpadding=\"0\" style='width:60px;'><tbody><tr align=\"center\"><td valign=\"middle\" height=\"100%\"><a href=\"javascript:void(0);\" onclick=\"javascript:callhtml('Member/Add.aspx?mid={0}&bdindex={1}','注册会员')\">[空位]<br/><br/>注册</a></td></tr></tbody></table>";
            tempkwsb = "<li><table cellspacing=\"0\" cellpadding=\"0\" style='width:60px;'><tbody><tr align=\"center\"><td valign=\"middle\" height=\"100%\"><br>[空位]</td></tr></tbody></table>";
            #endregion

            #region 太阳线
            //StringBuilder tempsb = new StringBuilder();
            //tempsb.Append("<li><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"tablefilter\"><tbody>");
            //tempsb.Append("<tr align=\"center\" bgcolor=\"{7}\"><td colspan=\"2\" class=\"tdfilter\"><a href=\"javascript:void(0);\" onclick=\"GetAjaxInfo('{0}')\">ID:{1}</a></td></tr>");
            //tempsb.Append("<tr align=\"center\"><td colspan=\"2\" class=\"tdfilter\"><table border=\"0\" cellspacing=\"1\" cellpadding=\"2\" width=\"100%\"><tbody>");
            //tempsb.Append("<tr bgcolor=\"#C0C0C0\"><td colspan=\"3\">{2}</td></tr>");
            //tempsb.Append("<tr bgcolor=\"#C0C0C0\"><td class=\"l\">{3}</td><td class=\"m\">人数</td><td class=\"r\">{4}</td></tr>");
            //tempsb.Append("<tr bgcolor=\"#C0C0C0\"><td class=\"l\">￥{5}</td><td class=\"m\">业绩</td><td class=\"r\">￥{6}</td></tr>");
            //tempsb.Append("</tbody></table></td></tr></tbody></table>");
            //tempMysb = tempsb.ToString();
            //tempEmptysb = "<li><table cellspacing=\"0\" cellpadding=\"0\" class=\"tablefilter\"><tbody><tr align=\"center\"><td valign=\"middle\" height=\"100%\"><a href=\"javascript:AddMember('{0}')\">[空位]<br/><br/>注册</a></td></tr></tbody></table>";
            //tempkwsb = "<li><table cellspacing=\"0\" cellpadding=\"0\" class=\"tablefilter\"><tbody><tr align=\"center\"><td valign=\"middle\" height=\"100%\"><br>[空位]</td></tr></tbody></table>";
            #endregion
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            int level = 3;
            string mkey = memberModel.MID;
            string color = "Agency";
            if (!string.IsNullOrEmpty(context.Request["level"]))
            {
                level = int.Parse(context.Request["level"]);
            }
            if (!string.IsNullOrEmpty(context.Request["mkey"]))
            {
                mkey = context.Request["mkey"];
            }
            if (!string.IsNullOrEmpty(context.Request["color"]))
            {
                color = context.Request["color"];
            }

            level = GetLevel(level, ref mkey, true);

            Model.Member tempmodel = BLL.Member.ManageMember.GetModel(mkey);
            string mbd = tempmodel.MBD;

            if (!memberModel.Role.IsAdmin && mkey == memberModel.MID)
                mbd = "";

            StringBuilder sb = new StringBuilder();
            #region 双轨
            List<Model.Member> MyListMember = new List<Model.Member>();
            List<Model.Member> AllListMember = new List<Model.Member>();
            string chileStr = GetStructure(tempmodel.MID, level, color, ref MyListMember);
            for (int i = 0; i < BLL.Configuration.Model.BDCount; i++)
            {
                if (MyListMember.Count > i)
                    AllListMember.Add(MyListMember[i]);
                else
                    AllListMember.Add(new Model.Member { MConfig = new Model.MemberConfig { UpSumMoney = 0, YJCount = 0 } });
            };
            sb.Append(string.Format(tempMysb, mbd, tempmodel.MID, GetName(tempmodel, color),
                AllListMember[0].MConfig.YJCount, AllListMember[1].MConfig.YJCount,
                AllListMember[0].MConfig.UpSumMoney, AllListMember[1].MConfig.UpSumMoney,
                AllListMember[0].MConfig.YJMoney, AllListMember[1].MConfig.YJMoney,
               GetColor(tempmodel, color)));
            sb.Append(chileStr);
            #endregion

            #region 太阳线
            //if (tempmodel.MConfig == null)
            //{
            //    tempmodel.MConfig = new Model.MemberConfig { YJCount = 0, TJCount = 0, YJMoney = 0, TJMoney = 0 };
            //}
            //sb.Append(string.Format(tempMysb, mbd, tempmodel.MID, GetName(tempmodel, color),
            //    tempmodel.MConfig.YJCount, tempmodel.MConfig.TJCount,
            //    tempmodel.MConfig.YJMoney, tempmodel.MConfig.TJMoney,
            //   GetColor(tempmodel, color)));
            //sb.Append(GetStructure(tempmodel.MID, level, color));
            #endregion

            sb.Append("</li>");
            context.Response.Write(Traditionalized(sb));
        }
        #region 太阳线
        //private string GetStructure(string mid, int level, string color)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    if (level >= 0)
        //    {
        //        List<Model.Member> ListMember = BLL.Member.ManageMember.GetMemberEntityList(string.Format("MBD='{0}' and MID<>'{0}' order by MBDIndex asc", mid));

        //        if (level == 0)
        //            return "";
        //        sb.Append("<ul>");
        //        foreach (Model.Member item in ListMember)
        //        {
        //            string colors = "";
        //            if (item.MState)
        //            {
        //                colors = GetColor(item, color);
        //            }
        //            else
        //            {
        //                colors = BLL.Roles.RolsList["Notactive"].RColor;
        //                item.MConfig = new Model.MemberConfig { YJCount = 0, TJCount = 0, YJMoney = 0, TJMoney = 0 };
        //            }

        //            sb.Append(string.Format(tempMysb, item.MID, item.MID, GetName(item, color),
        //                item.MConfig.YJCount, item.MConfig.TJCount,
        //                item.MConfig.YJMoney, item.MConfig.TJMoney,
        //                colors));
        //            sb.Append(GetStructure(item.MID, level - 1, color));
        //            sb.Append("</li>");
        //        }
        //        sb.Append("</ul>");
        //    }
        //    return Traditionalized(sb);
        //}

        #endregion
        #region 双轨
        private string GetStructure(string mid, int level, string color, ref List<Model.Member> ListMember)
        {
            StringBuilder sb = new StringBuilder();
            if (level >= 0)
            {
                if (mid != "")
                {
                    ListMember = BLL.Member.ManageMember.GetMemberEntityList(string.Format("MBD='{0}' and MState='1' and MID<>'{0}' and AgencyCode<>'001' order by MBDIndex asc", mid));
                    foreach (Model.Member item in ListMember)
                    {
                        if (!item.MState)
                            item.MConfig = new Model.MemberConfig { UpSumMoney = 0, YJCount = 0 };
                    }
                }
                if (level == 0)
                    return "";

                int sumcount = BLL.Configuration.Model.BDCount > ListMember.Count ? BLL.Configuration.Model.BDCount : ListMember.Count;

                sb.Append("<ul>");
                for (int i = 0; i < sumcount; i++)
                {
                    if (i < ListMember.Count)
                    {
                        List<Model.Member> MyListMember = new List<Model.Member>();
                        List<Model.Member> AllListMember = new List<Model.Member>();

                        string colors = "";
                        if (ListMember[i].MState)
                        {
                            colors = GetColor(ListMember[i], color);
                        }
                        else
                        {
                            colors = BLL.Roles.RolsList["Notactive"].RColor;
                            ListMember[i].MConfig = new Model.MemberConfig() { YJCount = 0, UpSumMoney = 0 };
                        }

                        string chileStr = GetStructure(ListMember[i].MID, level - 1, color, ref MyListMember);
                        for (int j = 0; j < BLL.Configuration.Model.BDCount; j++)
                        {
                            if (MyListMember.Count > j)
                                AllListMember.Add(MyListMember[j]);
                            else
                                AllListMember.Add(new Model.Member { MConfig = new Model.MemberConfig { UpSumMoney = 0, YJCount = 0 } });
                        }
                        sb.Append(string.Format(tempMysb, ListMember[i].MID, ListMember[i].MID, GetName(ListMember[i], color),
                            AllListMember[0].MConfig.YJCount, AllListMember[1].MConfig.YJCount,
                            AllListMember[0].MConfig.UpSumMoney, AllListMember[1].MConfig.UpSumMoney,
                            AllListMember[0].MConfig.YJMoney, AllListMember[1].MConfig.YJMoney,
                            colors, BLL.Member.GetOnlineInfo(ListMember[i].MID)));
                        sb.Append(chileStr);
                        sb.Append("</li>");
                    }
                    else
                    {
                        sb.Append(string.Format(tempEmptysb, mid, i + 1));
                        sb.Append("</li>");
                    }
                }
                sb.Append("</ul>");
            }
            return Traditionalized(sb);
        }
        #endregion
        private string GetName(Model.Member model, string colorType)
        {
            switch (colorType)
            {
                case "Agency":
                    return string.IsNullOrEmpty(model.FMID) ? model.MAgencyType.MAgencyName : "子账号";
                case "Role":
                    return model.Role.RName;
                default:
                    return "";
            }
        }

        private string GetColor(Model.Member model, string colorType)
        {
            switch (colorType)
            {
                case "Agency":
                    return model.MAgencyType.MColor;
                case "Role":
                    return model.Role.RColor;
                default:
                    return "";
            }
        }
        private int GetLevel(int level, ref string mkey, bool IsMBD)
        {
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.IsAdmin)
            {
                if (mkey == memberModel.MID)
                {
                    if (level > memberModel.MAgencyType.ViewLevel)
                        level = memberModel.MAgencyType.ViewLevel;
                }
                else
                {
                    int levelCount = BllModel.GetLevelForView(mkey, IsMBD);
                    if (levelCount > 0)
                    {
                        if (level + levelCount > memberModel.MAgencyType.ViewLevel)
                            level = memberModel.MAgencyType.ViewLevel - levelCount > level ? level : memberModel.MAgencyType.ViewLevel - levelCount;
                    }
                    else
                    {
                        mkey = memberModel.MID;
                    }
                }
            }
            return level;
        }
    }
}