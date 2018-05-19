<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Findpwd.aspx.cs" Inherits="WE_Project.Web.SecurityCenter.Findpwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<!DOCTYPE html>
<!--[if IE 9 ]><html class="ie9"><![endif]-->
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <meta name="format-detection" content="telephone=no">
    <meta charset="UTF-8">
    <link rel = "Shortcut Icon" href=/Admin/img/icon.ico>
    <meta name="description" content="Violate Responsive Admin Template">
    <meta name="keywords" content="Super Admin, Admin, Template, Bootstrap">

    <title><%=WebModel.WebTitle %></title>

    <!-- CSS -->
    <link href="/Admin/css/bootstrap.min.css" rel="stylesheet">
    <link href="/Admin/css/form.css" rel="stylesheet">
    <link href="/Admin/css/style.css" rel="stylesheet">
    <link href="/Admin/css/animate.css" rel="stylesheet">
    <link href="/Admin/css/generics.css" rel="stylesheet">

    <link type="text/css" rel="stylesheet" href="../Admin/pop/css/V5-UI.css" />
</head>
<body id="skin-blur-violate">
    <section id="login">
            <header>
                <h1>WE</h1>
                <p>如果您在尝试使用帐号密码登录时遇到了问题，请按照以下步骤重设密码并重新获取帐户访问权限。</p>
            </header>
        
            <div class="clearfix"></div>

            <!-- Register -->
            <form class="box animated tile active" id="form1"  method="post">
                <h2 class="m-t-0 m-b-15">找回密码</h2>
                <input type="text" class="login-control m-b-10" id="txtname" name="username" runat="server" placeholder="登陆账号">
                <input type="password" class="login-control m-b-10" id="txtpwd" name="password" runat="server" placeholder="设置登陆密码">
                <input type="password" class="login-control m-b-10" id="txtpwd2" name="password" runat="server"  placeholder="确认登陆密码">    
                <input type="password" class="login-control m-b-10" id="txtChangePwd" name="password" runat="server" placeholder="设置交易密码">
                <input type="password" class="login-control m-b-20"  id="txtChangePwd2" name="password" runat="server" placeholder="确认交易密码">

                <input type="text" class="login-control m-b-20"  id="txtTel" name="txtTel" runat="server" style="width:70%;" placeholder="手机号码"><button class="btn btn-sm m-r-5"  onclick="sendTelCodeForFindPwd();" type="button" >发送</button>
                <input type="text" class="login-control m-b-20"   id="checkCode" runat="server" placeholder="验证码">

                <button class="btn btn-sm m-r-5"  type="button" onclick="setNewPwd();">找回</button>
            </form>
            
            <!-- Forgot Password -->
           
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


     <script src="../Admin/pop/js/V5-UI.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/javascript_main.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/ajax.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/javascript_pop.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/MyValide.js" type="text/javascript"></script>
    <script type="text/javascript">
        function TestEmail() {
            var regex = new RegExp("^([\u4E00-\uFA29]|[\uE7C7-\uE7F3]|){1,10}$");
            if ($('#txtname').val() == "") {
                v5.error('会员账号不能为空', '1', 'true');
                return false;
            } else if ($('#txtpwd').val() == "" || $('#txtpwd').val().length < 6) {
                v5.error('登录密码应至少6个字母或数字', '1', 'true');
                return false;
            } else if ($('#txtpwd2').val() == "") {
                v5.error('确认登录密码不能为空', '1', 'true');
                return false;
            } else if ($('#txtChangePwd').val() != $('#txtChangePwd2').val()) {
                v5.error('登录密码与确认登录密码不一样', '1', 'true');
                return false;
            } else if ($('#txtChangePwd').val() == "" || $('#txtChangePwd').val().length < 6) {
                v5.error('交易密码应至少6个字母或数字', '1', 'true');
                return false;
            } else if ($('#txtChangePwd2').val() == "") {
                v5.error('确认交易密码不能为空', '1', 'true');
                return false;
            } else if ($('#txtChangePwd').val() != $('#txtChangePwd2').val()) {
                v5.error('交易密码与确认交易密码不一样', '1', 'true');
                return false;
            } else if ($('#txtChangePwd').val() == $('#txtpwd').val()) {
                v5.error('交易密码与登录密码不能相同', '1', 'true');
                return false;
            }
            return true;
        }
        function validMid() {
            var mid = $('#txtname').val();
            var num = 0;
            var number = 0;
            var letter = 0;
            var bigLetter = 0;
            if (mid.search(/[0-9]/) != -1) {
                num += 1;
                number = 1;
            }
            if (mid.search(/[A-Z]/) != -1) {
                num += 1;
                bigLetter = 1;
            }
            if (mid.search(/[a-z]/) != -1) {
                num += 1;
                letter = 1;
            }
            if (num == 1) {
                if (number == 1) {
                    return false;
                }
                if (letter == 1) {
                    return false;
                }
                if (bigLetter == 1) {
                    return false;
                }
            }
            return true;
        }

        function sendTelCodeForFindPwd() {
            var tel = $("#txtTel").val();
            var mid = $("#txtname").val();
            if (!$('#txtTel').val().TryTel()) {
                v5.error('请输入正确的手机号', '2', 'true');
            }
            else {
                if (TestEmail()) {
                    var relVal = RunAjaxGetKey('sendTelCodeForFindPwd', tel + "&txtMID=" + mid);
                    v5.error(relVal, '2', 'true');
                }
            }
        }

        function setNewPwd() {
            if (TestEmail()) {
                $.ajax({
                    type: 'post',
                    url: 'Findpwd.aspx?Action=add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        v5.error(info, '2', 'true');
                        //setTimeout(function () {
                        //    v5.clearall();
                        //    window.location.href = '../Login.aspx'
                        //}, 2000);
                    }
                });
            }
        }
    </script>
</body>
</html>


