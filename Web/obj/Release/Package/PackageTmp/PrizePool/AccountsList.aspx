<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountsList.aspx.cs" Inherits="WE_Project.Web.PrizePool.AccountsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "/Handler/AccountsList.ashx";
        tState = "001";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('001',this);" class="btn btn-danger">报单拨出</a>
                <a href="javascript:void(0);" onclick="SearchByState('005',this);" class="btn btn-success">升级拨出</a>
                <a href="javascript:void(0);" onclick="SearchByState('003',this);" class="btn btn-success">日分红</a>
           <%--     <a href="javascript:void(0);" onclick="SearchByState('007',this);" class="btn btn-success">鸿运结算</a>--%></div>
           <%-- <div class="pay" onclick="v5.show('../PrizePool/DTFHAccounts.aspx','鸿运结算','url',700,400);">
                鸿运结算</div>--%>
            <div class="pay" onclick="v5.show('../PrizePool/JTFHAccounts.aspx','日分红','url',700,400);">
                日分红</div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
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
                        结算流水
                    </th>
                    <th>
                        结算类型
                    </th>
                    <th>
                        奖金总计
                    </th>
                    <th>
                        数量总计
                    </th>
                    <th>
                        创建日期
                    </th>
                    <th>
                        结算日期
                    </th>
                    <th>
                        动作标识
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <span id="DivOperation" runat="server"></span>
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
