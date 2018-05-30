using System;
using System.Web;
using WE_Project.Model;

namespace WE_Project.Web.Payment.cai1pay
{
    public partial class redirect : BasePage
    {
        private HKModel HKModel
        {
            get
            {
                HKModel model = new HKModel();
                model.HKCreateDate = DateTime.Now;
                model.BankName = "";
                model.FromBank = "DSHPay";
                model.MID = TModel.MID;
                model.RealMoney = decimal.Parse(Request.QueryString["txtValidMoney"]);
                //model.ValidMoney = decimal.Parse(Request.QueryString["txtValidMoney"]);
                model.HKDate = DateTime.Now;
                model.HKState = false;
                model.HKType = int.Parse(Request.QueryString["CZType"]);
                model.ToBank = "";
                model.IsAuto = true;
                model.Sign = false;
                return model;
            }
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            HKModel hkModel = HKModel;

            decimal basemoney = 0;
            decimal minmoney = 0;
            decimal czbase = 0;

            if (hkModel.HKType == 1)//
            {
                basemoney = 100;
                minmoney = 100;
                czbase = 1;
            }
            else if (hkModel.HKType == 2)
            {
                basemoney = 200;
                minmoney = 200;
                czbase = 200;
            }
            else {
                Response.Write("支付类型不存在");
                Response.End();
            }

            if (hkModel.RealMoney % basemoney != 0)
            {
                Response.Write("汇款倍数有误");
                Response.End();
            }
            if (hkModel.RealMoney < minmoney)
            {
                Response.Write("汇款金额不能低于" + minmoney);
                Response.End();
            }

            hkModel.ValidMoney = hkModel.RealMoney / czbase;


            BLL.HKModel.Insert(hkModel);
            //提交地址
            string form_url = "http://pay.danbaoshop.cn:9876/netrecv/merchant/bMerUnionPay";
           
            //版本号
            string version = "01";

            //交易账户号
            string cust_id = "4001243573";

            //商户订单编号
            string ord_id = hkModel.HKCode;

            //商品名称
            string subject = "we";
            //支付渠道
            string gate_id = "1008";

            //订单金额(保留2位小数)
            string trans_amt = hkModel.RealMoney.ToString("F2");

            //支付结果成功返回的商户URL
            string url = "http://" + HttpContext.Current.Request.Url.Authority.ToString();
            //Server to Server 同步地址
            string ret_url = url + "/Payment/cai1pay/S2SReturn.aspx";
            //异步地址
            string bg_ret_url = url + "/Payment/cai1pay/OrderReturn.aspx";
            //商户证书
            string mac_key = "";
            //签名()
            string check_value = "";

            //订单支付接口的Md5摘要，原文=订单号+金额+日期+支付币种+商户证书 
            string SignMD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(version + cust_id + ord_id + subject+ gate_id+ trans_amt+ ret_url+ bg_ret_url + mac_key, "MD5").ToLower();
            check_value = SignMD5;

            string postForm = "<form name=\"frm1\" id=\"frm1\" method=\"post\" action=\"" + form_url + "\">";
            postForm += "<input type=\"hidden\" name=\"version\" value=\"" + version + "\" />";
            postForm += "<input type=\"hidden\" name=\"cust_id\" value=\"" + cust_id + "\" />";
            postForm += "<input type=\"hidden\" name=\"ord_id\" value=\"" + ord_id + "\" />";
            postForm += "<input type=\"hidden\" name=\"subject\" value=\"" + subject + "\" />";
            postForm += "<input type=\"hidden\" name=\"gate_id\" value=\"" + gate_id + "\" />";
            postForm += "<input type=\"hidden\" name=\"trans_amt\" value=\"" + trans_amt + "\" />";
            postForm += "<input type=\"hidden\" name=\"ret_url\" value=\"" + ret_url + "\" />";
            postForm += "<input type=\"hidden\" name=\"bg_ret_url\" value=\"" + bg_ret_url + "\" />";
            postForm += "<input type=\"hidden\" name=\"check_value\" value=\"" + check_value + "\" />";
            postForm += "</form>";

            //自动提交该表单到测试网关
            postForm += "<script type=\"text/javascript\" language=\"javascript\">setTimeout(\"document.getElementById('frm1').submit();\",100);</script>";

            Response.Write(postForm);
        }
        
    }
}