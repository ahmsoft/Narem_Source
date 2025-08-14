<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ForgotPass.aspx.vb" Inherits="ForgotPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    روش‌های بازیابی
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ForgetPassModal">
  Open modal
</button>
            <div class="modal fade fade" id="ForgetPassModal" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header" style="direction: rtl;">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title" style="color: red;">بازیابی اطلاعات ورود به حساب کاربری</h4>
                    </div>
                    <div class="modal-body">
                        <p style="direction: rtl; font-size: 14px;">
                            شماره تلفن همراه 11رقمی با صفر ابتدا و کد مربوط به تصویر امنیتی را وارد کنید و دکمه ثبت را بزنید.
                        </p>
                        <asp:TextBox runat="server" onKeyup="forgetBtn(event);" Style="direction: ltr; text-align: right; font-size: 14px;" ID="txtForgetPass" placeholder="به عنوان مثال: 09121815029" MaxLength="11" />
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCode" Style="font-family: IranSans !important;" onKeyup="forgetBtn(event);" runat="server" lang="fa" MaxLength="7" placeholder="کد موجود در تصویر امنیتی" /></td>
                                <td>
                                    <asp:Image ID="Image2" runat="server" ImageUrl="Captcha.aspx" Style="width: 150px; margin-top: -20px; padding: 10px;" /></td>
                            </tr>
                        </table>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">انصراف</button>
                        <asp:Button runat="server" Style="float: left;" class="btn btn-primary aligncenter" ID="btnForget" Text="ثبت" />
                    </div>
                </div>
            </div>
        </div>


</asp:Content>

