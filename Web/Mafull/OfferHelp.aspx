<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfferHelp.aspx.cs" Inherits="WE_Project.Web.Mafull.OfferHelp" %>

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
                        <span>申请援助说明：</span>
                    </td>
                    <td>
                        <div>
                            <p>
                                援助额度：<%= WE_Project.BLL.MMMConfig.Model.OfferHelpMin%>-<%=WE_Project.BLL.MMMConfig.Model.OfferHelpMax%>（<%=WE_Project.BLL.MMMConfig.Model.OfferHelpBase %>的倍数）</p>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>我的<%=WE_Project.BLL.Reward.List["MGP"].RewardName %>：</span>
                    </td>
                    <td>
                        <%=TModel.MConfig.MGP.ToString("F0") %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>排单区域：</span>
                    </td>
                    <td>
                      <select id="offerrdo" runat="server">
                                                    <option value="0">正常排单</option>
                                                    <option value="1">抢单区排单（不消耗排单币）</option>
                                                </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>申请援助金额：</span>
                    </td>
                    <td>
                        <input type="text" runat="server" id="txtSQMoneyOff" style="width: 100px" />
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
            if ($('#txtSQMoneyOff').val().Trim() == "") {
                v5.error('提供帮助金额不能为空', '1', 'true');
                return;
            }
            else {
                var reg1 = /^\d+$/;
                if (!reg1.test(parseInt($('#txtSQMoneyOff').val()))) {
                    v5.error('提供帮助金额应该为正数', '1', 'true');
                    return;
                }
            }
            verifypsd(function () {
                $.ajax({
                    type: 'post',
                    url: '/Mafull/OfferHelp.aspx?Action=add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        info = info.split('*')[1];
                        if (info == 0) {
                            v5.alert('提供帮助成功，请等待匹配', '2', 'true');
                            setTimeout(function () {
                                v5.clearall();
                                callhtml('../Mafull/OfferHelpList.aspx', '提供帮助列表 ');
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
