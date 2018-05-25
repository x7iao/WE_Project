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
                int type = 1;


                HKModel model = new HKModel();
                model.HKCreateDate = DateTime.Now;
                model.BankName = "";
                model.FromBank ="1";
                model.MID = TModel.MID;
                model.RealMoney = decimal.Parse(Request.QueryString["txtValidMoney"]);
                model.ValidMoney = decimal.Parse(Request.QueryString["txtValidMoney"]);
                model.HKDate = DateTime.Now;
                model.HKState = false;
                model.HKType = type;
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
            BLL.HKModel.Insert(hkModel);
            try
            {
                string _app_id = "2018040502507600";  //app_id
                string _private_key = "MIIEpAIBAAKCAQEAqmJXV7QNugFnk8PDj3RMM9m4YhIeCUf3mSn3g4qGjsIkjQ/fh8fV4Jqj5CnUsHOf99YRXpTJnkST3g8OffWqjtQ/uWn5uX22PW2ZhPuI99dvlsUyNDtX6KLoqRiDbtWIORgNL/M5DXbct0hqkvWQ89VBTTvtKDh0YELrVVUz2wstrcJc4jsFhbvC3QFrnbfIyM3pLOfAPW8HHOr1SNra628skBAZ7dpPAP6pCTZKHpiFA15edXI2VVuWgKwh1C32tNT8uqRI6VeLa3nqiCkt9tmQcd4ACF7bHi5etUTewl42IZmjdFKMp0kBRjuvrmU5zC2m0brNOv5CTd8ucLqnUwIDAQABAoIBADcVEc2NrP5cI+MWX6uJ2nTMxxoVZ1ZyyK3gbl89MmEGjJB5+DbKOO+irqc9ir/8sVOLBhSAn2mmG/OnBHVeLWR9Y5iKlSwNYxQa0Y23T8FoCXBBkghmwvW3bOX1wc/cAm0KxICi7efXbGVoaOPXtaPOZo0UeYgOMDlKiRAOOnRucmaPp+ixifyPk7l1cBg/TUFlNx9FT6DofrGkjNdHwLnHfXxX9tJVwb2lmsBb96SS82qlVj6DvliPtMrwjAZiRiuAYvGcp4fmyzseX0GWWJ49gritiJPsvT4+Dn5lYxLpb3ySnPfQKIV+zu2aIorXIpr7Dt4AiaUuoSTc/1pXtYECgYEA3qhnbkCrv6jNqJn+Yp3RG4s3uYdAvFpmNQTODjv2iv927GXz+Po1E+sCmxX89X4TSCycG7B6Ja5WvoJDLr4XFIGpRDrApNMIQqcaMvU534pmp8qY6v+MtsqZIpgqnXoczbw2gFmyjxcyQqa9Mwn8meLLshEjQweTrEd2EB+fXEECgYEAw+YGC1Le2siHAgwX2/6jwXJiFy96AfaI5FZyDo0k+s2zEqyo8+QcqDatO6j6YPUFXVjC82xEywPc90fYeZgAO8wSquHWgVFnNO2U0RsHcglwr56zM9QDzO5ltDZI46X9A41eSQ0aShNp5+3vdceJmwRFZ/MkT0apO1lhzkBlLpMCgYAkh3xwmiuTRh53iswxYbLs0epShd4ZCLu79w3XR/8qzr60CgX80w/iNKw4xWK64/RF4wu5fzqK9A9HMhfTk1w2AQ/EId95KyYvyTqDIbhc9FfjL1nnNAXh91soUc6sB1yyZC6M4CprT2LvjGt99CV9GbhRfn5KgPO5UAAOpSGAAQKBgQC0ydoWJTqp6po+F28FhnEWHDvObfBJU35uTCEisLvKAoAa4eFig8i2rQ8emgnH5Rg4V6xC/k5WlZAdXd64CMFebi1kKtvNqJR40jGe8TTj1zZ5vRpg4G9Jd1HBCMAn544i8xpqjH8Qke4RLxLpPWcO+tga4NdHmkygCxMqR1+ZpQKBgQDZsqTYiAL64uv63xqD4vioWx7jZfm96Nsz9jMv0UHNvmH2benE/OWBYdjlyIDTxwiIqV6xekm7lWxnMPSyB2TlM0xFYWQYHHpLNm+WlVwSVGSoqGeow033vsf4Sve5yhIhY5JNDkvps1VxqvEcuLc9r7wyjUCajwJ6tw/Gm/hN1A==";  //私钥
                string _alipay_public_key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAqmJXV7QNugFnk8PDj3RMM9m4YhIeCUf3mSn3g4qGjsIkjQ/fh8fV4Jqj5CnUsHOf99YRXpTJnkST3g8OffWqjtQ/uWn5uX22PW2ZhPuI99dvlsUyNDtX6KLoqRiDbtWIORgNL/M5DXbct0hqkvWQ89VBTTvtKDh0YELrVVUz2wstrcJc4jsFhbvC3QFrnbfIyM3pLOfAPW8HHOr1SNra628skBAZ7dpPAP6pCTZKHpiFA15edXI2VVuWgKwh1C32tNT8uqRI6VeLa3nqiCkt9tmQcd4ACF7bHi5etUTewl42IZmjdFKMp0kBRjuvrmU5zC2m0brNOv5CTd8ucLqnUwIDAQAB";  //公钥


                DefaultAopClient client = new DefaultAopClient("https://openapi.alipay.com/gateway.do", _app_id, _private_key, "json", "1.0", "RSA2", _AliPayNotifyHostPoint, "UTF-8", false);

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