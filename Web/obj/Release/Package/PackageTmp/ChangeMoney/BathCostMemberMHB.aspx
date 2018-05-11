<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BathCostMemberMHB.aspx.cs" Inherits="WE_Project.Web.ChangeMoney.BathCostMemberMHB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员集体扣费或加钱</title>
     <script type="text/javascript">
         tUrl = "/Handler/MemberList.ashx";
         tState = "";
         SearchByCondition();
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
                    onblur="if (value ==''){value='会员账号或名称'}" type="text" class="sinput" style="width: 80px;" />
                <input type="text" name="txtKey" id="endDate" placeholder="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                <input type="text" name="txtKey" id="startDate" placeholder="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" />
            </div>
            <div class="cheeckbox" style="float: left;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td  style=" display:none">
                            <select id="AgencyCode" name="txtKey" onchange="SearchByCondition()">
                                <%=AgencyListStr%>
                            </select>
                        </td>
                         
                        <td>
                            <select id="IsClose" name="txtKey" onchange="SearchByCondition()">
                                <option value="">锁定状态</option>
                                <option value="true">已锁定</option>
                                <option value="false">未锁定</option>
                            </select>
                        </td>
                        <td>
                            <select id="IsClock" name="txtKey" onchange="SearchByCondition()">
                                <option value="">冻结状态</option>
                                <option value="true">已冻结</option>
                                <option value="false">未冻结</option>
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
                        推荐人
                    </th>
                    <th>
                        锁定状态
                    </th>
                    <th>
                        冻结状态
                    </th>
                    <th>
                        激活日期
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                      <a href="javascript:void(0);" title="" onclick="RunAjaxToCostMHBByList('false','costMHB',',');">
                            操作</a>
                </div>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
    </script>
</body>
</html>
