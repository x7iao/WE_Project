<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemindMsg.aspx.cs" Inherits="WE_Project.Web.Message.RemindMsg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tState = '';
        tUrl = "/Handler/RemindMsgList.ashx";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
           
            <div class="pay" onclick="UpDateByID('../Message/RemindEdit.aspx?','修改提醒消息',900,470);">
                修改</div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" class="tabcolor" id="Result">
                <tr>
                    <th width="80px">
                        全选
                    </th>
                    <th>
                        序号
                    </th>
                    <th>
                        类型分类
                    </th>
                    <th>
                        提示消息
                    </th>
                    <th>
                        状态
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                   
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
