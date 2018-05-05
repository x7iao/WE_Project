<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WE_Project.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>
        <%=WebModel.WebTitle %></title>
    <link rel="Shortcut Icon" href="/Admin/images/fac.ico" />
    <link rel="shortcut icon" href="/Login/images/logo.ico" type="image/x-icon" />
    <link rel="stylesheet" href="/Login/css/bootstrap.min.css" />
    <link href="/Login/css/newIndex.css" rel="stylesheet" type="text/css" />
    <link href="/Login/css/tankuang.css" rel="stylesheet" type="text/css" />
    <link href="/Admin/pop/css/V5-UI.css" rel="stylesheet" type="text/css" />
    <script src="/Admin/jquery/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="/Admin/pop/js/V5-UI.js" type="text/javascript"></script>
    <script src="/Admin/pop/js/uaredirect.js" type="text/javascript"></script>
    <script type="text/javascript">        uaredirect("/tel/Login.aspx");</script>
    <script type="text/javascript">
        function Login() {
            if ($("#txtname").val() == "") {
                v5.error('用户名不能为空', '1', 'true');
            } else if (pwd = $("#txtpwd").val() == "") {
                v5.error('密码不能为空', '1', 'true');
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
                                v5.error('用户名不存在', '1', 'true');
                                break;
                            case "2":
                                v5.error('密码不正确', '1', 'true');
                                break;
                            case "3":
                                v5.error('验证码错误', '1', 'true');
                                $("#imgcode").click();
                                break;
                            case "4":
                                v5.error('请先激活', '1', 'true');
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
<body onkeydown="keyLogin();">
    <div class="newLogin91">
        <div class="newLogin91_newLoginBackground1" style="top: 78.5px;">
            <ul class="clearfix">
                <li>
                    <img src="/Login/images/logo.png" width="300px;" /></li>
            </ul>
            <div class="newLoginForm">
                <ol class="newLoginForm_user">
                    <li class="newLoginUser"><span></span>
                        <input style="outline: medium" type="text" name="txtname" id="txtname" placeholder="账号/邮箱">
                    </li>
                    <li class="newLoginPwd"><span></span>
                        <input style="outline: medium" type="password" name="txtpwd" id="txtpwd" placeholder="密码">
                    </li>
                </ol>
                <ol class="newLoginForm_code clearfix">
                    <li class="newLoginForm_codeNum"><span></span>
                        <input style="outline: medium" type="text" name="checkCode" id="checkCode" placeholder="验证码">
                    </li>
                    <li class="newLoginForm_codeImg floatRight">
                        <img src="/CheckCode.aspx" onclick="this.src='../CheckCode.aspx?'+Math.random()"
                            width="66px;" height="46px;">
                    </li>
                </ol>
                <ol class="newLoginForm_sub clearfix">
                    <li class="newLoginForm_sub1 floatLeft" id="btnSubmit" style="cursor: pointer;"><a
                        href="javascript:void(0)" onclick="Login()">登录</a></li>
                    <li><a class="remember" href="/SecurityCenter/Findpwd.aspx">忘记密码</a></li>
                </ol>
            </div>
        </div>
    </div>
</body>
</html>
