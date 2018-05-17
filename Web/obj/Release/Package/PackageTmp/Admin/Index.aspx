<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WE_Project.Web.Admin.Index" %>

<!DOCTYPE html>
<!--[if IE 9 ]><html class="ie9"><![endif]-->
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <meta name="format-detection" content="telephone=no">
    <meta charset="UTF-8">
    <meta name="description" content="Violate Responsive Admin Template">
    <meta name="keywords" content="Super Admin, Admin, Template, Bootstrap">
    <title><%=WebModel.WebTitle %></title>

    <!-- CSS -->
    <link href="/Admin/css/bootstrap.min.css" rel="stylesheet">
    <link href="/Admin/css/animate.min.css" rel="stylesheet">
    <link href="/Admin/css/font-awesome.min.css" rel="stylesheet">
    <link href="/Admin/css/form.css" rel="stylesheet">
    <link href="/Admin/css/calendar.css" rel="stylesheet">
    <link href="/Admin/css/style.css" rel="stylesheet">
    <link href="/Admin/css/icons.css" rel="stylesheet">
    <link href="/Admin/css/generics.css" rel="stylesheet">

    <link type="text/css" rel="stylesheet" href="/admin/pop/css/next_page_search.css" />
    <link rel="stylesheet" type="text/css" href="/admin/pop/css/V5-UI.css" />

    <script src="/Admin/js/jquery-1.9.1.min.js"></script>
    <style>
        #OfferHelp table tr {
            line-height: 2;
        }
    </style>
