<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="About.aspx.vb" Inherits="About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal runat="server" ID="litMeta" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumb-box">
        <div class="container">
            <ul class="breadcrumb">
                <li><a href="/index">صفحه اصلی</a> <span class="divider">/</span></li>
                <li><a runat="server" id="lblRootPageHref"></a><span class="divider">/</span></li>
                <li class="active">
                    <asp:Label runat="server" ID="lblCurrentPage" /></li>
            </ul>
        </div>
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
        <div class="full-width-box bottom-padding" runat="server" id="ManagerDiv" visible="false">
            <div class="bg fixed bg-image band-11">
                <div class="overlay"></div>
            </div>
            <div class="title-box title-white">
                <h1 class="title">اعضای هیئت مدیره</h1>
            </div>

            <div class="row team-box">
                <asp:Literal runat="server" ID="ltrAdminMember" />
            </div>
            <div class="clearfix"></div>
        </div>

    </div>
    <!-- .container -->
    <!-- #main -->

</asp:Content>

