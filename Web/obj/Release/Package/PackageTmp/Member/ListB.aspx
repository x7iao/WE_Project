<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListB.aspx.cs" Inherits="WE_Project.Web.Member.ListB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "/Handler/MemberListB.ashx";
        tState = "";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <% if (TModel.Role.IsAdmin)
           { %>
        <div class="control">
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" value="股东ID或名称" onfocus="if (value =='股东ID或名称'){value =''}"
                    onblur="if (value ==''){value='股东ID或名称'}" type="text" class="sinput" style="width: 80px;" />
                <input type="text" name="txtKey" id="endDate" value="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                <input type="text" name="txtKey" id="startDate" value="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" />
            </div>
        </div>
        <%} %>
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
                        子账号会员
                    </th>
                    <th>
                        子账号级别
                    </th>
                    <th>
                        报单费
                    </th>
                    <th>
                        <%=WE_Project.BLL.Reward.List["MHB"].RewardName %>
                    </th>
                    <th>
                        <%=WE_Project.BLL.Reward.List["MJB"].RewardName%>
                    </th>
                    <th>
                        <%=WE_Project.BLL.Reward.List["MCW"].RewardName%>
                    </th>
                    <th>
                        锁定状态
                    </th>
                    <th>
                        冻结状态
                    </th>
                    <th>
                        创建时间
                    </th>
                    <th>
                        进入账号
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <a href="javascript:void(0);" title="恢复密码" onclick="RunAjaxByList('','Recover',',');">
                        恢复密码</a>
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
