<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatchHelp.aspx.cs" Inherits="WE_Project.Web.Mafull.MatchHelp" %>

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
                        申请帮助数量:
                    </td>
                    <td>
                        <input id="txtOfferCount" runat="server" class="normal_input" type="text" readonly="readonly" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        获得帮助数量:
                    </td>
                    <td>
                        <input id="txtGetCount" runat="server" class="normal_input" type="text" readonly="readonly" />
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="right">
                        <input name="btnreturn" type="reset" style="display: none" class="normal_btnok" value="返回"
                            onclick="callhtml('PrizePool/AccountsList.aspx');" />
                    </td>
                    <td align="left">
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="按数量匹配"
                            onclick="checkChange();" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        申请帮助会员帐号:
                    </td>
                    <td>
                        <input id="txtoffer" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        获得帮助会员帐号:
                    </td>
                    <td>
                        <input id="txtget" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="right">
                        <input name="btnreturn" type="reset" style="display: none" class="normal_btnok" value="返回"
                            onclick="callhtml('PrizePool/AccountsList.aspx');" />
                    </td>
                    <td align="left">
                        <input class="normal_btnok" id="Button1" type="button" runat="server" value="按帐号匹配"
                            onclick="checkChange1();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            ActionModel("/Mafull/MatchHelp.aspx?Action=modify", $('#form1').serialize());
        }
        function checkChange1() {
            ActionModel("/Mafull/MatchHelp.aspx?Action=add", $('#form1').serialize());
        }
    </script>
</body>
</html>
