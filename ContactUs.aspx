<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ContactUs.aspx.vb" Inherits="ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
    <asp:Literal runat="server" ID="litMeta" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="breadcrumb-box">
        <div class="container">
            <ul class="breadcrumb">
                <li><a href="/index">صفحه اصلی</a> <span class="divider">/</span></li>
                <li class="active">تماس با ما</li>
            </ul>
        </div>
    </div>
    <!-- .breadcrumb-box -->
    <br />
    <br />
    <br />
    <header class="page-header">
        <div class="container">
            <h1 class="title">تماس با ما</h1>
        </div>
    </header>
    <div class="container">
        <div class="row">
            <div class="content span12">
                <div class="row">
                    <div class="span6 contact-info">
                        <div class="row">
                            <address class="span6">
                                <div class="title">آدرس</div>
                                <asp:Literal runat="server" ID="ltrAddress" />
                            </address>
                            <address class="span3">
                                <div class="title">پست‌های الکترونیک</div>
                                <div>تیم پشتیبانی: <a style='color:rgba(0,0,0,0.8);text-decoration:none;' href="mailto:INFO@NAREM.IR">INFO@NAREM.IR</a></div>
                                <div>مدیرعامل: <a style='color:rgba(0,0,0,0.8);text-decoration:none;' href="mailto:ah.moravveji.edu@gmail.com">ah.moravveji.edu@gmail.com</a></div>
                                <div>رئیس هیات مدیره: <a style='color:rgba(0,0,0,0.8);text-decoration:none;' href="mailto:ah.moravveji@gmail.com">ah.moravveji@gmail.com</a></div>
                                <div>نایب رئیس هیات مدیره: <a style='color:rgba(0,0,0,0.8);text-decoration:none;' href="mailto:moraveji.far@gmail.com">moraveji.far@gmail.com</a></div>
                            </address>
                            <address class="span3">
                                <div class="title">شماره‌های تماس</div>
                                <div>مدیرعامل: <asp:Literal runat="server" ID="ltrTel1" /></div>
                                <div>تلفن شرکت: <asp:Literal runat="server" ID="ltrTel2" /></div>
<%--                                <div>مدیر فروش: <asp:Label runat="server" ID="lblTel3" /></div>--%>
                            </address>
                            <address class="span6">
                                <div class="title">ساعات کاری در ایام هفته</div>
                                <asp:Label runat="server" ID="ltrWorkingHours" />
                            </address>
                        </div>
                        <hr>
                        <address class="span6">
                            <div class="title">رسانه‌های اجتماعی</div>
                            <asp:Literal runat="server" ID="ltrSocialNetworks" />
                        </address>
                        <p></p>
                    </div>
                    <div class="span6">
                        <h4>ارسال پیام</h4>
                        <label for="txtNameFamili" id="lblName">نام و نام خانوادگی :</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNameAndFamily" runat="server" ErrorMessage="نام و نام خانوادگی وارد شود" ValidationGroup="FAQ" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtNameAndFamily" runat="server" ErrorMessage="فارسی و صحیح وارد شود" ValidationGroup="FAQ" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" CssClass="label-danger" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\s*[ابپتثجچحخدذرزژئسشصضطظعغفق  کگلمنوهیآیيك\s]+\s*$"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" type="text" name="name" ID="txtNameAndFamily" value="" Style="height: 8px; width: 90%; padding: 10px;" class="text-input" />
                        <label for="txtEmail" id="lblEmail" style="padding-top: 15px;">ایمیل :</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtMail" runat="server" ErrorMessage="ایمیل وارد شود" ValidationGroup="FAQ" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtMail" runat="server" ErrorMessage="ایمیل نادرست" ValidationGroup="FAQ" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[\w-\.]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]{2,6}$"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" type="email" name="email" class="text-input" ID="txtMail" size="50" value="" Style="height: 8px; width: 90%; padding: 10px;" />
                        <label for="txtWebsite" id="lblWebsite" style="padding-top: 15px;">وب سایت :</label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtWSite" runat="server" ErrorMessage="آدرس وبسایت نادرست" ValidationGroup="FAQ" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" Display="Dynamic" SetFocusOnError="true" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                        <asp:TextBox runat="server" type="text" name="website" ID="txtWSite" placeholder="http://www.narem.ir" value="" Style="height: 8px; width: 90%; padding: 10px;" class="text-input" />
                        <label for="txtQuestion" id="lblQuestion" style="padding-top: 15px;">پرسش :</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtQuestion" ErrorMessage="متن پرسش وارد شود" ValidationGroup="FAQ" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:TextBox runat="server" name="msg" ID="txtQuestion" Style="width: 90%;" class="text-input" Rows="4" TextMode="MultiLine" />
                            <!-- .buttons-box -->
<%--                        </form>--%>
                        <br />
                        <table style="border: hidden; border-radius: 8px;">
                            <tr>
                                <th>
                                    <asp:Label runat="server" ID="lblSubmitStatusFAQ" Text="" />
                                </th>
                            </tr>
                            <tr>
                                <td style="background-color: rgba(0, 0, 0, 0); direction: ltr;">
                                    <telerik:RadCaptcha ID="RadCaptcha" ValidationGroup="FAQ" CaptchaImage-ImageCssClass="aligncenter" CaptchaTextBoxLabel="" runat="server" CaptchaImage-BackgroundColor="White"></telerik:RadCaptcha>
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color: rgba(0, 0, 0, 0); border: hidden;">
                                    <%--                                    <button type="button" style="width: 100%;" class="button solid-button purple aligncenter" data-toggle="modal" data-target="#FAQModal">ارسال پرسش</button>--%>
                                    <asp:Button runat="server" Style="" ValidationGroup="FAQ" name="submit" class="btn btn-primary" ID="btnFAQSubmit" Text="ارسال پرسش" />

                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="span12 map-box">
                        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3214.541388186899!2d59.46483441472306!3d36.32342670209224!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3f6cf2b2055d91d9%3A0xf00e56c3fad306df!2z2KLYsduM2Kcg2LPYp9mB2Ko!5e0!3m2!1sen!2s!4v1522079446859" height="270" style="border: 0"></iframe>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- .container -->
</asp:Content>

