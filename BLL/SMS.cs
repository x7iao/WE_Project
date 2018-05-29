using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace WE_Project.BLL
{
    public class SMS
    {

        private static string SendMessage(string Url, string strMessage)
        {
            string strResponse;
            // 初始化WebClient 
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Accept", "*/*");
            webClient.Headers.Add("Accept-Language", "zh-cn");
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            try
            {
                byte[] responseData = webClient.UploadData(Url, "POST", Encoding.GetEncoding("GB2312").GetBytes(strMessage));
                string srcString = Encoding.GetEncoding("GB2312").GetString(responseData);
                strResponse = srcString;
            }
            catch
            {
                return "-1";
            }
            return strResponse;
        }

        private static bool SendSMS(string tel, string message)
        {
            string url = "http://www.gysoft.cn/smspost/send.aspx";
            string sendContent = "username=" + BLL.WebBase.Model.SMSName + "&password=" + BLL.WebBase.Model.SMSPassword +
                    "&mobile=" + tel + "&content=" + message;
            if (SendMessage(url, sendContent).ToUpper().Contains("OK"))
            {
                return true;
            }
            else {
                return false;
            }
            //StringBuilder sms = new StringBuilder();
            //sms.AppendFormat("name={0}", "13305236600");
            //sms.AppendFormat("&pwd={0}", "60FF407E0ED65888D6BEB3BF7189");//登陆平台，管理中心--基本资料--接口密码（28位密文）；复制使用即可。
            //sms.AppendFormat("&content={0}", message);
            //sms.AppendFormat("&mobile={0}", tel);
            //sms.AppendFormat("&sign={0}", "新浪社区");// 公司的简称或产品的简称都可以
            //sms.Append("&type=pt");
            //string resp = PushToWeb("http://web.cr6868.com/asmx/smsservice.aspx", sms.ToString(), Encoding.UTF8);
            //string[] msg = resp.Split(',');
            //if (msg[0] == "0")
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        private static string PushToWeb(string weburl, string data, Encoding encode)
        {
            byte[] byteArray = encode.GetBytes(data);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(weburl));
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = byteArray.Length;
            Stream newStream = webRequest.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);
            newStream.Close();

            //接收返回信息：
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            StreamReader aspx = new StreamReader(response.GetResponseStream(), encode);
            return aspx.ReadToEnd();
        }

        public static string ShengYu()
        {

            string url = "http://www.gysoft.cn/smspost/havenum.aspx";

            //UTF-8
            //string url = "http://www.gysoft.cn/smspost_utf8/havenum.aspx";
            string sendContent = "username=" + BLL.WebBase.Model.SMSName + "&password=" + BLL.WebBase.Model.SMSPassword;
            return SendMessage(url, sendContent) + " 条";
        }

        public static Model.SMS GetModel(object obj)
        {
            return DAL.SMS.GetModel(obj);
        }

        private static bool TimeVerify(string tel, Model.SMSType type, int time)
        {
            List<Model.SMS> list = BLL.SMS.GetList(string.Format("Tel='{0}' and SType='{1}' order by SID desc", tel, type));
            if (list.Count > 0)
            {
                if ((DateTime.Now - list[0].CreateDate).TotalSeconds > time)
                    return true;
                return false;
            }
            return true;
        }

        public static string GetSKeyBuyTel(string tel, Model.SMSType type)
        {
            DateTime date = DateTime.Now.AddSeconds(-BLL.Configuration.CodeTime[type.ToString()] * 10);
            List<Model.SMS> list = BLL.SMS.GetList(string.Format("Tel='{0}' and SType='{1}' and SendState='1' and CreateDate>'{2}' order by SID desc", tel, type, date));
            if (list.Count > 0)
                return list[0].SMSKey;
            return "";
        }

        public static string GetSKeyBuyEmail(string email, Model.SMSType type)
        {
            DateTime date = DateTime.Now.AddSeconds(-BLL.Configuration.CodeTime[type.ToString()]);
            List<Model.SMS> list = BLL.SMS.GetList(string.Format("Email='{0}' and SType='{1}' and SendState='1' and CreateDate>'{2}' order by SID desc", email, type, date));
            if (list.Count > 0)
                return list[0].SMSKey;
            return "";
        }

        public static bool Insert(Model.SMS model, ref string error)
        {
            try
            {
                model.SendState = false;
                model.CreateDate = DateTime.Now;
                //model.SContent += "[" + BLL.WebBase.Model.SMSTitle + "]";
                if (BLL.WebBase.Model.SMSState && !string.IsNullOrEmpty(model.Tel))
                {
                    if (TimeVerify(model.Tel, model.SType, BLL.Configuration.CodeTime[model.SType.ToString()]))
                    {
                        //if (DAL.SMS.GetDayCount(DateTime.Now) <= DAL.WebBase.Model.SMSMinCount)
                        //{
                        string dian = @"^(13+\d{9})|(15+\d{9})|(18+\d{9})|(17+\d{9})|(14+\d{9})|(19+\d{9})$";
                        Regex regex = new Regex(dian);
                        if (regex.IsMatch(model.Tel))
                        {
                            model.SendState = SendSMS(model.Tel, model.SContent);
                            if (model.SendState)
                            {
                                DAL.SMS.Insert(model);
                            }
                            else
                            {
                                error = "短信发送失败,请稍后重试";
                            }
                        }
                        else
                        {
                            model.SendState = false;
                            error += "手机号格式不正确";
                        }
                        //}
                        //else
                        //{
                        //    error += "今日短信已用完";
                        //}
                    }
                    else
                    {
                        error += "请等待" + (BLL.Configuration.CodeTime[model.SType.ToString()]) + "秒后，才可以重新接收手机短信";
                    }
                }
                else
                {
                    error += "短信功能已关闭!";
                }
                return model.SendState;
            }
            catch (Exception ex)
            {
                error += ex.ToString();
                return false;
            }
        }

        public static System.Collections.Hashtable Insert(Model.SMS model, System.Collections.Hashtable MyHs)
        {
            model.SendState = SendSMS(model.Tel, model.SContent);
            model.CreateDate = DateTime.Now;
            return DAL.SMS.Insert(model, MyHs);
        }

        public static System.Collections.Hashtable Update(Model.SMS model, System.Collections.Hashtable MyHs)
        {
            return DAL.SMS.Update(model, MyHs);
        }

        public static bool Update(Model.SMS model)
        {
            return DAL.SMS.Update(model);
        }

        public static System.Collections.Hashtable Delete(object obj, System.Collections.Hashtable MyHs)
        {
            return DAL.SMS.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return DAL.SMS.Delete(obj);
        }

        public static System.Data.DataTable GetTable(string strWhere)
        {
            return DAL.SMS.GetTable(strWhere);
        }

        public static System.Data.DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.SMS.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.SMS> GetList(string strWhere)
        {
            return DAL.SMS.GetList(strWhere);
        }

        public static List<Model.SMS> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.SMS.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
