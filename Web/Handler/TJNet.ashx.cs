using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;
using System.Web.SessionState;
using System.Web.Script.Serialization;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// TJNet 的摘要说明
    /// </summary>
    public class TJNet : BaseHandler
    {

        string tempMysb = string.Empty;
        string tempEmptysb = string.Empty;
        string tempkwsb = string.Empty;

        public override void ProcessRequest(HttpContext context)
        {
            //Net(context);
            Tree(context);
        }

        # region tree树形图谱

        private void Tree(HttpContext context)
        {
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            int level = 3;
            string mkey = memberModel.MID;

            if (!string.IsNullOrEmpty(context.Request["level"]))
            {
                level = int.Parse(context.Request["level"]);
            }
            if (!string.IsNullOrEmpty(context.Request["mkey"]))
            {
                mkey = context.Request["mkey"];
            }

            level = GetLevel(level, ref mkey, true);

            Model.Member tempmodel = BLL.Member.ManageMember.GetModel(mkey);
            string mbd = tempmodel.MTJ;

            if (!memberModel.Role.IsAdmin && mkey == memberModel.MID)
                mbd = "";
            List<Model.sys_Tree> tree = new List<Model.sys_Tree>();
            GetStructure(tempmodel, level, tree);

            JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            string strJson = "{\"data\":" + oSerializer.Serialize(tree) + "}";
            context.Response.Write(strJson);
        }

        private void GetStructure(Model.Member member, int level, List<Model.sys_Tree> tree)
        {
            tree.Add(GetTreeByMember(member));
            List<Model.Member> ListMember = BllModel.GetMemberEntityList(string.Format("MTJ='{0}' and MID<>'{0}' order by MDate", member.MID));
            if (level > 0)
            {
                for (int i = 0; i < ListMember.Count; i++)
                {
                    string colors = "";
                    colors = ListMember[i].MAgencyType.MColor;

                    GetStructure(ListMember[i], level - 1, tree);
                }
            }
        }

        private Model.sys_Tree GetTreeByMember(Model.Member member, bool isOpen = true, bool isCheck = false)
        {
            Model.sys_Tree tree = new Model.sys_Tree();
            if (member != null)
            {
                tree.id = member.MID;
                if (member.MID != member.MTJ)
                {
                    tree.pId = member.MTJ;
                }
                tree.name = GetDisplay(member);/// member.MID + member.Role.RName;
                tree.open = isOpen;
                tree.checke = isCheck;
            }
            return tree;
        }

        private string GetDisplay(Model.Member member)
        {
            string result = "";

            result = string.Format("<span>会员帐号：【<b style=\"color:{2};font-weight: bold;\">{0}</b>】</span><span>会员级别：【{1}】</span><span>团队人数：【<b style=\"color:red;font-weight: bold;\">{3}</b>】</span>", member.MID, member.MAgencyType.MAgencyName, member.MAgencyType.MColor, member.MConfig.YJCount);

            return result;
        }

        # endregion tree树形图谱

        # region Net图谱

        private void Net(HttpContext context)
        {
            StringBuilder tempsb = new StringBuilder();
            tempsb.Append("<li><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"tablefilter\"><tbody>");
            tempsb.Append("<tr align=\"center\" bgcolor=\"{3}\"><td colspan=\"2\" class=\"tdfilter\"><a href=\"javascript:void(0);\" onclick=\"GetAjaxTJInfo('{0}')\">{1}</a></td></tr>");
            //tempsb.Append("<tr align=\"center\"><td colspan=\"2\" class=\"tdfilter\"><table border=\"0\" cellspacing=\"1\" cellpadding=\"2\" width=\"100%\"><tbody>");
            tempsb.Append("<tr bgcolor=\"#C0C0C0\"><td colspan=\"3\">{2}{4}</td></tr>");
            //tempsb.Append("<tr bgcolor=\"#C0C0C0\"><td class=\"l\">推荐</td><td class=\"m\"></td><td class=\"r\">{4}</td></tr>");
            //tempsb.Append("<tr bgcolor=\"#C0C0C0\"><td class=\"l\">业绩</td><td class=\"m\"></td><td class=\"r\">{5}</td></tr>");
            tempsb.Append("</tbody></table></td></tr>");
            tempsb.Append("</tbody></table>");
            tempMysb = tempsb.ToString();
            tempEmptysb = "<li><table cellspacing=\"0\" cellpadding=\"0\" class=\"tablefilter\"><tbody><tr align=\"center\"><td valign=\"middle\" height=\"100%\"><a href=\"javascript:AddMember('{0}')\">[空位]<br/><br/>注册</a></td></tr></tbody></table>";
            tempkwsb = "<li><table cellspacing=\"0\" cellpadding=\"0\" class=\"tablefilter\"><tbody><tr align=\"center\"><td valign=\"middle\" height=\"100%\"><br>[空位]</td></tr></tbody></table>";
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            int level = 3;
            string mkey = memberModel.MID;

            if (!string.IsNullOrEmpty(context.Request["level"]))
            {
                level = int.Parse(context.Request["level"]);
            }
            if (!string.IsNullOrEmpty(context.Request["mkey"]))
            {
                mkey = context.Request["mkey"];
            }

            level = GetLevel(level, ref mkey, true);

            Model.Member tempmodel = BLL.Member.ManageMember.GetModel(mkey);
            string mbd = tempmodel.MTJ;

            if (!memberModel.Role.IsAdmin && mkey == memberModel.MID)
                mbd = "";
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(tempMysb, mbd, tempmodel.MID, tempmodel.MAgencyType.MAgencyName, tempmodel.MAgencyType.MColor, BLL.Member.GetOnlineInfo(tempmodel.MID)));
            GetStructure(tempmodel.MID, level, sb);
            sb.Append("</li>");
            context.Response.Write(Traditionalized(sb));
        }

        private void GetStructure(string mid, int level, StringBuilder sb)
        {
            List<Model.Member> ListMember = BllModel.GetMemberEntityList(string.Format("MTJ='{0}' and MID<>'{0}' order by MDate", mid));
            if (level > 0)
            {
                sb.Append("<ul>");
                for (int i = 0; i < ListMember.Count; i++)
                {
                    string colors = "";
                    //if (ListMember[i].MState)
                    //{
                    colors = ListMember[i].MAgencyType.MColor;
                    //}
                    //else
                    //{
                    //    colors = "#FF5151";
                    //}
                    sb.AppendFormat(tempMysb, ListMember[i].MID, ListMember[i].MID, ListMember[i].MAgencyType.MAgencyName, colors, BLL.Member.GetOnlineInfo(ListMember[i].MID));

                    GetStructure(ListMember[i].MID, level - 1, sb);
                    sb.Append("</li>");
                }
                sb.Append("</ul>");
            }
        }

        # endregion Net图谱

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