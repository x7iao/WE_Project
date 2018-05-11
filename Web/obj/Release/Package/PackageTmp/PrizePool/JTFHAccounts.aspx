<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JTFHAccounts.aspx.cs" Inherits="WE_Project.Web.PrizePool.JTFHAccounts" %>

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
                    <td align="right">
                      每日利息:
                    </td>
                    <td>
                        <input id="txtDayLineLnterestPercent" runat="server" class="normal_input" type="text" onchange="getTotalFHMoney(this);" />
                        <input id="hdTotalMoney" runat="server" type="hidden" />
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                      每日诚信达人奖:
                    </td>
                    <td>
                        <input id="txtHonestyLiXiPercent" runat="server" class="normal_input" type="text" onchange="getTotalFHMoney(this);" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        会员数量:
                    </td>
                    <td>
                        <input id="txtMemberCount" readonly="readonly" runat="server" class="normal_input"
                            type="text" />
                    </td>
                </tr>
                   <tr>
                    <td align="right">
                        存款总额:
                    </td>
                    <td>
                        <input id="txtTotalMoney" readonly="readonly" runat="server" class="normal_input"
                            type="text" />
                    </td>
                </tr>
                    <tr>
                    <td align="right">
                        利息总额:
                    </td>
                    <td>
                        <input id="txtDayLineLnterest" readonly="readonly" runat="server" class="normal_input"
                            type="text" />
                    </td>
                </tr>
                    <tr>
                    <td align="right">
                        诚信达人奖总额:
                    </td>
                    <td>
                        <input id="txtHonestyLiXi" readonly="readonly" runat="server" class="normal_input"
                            type="text" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <b>上次分红信息</b>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        利息金额:
                    </td>
                    <td>
                        <input id="lbTotalFHMoney" readonly="readonly" runat="server" class="normal_input"
                            type="text" maxlength="20" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        会员人数:
                    </td>
                    <td>
                        <input id="lbFHCount" readonly="readonly" runat="server" class="normal_input" type="text"
                            maxlength="20" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        分红状态:
                    </td>
                    <td>
                        <input id="lbIsAuto" readonly="readonly" runat="server" class="normal_input" type="text"
                            maxlength="20" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        分红日期:
                    </td>
                    <td>
                        <input id="lbAccountsDate" readonly="readonly" runat="server" class="normal_input"
                            type="text" maxlength="20" />
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="right">
                        <input name="btnreturn" type="reset" class="normal_btnok" value="返回" onclick="callhtml('PrizePool/AccountsList.aspx');" />
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
        function getTotalFHMoney(obj) {
            $("#txtTotalFHMoney").val(parseInt($(obj).val()) * parseInt($("#hdTotalMoney").val()));
        }
        function checkChange() {
            ActionModelBackWithTitle("/PrizePool/JTFHAccounts.aspx?Action=add", $('#form1').serialize(), "PrizePool/AccountsList.aspx",
                function () {
                    $("#btnOK").removeAttr("onclick");
                    $("#btnOK").val("请等待...");
                },'结算明细');
        }
    </script>
</body>
</html>
