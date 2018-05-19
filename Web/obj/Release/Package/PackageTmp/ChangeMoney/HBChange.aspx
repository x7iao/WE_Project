<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HBChange.aspx.cs" Inherits="WE_Project.Web.ChangeMoney.HBChange"
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
                        <span>转出会员：</span>
                    </td>
                    <td>
                        <input id="txtFromMID" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <%--<tr>
                    <td align="right">
                        <span>
                            <%=WE_Project.BLL.Reward.List["MJB"].RewardName%>余额：</span>
                    </td>
                    <td>
                        <lable id="txtMJB"><%=TModel.MConfig.MJB %></lable>
                        <%if (TModel.Role.IsAdmin)
                          { %><input type="button" class="btn btn-info" value="查询" onclick="findMJB()" /><%} %>
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">
                        <span>
                            <%=WE_Project.BLL.Reward.List["MGP"].RewardName%>余额：</span>
                    </td>
                    <td>
                        <lable id="txtMGP"><%=TModel.MConfig.MGP %></lable>
                        <%if (TModel.Role.IsAdmin)
                          { %><input type="button" class="btn btn-info" value="查询" onclick="FindMGP()" /><%} %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>转入会员：</span>
                    </td>
                    <td>
                        <input id="txtMID" runat="server" class="normal_input" type="text" onchange="getName();" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>会员昵称：</span>
                    </td>
                    <td>
                        <input id="txtMName" readonly="readonly" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>转账类型：</span>
                    </td>
                    <td>
                        <%--<input id="Radio1" type="radio" value="1" name="RioHK" checked="checked" />
                        <%=WE_Project.BLL.Reward.List["MJB"].RewardName%>--%>
                        <input id="RioJB" type="radio" value="2" name="RioHK" checked="checked" />
                        <%=WE_Project.BLL.Reward.List["MGP"].RewardName%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>转账金额：</span>
                    </td>
                    <td>
                        <input name="txtMHB" id="txtMHB" class="normal_input" type="text" maxlength="6" onchange="setMoney()" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                        <div id="divTips" runat="server" style="color: Red">
                            您的账号暂不能转账，请联系管理员！</div>
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function setMoney() { 
              var mhb=$("#txtMHB").val()*<%=WE_Project.BLL.Configuration.Model.OutFloat %>;
                  $("#spMoney").html(mhb);
        }

        function checkChange() {
            var reg1 = /^\d+$/;
            if ($('#txtMHB').val().Trim() == "") {
                v5.error('转账金额不能为空', '1', 'true');
            } else if (!$('#txtMHB').val().TryInt()) {
                v5.error('转账金额应该为整数', '1', 'true');
            } else if (RunAjaxGetKey('getMName', $('#txtMID').val()) == '') {
                v5.error('不存在转入会员', '1', 'true');
            } else if (RunAjaxGetKey('getMName', $('#txtFromMID').val()) == '') {
                v5.error('不存在转出会员', '1', 'true');
            } else if ($('#txtFromMID').val() == $('#txtMID').val()) {
                v5.error('不能自己给自己转账', '1', 'true');
            }
//            else if (!isCanChangeByMember()) {
//                v5.error('转出会员与转入会员没有推荐关系，不能转账', '2', 'true');
//            }
            else {
                verifypsd(function () {
                    $.ajax({
                        type: 'post',
                        url: '/ChangeMoney/HBChange.aspx?Action=add',
                        data: $('#form1').serialize(),
                        success: function (info) {
                            if (info == "1") {
                                v5.alert('转账成功', '2', 'true');
                                setTimeout(function () {
                                    v5.clearall();
                                    callhtml('../ChangeMoney/HBChange.aspx', '会员转账');
                                }, 1000);
                            }
                            else {
                                v5.alert(info, '2', 'true');
                            }
                        }
                    });
                });
//                ActionModel("/ChangeMoney/HBChange.aspx?Action=add", $('#form1').serialize());
            }
        }
        //转账只能转给有推荐关系的会员之间转账,该函数校验转出会员与转入会员之间是否有推荐或被推荐关系
        function isCanChangeByMember() {
            var fromMID = $('#txtFromMID').val().Trim();
            var toMID = $('#txtMID').val().Trim();
            var result = GetAjaxString("isCanChangeByMember", fromMID + "|" + toMID);
            if (result == "1")
                return true;
            else
                return false;
        }

        function getName() {
            $("#txtMName").val(RunAjaxGetKey('getMName', $('#txtMID').val()));
        }

        function findMJB() {
            if (RunAjaxGetKey('getMName', $('#txtFromMID').val()) == '') {
                v5.error('不存在转出会员', '1', 'true');
            } else {
                $('#txtMJB').html(RunAjaxGetKey('FindMJB', $('#txtFromMID').val()));
            }
        }

        function FindMGP() {
            if (RunAjaxGetKey('getMName', $('#txtFromMID').val()) == '') {
                v5.error('不存在转出会员', '1', 'true');
            } else {
                $('#txtMGP').html(RunAjaxGetKey('FindMGP', $('#txtFromMID').val()));
            }
        }
    </script>
</body>
</html>
