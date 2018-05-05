<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WE_Project.Web.tel.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>
		<%=WebModel.WebTitle %></title>
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge" />
	<link rel="stylesheet" href="css/style.css" />
	<script src="/Admin/jquery/jquery-1.8.3.min.js" type="text/javascript"></script>
	<script src="/Admin/pop/js/V5-UI.js" type="text/javascript"></script>
	<link href="/Admin/pop/css/V5-UI.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript">
		function Login() {
			if ($("#txtname").val() == "") {
				v5.error('会员账号不能为空', '1', 'true');
			} else if (pwd = $("#txtpwd").val() == "") {
				v5.error('密码不能为空', '1', 'true');
			} else {
				$.ajax({
					type: "post",
					url: "/Login.aspx?type=login",
					data: {
						txtname: $("#txtname").val(), txtpwd: $("#txtpwd").val(), checkCode: $("#checkCode").val(), href: window.location.href
					},
					async: true,
					success: function (data) {
						switch (data) {
							case "1":
								v5.error('用户名不存在', '1', 'true');
								break;
							case "2":
								v5.error('密码不正确', '1', 'true');
								break;
							case "3":
								v5.error('验证码错误', '1', 'true');
								$("#imgcode").click();
								break;
							case "-1":
								v5.error('限制登录', '1', 'true');
								break;
							case "0":
								window.location.href = "/Default.aspx";
								break;
							default:
								if (data)
									v5.error(data, '1', 'true');
								break;
						}
					}
				})
			}
			return false;
		}
		function keyLogin() {
			if (event.keyCode == 13)   //回车键的键值为13   
				Login();
		}
	</script>
</head>
<body>
	<div class="whole">
		<div class="logoBox">
			<img src="images/logo.png" />
		</div>
		<div class="information">
			<div class="user">
				<div class="inputBox">
					<input type="text" placeholder="请输入用户名" id="txtname" name="txtname" />
				</div>
			</div>
			<div class="password">
				<div class="inputBox">
					<input type="password" placeholder="请输入密码" id="txtpwd" name="txtpwd" />
				</div>
			</div>
			<div class="yzm">
				<div class="inputBox2">
					<input type="text" placeholder="验证码" id="checkCode" name="checkCode" />
				</div>
				<div class="yzm_imgages">
					<img alt="" src="/CheckCode.aspx" style="cursor: pointer;" onclick="this.src='/CheckCode.aspx?'+Math.random()" />
				</div>
			</div>
		</div>
		<div class="login_btn">
			<input type="button" value="登录" class="login" onclick="Login();" style="cursor: pointer" />
		</div>
	</div>
</body>
</html>
