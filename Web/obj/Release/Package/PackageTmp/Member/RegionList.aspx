<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegionList.aspx.cs" Inherits="WE_Project.Web.Member.RegionList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        //        tUrl = "/Handler/RegionList.ashx";
        //        tState = "false";
        //        SearchByCondition();
    </script>
    <style type="text/css">
        .listdiv
        {
            float: left;
            margin-left: 30px;
        }
        .p1
        {
            color: Red;
            font-size: 16px;
            font-weight: bolder;
        }
        .p2
        {
            color: black;
            font-size: 14px;
            font-weight: bolder;
        }
    </style>
</head>
<body>
    <form id="form1">
    <div id="mempay">
        <div class="control">
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" runat="server" onclick="Search()" />
                <input name="txtMId" runat="server" id="txtMId" placeholder="请输入玩家ID" type="text" class="sinput" />
                <input name="txtProvince" runat="server" id="txtProvince" placeholder="请输入省份" type="text" class="sinput" />
            </div>
        </div>
        <div class="ui_table" runat="server" id="contui">
            <asp:Repeater ID="rep_List" runat="server">
                <ItemTemplate>
                    <div class="listdiv">
                        <p class="p1">
                            <%#Eval("Province") %><%#Eval("Region") %>区</p>
                        <p class="p2">
                            玩家：<%#Eval("MID") %>&nbsp;QQ群：<%#Eval("MQQGroup") %></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        function Search() {
            $.ajax({
                type: 'post',
                url: '/Member/RegionList.aspx?Action=modify',
                data: $('#form1').serialize(),
                success: function (info) {
                    $("#contui").html(info);
                }
            });
        }
    </script>
</body>
</html>
