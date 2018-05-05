<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EPBuy.aspx.cs" Inherits="WE_Project.Web.EP.EPBuy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EP买入</title>
    <script type="text/javascript">
        tState = '';
        tUrl = '/EP/Handler/EPBuy.ashx';
        SearchByCondition();
    </script>
</head>
<body>
    <div id="distr">
    </div>
    <div id="mempay">
        <div class="control">
            <div class="select">
              <%--  <a href="javascript:void(0);" onclick="SearchByState('',this);" class="btn btn-danger">
                    全部</a>&nbsp;<a href="javascript:void(0)" onclick="SearchByState('0-300',this);" class="btn btn-success">0~300</a>&nbsp;<a
                        href="javascript:void(0)" onclick="SearchByState('301-600',this);" class="btn btn-success">301~600</a>&nbsp;<a
                            href="javascript:void(0)" onclick="SearchByState('601-900',this);" class="btn btn-success">600~900</a>&nbsp;<a
                                href="javascript:void(0)" onclick="SearchByState('901-1200',this);" class="btn btn-success">901-1200</a>&nbsp;<a
                                href="javascript:void(0)" onclick="SearchByState('1201',this);" class="btn btn-success">1200以上</a>&nbsp;
                                --%>
                                <a    href="javascript:void(0)" onclick="callhtml('../EP/EPMarket.aspx','买入记录');" class="btn btn-info"
                                    style="margin-left: 50px">我的买入记录</a>
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit btn btn-success" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" placeholder="请输入会员账号" type="text" class="sinput" style=" width:100px" />
                <input type="text" name="txtKey" id="startDate" placeholder="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" />
                <input type="text" name="txtKey" id="endDate" placeholder="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" /></div>
        </div>
        <div class="ui_table">
            <div style="padding: 10px; font-size: 16px; color: Red;">
                买入后请在三个小时以内付款，以免影响信誉</div>
            <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                <tr>
                    <th width="80px">
                        全选
                    </th>
                    <th>
                        序号
                    </th>
                    <th>
                        卖方
                    </th>
                    <th>
                        信用等级
                    </th>
                 <%--   <th>
                        交易
                    </th>--%>
                    <th>
                        金额
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
                        挂单日期
                    </th>
                    <th>
                        操作
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
