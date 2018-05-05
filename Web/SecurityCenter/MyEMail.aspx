<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyEMail.aspx.cs" Inherits="WE_Project.Web.SecurityCenter.MyEMail" %>

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
                    <td align="center" colspan="4" class="sen_title">
                        <span>设置我的邮箱</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        我的邮箱:
                    </td>
                    <td>
                        <input id="txtMyEmail" class="normal_input" runat="server" readonly="readonly" maxlength="50" /><%//=IfVerify%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        变更邮箱:
                    </td>
                    <td>
                        <input id="txtChangeEmail" class="normal_input" runat="server" maxlength="50" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        默认接收电子账单:
                    </td>
                    <td>
                        <input id="chkGet" type="checkbox" runat="server" />接收
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        获取以下时间段电子账单
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        开始日期:
                        <input id="txtStartDate" class="normal_input" readonly="readonly" style="width: 120px;"
                            onclick="WdatePicker({minDate:'#F{$dp.$D(\'txtEndDate\')}'})" />
                    </td>
                    <td>
                        结束日期:
                        <input id="txtEndDate" class="normal_input" readonly="readonly" style="width: 120px;"
                            onclick="WdatePicker({minDate:'#F{$dp.$D(\'txtStartDate\')}'})" />
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display:none;" />
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
            ActionModel("/SecurityCenter/ModifyPwd.aspx?Action=modify", $('#form1').serialize());
        }
    </script>
</body>
</html>
