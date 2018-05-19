<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatchView.aspx.cs" Inherits="WE_Project.Web.Mafull.MatchView" %>

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
                    <td width="33%" align="right">
                        <span>付款编号：</span>
                    </td>
                    <td width="33%" colspan="2">
                        <%=match.MatchCode%>
                    </td>
                </tr>
                <tr>
                    <td width="13%" align="right">
                        <span>匹配时间：</span>
                    </td>
                    <td width="33%" colspan="2">
                        <%=match.MatchTime%>
                    </td>
                </tr>
                <tr>
                    <td width="13%" align="right">
                        <span>当前状态：</span>
                    </td>
                    <td width="33%" style="font-size: 16px; color: Blue;" colspan="2">
                        <%=GetMatchState(match.MatchState,match.PicUrl1)%>
                    </td>
                </tr>
                <tr>
                    <td width="13%" align="right">
                        <span>付款时间：</span>
                    </td>
                    <td width="33%" colspan="2">
                        <%=match.PayTime%>
                    </td>
                </tr>
                <tr>
                    <td width="33%" align="right">
                        <span>确认收款时间：</span>
                    </td>
                    <td width="33%" colspan="2">
                        <%=match.ConfirmTime%>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td width="33%" align="right">
                        <span>
                            <%=tdleft %>信息</span>
                    </td>
                    <td width="33%">
                        <span>
                            <%=tdright %>信息</span>
                    </td>
                    <%--<td>
                        <span>
                            <%=tdright %>推荐人信息</span>
                    </td>--%>
                </tr>
                <tr>
                    <td width="33%" align="right">
                        <span>会员账号：</span> <span>
                            <%=thismodel.MID %></span>
                    </td>
                    <td width="33%">
                        <span>会员账号：</span> <span>
                            <%=model.MID %></span>
                    </td>
                    <%--<td>
                        <span>会员账号：</span> <span>
                            <%=tjmodel.MID %></span>
                    </td>--%>
                </tr>
                <tr>
                    <td width="33%" align="right">
                        <span>开户名：</span><span>
                            <%=thismodel.BankCardName%></span>
                    </td>
                    <td width="33%">
                        <span>开户名：</span><span>
                            <%=model.BankCardName%></span>
                    </td>
                    <%--<td>
                        <span>会员昵称：</span><span>
                            <%=tjmodel.MName%></span>
                    </td>--%>
                </tr>
                <tr>
                    <td width="33%" align="right">
                        <span>手机号码：</span><span>
                            <%=thismodel.Tel%></span>
                    </td>
                    <td width="33%">
                        <span>手机号码：</span><span>
                            <%=model.Tel%></span>
                    </td>
                    <%--<td>
                        <span>手机号码：</span><span>
                            <%=tjmodel.Tel%></span>
                    </td>--%>
                </tr>
                <tr>
                    <td width="33%" align="right">
                        <span>开户银行：</span><span>
                            <%=thismodel.Bank%></span>
                    </td>
                    <td width="33%">
                        <span>开户银行：</span><span>
                            <%=model.Bank%></span>
                    </td>
                    <%--<td>
                        <span>开户银行：</span><span>
                            <%=tjmodel.Bank%></span>
                    </td>--%>
                </tr>
                <tr>
                    <td width="33%" align="right">
                        <span>开户名：</span><span>
                            <%=thismodel.BankCardName%></span>
                    </td>
                    <td width="33%">
                        <span>开户名：</span><span>
                            <%=model.BankCardName%></span>
                    </td>
                    <%--<td>
                        <span>开户名：</span><span>
                            <%=tjmodel.BankCardName%></span>
                    </td>--%>
                </tr>
                <tr>
                    <td width="33%" align="right">
                        <span>开户支行：</span><span>
                            <%=thismodel.Branch%></span>
                    </td>
                    <td width="33%">
                        <span>开户支行：</span><span>
                            <%=model.Branch%></span>
                    </td>
                    <%--<td>
                        <span>开户支行：</span><span>
                            <%=tjmodel.Branch%></span>
                    </td>--%>
                </tr>
                <tr>
                    <td width="33%" align="right">
                        <span>卡号：</span><span>
                            <%=thismodel.BankNumber%></span>
                    </td>
                    <td width="33%">
                        <span>卡号：</span><span>
                            <%=model.BankNumber%></span>
                    </td>
                    <%--<td>
                        <span>卡号：</span><span>
                            <%=tjmodel.BankNumber%></span>
                    </td>--%>
                </tr>
                <tr>
                    <td width="33%" align="right">
                        <span>支付宝账号：</span><span>
                            <%=thismodel.AliPay %></span>
                    </td>
                    <td width="33%">
                        <span>支付宝账号：</span><span>
                            <%=model.AliPay%></span>
                    </td>
                    <%--<td>
                        <span>支付宝账号：</span><span>
                            <%=tjmodel.Email%></span>
                    </td>--%>
                </tr>
                <tr>
                    <td width="33%" align="right">
                        <span>微信帐号：</span><span>
                            <%=thismodel.WeChat%></span>
                    </td>
                    <td width="33%">
                        <span>微信帐号：</span><span>
                            <%=model.WeChat%></span>
                    </td>
                    <%--<td>
                        <span>支付宝账号：</span><span>
                            <%=tjmodel.Email%></span>
                    </td>--%>
                </tr>
                <tr>
                    <td width="33%" align="right">
                        <span>备注：</span>
                    </td>
                    <td width="33%" colspan="2">
                        <%=match.Remark%>
                    </td>
                </tr>
                <tr style="font-size: 18px; color: Blue; font-weight: bold;">
                    <td width="33%" align="right">
                        <span>付款金额：</span>
                    </td>
                    <td width="33%" colspan="2">
                        <%=match.MatchMoney%>颗（ <%=match.MatchMoney*2000%>元）
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td align="right" style="padding: 45px">
                        <span>凭证一：</span>
                    </td>
                    <td colspan="2">
                        <div id="tablePic1">
                            <%=string.IsNullOrEmpty(match.PicUrl) ? "" : "<img class='appImg' src='" + match.PicUrl + "'/>"%>
                        </div>
                    </td>
                </tr>
                <%if ((!string.IsNullOrEmpty(match.PicUrl1)) && (TModel.Role.IsAdmin || match.GetMID == TModel.MID))
                  { %>
                <tr>
                    <td align="right" style="padding: 45px">
                        <span>拒绝理由：</span>
                    </td>
                    <td colspan="2">
                        <div id="tablePic2" style="max-width: 500px;">
                            <%=match.PicUrl1%>
                        </div>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td align="right" style="padding: 45px">
                        <span>付款方评价：</span>
                    </td>
                    <td colspan="2">
                        <div id="Div1">
                            <%if (match.OfferPJ!=0)
                              { %>
                            <span><%=getpingjia(match.OfferPJ.ToString())%></span>
                            <%}
                              else if (TModel.MID == match.OfferMID)
                              { %>
                            <select id="ddlPicUrl2" runat="server">
                                <option value="0">请选择</option>
                                <option value="1">一星</option>
                                <option value="2">二星</option>
                                <option value="3">三星</option>
                                <option value="4">四星</option>
                                <option value="5">五星</option>
                            </select>
                            <input class="normal_btnok" id="btnOK" type="button" runat="server" value="评价" onclick="checkChange();" />
                            <%} %>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="padding: 45px">
                        <span>收款方评价：</span>
                    </td>
                    <td colspan="2">
                        <div id="Div2">
                           <%if (match.GetPJ!=0)
                              { %>
                            <span><%=getpingjia(match.GetPJ.ToString())%></span>
                            <%}
                              else if (TModel.MID == match.GetMID)
                              { %>
                            <select id="ddlPicUrl3" runat="server">
                                <option value="0">请选择</option>
                                <option value="1">一星</option>
                                <option value="2">二星</option>
                                <option value="3">三星</option>
                                <option value="4">四星</option>
                                <option value="5">五星</option>
                            </select>
                            <input class="normal_btnok" id="Button1" type="button" runat="server" value="评价" onclick="checkChange2();" />
                            <%} %>
                        </div>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                    </td>
                    <td colspan="2">
                        <a href="javascript:void(0)" class="btn btn-danger btn sm" style="text-decoration: none"
                            onclick="returnList()">返回</a>
                    </td>
                </tr>--%>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            verifypsd(function () {
                $.ajax({
                    type: 'post',
                    url: '/Mafull/MatchView.aspx?Action=add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        if (info == "1") {
                            v5.alert('评价成功', '1', 'true');
                            setTimeout(function () {
                                v5.clearall();
                                window.location.reload();
                            }, 1000);
                        } else {
                            v5.alert(info, '1', 'true');
                        }
                    }
                });
            });
        }

        function checkChange2() {
            verifypsd(function () {
                $.ajax({
                    type: 'post',
                    url: '/Mafull/MatchView.aspx?Action=Modify',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        if (info == "1") {
                            v5.alert('评价成功', '1', 'true');
                            setTimeout(function () {
                                v5.clearall();
                                window.location.reload();
                            }, 1000);
                        } else {
                            v5.alert(info, '1', 'true');
                        }
                    }
                });
            });
        }
        function returnList() {
            var returnURL = '<%=returnURL %>';
            var returnTitle = '<%=returnTitle %>';
            if (returnURL == "") {
                window.location.reload();
            }
            else
                callhtml(returnURL, returnTitle);
        }
    </script>
</body>
</html>
