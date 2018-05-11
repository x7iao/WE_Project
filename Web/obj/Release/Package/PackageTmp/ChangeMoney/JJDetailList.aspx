<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JJDetailList.aspx.cs" Inherits="WE_Project.Web.ChangeMoney.JJDetailList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "/Handler/JJDetailList.ashx";
        tState = '';
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="txtKey" placeholder="请输入奖金来源" runat="server" style="width: 150px;"
                    onfocus="if (value =='请输入奖金来源'){value =''}" onblur="if (value ==''){value='请输入奖金来源'}"
                    type="text" class="sinput" />

                <%if (TModel.Role.IsAdmin)
                  { %>
                <input name="txtKey" id="mKey" placeholder="请输入会员账号"  style="width: 150px;"   type="text" class="sinput" />
                    <%} %>

                <input type="text" name="txtKey" id="endDate" placeholder="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                <input type="text" name="txtKey" id="startDate" placeholder="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" />
            </div>
            <div class="cheeckbox" style="display:none">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <% for (int i = 0; i < list.Count; i++)
                           {%>
                        <td>
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" checked="checked" id="chk<%=list[i].RewardType %>" value="<%=list[i].RewardType %>"
                                        name="chkType" onclick="SearchByCondition();" /><%=list[i].RewardName%></label>
                            </div>
                        </td>
                        <%} %>
                    </tr>
                </table>
            </div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" class="tabcolor" id="Result">
                <tr>
                    <th width="80px">
                        全选
                    </th>
                    <th>
                        序号
                    </th>
                  
                    <% if (TModel.Role.IsAdmin)
                       { %>
                    <th>
                        会员账号
                    </th>
                    <th>
                        会员级别
                    </th>
                    <%} %>
                         <th>
                        日分红
                    </th>
                     <th>
                        结算日期
                    </th>
                         <th>
                        推荐奖
                    </th>
                      <th>
                        培育奖
                    </th>
                      <th>
                        报单奖
                    </th>
                       <th>
                        平衡奖
                    </th>
             <%--    <th>
                        网络费
                    </th>--%>

                    <th>
                        进入<%=WE_Project.BLL.Reward.List["MHB"].RewardName %>
                    </th>
                    <th>
                        进入<%=WE_Project.BLL.Reward.List["MGP"].RewardName %>
                    </th>
              
                      <%--   <th>
                        奖励类型
                    </th>
                    <th>
                        奖励来源
                    </th>--%>
                  <%--  <th>
                        状态
                    </th>--%>


                 
                      
                   
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn" runat="server" id="DivDelete">
                    <a href="javascript:void(0);" title="" onclick="RunAjaxByList('','DeleteChangeMoney',',');">
                        删除</a>
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
