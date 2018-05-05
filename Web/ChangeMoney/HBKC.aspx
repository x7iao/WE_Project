<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HBKC.aspx.cs" Inherits="WE_Project.Web.ChangeMoney.HBKC"
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
                    <td width="35%" align="right">
                        <span>会 员ID：</span>
                    </td>
                    <td>
                        <input id="txtMID" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>扣除金额:</span>
                    </td>
                    <td>
                        <input name="txtMHB" id="txtMHB" class="normal_input" type="text" maxlength="6" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>扣费钱包：</span>
                    </td>
                    <td>
                        <input id="rdoMHB" value="MHB" type="radio" name="rdo" checked="checked" /><%=WE_Project.BLL.Reward.List["MHB"].RewardName %><input
                            id="rdoMJB" value="MJB" type="radio" name="rdo" /><%=WE_Project.BLL.Reward.List["MJB"].RewardName %><input
                                id="rdoMGP" value="MGP" type="radio" name="rdo" /><%=WE_Project.BLL.Reward.List["MGP"].RewardName %>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input class="pay_ok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#txtMHB').val().Trim() == "") {
                v5.error('充值金额不能为空', '1', 'true');
                return;
            }
            else {
                var reg1 = /^\d+$/;
                if (!reg1.test(parseInt($('#txtMHB').val()))) {
                    v5.error('充值金额应该为正数', '1', 'true');
                    return;
                }
            } if (RunAjaxGetKey('getMName', $('#txtMID').val()) == '') {
                v5.error('不存在购买会员', '1', 'true');
                return;
            }
            ActionModel("/ChangeMoney/HBKC.aspx?Action=add", $('#form1').serialize());
        }
    </script>
</body>
</html>
