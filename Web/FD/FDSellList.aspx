<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FDSellList.aspx.cs" Inherits="WE_Project.Web.FD.FDSellList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>富达卖出记录</title>
    <script type="text/javascript">
        tState = '';
        tUrl = '/FD/Handler/FDSellList.ashx';
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('',this);" class="btn btn-danger">全部</a><a
                    href="javascript:void(0)" onclick="SearchByState('A',this);" class="btn btn-success">A盘</a><a
                        href="javascript:void(0)" onclick="SearchByState('B',this);" class="btn btn-success">B盘</a><a
                            href="javascript:void(0)" onclick="SearchByState('C',this);" class="btn btn-success">C盘</a><a
                                href="javascript:void(0)" onclick="SearchByState('D',this);" class="btn btn-success">D盘</a></div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" placeholder="请输入会员账号" type="text" class="sinput" />
                <input type="text" name="txtKey" id="endDate" placeholder="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                <input type="text" name="txtKey" id="startDate" placeholder="开始日期" onfocus="if (value =='开始日期'){value =''}"
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
                        买入数量
                    </th>
                    <th>
                        挂卖数量
                    </th>
                    <th>
                        交易价格
                    </th>
                    <th>
                        已交易数量
                    </th>
                    <th>
                        已交易金额
                    </th>
                    <th>
                        交易大厅
                    </th>
                    <th>
                        买入日期
                    </th>
                    <th>
                        卖出日期
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
