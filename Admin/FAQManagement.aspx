<%@ Page Title="" Language="VB" MasterPageFile="AdminMasterPage.master" AutoEventWireup="false" CodeFile="FAQManagement.aspx.vb" Inherits="FAQManagement1" %>

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
                    <h1 class="page-header">F.A.Q مدیریت <small>مدیریت سوالات متداول</small></h1>

                    <ol class="breadcrumb">
                        <li>
                            <i class="fa fa-dashboard"></i>Dashboard
                        </li>
                        <li class="active">
                            <i class="fa fa-question-circle"></i>F.A.Q Management
                        </li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
            <div class="box box-default" id="FAQ">
                <div class="box-header with-border">
                    <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">پرسش‌ها</a></h3>
                    <div class="box-tools pull-right">
                        <%--<a href="#PersonInfo" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">

                        <div class="col-lg-12">
                            <asp:GridView ID="FAQView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="DataSourceFAQ" Width="100%" DataKeyNames="IDF">
                                <Columns>
                                    <asp:CommandField ButtonType="Button" SelectText="انتخاب" ShowSelectButton="True">
                                        <ControlStyle CssClass="btn btn-success btn-xs" Width="100%" />
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Question_Fa" HeaderText="پرسش فارسی" SortExpression="Question_Fa">
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Question_En" HeaderText="پرسش انگلیسی" SortExpression="Question_En">
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
                                    <asp:BoundField DataField="Seen" HeaderText="وضعیت" SortExpression="Seen">
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
                    <asp:SqlDataSource ID="DataSourceFAQ" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" InsertCommand="INSERT INTO [FAQ] ([IDF],[PreAnswer_Fa],[PreAnswer_En],[Answer_Fa],[Answer_En],[Keyword_Fa],[Keyword_En],[Question_En],[Question_Fa],[IsShow],[Year_Fa],[Month_Fa],[Day_Fa],[Year_En],[Month_En],[Day_En],[Priority]) VALUES (@IDF, @PreAnswer_Fa,@PreAnswer_En,@Answer_Fa,@Answer_En,@Keyword_Fa,@Keyword_En,@Question_En,@Question_Fa,@IsShow,@Year_Fa,@Month_Fa,@Day_Fa,@Year_En,@Month_En,@Day_En,@Priority)" SelectCommand="SELECT * FROM [FAQ] ORDER BY [Seen],[IDF] DESC" DeleteCommand="Delete From [FAQ] Where [IDF]=@IDF">
                        <DeleteParameters>
                            <asp:ControlParameter ControlID="FAQView" Name="IDF" PropertyName="SelectedValue" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="IDF" Type="Int32" />
                            <asp:Parameter Name="Question_Fa" Type="String" />
                            <asp:Parameter Name="Question_En" Type="String" />
                            <asp:Parameter Name="PreAnswer_Fa" Type="String" />
                            <asp:Parameter Name="PreAnswerEN" Type="String" />
                            <asp:Parameter Name="Answer_Fa" Type="String" />
                            <asp:Parameter Name="Answer_En" Type="String" />
                            <asp:Parameter Name="Keyword_Fa" Type="String" />
                            <asp:Parameter Name="Keyword_En" Type="String" />
                            <asp:Parameter Name="IsShow" Type="Boolean" />
                            <asp:Parameter Name="Year_En" Type="Int32" />
                            <asp:Parameter Name="Month_En" Type="Int32" />
                            <asp:Parameter Name="Day_En" Type="Int32" />
                            <asp:Parameter Name="Year_En" Type="Int32" />
                            <asp:Parameter Name="Month_En" Type="Int32" />
                            <asp:Parameter Name="Day_En" Type="Int32" />
                            <asp:Parameter Name="Priority" Type="Int32" />
                            <asp:Parameter Name="Moment" Type="String" />
                        </InsertParameters>

                    </asp:SqlDataSource>

                    <div class="box box-danger" id="PersonInfo">
                        <div class="box-header with-border">
                            <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">اطلاعات شخص سوال کننده</a></h3>

                            <div class="box-tools pull-right">
                                <%--<a href="#FAQ" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                                <a href="#FAQInfo" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            </div>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <div class="row">
                                <div class="form-group">
                                    <label for="txtNameAndFamily_Fa" class="col-lg-12 control-label">نام و نام خانوادگی فارسی:</label>
                                    <div class="col-lg-12">
                                        <asp:TextBox runat="server" for="Text" ID="txtNameAndFamily_Fa" Style="margin-bottom: 30px;" class="form-control" placeholder="نام و نام خانوادگی به فارسی" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <label for="txtNameAndFamily_En" class="col-lg-12 control-label">نام و نام خانوادگی انگلیسی:</label>
                                    <div class="col-lg-12">
                                        <asp:TextBox runat="server" for="Text" ID="txtNameAndFamily_En" Style="margin-bottom: 30px;text-align: left;direction: ltr;" class="form-control" placeholder="نام و نام خانوادگی به انگلیسی" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <label for="txtEmail" class="col-lg-12 control-label">پست الکترونیکی:</label>
                                    <div class="col-lg-12">
                                        <asp:TextBox runat="server" for="Text" ID="txtEmail" Style="margin-bottom: 30px;direction: ltr;text-align: left;" class="form-control" placeholder="پست الکترونیکی" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="txtWebsite" class=" control-label">وب سایت:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <asp:TextBox runat="server" for="Text" ID="txtWebsite" Style="margin-bottom: 30px;direction:ltr;text-align: left;" class="form-control" placeholder="آدرس وب سایت" />
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

                    <div class="box box-warning" id="FAQInfo">
                        <div class="box-header with-border">
                            <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">اطلاعات پرسش و پاسخ</a></h3>

                            <div class="box-tools pull-right">
                                <%--<a href="#PersonInfo" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                                <a href="#FAQFa" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            </div>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-md-12 center-block">
                                        <asp:CheckBox ID="chkIsShow" Style="margin-bottom: 30px;" CssClass="col-xs-12 checkbox" runat="server" Text="پیام نمایش داده شود." Checked="True" />
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
                                        <asp:Label runat="server" ID="lblMomentOld_Fa" Style="color: rgb(255, 154, 52);" />
                                        <div class="input-group date">
                                            <div class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </div>
                                            <input runat="server" type="text" id="tarikh" class="form-control pull-right" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6">
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

                    <div class="box box-success" id="FAQ_Fa">
                        <div class="box-header with-border">
                            <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">پرسش و پاسخ فارسی</a></h3>

                            <div class="box-tools pull-right">
                                <%--<a href="#FAQInfo" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                                <a href="#FAQ_En" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            </div>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">

                            <div class="row">

                                <div class="form-group">
                                    <label for="txtTitle_Fa" class="col-lg-12 control-label">پرسش به فارسی:</label>
                                    <div class="col-lg-12">
                                        <asp:TextBox runat="server" for="Text" ID="txtQuestion_Fa" Style="margin-bottom: 30px;" class="form-control" placeholder="سوال به فارسی" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="RadPreAnswer_Fa" class=" control-label">پاسخ به فارسی:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <telerik:RadEditor ID="RadPreAnswer_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="RadAnswer_Fa" class=" control-label">ادامه پاسخ به فارسی:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <telerik:RadEditor ID="RadAnswer_Fa" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
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
                            <%--                            <div class="row">
                                <div class="form-group col-lg-12">
                                    <label for="Day_Fa" class=" control-label">روز به شمسی:</label>
                                    <asp:DropDownList ID="Day_Fa" Style="margin-bottom: 30px;" runat="server">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                        <asp:ListItem>13</asp:ListItem>
                                        <asp:ListItem>14</asp:ListItem>
                                        <asp:ListItem>15</asp:ListItem>
                                        <asp:ListItem>16</asp:ListItem>
                                        <asp:ListItem>17</asp:ListItem>
                                        <asp:ListItem>18</asp:ListItem>
                                        <asp:ListItem>19</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                        <asp:ListItem>21</asp:ListItem>
                                        <asp:ListItem>22</asp:ListItem>
                                        <asp:ListItem>23</asp:ListItem>
                                        <asp:ListItem>24</asp:ListItem>
                                        <asp:ListItem>25</asp:ListItem>
                                        <asp:ListItem>26</asp:ListItem>
                                        <asp:ListItem>27</asp:ListItem>
                                        <asp:ListItem>28</asp:ListItem>
                                        <asp:ListItem>29</asp:ListItem>
                                        <asp:ListItem>30</asp:ListItem>
                                        <asp:ListItem>31</asp:ListItem>
                                    </asp:DropDownList>
                                    <label for="Month_Fa" class=" control-label">ماه به شمسی:</label>
                                    <asp:DropDownList ID="Month_Fa" runat="server">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                    </asp:DropDownList>
                                    <label for="Year_Fa" class=" control-label">سال به شمسی:</label>
                                    <asp:DropDownList ID="Year_Fa" runat="server">
                                        <asp:ListItem>1398</asp:ListItem>
                                        <asp:ListItem>1399</asp:ListItem>
                                        <asp:ListItem>1400</asp:ListItem>
                                        <asp:ListItem>1401</asp:ListItem>
                                        <asp:ListItem>1402</asp:ListItem>
                                        <asp:ListItem>1403</asp:ListItem>
                                        <asp:ListItem>1404</asp:ListItem>
                                        <asp:ListItem>1405</asp:ListItem>
                                        <asp:ListItem>1406</asp:ListItem>
                                        <asp:ListItem>1407</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                            <%--<div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <a href="#Save" style="margin-bottom: 30px; float: left;" class="btn btn-info"><i class="fa fa-arrow-circle-down"></i></a>
                                    </div>
                                </div>
                            </div>--%>
                        </div>
                    </div>
                    <div class="box box-info" id="FAQ_En">
                        <div class="box-header with-border">
                            <h3 class="box-title"><a href="#" style="color: black;" data-widget="collapse">پرسش و پاسخ انگلیسی</a></h3>

                            <div class="box-tools pull-right">
                                <%--<a href="#FAQ_Fa" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-up"></i></a>
                                <a href="#Save" type="button" class="btn btn-box-tool" data-widget=""><i style="color: blue;" class="fa fa-arrow-circle-down"></i></a>--%>
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            </div>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">

                            <div class="row">

                                <div class="form-group">
                                    <label for="txtQuestion_En" class="col-lg-12 control-label">پرسش به انگلیسی:</label>
                                    <div class="col-lg-12">
                                        <asp:TextBox runat="server" for="Text" ID="txtQuestion_En" Style="margin-bottom: 30px;direction: ltr;text-align: left;" class="form-control" placeholder="عنوان پیام به انگلیسی " />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="RadPreAnswer_En" class=" control-label">پاسخ به انگلیسی:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <telerik:RadEditor ID="RadPreAnswer_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="RadAnswer_En" class=" control-label">ادامه پاسخ به انگلیسی:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <telerik:RadEditor ID="RadAnswer_En" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating"></telerik:RadEditor>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-12 center-block">
                                        <label for="txtKeyword_En" class=" control-label">برچسب انگلیسی:</label>
                                    </div>
                                    <div class="col-lg-12 center-block">
                                        <asp:TextBox ID="txtKeyword_En" runat="server" class="form-control" Style="margin-bottom: 30px;direction: ltr;text-align: left;" placeholder="کلمات کلیدی را با ; جدا کنید." Width="100%" />
                                    </div>
                                </div>
                            </div>
                            <%--                            <div class="row">
                                <div class="form-group col-lg-12">
                                    <label for="Day_En" class=" control-label">روز به میلادی:</label>
                                    <asp:DropDownList ID="Day_En" Style="margin-bottom: 30px;" runat="server">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                        <asp:ListItem>13</asp:ListItem>
                                        <asp:ListItem>14</asp:ListItem>
                                        <asp:ListItem>15</asp:ListItem>
                                        <asp:ListItem>16</asp:ListItem>
                                        <asp:ListItem>17</asp:ListItem>
                                        <asp:ListItem>18</asp:ListItem>
                                        <asp:ListItem>19</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                        <asp:ListItem>21</asp:ListItem>
                                        <asp:ListItem>22</asp:ListItem>
                                        <asp:ListItem>23</asp:ListItem>
                                        <asp:ListItem>24</asp:ListItem>
                                        <asp:ListItem>25</asp:ListItem>
                                        <asp:ListItem>26</asp:ListItem>
                                        <asp:ListItem>27</asp:ListItem>
                                        <asp:ListItem>28</asp:ListItem>
                                        <asp:ListItem>29</asp:ListItem>
                                        <asp:ListItem>30</asp:ListItem>
                                        <asp:ListItem>31</asp:ListItem>
                                    </asp:DropDownList>
                                    <label for="Month_En" class=" control-label">ماه به میلادی:</label>
                                    <asp:DropDownList ID="Month_En" runat="server">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                    </asp:DropDownList>
                                    <label for="Year_En" class=" control-label">سال به میلادی:</label>
                                    <asp:DropDownList ID="Year_En" runat="server">
                                        <asp:ListItem>2019</asp:ListItem>
                                        <asp:ListItem>2020</asp:ListItem>
                                        <asp:ListItem>2021</asp:ListItem>
                                        <asp:ListItem>2022</asp:ListItem>
                                        <asp:ListItem>2023</asp:ListItem>
                                        <asp:ListItem>2024</asp:ListItem>
                                        <asp:ListItem>2025</asp:ListItem>
                                        <asp:ListItem>2028</asp:ListItem>
                                        <asp:ListItem>2029</asp:ListItem>
                                        <asp:ListItem>2030</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                        </div>
                    </div>
                    <div class="row" id="Save" style="margin-bottom: 30px;">
                        <div class="form-group">
                            <div class="col-md-12 btn-group">
                                <asp:Button ID="btnUpdateMessage" runat="server" class="col-xs-6 btn btn-default" Text="ذخیره تغییرات" />
                                <asp:Button ID="btnSaveNewMessage" runat="server" class="col-xs-6 btn btn-primary" Text="ایجاد پرسش و پاسخ جدید" />
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

</asp:Content>

