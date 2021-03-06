﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace WE_Project.Web.Admin
{
	/// <summary>
	/// Summary description for Handler1
	/// </summary>
	public class UploadImage : IHttpHandler
	{
		private static JavaScriptSerializer jss = new JavaScriptSerializer();

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/html";
			try
			{
				//获取当前Post过来的file集合对象,在这里我只获取了<input type='file' name='fileUp'/>的文件控件
				HttpPostedFile file = context.Request.Files["upload"];
				if (file != null)
				{
					//当前文件上传的目录
					//string path = context.Server.MapPath("~/images/upload/");
					////当前待上传的服务端路径
					//string imageUrl = path + Path.GetFileName(file.FileName);
					//当前文件后缀名
					string ext = Path.GetExtension(file.FileName).ToLower();
					//验证文件类型是否正确
					if (!ext.Equals(".gif") && !ext.Equals(".jpg") && !ext.Equals(".png") && !ext.Equals(".bmp"))
					{
						//这里window.parent.uploadSuccess()是我在前端页面中写好的javascript function,此方法主要用于输出异常和上传成功后的图片地址
						throw new Exception("你上传的文件格式不正确！上传格式有(.gif、.jpg、.png、.bmp)");
					}
					//验证文件的大小
					if (file.ContentLength > 4194304)
					{
						//这里window.parent.uploadSuccess()是我在前端页面中写好的javascript function,此方法主要用于输出异常和上传成功后的图片地址 
						throw new Exception("你上传的文件不能大于4MB!请重新上传！");
					}
					string filepath = "/plugin/layui/images/";
					if (Directory.Exists(context.Server.MapPath(filepath)) == false)//如果不存在就创建file文件夹
					{
						Directory.CreateDirectory(context.Server.MapPath(filepath));
					}
					string virpath = filepath + CreatePasswordHash(file.FileName, 4) + ext;//这是存到服务器上的虚拟路径
					string mappath = context.Server.MapPath(virpath);//转换成服务器上的物理路径
					file.SaveAs(mappath);//保存图片

					//string virpath = path + CreatePasswordHash(imageUrl, 4) + ext;//这是存到服务器上的虚拟路径
					////开始上传
					//file.SaveAs(virpath);
					//这里window.parent.uploadSuccess()是我在前端页面中写好的javascript function,此方法主要用于输出异常和上传成功后的图片地址
					//如果成功返回的数据是需要返回两个字符串，我在这里使用了|分隔  例： 成功信息|/Test/hello.jpg
					//string url = "http://" + HttpContext.Current.Request.Url.Authority.ToString();

					//context.Response.Write("<script>window.parent.uploadSuccess('上传成功!|" + virpath + "');</script>");

					context.Response.Write(jss.Serialize(new { isSuccess = true, msg = virpath }));

					//var callback = context.Request.To<string>("CKEditorFuncNum");
					//context.Response.Write($@"<script type=""text/javascript"" >");
					//context.Response.Write($@"window.parent.CKEDITOR.tools.callFunction('{callback}','{virpath}','');");
					//context.Response.Write($@"</script>");
					//context.Response.End();
				}
				else
				{
					//上传失败
					context.Response.Write(jss.Serialize(new { isSuccess = false, msg = "上传失败" }));
					//context.Response.Write($"<script>alert('上传失败');</script>");
					//context.Response.End();
				}
			}
			catch (Exception ex)
			{
				context.Response.Write(jss.Serialize(new { isSuccess = false, msg = ex.Message }));
			}
		}
		/// <summary>
		/// 创建一个指定长度的随机alt值
		/// </summary>
		public string CreateSalt(int saltLenght)
		{
			//生成一个加密的随机数
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
			byte[] buff = new byte[saltLenght];
			rng.GetBytes(buff);
			//返回一个Base64随机数的字符串
			return Convert.ToBase64String(buff);
		}
		/// <summary>
		/// 返回加密后的字符串
		/// </summary>
		public string CreatePasswordHash(string pwd, int saltLenght)
		{
			string strSalt = CreateSalt(saltLenght);
			//把密码和Salt连起来
			string saltAndPwd = String.Concat(pwd, strSalt);
			//对密码进行哈希
			string hashenPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "sha1");
			//转为小写字符并截取前16个字符串
			hashenPwd = hashenPwd.ToLower().Substring(0, 16);
			//返回哈希后的值
			return hashenPwd;
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}