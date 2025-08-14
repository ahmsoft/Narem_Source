<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Posts.aspx.vb" Inherits="Posts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal runat="server" ID="litMeta" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumb-box">
        <div class="container">
            <ul class="breadcrumb">
                <li><a href="/index">صفحه اصلی</a> <span class="divider">/</span></li>
                <li><a runat="server" id="lblRootPageHref" href="/posts/all/">آرشیو مطالب سایت</a> <span class="divider">/</span></li>
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
            <h1 class="title">مطالب ارسال شده</h1>
        </div>
    </header>
    <div class="container">
        <div class="row">
            <div class="content blog span9">
                <asp:SqlDataSource ID="SqlDataSourcePosts" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT * INTO B1 FROM Comments WHERE Action='Posts' AND IsShow=1 AND Active=1; SELECT * INTO M1 FROM Message WHERE CatName_En LIKE '%' +REPLACE(REPLACE(@CatName, '-', ' '),';',' ') + '%'; SELECT COUNT(B1.IDC) AS CommentsCount, M1.IDMessage, M1.Title_Fa, M1.Title_En, M1.PreMessage_Fa, M1.PreMessage_En, M1.Image, M1.WrittenBy_Fa, M1.WrittenBy_En, M1.Moment_Fa, M1.Moment_En, M1.Year_En, M1.Month_En, M1.Day_En, M1.Keyword_Fa, M1.Keyword_En FROM M1 FULL OUTER JOIN B1 ON B1.IDElement = M1.IDMessage Where M1.IDMessage is not null GROUP BY M1.IDMessage, M1.Title_Fa, M1.Title_En, M1.PreMessage_Fa, M1.PreMessage_En, M1.Image, M1.WrittenBy_Fa, M1.WrittenBy_En, M1.Moment_Fa, M1.Moment_En, M1.Year_En, M1.Month_En, M1.Day_En, M1.Keyword_Fa, M1.Keyword_En ORDER BY M1.Year_En DESC, M1.Month_En DESC, M1.Day_En DESC; DROP TABLE B1; DROP TABLE M1;">
                    <SelectParameters>
                        <asp:RouteParameter Name="CatName" DefaultValue="all" RouteKey="CatName" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <asp:ListView ID="ListViewPost" runat="server" DataSourceID="sqlDataSourcePosts" DataKeyNames="IDMessage">
                    <EditItemTemplate>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <span style="text-align: right; direction: rtl; float: right;">درحال حاضر پیامی توسط مدیر ثبت نشده.</span>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <article class="post">
                            <h2 class="entry-title"><a href="<%# Eval("Title_En").ToString.Replace(" ", "-").ToLower() %>/<%# Eval("IDMessage").ToString()%>"><%# Eval("Title_Fa")%></a></h2>
                            <div class="entry-content">
                                <img alt='<%# Eval("Title_Fa")%>' src='<%# Eval("Image")%>' style='margin: 10px; padding: 5px; width: 100px; float: Left; height: 100px;border-radius:15px;' class='img-responsive' />
                                <%# Eval("PreMessage_Fa")%>
                            </div>
                            <footer class="entry-meta">
                                <span class="autor-name">  نویسنده <%# Eval("WrittenBy_Fa")%></span> |
			<span class="time"><%#  Eval("Moment_Fa").ToString.Remove(Eval("Moment_Fa").ToString.Length - 8, 8)%></span>
                                <span class="separator"></span>
                                <%--                                <span class="meta">Posted in <a href="#">Sports</a> | <a href="#">Movies</a></span>--%>
                                <span class="comments-link pull-right">
                                    <a href="<%# Eval("Title_En").ToString.Replace(" ", "-").ToLower() %>/<%# Eval("IDMessage")%>">بازخورد <%# Eval("CommentsCount") %> </a>
                                </span>
                                <a class="btn btn-info" style="float: left;" href="<%# Eval("Title_En").ToString.Replace(" ", "-").ToLower() %>/<%# Eval("IDMessage").ToString()%>">ادامه مطلب</a>
                            </footer>
                        </article>
                        <!-- end .blog-post-content -->
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <article class="post">
                            <h2 class="entry-title"><a href="<%# Eval("Title_En").ToString.Replace(" ", "-").ToLower() %>/<%# Eval("IDMessage").ToString()%>"><%# Eval("Title_Fa")%></a></h2>
                            <div class="entry-content">
                                <img alt='<%# Eval("Title_Fa")%>' src='<%# Eval("Image")%>' style='margin: 10px; padding: 5px; width: 100px; float: Left; height: 100px;border-radius:15px;' class='img-responsive' />
                                <%# Eval("PreMessage_Fa")%>
                            </div>
                            <footer class="entry-meta">
                                <span class="autor-name">  نویسنده <%# Eval("WrittenBy_Fa")%></span> |
			<span class="time"><%#  Eval("Moment_Fa").ToString.Remove(Eval("Moment_Fa").ToString.Length - 8, 8)%></span>
                                <span class="separator"></span>
                                <%--                                <span class="meta">Posted in <a href="#">Sports</a> | <a href="#">Movies</a></span>--%>
                                <span class="comments-link pull-right">
                                    <a href="<%# Eval("Title_En").ToString.Replace(" ", "-").ToLower() %>/<%# Eval("IDMessage")%>">بازخورد <%# Eval("CommentsCount") %> </a>
                                </span>
                                <a class="btn btn-info" style="float: left;" href="<%# Eval("Title_En").ToString.Replace(" ", "-").ToLower() %>/<%# Eval("IDMessage").ToString()%>">ادامه مطلب</a>
                            </footer>
                        </article>
                    </AlternatingItemTemplate>

                    <LayoutTemplate>
                        <div id="itemPlaceholderContainer" runat="server" style="">
                            <span runat="server" id="itemPlaceholder" />
                        </div>

                    </LayoutTemplate>
                    <SelectedItemTemplate>
                    </SelectedItemTemplate>
                </asp:ListView>
                <hr class="shadow">
                <div class="pagenavi" style="margin-bottom: 10px;">
                    <asp:DataPager ID="DataPager" runat="server" PagedControlID="ListViewPost" QueryStringField="PageID" PageSize="4">
                        <Fields>
                            <asp:NumericPagerField PreviousPageText="👈" CurrentPageLabelCssClass="current" ButtonCount="8" NextPageText="👉"   />
                        </Fields>
                    </asp:DataPager>
                </div>
                <!-- .pagination -->
                <hr class="shadow" style="width: 100px; margin: auto;">
                <br />
            </div>
            <!-- .content -->

            <div id="sidebar" class="sidebar span3">
                <asp:PlaceHolder runat="server" ID="PlaceHolderBlock"></asp:PlaceHolder>
            </div>
            <!-- .sidebar -->
        </div>
    </div>
    <!-- .container -->
</asp:Content>

