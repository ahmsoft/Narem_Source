<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal runat="server" ID="litMeta" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="breadcrumb-box">
        <div class="container">
            <ul class="breadcrumb">
                <li><a href="/index">صفحه اصلی</a> <span class="divider">/</span></li>
                <li class="active">ورود</li>

            </ul>
        </div>
    </div>
    <!-- .breadcrumb-box -->
    <header class="page-header">
        <div class="container">
            <h1 class="title">ورود به حساب کاربری یا ایجاد حساب کاربری</h1>
        </div>
    </header>

    <div class="container">
        <div class="row">
            <div class="content login span12">
                <div class="row">
                    <div class="span6">
                        <div class="new-costumers">
                            <h3 class="title">کاربر جدید</h3>
                            <p style="text-align: justify;">اگر تا کنون در سایت نارِم ثبت نام نکرده‌اید، با ایجاد یک حساب کاربری در نارِم، شما قادر به استفاده ز کلیه‌ی امکانات تعریف شده برای حساب کاربری خود خواهید بود.</p>
                            <p style="text-align: justify;">دو نوع حساب کاربری در سایت وجود دارد حساب کاربری مشتریان (برای این منظور شما باید دارای شماره قرارداد 8 رقمی باشید) و حساب کاربری آموزشی</p>
                            <button class="btn" id="btnFeedw" data-toggle="modal" data-target="#SignUpModal">ایجاد حساب کاربری</button>
                            <asp:Button runat="server" ID="btnStdSignup" PostBackUrl="~/edu-account-signup" class="btn" Text="ایجاد حساب کاربری آموزشی" />
                            <div style="margin-top:15px;">
                                <strong style="font-size:larger;"><span style="color: red;">* </span>درصورت بروز هر گونه خطا، جهت رفع مشکل با شماره تماس <a href="tel:+989391815029">09391815029</a> تماس حاصل نمایید.
                                </strong>
                            </div>
                            <div class="modal fade" id="SignUpModal" role="dialog">
                                <div class="modal-dialog">
                                    <!-- Modal content-->
                                    <div class="modal-content">
                                        <div class="modal-header" style="direction: rtl;">
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            <h4 class="modal-title" style="color: red;">احراز هویت</h4>
                                        </div>
                                        <div class="modal-body">
                                            <p style="direction: rtl; font-size: 14px;">
                                                شماره قرارداد 8 رقمی و کد مربوط به تصویر امنیتی را وارد کنید و دکمه ثبت را بزنید.
                                            </p>
                                            <asp:TextBox runat="server" onKeyup="signupBtn(event);" ID="txtNoContract" placeholder="شماره قرارداد 8 رقمی" MaxLength="8" />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtCaptcha" Style="direction: ltr; text-align: right;" onKeyup="signupBtn(event);" runat="server" lang="fa" placeholder="کد موجود در تصویر امنیتی" /></td>
                                                    <td>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="Captcha.aspx" Style="width: 150px; margin-top: -20px; padding: 10px;" /></td>
                                                </tr>
                                            </table>
                                            <%--                                                <strong style="color: orangered;">توجه: </strong>جهت بارگذاری مجدد تصویر امنیتی Ctrl + R را فشار دهید و دوباره اقدام به ایجاد حساب کاربری کنید--%>
                                        </div>


                                        <%--                        <telerik:RadCaptcha ID="RadCaptcha1" CaptchaTextBoxCssClass="aligncenter" ValidationGroup="Comment" CaptchaImage-ImageCssClass="aligncenter" CaptchaTextBoxLabel="" runat="server" CaptchaImage-BackgroundColor="White"></telerik:RadCaptcha>--%>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">انصراف</button>
                                            <asp:Button runat="server" Style="float: left;" class="btn btn-primary aligncenter" ID="btnSignUp" Text="ثبت" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="span6">
                        <div class="register-form">
                            <h3 class="title">ورود به حساب کاربری</h3>
                            <p>اگر شما قبلا ثبت نام نموده‌اید، لطفا وارد حساب کاربری خود شوید.</p>
                            <label>نام کاربری: <span class="required">*</span></label>
                            <label>درصورتی که <span style="color: red;">حساب کاربری آموزشی</span> دارید، شماره تلفن همراه وارد شود (مثال: 09123456789)</label>
                            <asp:TextBox runat="server" ID="txtUsername" onKeyup="Ariv(event);" MaxLength="20" class="input-block-level" />
                            <label>رمز عبور: <span class="required">*</span></label>
                            <asp:TextBox runat="server" ID="txtPassword" onKeyup="Ariv(event);" MaxLength="20" class="input-block-level" type="password" />
                            <label class="checkbox">
                                <asp:CheckBox runat="server" ID="chk" type="checkbox" Style="" onKeyup="Ariv(event);" />
                                من را بخاطر بسپار
                            </label>
                            <div class="buttons-box clearfix">
                                <asp:Button runat="server" ID="btnArival" type="submit" class="btn pull-left" Text="ورود" />
                                <a href="#" data-toggle="modal" data-target="#ForgetPassModal" id="ForgetCode" class="forgot">رمز عبور خود را فراموش کرده‌اید؟</a>
                                <div class="modal fade" id="ForgetPassModal" role="dialog">
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
                                                <%--                                                    <strong style="color: orangered;">توجه: </strong>جهت بارگذاری مجدد تصویر امنیتی Ctrl + R را فشار دهید و دوباره اقدام به ایجاد حساب کاربری کنید--%>
                                            </div>

                                            <%--                        <telerik:RadCaptcha ID="RadCaptcha1" CaptchaTextBoxCssClass="aligncenter" ValidationGroup="Comment" CaptchaImage-ImageCssClass="aligncenter" CaptchaTextBoxLabel="" runat="server" CaptchaImage-BackgroundColor="White"></telerik:RadCaptcha>--%>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default" data-dismiss="modal">انصراف</button>
                                                <asp:Button runat="server" Style="float: left;" class="btn btn-primary aligncenter" ID="btnForget" Text="ثبت" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <span class="required" style="margin-right: 20px;">
                                    <asp:Label runat="server" ID="lblSubmitStatus" /></span>
                            </div>
                            <!-- .buttons-box -->
                        </div>
                    </div>
                </div>
                <br />
            </div>
        </div>
    </div>
    <!-- .container -->
    <script>
        function Ariv(event) {
            if (event.keyCode == 13) {
                $("#ContentPlaceHolder1_btnArival").click();
            }
        };
        $(document).keypress(function (e) {
            if (e.keyCode === 13) {
                e.preventDefault();
                return false;
            }
        });
        function forgetBtn(event) {
            if (event.keyCode === 13) {
                if (document.getElementById('#ContentPlaceHolder1_txtForgetPass').value) {
                    $("#ContentPlaceHolder1_btnForget").click();
                }
            }
        };
        function signupBtn(event) {
            if (event.keyCode === 13) {
                if (document.getElementById('#ContentPlaceHolder1_txtNoContract').value) {
                    $("#ContentPlaceHolder1_btnSignUp").click();
                }
            }
        };
    </script>
</asp:Content>

