<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListInfo.aspx.cs" Inherits="WE_Project.Web.Member.ListInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "/Handler/MemberListInfo.ashx";
        tState = "";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" placeholder="会员账号或名称" onfocus="if (value =='会员账号或名称'){value =''}"
                    onblur="if (value ==''){value='会员账号或名称'}" type="text" class="sinput" style="width: 80px;" />
            </div>
            <div class="cheeckbox" style="float: left;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <select id="AgencyCode" name="txtKey" onchange="SearchByCondition()">
                                <option value="">会员级别</option>
                                <%=AgencyListStr%>
                            </select>
                        </td>
                        <td>
                            <select id="RoleCode" name="txtKey" onchange="SearchByCondition()">
                                <option value="">会员角色</option>
                                <%=RoleListStr %>
                            </select>
                            <input type="hidden" id="OnlyOnLine" name="txtKey" value="" />
                        </td>
                        <td>
                            <select id="IsClose" name="txtKey" onchange="SearchByCondition()">
                                <option value="">锁定状态</option>
                                <option value="true">已锁定</option>
                                <option value="false">未锁定</option>
                            </select>
                        </td>
                        <td>
                            <select id="IsPPLeavel" name="txtKey" onchange="SearchByCondition()">
                                <option value="">优先匹配</option>
                                <option value="0">不优先</option>
                                <option value="1">优先</option>
                            </select>
                        </td>
                    </tr>
                </table>
            </div>
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
                        会员账号
                    </th>
                    <th>
                        提供帮助总数
                    </th>
                    <th>
                        打款成功总数
                    </th>
                    <th>
                        对方未确认总数
                    </th>
                    <th>
                        获得帮助总数
                    </th>
                    <th>
                        对方未打款总数
                    </th>
                    <th>
                        确认成功总数
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <%--<a href="javascript:void(0);" title="" onclick="UpDateByIDS('Member/ShortcutSet.aspx?','快捷设置',740,280);">
                        快捷设置</a><a style="width: auto;" href="javascript:void(0);" onclick="if($('#OnlyOnLine').val()=='1') {$('#OnlyOnLine').val('');} else {$('#OnlyOnLine').val('1')};SearchByCondition();">在线[<%=OnLineCount %>人]</a>--%>
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
