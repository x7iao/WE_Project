using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.mobaopay.merchant;
using System.Text;
using WE_Project.Model;

namespace WE_Project.Web.Payment.MoBao
{
    public partial class Payment : BasePage
    {

        private HKModel HKModel
        {
            get
            {
                HKModel model = new HKModel();
                model.HKCreateDate = DateTime.Now;
                model.BankName = "";
                model.FromBank = Request.Form["yh"];
                model.HKDate = DateTime.Now;
                model.HKState = false;
                model.HKType = 1;
                model.MID = BllModel.TModel.MID;
                model.ValidMoney = Convert.ToDecimal(Request.Form["txtValidMoney"]);
                model.RealMoney = model.ValidMoney * BLL.MMMConfig.Model.ActiveCodePrice;
                model.ToBank = "";
                model.IsAuto = true;
                model.Sign = false;
                return model;
            }
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            Model.HKModel model = HKModel;
            try
            {
                if (model.ValidMoney < 50)
                {
                    model.RealMoney = model.ValidMoney * BLL.MMMConfig.Model.ActiveCodePrice;
                }
                else if (model.ValidMoney < 100)
                {
                    model.RealMoney = model.ValidMoney * 50;
                }
                else if (model.ValidMoney < 200)
                {
                    model.RealMoney = model.ValidMoney * 40;
                }
                else
                {
                    model.RealMoney = model.ValidMoney * 30;
                }
                model.RealMoney = model.ValidMoney * BLL.MMMConfig.Model.ActiveCodePrice;
                if (!BLL.HKModel.Insert(model))
                {
                    Response.Write("提交失败");
                    Response.End();
                    return;
                }
            }
            catch
            {
                return;
            }

            // 组织数据和签名
            Dictionary<string, string> payData = new Dictionary<string, string>();
            payData.Add("apiName", MobaopayConfig.Mobaopay_apiname_pay);
            payData.Add("apiVersion", MobaopayConfig.Mobaopay_api_version);
            payData.Add("platformID", MobaopayConfig.Platform_id);
            payData.Add("merchNo", MobaopayConfig.Merchant_acc);
            payData.Add("orderNo", model.HKCode);//订单号
            payData.Add("tradeDate", model.HKDate.ToString("yyyyMMdd"));//交易日期
            payData.Add("amt", model.RealMoney.ToString());//总金额
            payData.Add("merchUrl", MobaopayConfig.Merchant_notify_url);
            payData.Add("merchParam", "abcd");//商户参数
            payData.Add("tradeSummary", "充值");//交易摘要
            /**
             * bankCode为空，提交表单后浏览器在新窗口显示摩宝支付收银台页面，在这里可以通过账户余额支付或者选择银行支付；
             * bankCode不为空，取值只能是接口文档中列举的银行代码，提交表单后浏览器将在新窗口直接打开选中银行的支付页面。
             * 无论选择上面两种方式中的哪一种，支付成功后收到的通知都是同一接口。
             */
            payData.Add("bankCode", Request.Form["yh"]);

            string requestStr = MobaopayMerchant.Instance.generatePayRequest(payData);  // 组织签名源数据
            payData.Add("signMsg", MobaopaySignUtil.Instance.sign(requestStr));         // 生成签名数据

            // 生成表单并自动提交到支付网关。
            StringBuilder sbHtml = new StringBuilder();
            sbHtml.Append("<form id='mobaopaysubmit' name='mobaopaysubmit' action='" + MobaopayConfig.Mobaopay_gateway + "?' method='post'>");
            foreach (KeyValuePair<string, string> temp in payData)
            {
                sbHtml.Append("<input type='hidden' name='" + temp.Key + "' value='" + temp.Value + "'/>");
            }
            sbHtml.Append("</form>");
            sbHtml.Append("<script>document.forms['mobaopaysubmit'].submit();</script>");
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Write(sbHtml.ToString());
        }
    }
}