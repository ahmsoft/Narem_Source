<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Portf.aspx.vb" Inherits="Portf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal runat="server" ID="litMeta" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumb-box">
        <div class="container">
            <ul class="breadcrumb">
                <li><a href="/index">صفحه اصلی</a> <span class="divider">/</span></li>
                <li class="active">نمونه کارها</li>
            </ul>
        </div>
    </div>
    <!-- .breadcrumb-box -->

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
                        <%--<a href="#" class="active" data-filter="*">همه</a>
                        <a href="#" data-filter=".Company">شرکتی</a>
                        <a href="#" data-filter=".Personal">شخصی رزومه‌ای</a>
                        <a href="#" data-filter=".Marketing">فروشگاهی</a>
                        <a href="#" data-filter=".Servering">خدماتی</a>
                        <a href="#" data-filter=".generalP">چندمنظوره</a>--%>
                    </div>
                    <!-- .filter-buttons --> 

                    <%--<div class="year-regulator pull-right">
                        <b>Year:</b>
                        <div class="layout-slider span4">
                            <input id="filter" type="slider" name="year" value="2000;2013" />
                        </div>
                    </div>--%>
                    <!-- .price-regulator -->

                    <div class="clearfix"></div>

                    <div class="row filter-elements">
<%--                        <asp:Label runat="server" ID="lblPortfo" />--%>
                        <asp:Literal runat="server" ID="ltrPortfo" />
<%--                        <asp:PlaceHolder runat="server" ID="PlaceHolderPortfo"></asp:PlaceHolder>--%>
"
                        <%--<div class="span3 generalP Servering Personal Company Marketing">
                            <a href="portfolio-single.html" class="work">
                                <img src="img/content/banner4.jpg" width="370" height="270" alt="">
                                <span class="shadow"></span>
                                <div class="bg-hover"></div>
                                <div class="work-title">
                                    <h3 class="title">وب سایت شرکت نارم</h3>
                                    <div class="description">وبسایت شرکت نارِم به منظور معرفی و دریافت سفارشات آنلان جهت طراحی و توسعه وب سایت طراحی شده. این پروژه هنوز درحال بروز رسانی برخی قسمتها در پنل مدیریتی می‌باشد.</div>
                                </div>
                            </a>
                        </div>
                        <div class="span3 Marketing Servering Company">
                            <a href="portfolio-single.html" class="work">
                                <img src="img/content/banner2.jpg" width="370" height="270" alt="">
                                <span class="shadow"></span>
                                <div class="bg-hover"></div>
                                <div class="work-title">
                                    <h3 class="title">نارم مارکت </h3>
                                    <div class="description">وب سایت فروشگاهی، بمنظور بستری جهت فروش فایل و مقالات کمک آموزشی و پژوهشی است.</div>
                                </div>
                            </a>
                        </div>
                        <div class="span3 Personal">
                            <a href="portfolio-single.html" class="work">
                                <img src="img/content/banner3.jpg" width="370" height="270" alt="">
                                <span class="shadow"></span>
                                <div class="bg-hover"></div>
                                <div class="work-title">
                                    <h3 class="title">وب سایت رسمی دکتر احسان شریعتی</h3>
                                    <div class="description">این پروژه هم اکنون درحال ساخت است و از 4 زبان فارسی، انگلیسی، فرانسوی و عربی بخوبی پشتیبانی می‌کند.</div>
                                </div>
                            </a>
                        </div>
                        <div class="span3 Servering generalP Company">
                            <a href="portfolio-single.html" class="work">
                                <img src="img/content/banner1.jpg" width="370" height="270" alt="">
                                <span class="shadow"></span>
                                <div class="bg-hover"></div>
                                <div class="work-title">
                                    <h3 class="title">پروژه دوم شرکت نارم</h3>
                                    <div class="description">وبسایت شرکت نارِم به منظور معرفی و دریافت سفارشات آنلان جهت طراحی و توسعه وب سایت طراحی شده. این پروژه هنوز درحال بروز رسانی برخی قسمتها در پنل مدیریتی می‌باشد.</div>
                                </div>
                            </a>
                        </div>
                        <div class="span3 Personal">
                            <a href="portfolio-single.html" class="work">
                                <img src="img/content/banner5.jpg" width="370" height="270" alt="">
                                <span class="shadow"></span>
                                <div class="bg-hover"></div>
                                <div class="work-title">
                                    <h3 class="title">وب سایت مهندس علیرضا پارسایی</h3>
                                    <div class="description">وب سایت شخصی جهت معرفی مهندس علیرضا پارسایی دبیر کلاسهای کنکور ریاضی که به تازگی گوینده رادیو هستند.</div>
                                </div>
                            </a>
                        </div>
                        <div class="span3 Servering">
                            <a href="portfolio-single.html" class="work">
                                <img src="img/content/banner6.jpg" width="370" height="270" alt="">
                                <span class="shadow"></span>
                                <div class="bg-hover"></div>
                                <div class="work-title">
                                    <h3 class="title">تالار گفتمان اجتماعی</h3>
                                    <div class="description">این وبسایت هم اکنون منقضی شده.</div>
                                </div>
                            </a>
                        </div>
                        <div class="span3 Marketing Company Servering">
                            <a href="portfolio-single.html" class="work">
                                <img src="img/content/portfolio-7.jpg" width="370" height="270" alt="">
                                <span class="shadow"></span>
                                <div class="bg-hover"></div>
                                <div class="work-title">
                                    <h3 class="title">وب سایت مزرعه دمدار</h3>
                                    <div class="description">ارائه دهنده‌ی انواع حیوانات مزرعه</div>
                                </div>
                            </a>
                        </div>--%>

                        <%--<div class="span3 graphic-design">
                            <a href="portfolio-single.html" class="work">
                                <img src="img/content/portfolio-8.jpg" width="370" height="270" alt="">
                                <span class="shadow"></span>
                                <div class="bg-hover"></div>
                                <div class="work-title">
                                    <h3 class="title">Quisque nec lorem vel metus ultrices</h3>
                                    <div class="description">Web design</div>
                                </div>
                            </a>
                        </div>

                        <div class="span3 web-design">
                            <a href="portfolio-single.html" class="work">
                                <img src="img/content/portfolio-9.jpg" width="370" height="270" alt="">
                                <span class="shadow"></span>
                                <div class="bg-hover"></div>
                                <div class="work-title">
                                    <h3 class="title">Proin faucibus pretium</h3>
                                    <div class="description">Web design</div>
                                </div>
                            </a>
                        </div>--%>
                    </div>
                </div>
                <!-- .content -->
            </div>
        </div>
        <!-- .container -->

    </section>
    <!-- #main -->
</asp:Content>

