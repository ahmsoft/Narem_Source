<%@ Page Title="" Language="VB" MasterPageFile="~/Students/StudentsMasterPage.master" AutoEventWireup="false" CodeFile="Send.aspx.vb" Inherits="Students_Send" %>
<%@ Register TagPrefix="qsf" Namespace="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
        <script src="StudentsComponents/scripts.js" type="text/javascript"></script>
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
    <!-- Content Wrapper. Contains page content -->
    <!-- Content Header (Page header) -->

    <!-- Main content -->
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
            <div class="box box-default" id="Posts">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">پست‌ها </a></h3>
                    <div class="box-tools pull-right">

                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">

                        <div class="col-lg-12">
                            <asp:GridView ID="MessageView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="DataSourceMessage" Width="100%" DataKeyNames="IDMStd">
                                <Columns>
                                    <asp:CommandField ButtonType="Button" SelectText="انتخاب" ShowSelectButton="True">
                                        <ControlStyle CssClass="btn btn-success btn-xs" Width="100%" />
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Title" HeaderText="عنوان" SortExpression="Title">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Moment_Fa" HeaderText="زمان" SortExpression="Moment_Fa">
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
                    <asp:SqlDataSource ID="DataSourceMessage" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT * FROM [StdMessage] ORDER BY Year_En DESC, Month_En DESC, Day_En DESC, IDMStd DESC" DeleteCommand="Delete From [StdMessage] Where [IDMStd]=@IDMStd">
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="MessageView" Name="IDMStd" PropertyName="SelectedValue" />
                        </DeleteParameters>
                        
                    </asp:SqlDataSource>
                </div>
            </div>

            <div class="box box-success" id="Message_Fa">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">ارسال پیام</a></h3>
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
                                <label for="txtTitle" class=" control-label">موضوع: </label>
                                تعداد کاراکتر:<span id="character-count-title" style="padding-right: 5px; color: #FF0000;">0</span>
                            </div>
                            <div class="col-lg-12">
                                <asp:TextBox runat="server" for="Text" ID="txtTitle" Style="margin-bottom: 6px;" class="form-control" placeholder="عنوان" onkeyup="count_remaining_character_title();Check();" onmousedown="count_remaining_character_title()" />
                                <asp:RegularExpressionValidator Style="margin-bottom: 30px;" ID="RegularExpression_txtTitle" runat="server" ValidationExpression="^.{10,70}$" ErrorMessage="تعداد کاراکتر باید بین 10 تا 70 باشد." ControlToValidate="txtTitle" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-12 center-block">
                                <label for="RadMessage" class=" control-label">متن پیام:</label>
                            </div>
                            <div class="col-lg-12 center-block">
                                <telerik:RadEditor ID="RadMessage" onkeyup="Check()" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <div class="row" id="Save" style="margin-bottom: 30px;">
                <div class="form-group">
                    <div class="col-md-12 btn-group">
                        <asp:Button ID="btnSaveNewMessage" runat="server" disabled class="col-xs-12 btn btn-primary" Text="ارسال" />
                    </div>

                </div>
            </div>
        </div>
        <!-- /.row -->
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
    <script>        
        function count_remaining_character_title() {
            var max_length = 70;
            var character_entered = $('#ContentPlaceHolder1_txtTitle').val().length;
            var character_remaining = character_entered;
            $('#character-count-title').html(character_remaining);
            if (max_length < character_entered || character_entered < 10) {
                $('#character-count-title').css('color', '#FF0000');
            } else {
                $('#character-count-title').css('color', '#76BC31');
            }
        }
        function Check() {
            var txttitle = document.getElementById("<%=txtTitle.ClientID%>");
            var radmessage = document.getElementById("<%=RadMessage.ClientID%>");
            var btnSaveNewMessage = document.getElementById("<%=btnSaveNewMessage.ClientID %>")
            if (txttitle.value != "") {
                btnSaveNewMessage.disabled = false;
            } else {
                btnSaveNewMessage.disabled = true;

            }
            
        }
    </script>    <!-- /.content -->
</asp:Content>

