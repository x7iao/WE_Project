<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JJList.aspx.cs" Inherits="WE_Project.Web.ChangeMoney.JJList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var date = "<%=date %>";
        $("#countdate").val(date);
        var mKey = "<%=mKey %>";
        $("#mKey").val(mKey);
        tUrl = "/Handler/JJList.ashx";
        tState = '';
        SearchByCondition();
        function TQJJ(id) {
            var relVal = RunAjaxGetKey('TQJJ', id);
            if (relVal == "1") {
                v5.alert('提取成功', '1', 'true');
                SearchByCondition();
            }
            else {
                v5.alert(relVal, '1', 'true');
            }
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('',this);" class="btn btn-danger">
                    全部</a> <a href="javascript:void(0);" onclick="SearchByState('R_TJ',this);" class="btn btn-success">
                        推荐奖</a> <a href="javascript:void(0);" onclick="SearchByState('R_GL',this);" class="btn btn-success">
                            管理奖</a> <a href="javascript:void(0);" onclick="SearchByState('TJKF',this);" class="btn btn-success">
                                不打款扣费</a>
                <input type="hidden" name="txtKey" id="countdate" />
                <input name="txtKey" id="mKey" type="hidden" class="sinput" />
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <%--  <input name="txtKey" id="mKey" placeholder="请输入会员账号" style="width: 150px;" onfocus="if (value =='请输入会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入会员账号'}" type="text" class="sinput" />--%>
                <input type="text" name="txtKey" id="endDate" placeholder="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                <input type="text" name="txtKey" id="startDate" placeholder="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" />
            </div>
            <div class="cheeckbox" style="display: none;">
                <table cellpadding="0" cellspacing="0" style="width: auto;">
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
                        奖金合计
                    </th>
                    <%--<th>
                        已解冻
                    </th>--%>
                    <th>
                        类型
                    </th>
                    <th>
                        备注
                    </th>
                    <th>
                        状态
                    </th>
                    <th>
                        日期
                    </th>
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
