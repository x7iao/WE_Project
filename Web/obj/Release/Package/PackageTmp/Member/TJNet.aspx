<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TJNet.aspx.cs" Inherits="WE_Project.Web.Member.TJNet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title></title>
    <link href="../plugin/ztree/css/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <%--<link href="../plugin/ztree/css/demo.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript">
        var level = 1;
        var defalutinfo = "�������Ա�˺�,�㼶";
        LoadZtree($('#txtMid').val());
    </script>
    <style type="text/css">
        .tablefilter td
        {
            width: auto;
            font-size: 14px;
        }
        td a
        {
            color: #00CCFF;
        }
        .node table
        {
            min-width: 80px;
        }
        #chart table
        {
            margin: auto;
        }
          .cheeckbox td label
        {
            text-align: center;
            font-size: 12px;
            color: White;
            padding-left:10px;
        }
        .tree_table table td
        {
            padding:5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="mempay">
        <div class="control">
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="���ض���" class="ssubmit btn btn-danger" onclick="callhtml('../Member/TJNet.aspx','�Ƽ�ͼ��');" />
                <input type="button" value="��ѯ" class="ssubmit btn btn-danger" onclick="LoadZtree($('#txtMid').val())" /><input
                    id="txtMid" runat="server" value="�������Ա�˺�" onfocus="if (value =='�������Ա�˺�'){value =''}"
                    onblur="if (value ==''){value='�������Ա�˺�'}" type="text" class="sinput" /></div>
            <div class="cheeckbox">
               
            </div>
        </div>
        <div class="tree_table">
         <table cellpadding="0" cellspacing="0" style="width:auto;">
                <tr>
                    <%=MAgencyTypeColor%>
                </tr>
            </table>
            <%--<div class="zTreeDemoBackground left">--%>
            <ul id="treeDemo" class="ztree">
            </ul>
            <%--</div>--%>
        </div>
    </div>
    </form>
</body>
</html>
