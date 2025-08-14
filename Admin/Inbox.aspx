<%@ Page Title="" Language="VB" MasterPageFile="../Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="Inbox.aspx.vb" Inherits="Inbox1" %>

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
                    <h1 class="page-header">صندوق دریافت <small>پیام‌های دریافتی</small></h1>

                    <ol class="breadcrumb">
                        <li class="">
                            <i class="fa fa-dashboard"></i>Dashboard
                        </li>
                        <li class="active">
                            <i class="fa fa-inbox"></i>Inbox
                        </li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
            <div class="box box-default" id="Inbox">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">صندوق دریافت</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#PersonInfo" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:SqlDataSource ID="DataSourceContactUs" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT * FROM [ContactUs] ORDER BY [IDCU] DESC" DeleteCommand="Delete From [ContactUs] Where [IDCU]=@IDCU">
                                <DeleteParameters>
                                    <asp:ControlParameter ControlID="ContactUsView" Name="IDC" PropertyName="SelectedValue" />
                                </DeleteParameters>
                            </asp:SqlDataSource>
                            <div class="text-center">
                                <asp:GridView ID="ContactUsView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="DataSourceContactUs" Width="100%" DataKeyNames="IDCU">
                                    <Columns>
                                        <asp:CommandField ButtonType="Button" SelectText="اتخاب" ShowSelectButton="True">
                                            <ControlStyle CssClass="btn btn-success btn-xs" Width="100%" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="NameAndFamily_Fa" HeaderText="مخاطب فارسی" SortExpression="NameAndFamily_Fa">
                                            <HeaderStyle CssClass="text-center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NameAndFamily_En" HeaderText="مخاطب انگلیسی" SortExpression="NameAndFamily_En">
                                            <HeaderStyle CssClass="text-center" />
                                        </asp:BoundField>
                                        <%--                                <asp:BoundField DataField="Date" HeaderText="تاریخ" SortExpression="Date" />--%>
                                        <asp:BoundField DataField="Seen" HeaderText="وضعیت" SortExpression="Seen">
                                            <HeaderStyle CssClass="text-center" />
                                        </asp:BoundField>
                                        <asp:CommandField ButtonType="Button" DeleteText="حذف" ShowDeleteButton="True">
                                            <ControlStyle CssClass="btn btn-danger btn-xs" Width="100%" />
                                        </asp:CommandField>
                                    </Columns>
                                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="False" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                                </asp:GridView>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <div runat="server" id="PanelMSG_Fa" visible="false" style="direction:rtl;">
                <div class="box box-default" id="MSG">
                    <div class="box-header with-border">
                        <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">صندوق دریافت پیام</a></h3>
                        <div class="box-tools pull-right">
                            <%--<a href="#PersonInfo" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="form-group">
                                <label for="contact-Title" class="col-lg-2 control-label">نام و نام خانوادگی:</label>
                                <div class="col-lg-10">
                                    <asp:Label runat="server" for="Text" ID="lblNameAndFamily_Fa" Text="---" class="" placeholder="نام و نام خانوادگی" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-lg-2">
                                    <label for="contact-message" class=" control-label">ایمیل:</label>
                                </div>
                                <div class="col-lg-10 ">
                                    <asp:Label runat="server" for="Email" ID="lblEmail_Fa" class="" Text="---" placeholder="پست الکترنیکی" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-lg-2">
                                    <label for="contact-message" class=" control-label">پیام:</label>

                                </div>

                                <div class="col-lg-10 ">
                                    <hr />
                                    <asp:Label Style="border-color: red;" runat="server" for="Text" ID="lblarea_Fa" class="" Text="---" placeholder="پیام" />
                                    <hr />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-lg-2">
                                    <label for="contact-message" class=" control-label">زمان شمسی:</label>
                                </div>
                                <div class="col-lg-10 ">
                                    <asp:Label runat="server" for="Time" ID="lblTime_Fa" Text="---" class="" placeholder="زمان" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-lg-2">
                                    <label for="contact-message" class=" control-label">زمان میلادی:</label>
                                </div>
                                <div class="col-lg-10 ">
                                    <asp:Label runat="server" for="Time" ID="lblTime_En" Text="---" class="" placeholder="زمان" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-lg-2">
                                    <label for="contact-message" class=" control-label">وب سایت:</label>
                                </div>
                                <div class="col-lg-10 ">
                                    <asp:Label runat="server" for="Website" ID="lblWebsite_Fa" Text="---" class="" placeholder="وب سایت" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-lg-2">
                                    <label for="contact-message" class=" control-label">وضعیت:</label>
                                </div>
                                <div class="col-lg-10 ">
                                    <span class="badge alert-success">
                                        <asp:Label ID="lblStatus_Fa" CssClass="col-xs-12 checkbox" runat="server" Text="نامشخص" Checked="True" /></span>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
            </div>
                    <div runat="server" id="PanelMSG_En" visible="false">
                <div class="box box-default" id="MSG1">
                    <div class="box-header with-border">
                        <h3 class="box-title align"><a href="#" style="color: black;" data-widget="collapse">صندوق دریافت پیام</a></h3>
                        <div class="box-tools pull-left">
                            <%--<a href="#PersonInfo" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="form-group">
                                <label for="contact-Title" class="col-lg-2 control-label">نام و نام خانوادگی:</label>
                                <div class="col-lg-10">
                                    <asp:Label runat="server" for="Text" ID="lblNameAndFamily_En" Style="direction: ltr;" Text="---" class="" placeholder="Name And Family" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-lg-2">
                                    <label for="contact-message" class=" control-label">ایمیل:</label>
                                </div>
                                <div class="col-lg-10 ">
                                    <asp:Label runat="server" for="Email" ID="lblEmail_En" Style="direction: ltr;" class="" Text="---" placeholder="Email" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-lg-2">
                                    <label for="contact-message" class=" control-label">پیام:</label>

                                </div>

                                <div class="col-lg-10 ">
                                    <hr />
                                    <asp:Label Style="border-color: red;direction:ltr;" runat="server" for="Text" ID="lblarea_En" class="" Text="---" placeholder="Message" />
                                    <hr />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-lg-2">
                                    <label for="contact-message" class=" control-label">تاریخ شمسی:</label>
                                </div>
                                <div class="col-lg-10 ">
                                    <asp:Label runat="server" for="Time" ID="lblTime_Fa1" Style="direction: ltr;" Text="---" class="" placeholder="Shamsi Date" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-lg-2">
                                    <label for="contact-message" class=" control-label">تاریخ میلادی:</label>
                                </div>
                                <div class="col-lg-10 ">
                                    <asp:Label runat="server" for="Time" ID="lblTime_En1" Style="direction: ltr;" Text="---" class="" placeholder="Miladi Date" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-lg-2">
                                    <label for="contact-message" class=" control-label">وب سایت:</label>
                                </div>
                                <div class="col-lg-10 ">
                                    <asp:Label runat="server" for="Website" ID="lblWebsite_En" Style="direction: ltr;" Text="---" class="" placeholder="Website" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <div class="col-lg-2">
                                    <label for="contact-message" class=" control-label">وضعیت:</label>
                                </div>
                                <div class="col-lg-10 ">
                                    <span class="badge alert-success">
                                        <asp:Label ID="lblStatus_En" Style="direction: ltr;" CssClass="col-xs-12 checkbox" runat="server" Text="Unknown" Checked="True" /></span>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>

    <!-- /.row -->
        <!-- /.container-fluid -->
        <!-- /#page-wrapper -->
</asp:Content>

