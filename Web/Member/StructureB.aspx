<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StructureB.aspx.cs" Inherits="WE_Project.Web.Member.StructureB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var level = 3;
        var defalutinfo = "请输入会员账号,层级";

        GetAjaxInfoB($('#txtMid').val());
    </script>
    <style type="text/css">
        .tablefilter td
        {
            width: auto; font-size:14px;
        }
        td a
        {
            color:#00CCFF; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="mempay">
        <div class="control">
            <div class="pay" style="display:none;" onclick="fullscreen()">
                全屏切换</div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="GetAjaxInfoB($('#txtMid').val())" /><input
                    id="txtMid" runat="server" value="请输入会员账号" onfocus="if (value =='请输入会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入会员账号'}" type="text" class="sinput" /><input id="txtLevel"
                        runat="server" value="3" onfocus="if (value =='层级'){value =''}" onblur="if (value ==''){value='层级'}"
                        type="text" class="sinput" style="width: 30px;" /></div>
            <div class="cheeckbox" style="display: none;">
                <table cellpadding="0" cellspacing="0">
                    <tr style="display: none;">
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        会员级别:<input id="rdoAgency" value="Agency" type="radio" name="rdoColor" checked="checked"
                                            onclick="GetAjaxInfo($('#txtMid').val())" />
                                    </td>
                                    <%=MAgencyTypeColor%></tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        称谓:<input id="RdoJXType" value="JXType" type="radio" name="rdoColor" onclick="GetAjaxInfo($('#txtMid').val())" />
                                    </td>
                                    <%=JXTypeColor%></tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        角色:<input id="rdoRole" value="Role" type="radio" name="rdoColor" onclick="GetAjaxInfo($('#txtMid').val())" />
                                    </td>
                                    <%=RoleColor%></tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="tree_table">
            <ul id="org" style="display: none">
            </ul>
            <div id="chart" class="jOrgChart">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
