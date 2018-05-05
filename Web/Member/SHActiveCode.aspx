<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SHActiveCode.aspx.cs" Inherits="WE_Project.Web.Member.SHActiveCode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "/Handler/SHActiveCodeList.ashx";
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
                <a href="javascript:void(0);" onclick="SearchByState('false',this);" class="btn btn-danger"
                    id="yishehen">未审核</a><a id="noShenhe" href="javascript:void(0)" onclick="SearchByState('true',this);"
                        class="btn btn-success">已审核</a></div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" placeholder="请输入会员账号" type="text" class="sinput" />
                <input id="txtMid" type="hidden" runat="server" />
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
                        申请会员
                    </th>
                    <th>
                        申请数量
                    </th>
                    <th>
                        付款时间
                    </th>
                    <th>
                        审核时间
                    </th>
                    <th><img src="" onclick="" style="max-width:100px;" />
                        打款截图
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
                        title="审核" onclick="RunAjaxByList('','SHActiveCode',',');">审核</a><a href="javascript:void(0);"
                            class="btnDeleteIcon" title="审核" onclick="RunAjaxByList('','deleteActiveCode',',');">删除</a>
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
