<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="GalleryManagement.aspx.vb" Inherits="Admin_GalleryManagement" %>

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
                    <h1 class="page-header">مدیریت آلبوم <small>مدیریت تصاویر و آلبوم‌ها</small></h1>
                    <ol class="breadcrumb">
                        <li>
                            <i class="fa fa-dashboard"></i>Dashboard
                        </li>
                        <li class="active"><i class="fa fa-bank"></i>Gallery Management
                        </li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->

            <div class="box box-success" id="Gallerys">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">دسته‌بندی:</a>
                        <%--                    <div class="form-group col-lg-12">--%>
                        <asp:LinqDataSource ID="CoverDataSource" runat="server" ContextTypeName="LinqDBClassesDataContext" EntityTypeName="" TableName="Covers" EnableDelete="True">
                            <DeleteParameters>
                                <asp:ControlParameter ControlID="CoverDropDownList" Name="IDCover" PropertyName="SelectedValue" />
                            </DeleteParameters>
                        </asp:LinqDataSource>
                        <%--<label for="Day_Fa" class=" control-label">دسته‌بندی:</label>--%>
                        <asp:DropDownList ID="CoverDropDownList" runat="server" DataSourceID="CoverDataSource" DataTextField="Title_Fa" DataValueField="IDCover" AutoPostBack="True">
                        </asp:DropDownList>
                        <%--                        </div>--%>
                    </h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#GalleryStatus" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:GridView ID="GallerysView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="SqlDataSourceGallerys" Width="100%" DataKeyNames="IDG">
                                <Columns>
                                    <asp:CommandField ButtonType="Button" SelectText="انتخاب" ShowSelectButton="True">
                                        <ControlStyle CssClass="btn btn-success btn-xs" Width="100%" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Name_Fa" HeaderText="نام فارسی" SortExpression="Name_Fa">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Name_En" HeaderText="نام انگلیسی" SortExpression="Name_En">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField DataField="NameFr" HeaderText="نام فرانسوی" SortExpression="NameFr">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NameAr" HeaderText="نام عربی" SortExpression="NameAr">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>--%>
                                    <asp:TemplateField HeaderText="تصویر">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <a runat="server" id="imgz" href='<%# Bind("Address") %>'>
                                                <center><asp:Image ID='Image1' Style='width: 43px; height: 23px;' class='img-responsive text-center' runat='server' ImageUrl='<%# Bind("Address") %>' /></center>
                                            </a>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="text-center" />
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:CommandField ButtonType="Button" DeleteText="حذف" ShowDeleteButton="True">
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
                            <asp:SqlDataSource ID="SqlDataSourceGallerys" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT * FROM [Gallery] WHERE IDCover=@IDCover ORDER BY [IDG] DESC, [Name_Fa]" DeleteCommand="DELETE FROM [Gallery] WHERE [IDG]=@IDG">
                                <DeleteParameters>
                                    <asp:Parameter Name="IDG" />
                                </DeleteParameters>
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="CoverDropDownList" Name="IDCover" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                    <%--<div class="row">
                        <div class="col-lg-12">
                            <asp:Label runat="server" ID="lblShowGallery" Style="width: 100%;" Visible="false" />
                        </div>
                    </div>--%>
                </div>
            </div>
            <div class="box box-warning" id="GalleryStatus">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">وضعیت تصویر</a></h3>

                    <div class="box-tools pull-right">
                        <%--<a href="#Gallerys" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                        <a href="#GalleryInfo_Fa" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="contact-Title" class="control-label">زمان انتشار شمسی:</label>
                                <asp:Label runat="server" ID="lblMomentOld_Fa" Style="color: rgb(255, 154, 52);" />
                                <div class="input-group date">
                                    <div class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </div>
                                    <input runat="server" type="text" id="tarikh" class="form-control pull-right" />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="contact-Title" class="control-label">زمان انتشار میلادی:</label>
                                <asp:Label runat="server" ID="lblMomentOld_En" Style="color: rgb(255, 154, 52);" />
                                <div class="input-group date">
                                    <div class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </div>
                                    <input runat="server" type="text" id="txtMoment_En" style="direction: ltr; text-align: right;" class="form-control pull-right" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <label for="txtAddress" class=" control-label">تصویر:</label>
                            </div>
                            <div class="col-lg-12 center-block">
                                <asp:TextBox runat="server" for="Text" ID="txtAddress" Style="margin-bottom: 30px;direction: ltr;text-align:left;" class="form-control" placeholder="آدرس تصویر پیام" />
                            </div>
                        </div>
                    </div>
                    <%--<div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <a href="#Save" style="margin-bottom: 30px; float: left;" class="btn btn-info"><i class="fa fa-arrow-circle-down"></i></a>
                            </div>
                        </div>
                    </div>--%>
                </div>
            </div>
            <div class="box box-success" id="GalleryInfo_Fa">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">اطلاعات تصویر به فارسی</a></h3>
                    <div class="box-tools pull-right">
