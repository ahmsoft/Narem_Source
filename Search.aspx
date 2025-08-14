<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Search.aspx.vb" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
        <asp:Literal runat="server" ID="litMeta" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section">
        <div class="container">
            <div class="" style="text-align:right;direction:rtl;">
                <br />
                <h2 class="title">نتایج جستجو <asp:Label runat="server" ID="lblSearchCount" style="color:#5cb85c;" /> مورد</h2>
                <asp:PlaceHolder ID="PostsPlaceHolder" runat="server"></asp:PlaceHolder>
                <asp:PlaceHolder ID="FAQPlaceHolder" runat="server"></asp:PlaceHolder>
                <asp:PlaceHolder ID="PagesPlaceHolder" runat="server"></asp:PlaceHolder>
                <asp:PlaceHolder ID="GalleryPlaceHolder" runat="server"></asp:PlaceHolder>
            </div>
        </div>
        <hr />

    </div>
</asp:Content>

