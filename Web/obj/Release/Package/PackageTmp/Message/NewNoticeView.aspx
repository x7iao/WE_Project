<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewNoticeView.aspx.cs" Inherits="WE_Project.Web.Message.NewNoticeView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>公告查看</title>
    <link href="../Admin/pop/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../Admin/pop/js/jquery.min.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/ajax.js" type="text/javascript"></script>
    <script src="../Admin/pop/js/javascript_pop.js" type="text/javascript"></script>
      <script type="text/javascript">
          function choiceIcon() {
              closelay();
          }
          function closelay() {
              var index = parent.layer.getFrameIndex(window.name);
              parent.layer.close(index);
          }
          function alreadyRead() {
              $.ajax({
                  type: 'post',
                  url: '/Message/NewNoticeView.aspx?Action=add',
                  data: 'nid=<%=model.ID %>',
                  success: function (info) {
                      if (info == "1") {
                          setTimeout(function () {
                              closelay();
                          }, 1000);
                      }
                      else {
                          alert("已阅失败，请重试");
                      }
                  }
              });
          }

    </script>
</head>
<body style=" background:#E8F7F9">
    <div id="mempay">
        <div class="widget widget-none" style="padding:20px">
            <div class="widget-body">
                <%=model.NContent %>
            </div>
            <div style=" text-align:center">
            <input type="button" class="btn btn-success" value="已阅" onclick="alreadyRead()" />&emsp;
            <input type="button" onclick="choiceIcon()" class="btn btn-danger" value="关闭" />
            </div>
        </div>
    </div>
</body>
</html>
