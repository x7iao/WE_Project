<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CheckSecurityQuestion.ascx.cs" Inherits="WE_Project.Web.CommonControl.CheckSecurityQuestion" %>
      <tr>
                    <td  align="right" >
                       
                    </td>
                       <td >
                      验证密保问题 
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        密保问题:
                    </td>
                    <td>
                         <select id="ddl_PwdQuestion" width="175px" runat="server">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        密保问题答案:
                    </td>
                    <td>
                        <input type="hidden" runat="server" id="hidQuesId" />
                        <input id="pwdAnswer" class="normal_input" runat="server" type="text" /><font
                            color="red">*</font>
                    </td>
 </tr>