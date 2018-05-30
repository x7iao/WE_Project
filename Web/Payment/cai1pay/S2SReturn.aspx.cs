using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

namespace WE_Project.Web.Payment.cai1pay
{
    public partial class S2SReturn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //接收数据
            string resp_code = Request.Form["resp_code"];
            string resp_desc = Request.Form["resp_desc"];
            string cust_id = Request.Form["cust_id"];
            string ord_id = Request.Form["ord_id"];
            string trans_amt = Request.Form["trans_amt"];
            string notify_id = Request.Form["notify_id"];
            string check_value = Request.Form["check_value"];

            //签名原文（商户订单号+交易金额+交易时间+成功标志+IPS交易号+交易币种）<要按照这个先后顺序>
            string content = resp_code + resp_desc + cust_id + ord_id + trans_amt + notify_id+ check_value;

            //签名是否正确
            Boolean verify = false;

            //验证方式：12-md5
            if (resp_code == "000")
            {
                //Md5摘要（商户证书在商户后台可下载）
                //string merchant_key = "DoptoupEp2Vbz3nuRuYHk7NqLLfBHDPJTnL7hxqUHPhJ6JLmB62Izsjf1Z73pDWCDmhmIGm3eeauzeJcZTallhtBdFfiQMEdT5fuB94UtZEvsOGxp54vDL16S6icAdCr";
                ////string merchant_key = "MK3LaSgnNnb2qfZ6sDfP5wOZ3f6VsXm068Ieo3LNUps3qRfdMS2AMGLzW3rUwkUPaBVHwVrOSsUqeuJCa2j04BDQNsiLlQ1Ku23FWxGRBDI4L4vBKFUTb4vyXeUdM5Dc";
                //string signature1 = FormsAuthentication.HashPasswordForStoringInConfigFile(content + merchant_key, "MD5").ToLower();

                //if (signature1 == signature)
                {
                    verify = true;
                }

            }

            //判断签名验证是否通过
            if (verify == true)
            {
                //判断交易是否成功
                if (resp_code != "000")
                {
                    FileStream file = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\s2s.txt", FileMode.OpenOrCreate);
                    StreamWriter writer = new StreamWriter(file);
                    writer.WriteLine("交易失败！");
                    writer.Close();

                    //#############################################################
                    //以上代码仅作参考，此处可增加商户逻辑
                    //#############################################################
                }
                else
                {
                    FileStream file = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\s2s.txt", FileMode.OpenOrCreate);
                    StreamWriter writer = new StreamWriter(file);
                    writer.WriteLine("true");
                    writer.Close();

                    //#############################################################
                    //以上代码仅作参考，此处可增加商户逻辑
                    //#############################################################
                }
            }
            else
            {
                Response.Write("签名不正确！");
            }
        }
    }
}