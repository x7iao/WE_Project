<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="c#" runat="server">
 
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string name = Request.QueryString["name"];
                string email = Request.QueryString["email"];
                string tel = Request.QueryString["tel"];
                string suggest = Request.QueryString["suggest"];

                string context = "留言内容:姓名:" + name + "；邮箱:" + email + "；电话:" + tel + "；留言内容:" + suggest;
                if (LeaveMsg(context))
                    Response.Write("accepJson([{id:1}])");
                //Response.Write("accepJson([{id:1,name:'" + "留言内容:姓名:" + name + ";邮箱:" + email + ";电话:" + tel + ";留言内容:" + suggest + "',age:432}])");
                else
                    Response.Write("accepJson([{id:0}])");
                Response.End();

                //lb_Ip.Text = GetUserIp();
            }
        }

        private bool LeaveMsg(string text)
        {
            string path = "E:\\YGMessage.txt";
            if (!System.IO.File.Exists(path))
            {
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                //创建文件   
                System.IO.FileStream fs = file.Create();
                //关闭文件流   
                fs.Close();
            }
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path, true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "~" + text);
            }
            return true;
        }

        public string GetUserIp()
        {
            string userIP = "未获取用户IP";
            try
            {
                if (HttpContext.Current == null || HttpContext.Current.Request == null || HttpContext.Current.Request.ServerVariables == null)
                    return "";
                string CustomerIP = "";
                //CDN加速后取到的IP  
                CustomerIP = HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
                if (!string.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }
                CustomerIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!String.IsNullOrEmpty(CustomerIP))
                    return CustomerIP;
                if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    CustomerIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (CustomerIP == null)
                        CustomerIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                else
                {
                    CustomerIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                if (string.Compare(CustomerIP, "unknown", true) == 0)
                    return HttpContext.Current.Request.UserHostAddress;
                return CustomerIP;
            }
            catch { }
            return userIP;
        }


        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN：该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        您的IP地址是:
        <asp:Label ID="lb_Ip" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