</head>
<body id="skin-blur-violate">

    <header id="header" class="media">
        <a href="" id="menu-toggle"></a>
        <a class="logo pull-left" href="#">
            <img src="/admin/img/meitu_2.png" width="50" style="margin-top: -10px;" /></a>

        <div class="media-body">
            <div class="media" id="top-menu">
                <div class="pull-left tm-icon">
                    <a data-drawer="messages" class="drawer-toggle" href="">
                        <i class="sa-top-message"></i>
                        <i class="n-count animated">5</i>
                        <span>新消息</span>
                    </a>
                </div>
                <div class="pull-left tm-icon">
                    <a data-drawer="notifications" class="drawer-toggle" href="">
                        <i class="sa-top-updates"></i>
                        <i class="n-count animated">9</i>
                        <span>打款或收款</span>
                    </a>
                </div>



                <div id="time" class="pull-right">
                    <span id="hours"></span>
                    :
                        <span id="min"></span>
                    :
                        <span id="sec"></span>
                </div>

                <%--   <div class="media-body">
                    <input type="text" class="main-search">
                </div>--%>
            </div>
        </div>
    </header>

    <div class="clearfix"></div>

    <section id="main" class="p-relative" role="main">

        <!-- Sidebar -->
        <aside id="sidebar">

            <!-- Sidbar Widgets -->
            <div class="side-widgets overflow">
                <!-- Profile Menu -->
                <div class="text-center s-widget m-b-25 dropdown" id="profile-menu">
                    <a href="" data-toggle="dropdown">
                        <img class="profile-pic animated" src="/Admin/img/profile-pic.jpg" alt="">
                    </a>
                    <ul class="dropdown-menu profile-menu">
                        <li><a href="javascript:void(0)" onclick="callhtml('../Member/View.aspx','个人信息');">个人信息</a> <i class="icon left">&#61903;</i><i class="icon right">&#61815;</i></li>
                        <li><a href="javascript:void(0)" onclick="callhtml('../SecurityCenter/ModifyPwd.aspx','登录密码修改');">设置登陆密码</a> <i class="icon left">&#61903;</i><i class="icon right">&#61815;</i></li>
                        <li><a href="javascript:void(0)" onclick="callhtml('../SecurityCenter/ModifySecPwd.aspx','二级密码修改');">设置二级密码</a> <i class="icon left">&#61903;</i><i class="icon right">&#61815;</i></li>
                        <li><a href="/SysManage/Out.aspx">退出登陆</a> <i class="icon left">&#61903;</i><i class="icon right">&#61815;</i></li>
                    </ul>
                    <h4 class="m-0"><%=TModel.MID %><%=string.IsNullOrEmpty(TModel.ActiveCode)?"":"<span style='color:red; font-weight:bolder;'>【"+TModel.ActiveCode+"】</span>" %></h4>
                    <%=TModel.MName %>
                </div>

                <!-- Calendar -->
                <div class="s-widget m-b-25">
                    <div id="sidebar-calendar"></div>
                </div>

                <!-- Feeds -->
                <%-- <div class="s-widget m-b-25">
                    <h2 class="tile-title">News Feeds
                    </h2>

                    <div class="s-widget-body">
                        <div id="news-feed"></div>
                    </div>
                </div>--%>

                <!-- Projects -->
                <div class="s-widget m-b-25">
                    <h2 class="tile-title">许愿台
                    </h2>

                    <div class="s-widget-body">

                        <%
                            int index = 0;
                            for (int i = 0; i < dtxxfloat.Rows.Count; i++)
                            {
                                index++;
                        %>
                        <div class="side-border">
                            <small>第<%=index %>单未出局</small>
                            <div class="progress progress-small">
                                <a href="#" data-toggle="tooltip" title="" class="progress-bar tooltips progress-bar-danger" style="width: <%=dtxxfloat.Rows[i]["xxfloat"]%>%;" data-original-title="<%=dtxxfloat.Rows[i]["xxfloat"]%>%">
                                    <span class="sr-only"><%=dtxxfloat.Rows[i]["xxfloat"]%>% 进度</span>
                                </a>
                            </div>
                        </div>
                        <%
                            }
                        %>



                        <%-- <div class="side-border">
                            <small>Chrome Extension</small>
                            <div class="progress progress-small">
                                <a href="#" data-toggle="tooltip" title="" class="tooltips progress-bar progress-bar-success" style="width: 95%;" data-original-title="95%">
                                    <span class="sr-only">95% Complete</span>
                                </a>
                            </div>
                        </div>--%>
                    </div>
                </div>

                 <div class="s-widget m-b-25">
                    <h2 class="tile-title">忠诚度<%=TModel.MConfig.EPXingCount %>
                    </h2>

                    <div class="s-widget-body">

                      


                         <div class="side-border">
                            <small></small>
                            <div class="progress progress-small">
                                <a href="#" data-toggle="tooltip" title="" class="tooltips progress-bar progress-bar-success" style="width: <%=TModel.MConfig.EPXingCount %>%;" data-original-title="<%=TModel.MConfig.EPXingCount %>">
                                    <span class="sr-only"><%=TModel.MConfig.EPXingCount %></span>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Side Menu -->
            <ul class="list-unstyled side-menu">
                <li class="active">
                    <a class="sa-side-home" href="javascript:void(0)" onclick="location.reload()">
                        <span class="menu-item">首页</span>
                    </a>
                </li>


                <%foreach (WE_Project.Model.RolePowers item in GetPowers("0"))
                    { %>
                <li class="dropdown"><a href="javascript:void(0)" class="<%=item.Content.CImage %>"><span class="menu-item"><%=item.Content.CTitle %></span> </a>
                    <ul class="list-unstyled menu-item">
                        <%foreach (WE_Project.Model.RolePowers item2 in GetPowers(item.CID))
                            { %>
                        <li><a href="javascript:void(0)" onclick="callhtml('<%=item2.Content.CAddress %>','<%=item2.Content.CTitle %>');">
                            <%=item2.Content.CTitle%></a></li>
                        <%} %>
                    </ul>
                </li>
                <%} %>
            </ul>

        </aside>

        <!-- Content -->
        <section id="content" class="container">
            <!-- Messages Drawer -->
            <%-- <div id="messages" class="tile drawer animated">
                <div class="listview narrow">
                    <div class="media">
                        <a href="">最新公告</a>
                        <span class="drawer-close">&times;</span>
                    </div>
                    <div class="overflow" style="height: 254px">
                        <div class="media">
                            <div class="pull-left">
                                <img width="40" src="img/profile-pics/1.jpg" alt="">
                            </div>
                            <div class="media-body">
                                <small class="text-muted">Nadin Jackson - 2 Hours ago</small><br>
                                <a class="t-overflow" href="">Mauris consectetur urna nec tempor adipiscing. Proin sit amet nisi ligula. Sed eu adipiscing lectus</a>
                            </div>
                        </div>
                        <div class="media">
                            <div class="pull-left">
                                <img width="40" src="img/profile-pics/2.jpg" alt="">
                            </div>
                            <div class="media-body">
                                <small class="text-muted">David Villa - 5 Hours ago</small><br>
                                <a class="t-overflow" href="">Suspendisse in purus ut nibh placerat Cras pulvinar euismod nunc quis gravida. Suspendisse pharetra</a>
                            </div>
                        </div>
                     
                    </div>
                    <div class="media text-center whiter l-100">
                        <a href=""><small>更多</small></a>
                    </div>
                </div>
            </div>--%>

            <!-- Breadcrumb -->
            <ol class="breadcrumb hidden-xs">
                <%--<li><a href="#">Home</a></li>
                <li><a href="#">Library</a></li>--%>
                <li class="active">Data</li>
            </ol>

            <h4 class="page-title">快捷菜单</h4>

            <!-- Shortcuts -->
            <div class="block-area shortcut-area">
                <a class="shortcut tile drawer-toggle" href="javascript:void(0)" data-drawer="OfferHelp">
                    <img src="/Admin/img/shortcuts/money.png" alt="">
                    <small class="t-overflow">买入</small>
                </a>
                <%-- <a class="shortcut tile" href="">
                    <img src="/Admin/img/shortcuts/twitter.png" alt="">
                    <small class="t-overflow">Tweets</small>
                </a>--%>
                <a class="shortcut tile  drawer-toggle" href="javascript:void(0)" data-drawer="GetHelp">
                    <img src="/Admin/img/shortcuts/calendar.png" alt="">
                    <small class="t-overflow">卖出</small>
                </a>
                <a class="shortcut tile" href="JavaScript:void(0)" onclick="callhtml('../Mafull/OfferHelpList.aspx','提供帮助列表 ');">
                    <img src="/Admin/img/shortcuts/stats.png" alt="">
                    <small class="t-overflow">买入列表</small>
                </a>
                <a class="shortcut tile" href="JavaScript:void(0)" onclick="callhtml('../Mafull/GetHelpList.aspx','获得帮助列表');">
                    <img src="/Admin/img/shortcuts/connections.png" alt="">
                    <small class="t-overflow">卖出列表</small>
                </a>
                <%-- <a class="shortcut tile" href="">
                    <img src="/Admin/img/shortcuts/reports.png" alt="">
                    <small class="t-overflow">Reports</small>
                </a>--%>
            </div>

            <!--提供帮助-->
            <div id="OfferHelp" class="tile drawer animated" style="margin: 10px 10px 0;">
                <div class="listview narrow">
                    <div class="media">
                        <a href="">提供帮助</a>
                        <span class="drawer-close">&times;</span>
                    </div>
                    <div class="overflow" style="height: 254px">
                        <%-- <form id="form1">--%>
                        <table cellpadding="0" cellspacing="0" style="margin-top: 10px;">
                            <tr>
                                <td width="45%" align="right">
                                    <span>申请援助说明：</span>
                                </td>
                                <td>
                                    <div>
                                        <p>
                                            额度：<%= WE_Project.BLL.MMMConfig.Model.OfferHelpMin%>-<%=WE_Project.BLL.MMMConfig.Model.OfferHelpMax%>（<%=WE_Project.BLL.MMMConfig.Model.OfferHelpBase %>的倍数）
                                        </p>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>我的<%=WE_Project.BLL.Reward.List["MGP"].RewardName %>：</span>
                                </td>
                                <td>
                                    <%=TModel.MConfig.MGP %>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>排单区域：</span>
                                </td>
                                <td>
                                    <select id="offerrdoindex" name="offerrdoindex">
                                        <option value="0">正常排单</option>
                                        <option value="1">抢单区排单（不消耗排单币）</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>申请援助金额：</span>
                                </td>
                                <td>
                                    <input type="text" id="txtSQMoneyOffindex" name="txtSQMoneyOffindex" style="width: 100px; margin-top: 4px;" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <input class="btn btn-success" id="btnOK" type="button" runat="server" value="提交"
                                        onclick="checkofferindex();" style="margin-top: 6px;" />
                                </td>
                            </tr>
                        </table>
                        <%--</form>--%>
                    </div>

                </div>
            </div>

            <!--提供帮助-->
            <div id="GetHelp" class="tile drawer animated" style="margin: 10px 10px 0;">
                <div class="listview narrow">
                    <div class="media">
                        <a href="">获得帮助</a>
                        <span class="drawer-close">&times;</span>
                    </div>
                    <div class="overflow" style="height: 254px">
                        <%--<form id="form1">--%>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="35%" align="right">
                                        <span>我的<%=WE_Project.BLL.Reward.List["MHB"].RewardName %>：</span>
                                    </td>
                                    <td>
                                        <%=TModel.MConfig.MHB%>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="35%" align="right">
                                        <span>我的<%=WE_Project.BLL.Reward.List["MJB"].RewardName %>：</span>
                                    </td>
                                    <td>
                                        <%=TModel.MConfig.MJB%>
                                    </td>
                                </tr>
                          
                                <tr>
                                    <td width="35%" align="right">
                                        <span>我的<%=WE_Project.BLL.Reward.List["MCW"].RewardName %>：</span>
                                    </td>
                                    <td>
                                        <%=TModel.MConfig.MCW%>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="35%" align="right">
                                        <span>申请援助说明：</span>
                                    </td>
                                    <td>
                                        <div>
                                            <%--<p>
                                互助币:(<%=WE_Project.BLL.MMMConfig.Model.GetHelpMin%>-<%=WE_Project.BLL.MMMConfig.Model.GetHelpMax%>(<%=WE_Project.BLL.MMMConfig.Model.MHBBase %>的倍数))</p>
                            <p>
                                回馈币:(<%=WE_Project.BLL.MMMConfig.Model.GetHelpMin%>-<%=Math.Min(WE_Project.BLL.MMMConfig.Model.GetHelpMax, TModel.MAgencyType.DTopMoney)%>(<%=WE_Project.BLL.MMMConfig.Model.MCWBase %>的倍数))</p>
                            <p>
                                爱心币:(<%=WE_Project.BLL.MMMConfig.Model.GetHelpMin%>-<%=WE_Project.BLL.MMMConfig.Model.GetHelpMax%>(<%=WE_Project.BLL.MMMConfig.Model.MJBBase %>的倍数))</p>--%>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <span>申请金额：</span>
                                    </td>
                                    <td>
                                        <input type="text" runat="server" id="txtSQMoneygetindex" class="input-sm form-control mask-date" autocomplete="off" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="right">
                                        <span>使用钱包：</span>
                                    </td>
                                    <td>

                                        <input value="MCW" type="radio" name="getrdoindex" checked="checked" /><%=WE_Project.BLL.Reward.List["MCW"].RewardName %>
                                        <input value="MHB" type="radio" name="getrdoindex" /><%=WE_Project.BLL.Reward.List["MHB"].RewardName %>
                                        <input value="MJB" type="radio" name="getrdoindex" /><%=WE_Project.BLL.Reward.List["MJB"].RewardName %>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <input class="btn btn-success" id="Button1" type="button" runat="server" value="提交"
                                            onclick="checkgetindex();" />
                                    </td>
                                </tr>
                            </table>
                    <%--    </form>--%>

                    </div>
                    <div class="media text-center whiter l-100">
                        <%--<a href=""><small>更多</small></a>--%>
                    </div>
                </div>
            </div>


            <hr class="whiter" />

            <div id="maincontent">

                <!-- Quick Stats -->
                <div class="block-area">
                    <div class="row">
                        <div class="col-md-3 col-xs-6">
                            <div class="tile quick-stats">
                                <div id="stats-line12" class="pull-left"></div>
                                <div class="data">
                                    <h2 value="<%=TModel.MConfig.MCW %>"><%=TModel.MConfig.MCW %></h2>
                                    <small>许愿果[用来排单]</small>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3 col-xs-6">
                            <div class="tile quick-stats media">
                                <div id="stats-line12" class="pull-left"></div>
                                <div class="media-body">
                                    <h2 value="<%=TModel.MConfig.MJBF %>"><%=TModel.MConfig.MJBF %></h2>
                                    <small>许愿台[用来理财]</small>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3 col-xs-6">
                            <div class="tile quick-stats media">

                                <div id="stats-line12" class="pull-left"></div>

                                <div class="media-body">
                                    <h2 value="<%=TModel.MConfig.MJB %>"><%=TModel.MConfig.MJB %></h2>
                                    <small>许愿池[动态奖金]</small>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3 col-xs-6">
                            <div class="tile quick-stats media">
                                <div id="stats-line12" class="pull-left"></div>
                                <div class="media-body">
                                    <h2 value="<%=TModel.MConfig.MHB %>"><%=TModel.MConfig.MHB %></h2>
                                    <small>许愿树[静态奖金]</small>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 col-xs-6">
                            <div class="tile quick-stats media">
                                <div id="stats-line12" class="pull-left"></div>
                                <div class="media-body">
                                    <h2 value="<%=TModel.MConfig.MGP %>"><%=TModel.MConfig.MGP %></h2>
                                    <small>许愿金[手续费]</small>
                                </div>
                            </div>
                        </div>
                          <div class="col-md-3 col-xs-6">
                            <div class="tile quick-stats media">
                                <div id="stats-line12" class="pull-left"></div>
                                <div class="media-body">
                                    <h2 value="<%=TModel.MConfig.MGP %>"><%=TModel.MConfig.TotalYFHMoney.ToFixedDecimal(0) %></h2>
                                    <small>激活码[激活]</small>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <hr class="whiter" />

                <!-- Main Widgets -->

                <div class="block-area">
                    <div class="row">
                        <div class="col-md-8">

                            <!-- Pies -->
                            <%-- <div class="tile text-center">
                                <div class="tile-dark p-10">
                                    <div class="pie-chart-tiny" data-percent="86">
                                        <span class="percent"></span>
                                        <span class="pie-title">New Visitors <i class="m-l-5 fa fa-retweet"></i></span>
                                    </div>
                                    <div class="pie-chart-tiny" data-percent="23">
                                        <span class="percent"></span>
                                        <span class="pie-title">Bounce Rate <i class="m-l-5 fa fa-retweet"></i></span>
                                    </div>
                                    <div class="pie-chart-tiny" data-percent="57">
                                        <span class="percent"></span>
                                        <span class="pie-title">Emails Sent <i class="m-l-5 fa fa-retweet"></i></span>
                                    </div>
                                    <div class="pie-chart-tiny" data-percent="34">
                                        <span class="percent"></span>
                                        <span class="pie-title">Sales Rate <i class="m-l-5 fa fa-retweet"></i></span>
                                    </div>
                                    <div class="pie-chart-tiny" data-percent="81">
                                        <span class="percent"></span>
                                        <span class="pie-title">New Signups <i class="m-l-5 fa fa-retweet"></i></span>
                                    </div>
                                </div>
                            </div>--%>

                            <!--  Recent Postings -->
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="tile">
                                        <h2 class="tile-title">公告</h2>
                                        <div class="tile-config dropdown">
                                            <a data-toggle="dropdown" href="" class="tile-menu"></a>
                                            <ul class="dropdown-menu animated pull-right text-right">
                                                <li><a href="">Refresh</a></li>
                                                <%--<li><a href="">Settings</a></li>--%>
                                            </ul>
                                        </div>
                                        <div class="listview narrow">

                                            <%
                                                if (noticelist != null)
                                                {
                                                    foreach (var item in noticelist)
                                                    {
                                            %>
                                            <div class="media p-l-5">
                                                <div class="pull-left">
                                                    <img width="40" src="img/profile-pics/2.jpg" alt="">
                                                </div>
                                                <div class="media-body">
                                                    <small class="text-muted">On <%=item.NCreateTime.ToString("dd/MM/yyyy") %></small><br />
                                                    <a class="t-overflow" href="javascript:void(0)" onclick="callhtml('Message/NoticeView.aspx?id=<%=item.ID %>','<%=item.NTitle %>')"><%=item.NTitle %></a>

                                                </div>
                                            </div>
                                            <%
                                                    }
                                                }
                                            %>


                                            <div class="media p-5 text-center l-100">
                                                <a href="javascript:callhtml('../Message/NoticeViewList.aspx','公告查看');onclickmenu()"><small>VIEW ALL</small></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <!-- Tasks to do -->
                                <div class="col-md-6">
                                    <div class="tile">
                                        <h2 class="tile-title">待定</h2>
                                        <div class="tile-config dropdown">
                                            <a data-toggle="dropdown" href="" class="tile-menu"></a>
                                            <ul class="dropdown-menu pull-right text-right">
                                                <%--<li id="todo-add"><a href="">Add New</a></li>--%>
                                                <li id="todo-refresh"><a href="">Refresh</a></li>
                                                <%--<li id="todo-clear"><a href="">Clear All</a></li>--%>
                                            </ul>
                                        </div>

                                        <div class="listview todo-list sortable">
                                            <div class="media">
                                                <div class="checkbox m-0">
                                                    <label class="t-overflow">
                                                        <%--<input type="checkbox">--%>
                                                       待定信息
                                                    </label>
                                                </div>
                                            </div>

                                        </div>


                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                        </div>

                        <div class="col-md-4">
                            <!-- USA Map -->
                            <%--    <div class="tile">
                                <h2 class="tile-title">Live Visits</h2>
                                <div class="tile-config dropdown">
                                    <a data-toggle="dropdown" href="" class="tile-menu"></a>
                                    <ul class="dropdown-menu pull-right text-right">
                                        <li><a href="">Refresh</a></li>
                                        <li><a href="">Settings</a></li>
                                    </ul>
                                </div>

                                <div id="usa-map"></div>
                            </div>--%>



                            <!-- Activity -->
                            <div class="tile">
                                <h2 class="tile-title">平台数据</h2>
                                <div class="tile-config dropdown">
                                    <a data-toggle="dropdown" href="" class="tile-menu"></a>
                                    <ul class="dropdown-menu pull-right text-right">
                                        <li><a href="">Refresh</a></li>

                                    </ul>
                                </div>

                                <div class="listview narrow">

                                    <div class="media">
                                        <div class="pull-right">
                                            <div class="counts"><%=pdtotalcount %></div>
                                        </div>
                                        <div class="media-body">
                                            <h6>排单总数</h6>
                                        </div>
                                    </div>

                                    <div class="media">
                                        <div class="pull-right">
                                            <div class="counts"><%=txtotalcount %></div>
                                        </div>
                                        <div class="media-body">
                                            <h6>提现总数</h6>
                                        </div>
                                    </div>

                                    <div class="media">
                                        <div class="pull-right">
                                            <div class="counts"><%=pddaymoney %></div>
                                        </div>
                                        <div class="media-body">
                                            <h6>日排单金额</h6>
                                        </div>
                                    </div>

                                    <div class="media">
                                        <div class="pull-right">
                                            <div class="counts"><%=txdaymoney %></div>
                                        </div>
                                        <div class="media-body">
                                            <h6>日提现金额</h6>
                                        </div>
                                    </div>
                                    <div class="media">
                                        <div class="pull-right">
                                            <div class="counts"><%=totalmembercount %></div>
                                        </div>
                                        <div class="media-body">
                                            <h6>平台总人数</h6>
                                        </div>
                                    </div>
                                    <div class="media">
                                        <div class="pull-right">
                                            <div class="counts"><%=daymembercount %></div>
                                        </div>
                                        <div class="media-body">
                                            <h6>日新增人数</h6>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>

                <!-- Chat -->
               <%-- <div class="chat">

                    <!-- Chat List -->
                    <div class="pull-left chat-list">
                        <div class="listview narrow">
                            <div class="media">
                                <img class="pull-left" src="/Admin/img/profile-pics/1.jpg" width="30" alt="">
                                <div class="media-body p-t-5">
                                    Alex Bendit
                                </div>
                            </div>
                            <div class="media">
                                <img class="pull-left" src="/Admin/img/profile-pics/2.jpg" width="30" alt="">
                                <div class="media-body">
                                    <span class="t-overflow p-t-5">David Volla Watkinson</span>
                                </div>
                            </div>
                            <div class="media">
                                <img class="pull-left" src="/Admin/img/profile-pics/3.jpg" width="30" alt="">
                                <div class="media-body">
                                    <span class="t-overflow p-t-5">Mitchell Christein</span>
                                </div>
                            </div>
                            <div class="media">
                                <img class="pull-left" src="/Admin/img/profile-pics/4.jpg" width="30" alt="">
                                <div class="media-body">
                                    <span class="t-overflow p-t-5">Wayne Parnell</span>
                                </div>
                            </div>
                            <div class="media">
                                <img class="pull-left" src="/Admin/img/profile-pics/5.jpg" width="30" alt="">
                                <div class="media-body">
                                    <span class="t-overflow p-t-5">Melina April</span>
                                </div>
                            </div>
                            <div class="media">
                                <img class="pull-left" src="/Admin/img/profile-pics/6.jpg" width="30" alt="">
                                <div class="media-body">
                                    <span class="t-overflow p-t-5">Ford Harnson</span>
                                </div>
                            </div>

                        </div>
                    </div>

                    <!-- Chat Area -->
                    <div class="media-body">
                        <div class="chat-header">
                            <a class="btn btn-sm" href="">
                                <i class="fa fa-circle-o status m-r-5"></i>Chat with Friends
                            </a>
                        </div>

                        <div class="chat-body">
                            <div class="media">
                                <img class="pull-right" src="/Admin/img/profile-pics/1.jpg" width="30" alt="" />
                                <div class="media-body pull-right">
                                    Hiiii<br />
                                    How you doing bro?
                                    <small>Me - 10 Mins ago</small>
                                </div>
                            </div>

                            <div class="media pull-left">
                                <img class="pull-left" src="/Admin/img/profile-pics/2.jpg" width="30" alt="" />
                                <div class="media-body">
                                    I'm doing well buddy.
                                <br />
                                    How do you do?
                                    <small>David - 9 Mins ago</small>
                                </div>
                            </div>

                            <div class="media pull-right">
                                <img class="pull-right" src="/Admin/img/profile-pics/2.jpg" width="30" alt="" />
                                <div class="media-body">
                                    I'm Fine bro
                                <br />
                                    Thank you for asking
                                    <small>Me - 8 Mins ago</small>
                                </div>
                            </div>

                            <div class="media pull-right">
                                <img class="pull-right" src="/Admin/img/profile-pics/2.jpg" width="30" alt="" />
                                <div class="media-body">
                                    Any idea for a hangout?
                                    <small>Me - 8 Mins ago</small>
                                </div>
                            </div>

                        </div>

                        <div class="chat-footer media">
                            <i class="chat-list-toggle pull-left fa fa-bars"></i>
                            <i class="pull-right fa fa-picture-o"></i>
                            <div class="media-body">
                                <textarea class="form-control" placeholder="Type something..."></textarea>
                            </div>
                        </div>

                    </div>
                </div>--%>
            </div>


        </section>

        <!-- Older IE Message -->
        <!--[if lt IE 9]>
                <div class="ie-block">
                    <h1 class="Ops">Ooops!</h1>
                    <p>You are using an outdated version of Internet Explorer, upgrade to any of the following web browser in order to access the maximum functionality of this website. </p>
                    <ul class="browsers">
                        <li>
                            <a href="https://www.google.com/intl/en/chrome/browser/">
                                <img src="img/browsers/chrome.png" alt="">
                                <div>Google Chrome</div>
                            </a>
                        </li>
                        <li>
                            <a href="http://www.mozilla.org/en-US/firefox/new/">
                                <img src="img/browsers/firefox.png" alt="">
                                <div>Mozilla Firefox</div>
                            </a>
                        </li>
                        <li>
                            <a href="http://www.opera.com/computer/windows">
                                <img src="img/browsers/opera.png" alt="">
                                <div>Opera</div>
                            </a>
                        </li>
                        <li>
                            <a href="http://safari.en.softonic.com/">
                                <img src="img/browsers/safari.png" alt="">
                                <div>Safari</div>
                            </a>
                        </li>
                        <li>
                            <a href="http://windows.microsoft.com/en-us/internet-explorer/downloads/ie-10/worldwide-languages">
                                <img src="img/browsers/ie.png" alt="">
                                <div>Internet Explorer(New)</div>
                            </a>
                        </li>
                    </ul>
                    <p>Upgrade your browser for a Safer and Faster web experience. <br/>Thank you for your patience...</p>
                </div>   
            <![endif]-->
    </section>

    <!-- Javascript Libraries -->
    <!-- jQuery -->
    <script src="/Admin/js/jquery.min.js"></script>
    <!-- jQuery Library -->
    <script src="/Admin/js/jquery-ui.min.js"></script>
    <!-- jQuery UI -->
    <script src="/Admin/js/jquery.easing.1.3.js"></script>
    <!-- jQuery Easing - Requirred for Lightbox + Pie Charts-->

    <!-- Bootstrap -->
    <script src="/Admin/js/bootstrap.min.js"></script>

    <!-- Charts -->
    <script src="/Admin/js/charts/jquery.flot.js"></script>
    <!-- Flot Main -->
    <script src="/Admin/js/charts/jquery.flot.time.js"></script>
    <!-- Flot sub -->
    <script src="/Admin/js/charts/jquery.flot.animator.min.js"></script>
    <!-- Flot sub -->
    <script src="/Admin/js/charts/jquery.flot.resize.min.js"></script>
    <!-- Flot sub - for repaint when resizing the screen -->

    <script src="/Admin/js/sparkline.min.js"></script>
    <!-- Sparkline - Tiny charts -->
    <script src="/Admin/js/easypiechart.js"></script>
    <!-- EasyPieChart - Animated Pie Charts -->
    <script src="/Admin/js/charts.js"></script>
    <!-- All the above chart related functions -->

    <!-- Map -->
    <script src="/Admin/js/maps/jvectormap.min.js"></script>
    <!-- jVectorMap main library -->
    <script src="/Admin/js/maps/usa.js"></script>
    <!-- USA Map for jVectorMap -->

    <!--  Form Related -->
    <%--<script src="/Admin/js/icheck.js"></script>--%>
    <!-- Custom Checkbox + Radio -->

    <!-- UX -->
    <script src="/Admin/js/scroll.min.js"></script>
    <!-- Custom Scrollbar -->

    <!-- Other -->
    <script src="/Admin/js/calendar.min.js"></script>



    <!-- Calendar -->
    <script src="/Admin/js/feeds.min.js"></script>
    <!-- News Feeds -->


    <!-- All JS functions -->
    <script src="/Admin/js/functions.js"></script>

    <%--<script type="text/javascript" src="/Admin/pop/js/layer/layer.min.js"></script>--%>
    <script type="text/javascript" src="/Admin/pop/js/stack.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/MyValide.js"></script>
    <script type="text/javascript" src="/plugin/ztree/js/jquery.ztree.core-3.5.js"></script>
    <script type="text/javascript" src="/plugin/ztree/ztreeScript.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/javascript_main.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/ajax.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/javascript_pop.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/V5-UI.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/jquery.pagination.js" charset="gbk"></script>

    <link rel="stylesheet" type="text/css" href="/plugin/layer/skin/layer.css" />
     <link href="/plugin/layui/css/layui.css" rel="stylesheet" />
        <script src="/plugin/layui/layui.js"></script>
    
    <script type="text/javascript" src="plugin/layer/layer.js"></script>
    <script type="text/javascript" src="/plugin/UEditor/editor_config.js"></script>
    <script type="text/javascript" src="/plugin/UEditor/editor_all.js"></script>
    <script type="text/javascript" src="/plugin/jOrgChart/prettify.js"></script>
    <script type="text/javascript" src="/plugin/jOrgChart/jquery.jOrgChart.js"></script>
    <script type="text/javascript" src="/plugin/date/WdatePicker.js"></script>
    <script type="text/javascript" src="/plugin/ZeroClipboard/ZeroClipboard.js"></script>
    <%--<script type="text/javascript" src="/plugin/kindeditor/kindeditor-min.js"></script>--%>
    <%--<script type="text/javascript" src="/Admin/js/LoadHelp.js"></script>--%>
    <script type="text/javascript" src="/Mafull/chat/js/chat.js"></script>
    <script type="text/javascript">
        function checkofferindex() {
            var seltype = $("#offerrdoindex").val();
            var offmoney = $("#txtSQMoneyOffindex").val();
            if (seltype == '') {
                v5.alert("请选择排单区域", '1', 'true');
            } else if (offmoney == '') {
                v5.alert("请输入排单金额", '1', 'true');
            } else {
                $.ajax({
                    type: 'post',
                    url: '/Mafull/offerhelp.aspx?Action=add',
                    data: { txtSQMoneyOff: offmoney, offerrdo: seltype },
                    success: function (info) {
                        info = info.split('*')[1];
                        if (info == 0) {
                            v5.alert('提供帮助成功，请等待匹配', '2', 'true');
                            setTimeout(function () {
                                v5.clearall();
                                callhtml('../Mafull/OfferHelpList.aspx', '提供帮助列表 ');
                            }, 2000);
                        }
                        else {
                            v5.alert(info, '2', 'true');
                        }
                    }
                });
            }
        }

        function checkgetindex() {
            var rdo = $("#getrdoindex").val();
            var txtSQMoneyGet = $("#txtSQMoneygetindex").val();
            if (rdo == '') {
                v5.alert("请选择提现币种", '1', 'true');
            } else if (txtSQMoneyGet == '') {
                v5.alert("请输入提现金额", '1', 'true');
            } else {
                $.ajax({
                    type: 'post',
                    url: '/Mafull/Gethelp.aspx?Action=add',
                    data: { txtSQMoneyGet: txtSQMoneyGet, rdo: rdo },
                    success: function (info) {
                        info = info.split('*')[1];
                        if (info == 0) {
                            v5.alert('提现成功', '2', 'true');
                            //setTimeout(function () {
                            //    v5.clearall();
                            //    callhtml('../Mafull/GetHelpList.aspx', '获得帮助列表');
                            //}, 2000);
                        }
                        else {
                            v5.alert(info, '2', 'true');
                        }
                    }
                });
            }
        }


        $(function () {
            $.ajaxSetup({ cache: false });
            var clip = new ZeroClipboard(document.getElementById("fenxian"), {
                moviePath: "/plugin/ZeroClipboard/ZeroClipboard.swf"
            });
            // 复制内容到剪贴板成功后的操作 
            clip.on('complete', function (client, args) {
                layer.alert('复制成功！', {
                    skin: 'layer-ext-moon',
                    btn: '确定'
                });
            });
            //GetHelpList("1", ".jycontent #getMatch > tbody");
            //GetHelpList("2", ".jycontent #offMatch > tbody");
            //GetHelpList("3", ".jycontent .mianright");
        });

        //function onclickmenu() {
        //    var className = document.getElementById("sidebar-collapse").className;
        //    if (className == "row headermenu sidebar collapse in") {
        //        $(".navbar-toggle").click();
        //    }
        //}

        //function rectClick() {
        //    layer.open({
        //        title: false,
        //        type: 2,
        //        content: ['test/iframe.html', '0'],
        //        area: ['380px', '160px'],
        //        btn: ['ok']
        //    });
        //}

        //KindEditor.ready(function (K) {
        //    window.KKKK = K;
        //});
    </script>
</body>
</html>
