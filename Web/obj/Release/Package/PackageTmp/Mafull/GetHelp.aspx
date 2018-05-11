<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetHelp.aspx.cs" Inherits="WE_Project.Web.Mafull.GetHelp" %>

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
                    <td width="35%" align="right">
                        <span>我的<%=WE_Project.BLL.Reward.List["MHB"].RewardName %>：</span>
                    </td>
                    <td>
                        <%=TModel.MConfig.MHB%>
                    </td>
                </tr>
                <tr>
                    <td width="35%" align="right">
                        <span>我的<%=WE_Project.BLL.Reward.List["MJB"].RewardName %>：</span>
                    </td>
                    <td>
                        <%=TModel.MConfig.MJB%>
                    </td>
                </tr>
                <%--<tr>
                    <td width="35%" align="right">
                        <span>我的<%=WE_Project.BLL.Reward.List["MGP"].RewardName %>：</span>
                    </td>
                    <td>
                        <%=TModel.MConfig.MGP%>
                    </td>
                </tr>--%>
                <tr>
                    <td width="35%" align="right">
                        <span>我的<%=WE_Project.BLL.Reward.List["MCW"].RewardName %>：</span>
                    </td>
                    <td>
                        <%=TModel.MConfig.MCW%>
                    </td>
                </tr>
                <tr>
                    <td width="35%" align="right">
                        <span>申请援助说明：</span>
                    </td>
                    <td>
                        <div>
                            <%--<p>
                                互助币:(<%=WE_Project.BLL.MMMConfig.Model.GetHelpMin%>-<%=WE_Project.BLL.MMMConfig.Model.GetHelpMax%>(<%=WE_Project.BLL.MMMConfig.Model.MHBBase %>的倍数))</p>
                            <p>
                                回馈币:(<%=WE_Project.BLL.MMMConfig.Model.GetHelpMin%>-<%=Math.Min(WE_Project.BLL.MMMConfig.Model.GetHelpMax, TModel.MAgencyType.DTopMoney)%>(<%=WE_Project.BLL.MMMConfig.Model.MCWBase %>的倍数))</p>
                            <p>
                                爱心币:(<%=WE_Project.BLL.MMMConfig.Model.GetHelpMin%>-<%=WE_Project.BLL.MMMConfig.Model.GetHelpMax%>(<%=WE_Project.BLL.MMMConfig.Model.MJBBase %>的倍数))</p>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>申请金额：</span>
                    </td>
                    <td>
                        <input type="text" runat="server" id="txtSQMoneyGet" style="width: 100px" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>使用钱包：</span>
                    </td>
                    <td>
                        <input  value="MCW" type="radio" name="rdo" checked="checked" /><%=WE_Project.BLL.Reward.List["MCW"].RewardName %>
                        <input  value="MHB" type="radio" name="rdo" /><%=WE_Project.BLL.Reward.List["MHB"].RewardName %>
                        <input  value="MJB" type="radio" name="rdo" /><%=WE_Project.BLL.Reward.List["MJB"].RewardName %>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input class="btn btn-success" id="btnOK" type="button" runat="server" value="提交"
                            onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#txtSQMoneyGet').val().Trim() == "") {
                v5.error('获得帮助金额不能为空', '1', 'true');
                return;
            }
            else {
                var reg1 = /^\d+$/;
                if (!reg1.test(parseInt($('#txtSQMoneyGet').val()))) {
                    v5.error('获得帮助金额应该为正数', '1', 'true');
                    return;
                }
            }
            verifypsd(function () {
                $.ajax({
                    type: 'post',
                    url: '/Mafull/GetHelp.aspx?Action=add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        info = info.split('*')[1];
                        if (info == 0) {
                            v5.alert('24小时内匹配成功，请在收到款后6小时内确认', '2', 'true');
                            setTimeout(function () {
                                v5.clearall();
                                callhtml('../Mafull/GetHelpList.aspx', '获得帮助列表');
                            }, 2000);
                        }
                        else {
                            v5.alert(info, '2', 'true');
                        }
                    }
                });
            });
        }
    </script>
</body>
</html>
