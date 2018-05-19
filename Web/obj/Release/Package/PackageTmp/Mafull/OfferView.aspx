<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfferView.aspx.cs" Inherits="WE_Project.Web.Mafull.OfferView" %>

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
                        <span>申请编号：</span>
                    </td>
                    <td width="35%">
                        <%=offer.SQCode%>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>买入许愿果金额：</span>
                    </td>
                    <td width="35%">
                        <%=offer.SQMoney%>颗（ <%=offer.SQMoney*2000%>元）
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>申请时间：</span>
                    </td>
                    <td width="35%">
                        <%=offer.SQDate%>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>匹配状态：</span>
                    </td>
                    <td width="35%">
                        <%=GetHelpState(offer.PPState)%>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>已匹配金额：</span>
                    </td>
                    <td width="35%">
                        <%=offer.MatchMoney%>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>利息天数：</span>
                    </td>
                    <td width="35%">
                        <%=offer.TotalInterestDays%>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>利息总额：</span>
                    </td>
                    <td width="35%">
                        <%=offer.TotalInterest%>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                    </td>
                    <td>
                        <a href="/Default.aspx" class="btn btn-danger btn sm" style="text-decoration: none">
                            返回</a>
                    </td>
                </tr>--%>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if (checkForm()) {
                $.ajax({
                    type: 'post',
                    url: '/Mafull/GetMoney.aspx?Action=add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        if (info == "1") {
                            v5.alert('付款提交成功，请等待收款人确认', '1', 'true');
                            setTimeout(function () {
                                v5.clearall();
                                callhtml('../Mafull/MatchGetList.aspx', '获取帮助匹配');
                            }, 1000);
                        }
                    }
                });
            }
        }
       
    </script>
</body>
</html>
