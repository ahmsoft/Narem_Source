<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="Profile.aspx.vb" Inherits="Admin_Profile" %>

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
                    <h1 class="page-header">مدیریت پیام <small>پیام های مطالب سایت</small></h1>

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
            <div class="box box-default" id="UsersList">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color:black;" data-widget="collapse" >لیست کاربران</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#ContactInfo" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:SqlDataSource ID="SqlDataSourceUsers" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT [Username], [IDU] FROM [User]"></asp:SqlDataSource>

                            <asp:GridView ID="UserView" runat="server" AllowSorting="True" DataSourceID="SqlDataSourceUsers" AutoGenerateColumns="False" DataKeyNames="IDU" CellPadding="4" ForeColor="#333333" Width="100%" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField ButtonType="Button" SelectText="انتخاب" ShowSelectButton="True">
                                        <HeaderStyle CssClass="text-center" />
                                        <ControlStyle CssClass="btn btn-success btn-xs" Width="100%" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Username" HeaderText="نام کاربری" SortExpression="Usersname">
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
                    <h3 class="box-title"><a href="#" style="color:black;" data-widget="collapse" >اطلاعات تماس</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#UsersList" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                        <a href="#About" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row" style="margin-bottom:15px;">
                        <div class="col-lg-6">
                            <label for="txtPhone1" class="control-label">تلفن:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtPhone1" class="form-control" placeholder="تلفن" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtMobile1" class="control-label">موبایل:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtMobile1" class="form-control" placeholder="موبایل" />
                        </div>
                        <%--<div class="col-lg-6">
                            <label for="txtPhone2" class="control-label">تلفن دوم:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtPhone2" class="form-control" placeholder="تلفن دوم" />
                        </div>--%>
                    </div>
                    <div class="row"style="margin-bottom:15px;">
                        <div class="col-lg-12">
                            <label for="RadAddress1" class=" control-label">آدرس:</label>
                            <telerik:RadEditor ID="RadAddress1" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <%--<div class="row"style="margin-bottom:15px;">
                        <div class="col-lg-12 center-block">
                            <label for="RadAddress2" class=" control-label">آدرس دوم:</label>
                            <telerik:RadEditor ID="RadAddress2" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>--%>

                    <%--<div class="row"style="margin-bottom:15px;">
                        <div class="col-lg-12">
                            <label for="txtMobile1" class="control-label">موبایل:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtMobile1" class="form-control" placeholder="موبایل اول" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtMobile2" class="control-label">موبایل دوم:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtMobile2" class="form-control" placeholder="موبایل دوم" />
                        </div>
                    </div>--%>
                    <div class="row"style="margin-bottom:15px;">
                        <div class="col-lg-6">
                            <label for="txtEmail" class="control-label">ایمیل:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtEmail" class="form-control" placeholder="ایمیل" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtWebsite" class="control-label">وب سایت:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtWebsite" class="form-control" placeholder="وب سایت" />
                        </div>
                    </div>
                    <div class="row"style="margin-bottom:15px;">

                        <div class="col-lg-6">
                            <label for="txtInstagram" class=" control-label">اینستاگرام:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtInstagram" class="form-control" placeholder="اینستاگرام" />
                        </div>

                        <div class="col-lg-6">
                            <label for="txtTelegram" class=" control-label">تلگرام:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtTelegram" class="form-control" placeholder="تلگرام" />
                        </div>
                    </div>
                    <div class="row"style="margin-bottom:15px;">

                        <div class="col-lg-6">
                            <label for="txtLinkedin" class=" control-label">لینکداین:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtLinkedin" class="form-control" placeholder="لینکداین" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtGoogleplus" class=" control-label">گوگل پلاس:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtGoogleplus" class="form-control" placeholder="گوگل پلاس" />
                        </div>
                    </div>
                    <div class="row"style="margin-bottom:15px;">

                        <div class="col-lg-6">
                            <label for="txtTwitter" class=" control-label">توئیتر:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtTwitter" class="form-control" placeholder="توئیتر" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtFacebook" class=" control-label">فیس بوک:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtFacebook" class="form-control" placeholder="فیس بوک" />
                        </div>
                    </div>
                    <%--<div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <a href="#Save" style="margin: 15px; float: left;" class="btn btn-info"><i class="fa fa-save"></i></a>
                            </div>
                        </div>
                    </div>--%>
                </div>
            </div>
            <div class="box box-info" id="About">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color:black;" data-widget="collapse" >درباره‌ما</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#ContactInfo" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                        <a href="#Save" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row"style="margin-bottom:15px;">
                        <div class="col-lg-6">
                            <label for="txtPhotoMax" class="control-label">آدرس عکس بزرگ:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtPhotoMax" class="form-control" placeholder="آدرس عکس بزرگ" />
                        </div>
                        <div class="col-lg-6">
                            <label for="txtPhotoMin" class="control-label">آدرس عکس کوچک:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtPhotoMin" class="form-control" placeholder="آدرس عکس کوچک" />
                        </div>
                    </div>
                    <%--<div class="row"style="margin-bottom:15px;">
                        <div class="col-lg-12">
                            <label for="RadResumeFile" class="control-label">فایل رزومه:</label>
                            <asp:TextBox runat="server" ID="txtResumeFile" class="form-control" placeholder="آدرس فایل رزومه" />
                        </div>
                    </div>--%>
                    <div class="row"style="margin-bottom:15px;">
                        <div class="col-lg-12">
                            <label for="RadBiography_Fa" class="control-label">بیوگرافی فارسی:</label>
                            <telerik:RadEditor ID="RadBiography_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row"style="margin-bottom:15px;">
                        <div class="col-lg-12">
                            <label for="RadBiography_En" class="control-label">بیوگرافی انگلیسی:</label>
                            <telerik:RadEditor ID="RadBiography_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <%--<div class="row"style="margin-bottom:15px;">
                        <div class="col-lg-12">
                            <label for="RadAbout_Fa" class="control-label">درباره‌ی من فارسی:</label>
                            <telerik:RadEditor ID="RadAbout_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row"style="margin-bottom:15px;">
                        <div class="col-lg-12">
                            <label for="RadAbout_En" class="control-label">درباره‌ی من انگلیسی:</label>
                            <telerik:RadEditor ID="RadAbout_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>--%>
                    <div class="row"style="margin-bottom:15px;">
                        <div class="col-lg-12">
                            <label for="txtJob_Fa" class="control-label">شغل فارسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtJob_Fa" class="form-control" placeholder="شغل فارسی" />
                        </div>
                    </div>
                    <div class="row"style="margin-bottom:15px;">
                        <div class="col-lg-12">
                            <label for="txtJob_En" class="control-label">شغل انگلیسی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtJob_En" class="form-control" placeholder="شغل انگلیسی" />
                        </div>
                    </div>
