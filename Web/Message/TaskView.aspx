<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskView.aspx.cs" Inherits="WE_Project.Web.Message.TaskView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>信息查看</title>
    <style type="text/css">
        .appDiv
        {
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <input type="hidden" id="hidIndex" value="" />
            <table cellpadding="0" cellspacing="0">
                <%if (TModel.Role.IsAdmin)
                  { %>
                <tr>
                    <td width="25%" align="right">
                        发送人：
                    </td>
                    <td width="75%" style="height: 40px;">
                        <span id="spSendMan" runat="server"></span>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td align="right">
                        留言类型
                    </td>
                    <td>
                        <span id="spTaskType" runat="server"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        留言时间
                    </td>
                    <td>
                        <span id="spdate" runat="server"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        留言内容：
                    </td>
                    <td>
                        <span id="spContent" runat="server"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        附件信息：
                    </td>
                    <td>
                        <div id="tablePic1" runat="server">
                        </div>
                    </td>
                </tr>
                <%
                    if (isReply)
                    {
                %>
                <%if (TModel.Role.IsAdmin)
                  { %>
                <tr>
                    <td width="25%" align="right">
                        回复人：
                    </td>
                    <td width="75%" style="height: 40px;">
                        <span id="RespSendMan" runat="server"></span>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td align="right">
                        回复类型
                    </td>
                    <td>
                        <span id="RespTaskType" runat="server"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        回复时间
                    </td>
                    <td>
                        <span id="Respdate" runat="server"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        回复内容：
                    </td>
                    <td>
                        <span id="RespContent" runat="server"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        附件信息：
                    </td>
                    <td>
                        <div id="RetablePic1" runat="server">
                        </div>
                    </td>
                </tr>
                <%
                    }
                %>
                <tr style="height: 40px;">
                    <td align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                    </td>
                    <td>
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="返回" onclick="returnList();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function returnList() {
            callhtml('../Message/TaskList.aspx', '留言管理');
        }
    </script>
</body>
</html>
