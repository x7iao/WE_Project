<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MMMData.aspx.cs" Inherits="WE_Project.Web.SysManage.MMMData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">
                        排单总数:
                    </td>
                    <td width="35%">
                        <%=pdtotalcount %>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        提现总数:
                    </td>
                    <td width="35%">
                        <%=txtotalcount %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        日排单金额:
                    </td>
                    <td>
                      <%=pddaymoney %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        日提现金额:
                    </td>
                    <td>
                        <%=txdaymoney %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        平台总人数:
                    </td>
                    <td>
                        <%=totalmembercount %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        日新增人数:
                    </td>
                    <td>
                       <%=daymembercount %>
                    </td>
                </tr>
                
            </table>
        </div>
    </div>
</body>
</html>