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
    /// TJTree 的摘要说明
    /// </summary>
    public class TJTree : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            string mkey = memberModel.MID;
            bool isStructure = false;

            if (!string.IsNullOrEmpty(context.Request["id"]))//非查询
            {
                mkey = context.Request["id"];
                isStructure = true;
            }
            else
            {
                if (!string.IsNullOrEmpty(context.Request["serachId"]))//查询
                {
                    if (memberModel.Role.IsAdmin)
                    {
                        isStructure = false;
                        mkey = context.Request["serachId"];
                    }
                }
            }

            List<Model.sys_Tree> tree = new List<Model.sys_Tree>();
            if (isStructure)
            {
                GetStructure(mkey, tree);
            }
            else
            {
                Model.Member tempmodel = BLL.Member.ManageMember.GetModel(mkey);
                tree.Add(GetTreeByMember(tempmodel, isParent(tempmodel.MID), true));
                //GetStructure(tempmodel.MID, tree);//默认两层
            }

            JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            string strJson = oSerializer.Serialize(tree);
            context.Response.Write(strJson);
        }

        private void GetStructure(string mid, List<Model.sys_Tree> tree)
        {
            List<Model.Member> ListMember = BllModel.GetMemberEntityList(string.Format("MTJ='{0}' and MID<>'{0}' order by MDate", mid));
            for (int i = 0; i < ListMember.Count; i++)
            {
                //string colors = "";
                //colors = ListMember[i].MAgencyType.MColor;
                //bool parent = isParent(ListMember[i].MID);
                tree.Add(GetTreeByMember(ListMember[i], isParent(ListMember[i].MID)));
            }
        }

        private bool isParent(string mid)
        {
            List<Model.Member> ListMember = BllModel.GetMemberEntityList(string.Format("MTJ='{0}' and MID<>'{0}' order by MDate", mid));
            if (ListMember != null && ListMember.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Model.sys_Tree GetTreeByMember(Model.Member member, bool isparent = false, bool isOpen = false, bool isCheck = false)
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
                tree.isParent = isparent;
            }
            return tree;
        }

        private string GetDisplay(Model.Member member)
        {
            string result = "";

            result = string.Format("<span>会员帐号：【<b style=\"color:{2};font-weight: bold;\">{0}</b>】</span><span>会员级别：【{1}】</span><span>团队人数：【<b style=\"color:red;font-weight: bold;\">{3}</b>】</span>", member.MID, member.MAgencyType.MAgencyName, member.MAgencyType.MColor, member.MConfig.YJCount);

            return result;
        }
    }
}