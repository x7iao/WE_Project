<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Findpwd.aspx.cs" Inherits="WE_Project.Web.SecurityCenter.Findpwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>
        <%=WebModel.WebTitle %></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/style.css" />
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <link type="text/css" rel="stylesheet" href="/Admin/pop/css/V5-UI.css" />
    <script src="/Admin/jquery/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            if (!placeholderSupport()) {   // 判断浏览器是否支持 placeholder
                $('[placeholder]').focus(function () {
                    var input = $(this);
                    if (input.val() == input.attr('placeholder')) {
                        input.val('');
                        input.removeClass('placeholder');
                    }
                }).blur(function () {
                    var input = $(this);
                    if (input.val() == '' || input.val() == input.attr('placeholder')) {
                        input.addClass('placeholder');
                        input.val(input.attr('placeholder'));
                    }
                }).blur();
            };
        })
        function placeholderSupport() {
            return 'placeholder' in document.createElement('input');
        }
    </script>
</head>
<body>
    <div class="web-header">
        <div class="container clearfix">
            <div class="pull-left logo">
                <a href="javascript:void(0)">
                    <img src="images/logo.png" style="height: 80px" />
                </a>
            </div>
            <nav class="pull-right">
					<%--<a href="/Regedit/Index.aspx" class="pull-right text-white" style="margin-left:15px;">注册</a>--%>
					<a href="/login.aspx" class="pull-right text-white">登陆</a>
				</nav>
        </div>
    </div>
    <div class="container">
        <div class="mainbody">
            <div class="title">
                <span>找回密码</span> <a href="/login.aspx" class="pull-right rightlink text-danger">直接登陆</a>
            </div>
            <div class="register-box">
                <form class="form-horizontal" method="post" id="form1" runat="server">
                <div class="form-group">
                    <label class="col-sm-3 control-label">
                        会员账号</label>
                    <div class="col-sm-9">
                        <input id="txtMemberMID" type="text" class="form-control" placeholder="用户名" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">
                        请选择密保问题</label>
                    <div class="col-sm-9">
                        <select id="ddlQuestion" runat="server" class="form-control">
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">
                        请填写密保答案</label>
                    <div class="col-sm-9">
                        <input id="txtAnswer" runat="server" type="text" class="form-control" placeholder="密保答案" />
                    </div>
                </div>
                <div class="form-group mt20">
                    <label class="col-sm-3 control-label">
                    </label>
                    <div class="col-sm-9">
                        <asp:Button ID="Button2" runat="server" Text="提交" OnClick="btnSubmit2_Click" CssClass="btn btn-success btn-lg width200" />
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </div>
                </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
