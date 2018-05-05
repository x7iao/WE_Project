<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DayLiuShui.aspx.cs" Inherits="WE_Project.Web.ChangeMoney.DayLiuShui" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = '/Handler/DayLiuShui.ashx';
        SearchByCondition();
    </script>
</head> 
<body>
    <div id="mempay">
        <div class="control" id="DivSearch" runat="server">
            <div class="search">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" value="请输入会员账号" onfocus="if (value =='请输入会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入会员账号'}" type="text" class="sinput" />
                <input type="text" name="txtKey" id="endDate" value="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                <input type="text" name="txtKey" id="startDate" value="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" /></div>
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
                        收入/支出
                    </th>
                    <th>
                        金额
                    </th>
                    <th>
                        是否生效
                    </th>
                    <th>
                        备注
                    </th>
                    <th>
                        日期
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
