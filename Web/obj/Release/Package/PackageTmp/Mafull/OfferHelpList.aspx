<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfferHelpList.aspx.cs"
    Inherits="WE_Project.Web.Mafull.OfferHelpList" %>

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
        tUrl = "/Mafull/Handler/OfferHelpList.ashx";
        tState = "";
        SearchByCondition();

        function MatchGetMoney(mid, obj) {
            var relVal = RunAjaxGetKey('MatchGetMoney', mid);
            if (relVal == "1") {
                v5.alert('提款成功', '1', 'true');
                SearchByCondition();
            }
            else {
                v5.alert(relVal, '1', 'true');
            }
        }

        function MatchGetLixiMoney(mid, obj) {
            var relVal = RunAjaxGetKey('MatchGetLixiMoney', mid);
            if (relVal == "1") {
                v5.alert('解冻成功', '1', 'true');
                SearchByCondition();
            }
            else {
                v5.alert(relVal, '1', 'true');
            }
        }

        function CountOrderCount(tid) {
            $.ajax({
                type: 'post',
                url: '/Mafull/OfferHelpList.aspx?Action=add&tid=' + tid,
                data: tid,
                success: function (info) {
                    $("#countSumSp").html(info);
                }
            });
        }

        function CancelOffer(id) {
            v5.confirm("确定取消申请？", function () {
                var relVal = GetAjaxString('CancelOffer', id);
                if (relVal == "1") {
                    v5.alert('取消成功', '1', 'true');
                    setTimeout(function () { window.location.reload(); }, 1000);
                }
                else {
                    v5.alert(relVal, '1', 'true');
                }
            });
        }
    </script>
</head>
<body>
    <div id="distr">
    </div>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('',this);CountOrderCount('');"
                    class="btn btn-danger">全部</a> <a href="javascript:void(0);" onclick="SearchByState('1',this);CountOrderCount('1');"
                        class="btn btn-success">等待匹配中</a> <a href="javascript:void(0);" onclick="SearchByState('2',this);CountOrderCount('2');"
                            class="btn btn-success">匹配成功</a> <a href="javascript:void(0);" onclick="SearchByState('3',this);CountOrderCount('3');"
                                class="btn btn-success">交易完成</a> <a href="javascript:void(0);" onclick="SearchByState('4',this);CountOrderCount('4');"
                                    class="btn btn-success">可取款</a>
                <%if (TModel.Role.IsAdmin)
                  { %>
                <a href="javascript:void(0);" onclick="SearchByState('5',this);CountOrderCount('5');"
                    class="btn btn-success">可以匹配</a><%} %>
            </div>
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
                        当前状态
                    </th>
                    <th>
                        排单区域
                    </th>
                    <%--<th>
                        结息天数
                    </th>--%>
                    <th>
                        援助总金额
                    </th>
                    <th>
                        已匹配金额
                    </th>
                    <th>
                        利息
                    </th>
                    <%--<th>
                        利息状态
                    </th>--%>
                    <%--<th>
                        诚信奖
                    </th>--%>
                    <%--<th>
                        奖励利息状态
                    </th>--%>
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
                    <a href="javascript:void(0);" title="" onclick="RunAjaxByList('','DeleteOffer',',');">
                        删除</a>
                </div>
                <div class="pn" runat="server" id="matchMui">
                    <input type="button" value="多人匹配" class="btn btn-success" onclick="MatchOtherPage('/Mafull/GetHelpList.aspx','提供帮助列表')" />
                </div>
                <div class="pn" runat="server" id="matchSure" visible="false">
                    <input type="button" value="确认匹配" class="btn btn-success" onclick="MatchOtherPageOffSure('<%=matchid %>')" />
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
