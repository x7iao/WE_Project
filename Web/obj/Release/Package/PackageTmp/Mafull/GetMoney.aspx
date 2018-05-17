<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetMoney.aspx.cs" Inherits="WE_Project.Web.Mafull.GetMoney" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <input id="hidId" type="hidden" runat="server" />
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">
                        <span>付款编号：</span>
                    </td>
                    <td width="35%">
                        <%=match.MatchCode%>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>付款金额：</span>
                    </td>
                    <td width="35%">
                        <%=match.MatchMoney%>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>匹配时间：</span>
                    </td>
                    <td width="35%">
                        <%=match.MatchTime%>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>付款时间：</span>
                    </td>
                    <td width="35%">
                        <%=match.PayTime%>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>剩余确认时间：</span>
                    </td>
                    <td width="35%">
                        <span id="spLeaveTime" runat="server"></span>
                    </td>
                </tr>
                <tr style="color:#000000">
                    <td width="15%" align="right">
                        <span>付款方信息：</span>
                    </td>
                    <td width="35%">
                        <table>
                            <tr>
                                <td>
                                    会员账号：<%=getMemberModel.MID%>
                                </td>
                                <%--<td>
                                    推荐人会员账号：<%=getTJMemberModel.MID%>
                                </td>--%>
                            </tr>
                            <tr>
                                <td>
                                    开户名：<%=getMemberModel.BankCardName%>
                                </td>
                                <%--<td>
                                    推荐人会员昵称：<%=getTJMemberModel.MName%>
                                </td>--%>
                            </tr>
                            <tr>
                                <td>
                                    手机号码：<%=getMemberModel.Tel%>
                                </td>
                                <%--<td>
                                    推荐人手机号码：<%=getTJMemberModel.Tel%>
                                </td>--%>
                            </tr>
                            <tr>
                                <td>
                                    开户银行：<%=getMemberModel.Bank%>
                                </td>
                                <%--<td>
                                    推荐人开户银行：<%=getTJMemberModel.Bank%>
                                </td>--%>
                            </tr>
                            <tr>
                                <td>
                                    银行支行：<%=getMemberModel.Branch%>
                                </td>
                                <%--<td>
                                    推荐人银行支行：<%=getTJMemberModel.Branch%>
                                </td>--%>
                            </tr>
                            <tr>
                                <td>
                                    银行卡号：<%=getMemberModel.BankNumber%>
                                </td>
                                <%--<td>
                                    推荐人银行卡号：<%=getTJMemberModel.BankNumber%>
                                </td>--%>
                            </tr>
                            <tr style="display:none;">
                                <td>
                                    支付宝账号：<%=getMemberModel.AliPay%>
                                </td>
                                <%--<td>
                                    推荐人支付宝账号：<%=getTJMemberModel.Email%>
                                </td>--%>
                            </tr>
                            <tr style="display:none;">
                                <td>
                                    微信帐号：<%=getMemberModel.WeChat%>
                                </td>
                                <%--<td>
                                    推荐人支付宝账号：<%=getTJMemberModel.Email%>
                                </td>--%>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>备注留言：</span>
                    </td>
                    <td width="35%">
                        <%=match.Remark%>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="padding: 45px">
                        <span>凭证一：</span>
                    </td>
                    <td>
                        <div id="tablePic1">
                            <%=string.IsNullOrEmpty(match.PicUrl) ? "" : "<img class='appImg' src='" + match.PicUrl + "'  style='max-width: 700px;'/>"%>
                        </div>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td align="right" style="padding: 45px">
                        <span>凭证二：</span>
                    </td>
                    <td>
                        <div id="tablePic2">
                            <%=string.IsNullOrEmpty(match.PicUrl1) ? "" : "<img class='appImg' src='../../Attachment/" + match.PicUrl1 + "'/>"%>
                        </div>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td align="right" style="padding: 45px;">
                        <span>给付款方评价：</span>
                    </td>
                    <td>
                        <div id="tablePi3">
                            <select id="ddlPicUrl3" runat="server">
                                <option value="1">真差劲</option>
                                <option value="2">马马虎虎</option>
                                <option value="3" selected="selected">一般</option>
                                <option value="4">很好</option>
                                <option value="5">非常棒</option>
                            </select>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        拒绝理由：
                    </td>
                    <td>
                        <textarea type="text" id="txtjujuemessage" runat="server" name="txtjujuemessage"
                            style="height: 50px; width: 500px;"></textarea>
                        <%if (string.IsNullOrEmpty(match.PicUrl1))
                          { %>
                        <input class="normal_btnok" id="Button2" type="button" runat="server" value="申请拒绝交易"
                            onclick="checkChange2();" /><%} %>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="确认收款"
                            visible="false" onclick="checkChange();" />&nbsp;
                        <%--<input class="btn btn-danger" id="Button1" type="button" runat="server" value="返回"
                            onclick="returnList();" />--%>
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if (checkForm()) {
                verifypsd(function () {
                    $.ajax({
                        type: 'post',
                        url: '/Mafull/GetMoney.aspx?Action=add',
                        data: $('#form1').serialize(),
                        success: function (info) {
                            if (info == "1") {
                                v5.alert('确认成功', '2', 'true');
                                setTimeout(function () {
                                    v5.clearall();
                                    window.location.reload();
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
        function checkChange2() {
            if ($("#txtjujuemessage").val().Trim() == "") {
                v5.error("请填写拒绝理由", '2', 'true');
                return;
            }
            else if (checkForm()) {
                verifypsd(function () {
                    $.ajax({
                        type: 'post',
                        url: '/Mafull/GetMoney.aspx?Action=modify',
                        data: $('#form1').serialize(),
                        success: function (info) {
                            if (info == "1") {
                                v5.alert('申请成功，等待处理！', '2', 'true');
                                setTimeout(function () {
                                    v5.clearall();
                                    window.location.reload();
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
        function returnList() {
            window.location.reload();
        }
    </script>
</body>
</html>
