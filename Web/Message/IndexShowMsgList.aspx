<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexShowMsgList.aspx.cs" Inherits="WE_Project.Web.Message.IndexShowMsgList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tState = '';
        tUrl = "/Handler/IndexShowMsgList.ashx";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
           
            <div class="pay" onclick="UpDateByID('../Message/IndexShowMsg.aspx?','修改',900,470);">
                修改</div>
            <div class="pay" onclick="v5.show('../Message/IndexShowMsg.aspx','发布','url',900,470)">
                发布</div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" class="tabcolor" id="Result">
                <tr>
                    <th width="80px">
                        全选
                    </th>
                      <th width="80px">
                        序号
                    </th>
                    
                    <th>
                        发布日期
                    </th>
                    <th>
                        内容
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
