<%@ Page Title="" Language="VB" MasterPageFile="AdminMasterPage.master" AutoEventWireup="true" CodeFile="NewsManagement.aspx.vb" Inherits="NewsManagement" ValidateRequest="false" %>

<%@ Register TagPrefix="qsf" Namespace="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="AdminComponents/scripts.js" type="text/javascript"></script>
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
                    <h1 class="page-header">مدیریت خبر <small>اخبار سایت</small></h1>
                    <ol class="breadcrumb">
                        <li>
                            <i class="fa fa-dashboard"></i>Dashboard
                        </li>
                        <li class="active">
                            <i class="fa fa-edit"></i>News Management
                        </li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
            <div class="box box-danger collapsed-box" id="Cate">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">دسته‌بندی:</a><asp:TextBox runat="server" ID="txtSearch" placeholder="جستجو" AutoPostBack="true" />
                        <%--                    <div class="form-group col-lg-12">--%>
                        <asp:LinqDataSource ID="CatDataSource" runat="server" ContextTypeName="LinqDBClassesDataContext" EntityTypeName="" TableName="Categories" EnableDelete="True">
                            <DeleteParameters>
                                <asp:ControlParameter ControlID="CatDropDownList" Name="IDCat" PropertyName="SelectedValue" />
                            </DeleteParameters>
                        </asp:LinqDataSource>
                        <%--<label for="Day_Fa" class=" control-label">دسته‌بندی:</label>--%>
                        <asp:DropDownList ID="CatDropDownList" runat="server" DataSourceID="CatDataSource" DataTextField="CatName_Fa" DataValueField="CatName_Fa" AutoPostBack="True">
                        </asp:DropDownList>
                        <%--                        </div>--%>
                    </h3>
                    <div class="box-tools pull-right">
                        <%--                        <a href="#Posts" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-xs-12">
                            <asp:GridView ID="CatView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="5" CellSpacing="2" DataSourceID="CatDataSource" Width="100%" DataKeyNames="IDCat">
                                <Columns>
                                    <asp:BoundField DataField="IDCat" HeaderText="کد" SortExpression="IDCat">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="CatName_Fa" HeaderText="نام دسته فارسی" SortExpression="CatName_Fa">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CatName_En" HeaderText="نام دسته انگلیسی" SortExpression="CatName_En">
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
                        <div class="form-group col-xs-6">
                            <label for="txtCatID" class="col-lg-12 control-label">کد:</label>
                            <div class="col-lg-12">
                                <asp:TextBox runat="server" for="Text" ID="txtCatID" Style="margin-bottom: 15px;" class="form-control" placeholder="کد" />
                            </div>
                        </div>
                        <div class="form-group col-xs-6">
                            <label for="txtCatPriority" class="col-lg-12 control-label">اولویت:</label>
                            <div class="col-lg-12">
                                <asp:TextBox runat="server" for="Text" ID="txtCatPriority" Style="margin-bottom: 15px;" class="form-control" placeholder="اولویت" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-6">
                            <label for="txtCatName_Fa" class="col-lg-12 control-label">نام دسته فارسی:</label>
                            <div class="col-lg-12">
                                <asp:TextBox runat="server" for="Text" ID="txtCatName_Fa" Style="margin-bottom: 10px;" class="form-control" placeholder="نام دسته فارسی" />
                            </div>
                        </div>
                        <div class="form-group col-xs-6">
                            <label for="txtCatName_En" class="col-lg-12 control-label">نام دسته انگلیسی:</label>
                            <div class="col-lg-12">
                                <asp:TextBox runat="server" for="Text" ID="txtCatName_En" Style="margin-bottom: 10px;direction: ltr;text-align:left;" class="form-control" placeholder="نام دسته انگلیسی" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <label for="txtCatDescription_Fa" class="col-lg-12 control-label">توضیح فارسی:</label>
                            <div class="col-lg-12">
                                <asp:TextBox runat="server" for="Text" ID="txtCatDescription_Fa" Style="margin-bottom: 15px;" class="form-control" placeholder="توضیح فارسی" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <label for="txtCatDescription_En" class="col-lg-12 control-label">توضیح انگلیسی:</label>
                            <div class="col-lg-12">
                                <asp:TextBox runat="server" for="Text" ID="txtCatDescription_En" Style="margin-bottom: 15px;direction:ltr;text-align:left;" class="form-control" placeholder="توضیح انگلیسی" />
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 10px;">
                        <div class="form-group">
                            <div class="col-md-12 btn-group">
                                <asp:Button ID="btnUpdateCat" runat="server" class="col-xs-6 btn btn-default" Text="ذخیره تغییرات" />
                                <asp:Button ID="btnSaveNewCat" runat="server" class="col-xs-6 btn btn-primary" Text="ایجاد گروه جدید" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="box box-default" id="Posts">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">اخبار </a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#Cate" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>--%>
                        <asp:Button runat="server" ID="btnShowAll" type="button" class="btn btn-box-tool" data-widget="" Text="نمایش تمام اخبار"/>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">

                        <div class="col-lg-12">
                            <asp:GridView ID="NewsView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="DataSourceNews" Width="100%" DataKeyNames="IDN">
                                <Columns>
                                    <asp:CommandField ButtonType="Button" SelectText="انتخاب" ShowSelectButton="True">
                                        <ControlStyle CssClass="btn btn-success btn-xs" Width="100%" />
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Title_Fa" HeaderText="عنوان فارسی" SortExpression="Title_Fa">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Title_En" HeaderText="عنوان انگلیسی" SortExpression="Title_En">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="نمایش " SortExpression="IsShow">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IsShow") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsShow") %>' Enabled="False" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" />
                                        <ItemStyle CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Priority" HeaderText="اولویت" SortExpression="Priority">
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
                        </div>

                    </div>

                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <asp:SqlDataSource ID="DataSourceNews" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" InsertCommand="INSERT INTO [News] ([IDN],[PreMSG_Fa],[PreMSG_En],[MSG_Fa],[MSG_En],[Keyword_Fa],[Keyword_En],[Image], [Title_En],[Title_Fa],[IsShow],[Year_Fa],[Month_Fa],[Day_Fa],[Year_En],[Month_En],[Day_En],[Priority]) VALUES (@IDN, @PreMSG_Fa,@PreMSG_En,@MSG_Fa,@MSG_En,@Keyword_Fa,@Keyword_En,@Pic, @Title_En,@Title_Fa,@IsShow,@Year_Fa,@Month_Fa,@Day_Fa,@Year_En,@Month_En,@Day_En,@Priority)" SelectCommand="SELECT * FROM [News1] WHERE CatName_Fa LIKE '%' + @CatName + '%' ORDER BY IDN DESC" DeleteCommand="Delete From [News1] Where [IDN]=@IDN">
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="NewsView" Name="IDN" PropertyName="SelectedValue" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="IDN" Type="Int32" />
                            <asp:Parameter Name="Title_Fa" Type="String" />
                            <asp:Parameter Name="Title_En" Type="String" />
                            <asp:Parameter Name="PreMSG_Fa" Type="String" />
                            <asp:Parameter Name="PreMSGEN" Type="String" />
                            <asp:Parameter Name="MSG_Fa" Type="String" />
                            <asp:Parameter Name="MSG_En" Type="String" />
                            <asp:Parameter Name="Keyword_Fa" Type="String" />
                            <asp:Parameter Name="Keyword_En" Type="String" />
                            <asp:Parameter Name="IsShow" Type="Boolean" />
                            <asp:Parameter Name="Image" Type="String" />
                            <asp:Parameter Name="Year_En" Type="Int32" />
                            <asp:Parameter Name="Month_En" Type="Int32" />
                            <asp:Parameter Name="Day_En" Type="Int32" />
                            <asp:Parameter Name="Year_En" Type="Int32" />
                            <asp:Parameter Name="Month_En" Type="Int32" />
                            <asp:Parameter Name="Day_En" Type="Int32" />
                            <asp:Parameter Name="Priority" Type="Int32" />
                            <asp:Parameter Name="Moment" Type="String" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="CatDropDownList" Name="CatName" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <div class="box box-warning" id="NewsInfo">
                        <div class="box-header with-border">
                            <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">اطلاعات خبر</a></h3>

                            <div class="box-tools pull-right">
                                <%--<a href="#Posts" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                                <a href="#News_Fa" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            </div>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-md-12 center-block">
                                        <asp:CheckBox ID="CheckBoxIsShow" Style="margin-bottom: 30px;" CssClass="col-xs-12 checkbox" runat="server" Text="خبر نمایش داده شود." Checked="True" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <label for="txtPriority" class="col-lg-12 control-label">اولویت:</label>
                                    <div class="col-lg-12">
                                        <asp:TextBox runat="server" for="Text" ID="txtPriority" Style="margin-bottom: 30px;" class="form-control" placeholder="اولویت" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="contact-Title" class="control-label">زمان انتشار شمسی:</label>
                                        <%--                                        <asp:Label runat="server" ID="lblMomentNewFa" Style="color: rgb(255, 154, 52);" />--%>
                                        <asp:TextBox runat="server" ID="tarikh" Style="background-color: white; color: rgb(255, 154, 52); width: 185px;" ReadOnly="true" BorderStyle="None" />
                                        <div class="input-group date">
                                            <div class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </div>
                                            <input runat="server" type="text" id="txtMoment_Fa" style="z-index: 0;" class="form-control pull-right" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="contact-Title" class="control-label">زمان انتشار میلادی:</label>
                                        <asp:TextBox runat="server" ID="txtMomentNew_En" ReadOnly="true" BorderStyle="None" Style="color: rgb(255, 154, 52); width: 185px; direction: ltr; text-align: right;" />
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
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="chkCat_Fa" class="control-label">دسته‌بندی فارسی:</label>
                                        <div>
                                            <asp:CheckBoxList ID="chkCat_Fa" runat="server" Style="direction: rtl; text-align: right;" class="pull-right" DataSourceID="CatDataSource" DataTextField="CatName_Fa" RepeatDirection="Vertical" DataValueField="CatName_Fa" CellPadding="-1" BorderStyle="None" EnableTheming="True" BorderWidth="100" RepeatLayout="Table"></asp:CheckBoxList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="chkCat_En" class="control-label">دسته‌بندی انگلیسی:</label>
                                        <div>
                                            <asp:CheckBoxList ID="chkCat_En" runat="server" Style="direction: rtl; text-align: right;" class="pull-right" DataSourceID="CatDataSource" DataTextField="CatName_En" RepeatDirection="Vertical" DataValueField="CatName_En" CellPadding="-1" BorderStyle="None" EnableTheming="True" BorderWidth="100" RepeatLayout="Table"></asp:CheckBoxList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="box box-success" id="News_Fa">
                        <div class="box-header with-border">
                            <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">خبر فارسی</a></h3>
                            <div class="box-tools pull-right">
                                <%--<a href="#NewsInfo" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                                <a href="#News_En" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            </div>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">

                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="txtTitle_Fa" class=" control-label">عنوان به فارسی: </label>
                                        تعداد کاراکتر:<span id="character-count-title-Fa" style="padding-right: 5px; color: #FF0000;">0</span>
                                    </div>
                                    <div class="col-lg-12">
                                        <asp:TextBox runat="server" for="Text" ID="txtTitle_Fa" Style="margin-bottom: 6px;" class="form-control" placeholder="عنوان پیام به فارسی" onkeyup="count_remaining_character_title_Fa()" onmousedown="count_remaining_character_title_Fa()" />
                                        <asp:RegularExpressionValidator Style="margin-bottom: 30px;" ID="RegularExpression_txtTitle_Fa" runat="server" ValidationExpression="^.{10,70}$" ErrorMessage="تعداد کاراکتر باید بین 10 تا 70 باشد." ControlToValidate="txtTitle_Fa" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="RadPreMSG_Fa" class=" control-label">مطلب به فارسی:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <telerik:RadEditor ID="RadPreMSG_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating" DocumentManager-ViewPaths="~/Uploads" ImageManager-ViewPaths="~/Uploads"></telerik:RadEditor>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="btn-group col-lg-6">
                                        <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertImagePreMessage_Fa" class="btn btn-success"><i class="fa fa-image"> درج در مطلب</i></asp:LinkButton>
                                        <asp:TextBox runat="server" placeholder="آدرس تصویر" ID="FileNamePreMessage_Fa" Style="width: 235px; height: 28px; direction: ltr;text-align:left;" />
                                        <asp:Label runat="server" ID="lblInsertImageStatePreMessage_Fa" Style="float: left;" class="label label-success" Visible="false" Text="تصویر با موفقیت در مطلب درج شد. " />
                                    </div>
                                    <div class="btn-group col-lg-6">
                                        <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertMediaPreMessage_Fa" class="btn btn-success"><i class="fa fa-file-sound-o"> درج در مطلب</i></asp:LinkButton>
                                        <asp:TextBox runat="server" placeholder="آدرس فایل صوتی یا تصویری" ID="FileNameMediaPreMessage_Fa" Style="width: 235px; height: 28px; direction: ltr;text-align:left;" />
                                        <asp:Label runat="server" ID="lblInsertMediaStatePreMessage_Fa" Style="float: left;" class="label label-success" Visible="false" Text="رسانه با موفقیت در مطلب درج شد. " />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="RadMSG_Fa" class=" control-label">ادامه مطلب به فارسی:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <telerik:RadEditor ID="RadMSG_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="btn-group col-lg-6">
                                        <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertImageMessage_Fa" class="btn btn-success"><i class="fa fa-image"> درج در مطلب</i></asp:LinkButton>
                                        <asp:TextBox runat="server" placeholder="آدرس تصویر" ID="FileNameMessage_Fa" Style="width: 135px; height: 28px; direction: ltr;text-align:left;" />
                                        <asp:Label runat="server" ID="lblInsertImageStateMessage_Fa" Style="float: left;" class="label label-success" Visible="false" Text="تصویر با موفقیت در مطلب درج شد. " />
                                    </div>
                                    <div class="btn-group col-lg-6">
                                        <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertMediaMessage_Fa" class="btn btn-success"><i class="fa fa-file-sound-o"> درج در مطلب</i></asp:LinkButton>
                                        <asp:TextBox runat="server" placeholder="آدرس فایل صوتی یا تصویری" ID="FileNameMediaMessage_Fa" Style="width: 235px; height: 28px; direction: ltr;text-align:left;" />
                                        <asp:Label runat="server" ID="lblInsertMediaStateMessage_Fa" Style="float: left;" class="label label-success" Visible="false" Text="رسانه با موفقیت در مطلب درج شد. " />
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
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="txtMetaDescription_Fa" class=" control-label">توضیحات متا: </label>
                                        تعداد کاراکتر:<span id="character-count-Fa" style="padding-right: 5px; color: #FF0000;">0</span>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <asp:TextBox ID="txtMetaDescription_Fa" Rows="4" TextMode="MultiLine" Style="margin-bottom: 6px;" class="form-control" placeholder="توضیحات متا باید بین 70 تا 160 کاراکتر باشد." runat="server" Width="100%" MaxLength="600" onkeyup="count_remaining_character_metadescription_Fa()" onmousedown="count_remaining_character_metadescription()" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Style="margin-bottom: 30px;" runat="server" ValidationExpression="^.{70,160}$" ErrorMessage="تعداد کاراکتر باید بین 70 تا 160 باشد." ControlToValidate="txtMetaDescription_Fa" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <label for="txtMetaPic" class="col-lg-12 control-label">تصویر متا:</label>
                                    <div class="col-lg-12">
                                        <asp:TextBox runat="server" for="Text" ID="txtMetaPic" Style="margin-bottom: 30px;direction:ltr; text-align:left;" class="form-control" placeholder="تصویر متا" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box box-info" id="News_En">
                        <div class="box-header with-border">
                            <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">خبر انگلیسی</a></h3>

                            <div class="box-tools pull-right">
                                <%--<a href="#News_Fa" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                                <a href="#Save" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            </div>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="txtTitle_En" class=" control-label">عنوان به انگلیسی: </label>
                                        تعداد کاراکتر:<span id="character-count-title-En" style="padding-right: 5px; color: #FF0000;">0</span>
                                    </div>
                                    <div class="col-lg-12">
                                        <asp:TextBox runat="server" for="Text" ID="txtTitle_En" Style="margin-bottom: 6px;direction:ltr;text-align:left;" class="form-control" placeholder="عنوان پیام به انگلیسی" onkeyup="count_remaining_character_title_En()" onmousedown="count_remaining_character_title_En()" />
                                        <asp:RegularExpressionValidator Style="margin-bottom: 30px;" ID="RegularExpression_txtTitle_En" runat="server" ValidationExpression="^.{10,70}$" ErrorMessage="تعداد کاراکتر باید بین 10 تا 70 باشد." ControlToValidate="txtTitle_En" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="RadPreMSG_En" class=" control-label">مطلب به انگلیسی:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <telerik:RadEditor ID="RadPreMSG_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="btn-group col-lg-6">
                                        <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertImagePreMessage_En" class="btn btn-success"><i class="fa fa-image"> درج در مطلب</i></asp:LinkButton>
                                        <asp:TextBox runat="server" placeholder="آدرس تصویر" ID="FileNamePreMessage_En" Style="width: 135px; height: 28px; direction: ltr;text-align:left;" />
                                        <asp:Label runat="server" ID="lblInsertImageStatePreMessage_En" Style="float: left;" class="label label-success" Visible="false" Text="تصویر با موفقیت در مطلب درج شد. " />
                                    </div>
                                    <div class="btn-group col-lg-6">
                                        <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertMediaPreMessage_En" class="btn btn-success"><i class="fa fa-file-sound-o"> درج در مطلب</i></asp:LinkButton>
                                        <asp:TextBox runat="server" placeholder="آدرس فایل صوتی یا تصویری" ID="FileNameMediaPreMessage_En" Style="width: 235px; height: 28px; direction: ltr;text-align:left;" />
                                        <asp:Label runat="server" ID="lblInsertMediaStatePreMessage_En" Style="float: left;" class="label label-success" Visible="false" Text="رسانه با موفقیت در مطلب درج شد. " />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="RadMSG_En" class=" control-label">ادامه مطلب به انگلیسی:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <telerik:RadEditor ID="RadMSG_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="btn-group col-lg-6">
                                        <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertImageMessage_En" class="btn btn-success"><i class="fa fa-image"> درج در مطلب</i></asp:LinkButton>
                                        <asp:TextBox runat="server" placeholder="آدرس تصویر" ID="FileNameMessage_En" Style="width: 135px; height: 28px; direction: ltr;text-align:left;" />
                                        <asp:Label runat="server" ID="lblInsertImageStateMessage_En" Style="float: left;" class="label label-success" Visible="false" Text="تصویر با موفقیت در مطلب درج شد. " />
                                    </div>
                                    <div class="btn-group col-lg-6">
                                        <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertMediaMessage_En" class="btn btn-success"><i class="fa fa-file-sound-o"> درج در مطلب</i></asp:LinkButton>
                                        <asp:TextBox runat="server" placeholder="آدرس فایل صوتی یا تصویری" ID="FileNameMediaMessage_En" Style="width: 235px; height: 28px; direction: ltr;text-align:left;" />
                                        <asp:Label runat="server" ID="lblInsertMediaStateMessage_En" Style="float: left;" class="label label-success" Visible="false" Text="رسانه با موفقیت در مطلب درج شد. " />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="txtKeyword_En" class=" control-label">برچسب انگلیسی:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <asp:TextBox ID="txtKeyword_En" runat="server" class="form-control" Style="margin-bottom: 30px;direction: ltr; text-align:left;" placeholder="کلمات کلیدی را با ; جدا کنید." Width="100%" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="txtMetaDescription_En" class=" control-label">توضیحات متا: </label>
                                        تعداد کاراکتر:<span id="character-count-En" style="padding-right: 5px; color: #FF0000;">0</span>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <asp:TextBox ID="txtMetaDescription_En" Rows="4" TextMode="MultiLine" Style="margin-bottom: 6px;direction:ltr; text-align:left;" class="form-control" placeholder="توضیحات متا باید بین 70 تا 160 کاراکتر باشد." runat="server" Width="100%" MaxLength="600" onkeyup="count_remaining_character_metadescription_En()" onmousedown="count_remaining_character_metadescription_En()" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Style="margin-bottom: 30px;" runat="server" ValidationExpression="^.{70,160}$" ErrorMessage="تعداد کاراکتر باید بین 70 تا 160 باشد." ControlToValidate="txtMetaDescription_En" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="row" id="Save" style="margin-bottom: 30px;">
                        <div class="form-group">
                            <div class="col-md-12 btn-group">
                                <asp:Button ID="btnUpdateNews" runat="server" class="col-xs-6 btn btn-default" Text="ذخیره تغییرات" />
                                <asp:Button ID="btnSaveNewNews" runat="server" class="col-xs-6 btn btn-primary" Text="ایجاد خبر جدید" />
                            </div>
                            <div class="col-md-12 btn-group">
                                <asp:Button ID="btnSendFeed" runat="server" class="col-xs-12 btn btn-info" Text="ارسال خوراک خبری" />
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /#page-wrapper -->
    </div>
    <script>
        function count_remaining_character_metadescription_Fa() {
            var max_length = 160;
            var character_entered = $('#ContentPlaceHolder1_txtMetaDescription_Fa').val().length;
            var character_remaining = character_entered;
            $('#character-count-Fa').html(character_remaining);
            if (max_length < character_entered || character_entered < 70) {
                $('#character-count-Fa').css('color', '#FF0000');
            } else {
                $('#character-count-Fa').css('color', '#76BC31');
            }
        }
        function count_remaining_character_metadescription_En() {
            var max_length = 160;
            var character_entered = $('#ContentPlaceHolder1_txtMetaDescription_En').val().length;
            var character_remaining = character_entered;
            $('#character-count-En').html(character_remaining);
            if (max_length < character_entered || character_entered < 70) {
                $('#character-count-En').css('color', '#FF0000');
            } else {
                $('#character-count-En').css('color', '#76BC31');
            }
        }
        function count_remaining_character_title_Fa() {
            var max_length = 70;
            var character_entered = $('#ContentPlaceHolder1_txtTitle_Fa').val().length;
            var character_remaining = character_entered;
            $('#character-count-title-Fa').html(character_remaining);
            if (max_length < character_entered || character_entered < 10) {
                $('#character-count-title-Fa').css('color', '#FF0000');
            } else {
                $('#character-count-title-Fa').css('color', '#76BC31');
            }
        }
        function count_remaining_character_title_En() {
            var max_length = 70;
            var character_entered = $('#ContentPlaceHolder1_txtTitle_En').val().length;
            var character_remaining = character_entered;
            $('#character-count-title-En').html(character_remaining);
            if (max_length < character_entered || character_entered < 10) {
                $('#character-count-title-En').css('color', '#FF0000');
            } else {
                $('#character-count-title-En').css('color', '#76BC31');
            }
        }
    </script>

</asp:Content>

