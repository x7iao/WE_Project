using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Message
{
    public partial class TaskView : BasePage
    {
        protected bool isReply = false;
        protected override void SetPowerZone()
        {

        }

        protected override void SetValue(string id)
        {
            Model.Task yask = BLL.Task.GetModel(id);
            if (yask != null)
            {
                BLL.Task.ReadTask(yask.ID.ToString());
                spSendMan.InnerHtml = yask.TFromMID;
                spContent.InnerHtml = yask.TContent;
                spdate.InnerHtml = yask.TDataStr;
                spTaskType.InnerHtml = yask.TTypeStr;
                string picurl = yask.PicURL;
                if (!string.IsNullOrEmpty(picurl))
                {
                    string resu = string.Empty;
                    string[] array = yask.PicURL.Split(',');
                    foreach (string str in array)
                    {
                        resu += "<div class='appDiv'><img class='appImg' src='" + str + "'/></div>";
                    }
                    tablePic1.InnerHtml = resu;
                }

                Model.Task reply = BllModel.GetReplyTask(yask.ID);
                if (reply != null)
                {
                    //BLL.Task.ReadTask(yask.ID.ToString());
                    isReply = true;
                    RespSendMan.InnerHtml = reply.TFromMID;
                    RespContent.InnerHtml = reply.TContent;
                    Respdate.InnerHtml = reply.TDataStr;
                    RespTaskType.InnerHtml = reply.TTypeStr;
                    string picur2 = reply.PicURL;
                    if (!string.IsNullOrEmpty(picur2))
                    {
                        string resu = string.Empty;
                        string[] array = reply.PicURL.Split(',');
                        foreach (string str in array)
                        {
                            resu += "<div class='appDiv'><img class='appImg' src='" + str + "'/></div>";
                        }
                        RetablePic1.InnerHtml = resu;
                    }
                }

            }
        }
    }
}