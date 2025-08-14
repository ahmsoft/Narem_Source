<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="DynamicPageManagement.aspx.vb" Inherits="Admin_DynamicPageManagement" %>

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
                    <h1 class="page-header">مدیریت صفحه پویا <small>ایجاد و تغییرات</small></h1>
                    <ol class="breadcrumb">
                        <li>
                            <i class="fa fa-dashboard"></i>Dashboard
                        </li>
                        <li class="active">
                            <i class="fa fa-newspaper-o"></i>Pages Management
                        </li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
            <div class="box box-default" id="Pages">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">صفحه‌ها </a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="Pages_Fa" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">

                        <div class="col-lg-12">
                            <asp:GridView ID="PagesView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="DataSourcePages" Width="100%" DataKeyNames="ID">
                                <Columns>
                                    <asp:CommandField ButtonType="Button" SelectText="انتخاب" ShowSelectButton="True">
                                        <ControlStyle CssClass="btn btn-success btn-xs" Width="100%" />
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="PageTitle_Fa" HeaderText="عنوان فارسی" SortExpression="PageTitle_Fa">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PageTitle_En" HeaderText="عنوان انگلیسی" SortExpression="PageTitle_En">
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
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" Style="width: 100%; direction: ltr; margin-top: 3px;" placeholder="آدرس صفحه" Visible="false" ReadOnly="true" />
                        </div>
                        <div class="col-lg-6">
                            <asp:Label runat="server" ID="lblPageView" Style="width: 100%;" Visible="false" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <asp:SqlDataSource ID="DataSourcePages" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT * FROM [Page] ORDER BY ID DESC" DeleteCommand="Delete From [Page] Where [ID]=@ID">
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="PagesView" Name="ID" PropertyName="SelectedValue" />
                        </DeleteParameters>
                    </asp:SqlDataSource>
                    <div class="box box-success" id="Pages_Fa">
                        <div class="box-header with-border">
                            <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">صفحه فارسی</a></h3>

                            <div class="box-tools pull-right">
                                <%--<a href="#Posts" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up "></i></a>
                                <a href="#Pages_En" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            </div>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
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
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="txtTitle_Fa" class=" control-label">عنوان به فارسی: </label>
                                        تعداد کاراکتر:<span id="character-count-title-Fa" style="padding-right: 5px; color: #FF0000;">0</span>
                                    </div>
                                    <div class="col-lg-12">
                                        <asp:TextBox runat="server" for="Text" ID="txtTitle_Fa" Style="margin-bottom: 6px;" class="form-control" placeholder="عنوان صفحه به فارسی" onkeyup="count_remaining_character_title_Fa()" onmousedown="count_remaining_character_title_Fa()" />
                                        <asp:RegularExpressionValidator Style="margin-bottom: 30px;" ID="RegularExpression_txtTitle_Fa" runat="server" ValidationExpression="^.{10,70}$" ErrorMessage="تعداد کاراکتر باید بین 10 تا 70 باشد." ControlToValidate="txtTitle_Fa" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="RadPage_Fa" class=" control-label">بدنه صفحه به فارسی:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <telerik:RadEditor ID="RadPage_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating" DocumentManager-ViewPaths="~/Uploads" ImageManager-ViewPaths="~/Uploads"></telerik:RadEditor>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="btn-group col-lg-6">
                                        <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertImageBody_Fa" class="btn btn-success"><i class="fa fa-image"> درج در مطلب</i></asp:LinkButton>
                                        <asp:TextBox runat="server" placeholder="آدرس تصویر" ID="FileNameBody_Fa" Style="width: 135px; height: 28px; direction: ltr;text-align:left;" />
                                        <asp:Label runat="server" ID="lblInsertImageStateBody_Fa" Style="float: left;" class="label label-success" Visible="false" Text="تصویر با موفقیت در مطلب درج شد. " />
                                    </div>
                                    <div class="btn-group col-lg-6">
                                        <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertMediaBody_Fa" class="btn btn-success"><i class="fa fa-file-sound-o"> درج در مطلب</i></asp:LinkButton>
                                        <asp:TextBox runat="server" placeholder="آدرس فایل صوتی یا تصویری" ID="FileNameMediaBody_Fa" Style="width: 235px; height: 28px; direction: ltr;text-align:left;" />
                                        <asp:Label runat="server" ID="lblInsertMediaStateBody_Fa" Style="float: left;" class="label label-success" Visible="false" Text="رسانه با موفقیت در مطلب درج شد. " />
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
                                        <label for="txtMetaDescription_Fa" class=" control-label">توضیحات متا فارسی: </label>
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
                                        <asp:TextBox runat="server" for="Text" ID="txtMetaPic" Style="margin-bottom: 30px;direction: ltr;text-align:left;" class="form-control" placeholder="تصویر متا" />
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
                    <div class="box box-info" id="Pages_En">
                        <div class="box-header with-border">
                            <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">صفحه انگلیسی</a></h3>
                            <div class="box-tools pull-right">
                                <%--<a href="#Pages_Fa" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
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
                                            <asp:TextBox runat="server" for="Text" ID="txtTitle_En" Style="direction: ltr;text-align: left;margin-bottom: 6px;" class="form-control" placeholder="عنوان پیام به انگلیسی" onkeyup="count_remaining_character_title_En()" onmousedown="count_remaining_character_title_En()" />
                                            <asp:RegularExpressionValidator Style="margin-bottom: 30px;" ID="RegularExpression_txtTitle_En" runat="server" ValidationExpression="^.{10,70}$" ErrorMessage="تعداد کاراکتر باید بین 10 تا 70 باشد." ControlToValidate="txtTitle_En" ForeColor="Red"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="RadPage_En" class=" control-label">بدنه صفحه به انگلیسی:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <telerik:RadEditor ID="RadPage_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="btn-group col-lg-6">
                                        <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertImageBody_En" class="btn btn-success"><i class="fa fa-image"> درج در مطلب</i></asp:LinkButton>
                                        <asp:TextBox runat="server" placeholder="آدرس تصویر" ID="FileNameBody_En" Style="width: 135px; height: 28px; direction: ltr;text-align:left;" />
                                        <asp:Label runat="server" ID="lblInsertImageStateBody_En" Style="float: left;" class="label label-success" Visible="false" Text="تصویر با موفقیت در مطلب درج شد. " />
                                    </div>
                                    <div class="btn-group col-lg-6">
                                        <asp:LinkButton runat="server" Style="margin-bottom: 30px; height: 28px;" ID="btnInsertMediaBody_En" class="btn btn-success"><i class="fa fa-file-sound-o"> درج در مطلب</i></asp:LinkButton>
                                        <asp:TextBox runat="server" placeholder="آدرس فایل صوتی یا تصویری" ID="FileNameMediaBody_En" Style="width: 235px; height: 28px; direction: ltr;text-align:left;" />
                                        <asp:Label runat="server" ID="lblInsertMediaStateBody_En" Style="float: left;" class="label label-success" Visible="false" Text="رسانه با موفقیت در مطلب درج شد. " />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="txtKeyword_En" class=" control-label">برچسب انگلیسی:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <asp:TextBox ID="txtKeyword_En" runat="server" class="form-control" Style="direction: ltr;text-align: left;margin-bottom: 30px;" placeholder="کلمات کلیدی را با ; جدا کنید." Width="100%" />
                                    </div>
                                </div>
                            </div>
                                                        <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="txtMetaDescription_En" class=" control-label">توضیحات متا انگلیسی: </label>
                                        تعداد کاراکتر:<span id="character-count-En" style="padding-right: 5px; color: #FF0000;">0</span>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <asp:TextBox ID="txtMetaDescription_En" Rows="4" TextMode="MultiLine" Style="direction: ltr;text-align: left;margin-bottom: 6px;" class="form-control" placeholder="توضیحات متا باید بین 70 تا 160 کاراکتر باشد." runat="server" Width="100%" MaxLength="600" onkeyup="count_remaining_character_metadescription_En()" onmousedown="count_remaining_character_metadescription()" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Style="margin-bottom: 30px;" runat="server" ValidationExpression="^.{70,160}$" ErrorMessage="تعداد کاراکتر باید بین 70 تا 160 باشد." ControlToValidate="txtMetaDescription_En" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="row" id="Save" style="margin-bottom: 30px;">
                        <div class="form-group">
                            <div class="col-md-12 btn-group">
                                <asp:Button ID="btnUpdatePage" runat="server" class="col-xs-6 btn btn-default" Text="ذخیره تغییرات" />
                                <asp:Button ID="btnSaveNewPage" runat="server" class="col-xs-6 btn btn-primary" Text="ایجاد صفحه جدید" />
                            </div>
                            <div class="col-md-12 btn-group">
                                <asp:Button ID="btnSendFeed" runat="server" class="col-xs-12 btn btn-info" Text="ارسال خوراک خبری" />
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.row -->
            </div>
            <!-- /.row -->

        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
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

