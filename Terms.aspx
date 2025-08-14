<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Terms.aspx.vb" Inherits="Terms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <asp:Literal runat="server" ID="litMeta" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="breadcrumb-box">
        <asp:Literal runat="server" ID="ltrBreadCrumb" />
    </div>
    <!-- .breadcrumb-box -->
    <br />
    <br />
    <br />
    <header class="page-header">
        <div class="container">
            <h1 class="title">
                <asp:Literal runat="server" ID="ltrTitle" />
            </h1>
        </div>
    </header>
    <div class="container" style="margin-top: -30px;">

        <div class="row">
            <div class="content blog blog-post span9">
                <asp:PlaceHolder ID="PostViewPlaceHolder" runat="server"></asp:PlaceHolder>
            </div>
            <!-- .content -->

            <div id="sidebar" class="sidebar span3">
                <aside class="tags">
                    <header>
                        <h3>برچسب‌ها</h3>
                    </header>
                    <asp:Literal runat="server" ID="ltrTag" />
                </aside>
                <!-- .tags -->
                <asp:PlaceHolder runat="server" ID="PlaceHolderBlock"></asp:PlaceHolder>
                
            </div>
            <!-- .sidebar -->
        </div>
    </div>
    <!-- .container -->
    <%--    </section>--%>
    <!-- #main -->

</asp:Content>

