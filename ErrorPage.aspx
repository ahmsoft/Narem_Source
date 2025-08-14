<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ErrorPage.aspx.vb" Inherits="ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal runat="server" ID="litMeta" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div  style="text-align: center;">
        <img src="img/Under-construction.png" />
        <span style="font-size:100px;font-weight:bolder;margin:50px;">خطای 404</span>
    </div>
</asp:Content>

