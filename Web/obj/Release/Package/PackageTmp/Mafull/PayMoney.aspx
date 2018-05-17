<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayMoney.aspx.cs" Inherits="WE_Project.Web.Mafull.PayMoney" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script>
        layui.use("upload", function () {
            layui.upload({
                url: '/Admin/UpLoadPic/UploadImage.ashx',
                success: function (res) {
                    console.log(res); //上传成功返回值，必须为json格式
                    if (res.isSuccess) {
                        $("#upimage").attr("src", res.msg);
                        $("#hduploadPic1").val(res.msg);
                    } else {
                        v5.alert(res.msg, '1', 'true')
                    }
                }
            });
        });

    </script>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1" name='form1' method="post">
                <input id="hidId" type="hidden" runat="server" />
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="15%" align="right">
                            <span>付款编号：</span>
                        </td>
                        <td width="35%">
                            <%=match.MatchCode%>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            <span>付款金额：</span>
                        </td>
                        <td width="35%">
                            <%=match.MatchMoney%>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            <span>匹配时间：</span>
                        </td>
                        <td width="35%">
                            <%=match.MatchTime%>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            <span>剩余支付时间：</span>
                        </td>
                        <td width="35%">
                            <span id="spLeaveTime" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            <span>收款方信息：</span>
                        </td>
                        <td width="35%">
                            <table>
                                <tr>
                                    <td>会员账号：<%=getMemberModel.MID%>
                                    </td>
                                    <%--<td>
                                    推荐人会员账号：<%=getTJMemberModel.MID%>
                                </td>--%>
                                </tr>
                                <tr>
                                    <td>开户名：<%=getMemberModel.BankCardName%>
                                    </td>
                                    <%--<td>
                                    推荐人会员昵称：<%=getTJMemberModel.MName%>
                                </td>--%>
                                </tr>
                                <tr>
                                    <td>手机号码：<%=getMemberModel.Tel%>
                                    </td>
                                    <%--<td>
                                    推荐人手机号码：<%=getTJMemberModel.Tel%>
                                </td>--%>
                                </tr>
                                <tr>
                                    <td>开户银行：<%=getMemberModel.Bank%>
                                    </td>
                                    <%--<td>
                                    推荐人开户银行：<%=getTJMemberModel.Bank%>
                                </td>--%>
                                </tr>
                                <tr>
                                    <td>银行支行：<%=getMemberModel.Branch%>
                                    </td>
                                    <%--<td>
                                    推荐人银行支行：<%=getTJMemberModel.Branch%>
                                </td>--%>
                                </tr>
                                <tr>
                                    <td>银行卡号：<%=getMemberModel.BankNumber%>
                                    </td>
                                    <%--<td>
                                    推荐人银行卡号：<%=getTJMemberModel.BankNumber%>
                                </td>--%>
                                </tr>
                                <tr>
                                    <td>支付宝账号：<%=getMemberModel.AliPay%>
                                    </td>
                                    <%--<td>
                                    推荐人支付宝账号：<%=getTJMemberModel.Email%>
                                </td>--%>
                                </tr>
                                <tr>
                                    <td>微信帐号：<%=getMemberModel.WeChat%>
                                    </td>
                                    <%--<td>
                                    推荐人支付宝账号：<%=getTJMemberModel.Email%>
                                </td>--%>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            <span>备注留言：</span>
                        </td>
                        <td width="35%">
                            <textarea id="txtRemark" runat="server" style="width: 500px"></textarea>
                            <input type="hidden" id="hidIndex" value="" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding: 45px">
                            <span>凭证一：</span>
                        </td>
                        <td style="display: none;">
                            <input id="txtBigPng" type="button" value="上传图片" class="btn btn-success" onclick="showUpload(1)" />
                            <div id="tablePic1">
                            </div>
                        </td>
                        <td>

                            <input type="file" name="upload" class="layui-upload-file" style="display:block;">
                            <input type="hidden" id="hduploadPic1" name="hduploadPic1" runat="server" />
                            <img id="upimage" width="100px;" height="100px" />

                            <%--  <input type="button" id="GatheringPic" value="上传图片" />
                        <div id='uploadLog'>
                        </div>
                        <input type="hidden" id="hduploadPic1" name="hduploadPic1" />
                        <img id="imgPic" class='appImg' style='max-width: 700px;' />--%>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td align="right" style="padding: 45px">
                            <span>凭证二：</span>
                        </td>
                        <td>
                            <input id="Button2" type="button" value="上传图片" class="btn btn-success" onclick="showUpload(2)" />
                            <div id="tablePic2">
                            </div>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td align="right" style="padding: 45px">
                            <span>凭证三：</span>
                        </td>
                        <td>
                            <input id="Button3" type="button" value="上传图片" class="btn btn-success" onclick="showUpload(3)" />
                            <div id="tablePi3">
                            </div>
                        </td>
                    </tr>
                    <%--<tr>
                    <td>
                        拒绝付款：
                    </td>
                    <td>
                        <textarea type="text" id="txtjujuemessage" runat="server" name="txtjujuemessage"
                            style="height: 50px; width: 500px"></textarea>
                        <%if (string.IsNullOrEmpty(match.PicUrl1))
                          { %>
                        <input class="normal_btnok" id="Button4" type="button" runat="server" value="申请拒绝付款"
                            onclick="checkChange2();" /><%} %>
                    </td>
                </tr>--%>
                    <tr>
                        <td></td>
                        <td>
                            <input class="normal_btnok" id="btnOK" type="button" runat="server" value="确认付款"
                                onclick="checkChange();" />&nbsp;
                        <input class="btn btn-danger" id="Button1" type="button" runat="server" value="返回"
                            onclick="returnList();" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <script>
        layui.use("upload", function () {
            layui.upload({
                url: '/Admin/UpLoadPic/UploadImage.ashx',
                success: function (res) {
                    console.log(res); //上传成功返回值，必须为json格式
                    if (res.isSuccess) {
                        $("#upimage").attr("src", res.msg);
                        $("#hduploadPic1").val(res.msg);
                    } else {
                        v5.alert(res.msg, '1', 'true')
                    }
                }
            });
        });

    </script>
    <script type="text/javascript">
        function returnList() {
            window.location.reload();
        }
        function OpenWindow(url, title, width, height) {
            var iTop = (window.screen.height - 30 - height) / 2; //获得窗口的垂直位置;
            var iLeft = (window.screen.width - 10 - width) / 2; //获得窗口的水平位置;
            window.open(url, title, 'height=' + height + ', width=' + width + ', top=' + iTop + ', left=' + iLeft + ', toolbar=no, menubar=no, scrollbars=no,resizable=no,location=no, status=no');
        }

        function checkChange() {
            if ($("#hduploadPic1").val().Trim() == "") {
                v5.alert('请上传您的打款凭证', '1', 'true');
                return;
            }
            //            if (checkForm()) {
            verifypsd(function () {
                $.ajax({
                    type: 'post',
                    url: '/Mafull/PayMoney.aspx?Action=add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        if (info == "1") {
                            v5.alert('付款提交成功，请等待收款人确认', '1', 'true');
                            setTimeout(function () {
                                v5.clearall();
                                window.location.reload();
                            }, 1000);
                        } else if (info == "2") {
                            v5.alert('请上传您的打款凭证', '1', 'true');
                        }
                        else if (info == "0") {
                            v5.alert('打款失败，请重试', '1', 'true');
                        }
                    }
                });
            });
            //            }
        }

        function checkChange2() {
            if ($("#txtjujuemessage").val().Trim() == "") {
                v5.error("请填写拒绝理由", '2', 'true');
                return;
            }
            else if (checkForm()) {
                verifypsd(function () {
                    $.ajax({
                        type: 'post',
                        url: '/Mafull/PayMoney.aspx?Action=modify',
                        data: $('#form1').serialize(),
                        success: function (info) {
                            if (info == "1") {
                                v5.alert('申请成功，等待处理！', '2', 'true');
                                setTimeout(function () {
                                    v5.clearall();
                                    window.location.reload();
                                }, 1000);
                            }
                            else {
                                v5.alert(info, '2', 'true');
                            }
                        }
                    });
                });
            }
        }
    </script>
</body>
</html>
