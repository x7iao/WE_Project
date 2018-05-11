<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WE_Project.Web.Regedit.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>
        <%=WebModel.WebTitle%></title>
    <meta name="renderer" content="webkit" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/style.css" />
    <link href="css/layer.css" rel="stylesheet" />
    <link href="/Admin/pop/css/V5-UI.css" rel="stylesheet" type="text/css" />
    <script src="/Admin/jquery/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="/Admin/pop/js/MyValide.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            if (!placeholderSupport()) {   // 判断浏览器是否支持 placeholder
                $('[placeholder]').focus(function () {
                    var input = $(this);
                    if (input.val() == input.attr('placeholder')) {
                        input.val('');
                        input.removeClass('placeholder');
                    }
                }).blur(function () {
                    var input = $(this);
                    if (input.val() == '' || input.val() == input.attr('placeholder')) {
                        input.addClass('placeholder');
                        input.val(input.attr('placeholder'));
                    }
                }).blur();
            };
        })
        function placeholderSupport() {
            return 'placeholder' in document.createElement('input');
        }
    </script>
</head>
<body>
    <div class="web-header">
        <div class="container clearfix">
            <div class="pull-left logo">
                <a href="Login.aspx">
                    <img src="images/logo.png"></a>
            </div>
            <nav class="blog-nav pull-left"> <a class="blog-nav-item active" href="/Regedit/Index.aspx">欢迎注册</a> </nav>
            <nav class="pull-right"> <a href="/Regedit/Index.aspx" class="pull-right text-white" style="margin-left:15px;">注册账号</a> <a href="/Login.aspx" class="pull-right text-white">登陆</a> </nav>
        </div>
    </div>
    <div class="container">
        <div class="mainbody">
            <div class="title">
                <span>注册</span> <a href="/Login.aspx" class="pull-right rightlink text-danger">已有账号，直接登陆</a>
            </div>
            <div class="register-box">
                <form class="form-horizontal" method="post" runat="server">
                <div class="form-group">
                    <label class="col-sm-3 control-label">
                        推荐人帐号:</label>
                    <div class="col-sm-9">
                        <input name="txtMTJ" id="txtMTJ" class="form-control" style="line-height: 35px;"
                            type="text" maxlength="20" placeholder="推荐人帐号" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">
                        会员账号:</label>
                    <div class="col-sm-9">
                        <input name="txtMID" id="txtMID" class="form-control" style="line-height: 35px;"
                            type="text" maxlength="30" placeholder="会员账号" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">
                        会员昵称:</label>
                    <div class="col-sm-9">
                        <input name="txtMName" id="txtMName" style="line-height: 35px;" type="text" class="input310 form-control"
                            placeholder="会员昵称" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">
                        登录密码:</label>
                    <div class="col-sm-9">
                        <input name="txtPwd1" id="txtPwd1" style="line-height: 35px;" type="text" class="input310 form-control"
                            placeholder="登录密码" />
                    </div>
                </div>
                <hr>
                <div class="form-group">
                    <label for="tradepwd_re" class="col-sm-3 control-label">
                        确认登录密码:</label>
                    <div class="col-sm-9">
                        <input name="txtPwd2" id="txtPwd2" style="line-height: 35px;" type="text" class="input310 form-control"
                            placeholder="确认登录密码" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="invitecode" class="col-sm-3 control-label">
                        交易密码:</label>
                    <div class="col-sm-9">
                        <input name="txtSecPwd" id="txtSecPwd" style="line-height: 35px;" type="text" class="input310 form-control"
                            placeholder="交易密码" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="invitecode" class="col-sm-3 control-label">
                        确认交易密码：</label>
                    <div class="col-sm-9">
                        <input name="txtSecPwd2" id="txtSecPwd2" class="form-control" style="line-height: 35px;"
                            maxlength="20" type="text" placeholder="确认交易密码" />
                    </div>
                </div>
                <div class="form-group" style="display:none;">
                    <label for="invitecode" class="col-sm-3 control-label">
                        身份证号：</label>
                    <div class="col-sm-9">
                        <input name="txtNumID" id="txtNumID" class="form-control" style="line-height: 35px;"
                            maxlength="20" type="text" placeholder="身份证号" />
                    </div>
                </div>
                <div class="form-group" style="display:none;">
                    <label for="invitecode" class="col-sm-3 control-label">
                        微信帐号：</label>
                    <div class="col-sm-9">
                        <input name="txtWeChat" id="txtWeChat" class="form-control" style="line-height: 35px;"
                            maxlength="20" type="text" placeholder="微信帐号" />
                    </div>
                </div>
                <div class="form-group" style="display:none;">
                    <label for="invitecode" class="col-sm-3 control-label">
                        支付宝帐号：</label>
                    <div class="col-sm-9">
                        <input name="txtAlipay" id="txtAlipay" class="form-control" style="line-height: 35px;"
                            maxlength="20" type="text" placeholder="支付宝帐号" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">
                        开户银行</label>
                    <div class="col-sm-9">
                        <select name="txtBank" id="txtBank" class="form-control" style="line-height: 40px;
                            height: 40px;">
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
                    </div>
                </div>
                <div class="form-group">
                    <label for="invitecode" class="col-sm-3 control-label">
                        开户支行：</label>
                    <div class="col-sm-9">
                        <input name="txtBranch" id="txtBranch" class="form-control" style="line-height: 35px;"
                            maxlength="20" type="text" placeholder="开户支行" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="invitecode" class="col-sm-3 control-label">
                        开户名：</label>
                    <div class="col-sm-9">
                        <input name="txtBankCardName" id="txtBankCardName" class="form-control" style="line-height: 35px;"
                            maxlength="20" type="text" placeholder="开户名" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="invitecode" class="col-sm-3 control-label">
                        银行卡号：</label>
                    <div class="col-sm-9">
                        <input name="txtBankNumber" id="txtBankNumber" class="form-control" style="line-height: 35px;"
                            maxlength="20" type="text" placeholder="银行卡号" />
                    </div>
                </div>
                <div class="form-group" style="display:none;">
                    <label class="col-sm-3 control-label">
                        密保问题</label>
                    <div class="col-sm-9">
                        <select id="ddlQuestion" name="ddlQuestion" runat="server" class="form-control">
                        </select>
                    </div>
                </div>
                <div class="form-group" style="display:none;">
                    <label class="col-sm-3 control-label">
                        密保答案</label>
                    <div class="col-sm-9">
                        <input id="txtAnswer" name="txtAnswer" class="form-control" type="text" placeholder="请输入您的密保答案" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="invitecode" class="col-sm-3 control-label">
                        手机号码：</label>
                    <div class="col-sm-9">
                        <input name="txtTel" id="txtTel" class="form-control" style="line-height: 35px;"
                            maxlength="20" type="text" placeholder="手机号码" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="invitecode" class="col-sm-3 control-label">
                        手机验证码：</label>
                    <div class="col-sm-9">
                        <input id="txtTelCode" name="txtTelCode" class="form-control" style="line-height: 35px;
                            width: 50%;" type="text" maxlength="4" placeholder="验证码" />
                        <input type="button" class="getphone btn btn-success btn-lg" style="margin-left: 20px;
                            padding-left: 0px; padding: 4px 4px; border-radius: 3px;" value="获取验证码" onclick="sendTelCode()" />
                    </div>
                </div>
                <div class="form-group mt20">
                    <label class="col-sm-3 control-label">
                    </label>
                    <div class="col-sm-9">
                        <asp:Button ID="btnOK" runat="server" Text="注册账号" Style="cursor: pointer;" CssClass="btn btn-success btn-lg width200"
                            OnClientClick="return TestEmail();" OnClick="btnOK_Click" />
                    </div>
                </div>
                </form>
            </div>
        </div>
    </div>
    <footer class="pre-footer">
		<div class="container">
			<div class="divider"></div>
			<%=WebModel.WCopyright %>
		</div>
	</footer>
    <script src="/Admin/pop/js/ajax.js" type="text/javascript"></script>
    <script src="/Admin/pop/js/V5-UI.js" type="text/javascript"></script>
    <script src="/Admin/pop/js/javascript_pop.js" type="text/javascript"></script>
    <script type="text/javascript">
        function sendTelCode() {
            var tel = $.trim($("#txtTel").val());
            if (!$('#txtTel').val().TryTel()) {
                v5.error('请输入正确的手机号', '2', 'true');
                return false;
            }
            else {
                var relVal = GetAjaxString('SendCode', tel);
                v5.error(relVal, '2', 'true');
            }
        }
        function TestEmail() {
            if (!$('#txtMID').val().TryMID()) {
                v5.error('会员账户格式为6-20位字母或数字组合', '1', 'true');
                return false;
            } else if ($('#txtMName').val() == '') {
                v5.error('会员昵称不能为空', '1', 'true');
                return false;
            } else if (!$('#txtPassword').val().TryPassword()) {
                v5.error('登录密码不能为空，且必须为6-20位字母或数字组合', '1', 'true');
                return false;
            } else if ($('#txtPassword').val() != $('#txtPassword2').val()) {
                v5.error('登录密码与确认登录密码不一样', '1', 'true');
                return false;
            } else if (!$('#txtSecPsd').val().TryPassword()) {
                v5.error('二级密码不能为空，且必须为6-20位字母或数字组合', '1', 'true');
                return false;
            } else if ($('#txtSecPsd').val() != $('#txtSecPsd2').val()) {
                v5.error('二级密码与确认二级密码不一样', '1', 'true');
                return false;
            } else if ($('#txtPassword').val() == $('#txtSecPsd').val()) {
                v5.error('二级密码与登录密码不能相同', '1', 'true');
                return false;
            //} else if (!$('#txtNumID').val().TryIDCard()) {
            //    v5.error('身份证号码格式不正确', '1', 'true');
            //    return false;
            //} else if ($('#txtWeChat').val() == "") {
            //    v5.error('微信帐号不能为空', '1', 'true');
            //    return false;
            //} else if ($('#txtAlipay').val() == "") {
            //    v5.error('支付宝帐号不能为空', '1', 'true');
            //    return false;
            } else if ($('#txtBank').val() == "") {
                v5.error('请选择开户银行', '1', 'true');
                return false;
            } else if ($('#txtBranch').val() == "") {
                v5.error('请填写开户支行', '1', 'true');
                return false;
            } else if (!$('#txtBankCardName').val().TryWENZI()) {
                v5.error('开户名格式不正确', '1', 'true');
                return false;
            } else if ($('#txtBankNumber').val() == "") {
                v5.error('请填写银行卡号', '1', 'true');
                return false;
            } else if (!$('#txtTel').val().TryTel()) {
                v5.error('手机号码格式不正确', '1', 'true');
                return false;
            } else if ($('#txtTelCode').val() == "") {
                v5.error('验证码不能为空', '1', 'true');
                return false;
            //} else if ($('#txtAnswer').val() == '') {
            //    v5.error('密保答案不能为空', '1', 'true');
            //    return false;
            }
            return true;
        }
    </script>
</body>
</html>
