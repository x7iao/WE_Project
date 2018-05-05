<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EPMarket.aspx.cs" Inherits="WE_Project.Web.EP.EPMarket" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EP我的市场</title>
    <script type="text/javascript">
        tState = '';
        tUrl = '/EP/Handler/EPMarket.ashx';
        SearchByCondition();
    </script>
</head>
<body>
    <div id="distr">
    </div>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('',this);" class="btn btn-danger">
                    全部</a> <a href="javascript:void(0);" onclick="SearchByState('1',this);" class="btn btn-success">
                        未付款</a> <a href="javascript:void(0);" onclick="SearchByState('2',this);" class="btn btn-success">
                            卖家未确认</a> <a href="javascript:void(0);" onclick="SearchByState('3',this);" class="btn btn-success">
                                已完成</a> <a href="javascript:void(0)" onclick="SearchByState('4',this);" class="btn btn-success">
                                    已关闭</a> <a href="javascript:void(0)" onclick="callhtml('../EP/EPBuy.aspx','我要买入');"
                                        class="btn btn-purple" style="margin-left: 50px">我要买入</a>
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input type="text" name="txtKey" id="startDate" placeholder="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" />
                <input type="text" name="txtKey" id="endDate" placeholder="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" /></div>
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
                        交易类型
                    </th>
                    <th>
                        交易数量
                    </th>
                    <th>
                        等额现金
                    </th>
                    <th>
                        挂单日期
                    </th>
                    <th>
                        卖家
                    </th>
                    <th>
                        卖家信誉
                    </th>
                    <th>
                        卖家开户银行
                    </th>
                    <th>
                        开户支行
                    </th>
                    <th>
                        银行账号
                    </th>
                    <th>
                        开户姓名
                    </th>
                    <th>
                        买入日期
                    </th>
                    <th>
                        状态
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
