<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WE_Project.Web.Manage.Login" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title><%=WebModel.WebTitle %></title>
   
    <meta name="viewport" content="width=device-width">
    <link href="/Manage/public/css/base.css" rel="stylesheet" type="text/css">
    <link href="/Manage/public/css/login.css" rel="stylesheet" type="text/css">


     <script src="/Admin/js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="/Admin/pop/js/ajax.js" type="text/javascript"></script>
    
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
    

</head>
<body  onkeydown="keyLogin();">

    <div class="login"  id="main">
       
            <div class="logo"></div>
            <div class="login_form">
                <div class="user">
                    <input class="text_value" value="" id="txtname" name="txtname" type="text" >
                    <input class="text_value" value="" type="password" id="txtpwd" name="txtpwd">
                </div>
                <button class="button"  type="button" onclick="Login();" >登录</button>
            </div>

            <div id="tip"></div>
            <div class="foot">
                  <%=WebModel.WCopyright%>
            </div>
        
    </div>
  
    <script type="text/javascript">
        function Login() {
            if ($("#txtname").val() == "") {
                v5.error('用户不能为空', '1', 'true');
            } else if (pwd = $("#txtpwd").val() == "") {
                v5.error('密码不能为空', '1', 'true');
            } else {
                $.ajax({
                    type: "post",
                    url: "/Manage/Login.aspx?type=login",
                    data: {
                        txtname: $("#txtname").val(), txtpwd: $("#txtpwd").val(), href: window.location.href
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
                            //case "3":
                            //    v5.error('验证码错误', '1', 'true');
                            //    $("#imgcode").click();
                            //    break;
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
                                v5.error(data, '1', 'true');
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
</body>
</html>
