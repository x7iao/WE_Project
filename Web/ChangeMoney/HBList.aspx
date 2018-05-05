<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HBList.aspx.cs" Inherits="WE_Project.Web.ChangeMoney.HBList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "/Handler/HBList.ashx";
        tState = "zc";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('zc',this);" class="btn btn-danger">
                    转出记录</a>&nbsp;<a href="javascript:void(0)" onclick="SearchByState('zr',this);" class="btn btn-success">转入记录</a><%--&nbsp;<a
                        href="javascript:void(0)" onclick="SearchByState('dh',this);" class="btn btn-success">转换记录</a>--%>
            </div>
            <div class="pay" onclick="v5.show('../ChangeMoney/HBChange.aspx','会员转账','url',280,260)">
                会员转账</div>
            <%--<div class="pay" onclick="v5.show('ChangeMoney/HBToJBChange.aspx','币种转换','url',380,220)">
                币种转换</div>--%>
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
                        会员昵称
                    </th>
                    <%--<th>
                        转账数量
                    </th>--%>
                    <th>
                        金额
                    </th>
                    <th>
                        目标ID
                    </th>
                    <th>
                        会员昵称
                    </th>
                    <th>
                        状态
                    </th>
                    <th>
                        日期
                    </th>
                    <th>
                        备注
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
