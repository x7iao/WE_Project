<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebBase.aspx.cs" Inherits="WE_Project.Web.SysManage.WebBase" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="20%" align="right">
                        短信签名:
                    </td>
                    <td width="30%">
                        <input id="txtSMSTitle" runat="server" class="normal_input" type="text" maxlength="25" />
                    </td>
                    <td width="20%" align="right">
                        邮箱签名:
                    </td>
                    <td width="30%">
                        <input id="txtEmailTitle" runat="server" class="normal_input" type="text" maxlength="25" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        短信账号:
                    </td>
                    <td>
                        <input id="txtSMSName" runat="server" class="normal_input" type="text" maxlength="25" />
                    </td>
                    <td align="right">
                        邮箱账号:
                    </td>
                    <td>
                        <input id="txtEmailName" runat="server" class="normal_input" type="text" maxlength="25" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        短信密码:
                    </td>
                    <td>
                        <input id="txtSMSPassword" runat="server" class="normal_input" type="text" maxlength="25" />
                    </td>
                    <td align="right">
                        邮箱密码:
                    </td>
                    <td>
                        <input id="txtEmailPassword" runat="server" class="normal_input" type="text" maxlength="25" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        短信余额:
                    </td>
                    <td>
                        <input id="txtShengYu" runat="server" readonly="readonly" class="normal_input" type="text"
                            maxlength="25" />
                    </td>
                    <td align="right">
                        邮箱服务器:
                    </td>
                    <td>
                        <input id="txtEmailSmtp" runat="server" class="normal_input" type="text" maxlength="25" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        每日限量:
                    </td>
                    <td>
                        <input id="txtDaySMSCount" runat="server" class="normal_input" type="text" maxlength="25" />
                    </td>
                    <td align="right">
                        邮箱验证:
                    </td>
                    <td>
                        <input id="chkEmailVerify" runat="server" type="checkbox" />验证
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        余额报警:
                    </td>
                    <td>
                        <input id="txtSMSMinCount" runat="server" class="normal_input" type="text" maxlength="25" />
                    </td>
                    <td align="right">
                        手机验证:
                    </td>
                    <td>
                        <input id="chkTelVerify" type="checkbox" runat="server" />验证
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        短信功能:
                    </td>
                    <td>
                        <input id="chkSMSState" runat="server" type="checkbox" />开启
                    </td>
                    <td align="right">
                        邮箱功能:
                    </td>
                    <td>
                        <input id="chkEmailState" runat="server" type="checkbox" />开启
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        系统分配账号:
                    </td>
                    <td>
                        <input id="chkAutoID" runat="server" type="checkbox" checked="checked" />随机，不可修改
                    </td>
                    <td align="right">
                        随机密码:
                    </td>
                    <td>
                        <input id="chkRandPassword" runat="server" type="checkbox" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        监控手机号:
                    </td>
                    <td>
                        <input id="txtMonitorTel" runat="server" class="normal_input" type="text" maxlength="25" />
                    </td>
                    <td align="right">
                        监控邮箱:
                    </td>
                    <td>
                        <input id="txtMonitorEmail" runat="server" class="normal_input" type="text" maxlength="25" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        会员注册内容:
                    </td>
                    <td colspan="3">
                        <input id="txtMIDContent" runat="server" class="normal_input" type="text" style="width:80%" />$MID：会员账号；$MName：会员昵称
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        领导人提示内容:
                    </td>
                    <td colspan="3">
                        <input id="txtMTJContent" runat="server" class="normal_input" type="text" style="width:80%" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <input id="Button1" type="button" value="短信测试" class="normal_btnok" onclick="alert(RunAjaxGetKey('SendSMSTest'));" />
                    </td>
                    <td align="center" colspan="2">
                        <input id="Button2" type="button" value="邮箱测试" class="normal_btnok" onclick="alert(RunAjaxGetKey('SendEmailTest'));" />
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td colspan="2" align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                    </td>
                    <td colspan="2" align="left">
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            ActionModel("/SysManage/WebBase.aspx?Action=Modify", $('#form1').serialize());
        }
    </script>
</body>
</html>
