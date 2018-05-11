<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SHActiveCodeDetail.aspx.cs"
    Inherits="WE_Project.Web.Member.SHActiveCodeDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                        <span>申请人：</span>
                    </td>
                    <td width="35%">
                        <%=BuyActiveCodeModel.FromMID%>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>购买激活码数量：</span>
                    </td>
                    <td width="35%">
                        <%=BuyActiveCodeModel.CodeCount%>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>付款时间：</span>
                    </td>
                    <td width="35%">
                        <%=BuyActiveCodeModel.PayTime%>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>备注留言：</span>
                    </td>
                    <td width="35%">
                        <%=BuyActiveCodeModel.Remark%>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>付款凭证：</span>
                    </td>
                    <td width="35%">
                        <%=picImgs%>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="审核" onclick="checkChange();" />&nbsp;
                        <input class="btn btn-danger" id="Button1" type="button" runat="server" value="返回"
                            onclick="returnList();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function returnList() {
            callhtml('../Member/SHActiveCode.aspx', '审核激活码');
        }
        function checkChange() {
            verifypsd(function () {
                $.ajax({
                    type: 'post',
                    url: '/Member/SHActiveCodeDetail.aspx?Action=add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        if (info == "1") {
                            v5.alert('审核成功', '1', 'true');
                            setTimeout(function () {
                                v5.clearall();
                                returnList();
                            }, 1000);
                        }
                    }
                });
            });
        }
    </script>
</body>
</html>