<%--                    <div class="row"style="margin-bottom:15px;">
                        <div class="col-lg-12">
                            <label for="RadBioEdu_Fa" class="control-label">سوابق تحصیلی فارسی:</label>
                            <telerik:RadEditor ID="RadBioEdu_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row"style="margin-bottom:15px;">
                        <div class="col-lg-12">
                            <label for="RadBioEdu_En" class="control-label">سوابق تحصیلی انگلیسی:</label>
                            <telerik:RadEditor ID="RadBioEdu_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row"style="margin-bottom:15px;">
                        <div class="col-lg-12">
                            <label for="RadBioJob_Fa" class="control-label">سوابق شغلی فارسی:</label>
                            <telerik:RadEditor ID="RadBioJob_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>
                    <div class="row"style="margin-bottom:15px;">
                        <div class="col-lg-12">
                            <label for="RadBioJob_En" class=" control-label">سابقه شغلی انگلیسی:</label>
                            <telerik:RadEditor ID="RadBioJob_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                        </div>
                    </div>--%>
                    <%--<div class="row"style="margin-bottom:15px;">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <a href="#Save" style="float: left;" class="btn btn-info"><i class="fa fa-save"></i></a>
                            </div>
                        </div>
                    </div>--%>
                </div>
            </div>
            <div class="box box-danger collapsed-box" runat="server" id="ChangePassword">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color:black;" data-widget="collapse">تغییر گذرواژه</a></h3>
                    <div class="box-tools pull-right">
<%--                        <a href="#About" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">                    
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <asp:Label runat="server" ID="lblValidOldPass" Text="*" style="color:red" Visible="false" />
                            <label for="txtOPassword" class="control-label">رمز فعلی:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtOPassword" class="form-control" placeholder="رمز فعلی" TextMode="Password" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <label for="txtPassword" class="control-label">رمز جدید:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtPassword" class="form-control" placeholder="رمز جدید" TextMode="Password" />
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <asp:CompareValidator ID="PasswordCompareValidator" runat="server" ErrorMessage="*" style="color:red;" ControlToValidate="txtPassword" ControlToCompare="txtRPassword"></asp:CompareValidator>
                            <label for="txtRPassword" class="control-label">تکرار رمز جدید:</label>
                            <asp:TextBox runat="server" for="Text" ID="txtRPassword" class="form-control" placeholder="تکرار رمز جدید" TextMode="Password" />
                        </div>
                    </div>
<%--                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <a href="#page-wrapper" title="بالای صفحه" style="margin-bottom: 15px; float: right;" class="btn btn-info"><i class="fa fa-arrow-circle-up"></i></a>
                            </div>
                        </div>
                    </div>--%>
                </div>
            </div>
            <div class="row" id="Save">
                <div class="col-lg-12">
                    <asp:Button ID="btnUpdateProfile" runat="server" class="col-lg-12 btn btn-success" Text="ذخیره تغییرات" />
                    <%--                        <asp:Button ID="btnSaveNewProfile" runat="server" class="col-xs-6 btn btn-primary" Text="ایجاد پیام جدید" />--%>
                </div>
            </div>

        </div>
    </div>
    <!-- /.row -->

    <!-- /.container-fluid -->
    <!-- /#page-wrapper -->
</asp:Content>

