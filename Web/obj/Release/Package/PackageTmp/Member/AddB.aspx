<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddB.aspx.cs" Inherits="WE_Project.Web.Member.AddB"
    EnableEventValidation="false" %>

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
                        子账号:
                    </td>
                    <td width="30%">
                        <%=WE_Project.BLL.Configuration.Model.SHMoneyList["003"].MAgencyName%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <%=WE_Project.BLL.Reward.List["MCW"].RewardName%>:
                    </td>
                    <td>
                        <%=TModel.MConfig.MCW%>
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td>
                    </td>
                    <td align="left">
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="生成" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">

        function checkChange() {
            if (1000 > parseInt("<%= TModel.MConfig.MCW%>")) {
                v5.error('您的<%=WE_Project.BLL.Reward.List["MCW"].RewardName %>不足', '1', 'true');
                return;
            } else {
                ActionModelBack("/Member/AddB.aspx?Action=add", $('#form1').serialize(), "Member/ListB.aspx",
                function () {
                    $("#btnOK").removeAttr("onclick");
                    $("#btnOK").val("请等待...");
                });
            }
        }
    </script>
</body>
</html>
