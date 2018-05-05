<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DLMoney.aspx.cs" Inherits="WE_Project.Web.Member.DLMoney" %>

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
                    <td width="30%" align="right">
                        签到奖:
                    </td>
                    <td>
                        <%=DayFHMoney%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        上次签到日期:
                    </td>
                    <td>
                        <%=UpDFHMoney%>
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="center" colspan="2">
                        <input class="normal_btnok" id="btnOK" type="button" value="领取签到奖" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            ActionModelBack("/Member/DLMoney.aspx?Action=add", $('#form1').serialize(), "Member/DLMoney.aspx",
                function () {
                    $("#btnOK").removeAttr("onclick");
                    $("#btnOK").val("请等待...");
                });
        }
    </script>
</body>
</html>