<%--                        <a href="#GalleryStatus" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                        <a href="#GalleryInfo_En" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>عنوان فارسی:</label>
                                <asp:TextBox runat="server" ID="txtName_Fa" placeholder="عنوان تصویر به فارسی" class="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>محل فارسی:</label>
                                <asp:TextBox runat="server" ID="txtLocation_Fa" placeholder="محل تصویر گرفته شده به فارسی" type="number" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <label for="RadGalleryDescription_Fa" class="control-label">توضیحات تصویر به فارسی:</label>
                            </div>
                            <div class="col-lg-12 center-block">
                                <telerik:RadEditor ID="RadGalleryDescription_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating" DocumentManager-ViewPaths="~/Uploads" ImageManager-ViewPaths="~/Uploads"></telerik:RadEditor>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="btn-group col-lg-12">
                                <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertImageGalleryDescription_Fa" class="btn btn-success"><i class="fa fa-image"> درج در مطلب</i></asp:LinkButton>
                                <asp:TextBox runat="server" ID="FileNameGalleryDescription_Fa" PlaceHolder="آدرس تصویر در هاست" Style="width: 135px; height: 28px; direction: ltr;text-align: left;" />
                                <asp:Label runat="server" ID="lblInsertImageState_Fa" Style="float: left;" class="label label-success" Visible="false" Text="تصویر با موفقیت در مطلب درج شد. " />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <label for="txtKeyword_Fa" class=" control-label">برچسب به فارسی:</label>
                            </div>
                            <div class="col-lg-12 center-block">
                                <asp:TextBox ID="txtKeyword_Fa" Style="margin-bottom: 30px;" class="form-control" placeholder="کلمات کلیدی را با ; جدا کنید." runat="server" Width="100%" />
                            </div>
                        </div>
                    </div>

                </div>
                <!-- /.row -->
            </div>
            <div class="box box-success" id="GalleryInfo_En">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">اطلاعات تصویر به انگلیسی</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#GalleryInfo_Fa" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                        <a href="#Save" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>عنوان انگلیسی:</label>
                                <asp:TextBox runat="server" ID="txtName_En" style="direction: ltr;text-align:left;" placeholder="عنوان تصویر به انگلیسی" class="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>محل انگلیسی:</label>
                                <asp:TextBox runat="server" ID="txtLocation_En" style="direction: ltr;text-align:left;" placeholder="محل تصویر گرفته شده به انگلیسی" type="number" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <label for="RadDescription_En" class="control-label">توضیحات تصویر به انگلیسی:</label>
                            </div>
                            <div class="col-lg-12 center-block">
                                <telerik:RadEditor ID="RadGalleryDescription_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating" DocumentManager-ViewPaths="~/Uploads" ImageManager-ViewPaths="~/Uploads"></telerik:RadEditor>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="btn-group col-lg-12">
                                <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertImageGalleryDescription_En" class="btn btn-success"><i class="fa fa-image"> درج در مطلب</i></asp:LinkButton>
                                <asp:TextBox runat="server" ID="FileNameGalleryDescription_En" PlaceHolder="آدرس تصویر در هاست" Style="width: 135px; height: 28px; direction: ltr;text-align: left;" />
                                <asp:Label runat="server" ID="lblInsertImageState_En" Style="float: left;" class="label label-success" Visible="false" Text="تصویر با موفقیت در مطلب درج شد. " />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <label for="txtKeyword_En" class=" control-label">برچسب به انگلیسی:</label>
                            </div>
                            <div class="col-lg-12 center-block">
                                <asp:TextBox ID="txtKeyword_En" Style="margin-bottom: 30px;direction: ltr;text-align:left;" class="form-control" placeholder="کلمات کلیدی را با ; جدا کنید." runat="server" Width="100%" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
