<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WE_Project.Web.Regedit.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<!--[if IE 9 ]><html class="ie9"><![endif]-->
    <head>
        <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
        <meta name="format-detection" content="telephone=no">
        <meta charset="UTF-8">

        <meta name="description" content="Violate Responsive Admin Template">
        <meta name="keywords" content="Super Admin, Admin, Template, Bootstrap">
        <link rel = "Shortcut Icon" href=/Admin/img/icon.ico>
        <title><%=WebModel.WebTitle %></title>
            
        <!-- CSS -->
        <link href="/Admin/css/bootstrap.min.css" rel="stylesheet">
        <link href="/Admin/css/form.css" rel="stylesheet">
        <link href="/Admin/css/style.css" rel="stylesheet">
        <link href="/Admin/css/animate.css" rel="stylesheet">
        <link href="/Admin/css/generics.css" rel="stylesheet">
        
        
        <link href="../Admin/pop/css/pop.css" rel="stylesheet" type="text/css" />
    <link href="../Admin/pop/css/V5-UI.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Admin/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="../Admin/pop/js/MyValide.js"></script>
    <script src="../Admin/pop/js/ajax.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/V5-UI.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/javascript_pop.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Admin/pop/js/linkage.js"></script>
    <script type="text/javascript">
        function checkChange() {
            if (!$('#txtMID').val().TryMID()) {
                v5.error('会员账户格式为6-20位字母或数字组合', '1', 'true');
            } else if ($('#txtMName').val() == '') {
                v5.error('会员昵称不能为空', '1', 'true');
            } else if ($('#txtMTJ').val() == '') {
                v5.error('推荐会员不能为空', '1', 'true');
            } else if (!$('#txtPassword').val().TryPassword()) {
                v5.error('登录密码不能为空，且必须为6-20位字母或数字组合', '1', 'true');
            } else if ($('#txtPassword').val() != $('#txtPassword2').val()) {
                v5.error('登录密码与确认登录密码不一样', '1', 'true');
            } else if (!$('#txtSecPsd').val().TryPassword()) {
                v5.error('交易密码不能为空，且必须为6-20位字母或数字组合', '1', 'true');
            } else if ($('#txtSecPsd').val() != $('#txtSecPsd2').val()) {
                v5.error('交易密码与确认交易密码不一样', '1', 'true');
            } else if ($('#txtPassword').val() == $('#txtSecPsd').val()) {
                v5.error('交易密码与登录密码不能相同', '1', 'true');
            } else if (!$('#txtTel').val().TryTel()) {
                v5.error('手机号码格式不正确', '1', 'true');
            } else if ($('#txtAlipay').val() == "") {
                v5.error('支付宝帐号不能为空', '1', 'true');
            }  else  if ($('#txtBank').val() == "") {
                v5.error('请选择开户银行', '1', 'true');

            } else if ($('#txtBranch').val() == "") {
                v5.error('请填写开户支行', '1', 'true');
            } else if ($('#txtBankCardName').val() == "") {
                v5.error('请填写开户名', '1', 'true');

            } else if (!$('#txtBankCardName').val().TryWENZI()) {
                v5.error('开户名格式不正确', '1', 'true');

            } else if ($('#txtBankNumber').val() == "") {
                v5.error('请填写银行卡号', '1', 'true');

            } else {
              
                if (checkForm()) {
                    $.ajax({
                        type: 'post',
                        url: '/Ajax/Regedit.ashx?Action=add',
                        data: $('#form1').serialize(),
                        success: function (info) {
                            v5.alert(info, '1', 'true');
                            setTimeout(function () {
                                v5.clearall();
                            }, 1000);
                        }
                    });
                }
            }
        }
        function sendTelCode() {
            var tel = $.trim($("#txtTel").val());
            if (tel == "") {
                v5.error('手机号码不能为空', '1', 'true');
                return false;
            }
            if (!tel.TryTel()) {
                v5.error('手机号格式不正确', '1', 'true');
                return false;
            }
            var relVal = GetAjaxString('SendCode', tel);
            v5.error(relVal, '1', 'true');
        }
    </script>
         
    </head>
    <body id="skin-blur-violate">
        <section id="login">
            <header>
                <h1>WE</h1>
                <p>为避免您的资金安全，请正确填写以下注册信息</p>
            </header>
        
            <div class="clearfix"></div>
            
          
            
            <!-- Register -->
            <form class="box animated tile active" id="box-register">
                <h2 class="m-t-0 m-b-15">注册</h2>
                <input type="text" class="login-control m-b-10"  id="txtMID" runat="server" placeholder="会员账号">
                <input type="text" class="login-control m-b-10" id="txtMName" name="txtMName" runat="server"  placeholder="会员昵称">
                <input type="text" class="login-control m-b-10"  id="txtMTJ" runat="server" placeholder="推荐人账号">    
                <input type="password" class="login-control m-b-10" id="txtPassword" name="txtPassword" placeholder="登录密码">
                <input type="password" class="login-control m-b-20" id="txtPassword2" name="txtPassword2" placeholder="确认登录密码">

                <input type="password" class="login-control m-b-10"  id="txtSecPsd" name="txtSecPsd" placeholder="交易密码">
                <input type="password" class="login-control m-b-20" id="txtSecPsd2" name="txtSecPsd2" placeholder="确认交易密码">
                <input type="text" class="login-control m-b-10"  id="txtWeChat" runat="server" placeholder="微信帐号">    
                <input type="text" class="login-control m-b-10"  id="txtAlipay" runat="server" placeholder="支付宝帐号">    

               

                <input type="text" class="login-control m-b-10" name="txtBranch" id="txtBranch"    placeholder="开户支行">
                  <select name="txtBank" id="txtBank"  class="login-control m-b-20" >
                            <option selected="selected" value="">请选择</option>
                            <option value="中国银行">中国银行</option>
                            <option value="工商银行">工商银行</option>
                            <option value="农业银行">农业银行</option>
                            <option value="建设银行">建设银行</option>
                            <option value="交通银行">交通银行</option>
                            <option value="中国邮政">中国邮政</option>
                            <option value="兴业银行">兴业银行</option>
                            <option value="招商银行">招商银行</option>
                            <option value="民生银行">民生银行</option>
                        </select>
                <input type="text" class="login-control m-b-10"  name="txtBankCardName" id="txtBankCardName" placeholder="开户名">    
                <input type="text" class="login-control m-b-10" name="txtBankNumber" id="txtBankNumber"  placeholder="银行卡号">

                <input type="text" class="login-control m-b-10"  id="txtTel" runat="server" maxlength="11"  placeholder="手机号码">
                  <%
                    if (WE_Project.BLL.Configuration.Model.DFHXFCount == 1) 
                    {
                    %>
                  <input type="text" class="login-control m-b-10" id="txtTelCode" name="txtTelCode"  maxlength="6" placeholder="手机验证码" style="width:70%;"><input type="button" value="获取验证码" class="btn" onclick="sendTelCode()" />
                  <%
                    }
                     %>
              
                <button class="btn btn-sm m-r-5"  onclick="checkChange()" type="button">注册</button>

                <small><a  href="/login.aspx">我有账号，登录</a></small>
            </form>
            
            
        </section>                      
        
        <!-- Javascript Libraries -->
        <!-- jQuery -->
        <script src="/Admin/js/jquery.min.js"></script> <!-- jQuery Library -->
        
        <!-- Bootstrap -->
        <script src="/Admin/js/bootstrap.min.js"></script>
        
        <!--  Form Related -->
        <script src="/Admin/js/icheck.js"></script> <!-- Custom Checkbox + Radio -->
        
        <!-- All JS functions -->
        <script src="/Admin/js/functions.js"></script>
    </body>
</html>
