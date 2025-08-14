<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="LinkManagement.aspx.vb" Inherits="Admin_LinkManagement" %>

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
                    <h1 class="page-header">مدیریت لینک‌ها <small>مدیریت لینک‌های بلاک</small></h1>

                    <ol class="breadcrumb">
                        <li>
                            <i class="fa fa-dashboard"></i>Dashboard
                        </li>
                        <li class="active">
                            <i class="fa fa-list"></i>Link Management
                        </li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->

            <div class="box box-success" id="Links">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">لینک‌ها</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#Blocks" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="row">
                                <div class="col-lg-12 col-md-12">
                                    <asp:GridView ID="LinkView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="SqlDataSourceLinks" Width="100%" DataKeyNames="IDL">
                                        <Columns>
                                            <asp:CommandField ButtonType="Button" SelectText="انتخاب" ShowSelectButton="True">
                                                <ControlStyle CssClass="btn btn-success btn-xs" Width="100%" />
                                                <HeaderStyle CssClass="text-center" />
                                            </asp:CommandField>
                                            <asp:BoundField DataField="Name_Fa" HeaderText="لینک فارسی" SortExpression="Name_Fa">
                                                <HeaderStyle CssClass="text-center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Name_En" HeaderText="لینک انگلیسی" SortExpression="Name_En">
                                                <HeaderStyle CssClass="text-center" />
                                                <ItemStyle CssClass="text-center" />
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
                                    <asp:SqlDataSource ID="SqlDataSourceLinks" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT * FROM [Links] ORDER BY [IDB], [IDL], [Name_Fa]" DeleteCommand="Delete From [Links] Where [IDL]=@IDL">
                                        <DeleteParameters>
                                            <asp:Parameter Name="IDL" />
                                        </DeleteParameters>
                                    </asp:SqlDataSource>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="box box-warning" id="LinksStatus">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">وضعیت</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#Blocks" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="row">
                                <div class="form-group col-lg-6">
                                    <label>انتخاب بلاک‌:</label>
                                    <asp:DropDownList runat="server" ID="drpBlock" placeholder="انتخاب بلاک" class="form-control" DataSourceID="SqlDataSourceBlocks" DataTextField="Name_Fa" DataValueField="IDB" AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSourceBlocks" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT [IDB], [Name_Fa] FROM [Blocks] ORDER BY [IDB], [Name_Fa]"></asp:SqlDataSource>
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
                                <div class="col-md-6 center-block">
                                    <label>اولویت نمایش:</label>
                                    <asp:TextBox runat="server" ID="txtPriorityLink" placeholder="اولویت" type="number" class="form-control" />
                                </div>
                                <div class="form-group col-lg-6">
                                    <asp:CheckBox runat="server" ID="chkHTML" Text="محتوای بیشتر" AutoPostBack="true" />
                                </div>
                                <div class="form-group col-lg-6">
                                    <asp:Label runat="server" ID="lblNotFoundBlock_Fa" Style="display: inline-block;" class="alert alert-warning " Text="لینک انتخابی فاقد بلاک می‌باشد، شما قبلا بلاک آن را حذف نموده‌اید لطفا لینک را حذف، یا یک بلاک برای آن مشخص و سپس دکمه ذخیره تغییرات را بزنید." Visible="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="box box-warning" id="Links_Fa">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">اطلاعات فارسی</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#Blocks" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="row" runat="server" id="InfoHTML_Fa" visible="false">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label>پیام یا کد:</label>
                                        <telerik:RadEditor Style="direction: ltr;" ID="txtBodyHTML_Fa" runat="server" Width="100%" Skin="Bootstrap" ToolbarMode="Floating"></telerik:RadEditor>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <div class="btn-group col-lg-6">
                                            <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertImageBody_Fa" class="btn btn-success"><i class="fa fa-image"> درج در مطلب</i></asp:LinkButton>
                                            <asp:TextBox runat="server" placeholder="آدرس تصویر" ID="FileNameBody_Fa" Style="width: 135px; height: 28px; direction: ltr;" />
                                            <asp:Label runat="server" ID="lblInsertImageStateBody_Fa" Style="float: left;" class="label label-success" Visible="false" Text="تصویر با موفقیت در مطلب درج شد. " />
                                        </div>
                                        <div class="btn-group col-lg-6">
                                            <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertMediaBody_Fa" class="btn btn-success"><i class="fa fa-file-sound-o"> درج در مطلب</i></asp:LinkButton>
                                            <asp:TextBox runat="server" placeholder="آدرس فایل صوتی یا تصویری" ID="FileNameMediaBody_Fa" Style="width: 235px; height: 28px; direction: ltr;" />
                                            <asp:Label runat="server" ID="lblInsertMediaStateBody_Fa" Style="float: left;" class="label label-success" Visible="false" Text="رسانه با موفقیت در مطلب درج شد. " />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row" runat="server" id="InfoLink_Fa">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label>نام:</label>
                                        <asp:TextBox runat="server" ID="txtLinkName_Fa" placeholder="نام پیوند" class="form-control" />
                                    </div>

                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label>آدرس:</label>
                                        <asp:TextBox runat="server" ID="txtLinkAddress_Fa" placeholder="آدرس پیوند" class="form-control" />
                                    </div>

                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label>توضیح:</label>
                                        <asp:TextBox runat="server" ID="txtLinkAlt_Fa" placeholder="توضیح کوتاه" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <!-- /.row -->

                        </div>

                    </div>
                </div>
            </div>
            <div class="box box-info" id="Links_En">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">اطلاعات انگلیسی</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#Blocks" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="row" runat="server" id="InfoHTML_En" visible="false">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label>پیام یا کد:</label>
                                        <telerik:RadEditor Style="direction: ltr;" ID="txtBodyHTML_En" runat="server" Width="100%" Skin="Bootstrap" ToolbarMode="Floating"></telerik:RadEditor>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <div class="btn-group col-lg-6">
                                            <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertImageBody_En" class="btn btn-success"><i class="fa fa-image"> درج در مطلب</i></asp:LinkButton>
                                            <asp:TextBox runat="server" placeholder="آدرس تصویر" ID="fileNameBody_En" Style="width: 135px; height: 28px; direction: ltr;" />
                                            <asp:Label runat="server" ID="lblInsertImageStateBody_En" Style="float: left;" class="label label-success" Visible="false" Text="تصویر با موفقیت در مطلب درج شد. " />
                                        </div>
                                        <div class="btn-group col-lg-6">
                                            <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertMediaBody_En" class="btn btn-success"><i class="fa fa-file-sound-o"> درج در مطلب</i></asp:LinkButton>
                                            <asp:TextBox runat="server" placeholder="آدرس فایل صوتی یا تصویری" ID="FileNameMediaBody_En" Style="width: 235px; height: 28px; direction: ltr;" />
                                            <asp:Label runat="server" ID="lblInsertMediaStateBody_En" Style="float: left;" class="label label-success" Visible="false" Text="رسانه با موفقیت در مطلب درج شد. " />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row" runat="server" id="InfoLink_En">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label>نام:</label>
                                        <asp:TextBox runat="server" ID="txtLinkName_En" placeholder="نام پیوند" class="form-control" />
                                    </div>

                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label>آدرس:</label>
                                        <asp:TextBox runat="server" ID="txtLinkAddress_En" placeholder="آدرس پیوند" class="form-control" />
                                    </div>

                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label>توضیح:</label>
                                        <asp:TextBox runat="server" ID="txtLinkAlt_En" placeholder="توضیح کوتاه" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <!-- /.row -->

                        </div>

                    </div>
                </div>
            </div>
            <div class="row" id="Save">
                <div class="col-lg-12">
                    <div class="form-group">
                        <asp:Button ID="btnUpdateLink" runat="server" class="col-xs-6 btn btn-default" Text="ذخیره تغییرات" />
                        <asp:Button ID="btnSaveNewLink" runat="server" class="col-xs-6 btn btn-primary" Text="ایجاد لینک جدید" />
                    </div>
                </div>
            </div>
        </div>
        <!-- /.container-fluid -->
    </div>
</asp:Content>

