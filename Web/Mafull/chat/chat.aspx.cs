using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WE_Project.Web.Mafull.chat
{
    public partial class chat : BasePage
    {
        protected BLL.HelpChat chatBLL = new BLL.HelpChat();
        protected string code = "";
        protected List<Model.HelpChat> chatList = new List<Model.HelpChat>();
        protected override void SetValue(string id)
        {
            code = id;
            chatList = chatBLL.GetModelList(" MatchCode = '" + id + "' order by SendTime ");
        }

        protected override string btnAdd_Click()
        {
            string content = Request.Form["content"];
            string ccode = Request.Form["ccode"];
            string imgs = Request.Form["imgs"];
            Model.MHelpMatch match = BLL.MHelpMatch.GetModelByCode(ccode);
            Model.HelpChat model = new Model.HelpChat()
            {
                MatchCode = ccode,
                SendMID = TModel.MID,
                SendName = TModel.MName,
                SendTime = DateTime.Now,
                TContent = content,
                SendType = (match.OfferMID == TModel.MID ? 1 : 2),
                SendImages = imgs
            };
            if (chatBLL.Add(model))
            {
                return "1" + GetChatHtml(model);
            }
            else
            {
                return "0发送失败";
            }
        }

        private string GetChatHtml(Model.HelpChat model)
        {
            StringBuilder html = new StringBuilder();
            html.AppendFormat("<div class=\"chat_content\">");
            html.AppendFormat("<div class=\"msg_row\">");
            html.AppendFormat("{0}<span title=\"online\" class=\"user_online\">&nbsp;</span><br />", model.SendName);
            html.AppendFormat("<br />{0}<br />{1}", model.SendTime.ToString("dd.MM.yyyy HH:mm"), model.SendTypeStr);
            html.AppendFormat("</div>");
            html.AppendFormat("<div class=\"msg\">{0}{1}</div></div>", model.TContent, GetImgs(model.SendImages));
            return html.ToString();
        }

        private string GetImgs(string imges)
        {
            StringBuilder html = new StringBuilder();
            html.AppendFormat("<div style=\"padding-top: 10px; padding-bottom: 10px\">");
            foreach (string img in imges.Split('&'))
            {
                if (!string.IsNullOrEmpty(img))
                {
                    html.AppendFormat("<a target=\"_blank\" href=\"{0}\">", img);
                    html.AppendFormat("<img style=\"max-width: 100px; max-height: 100px; margin-right: 20px; margin-bottom: 20px; float: left;\" src=\"{0}\"></a>", img);
                }
            }
            html.AppendFormat("</div>");
            return html.ToString();
        }
    }
}