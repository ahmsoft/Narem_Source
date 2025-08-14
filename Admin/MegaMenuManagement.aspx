<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="MegaMenuManagement.aspx.vb" Inherits="Admin_MegaMenuManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                    <h1 class="page-header">مدیریت مگا منو <small>مدیریت مگا منو سایت</small></h1>
                    <ol class="breadcrumb">
                        <li>
                            <i class="fa fa-dashboard"></i>Dashboard
                        </li>
                        <li class="active">
                            <i class="fa fa-edit"></i>MegaMenu Management
                        </li>
                    </ol>
                </div>
            </div>
            <div class="box box-default" id="MegaMenu">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">منوهای دارای ویژگی مگا </a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#Cate" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>--%>
                        <asp:Button runat="server" ID="btnShowAll" type="button" class="btn btn-box-tool" data-widget="" Text="نمایش تمام منوها" />
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">

                        <div class="col-lg-12">
                            <asp:GridView ID="MegaMenuView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="DataSourceMegaMenu" Width="100%" DataKeyNames="IDM">
                                <Columns>
                                    <asp:CommandField ButtonType="Button" SelectText="انتخاب" ShowSelectButton="True">
                                        <ControlStyle CssClass="btn btn-success btn-xs" Width="100%" />
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Name_Fa" HeaderText="نام فارسی" SortExpression="Name_Fa">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Name_En" HeaderText="نام انگلیسی" SortExpression="Name_En">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:CommandField ButtonType="Button" DeleteText="حذف" ShowDeleteButton="True">
                                        <ControlStyle CssClass="btn btn-danger btn-xs" Width="100%" />
                                        <HeaderStyle CssClass="text-center" />
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
            <div class="box box-success" id="MegaMenu_Fa">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">مگا منو فارسی</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#MessageInfo" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                                <a href="#Message_En" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <label for="txtTitle_Fa" class=" control-label">لینک: </label>
                            </div>
                            <div class="col-lg-12">
                                <asp:TextBox runat="server" for="Text" ID="txtHref" Style="margin-bottom: 6px;" class="form-control" placeholder="لینک Href"/>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <label for="RadMegaMenu_Fa" class=" control-label">محتوای منو فارسی:</label>
                            </div>
                            <div class="col-lg-12 center-block">
                                <telerik:RadEditor ID="RadMegaMenu_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating" DocumentManager-ViewPaths="~/Uploads" ImageManager-ViewPaths="~/Uploads"></telerik:RadEditor>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <label for="txtMegaPic" class="col-lg-12 control-label">تصویر مگا منو:</label>
                            <div class="col-lg-12">
                                <asp:TextBox runat="server" for="Text" ID="txtMegaPic" Style="margin-bottom: 30px;" class="form-control" placeholder="تصویر مگا" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="box box-info" id="MegaMenu_En">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">محتوای منو انگلیسی</a></h3>

                    <div class="box-tools pull-right">
                        <%--<a href="#MegaMenu_Fa" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                                <a href="#Save" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <label for="RadMegaMenu_En" class=" control-label">محتوای منو انگلیسی:</label>
                            </div>
                            <div class="col-lg-12 center-block">
                                <telerik:RadEditor ID="RadMegaMenu_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" id="Save" style="margin-bottom: 30px;">
                <div class="form-group">
                    <div class="col-md-12 btn-group">
                        <asp:Button ID="btnUpdateMegaMenu" runat="server" class="col-xs-6 btn btn-default" Text="ذخیره تغییرات" />
                        <asp:Button ID="btnSaveNewMegaMenu" runat="server" class="col-xs-6 btn btn-primary" Text="ایجاد مگا منو جدید" />
                    </div>
                </div>
            </div>
        </div>
        <!-- /.row -->
        <!-- /.container-fluid -->
        <div class="row">
                <div class="col-lg-12">
                    <asp:SqlDataSource ID="DataSourceMegaMenu" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT * FROM [Menu] WHERE MegaMenu=1 ORDER BY IDM DESC" DeleteCommand="Delete From [Menu] Where [IDM]=@IDM">
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="MegaMenuView" Name="IDM" PropertyName="SelectedValue" />
                        </DeleteParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
    </div>
</asp:Content>

