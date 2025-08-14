<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="BlockManagement.aspx.vb" Inherits="Admin_BlockManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                    <h1 class="page-header">مدیریت بلاک <small>بلاک در مطالب سایت</small></h1>

                    <ol class="breadcrumb">
                        <li>
                            <i class="fa fa-dashboard"></i>Dashboard
                        </li>
                        <li class="active">
                            <i class="fa fa-bank"></i>Block Management
                        </li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->

            <div class="box box-success" id="Blocks">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color:black;" data-widget="collapse" >بلاک‌ها</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#Links" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">

                        <div class="col-lg-12">
                            <asp:GridView ID="BlockView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="SqlDataSourceBlocks" Width="100%" DataKeyNames="IDB">
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
                            <asp:SqlDataSource ID="SqlDataSourceBlocks" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT * FROM [Blocks] ORDER BY [IDB], [Name_Fa]" DeleteCommand="DELETE FROM [Blocks] WHERE [IDB]=@IDB">
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
                                <asp:TextBox runat="server" ID="txtBlockName_Fa" placeholder="فارسی" class="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>نام انگلیسی:</label>
                                <asp:TextBox runat="server" ID="txtBlockName_En" placeholder="انگلیسی" class="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>اولویت نمایش:</label>
                                <asp:TextBox runat="server" ID="txtPriorityBlock" placeholder="اولویت" type="number" class="form-control" />
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="form-group">
                                <asp:Button ID="btnUpdateBlock" runat="server" class="col-xs-6 btn btn-default" Text="ذخیره تغییرات" />
                                <asp:Button ID="btnSaveNewBlock" runat="server" class="col-xs-6 btn btn-primary" Text="ایجاد بلاک جدید" />
                            </div>

                        </div>

                    </div>
                    <!-- /.row -->
                </div>
            </div>

        </div>
        <!-- /.container-fluid -->
    </div>

</asp:Content>

