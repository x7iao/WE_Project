<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WE_Project.Web.Manage.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=WebModel.WebTitle %></title>
    <link rel="Shortcut Icon" href="/Admin/images/fac.ico" />
    <script src="js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="/Admin/pop/js/ajax.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="css/base.css" media="all">
    <link rel="stylesheet" type="text/css" href="css/login.css" media="all">
    <link href="/Admin/pop/css/V5-UI.css" rel="stylesheet" type="text/css" />
    <script src="/Admin/pop/js/V5-UI.js" type="text/javascript"></script>
    <!--[if lt IE 9]>
		<script type="text/javascript" src="js/PIE.js"></script>
		<script language="javascript">
			$(function() {
			    if (window.PIE) {
			        $('.rounded').each(function() {
			            PIE.attach(this);
			        });
			    }
			});
		</script>
	<![endif]-->
    <script type="text/javascript">
        function Login() {
            if ($("#txtname").val() == "") {
                alert('用户不能为空');
            } else if (pwd = $("#txtpwd").val() == "") {
                alert('密码不能为空');
            } else {
                $.ajax({
                    type: "post",
                    url: "/Login.aspx?type=login",
                    data: { txtname: $("#txtname").val(), txtpwd: $("#txtpwd").val(), checkCode: $("#checkCode").val(), href: window.location.href
                    },
                    async: true,
                    success: function (data) {
                        switch (data) {
                            case "1":
                                v5.error('用户名不存在');
                                break;
                            case "2":
                                v5.error('密码不正确');
                                break;
                            case "3":
                                v5.error('验证码错误');
                                $("#imgcode").click();
                                break;
                            case "4":
                                v5.error('请先激活');
                                break;
                            case "-1":
                                v5.error('限制登录');
                                break;
                            case "0":
                                window.location.href = "/Default.aspx";
                                break;
                            default:
                                v5.error(data);
                                break;
                        }
                    }
                })
            }
        }

        function keyLogin() {
            if (event.keyCode == 13)   //回车键的键值为13   
                Login();
        }
        function reset() {
            $("#txtname").val("");
            $("#txtpwd").val("");
        }

        function OpenWindow(url, title, width, height) {
            var iTop = (window.screen.height - 30 - height) / 2; //获得窗口的垂直位置;
            var iLeft = (window.screen.width - 10 - width) / 2; //获得窗口的水平位置;
            window.open(url, title, 'height=' + height + ', width=' + width + ', top=' + iTop + ', left=' + iLeft + ', toolbar=no, menubar=no, scrollbars=no,resizable=no,location=no, status=no');
        }
    </script>
</head>
<body onkeydown="keyLogin();">
    <div id="main">
        <div class="box">
            <p>
            </p>
            <div class="foot">
                <%=WebModel.WCopyright%><span><%=WebModel.WCopyright%></span></div>
            <div class="login_from">
                <div class="title">
                    <span>登录</span>会员管理系统</div>
                <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="54">
                            账号
                        </td>
                        <td height="70" colspan="2" align="left" valign="middle">
                            <input class="input_style frsd" type="text" id="txtname" maxlength="20" value="admin">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            密码
                        </td>
                        <td height="70" colspan="2" align="left" valign="middle">
                            <input class="input_style frsd" type="password" id="txtpwd" maxlength="32" value="123">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            验证码
                        </td>
                        <td width="122" align="left" valign="middle">
                            <input maxlength="4" class="input_style thrd" type="text" id="checkCode" style="text-transform: uppercase;">
                        </td>
                        <td width="161" height="70" align="left" valign="middle">
                            <img id="imgcode" src="../CheckCode.aspx" onclick="this.src='../CheckCode.aspx?'+Math.random()"
                                style="cursor: pointer" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="center" valign="middle">
                            <a href="/SecurityCenter/Findpwd.aspx">忘记密码？</a>
                        </td>
                        <td height="70" align="center" valign="middle">
                            <input class="btn_ok" value="" type="button" onclick="Login();" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</body>
</html>
