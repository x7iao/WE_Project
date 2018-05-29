using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WE_Project.Model;

namespace WE_Project.Web.Payment.AliPay
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
                model.FromBank ="AliPay";
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
            //orderOID--订单ID，不重复的订单编号
            //orderName--订单名称
            //payMoney--支付金额
            //note--说明
            //WIDquitUrl--支付中途退出返回商户网站地址
            //ReturnUrl--支付完成同步回掉的页面
            //NotifyUrl--支付宝异步回掉接口--必须保证外网能访问

            //支付宝支付回掉域名(只要域名，不带http)
            string _AliPayNotifyHostPoint = "wefamily.me";


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
            if(hkModel.RealMoney<minmoney)
            {
                Response.Write("汇款金额不能低于"+minmoney);
                Response.End();
            }

            hkModel.ValidMoney = hkModel.RealMoney / czbase;

            BLL.HKModel.Insert(hkModel);
            try
            {
                DefaultAopClient client = new DefaultAopClient("https://openapi.alipay.com/gateway.do", config.app_id, config.private_key, "json", "1.0", "RSA2", _AliPayNotifyHostPoint, "UTF-8", false);
                // 外部订单号，商户网站订单系统中唯一的订单号
                string out_trade_no = hkModel.HKCode;

                // 订单名称
                string subject = "WE支付";

                // 付款金额
                string total_amout =hkModel.RealMoney.ToString();

                // 商品描述
                string body = "商品描述";

                // 支付中途退出返回商户网站地址
                string quit_url = "https://wefamily.me/";

                // 组装业务参数model
                AlipayTradeWapPayModel model = new AlipayTradeWapPayModel();
                model.Body = body;
                model.Subject = subject;
                model.TotalAmount = total_amout;
                model.OutTradeNo = out_trade_no;
                model.ProductCode = "QUICK_WAP_WAY";
                model.QuitUrl = quit_url;

                AlipayTradeWapPayRequest request = new AlipayTradeWapPayRequest();
                // 设置支付完成同步回调地址
                string url = "http://" + HttpContext.Current.Request.Url.Authority.ToString();
                string Merchanturl = url + "/Payment/AliPay/TBReturn.aspx";
                request.SetReturnUrl(Merchanturl);
                // 设置支付完成异步通知接收地址
                string Merchanturl2 = url + "/Payment/AliPay/YBReturn.aspx";
                request.SetNotifyUrl(Merchanturl2);
                // 将业务model载入到request
                request.SetBizModel(model);

                AlipayTradeWapPayResponse response = null;
                try
                {
                    response = client.pageExecute(request, null, "post");
                    //return response.Body;  //拼接好的form标签，页面直接submit这个标签就可以了
                    Response.Write(response.Body);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Response.Write(postForm);
        }
    }
}