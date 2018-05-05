using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;

namespace WE_Project.BLL
{
    public static class Msg
    {
        /// 发送短信
        /// </summary>
        /// <param name="mobile">短信接收人</param>
        /// <param name="message">短信内容</param>
        /// <returns></returns>
        public static string SendMessage(string Url, string strMessage)
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
    }
}
