<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyTJBDList.aspx.cs" Inherits="WE_Project.Web.Member.MyTJBDList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tState = '001'
        tUrl = "/Handler/MyTJBDList.ashx";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0)" onclick="SearchByState('001',this);" class="btn btn-danger">未激活</a>
                <a href="javascript:void(0);" onclick="SearchByState('002',this);" class="btn btn-success">已激活</a>
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
                        会员昵称
                    </th>
                    <th>
                        会员级别
                    </th>
                    <%--<th>
                        QQ号码
                    </th>--%>
                    <%--<th>
                        邮箱
                    </th>--%>
                    <th>
                        手机号码
                    </th>
                    <th>
                        注册日期
                    </th>
                    <th>
                        激活日期
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle; display: none;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn" style="display:none;">
                    <a href="javascript:void(0);" title="删除" onclick="RunAjaxByList('','DeleteMemberW',',');">
                        删除</a>
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
