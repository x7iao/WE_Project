<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatchOfferList.aspx.cs"
    Inherits="WE_Project.Web.Mafull.MatchOfferList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        td span
        {
            color: Red;
        }
    </style>
    <script type="text/javascript">
        var matchId = '<%=matchid %>';
        $("#matchid").val(matchId);
        tUrl = "/Mafull/Handler/MatchOfferList.ashx";
        tState = "";
        SearchByCondition();

        function clearid() {
            return;
            $("#matchid").val("");
        }
        function deleteMatch(mid) {
            var relVal = RunAjaxGetKey('deleteMatch', mid);
            if (relVal == "1") {
                v5.alert('删除成功', '1', 'true');
                SearchByCondition();
            }
        }

        function viewDetail(id, title, returnURL, returnTitle) {
            callhtml('../Mafull/MatchView.aspx?id=' + id + '&returnURL=' + returnURL + '&returnTitle=' + returnTitle, '匹配详情');
        }

    </script>
</head>
<body>
    <div id="distr">
    </div>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="clearid();SearchByState('',this);" class="btn btn-danger">
                    全部</a> <a href="javascript:void(0);" onclick="SearchByState('1',this);" class="btn btn-success">
                        未付款</a> <a href="javascript:void(0);" onclick="SearchByState('2',this);" class="btn btn-success">
                            已付款</a> <a href="javascript:void(0);" onclick="SearchByState('3',this);" class="btn btn-success">
                                已确认</a>
                <input type="hidden" id="matchid" name="txtKey" />
            </div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition();" />
                <input name="txtKey" id="MatchCode" placeholder="请输入付款编号" type="text" class="sinput" />
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
                        付款编号
                    </th>
                    <th>
                        匹配金额
                    </th>
                    <th>
                        匹配时间
                    </th>
                    <th>
                        当前状态
                    </th>
                    <th>
                        付款账号
                    </th>
                    <th>
                        付款会员昵称
                    </th>
                    <th>
                        付款时间
                    </th>
                    <th>
                        收款账号
                    </th>
                    <th>
                        收款会员昵称
                    </th>
                    <th>
                        确认收款时间
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
