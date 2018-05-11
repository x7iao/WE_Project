<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HKList.aspx.cs" Inherits="WE_Project.Web.ChangeMoney.HKList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        tState = 'false';
        tUrl = '/Handler/HKList.ashx';
        SearchByCondition();
        $(function () {
            $("#showDelete").click(function () {
                $("#DivOperation").show();
            });
            $("#hideDelete").click(function () {
                $("#DivOperation").hide();
            });
        })
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0)" onclick="SearchByState('false',this);" class="btn btn-danger"
                    id="showDelete">未生效</a> <a href="javascript:void(0);" onclick="SearchByState('true',this);"
                        class="btn btn-success" id="hideDelete">已生效</a></div>
            <div class="pay" onclick="v5.show('../Member/BuyActiveCode.aspx','线下汇款单','url',680,330)">
                线下汇款单</div>
            <%--<div class="pay" onclick="callhtml('ChangeMoney/PayHB.aspx','在线充值','url',720,280)">
                在线充值</div>--%>
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
                        汇款金额
                    </th>
                    <th>
                        购买类型
                    </th>
                    <th>
                        数量
                    </th>
                    <th>
                        汇款日期
                    </th>
                    <th>
                        状态
                    </th>
                    <th>
                        备注
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <span id="DivOperation" runat="server"><a href="javascript:void(0);" title="" onclick="RunAjaxByList('false','shHKModel',',');">
                        审核</a> <a href="javascript:void(0);" title="" onclick="RunAjaxByList('false','deleteHKModel',',');">
                            删除</a></span>
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
