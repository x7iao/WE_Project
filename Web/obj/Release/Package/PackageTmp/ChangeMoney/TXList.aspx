<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TXList.aspx.cs" Inherits="WE_Project.Web.ChangeMoney.TXList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        tState = 'false';
        tUrl = '/Handler/TXList.ashx';
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('false',this);" class="btn btn-danger">未审核</a><a
                    href="javascript:void(0)" onclick="SearchByState('true',this);" class="btn btn-success">已审核</a></div>
            <div class="pay" onclick="v5.show('ChangeMoney/TXChange.aspx','申请提现','url',620,400)">
                申请提现</div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" placeholder="请输入会员账号"   type="text" class="sinput" />
                <input type="text" name="txtKey" id="endDate" placeholder="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                <input type="text" name="txtKey" id="startDate" placeholder="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" /></div>
            <div class="cheeckbox" style="float:right;">
                <table cellpadding="0" cellspacing="0" style=" width:100px">
                    <tr>
                        <td>
                            <label>
                                累计提现：</label>
                        </td>
                        <td>
                            <%=TModel.MConfig.TotalTXMoney %>
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
                        开户行
                    </th>
                    <th>
                        支行
                    </th>
                    <th>
                        户名
                    </th>
                    <th>
                        卡号
                    </th>
                    <th>
                        提现
                    </th>
                    <%--<th>
                        手续费
                    </th>--%>
                 <%--   <th>
                        实发
                    </th>--%>
                    <th>
                        金额
                    </th>
                    <th>
                        是否批准
                    </th>
                    <th>
                        日期
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <span id="DivOperation" runat="server"><a href="javascript:void(0);" title="" onclick="RunAjaxByList('false','SHTX',',');">
                        审核</a></span><a href="javascript:void(0);" title="删除" onclick="RunAjaxByList('false','DeleteChangeMoney',',');">删除</a>
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
