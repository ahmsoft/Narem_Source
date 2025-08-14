<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="MenuManagement.aspx.vb" Inherits="Admin_MenuManagement" %>

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
                    <h1 class="page-header">مدیریت منوها <small>مدیریت منوی اصلی سایت</small></h1>

                    <ol class="breadcrumb">
                        <li>
                            <i class="fa fa-dashboard"></i>Dashboard
                        </li>
                        <li class="active">
                            <i class="fa fa-bank"></i>Menu Management
                        </li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
            <div class="box box-success" id="Menus">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">منو‌ها</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#Links" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:GridView ID="MenuView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="SqlDataSourceMenus" Width="100%" DataKeyNames="IDM">
                                <Columns>
                                    <asp:CommandField ButtonType="Button" SelectText="انتخاب" ShowSelectButton="True">
                                        <ControlStyle CssClass="btn btn-success btn-xs" Width="100%" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Name_Fa" HeaderText="نام" SortExpression="Name">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Priority" HeaderText="اولویت" SortExpression="Priority">
                                        <HeaderStyle CssClass="text-center" />
                                        <ItemStyle CssClass="text-center" />
                                    </asp:BoundField>
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
                            <asp:SqlDataSource ID="SqlDataSourceMenus" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT * FROM [Menu] ORDER BY [IDM], [Name_Fa]" DeleteCommand="DELETE FROM [Menu] WHERE [IDM]=@IDM">
                                <DeleteParameters>
                                    <asp:Parameter Name="IDB" />
                                </DeleteParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>نام فارسی:</label>
                                <asp:TextBox runat="server" ID="txtName_Fa" placeholder="فارسی" class="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>نام انگلیسی:</label>
                                <asp:TextBox runat="server" ID="txtName_En" placeholder="انگلیسی" class="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>اولویت نمایش:</label>
                                <asp:TextBox runat="server" ID="txtPriority" placeholder="اولویت" type="number" class="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>مگا منو:</label>
                                <asp:DropDownList runat="server" ID="drpMega" class="form-control">
                                    <asp:ListItem Value="True">بله</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="False">خیر</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>توضیح فارسی:</label>
                                <asp:TextBox runat="server" ID="txtAlt_Fa" placeholder="توضیح فارسی" class="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>توضیح انگلیسی:</label>
                                <asp:TextBox runat="server" ID="txtAlt_En" placeholder="توضیح انگلیسی" class="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>آدرس لینک:</label>
                                <asp:TextBox runat="server" ID="txtHref" placeholder="href آدرس لینک" class="form-control" />
                            </div>
                        </div>
                        <div class="form-group col-lg-6" runat="server" id="drpLinkTargetState">
                            <label>مقصد:</label>
                            <asp:DropDownList runat="server" ID="drpLinkTarget" placeholder="انتخاب مقصد" class="form-control">
                                <asp:ListItem Value="_blank">پنجره جدید</asp:ListItem>
                                <asp:ListItem Value="_self">پنجره جاری</asp:ListItem>
                                <asp:ListItem Value="_parent">صفحه اصلی</asp:ListItem>
                                <asp:ListItem Value="_top">صفحه جاری</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>دارای زیر منو:</label>
                                <asp:DropDownList runat="server" ID="drpHasSub" class="form-control">
                                    <asp:ListItem Value="True">بله</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="False">خیر</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>نمایش:</label>
                                <asp:DropDownList runat="server" ID="drpShow" class="form-control">
                                    <asp:ListItem Value="True">بله</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="False">خیر</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <!-- /.row -->
                </div>
            </div>
            <div class="row" id="Save" style="margin-bottom: 30px;">
                <div class="form-group">
                    <div class="col-md-12 btn-group">
                        <asp:Button ID="btnUpdateMenu" runat="server" class="col-xs-6 btn btn-default" Text="ذخیره تغییرات" />
                        <asp:Button ID="btnSaveNewMenu" runat="server" class="col-xs-6 btn btn-primary" Text="ایجاد منو جدید" />
                    </div>
                </div>
            </div>


        </div>
        <!-- /.container-fluid -->
    </div>
</asp:Content>

