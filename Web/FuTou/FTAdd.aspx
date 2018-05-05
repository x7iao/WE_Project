<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FTAdd.aspx.cs" Inherits="WE_Project.Web.FuTou.FTAdd" %>

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
                        会员账号:
                    </td>
                    <td width="30%">
                        <%=TModel.MID %>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        剩余可复投金额:
                    </td>
                    <td width="30%">
                        <%=remain %>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        我的<%=WE_Project.BLL.Reward.List["MHB"].RewardName %>:
                    </td>
                    <td width="30%">
                        <%=TModel.MConfig.MHB %>
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="right">
                        复投金额:
                    </td>
                    <td width="30%">
                        <input type="text" id="txtCount" name="txtCount" class="normal_input" />
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td>
                    </td>
                    <td align="left">
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="购买" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if (!$("#txtCount").val().TryMoney()) {
                v5.error('请输入正确的购买金额', '1', 'true');
            }
            else {
                ActionModelBack("/FuTou/FTAdd.aspx?Action=add", $('#form1').serialize(), "FuTou/FTList.aspx",
                function () {
                    $("#btnOK").removeAttr("onclick");
                    $("#btnOK").val("请等待...");
                });
            }
        }
    </script>
</body>
</html>
