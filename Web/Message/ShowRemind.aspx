<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowRemind.aspx.cs" Inherits="WE_Project.Web.Message.ShowRemind" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>提示信息</title>
    <link href="../Admin/pop/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body style=" background:#E8F7F9">
    <div id="mempay">
        <div class="widget widget-none" style="padding:20px">
            <div class="widget-body">
                <%=model.RemindMsg%>
            </div>
        </div>
    </div>
</body>
</html>
