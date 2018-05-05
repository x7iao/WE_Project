<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeView.aspx.cs" Inherits="WE_Project.Web.Message.NoticeView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>公告查看</title>
</head>
<body>
    <div id="mempay">
        <div class="widget widget-none">
            <div class="widget-body">
                <%=model.NContent %>
            </div>
        </div>
    </div>
</body>
</html>
