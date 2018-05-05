using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WE_Project.Model;

namespace WE_Project.Web.SecurityCenter
{
    public partial class SecurityQuestion : BasePage
    {
        protected override void SetPowerZone()
        {
            BindRep();
        }

        protected void BindRep()
        {
            BLL.Sys_SecurityQuestion bll = new BLL.Sys_SecurityQuestion();
            rep_QuestionList.DataSource = bll.GetList(" 1=1 and IsDeleted=0 order by ID desc");
            rep_QuestionList.DataBind();
        }

        protected override string btnAdd_Click()
        {
            IList<Model.Sys_SecurityQuestion> list = GetDetailModelList();
            IList<Model.Sys_SecurityQuestion> listNew = new List<Model.Sys_SecurityQuestion>(); 
            foreach (Model.Sys_SecurityQuestion objNew in list)
            {
                Model.Sys_SecurityQuestion sq = objNew;
                if (objNew.ID == 0)
                {
                    sq.CreatedBy = TModel.MID;
                    sq.CreatedTime = DateTime.Now;
                    sq.Status = 1;
                }
                else
                {
                    sq = new BLL.Sys_SecurityQuestion().GetModel(objNew.ID);
                    sq.Question = objNew.Question;
                    sq.LastUpdateBy = TModel.MID;
                    sq.LastUpdateTime = DateTime.Now;
                }
                listNew.Add(sq);
            }
            //删除需要删除的
            string deleteId = Request.Form["hidDelIds"];
            if (!string.IsNullOrEmpty(deleteId))
            {
                string[] arr = deleteId.Split(',');
                foreach (string str in arr)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        Sys_SecurityQuestion sq = new BLL.Sys_SecurityQuestion().GetModel(str);
                        sq.IsDeleted = true;//执行逻辑删除
                        sq.LastUpdateBy = TModel.MID;
                        sq.LastUpdateTime = DateTime.Now;
                       // new BLL.Sys_SecurityQuestion().Delete(str);//不执行物理删除，
                        listNew.Add(sq);
                    }
                }
            }
            //更新或新增
            if (new BLL.Sys_SecurityQuestion().SaveOrUpdate(listNew) )
            {
                return "操作成功";
            }
            else
                return "操作失败";
        }

        public string[] EditTableKeysForTrain { get { return new string[] { "Ques", "hidId" }; } }

        protected IList<Model.Sys_SecurityQuestion> GetDetailModelList()
        {
            string[] arrRequest = Request.Form.AllKeys;
            IList<string> newDetailListTrain = new List<string>();
            IList<Model.Sys_SecurityQuestion> listSafe = new List<Model.Sys_SecurityQuestion>();
            foreach (string str in arrRequest)
            {
                var key = str.Split('_')[0];
                if (EditTableNeedSaveKeys(key, EditTableKeysForTrain))
                {
                    newDetailListTrain.Add(str);
                }

            }
            IList<string> strFlagsTrain = GetSetedGuid(newDetailListTrain);

            listSafe = AddToTotalModel(listSafe, AddListModel(strFlagsTrain, EditTableKeysForTrain));

            return listSafe;
        }
        protected IList<Model.Sys_SecurityQuestion> AddToTotalModel(IList<Model.Sys_SecurityQuestion> toAdd, IList<Model.Sys_SecurityQuestion> origin)
        {
            foreach (Model.Sys_SecurityQuestion obj in origin)
            {
                Model.Sys_SecurityQuestion newObj = obj;
                toAdd.Add(newObj);
            }
            return toAdd;
        }
       

        protected IList<Model.Sys_SecurityQuestion> AddListModel(IList<string> strFlags, string[] EditTableKeys)
        {
            IList<Model.Sys_SecurityQuestion> list = new List<Model.Sys_SecurityQuestion>();
            object id = null; string TicketName = "";
            foreach (string str in strFlags)
            {
                foreach (string sin in EditTableKeys)
                {
                    switch (sin)
                    {
                        case "hidId": id = Request.Form[sin + "_" + str]; break;
                        case "Ques":
                            if (Request.Form[sin + "_" + str] != null && !string.IsNullOrEmpty(Request.Form[sin + "_" + str]))
                                TicketName = Request.Form[sin + "_" + str];
                            break;
                    }
                }
                list.Add(NewEntity(id, TicketName));
            }
            return list;
        }
        private Model.Sys_SecurityQuestion NewEntity(object id, string question)
        {
            Model.Sys_SecurityQuestion obj = null;
            if (!string.IsNullOrEmpty(question))
            {
                obj = new Model.Sys_SecurityQuestion { ID = ToNullLong(id), Question = question };
            }
            return obj;
        }
 
    }
}