<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="EffectsManagement.aspx.vb" Inherits="Admin_EffectsManagement" %>

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
                    <h1 class="page-header">مدیریت آثار <small>مدیریت کارهای انجام شده</small></h1>
                    <ol class="breadcrumb">
                        <li>
                            <i class="fa fa-dashboard"></i>Dashboard
                        </li>
                        <li class="active"><i class="fa fa-bank"></i>Portfolio Management
                        </li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->

            <div class="box box-success" id="Covers">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">جلدها</a></h3>
                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">

                        <div class="col-lg-12">
                            <asp:GridView ID="CoversViewPortf" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="SqlDataSourceCoversPortf" Width="100%" DataKeyNames="IDP">
                                <Columns>
                                    <asp:CommandField ButtonType="Button" SelectText="انتخاب" ShowSelectButton="True">
                                        <ControlStyle CssClass="btn btn-success btn-xs" Width="100%" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Title_Fa" HeaderText="عنوان فارسی" SortExpression="Title_Fa">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Title_En" HeaderText="عنوان انگلیسی" SortExpression="Title_En">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="تصویر">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <a runat="server" id="imgz" href='<%# Bind("Image") %>'>
                                                <center><asp:Image ID='Image1' Style='width: 43px; height: 23px;' class='img-responsive text-center' runat='server' ImageUrl='<%# Bind("Image") %>' /></center>
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
                            <asp:SqlDataSource ID="SqlDataSourceCoversPortf" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT * FROM [Portfolio] ORDER BY [IDP] DESC, [Title_Fa]" DeleteCommand="DELETE FROM [Portfolio] WHERE [IDP]=@IDP">
                                <DeleteParameters>
                                    <asp:Parameter Name="IDP" />
                                </DeleteParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>
            <div class="box box-warning" id="CoverStatus">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">وضعیت جلد</a></h3>

                    <div class="box-tools pull-right">
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
                                <asp:TextBox runat="server" for="Text" ID="txtAddress" Style="margin-bottom: 30px;direction: ltr;text-align:left;" class="form-control" placeholder="آدرس تصویر پیام" /> <span>(1366*768)px</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="box box-success" id="CoverInfo_Fa">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">اطلاعات جلد به فارسی</a></h3>
                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <label for="txtTitle_Fa" class=" control-label">عنوان به فارسی:</label>
                            </div>
                            <div class="col-lg-12 center-block">
                                <asp:TextBox ID="txtTitle_Fa" Style="margin-bottom: 30px;" class="form-control" placeholder="عنوان جلد نمونه کار" runat="server" Width="100%" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>دسته‌بندی فارسی:</label>
                                <asp:TextBox runat="server" ID="txtCat_Fa" placeholder="دسته‌بندی جلد به فارسی" class="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>دسته‌بندی انگلیسی:</label>
                                <asp:TextBox runat="server" ID="txtCat_En" placeholder="دسته‌بندی جلد به انگلیسی" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <label for="RadCoverDescription_Fa" class="control-label">توضیحات جلد به فارسی:</label>
                            </div>
                            <div class="col-lg-12 center-block">
                                <telerik:RadEditor ID="RadCoverDescription_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating" DocumentManager-ViewPaths="~/Uploads" ImageManager-ViewPaths="~/Uploads"></telerik:RadEditor>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="btn-group col-lg-12">
                                <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertImageCoverDescription_Fa" class="btn btn-success"><i class="fa fa-image"> درج در مطلب</i></asp:LinkButton>
                                <asp:TextBox runat="server" ID="FileNameCoverDescription_Fa" PlaceHolder="آدرس تصویر در هاست" Style="width: 135px; height: 28px; direction: ltr;text-align: left;" />
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
            <div class="box box-success" id="CoverInfo_En">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">اطلاعات جلد به انگلیسی</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#CoverInfo_Fa" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                        <a href="#Save" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <label for="txtTitle_En" class=" control-label">عنوان به انگلیسی:</label>
                            </div>
                            <div class="col-lg-12 center-block">
                                <asp:TextBox ID="txtTitle_En" Style="margin-bottom: 30px;direction: ltr;text-align: left;" class="form-control" placeholder="عنوان جلد نمونه کار" runat="server" Width="100%" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <label for="RadCoverDescription_En" class="control-label">توضیحات جلد به انگلیسی:</label>
                            </div>
                            <div class="col-lg-12 center-block">
                                <telerik:RadEditor ID="RadCoverDescription_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating" DocumentManager-ViewPaths="~/Uploads" ImageManager-ViewPaths="~/Uploads"></telerik:RadEditor>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="btn-group col-lg-12">
                                <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertImageCoverDescription_En" class="btn btn-success"><i class="fa fa-image"> درج در مطلب</i></asp:LinkButton>
                                <asp:TextBox runat="server" ID="FileNameCoverDescription_En" PlaceHolder="آدرس تصویر در هاست" Style="width: 135px; height: 28px; direction: ltr;text-align: left;" />
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
                                <asp:TextBox ID="txtKeyword_En" Style="margin-bottom: 30px;direction: ltr;text-align: left;" class="form-control" placeholder="کلمات کلیدی را با ; جدا کنید." runat="server" Width="100%" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-12" id="Save">
                <div class="form-group">
                    <asp:Button ID="btnUpdateEffect" runat="server" class="col-xs-6 btn btn-default" Text="ذخیره تغییرات" />
                    <asp:Button ID="btnSaveNewEffect" runat="server" class="col-xs-6 btn btn-primary" Text="ایجاد اثر جدید" />
                </div>

            </div>
        </div>
        <!-- /.container-fluid -->
    </div>
</asp:Content>

