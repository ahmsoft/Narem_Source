<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Portfolio.aspx.vb" Inherits="Portfolio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal runat="server" ID="litMeta" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumb-box">
        <div class="container">
            <ul class="breadcrumb">
                <li><a href="/index">صفحه اصلی</a> <span class="divider">/</span></li>
                <li><a runat="server" id="lblRootPageHref" href="/portfolio/">نمونه کارها</a> <span class="divider">/</span></li>
                <li class="active">
                    <asp:Literal runat="server" ID="ltrCurrentPage" /></li>
            </ul>
        </div>
    </div>
    <!-- .breadcrumb-box -->
    <br />
    <br />
    <br />
    <header class="page-header">
        <div class="container">
            <h1 class="title">نمونه‌ها
                <asp:Literal runat="server" ID="ltrTitle_Fa" /></h1>
        </div>
    </header>
    <div style="background-color: #f5f5f5;padding:5px;border-color:black;border-style:dotted;">
        <div class="container">
            <div class="row">
                <div class="span3">
                    <div class="span3 portfolio-tags bottom-padding">
                        <p>
                            <span style="font-weight:bolder;"><b>کد محصول: </b></span>
                                <asp:Literal runat="server" ID="ltrIDP" />
                        </p>
                        <p>
                            <span style="font-weight:bolder;"><b>عنوان: </b></span>
                                <asp:Literal runat="server" ID="ltrTitle1_Fa" />
                        </p>
                        <p>
                            <span style="font-weight:bolder;"><b>سال انتشار: </b></span>
                                <asp:Literal runat="server" ID="ltrMoment_Fa" />
                        </p>
                        <p>
                            <span style="font-weight:bolder;"><b>قابلیت‌های استفاده: </b></span>
                                <asp:Literal runat="server" ID="ltrCatName_Fa" />
                        </p>
                        <p>
                            <span style="font-weight:bolder;"><b>کلمات کلیدی: </b></span>
                                <asp:Literal runat="server" ID="ltrKeyword_Fa" />
                        </p>
                        <p>
                            <asp:Literal runat="server" ID="ltrDescription_Fa" />
                        </p>
                        <asp:Literal runat="server" ID="ltrBtnView" />
                    </div>
                </div>
                <div class="span9" style="background-color: #f5f5f5;">
                <asp:Literal runat="server" ID="ltrGalleryPortfolio" />
                </div>
            </div>
        </div>
    </div>
    <!-- #slider -->
    <div class="clearfix"></div>

    <section id="main">
        <header class="page-header">
            <div class="container">
                <h1 class="title">نمونه کارها و قالب‌ها</h1>
            </div>
        </header>
        <div class="container">
            <div class="row">
                <div class="content span12 portfolio portfolio4">
                    <div class="filter-buttons pull-left">
                        <asp:Literal runat="server" ID="ltrPortfCat" />
                    </div>
                    <!-- .filter-buttons --> 

                    <!-- .price-regulator -->

                    <div class="clearfix"></div>

                    <div class="row filter-elements">
                        <asp:Literal runat="server" ID="ltrPortfo" />

                    </div>
                </div>
                <!-- .content -->
            </div>
        </div>
        <!-- .container -->

    </section>

    <!-- .container -->
</asp:Content>

