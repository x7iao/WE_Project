<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HBToJBChange.aspx.cs" Inherits="WE_Project.Web.ChangeMoney.HBToJBChange"
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
                    <td align="right">
                        <span>
                            <%=WE_Project.BLL.Reward.List["MHB"].RewardName%>：</span>
                    </td>
                    <td>
                        <%=TModel.MConfig.MHB%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>
                            <%=WE_Project.BLL.Reward.List["MCW"].RewardName%>：</span>
                    </td>
                    <td>
                        <%=TModel.MConfig.MCW%>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        <span>
                            <%=WE_Project.BLL.Reward.List["MGP"].RewardName%>：</span>
                    </td>
                    <td>
                        <%=TModel.MConfig.MGP%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>转换数量：</span>
                    </td>
                    <td>
                        <input name="txtMHB" id="txtMHB" class="normal_input" type="text" maxlength="6" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>类型：</span>
                    </td>
                    <td>
                        <select id="ddlFrom" runat="server">
                            <option value="MHB">互助币</option>
                            <option value="MCW">回馈币</option>
                        </select>
                        转换为<select id="ddlTo" runat="server">
                            <option value="MGP">排单币</option>
                        </select>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        <span>验证身份证号：</span>
                    </td>
                    <td>
                        <input name="txtNumID" id="txtNumID" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#txtMHB').val().Trim() == "") {
                v5.error('转换金额不能为空', '1', 'true');
            } else if (!$('#txtMHB').val().TryInt()) {
                v5.error('转换金额应该为整数', '1', 'true');
            } else if (!$('#txtMHB').val().TryInt()) {
                v5.error('转换金额应该为整数', '1', 'true');
                //            } else if ($('#ddlFrom').val() == "MJB" && $('#ddlTo').val() == "MJB") {
                //                v5.error('电子币之间不能互转', '1', 'true');
                //            } else if ($('#ddlFrom').val() == "MJB" && $('#ddlTo').val() == "MCW") {
                //                v5.error('电子币不能转购物币', '1', 'true');
            } else {
                verifypsd(function () {
                    $.ajax({
                        type: 'post',
                        url: '/ChangeMoney/HBToJBChange.aspx?Action=add',
                        data: $('#form1').serialize(),
                        success: function (info) {
                            if (info == "1") {
                                v5.alert('币种转换成功', '2', 'true');
                                setTimeout(function () {
                                    v5.clearall();
                                    callhtml('../ChangeMoney/HBToJBChange.aspx', '货币转换');
                                }, 1000);

                            }
                            else {
                                v5.alert(info, '2', 'true');
                            }
                        }
                    });
                });
            }
        }
    </script>
</body>
</html>
