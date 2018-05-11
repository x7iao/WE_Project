<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BCenterList.aspx.cs" Inherits="WE_Project.Web.Member.BCenterList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "/Handler/BCenterList.ashx";
        tState = "false";
        SearchByCondition();
        $(function () {
            $("#yishehen").click(function () {
                $(".btnDeleteIcon").show();
            });
            $("#noShenhe").click(function () {
                $(".btnDeleteIcon").hide();
            });
        })
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('false',this);" class="btn btn-danger" id="yishehen">未审核</a><a id="noShenhe"
                    href="javascript:void(0)" onclick="SearchByState('true',this);" class="btn btn-success">已审核</a></div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" placeholder="请输入会员账号"   type="text" class="sinput" />
                <input name="txtKey" style=" display:none" id="mSHKey" placeholder="请输入报单中心"   type="text" class="sinput" />
                <input id="txtMid" type="hidden" runat="server" />
                <input type="text" name="txtKey" id="endDate" placeholder="截止日期"  
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                <input type="text" name="txtKey" id="startDate" placeholder="开始日期"  
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" />
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
                        会员ID
                    </th>
                    <th>
                        会员名称
                    </th>
                 
                    <th>
                        <%=WE_Project.BLL.Reward.List["MJB"].RewardName %>
                    </th>
                    <th>
                        推荐人数
                    </th>
                    <th>
                        锁定状态
                    </th>
                    <th>
                        激活日期
                    </th>
                    <th>
                        申请级别
                    </th>
                    <th>
                        是否审核
                    </th>
                    <th>
                        申请日期
                    </th>
                     <th>
                        审核日期
                    </th>
                      <th>
                        操作
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <span id="DivOperation" runat="server"></span><a href="javascript:void(0);" class="btnDeleteIcon"
                            title="删除" onclick="RunAjaxByList('','DeleteBCenter',',');">删除</a>
                </div>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function dealApply(obj, isAgree, mid, applytype) {
            verifypsd(function () {
                var result = GetAjaxString('DealApply', mid + "&appid=" + applytype + "&isAgree=" + isAgree);
                if (result == "1") {
                    v5.error('审核成功', '1', 'true');
                    $(obj).parent().parent().find(".appleState").html("审核通过");
                    $(obj).hide();
                }
                else if (result == "1") {
                    v5.error('审核失败，请重试', '1', 'true');
                }
                else if (result == "-1") {
                    v5.error('审核失败，该区域的区域总监数量已到上限', '1', 'true');
                }
                else {
                    v5.error(result, '1', 'true');
                }
            });
        }
        function cancleApply(obj, applyType, mid, applyId) {
         verifypsd(function () {
            var result = GetAjaxString('DealApply', mid + "&appid=" + applyId + "&isAgree=0");
            if (result == "1") {
                v5.error('成功取消该会员的资格', '1', 'true');
                $(obj).parent().parent().find(".appleState").html("审核未通过");
                $(obj).hide();
            }
            else if (result == "1") {
                v5.error('取消失败，请重试', '1', 'true');
            }
            else {
                v5.error(result, '1', 'true');
            }
        });
        }
    </script>
</body>
</html>
