<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DTFHAccounts.aspx.cs" Inherits="WE_Project.Web.PrizePool.DTFHAccounts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="20%" align="right">
                        奖金类型:
                    </td>
                    <td width="30%">
                        <input id="txtPCodeStr" readonly="readonly" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        鸿运宝数量:
                    </td>
                    <td>
                        <input id="txtFHCount" readonly="readonly" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        每包分红:
                    </td>
                    <td>
                        <input id="txtFHMoney" type="text" runat="server" class="normal_input" onchange="gettotal(this);" />为空则按照默认
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        分红总计:
                    </td>
                    <td>
                        <input id="txtTotalFHMoney" runat="server" class="normal_input" type="text" readonly="readonly" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <b>上次结算信息</b>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        结算金额:
                    </td>
                    <td>
                        <input id="lbTotalFHMoney" readonly="readonly" runat="server" class="normal_input"
                            type="text" maxlength="20" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        鸿运宝数量:
                    </td>
                    <td>
                        <input id="lbFHCount" readonly="readonly" runat="server" class="normal_input" type="text"
                            maxlength="20" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        结算状态:
                    </td>
                    <td>
                        <input id="lbIsAuto" readonly="readonly" runat="server" class="normal_input" type="text"
                            maxlength="20" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        结算日期:
                    </td>
                    <td>
                        <input id="lbAccountsDate" readonly="readonly" runat="server" class="normal_input"
                            type="text" maxlength="20" />
                    </td>
                </tr>
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
        function checkChange() {
            ActionModelBack("/PrizePool/DTFHAccounts.aspx?Action=add", $('#form1').serialize(), "PrizePool/AccountsList.aspx",
                function () {
                    $("#btnOK").removeAttr("onclick");
                    $("#btnOK").val("请等待...");
                });
        }
        function gettotal(obj) {
            $("#txtTotalFHMoney").val(Math.round(parseFloat($("#txtFHCount").val()) * parseFloat($(obj).val()) * 100) / 100);
        }
    </script>
</body>
</html>
