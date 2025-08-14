<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="Settings.aspx.vb" Inherits="Admin_Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <div id="page-wrapper">
        <div class="container-fluid">

            <!-- Page Heading -->
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">مدیریت پیام <small>پیام‌های مطالب سایت</small></h1>

                    <ol class="breadcrumb">
                        <li>
                            <i class="fa fa-dashboard"></i>Dashboard
                        </li>
                        <li class="active">
                            <i class="fa fa-edit"></i>Message Management
                        </li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
            <div class="box box-default" id="SettingsList">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">لیست مجموعه تنظیمات</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#ContactInfo" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:SqlDataSource ID="SqlDataSourceSettings" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT [NameSettings], [IDS] FROM [Setting]"></asp:SqlDataSource>

                            <asp:GridView ID="SettingsView" runat="server" AllowSorting="True" DataSourceID="SqlDataSourceSettings" AutoGenerateColumns="False" DataKeyNames="IDS" CellPadding="4" ForeColor="#333333" Width="100%" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField ButtonType="Button" SelectText="انتخاب" ShowSelectButton="True">
                                        <HeaderStyle CssClass="text-center" />
                                        <ControlStyle CssClass="btn btn-success btn-xs" Width="100%" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="NameSettings" HeaderText="نام مجموعه تنظیمات" SortExpression="NameSettings">
                                        <HeaderStyle CssClass="text-center" />
                                        <ItemStyle CssClass="text-center" Font-Bold="True" />
                                    </asp:BoundField>

                                    <asp:CommandField ButtonType="Button" DeleteText="حذف" ShowDeleteButton="True" Visible="False">
                                        <HeaderStyle CssClass="text-center" />
                                        <ControlStyle CssClass="btn btn-danger btn-xs" Width="100%" />
                                    </asp:CommandField>
                                </Columns>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                <SortedDescendingHeaderStyle BackColor="#93451F" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <div class="box box-success" id="ContactInfo">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">اطلاعات پایه و تماس</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#UsersList" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                        <a href="#About" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="txtSettingName" class="control-label">نام تنظیمات:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtSettingName" class="form-control" placeholder="نام مجموعه تنظیمات" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-6">
                            <label for="txtBrand_Fa" class="control-label">نام برند فارسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtBrand_Fa" class="form-control" placeholder="نام برند فارسی" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtBrand_En" class="control-label">نام برند انگلیسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtBrand_En" class="form-control" placeholder="نام برند انگلیسی" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-6">
                            <label for="txtCoName_Fa" class="control-label">نام شرکت فارسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtCoName_Fa" class="form-control" placeholder="نام شرکت فارسی" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtCoName_En" class="control-label">نام شرکت انگلیسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtCoName_En" class="form-control" placeholder="نام شرکت انگلیسی" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-6">
                            <label for="txtSiteName_Fa" class="control-label">نام سایت فارسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtSiteName_Fa" class="form-control" placeholder="نام سایت فارسی" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtSiteName_En" class="control-label">نام سایت انگلیسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtSiteName_En" class="form-control" placeholder="نام سایت انگلیسی" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-6">
                            <label for="txtSiteTitle_Fa" class="control-label">عنوان سایت فارسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtSiteTitle_Fa" class="form-control" placeholder="عنوان سایت فارسی" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtSiteTitle_En" class="control-label">عنوان سایت انگلیسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtSiteTitle_En" class="form-control" placeholder="عنوان سایت انگلیسی" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-6">
                            <label for="Subject_Fa" class="control-label">موضوع فارسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtSubject_Fa" class="form-control" placeholder="موضوع سایت فارسی" />
                        </div>
                        <div class="col-lg-6">
                            <label for="Subject_En" class="control-label">موضوع انگلیسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtSubject_En" class="form-control" placeholder="موضوع سایت انگلیسی" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-6">
                            <label for="txtPhone1" class="control-label">تلفن اول:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtPhone1" class="form-control" placeholder="تلفن" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtPhone2" class="control-label">تلفن دوم:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtPhone2" class="form-control" placeholder="تلفن دوم" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadAddress1" class=" control-label">آدرس فارسی:</label>
                            <telerik:RadEditor ID="RadAddress1_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadAddress1" class=" control-label">آدرس انگلیسی:</label>
                            <telerik:RadEditor ID="RadAddress1_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadAddress2" class=" control-label">آدرس دوم فارسی:</label>
                            <telerik:RadEditor ID="RadAddress2_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadAddress2" class=" control-label">آدرس دوم انگلیسی:</label>
                            <telerik:RadEditor ID="RadAddress2_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-6">
                            <label for="txtEmailSupport" class="control-label">ایمیل پشتیبانی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtEmailSupport" class="form-control" placeholder="ایمیل پشتیبانی" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtWebsite" class="control-label">وب سایت:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtWebsite" class="form-control" placeholder="وب سایت" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-6">
                            <label for="txtEmailCo" class="control-label">ایمیل کسب و کار:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtEmailCo" class="form-control" placeholder="ایمیل کسب و کار" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtAvatarImage" class="control-label">آواتار سایت:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtAvatarImage" class="form-control" placeholder="آواتار سایت" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">

                        <div class="col-lg-6">
                            <label for="txtInstagram" class=" control-label">اینستاگرام:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtInstagram" class="form-control" placeholder="اینستاگرام" />
                        </div>

                        <div class="col-lg-6">
                            <label for="txtTelegram" class=" control-label">تلگرام:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtTelegram" class="form-control" placeholder="تلگرام" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">

                        <div class="col-lg-6">
                            <label for="txtLinkedin" class=" control-label">لینکداین:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtLinkedin" class="form-control" placeholder="لینکداین" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtGoogleplus" class=" control-label">گوگل پلاس:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtGoogleplus" class="form-control" placeholder="گوگل پلاس" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">

                        <div class="col-lg-6">
                            <label for="txtTwitter" class=" control-label">توئیتر:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtTwitter" class="form-control" placeholder="توئیتر" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtFacebook" class=" control-label">فیس بوک:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtFacebook" class="form-control" placeholder="فیس بوک" />
                        </div>
                    </div>

                </div>
            </div>
            <div class="box box-info" id="About">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">درباره‌کسب و کار</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#ContactInfo" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                        <a href="#Save" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-6">
                            <label for="txtKeyword_Fa" class="control-label">کلمات کلیدی فارسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtKeyword_Fa" class="form-control" placeholder="کلمات کلیدی فارسی" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtKeyword_En" class="control-label">کلمات کلیدی انگلیسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtKeyword_En" class="form-control" placeholder="کلمات کلیدی انگلیسی" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-6">
                            <label for="txtCopyWrite_Fa" class="control-label">کپی رایت فارسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtCopyWrite_Fa" class="form-control" placeholder="کپی رایت فارسی" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtCopyWrite_En" class="control-label">کپی رایت انگلیسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtCopyWrite_En" class="form-control" placeholder="کپی رایت انگلیسی" />
                        </div>
                    </div>

                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadTerms_Fa" class="control-label">قوانین و ضوابط فارسی:</label>
                            <telerik:RadEditor ID="RadTerms_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadTerms_En" class="control-label">قوانین و ضوابط انگلیسی:</label>
                            <telerik:RadEditor ID="RadTerms_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadPrivacyPolicy_Fa" class="control-label">قوانین حریم خصوصی فارسی:</label>
                            <telerik:RadEditor ID="RadPrivacyPolicy_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadPrivacyPolicy_En" class="control-label">قوانین حریم خصوصی انگلیسی:</label>
                            <telerik:RadEditor ID="RadPrivacyPolicy_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadSafePay_Fa" class="control-label">قوانین پرداخت امن فارسی:</label>
                            <telerik:RadEditor ID="RadSafePay_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadSafePay_En" class="control-label">قوانین پرداخت امن انگلیسی:</label>
                            <telerik:RadEditor ID="RadSafePay_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadWorkingHours_Fa" class="control-label">ساعات کاری فارسی:</label>
                            <telerik:RadEditor ID="RadWorkingHours_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadWorkingHours_En" class="control-label">ساعات کاری انگلیسی:</label>
                            <telerik:RadEditor ID="RadWorkingHours_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadAbout_Fa" class="control-label">درباره‌ی کسب و فارسی:</label>
                            <telerik:RadEditor ID="RadAbout_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadAbout_En" class="control-label">درباره‌ی کسب و کار انگلیسی:</label>
                            <telerik:RadEditor ID="RadAbout_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadSpecialOffers_Fa" class="control-label">پیشنهاد ویژه فارسی:</label>
                            <telerik:RadEditor ID="RadSpecialOffers_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadSpecialOffers_En" class="control-label">پیشنهاد ویژه انگلیسی:</label>
                            <telerik:RadEditor ID="RadSpecialOffers_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-6">
                            <label for="txtSlogan_Fa" class="control-label">شعار کسب و کار فارسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtSlogan_Fa" class="form-control" placeholder="شعار کسب و کار فارسی" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtSlogan_En" class="control-label">شعار کسب و کار انگلیسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtSlogan_En" class="form-control" placeholder="شعار کسب و کار انگلیسی" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-6">
                            <label for="txtLogoImageMini" class="control-label">لوگو کوچک:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtLogoImageMini" class="form-control" placeholder="لوگو کوچک" />
                        </div>
                        <div class="col-lg-6">
                            <label for="LogoImageMax" class="control-label">لوگو بزرگ:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtLogoImageMax" class="form-control" placeholder="لوگو بزرگ" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-6">
                            <label for="txtCreateYear_Fa" class="control-label">سال تاسیس فارسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtCreateYear_Fa" class="form-control" placeholder="سال تاسیس فارسی" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtCreateYear_En" class="control-label">سال تاسیس انگلیسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtCreateYear_En" class="form-control" placeholder="سال تاسیس انگلیسی" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-6">
                            <label for="txtCreateMonth_Fa" class="control-label">ماه تاسیس فارسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtCreateMonth_Fa" class="form-control" placeholder="ماه تاسیس فارسی" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtCreateMonth_En" class="control-label">ماه تاسیس انگلیسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtCreateMonth_En" class="form-control" placeholder="ماه تاسیس انگلیسی" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-6">
                            <label for="txtCreateDay_Fa" class="control-label">روز تاسیس فارسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtCreateDay_Fa" class="form-control" placeholder="روز تاسیس فارسی" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtCreateDay_En" class="control-label">روز تاسیس انگلیسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtCreateDay_En" class="form-control" placeholder="روز تاسیس انگلیسی" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadDescription_Fa" class=" control-label">توضیحات کسب و کار فارسی:</label>
                            <telerik:RadEditor ID="RadDescription_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadDescription_En" class=" control-label">توضیحات کسب و کار انگلیسی:</label>
                            <telerik:RadEditor ID="RadDescription_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadMemo_Fa" class=" control-label">یادآوری کسب و کار فارسی:</label>
                            <telerik:RadEditor ID="RadMemo_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="RadMemo_En" class=" control-label">یادآوری کسب و کار انگلیسی:</label>
                            <telerik:RadEditor ID="RadMemo_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>

                </div>
            </div>
            <div class="row" id="Save">
                <div class="col-lg-12">
                    <asp:Button ID="btnUpdateSettings" runat="server" class="col-xs-8 btn btn-success" Text="ذخیره تغییرات" />
                    <asp:Button ID="btnSaveNewSettings" runat="server" class="col-xs-4 btn btn-primary" Text="ایجاد تنظیمات جدید" />
                </div>
            </div>
            <br />
        </div>
    </div>
    <!-- /.row -->

        <!-- /.container-fluid -->
        <!-- /#page-wrapper -->
</asp:Content>