<%--            <div class="box box-success" id="GalleryInfoFr">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">اطلاعات تصویر به فرانسوی</a></h3>
                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>عنوان فرانسوی:</label>
                                <asp:TextBox runat="server" ID="txtNameFr" placeholder="عنوان تصویر به فرانسوی" class="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>محل فرانسوی:</label>
                                <asp:TextBox runat="server" ID="txtLocationFr" placeholder="محل تصویر گرفته شده به فرانسوی" type="number" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <label for="RadGalleryDescriptionFr" class="control-label">توضیحات تصویر به فرانسوی:</label>
                            </div>
                            <div class="col-lg-12 center-block">
                                <telerik:RadEditor ID="RadGalleryDescriptionFr" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating" DocumentManager-ViewPaths="~/Uploads" ImageManager-ViewPaths="~/Uploads"></telerik:RadEditor>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="btn-group col-lg-12">
                                <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertImageGalleryDescriptionFr" class="btn btn-success"><i class="fa fa-image"> درج در مطلب</i></asp:LinkButton>
                                <asp:TextBox runat="server" ID="FileNameGalleryDescriptionFr" PlaceHolder="آدرس تصویر در هاست" Style="width: 135px; height: 28px; direction: ltr;" />
                                <asp:Label runat="server" ID="lblInsertImageStateFr" Style="float: left;" class="label label-success" Visible="false" Text="تصویر با موفقیت در مطلب درج شد. " />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <label for="txtKeywordFr" class=" control-label">برچسب به فرانسوی:</label>
                            </div>
                            <div class="col-lg-12 center-block">
                                <asp:TextBox ID="txtKeywordFr" Style="margin-bottom: 30px;" class="form-control" placeholder="کلمات کلیدی را با ; جدا کنید." runat="server" Width="100%" />
                            </div>
                        </div>
                    </div>

                </div>
                <!-- /.row -->
            </div>--%>
<%--            <div class="box box-success" id="GalleryInfoAr">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">اطلاعات تصویر به عربی</a></h3>
                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>عنوان عربی:</label>
                                <asp:TextBox runat="server" ID="txtNameAr" placeholder="عنوان تصویر به عربی" class="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>محل عربی:</label>
                                <asp:TextBox runat="server" ID="txtLocationAr" placeholder="محل تصویر گرفته شده به عربی" type="number" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <label for="RadDescriptionAr" class="control-label">توضیحات تصویر به عربی:</label>
                            </div>
                            <div class="col-lg-12 center-block">
                                <telerik:RadEditor ID="RadGalleryDescriptionAr" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating" DocumentManager-ViewPaths="~/Uploads" ImageManager-ViewPaths="~/Uploads"></telerik:RadEditor>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="btn-group col-lg-12">
                                <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertImageGalleryDescriptionAr" class="btn btn-success"><i class="fa fa-image"> درج در مطلب</i></asp:LinkButton>
                                <asp:TextBox runat="server" ID="FileNameGalleryDescriptionAr" PlaceHolder="آدرس تصویر در هاست" Style="width: 135px; height: 28px; direction: ltr;" />
                                <asp:Label runat="server" ID="lblInsertImageStateAr" Style="float: left;" class="label label-success" Visible="false" Text="تصویر با موفقیت در مطلب درج شد. " />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <label for="txtKeywordAr" class=" control-label">برچسب به عربی:</label>
                            </div>
                            <div class="col-lg-12 center-block">
                                <asp:TextBox ID="txtKeywordAr" Style="margin-bottom: 30px;" class="form-control" placeholder="کلمات کلیدی را با ; جدا کنید." runat="server" Width="100%" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>
            <div class="col-lg-12" id="Save">
                <div class="form-group">
                    <asp:Button ID="btnUpdateGallery" runat="server" class="col-xs-6 btn btn-default" Text="ذخیره تغییرات" />
                    <asp:Button ID="btnSaveNewGallery" runat="server" class="col-xs-6 btn btn-primary" Text="ایجاد تصویر جدید" />
                </div>

            </div>
        </div>
        <!-- /.container-fluid -->
    </div>
</asp:Content>

