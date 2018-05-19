<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfferPutScramble.aspx.cs"
    Inherits="WE_Project.Web.Mafull.OfferPutScramble" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>放单</title>
    <script type="text/javascript">
        tUrl = "/Mafull/Handler/OfferPutScramble.ashx";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="distr">
    </div>
    <div id="mempay">
        <div class="control">
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" placeholder="请输入会员账号" type="text" class="sinput" />
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
                        会员账号
                    </th>
                    <th>
                        订单编号
                    </th>
                    <th>
                        申请时间
                    </th>
                    <th>
                        买入许愿果总金额
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
            </table>
            <div style="padding-left: 20px; padding-bottom: 10px;" id="divCount" runat="server">
                <span id="countSumSp" runat="server">总数量：0；总金额：0</span>
            </div>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn" id="DivDelete" runat="server">
                    <a href="javascript:void(0);" onclick="OfferPutScramble();">放入抢单列表</a> <a href="javascript:void(0);"
                        onclick="RunAjaxByList('','DeleteOffer',',');">删除</a>
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
