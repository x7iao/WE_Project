<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifySecPwd.aspx.cs" Inherits="WE_Project.Web.SecurityCenter.ModifySecPwd"
    EnableEventValidation="false" %>

<html>
<head>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        新交易密码:
                    </td>
                    <td>
                        <input id="lbNSecPsd" class="normal_input" runat="server" type="password" /><font
                            color="red">*</font>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        确认交易密码:
                    </td>
                    <td>
                        <input id="lbConfirm" class="normal_input" runat="server" type="password" /><font
                            color="red">*</font>
                    </td>
                </tr>
                 <tr style="display:none;">
                    <td align="right">
                        <span>手机号码：</span>
                    </td>
                    <td>
                        <input name="txtNumID" id="txtNumID" runat="server" class="normal_input" type="text"  readonly="readonly"/>
                       <input type="button" value="获取验证码"  class="btn btn-success btn-sm" onclick="sendCode(this)"/>
                    </td>
                </tr>
                  <tr style="display:none;">
                    <td align="right">
                        <span>验证码：</span>
                    </td>
                    <td>
                       <input type="text" name="txtTelCode" id="txtTelCode"/>
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                    </td>
                    <td align="left">
                        <input class="normal_btnok" id="btnOK" type="button" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#lbNSecPsd').val().Trim() == '' || $('#lbNSecPsd').val().length < 6) {
                v5.error('新二级密码不能为空，且至少6个字母或数字', '1', 'true');
            } else if ($('#lbNSecPsd').val().Trim() != $('#lbConfirm').val().Trim()) {
                v5.error('新二级密码与确认二级密码不一致', '1', 'true');
            } 
            
            else {
                ActionModel("/SecurityCenter/ModifySecPwd.aspx?Action=modify", $('#form1').serialize());
            }
        }
        function checkPwdAnswer() {
            var qid = $("#hidQuesId").val().Trim();
            var ans = $("#pwdAnswer").val().Trim();
            var result = GetAjaxString("checkPwdAnswer", "0&question=" + qid + "&answer=" + ans);
            if (result == '-1') {
                v5.error('参数错误', '1', 'true');
                return;
            } else if (result == '0') {
                v5.error('密保问题不正确', '1', 'true');
                return;
            }
            else if (result == '2') {
                v5.error('未设置密保问题', '1', 'true');
                return;
            }
            return true;
        }
        function sendCode(obj) {
            $(obj).val("发送中...");
            $(obj).attr("disabled", "disabled");
//            $("#txtTel").attr("readonly", "readonly");
            var sendstate = RunAjaxGetKey("SendCodeModifySecPsd");
            setTimeout(function () { alert(sendstate); $(obj).val(sendstate); }, 500);
        }
    </script>
</body>
</html>
