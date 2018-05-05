/**  版本信息模板在安装目录下，可自行修改。
* HelpChat.cs
*
* 功 能： N/A
* 类 名： HelpChat
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/4/18 11:01:37   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace WE_Project.Model
{
    /// <summary>
    /// HelpChat:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class HelpChat
    {
        public HelpChat()
        { }
        #region Model
        private int _id;
        private string _matchcode;
        private string _sendmid;
        private string _sendname;
        private string _tcontent;
        private DateTime _sendtime;
        private int _sendtype;
        private string _sendimages;
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 匹配编号
        /// </summary>
        public string MatchCode
        {
            set { _matchcode = value; }
            get { return _matchcode; }
        }
        /// <summary>
        /// 发送人MID
        /// </summary>
        public string SendMID
        {
            set { _sendmid = value; }
            get { return _sendmid; }
        }
        /// <summary>
        /// 发送人姓名
        /// </summary>
        public string SendName
        {
            set { _sendname = value; }
            get { return _sendname; }
        }
        /// <summary>
        /// 发送内容
        /// </summary>
        public string TContent
        {
            set { _tcontent = value; }
            get { return _tcontent; }
        }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendTime
        {
            set { _sendtime = value; }
            get { return _sendtime; }
        }
        /// <summary>
        /// 发送类型
        /// </summary>
        public int SendType
        {
            set { _sendtype = value; }
            get { return _sendtype; }
        }
        /// <summary>
        /// 发送类型
        /// </summary>
        public string SendTypeStr
        {
            get
            {
                if (SendType == 1)
                {
                    return "发款人";
                }
                else
                {
                    return "收件人";
                }
            }
        }
        /// <summary>
        /// 发送的图片
        /// </summary>
        public string SendImages
        {
            set { _sendimages = value; }
            get { return _sendimages; }
        }
        #endregion Model

    }
}

