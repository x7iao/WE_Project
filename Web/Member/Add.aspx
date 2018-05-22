<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="WE_Project.Web.Member.Add"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%-- <script src="/SourceFiles/AcmeBlue/js/linkage.js" type="text/javascript"></script>--%>
    <title></title>
    <style type="text/css">
        td span
        {
            /*color: Red;*/
        }
    </style>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="30%" align="right">
                        会员账号:
                    </td>
                    <td>
                        <input id="txtMID" runat="server" class="normal_input" type="text" maxlength="20"
                            placeholder="请输入会员帐号" /><span>*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        会员昵称:
                    </td>
                    <td>
                        <input id="txtMName" name="txtMName" class="normal_input" type="text" maxlength="10"
                            placeholder="请输入会员昵称" value="速度" /><span>*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        推荐人账号:
                    </td>
                    <td>
                        <input id="txtMTJ" runat="server" class="normal_input" type="text" maxlength="20"  onchange="getName();"
                            placeholder="请输入推荐人帐号" />姓名：<span id="spmtjName" runat="server">*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        登录密码:
                    </td>
                    <td>
                        <input id="txtPassword" name="txtPassword" class="normal_input" type="password" placeholder="请输入登录密码"
                            maxlength="20" value="" /><span>*(6-20位字母或数字)</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        确认登录密码:
                    </td>
                    <td>
                        <input id="txtPassword2" name="txtPassword2" class="normal_input" type="password"
                            placeholder="请输入确认登录密码" maxlength="20" value="" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        交易密码:
                    </td>
                    <td>
                        <input id="txtSecPsd" name="txtSecPsd" class="normal_input" type="password" placeholder="请输入交易密码"
                            maxlength="20" value="" /><span>*(6-20位字母或数字，且不能与登录密码相同)</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        确认交易密码:
                    </td>
                    <td>
                        <input id="txtSecPsd2" name="txtSecPsd2" class="normal_input" type="password" placeholder="请输入确认交易密码"
                            maxlength="20" value="" />
                    </td>
                </tr>
                <tr style="display:none;">
                    <td align="right">
                        身份证号:
                    </td>
                    <td>
                        <input name="txtNumID" id="txtNumID" class="normal_input" type="text" maxlength="20" placeholder="请输入您的身份证号"
                            value="" /><span>*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        微信帐号:
                    </td>
                    <td>
                        <input name="txtWeChat" id="txtWeChat" class="normal_input" type="text" maxlength="20" placeholder="请输入您的微信帐号"
                            value="" /><span></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        支付宝帐号:
                    </td>
                    <td>
                        <input name="txtAlipay" id="txtAlipay" class="normal_input" type="text" maxlength="20" placeholder="请输入您的支付宝帐号"
                            value="" /><span>*</span>
                    </td>
                </tr>
              
                <tr>
                    <td align="right">
                        开户支行:
                    </td>
                    <td>
                        <input name="txtBranch" id="txtBranch" class="normal_input" type="text" placeholder="请填写开户支行"
                            maxlength="20" value="" /><span>*</span>
                    </td>
                </tr>
                  <tr>
                    <td align="right">
                        开户银行:
                    </td>
                    <td>
                        <select name="txtBank" id="txtBank">
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
                        </select><span>*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        开户名:
                    </td>
                    <td>
                        <input name="txtBankCardName" id="txtBankCardName" class="normal_input" type="text"
                            placeholder="请填写开户名" maxlength="20" value="" /><span>*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        银行卡号:
                    </td>
                    <td>
                        <input name="txtBankNumber" id="txtBankNumber" class="normal_input" type="text" placeholder="请填写银行卡号"
                            maxlength="20" value="" /><span>*</span>
                    </td>
                </tr>
                <tr style="display:none;">
                    <td align="right">
                        密保问题:
                    </td>
                    <td>
                        <select id="ddlQuestion" name="ddlQuestion" runat="server">
                        </select>
                    </td>
                </tr>
                <tr style="display:none;">
                    <td align="right">
                        密保答案:
                    </td>
                    <td>
                        <input id="txtAnswer" name="txtAnswer" type="text" /><span class="dotted">*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        手机号码:
                    </td>
                    <td>
                        <input id="txtTel" runat="server" class="normal_input" type="text" maxlength="11"
                            require-msg="手机号码" require-type="require" placeholder="请输入手机号码" value="" /><span>*</span>
                    </td>
                </tr>
                <%
                    if (WE_Project.BLL.Configuration.Model.DFHXFCount == 1) 
                    {
                    %>
                        <tr>
                            <td align="right">
                                手机验证码:
                            </td>
                            <td>
                                <input id="txtTelCode" class="normal_input" name="txtTelCode" type="text" placeholder="请输入验证码"
                                    value="" /><span>*</span>
                                <input type="button" class="normal_btnok" value="获取验证码" onclick="sendTelCode()" />
                            </td>
                        </tr>
                    <%
                    }
                     %>
                
                <tr style="height: 50px;">
                    <td align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                    </td>
                    <td align="left">
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function getName() {
            

            var name = RunAjaxGetKey('getMName', $('#txtMTJ').val());
            $("#spmtjName").html(name);
        }

        function sendTelCode() {
            var tel = $.trim($("#txtTel").val());
            if (!tel.TryTel()) {
                v5.error('请输入正确的手机号', '2', 'true');
                return false;
            }
            else {
                var relVal = GetAjaxString('SendCode', tel);
                v5.error(relVal, '2', 'true');
            }
        }
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
            //} else if (!$('#txtNumID').val().TryIDCard()) {
            //    v5.error('身份证号码格式不正确', '1', 'true');
            //} else if ($('#txtAlipay').val() == "") {
            //    v5.error('支付宝帐号不能为空', '1', 'true');
            }else if ($('#txtBank').val() == "") {
                v5.error('请选择开户银行', '1', 'true');

            } else if ($('#txtBranch').val() == "") {
                v5.error('请填写开户支行', '1', 'true');
            } else if ($('#txtBankCardName').val() == "") {
                v5.error('请填写开户名', '1', 'true');
            } else if (!$('#txtBankCardName').val().TryWENZI()) {
                v5.error('开户名格式不正确', '1', 'true');

            } else if ($('#txtBankNumber').val() == "") {
                v5.error('请填写银行卡号', '1', 'true');

            } else if (!$('#txtTel').val().TryTel()) {
                v5.error('手机号码格式不正确', '1', 'true');
            //} else if ($('#txtAnswer').val() == '') {
            //    v5.error('密保答案不能为空', '1', 'true');
//            } else if ($('#txtTelCode').val() == "") {
//                v5.error('验证码不能为空', '1', 'true');
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
    </script>
</body>
</html>
