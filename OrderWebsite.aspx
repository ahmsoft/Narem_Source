<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="OrderWebsite.aspx.vb" Inherits="OrderWebsite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal runat="server" ID="litMeta" />
    <style>
        @media (max-width: 1382px) {
            #OrderForm {
                width: 100%;
                height: 1350px;
            }
        }

        @media (max-width: 1119px) {
            #OrderForm {
                width: 100%;
                height: 1360px;
            }
        }

        @media (max-width: 1034px) {
            #OrderForm {
                width: 100%;
                height: 2200px;
            }
        }

        @media (max-width: 1050px) {
            #OrderForm {
                width: 100%;
                height: 1360px;
            }
        }

        @media (max-width: 1017px) {
            #OrderForm {
                width: 100%;
                height: 2200px;
            }
        }

        @media (max-width: 802px) {
            #OrderForm {
                width: 100%;
                height: 2210px;
            }
        }

        @media (max-width: 582px) {
            #OrderForm {
                width: 100%;
                height: 2230px;
            }
        }

        @media (max-width: 523px) {
            #OrderForm {
                width: 100%;
                height: 2250px;
            }
        }
        @media (max-width: 414px) {
            #OrderForm {
                width: 100%;
                height: 2340px;
            }
        }
        @media (max-width: 411px) {
            #OrderForm {
                width: 100%;
                height: 2350px;
            }
        }
        @media (max-width: 375px) {
            #OrderForm {
                width: 100%;
                height: 2390px;
            }
        }
        @media (max-width: 360px) {
            #OrderForm {
                width: 100%;
                height: 2390px;
            }
        }
        @media (max-width: 320px) {
            #OrderForm {
                width: 100%;
                height: 2490px;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
         <!---begin Crisp code--->
    <script type="text/javascript">
        window.$crisp = [];
        window.CRISP_WEBSITE_ID = "55e2eb86-5fb2-47b6-84bb-ddce6f1188a6"; (function () { d = document; s = d.createElement("script"); s.src = "https://client.crisp.chat/l.js"; s.async = 1; d.getElementsByTagName("head")[0].appendChild(s); })();
    </script>
    <!---end Crisp code--->
    <iframe id="OrderForm" src="https://narem.ir/OrderSite.aspx" style="border: none;" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture;" title="description"></iframe>

    <script>
        function setIframeHeight(iframe) {
            if (iframe) {
                var iframeWin = iframe.contentWindow || iframe.contentDocument.parentWindow;
                if (iframeWin.document.body) {
                    iframe.height = iframeWin.document.documentElement.scrollHeight || iframeWin.document.body.scrollHeight;
                }
            }
        };
    </script>
</asp:Content>

