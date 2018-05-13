<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WE_Project.Web.Member.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "/Handler/MemberList.ashx";
        tState = "";
        SearchByCondition();
        function enterMember(MID) {
            var result = GetAjaxString("enterMember", MID);
            if (result == "1") {
                location.href = "/Default.aspx";
            }
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="pay" onclick="UpDateByID('../Member/ModifyMember.aspx?','修改会员',820,530)">
                修改会员</div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" placeholder="会员账号或名称" onfocus="if (value =='会员账号或名称'){value =''}"
                    onblur="if (value ==''){value='会员账号或名称'}" type="text" class="sinput" style="width: 130px;" />
                <input type="text" name="txtKey" id="endDate" placeholder="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                <input type="text" name="txtKey" id="startDate" placeholder="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" />
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
                        会员昵称
                    </th>
                    <th>
                        会员级别
                    </th>
                    <th>
                        <%=WE_Project.BLL.Reward.List["MHB"].RewardName %>
                    </th>
                    <th>
                        <%=WE_Project.BLL.Reward.List["MJB"].RewardName %>
                    </th>
                     <th>
                        <%=WE_Project.BLL.Reward.List["MCW"].RewardName %>
                    </th>
                    <th>
                        <%=WE_Project.BLL.Reward.List["MGP"].RewardName %>
                    </th>
                    <th>
                        <%=WE_Project.BLL.Reward.List["MJBF"].RewardName %>
                    </th>
                     <th>
                        忠诚度
                    </th>
                    <th>
                        推荐人
                    </th>
                    <th>
                        锁定状态
                    </th>
                    <th>
                        优先状态
                    </th>
                    <th>
                        注册日期
                    </th>
                    <th>
                        状态
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <a href="javascript:void(0);" title="" onclick="UpDateByIDS('Member/ShortcutSet.aspx?','快捷设置',740,280);">
                        快捷设置</a><a style="width: auto;" href="javascript:void(0);" onclick="if($('#OnlyOnLine').val()=='1') {$('#OnlyOnLine').val('');} else {$('#OnlyOnLine').val('1')};SearchByCondition();">在线[<%=OnLineCount %>人]</a>
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
