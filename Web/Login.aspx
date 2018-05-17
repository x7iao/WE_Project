<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WE_Project.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<!--[if IE 9 ]><html class="ie9"><![endif]-->
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <meta name="format-detection" content="telephone=no">
    <meta charset="UTF-8">

    <meta name="description" content="Violate Responsive Admin Template">
    <meta name="keywords" content="Super Admin, Admin, Template, Bootstrap">

    <title><%=WebModel.WebTitle %></title>

    <!-- CSS -->
    <link href="/Admin/css/bootstrap.min.css" rel="stylesheet">
    <link href="/Admin/css/style.css" rel="stylesheet">
    <link href="/Admin/css/form.css" rel="stylesheet">
    <link href="/Admin/css/animate.css" rel="stylesheet">
    <link href="/Admin/css/generics.css" rel="stylesheet">


    <link href="/Admin/pop/css/V5-UI.css" rel="stylesheet" type="text/css" />
    <script src="/Admin/pop/js/jquery-1.8.3.min.js"></script>
    <script src="/Admin/pop/js/V5-UI.js" type="text/javascript"></script>
    <script src="/Admin/pop/js/uaredirect.js" type="text/javascript"></script>
    <%--<script type="text/javascript">        uaredirect("/tel/Login.aspx");</script>--%>
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
<body id="skin-blur-violate" onkeydown="keyLogin();">
    <section id="login">
            <header>
                <h1>WE</h1>
                <p>任何使用本网站系统的用户均应仔细阅读本声明，用户可选择不使用本网站系统，用户使用本网站系统的行为将被视为对本声明全部内容的认可。</p>
            </header>
        
            <div class="clearfix"></div>
            
            <!-- Login -->
            <form class="box tile animated active" id="box-login">
                <h2 class="m-t-0 m-b-15">登陆</h2>
                <input type="text" class="login-control m-b-10" name="txtname" id="txtname" placeholder="Username">
                <input type="password" class="login-control"  name="txtpwd" id="txtpwd" placeholder="Password">
                <input type="test" class="login-control"  name="checkCode" id="checkCode" placeholder="验证码" style="margin-top:12px; width:70%;">
                 <img src="/CheckCode.aspx" onclick="this.src='../CheckCode.aspx?'+Math.random()" width="66px;" height="28px;">
                <br />
               <%-- <div class="checkbox m-b-20">
                    <label>
                        <input type="checkbox">
                        Remember Me
                    </label>
                </div>--%>
                <button class="btn btn-sm m-r-5" type="button"  onclick="Login()" style="margin-top:5px;">登陆</button>
                
                <small>
                    <%--<a class="box-switcher" data-switch="box-register" href="">Don't have an Account?</a>--%> 
                    <a data-switch="box-reset" href="/SecurityCenter/Findpwd.aspx">忘记密码?</a>
                </small>
            </form>
            
           
            
        </section>

    <!-- Javascript Libraries -->
    <!-- jQuery -->
    <script src="/Admin/js/jquery.min.js"></script>
    <!-- jQuery Library -->

    <!-- Bootstrap -->
    <script src="/Admin/js/bootstrap.min.js"></script>

    <!--  Form Related -->
    <script src="/Admin/js/icheck.js"></script>
    <!-- Custom Checkbox + Radio -->

    <!-- All JS functions -->
    <script src="/Admin/js/functions.js"></script>
</body>
</html>
