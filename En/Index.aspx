<%@ Page Title="" Language="VB" MasterPageFile="~/En/MasterPage.master" AutoEventWireup="false" CodeFile="Index.aspx.vb" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script>
        function alertsucsses() {
            Swal.fire(
                'ارسال موفق',
                'ایمیل شما با موفقیت ثبت شد',
                'success'
            )
        }
    </script>--%>
    <asp:Literal runat="server" ID="litMeta" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="slider" class="rs-slider load">
        <div class="tp-banner-container">
            <div class="tp-banner">
                <ul>
                    <li data-delay="7000" data-transition="fade" data-slotamount="7" data-masterspeed="2000">
                        <div class="elements">
                            <div class="tp-caption lfl"
                                data-x="211"
                                data-y="203"
                                data-speed="1000"
                                data-start="1500"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn"
                                style="z-index: 2">
                                <img src="img/content/slider/rs-slider4-img1.png" alt="narem.ir">
                            </div>

                            <div class="tp-caption lft"
                                data-x="97"
                                data-y="271"
                                data-speed="1000"
                                data-start="1000"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn">
                                <img src="img/content/slider/rs-slider4-img2.png" alt="Narem">
                            </div>

                            <div class="tp-caption lft"
                                data-x="479"
                                data-y="271"
                                data-speed="1000"
                                data-start="1200"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn">
                                <img src="img/content/slider/rs-slider4-img2.png" alt="نارم">
                            </div>

                            <div class="tp-caption lfb"
                                data-x="-32"
                                data-y="372"
                                data-speed="1000"
                                data-start="1000"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn">
                                <img src="img/content/slider/rs-slider4-img3.png" alt="نارِم">
                            </div>

                            <div class="tp-caption lft"
                                data-x="166"
                                data-y="167"
                                data-speed="1000"
                                data-start="1000"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn">
                                <img src="img/content/slider/rs-slider4-img4.png" alt="NAREM">
                            </div>

                            <div class="tp-caption customin"
                                data-x="177"
                                data-y="62"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 100%;"
                                data-speed="700"
                                data-start="1400"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn"
                                style="z-index: 3">
                                <img src="img/content/slider/rs-slider4-img5.png" alt="Narem">
                            </div>

                            <div class="tp-caption lft"
                                data-x="487"
                                data-y="69"
                                data-speed="1000"
                                data-start="1500"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn"
                                style="z-index: 1">
                                <img src="img/content/slider/rs-slider4-img6.png" alt="AHMSoft">
                            </div>

                            <div class="tp-caption lfl"
                                data-x="539"
                                data-y="177"
                                data-speed="1000"
                                data-start="1000"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn"
                                style="z-index: 3">
                                <img src="img/content/slider/rs-slider4-img7.png" alt="نگار اعتبار رایان مبنا">
                            </div>

                            <div class="tp-caption lfl lft"
                                data-x="-33"
                                data-y="134"
                                data-speed="1000"
                                data-start="1700"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn"
                                style="z-index: 3">
                                <img src="img/content/slider/rs-slider4-img8.png" alt="نگار">
                            </div>

                            <div class="tp-caption customin"
                                data-x="375"
                                data-y="78"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1000"
                                data-start="1500"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn">
                                <img src="img/content/slider/rs-slider4-img9.png" alt="اعتبار">
                            </div>

                            <div class="tp-caption lfb"
                                data-x="141"
                                data-y="297"
                                data-speed="1000"
                                data-start="1800"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider4-img10.png" alt="رایان">
                            </div>

                            <div class="tp-caption lfl"
                                data-x="428"
                                data-y="356"
                                data-speed="500"
                                data-start="2000"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn"
                                style="z-index: 3">
                                <img src="img/content/slider/rs-slider4-img11.png" alt="مبنا">
                            </div>

                            <div class="tp-caption lfb"
                                data-x="225"
                                data-y="335"
                                data-speed="1000"
                                data-start="1880"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider4-img12.png" alt="شرکت نارم">
                            </div>

                            <div class="tp-caption lfb"
                                data-x="258"
                                data-y="341"
                                data-speed="1000"
                                data-start="1960"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider4-img13.png" alt="رایان مبنا">
                            </div>

                            <div class="tp-caption lfb"
                                data-x="395"
                                data-y="335"
                                data-speed="1000"
                                data-start="2040"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider4-img14.png" alt="نگار اعتبار">
                            </div>

                            <h2 class="tp-caption lft skewtotop title span6"
                                data-x="722"
                                data-y="101"
                                data-speed="1000"
                                data-start="1700"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn">
                                <strong style="margin-right: 65%; font-size: larger;">شرکت نارِم</strong>
                            </h2>

                            <div class="tp-caption lfr skewtoright description span6"
                                data-x="722"
                                data-y="189"
                                data-speed="1000"
                                data-start="1500"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn">
                                <p style="margin-right: 65%; font-size: larger;">
                                    <br />
                                    Narem Software Development and Accounting Company
                                </p>
                            </div>

                            <a href="https://narem.ir/about-en" class="btn cherry tp-caption lfb"
                                data-x="722"
                                data-y="332"
                                data-speed="1000"
                                data-start="1700"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn">درباره شرکت نارم
                            </a>
                        </div>

                        <img src="img/content/slider/rs-slider4-bg.jpg" alt="شرکت نارم" data-bgfit="cover" data-bgposition="center top" data-bgrepeat="no-repeat">
                    </li>

                    <li data-delay="7000" data-transition="fade" data-slotamount="7" data-masterspeed="2000">
                        <div class="elements">
                            <div class="tp-caption lfb skewtobottom"
                                data-x="145"
                                data-y="66"
                                data-speed="1000"
                                data-start="500"
                                data-easing="Power4.easeOut"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn"
                                style="z-index: 3">
                                <img src="img/content/slider/rs-slider1-phone.png" alt="نگار">
                            </div>

                            <div class="tp-caption lfb skewtobottom"
                                data-x="307"
                                data-y="105"
                                data-speed="1000"
                                data-start="500"
                                data-easing="Power4.easeOut"
                                data-endspeed="400"
                                data-endeasing="Power1.easeIn"
                                style="z-index: 1">
                                <img src="img/content/slider/rs-slider1-phone-bg.png" alt="اعتبار رایان">
                            </div>

                            <h2 class="tp-caption sft skewtotop title span6"
                                data-x="590"
                                data-y="101"
                                data-speed="1000"
                                data-start="500"
                                data-easing="Power4.easeOut"
                                data-endspeed="400"
                                data-endeasing="Power1.easeIn"><strong style="margin-right: 54%;">توسعه وب اپلیکیشن</strong>
                            </h2>

                            <div class="tp-caption lfr skewtoright description span6"
                                data-x="590"
                                data-y="189"
                                data-speed="1000"
                                data-start="1000"
                                data-easing="Power4.easeOut"
                                data-endspeed="400"
                                data-endeasing="Power1.easeIn">

                                <p style="margin-right: 54%;">
                                    با بکارگیری فناوری‌های روز جهان<br>
                                </p>
                            </div>

                            <a href="https://www.narem.ir/page/Web-based-programming/en/6" class="btn tp-caption customin cherry"
                                data-x="590"
                                data-y="332"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1200"
                                data-start="1400"
                                data-easing="Power3.easeInOut"
                                data-endspeed="300"
                                style="z-index: 5">Web application programming
                            </a>

                            <div class="tp-caption customin customout"
                                data-x="337"
                                data-y="148"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:1;scaleY:1;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1200"
                                data-start="800"
                                data-easing="Power3.easeInOut"
                                data-endspeed="300"
                                style="z-index: 5">
                                <img src="img/content/slider/rs-slider1-html5-1.png" alt="نگار مبنا">
                            </div>

                            <div class="tp-caption customin"
                                data-x="355"
                                data-y="158"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1200"
                                data-start="1200"
                                data-easing="Power3.easeInOut"
                                data-end="3300"
                                data-endspeed="400"
                                style="z-index: 5">
                                <img src="img/content/slider/rs-slider1-html5-2.png" alt="narem software">
                            </div>

                            <div class="tp-caption customin"
                                data-x="355"
                                data-y="158"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1200"
                                data-start="3700"
                                data-easing="Power3.easeInOut"
                                data-endspeed="100"
                                style="z-index: 5">
                                <img src="img/content/slider/rs-slider1-css3.png" alt="web design">
                            </div>

                            <div class="tp-caption lfb skewtobottom customin customout phone-text"
                                data-x="359"
                                data-y="325"
                                data-customin="x:0;y:55;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:55;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:1;scaleY:1;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1000"
                                data-start="1000"
                                data-easing="Power0.easeOut"
                                data-end="3500"
                                data-endspeed="400"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 2; font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">
                                HTML5
                            </div>

                            <div class="tp-caption lfb skewtobottom customin customout phone-text"
                                data-x="365"
                                data-y="325"
                                data-customin="x:0;y:55;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:55;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:1;scaleY:1;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1000"
                                data-start="3600"
                                data-easing="Power0.easeOut"
                                data-endspeed="400"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 2; font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">
                                CSS3
                            </div>
                        </div>

                        <img src="img/content/slider/rs-slider1-bg.jpg" alt="services" data-bgfit="cover" data-bgposition="center top" data-bgrepeat="no-repeat">
                    </li>

                    <li data-delay="10300" data-transition="fade" data-slotamount="7" data-masterspeed="2000" class="slid2">
                        <div class="elements">
                            <h2 class="tp-caption sft skewtotop title span6"
                                data-x="0"
                                data-y="101"
                                data-speed="1000"
                                data-start="1100"
                                data-easing="Power4.easeOut"
                                data-endspeed="400"
                                data-endeasing="Power1.easeIn"><strong style="margin-right: 55%;">Artificial intelligence services</strong>
                            </h2>

                            <div class="tp-caption lfl skewtoleft description span6"
                                data-x="0"
                                data-y="189"
                                data-speed="1000"
                                data-start="1000"
                                data-easing="Power4.easeOut"
                                data-endspeed="400"
                                data-endeasing="Power1.easeIn">
                                <p style="margin-right: 55%;">
                                    Implementation and implementation of artificial intelligence research projects
                                </p>
                            </div>

                            <a href="https://narem.ir/page/Implementation-and-research-projects/en/12" class="btn btn-primary tp-caption customin"
                                data-x="0"
                                data-y="332"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1200"
                                data-start="1000"
                                data-easing="Power3.easeInOut"
                                data-endspeed="300"
                                style="z-index: 5">Artificial intelligence services
                            </a>

                            <div class="tp-caption lfb skewtobottom customin"
                                data-x="right"
                                data-hoffset="100"
                                data-y="70"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:-360;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1000"
                                data-start="1000"
                                data-easing="Power4.easeOut"
                                data-end="14000"
                                data-endspeed="500"
                                data-endeasing="Power1.easeIn"
                                style="z-index: 3">
                                <img src="img/content/slider/rs-slider2-img.png" alt="financial and accounting">
                            </div>

                            <div class="tp-caption lfb customout"
                                data-x="right"
                                data-hoffset="-126"
                                data-y="70"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="400"
                                data-start="2000"
                                data-easing="Power0.easeOut"
                                data-end="3000"
                                data-endspeed="400"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 2">
                                <img src="img/content/slider/rs-slider2-homepage1.png" alt="software">
                            </div>

                            <div class="tp-caption lfb customout"
                                data-x="right"
                                data-hoffset="-126"
                                data-y="70"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="400"
                                data-start="3500"
                                data-easing="Power0.easeOut"
                                data-end="4500"
                                data-endspeed="400"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 2">
                                <img src="img/content/slider/rs-slider2-homepage2.png" alt="Artificial intelligence">
                            </div>

                            <div class="tp-caption lfb customout"
                                data-x="right"
                                data-hoffset="-126"
                                data-y="70"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="400"
                                data-start="5000"
                                data-easing="Power0.easeOut"
                                data-end="6000"
                                data-endspeed="400"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 2">
                                <img src="img/content/slider/rs-slider2-homepage3.png" alt="Engineering">
                            </div>

                            <div class="tp-caption lfb customout"
                                data-x="right"
                                data-hoffset="-126"
                                data-y="70"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="400"
                                data-start="6500"
                                data-easing="Power0.easeOut"
                                data-end="7500"
                                data-endspeed="400"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 2">
                                <img src="img/content/slider/rs-slider2-homepage4.png" alt="website">
                            </div>

                            <div class="tp-caption  customout"
                                data-x="right"
                                data-hoffset="-208"
                                data-y="130"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:1;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1"
                                data-start="2300"
                                data-easing="Power0.easeOut"
                                data-end="3800"
                                data-endspeed="1"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider2-one.png" alt="Programming">
                            </div>

                            <div class="tp-caption customin customout"
                                data-x="right"
                                data-hoffset="-208"
                                data-y="130"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:1;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1"
                                data-start="3800"
                                data-easing="Power0.easeOut"
                                data-end="5300"
                                data-endspeed="1"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider2-two.png" alt="Computer services">
                            </div>

                            <div class="tp-caption customin customout"
                                data-x="right"
                                data-hoffset="-208"
                                data-y="130"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:1;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1"
                                data-start="5300"
                                data-easing="Power0.easeOut"
                                data-end="6800"
                                data-endspeed="1"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider2-three.png" alt="Accounting services">
                            </div>

                            <div class="tp-caption customin customout"
                                data-x="right"
                                data-hoffset="-208"
                                data-y="130"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:1;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1"
                                data-start="6800"
                                data-easing="Power0.easeOut"
                                data-end="8000"
                                data-endspeed="1"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider2-four.png" alt="Audit">
                            </div>

                            <div class="tp-caption customin customout"
                                data-x="right"
                                data-hoffset="-208"
                                data-y="130"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:1;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1"
                                data-start="8200"
                                data-easing="Power0.easeOut"
                                data-end="8300"
                                data-endspeed="1"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider2-four.png" alt="software engineering">
                            </div>

                            <div class="tp-caption customin customout"
                                data-x="right"
                                data-hoffset="-208"
                                data-y="130"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:1;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1"
                                data-start="8400"
                                data-easing="Power0.easeOut"
                                data-end="8500"
                                data-endspeed="1"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider2-four.png" alt="Computer">
                            </div>

                            <div class="tp-caption customin customout"
                                data-x="right"
                                data-hoffset="-208"
                                data-y="130"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:1;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1"
                                data-start="8600"
                                data-easing="Power0.easeOut"
                                data-end="8700"
                                data-endspeed="1"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider2-four.png" alt="Artificial Intelligence Engineering">
                            </div>

                            <div class="tp-caption customin customout"
                                data-x="right"
                                data-hoffset="-208"
                                data-y="130"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:1;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1"
                                data-start="8800"
                                data-easing="Power0.easeOut"
                                data-end="8900"
                                data-endspeed="1"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider2-four.png" alt="Optimization">
                            </div>

                            <div class="tp-caption customin customout"
                                data-x="right"
                                data-hoffset="-239"
                                data-y="187"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:1;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1"
                                data-start="9000"
                                data-easing="Power0.easeOut"
                                data-end="10300"
                                data-endspeed="1"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider2-quadrate1.png" alt="Development">
                            </div>

                            <div class="tp-caption customin customout"
                                data-x="right"
                                data-hoffset="-224"
                                data-y="172"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:1;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1"
                                data-start="9100"
                                data-easing="Power0.easeOut"
                                data-end="10200"
                                data-endspeed="1"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider2-quadrate2.png" alt="Eliminate your restrictions">
                            </div>

                            <div class="tp-caption customin customout"
                                data-x="right"
                                data-hoffset="-209"
                                data-y="157"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:1;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1"
                                data-start="9200"
                                data-easing="Power0.easeOut"
                                data-end="10100"
                                data-endspeed="1"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider2-quadrate3.png" alt="Push your limits">
                            </div>

                            <div class="tp-caption customin customout"
                                data-x="right"
                                data-hoffset="-194"
                                data-y="142"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:1;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1"
                                data-start="9300"
                                data-easing="Power0.easeOut"
                                data-end="10000"
                                data-endspeed="1"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider2-quadrate4.png" alt="narem dot ir">
                            </div>

                            <div class="tp-caption customin customout"
                                data-x="right"
                                data-hoffset="-179"
                                data-y="127"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:1;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1"
                                data-start="9400"
                                data-easing="Power0.easeOut"
                                data-end="9900"
                                data-endspeed="1"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider2-quadrate5.png" alt="Cute sparrow narem">
                            </div>

                            <div class="tp-caption customin customout"
                                data-x="right"
                                data-hoffset="-164"
                                data-y="112"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:1;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1"
                                data-start="9500"
                                data-easing="Power0.easeOut"
                                data-end="9800"
                                data-endspeed="1"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider2-quadrate6.png" alt="narem brand">
                            </div>

                            <div class="tp-caption customin customout"
                                data-x="right"
                                data-hoffset="-149"
                                data-y="97"
                                data-customin="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:1;transformPerspective:600;transformOrigin:50% 50%;"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1"
                                data-start="9600"
                                data-easing="Power0.easeOut"
                                data-end="9700"
                                data-endspeed="1"
                                data-endeasing="Power0.easeIn"
                                data-captionhidden="on"
                                style="z-index: 4">
                                <img src="img/content/slider/rs-slider2-quadrate7.png" alt="host">
                            </div>
                        </div>

                        <img src="img/content/slider/rs-slider2-bg.jpg" alt="Negar Etebar Rayan Mabna - Private Held Co. - NAREM" data-bgfit="cover" data-bgposition="center top" data-bgrepeat="no-repeat">
                    </li>

                    <li data-delay="8000" data-transition="fade" data-slotamount="7" data-masterspeed="2000">
                        <div class="elements">
                            <div class="tp-caption lfl skewtoleft"
                                data-x="left"
                                data-hoffset="-127"
                                data-y="bottom"
                                data-speed="1500"
                                data-start="1000"
                                data-easing="Power4.easeOut"
                                data-endspeed="1000"
                                data-endeasing="Power1.easeIn"
                                style="z-index: 1">
                                <img src="img/content/slider/rs-slider3-pig.png" alt="Website Hosting">
                            </div>

                            <div class="tp-caption lfl skewtoleft"
                                data-x="left"
                                data-hoffset="-127"
                                data-y="bottom"
                                data-speed="1500"
                                data-start="1000"
                                data-easing="Power4.easeOut"
                                data-endspeed="1000"
                                data-endeasing="Power1.easeIn"
                                style="z-index: 3">
                                <img src="img/content/slider/rs-slider3-pig2.png" alt="FTP">
                            </div>

                            <h2 class="tp-caption lft skewtotop title span3"
                                data-x="509"
                                data-y="122"
                                data-speed="1500"
                                data-start="1000"
                                data-easing="Power0.easeOut"
                                data-endspeed="1000"
                                data-endeasing="Power1.easeIn">
                                <strong style="margin-right: 94%; font-size: 45px;">💸</strong>
                            </h2>

                            <h2 class="tp-caption lfr skewtoright title span3"
                                data-x="755"
                                data-y="122"
                                data-speed="1500"
                                data-start="1000"
                                data-easing="Power4.easeOut"
                                data-endspeed="1000"
                                data-endeasing="Power1.easeIn"><strong style="margin-right: 70%;">Financial and accounting services</strong>
                            </h2>

                            <div class="tp-caption customin customout description span6"
                                data-x="509"
                                data-y="196"
                                data-customin="x:0;y:0;z:50;rotationX:90;rotationY:0;rotationZ:0;scaleX:1;scaleY:1;skewX:0;skewY:0;opacity:0;transformPerspective:200;transformOrigin:50% 0;"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="1000"
                                data-start="1500"
                                data-easing="Back.easeInOut"
                                data-endspeed="400"
                                data-endeasing="Power1.easeIn">
                                <p style="margin-right: 45%;">
                                    Our customers are business owners.<br>
                                    We help your business see more<br>
                                    We provide tools to help you better communicate with your customers<br>
                                    Increasing the quality of your business is our specialty.
                                </p>
                            </div>

                            <a href="https://narem.ir/page/Tax-returns/en/16" class="tp-caption btn orang lfb skewtobottom"
                                data-x="509"
                                data-y="338"
                                data-speed="1000"
                                data-start="1500"
                                data-easing="Power3.easeInOut"
                                data-endspeed="300">Tax returns
                            </a>

                            <div class="tp-caption lft customout"
                                data-x="130"
                                data-y="140"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="500"
                                data-start="2200"
                                data-easing="Power4.easeOut"
                                data-end="2400"
                                data-endspeed="100"
                                data-endeasing="Power1.easeIn"
                                style="z-index: 2">
                                <img src="img/content/slider/rs-slider3-coin.png" alt="Accounting system">
                            </div>

                            <div class="tp-caption lft customout"
                                data-x="130"
                                data-y="30"
                                data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;"
                                data-speed="500"
                                data-start="2700"
                                data-easing="Power4.easeOut"
                                data-endeasing="Power1.easeIn"
                                style="z-index: 2">
                                <img src="img/content/slider/rs-slider3-coin.png" alt="Audit">
                            </div>
                        </div>

                        <img src="img/content/slider/rs-slider3-bg.jpg" alt="financial department" data-bgfit="cover" data-bgposition="center top" data-bgrepeat="no-repeat">
                    </li>
                </ul>
                <div class="tp-bannertimer"></div>
            </div>
        </div>
    </div>
    <!-- .rs-slider -->
    <asp:Literal runat="server" ID="ltrBanners" />

    <!-- .banner-set -->
    <br />
    <p style="text-align: center;"><a class="btn btn-inverse" href="/portfolios">Portfolios</a></p>


    <div class="clearfix"></div>

    <section id="main">
        <div class="container">
            <article class="content">
                <!-- .full-width-box -->

                <div class="row services">
                    <div class="span12 title-box">
                        <h1 class="title">Some services of Narm Company</h1>
                    </div>

                    <div class="span4 big-services-box">
                        <div>
                            <div class="big-icon bg" data-appear-animation="wobble"><i class="fa fa-desktop"></i></div>
                            <h4 class="title" data-appear-animation="bounceInLeft">Design and development of web-based software systems</h4>
                            <div class="text-small" data-appear-animation="bounceInLeft">
                                Development of computer software systems by applying software development process standards (Software Development Process) which includes requirements engineering, analysis, design, implementation, testing and ultimately lead to product output.
                                        <div class="clearfix"></div>
                                <br>
                                <a class="btn  highslide" style="color: white;" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html1' } )">Read more</a>
                                <div class="highslide-html-content" id="highslide-html1" style="max-width: 99%;">
                                    <div class="highslide-header highslide-move">
                                        <ul>
                                            <li style="font-family: 'B Yekan';">
                                                <b style="padding: 4px  7px 4px 7px;">Design and development of web-based software systems</b><i style="color: #7baa00;" class="fa fa-desktop"></i>
                                            </li>
                                            <li class="highslide-close">
                                                <a href="#" style="float: left; cursor: pointer; text-decoration: none; font-family: Arial; padding: 4px 7px 4px 7px;" onclick="return hs.close(this)">X</a>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="highslide-body" style="text-align: right; direction: ltr;">
                                        <p style="text-align: justify;">Development of computer software systems by applying software development process standards (Software Development Process) which includes requirements engineering, analysis, design, implementation, testing and ultimately lead to product output.</p>
                                    </div>
                                    <div class="highslide-footer">
                                        <div>
                                            <span class="highslide-resize" title="Resize">
                                                <span></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- .services-box-two -->

                    <div class="span4 big-services-box">
                        <div>
                            <div class="big-icon bg" data-appear-animation="wobble"><i class="fa fa-magic"></i></div>
                            <h4 class="title" data-appear-animation="bounceInUp">Executor of informatics and artificial intelligence research projects</h4>
                            <div class="text-small" data-appear-animation="bounceInUp">
                                Supervising the implementation of informatics and artificial intelligence projects, production and support of customer order software, providing and supporting in-house software software packages and information CDs, information network services, and providing computer programming services.
                                        <div class="clearfix"></div>
                                <br>
                                <a class="btn  highslide" style="color: white;" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html2' } )">Read more</a>
                                <div class="highslide-html-content" id="highslide-html2" style="max-width: 99%;">
                                    <div class="highslide-header highslide-move">
                                        <ul>
                                            <li style="font-family: 'B Yekan';">
                                                <b style="padding: 4px  7px 4px 7px;">Executor of informatics and artificial intelligence research projects</b><i style="color: #7baa00;" class="fa fa-magic"></i>
                                            </li>
                                            <li class="highslide-close">
                                                <a href="#" style="float: left; cursor: pointer; text-decoration: none; font-family: Arial; padding: 4px 7px 4px 7px;" onclick="return hs.close(this)">X</a>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="highslide-body" style="text-align: right; direction: ltr;">
                                        <p style="text-align: justify;">Supervising the implementation of informatics and artificial intelligence projects, production and support of customer order software, providing and supporting in-house software software packages and information CDs, information network services, and providing computer programming services.</p>
                                    </div>
                                    <div class="highslide-footer">
                                        <div>
                                            <span class="highslide-resize" title="Resize">
                                                <span></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- .services-box-two -->

                    <div class="span4 big-services-box">
                        <div>
                            <div class="big-icon bg" data-appear-animation="wobble"><i class="fa fa-dollar"></i></div>
                            <h4 class="title" data-appear-animation="bounceInRight">Providing financial and accounting services to companies and organizations</h4>
                            <div class="text-small" data-appear-animation="bounceInRight">Writing legal offices, preparing financial statements, preparing tax returns and accounting of companies are also among the activities of the company.
                                        <div class="clearfix"></div>
                                <br>
                                <a class="btn  highslide" style="color: white;" onclick="return hs.htmlExpand(this, { contentId: 'highslide-html3' } )">Read more</a>
                                <div class="highslide-html-content" id="highslide-html3" style="max-width: 99%;">
                                    <div class="highslide-header highslide-move">
                                        <ul>
                                            <li style="font-family: 'B Yekan';">
                                                <b style="padding: 4px  7px 4px 7px;">Providing financial and accounting services to companies and organizations</b><i style="color: #7baa00;" class="fa fa-dollar"></i>
                                            </li>
                                            <li class="highslide-close">
                                                <a href="#" style="float: left; cursor: pointer; text-decoration: none; font-family: Arial; padding: 4px 7px 4px 7px;" onclick="return hs.close(this)">X</a>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="highslide-body" style="text-align: right; direction: ltr;">
                                        <p style="text-align: justify;">Writing legal offices, preparing financial statements, preparing tax returns and accounting of companies are also among the activities of the company.</p>
                                    </div>
                                    <div class="highslide-footer">
                                        <div>
                                            <span class="highslide-resize" title="Resize">
                                                <span></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- .services-box-two -->
                </div>
                <br>
                <br>
                <!-- .full-width-box -->

                <div class="row">
                    <div class="bottom-padding span6">
                        <asp:Literal runat="server" ID="ltrNews" />
                    </div>

                    <div class="span6 bottom-padding">
                        <div class="title-box">
                            <h2 class="title">Frequently Asked Questions</h2>
                            <a href="/faq/all/" class="btn btn-inverse" style="text-align: left;">Archive of FAQ <i class="icon-arrow-right icon-white"></i></a>
                        </div>
                        <asp:Literal runat="server" ID="ltrFAQ" Text="" />

                    </div>
                </div>

                <div class="full-width-box bottom-padding">
                    <div class="bg fixed bg-image band-11">
                        <div class="overlay"></div>
                    </div>
                    <div class="title-box title-white">
                        <h1 class="title">Board of Directors</h1>
                    </div>

                    <div class="row team-box">
                        <asp:Literal runat="server" ID="ltrAdminMember" />
                    </div>
                    <div class="clearfix"></div>
                </div>
                <!-- .full-width-box -->

                <div class="row bottom-padding last">
                    <div class="promo-partners span6 bottom-padding-mobile">
                        <div class="title-box">
                            <h2 class="title">Special offer</h2>
                        </div>
                        <div class="row manufactures">
                            <div class="span2">
                                <a href="#" class="make">
                                    <img src="img/content/make-1.png" width="128" height="128" alt="Collaboration brand">
                                </a>
                            </div>
                            <div class="span2">
                                <a href="#" class="make">
                                    <img src="img/content/make-2.png" width="128" height="128" alt="Narem's suggestion">
                                </a>
                            </div>
                            <div class="span2">
                                <a href="#" class="make">
                                    <img src="img/content/make-3.png" width="128" height="128" alt="Be with Narem">
                                </a>
                            </div>
                        </div>
                        <p style="text-align: justify;">Negar Etebar Ryan Mabna Co. (Private Held Company) offers special packages and offers to improve the sales quality of your business products and services under the brand name of Narem.</p>
                        <ul>
                            <li>
                                <p style="text-align: justify;">Introduce your business card to the world right now so that you can make the business card market bigger and bigger. Narem does this job easily and in the shortest time, with excellent quality. Right now <a href="../order" style="color:rgb(0 159 214 / 86%);"><b>Order form</b></a> Complete.</p>
                            </li>
                            <li>
                                <p style="text-align: justify;">Support for websites created by this company will include troubleshooting and improving performance, development, CEO and production of content relevant to your business.</p>
                            </li>
                        </ul>
                    </div>
                    <!-- .promo-partners -->

                    <div class="span6">
                        <div class="title-box">
                            <a href="/posts/all/" class="btn btn-inverse" style="text-align: left;">Posts Archive<i class="icon-arrow-right icon-white"></i></a>
                            <h2 class="title">Latest submissions</h2>
                        </div>
                        <ul class="latest-posts">
                            <asp:Literal runat="server" ID="ltrLastPost" />
                        </ul>
                    </div>
                </div>
            </article>

        </div>
    </section>
    <!-- #main -->
</asp:Content>








