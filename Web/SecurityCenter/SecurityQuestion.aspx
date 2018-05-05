<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecurityQuestion.aspx.cs" Inherits="WE_Project.Web.SecurityCenter.SecurityQuestion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    .tabInput{ width:99%;}
    </style>
    <script type="text/javascript">
        function guidGenerator() {
            var S4 = function () {
                return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
            };
            return (S4() + S4());
        }
        function addRow(obj) {
            var t = guidGenerator(); //  d + h + x + s + ms;
            var ownParent = $(".arrangeTab");
            var arrangeTable = $("#tabQuestion");
            var orgin = ownParent.html();
            //添加新的行程
            var appendHtml = "<tr id='ques" + t + "' class='active realContain'>" + orgin + "</tr>";
            arrangeTable.append(appendHtml);

            $("#ques" + t).find(".inputQues").attr("name", "Ques_" + t).attr("require-type", "require").attr("require-msg", "密保问题");
            reCount()
        }

        function reCount() {
            $(".spCount").each(function (i) {
                $(this).html(i);
            });
        }

        function removeRow(obj) {
            if (confirm("确定要移除该行吗？")) {
                var delId = $(obj).prev('.hidId').val();
                var hidDelIds = $("#hidDelIds").val();
              
                if (typeof (delId) != 'undefined' && delId != "") {
                    if (typeof (hidDelIds) != 'undefined') {
                        hidDelIds += delId + ',';
                    }
                    $("#hidDelIds").val(hidDelIds);
                }
                $(obj).parent().parent().remove();
                reCount()
            }
        }
        function checkFormVal() {
            if (checkForm()) {
//                $.ajax({
//                    type: 'post',
//                    url: '/SecurityCenter/SecurityQuestion.aspx?Action=Add',
//                    data: $('#form1').serialize(),
//                    success: function (info) {
//                        v5.alert('保存成功', '1', 'true');
//                        //setTimeout(function () { v5.clearall(); }, 1000);
//                        callhtml('SecurityCenter/SecurityQuestion.aspx', '密保问题');
//                    }
                //                });
                ActionModel("/SecurityCenter/SecurityQuestion.aspx?Action=Add", $('#form1').serialize(),false);
//                ActionModelBackWithTitle("/SecurityCenter/SecurityQuestion.aspx?Action=Add", $('#form1').serialize(), "SecurityCenter/SecurityQuestion.aspx", null, '密保问题');
            }
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <input type="hidden" runat="server" id="hidDelIds" />
               <table cellpadding="0" cellspacing="0" id="tabQuestion">
                <tr class="arrangeTab" style="display:none">
                    <td width="20%" align="right" class="tabIndex">
                      <span class="spCount"></span>    :
                    </td>
                    <td>
                        <input  class="normal_input tabInput inputQues" type="text" />
                    </td>
                      <td>
                         <input type="hidden" class="hidId"  />
                        <input type="button" value="删除" class="btn btn-danger" onclick="removeRow(this)" style="display:none" />
                    </td>
                </tr>

            <asp:Repeater ID="rep_QuestionList" runat="server">
            <ItemTemplate>
                <tr>
                    <td width="20%" align="right">
                  <span class="spCount"> <%# Container.ItemIndex + 1%></span>    :
                    </td>
                    <td>
                        <input  name="Ques_<%# Container.ItemIndex + 1%>" value="<%#Eval("Question")%> " require-type="require" require-msg="密保问题"  class="normal_input tabInput" type="text" />
                    </td>
                      <td>
                         <input type="hidden" class="hidId" value="<%# Eval("Id")%>" name="hidId_<%# Container.ItemIndex + 1%>"  />
                        <input type="button" value="删除" class="btn btn-danger" onclick="removeRow(this)"  style="display:none"/>
                    </td>
                </tr>
            </ItemTemplate>
            </asp:Repeater>
            </table>
            <div style="background-color:#fff; text-align:right">  
          
            <input type="button" value="添加" class="btn btn-info" onclick="addRow(this)" />
              <input type="button" value="保存"  class="btn btn-success" onclick="checkFormVal()" style="margin-right:15%" />
            </div>
          
             
            </form>
        </div>
    </div>
</body>
</html>
