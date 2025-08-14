<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="StudentsManagement.aspx.vb" Inherits="Admin_Students" %>

<%@ Register TagPrefix="qsf" Namespace="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <script src="AdminComponents/scripts.js" type="text/javascript"></script>
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
                    <h1 class="page-header">آپلودسنتر <small>مدیریت کاربران آموزشی</small></h1>
                    <ol class="breadcrumb">
                        <li>
                            <i class="fa fa-dashboard"></i>Dashboard
                        </li>
                        <li class="active">
                            <i class="fa fa-edit"></i>Students Management
                        </li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
            <div class="box box-default" id="Posts">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">مقطع تحصیلی:</a>                        <%--                    <div class="form-group col-lg-12">--%>
                        <%--<label for="Day_Fa" class=" control-label">دسته‌بندی:</label>--%>
                        <asp:SqlDataSource ID="DataSourceStudents" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT * FROM [Student] WHERE Evidence_Fa = @Evidence_Fa ORDER BY IDS DESC" DeleteCommand="Delete From [Student] Where [IDNo]=@IDNo">
                            <DeleteParameters>
                                <asp:ControlParameter ControlID="StudentsView" Name="IDNo" PropertyName="SelectedValue" />
                            </DeleteParameters>

                            <SelectParameters>
                                <asp:ControlParameter ControlID="drpEvidence" Name="Evidence_Fa" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:DropDownList ID="drpEvidence" runat="server" AutoPostBack="true">
                            <asp:ListItem Text="انتخاب کنید" Value="0" Selected="True">   </asp:ListItem>
                            <asp:ListItem Text="دکتری تخصصی" Value="دکتری تخصصی">   </asp:ListItem>
                            <asp:ListItem Text="فوق لیسانس" Value="فوق لیسانس">   </asp:ListItem>
                            <asp:ListItem Text="لیسانس" Value="لیسانس">   </asp:ListItem>
                            <asp:ListItem Text="فوق دیپلم" Value="فوق دیپلم">   </asp:ListItem>
                            <asp:ListItem Text="دیپلم" Value="دیپلم">   </asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox runat="server" ID="txtSearch" placeholder="جستجو" AutoPostBack="true" />

                        <%--                        </div>--%>
                    </h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#Cate" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>--%>
                        <asp:Button runat="server" ID="btnShowAll" type="button" class="btn btn-box-tool" data-widget="" Text="نمایش تمام نفرات" />
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">

                        <div class="col-lg-12">
                            <asp:GridView ID="StudentsView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="DataSourceStudents" Width="100%" DataKeyNames="IDNo">
                                <Columns>
                                    <asp:CommandField ButtonType="Button" SelectText="انتخاب" ShowSelectButton="True">
                                        <ControlStyle CssClass="btn btn-success btn-xs" Width="100%" />
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="IDNo" HeaderText="شماره دانشجویی" SortExpression="IDNo">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Name_Fa" HeaderText="نام" SortExpression="Name_Fa">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Family_Fa" HeaderText="نام‌خانوادگی" SortExpression="Family_Fa">
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

            <div class="row">
                <div class="col-lg-12">
                    <%--<asp:SqlDataSource ID="DataSourceStudents" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT * FROM [Students] WHERE Evidence_Fa LIKE '%' + @Evidence_Fa + '%' ORDER BY IDS DESC" DeleteCommand="Delete From [Students] Where [IDS]=@IDS">
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="StudentsView" Name="IDS" PropertyName="SelectedValue" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="StudentsDropDownList" Name="Evidence_Fa" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>--%>
                </div>
            </div>

            <div class="box box-success" id="Message_Fa">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">آپلود سنتر</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#MessageInfo" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                                <a href="#Message_En" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">

                    <div class="row">
                        <div class="col-lg-12">
                            <%--                        <telerik:RadScriptManager ID="RadScriptManager2" runat="server" />--%>
                            <telerik:RadFileExplorer ID="FileExplorer1" runat="server" AllowPaging="false" DisplayUpFolderItem="True" EnableCopy="True" EnableTheming="True" Style="direction: ltr; width: 100%;" Configuration-AllowMultipleSelection="False" EnableOpenFile="True" AvailableFileListControls="All" EnableFilterTextBox="True" EnableFilteringOnEnterPressed="False" ExplorerMode="Default" FilterTextBoxLabel="Search" Width="100%">
                                <Configuration DeletePaths="~/Students/Uploads" MaxUploadFileSize="1024000000" UploadPaths="~/Students/Uploads" ViewPaths="~/Students/Uploads" />
                            </telerik:RadFileExplorer>
                            <script src="AdminComponents/dialogscripts.js" type="text/javascript"></script>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <!-- /.row -->
        <!-- /.container-fluid -->
    </div>
</asp:Content>

