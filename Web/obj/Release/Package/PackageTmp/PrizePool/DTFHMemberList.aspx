<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DTFHMemberList.aspx.cs"
    Inherits="WE_Project.Web.PrizePool.DTFHMemberList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "/Handler/DTFHMemberList.ashx";
        tState = "1";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" value="请输入会员账号" onfocus="if (value =='请输入会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入会员账号'}" type="text" class="sinput" />
                <input type="text" name="txtKey" id="endDate" value="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                <input type="text" name="txtKey" id="startDate" value="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" /></div>
            <div class="cheeckbox">
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
                        报单费
                    </th>
                    <th>
                        鸿运币
                    </th>
                    <th>
                        理财包
                    </th>
                    <th>
                        出局个数
                    </th>
                    <th>
                        收益个数
                    </th>
                    <th>
                        收益金额
                    </th>
                    <th>
                        报单日期
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle; display: none;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
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
