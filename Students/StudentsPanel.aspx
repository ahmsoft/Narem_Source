<%@ Page Title="" Language="VB" MasterPageFile="../Students/StudentsMasterPage.master" AutoEventWireup="false" CodeFile="StudentsPanel.aspx.vb" Inherits="StudentsPanel" %>

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
                    <span class="info-box-icon bg-aqua"><i class="fa fa-envelope-o"></i></span>

                    <div class="info-box-content">
                        <span class="info-box-text">پیام‌ها</span>
                        <a href="#" style="color: black;"><span class="info-box-number">
                            <asp:Label ID="lblCommentCount" Style="font-size: small;" runat="server" /><small style="font-size: small;"> مورد</small></span></a>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-red"><i class="fa fa-bookmark"></i></span>
                    <div class="info-box-content">

                        <span class="info-box-text">علاقه‌مندی‌ها</span>
                        <a href="#" style="color: black;"><span class="info-box-number">
                            <asp:Label ID="lblOrderCount" runat="server" /><small style="font-size: small;">0 مورد</small></span></a>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->
            <!-- fix for small devices only -->
            <%--<div class="clearfix visible-sm-block"></div>--%>
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-green"><i class="ion ion-ios-paper-outline"></i></span>

                    <div class="info-box-content">
                        <span class="info-box-text">نمونه ها</span>
                        <a href="#" style="color: black;"><span class="info-box-number"><small style="font-size: small;">0 مورد</small></span>
                        </a>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-yellow"><i class="fa fa-tasks"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">پیشرفت کار</span>
                        <a href="#" style="color: black;"><span class="info-box-number">
                            <asp:Label ID="lblTaskCount" runat="server" /><small>پروژه</small></span></a>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->

        <!-- /.row -->

        <!-- Main row -->
        <!-- /.row -->
        <%--<div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">روند پیشرفت پروژه </h3>
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
                <div class="row">
                    <div class="row">
                        <div class="form-group col-md-12">
                            <span class="col-md-1 control-label" style="width: 100%;">پیام مدیر خط تولید شرکت:</span>
                            <div class="col-md-12">
                                <p style="border-style: solid; border-color: rgb(98, 98, 0); padding: 10px; height: 100%; width: 100%;"></p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box-footer">
                    <span>درحال حاضر سیستم پنل مشتری در حال توسعه می‌باشد.</span>
                </div>
            </div>
        </div>--%>
        <asp:Label runat="server" ID="lblStudentPanel" />

    </section>
    <!-- /.content -->
</asp:Content>

