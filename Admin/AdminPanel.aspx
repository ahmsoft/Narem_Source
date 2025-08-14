<%@ Page Title="" Language="VB" MasterPageFile="AdminMasterPage.master" AutoEventWireup="false" CodeFile="AdminPanel.aspx.vb" Inherits="AdminPanel1" %>

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

    <!-- Main content -->
    <section class="content">
        <!-- Info boxes -->
        <div class="row">
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-aqua"><i class="fa fa-tasks"></i></span>

                    <div class="info-box-content">
                        <span class="info-box-text">پست‌ها</span>
                        <a href="MessageManagement.aspx" style="color: black;"><span class="info-box-number">
                            <asp:Label ID="lblMessagesCount" runat="server" /><small> مورد</small></span></a>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-red"><i class="fa fa-question"></i></span>

                    <div class="info-box-content">
                        <span class="info-box-text">سوالات</span>
                        <a href="FAQManagement.aspx" style="color: black;"><span class="info-box-number">
                            <asp:Label ID="lblFAQsCount" runat="server" /><small> مورد</small></span></a>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->

            <!-- fix for small devices only -->
            <div class="clearfix visible-sm-block"></div>

            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-green"><i class="fa fa-comment"></i></span>

                    <div class="info-box-content">
                        <span class="info-box-text">نظرات</span>
                        <a href="CommentManagement.aspx" style="color: black;"><span class="info-box-number">
                            <asp:Label ID="lblCommentsCount" runat="server" /><small> مورد</small></span></a>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-yellow"><i class="fa fa-commenting"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">پاسخ به نظرات</span>
                        <a href="CommentManagement.aspx" style="color: black;"><span class="info-box-number">
                            <asp:Label ID="lblSubCommentsCount" runat="server" /><small> مورد</small></span></a>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->

        <div class="box box-primary" runat="server" id="frmClientInfo">
            <div class="box-header with-border">
                <h3 class="box-title">یادآوری </h3>

                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
                <div class="row">
                    <div class="row">
                        <div class="form-group col-md-12">
                            <label for="txtMessage" class="col-md-1 control-label" style="width: 100%;">متن یادداشت:<asp:Button runat="server" ID="btnVisitMemo" class="btn btn-info" Style="float: left; margin-left: 10px;" Text="نمایش آخرین تغییرات" /><asp:Button runat="server" ID="btnEnCrypt" class="btn btn-info" Style="float: left; margin-left: 10px;" Text="رمزنگاری" /><asp:Button runat="server" ID="btnDeCrypt" class="btn btn-info" Style="float: left; margin-left: 10px;" Text="رمزگشایی" /></label>
                            <div class="col-md-12">
                                <telerik:RadEditor ID="RadMemo" runat="server" Skin="Bootstrap" Style="direction: ltr; margin-bottom: 30px; height: auto;" Width="100%" ToolbarMode="Floating" DocumentManager-ViewPaths="~/Uploads" ImageManager-ViewPaths="~/Uploads"></telerik:RadEditor>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.box-body -->
                <div class="box-footer" id="Save">
                    <asp:Button ID="btnUpdateMemo" runat="server" class="col-lg-12 btn btn-success" Text="ذخیره تغییرات" />
                    <hr />
                    <div class="input-append">
                        <%--  <input class="span2" id="appendedInputButtons" type="text">--%>
                        <%--<asp:TextBox runat="server" type="text" class="span2" ID="txtPassChecker" Text="" placeholder="کلمه عبور مورد نظر" />--%>
<%--                        <asp:Button runat="server" class="btn" type="button" ID="btnPassEncription" Text="رمزگذاری" />--%>
<%--                        <asp:Button runat="server" class="btn" type="button" ID="btnPassDecription" Text="رمزگشایی" />--%>
                        <%--  <button class="btn" type="button">Search</button>
  <button class="btn" type="button">Options</button>--%>
                    </div>
              <div class="input-group input-group-lg">
                <div class="input-group-btn">
                  <button type="button" class="btn btn-info dropdown-toggle" data-toggle="dropdown">تبدیل
                    <span class="fa fa-caret-down"></span></button>
                  <ul class="dropdown-menu">
                    <li><asp:Button runat="server" class="btn btn-danger form-control" type="button" ID="btnPassEncription" Text="رمزگذاری" /></li>
                    <li class="divider"></li>
                    <li><asp:Button runat="server" class="btn btn-warning form-control" type="button" ID="btnPassDecription" Text="رمزگشایی" /></li>
                  </ul>
                </div>
                <!-- /btn-group -->
                  <asp:TextBox runat="server" type="text" class="form-control" ID="txtPassChecker" Text="" placeholder="رمز عبور مورد نظر" />
<%--                <input type="text" class="form-control">--%>
              </div>
<%--                    <asp:TextBox runat="server" type="text" class="span2" ID="txtPassChecker" Text="" placeholder="کلمه عبور مورد نظر" />--%>

                </div>
                    <asp:TextBox runat="server" class="form-control" ReadOnly="true" ID="lblResultCheckPass" Text="نتیجه تبدیل رمز عبور: " />
            </div>
        </div>

    </section>
    <!-- /.content -->
</asp:Content>

