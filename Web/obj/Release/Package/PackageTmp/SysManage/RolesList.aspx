<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RolesList.aspx.cs" Inherits="WE_Project.Web.SysManage.RolesList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = '/Handler/RolesList.ashx';
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="pay" onclick="UpDateByID('SysManage/ModifyRoles.aspx?','修改角色',680,200)">
                修改</div>
            <div class="pay" onclick="v5.show('SysManage/AddRoles.aspx','添加角色','url',680,200)">
                添加</div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                <tr>
                    <th width="80px">
                        全选
                    </th>
                    <th>
                        序号
                    </th>
                    <th>
                        角色编码
                    </th>
                    <th>
                        角色名称
                    </th>
                    <th>
                        管理员权限
                    </th>
                    <th>
                        超级管理员
                    </th>
                    <th>
                        激活权限
                    </th>
                    <th>
                        登录权限
                    </th>
                    <th>
                        留言处理
                    </th>
                    <th>
                        颜色
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn" id="DivDelete" runat="server">
                </div>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
