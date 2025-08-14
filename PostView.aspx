<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PostView.aspx.vb" Inherits="PostView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
        <asp:Literal runat="server" ID="litMeta" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumb-box">
        <div class="container">
            <ul class="breadcrumb">
                <asp:Literal runat="server" ID="ltrRoot" />
            </ul>
        </div>
    </div>
    <!-- .breadcrumb-box -->
    <br />
    <br />
    <br />
    <%--    <section id="main">--%>
    <header class="page-header">
        <div class="container">
            <h1 class="title">
                <asp:Label runat="server" ID="ltrTitle" />
            </h1>
        </div>
    </header>
    <div class="container" style="margin-top: -30px;">
        <div class="row">
            <div class="content blog blog-post span9">
                <asp:PlaceHolder ID="PostViewPlaceHolder" runat="server"></asp:PlaceHolder>
                <asp:PlaceHolder ID="CommentsViewPlaceHolder" runat="server"></asp:PlaceHolder>
                <hr class="shadow">
                <h3 class="title slim">دیدگاه خود را ارسال کنید</h3>
                <div class="comments-form" style="text-align: right; direction: rtl;">
                    <label for="txtNameFamili" id="name_label">نام و نام خانوادگی :</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorNameAndFamily" ControlToValidate="txtNameFamili" runat="server" ErrorMessage="نام و نام خانوادگی وارد شود" ValidationGroup="Comment" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionNameAndFamily" ControlToValidate="txtNameFamili" runat="server" ErrorMessage="فارسی و صحیح وارد شود" ValidationGroup="Comment" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" CssClass="label-danger" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\s*[ابپتثجچحخدذرزژئسشصضطظعغفق  کگلمنوهیآیيك\s]+\s*$"></asp:RegularExpressionValidator>
                    <asp:TextBox runat="server" type="text" name="name" ID="txtNameFamili" value="" Style="height: 8px; width: 90%;" class="text-input" />
                    <label for="txtEmail" id="email_label">ایمیل :</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" ControlToValidate="txtEmail" runat="server" ErrorMessage="ایمیل وارد شود" ValidationGroup="contactIndex" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionEmail" ControlToValidate="txtEmail" runat="server" ErrorMessage="ایمیل نادرست" ValidationGroup="Comment" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[\w-\.]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]{2,6}$"></asp:RegularExpressionValidator>
                    <asp:TextBox runat="server" type="email" name="email" class="text-input" ID="txtEmail" size="50" value="" Style="height: 8px; width: 90%;" />
                    <label for="txtWebsite" id="name_website">وب سایت :</label>
                    <asp:RegularExpressionValidator ID="RegularExpressionWebsite" ControlToValidate="txtWebsite" runat="server" ErrorMessage="آدرس وبسایت نادرست" ValidationGroup="Comment" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" Display="Dynamic" SetFocusOnError="true" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                    <asp:TextBox runat="server" type="text" name="website" ID="txtWebsite" placeholder="http://www.narem.ir" value="" Style="height: 8px; width: 90%;" class="text-input" />
                    <label for="txtMessage" id="msg_label">دیدگاه :</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" runat="server" ControlToValidate="txtMessage" ErrorMessage="متن دیدگاه وارد شود" ValidationGroup="Comment" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" name="msg" ID="txtMessage" Style="width: 90%;" class="text-input" Rows="4" TextMode="MultiLine" />
                    <br />
                    <div class="clearfix"></div>
                    <br />
                    <strong style="color: orangered;">توجه: </strong>جهت بارگذاری مجدد تصویر امنیتی Ctrl + R را فشار دهید

                    <table style="border: hidden;">
                        <tr>
                            <th>
                                <asp:Label runat="server" ID="lblSubmitStatus" Text="" />
                            </th>
                        </tr>
                        <tr>
                            <td style="background-color: rgba(0,0,0,0); direction: ltr;" class="aligncenter">
                                <telerik:RadCaptcha ID="RadCaptcha1" ValidationGroup="Comment" CaptchaTextBoxLabel="" runat="server" CaptchaImage-BackgroundColor="White"></telerik:RadCaptcha>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: rgba(0,0,0,0); border: hidden;">
                                <asp:Button runat="server" Style="width: 100%;" ValidationGroup="Comment" name="submit" class="btn btn-primary aligncenter" ID="btnCommentSubmit" Text="ثبت دیدگاه" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <!-- .content -->
            <div id="sidebar" class="sidebar span3">
                <aside class="tags">
                    <header>
                        <h3>برچسب‌ها</h3>
                    </header>
                    <asp:Label runat="server" ID="ltrTag" />
                </aside>
                <!-- .tags -->
                <asp:PlaceHolder runat="server" ID="PlaceHolderBlock"></asp:PlaceHolder>
                <!-- .list -->

            </div>
            <!-- .sidebar -->
        </div>
    </div>
    <!-- .container -->
    <%--    </section>--%>
    <!-- #main -->

</asp:Content>

