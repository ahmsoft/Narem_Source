<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="CommentManagement.aspx.vb" Inherits="Admin_CommentManagement" %>

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
                    <h1 class="page-header">مدیریت نظرات <small>نظرات ارسال شده برای پیام‌های سایت</small></h1>
                    <ol class="breadcrumb">
                        <li>
                            <i class="fa fa-dashboard"></i>Dashboard
                        </li>
                        <li class="active">
                            <i class="fa fa-edit"></i>Comments Management
                        </li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
            <div class="box box-default" id="Comments">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">دیدگاه‌ها </a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#Cate" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                        <a href="#MessageInfo" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:GridView CssClass="" ID="CommentsView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="DataSourceComments" Width="100%" DataKeyNames="IDC">
                                <Columns>
                                    <asp:CommandField ButtonType="Button" SelectText="انتخاب" ShowSelectButton="True">
                                        <ControlStyle CssClass="btn btn-success btn-xs" Width="100%" />
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="NameAndFamily_Fa" HeaderText="نام فارسی" SortExpression="NameAndFamily_Fa">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NameAndFamily_En" HeaderText="نام انگلیسی" SortExpression="NameAndFamily_En">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Seen" HeaderText="وضعیت" SortExpression="Seen">
                                        <HeaderStyle CssClass="text-center" />
                                        <ItemStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="نمایش" SortExpression="Active">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Active") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Active") %>' Enabled="False" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" />
                                        <ItemStyle CssClass="text-center" />
                                    </asp:TemplateField>
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
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:Label runat="server" ID="lblPM" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <asp:SqlDataSource ID="DataSourceComments" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT * FROM [Comments] WHERE Parent=0 ORDER BY IDC DESC" DeleteCommand="Delete From [Comments] WHERE Parent=0 AND [IDC]=@IDC">
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="CommentsView" Name="IDC" PropertyName="SelectedValue" />
                        </DeleteParameters>
                    </asp:SqlDataSource>
                    <div class="box box-warning" id="CommentInfo">
                        <div class="box-header with-border">
                            <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">اطلاعات دیدگاه</a></h3>
                            <div class="box-tools pull-right">
                                <%--<a href="#Posts" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                                <a href="#Message_Fa" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            </div>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="txtNameAndFamily_Fa" class=" control-label">نام به فارسی:</label>
                                        <asp:TextBox runat="server" for="Text" ID="txtNameAndFamily_Fa" Style="margin-bottom: 30px;" class="form-control" placeholder="نام دیدگاه نویس به فارسی" />
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="txtNameAndFamilyr_En" class=" control-label">نام به انگلیسی:</label>
                                        <asp:TextBox runat="server" ID="txtNameAndFamily_En" placeholder="نام دیدگاه نویس به انگلیسی" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="txtComment_Fa" class="control-label">دیدگاه به فارسی:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <asp:TextBox ID="txtComment_Fa" runat="server" TextMode="MultiLine" Style="direction: rtl; text-align: right; margin-bottom: 30px; height: auto;" Width="100%" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="txtComment_En" class="control-label">دیدگاه به انگلیسی:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <asp:TextBox ID="txtComment_En" runat="server" TextMode="MultiLine" Style="direction: ltr; text-align: left; margin-bottom: 30px; height: auto;" Width="100%" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="contact-Title" class="control-label">پست الکترونیکی:</label>
                                        <div class="input-group date">
                                            <div class="input-group-addon">
                                                <i class="fa fa-mail-reply"></i>
                                            </div>
                                            <input runat="server" type="text" id="txtEmail" class="form-control pull-right" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="contact-Title" class="control-label">وب سایت:</label>
                                        <div class="input-group date">
                                            <div class="input-group-addon">
                                                <i class="fa fa-wordpress"></i>
                                            </div>
                                            <input runat="server" type="text" id="txtWebsite" style="direction: ltr; text-align: right;" class="form-control pull-right" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4">
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
                                <div class="col-lg-4">
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
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label for="drpActive" class="control-label">وضعیت:</label>
                                        <asp:DropDownList ID="drpActive" runat="server" class="form-control pull-right">
                                            <asp:ListItem Value="False">غیرفعال</asp:ListItem>
                                            <asp:ListItem Value="True">فعال</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 30px;">
                                <div class="form-group">
                                    <div class="col-md-12 btn-group">
                                        <asp:Button ID="btnUpdateComment" runat="server" class="col-xs-12 btn btn-default" Text="ذخیره تغییرات" />
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
                    <div class="box box-warning" id="SubComment">
                        <div class="box-header with-border">
                            <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">پاسخ به دیدگاه</a></h3>
                            <div class="box-tools pull-right">
                                <%--<a href="#Posts" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                                <a href="#Message_Fa" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            </div>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <div class="row">
                                <asp:SqlDataSource ID="DataSourceSubComments" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT * FROM [Comments] WHERE Parent=@IDC" DeleteCommand="Delete From [Comments] WHERE Parent<>0 AND [IDC]=@IDSubComment">
                                    <DeleteParameters>
                                        <asp:ControlParameter ControlID="SubCommentsView" Name="IDSubComment" PropertyName="SelectedValue" />
                                    </DeleteParameters>
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="CommentsView" Name="IDC" PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <div class="col-lg-12">
                                    <asp:GridView ID="SubCommentView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="DataSourceSubComments" Width="100%" DataKeyNames="IDC" Style="margin-bottom: 30px;">
                                        <Columns>
                                            <asp:CommandField ButtonType="Button" SelectText="انتخاب" ShowSelectButton="True">
                                                <ControlStyle CssClass="btn btn-success btn-xs" Width="100%" />
                                                <HeaderStyle CssClass="text-center" />
                                            </asp:CommandField>
                                            <asp:BoundField DataField="MSG_Fa" HeaderText="پاسخ به فارسی" SortExpression="MSG_Fa">
                                                <HeaderStyle CssClass="text-center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MSG_En" HeaderText="پاسخ به انگلیسی" SortExpression="MSG_En">
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
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="txtSubComment_Fa" class="control-label">پاسخ به فارسی:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <asp:TextBox ID="txtSubComment_Fa" runat="server" TextMode="MultiLine" Style="direction: rtl; text-align: right; margin-bottom: 30px; height: auto;" Width="100%" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="txtSubComment_En" class="control-label">پاسخ به انگلیسی:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <asp:TextBox ID="txtSubComment_En" runat="server" TextMode="MultiLine" Style="direction: ltr; text-align: left; margin-bottom: 30px; height: auto;" Width="100%" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="contact-Title" class="control-label">زمان انتشار شمسی:</label>
                                        <asp:Label runat="server" ID="lblSubCommentMoment_Fa" Style="color: rgb(255, 154, 52);" />
                                        <div class="input-group date">
                                            <div class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtSubCommentMoment_Fa" class="form-control pull-right" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="contact-Title" class="control-label">زمان انتشار میلادی:</label>
                                        <asp:Label runat="server" ID="lblSubCommentMoment_En" Style="color: rgb(255, 154, 52);" />
                                        <div class="input-group date">
                                            <div class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </div>
                                            <input runat="server" type="text" id="txtSubCommentMoment_En" style="direction: ltr; text-align: right;" class="form-control pull-right" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="Save" style="margin-bottom: 30px;">
                                <div class="form-group">
                                    <div class="col-md-12 btn-group">
                                        <asp:Button ID="btnUpdateSubComment" runat="server" class="col-xs-6 btn btn-default" Text="ذخیره تغییرات" />
                                        <asp:Button ID="btnSaveNewSubComment" runat="server" class="col-xs-6 btn btn-primary" Text="ایجادپاسخ جدید" />
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

                </div>
                <%--<asp:PlaceHolder runat="server" ID="PostsPlaceHolder"></asp:PlaceHolder>
                           <asp:PlaceHolder runat="server" ID="FAQPlaceHolder"></asp:PlaceHolder>--%>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>

