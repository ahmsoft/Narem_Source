<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FAQ.aspx.vb" Inherits="FAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Literal runat="server" ID="litMeta" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumb-box">
        <div class="container">
            <ul class="breadcrumb">
                <li><a href="/index">صفحه اصلی</a> <span class="divider">/</span></li>
                <li><a runat="server" id="lblRootPageHref" href="/faq/all/">پرسش‌های متداول</a> <span class="divider">/</span></li>
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
            <h1 class="title">پرسش و پاسخ ارسال شده</h1>
        </div>
    </header>
    <div class="container">
        <div class="row">
            <div class="content blog span9">
                <%--<asp:LinqDataSource ID="DataSourceFAQ" runat="server" ContextTypeName="LinqDBClassesDataContext" EntityTypeName="" OrderBy="Year_En Descending, Month_En Descending, Day_En Descending, IDF Descending" TableName="FAQms" Where="IsShow == True AND CatName_Fa.contains(@CatName)">
                    <WhereParameters>
                                                <asp:QueryStringParameter DefaultValue="True" Name="All" QueryStringField="All" Type="Boolean" />
                                                <asp:QueryStringParameter  Name="IDCat" DefaultValue="99999999" QueryStringField="IDCat" Type="Int32" />
                        <asp:RouteParameter Name="CatName" DefaultValue="همه" RouteKey="CatName" Type="String" />
                    </WhereParameters>
                </asp:LinqDataSource>--%>
                <asp:SqlDataSource ID="DataSourceFAQ" runat="server" ConnectionString="<%$ ConnectionStrings:NaremDBConnectionString %>" SelectCommand="SELECT * INTO B1 FROM Comments WHERE Action='FAQ' AND IsShow=1 AND Active=1; SELECT * INTO M1 FROM FAQm WHERE CatName_En LIKE '%' + REPLACE(@CatName, '-', ' ') + '%'; SELECT COUNT(B1.IDC) AS CommentsCount, M1.IDF, M1.Question_Fa, M1.Question_En, M1.Answer_Fa, M1.Answer_En, M1.AskedBy_Fa, M1.AskedBy_En, M1.AnswerBy_Fa, M1.AnswerBy_En, M1.Moment_Fa, M1.Moment_En, M1.Year_En, M1.Month_En, M1.Day_En, M1.Keyword_Fa, M1.Keyword_En FROM M1 FULL OUTER JOIN B1 ON B1.IDElement = M1.IDF Where M1.IDF is not null GROUP BY M1.IDF, M1.Question_Fa, M1.Question_En, M1.Answer_Fa, M1.Answer_En, M1.AskedBy_Fa, M1.AskedBy_En, M1.AnswerBy_Fa, M1.AnswerBy_En, M1.Moment_Fa, M1.Moment_En, M1.Year_En, M1.Month_En, M1.Day_En, M1.Keyword_Fa, M1.Keyword_En ORDER BY M1.Year_En DESC, M1.Month_En DESC, M1.Day_En DESC; DROP TABLE B1; DROP TABLE M1;">
                    <SelectParameters>
                        <asp:RouteParameter Name="CatName" DefaultValue="all" RouteKey="CatName" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />

                <asp:ListView ID="ListViewFAQ" runat="server" DataSourceID="DataSourceFAQ" DataKeyNames="IDF">
                    <EditItemTemplate>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <span style="text-align: right; direction: rtl; float: right;">درحال حاضر پرسش و پاسخی توسط مدیر ثبت نشده.</span>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <article class="post">
                            <h2 class="entry-title"><a href="<%# Eval("Question_En").ToString.Replace(" ", "-").ToLower().Replace("?", "")%>/<%# Eval("IDF")%>"><%# Eval("Question_Fa")%></a></h2>
                            <div class="entry-content">
                                <%# Eval("Answer_Fa")%>
                            </div>
                            <footer class="entry-meta">
                                <span class="autor-name">پرسیده شده توسط  <%# Eval("AskedBy_Fa")%></span> |
                                  پاسخ داده شده توسط  <%# Eval("AnswerBy_Fa") %><span class="separator">| </span>
                                <span class="time"><%# Eval("Moment_Fa").ToString.Remove(Eval("Moment_Fa").ToString.Length - 8, 8)%></span>
                                <%--                                <span class="meta">Posted in <a href="#">Sports</a> | <a href="#">Movies</a></span>--%>
                                <span class="comments-link pull-right">
                                    <a href="<%# Eval("Question_En").ToString.Replace(" ", "-").ToLower().Replace("?", "") %>/<%# Eval("IDF")%>">دیدگاه <%# Eval("CommentsCount")%></a>
                                </span>
                                <a class="btn btn-info" style="float:left;" href="<%# Eval("Question_En").ToString.Replace(" ", "-").ToLower().Replace("?", "") %>/<%# Eval("IDF")%>">ثبت دیدگاه</a>
                            </footer>
                        </article>
                        <!-- end .blog-post-content -->
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <article class="post">
                            <h2 class="entry-title"><a href="<%# Eval("Question_En").ToString.Replace(" ", "-").ToLower().Replace("?", "") %>/<%# Eval("IDF")%>"><%# Eval("Question_Fa")%></a></h2>
                            <div class="entry-content">
                                <%# Eval("Answer_Fa")%>
                            </div>
                            <footer class="entry-meta">
                                <span class="autor-name">پرسیده شده توسط  <%# Eval("AskedBy_Fa")%></span> |
                                  پاسخ داده شده توسط  <%# Eval("AnswerBy_Fa") %><span class="separator">| </span>
                                <span class="time"><%# Eval("Moment_Fa").ToString.Remove(Eval("Moment_Fa").ToString.Length-8,8)%></span>
                                <%--                                <span class="meta">Posted in <a href="#">Sports</a> | <a href="#">Movies</a></span>--%>
                                <span class="comments-link pull-right">
                                    <a href="<%# Eval("Question_En").ToString.Replace(" ", "-").ToLower().Replace("?", "") %>/<%# Eval("IDF")%>">دیدگاه <%# Eval("CommentsCount")%></a>
                                </span>
                                <a class="btn btn-info" style="float:left;" href="<%# Eval("Question_En").ToString.Replace(" ", "-").ToLower().Replace("?", "") %>/<%# Eval("IDF")%>">ثبت دیدگاه</a>
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

                <div class="pagenavi" style="margin-bottom: 10px;">
                    <asp:DataPager ID="DataPager" runat="server" PagedControlID="ListViewFAQ" QueryStringField="PageID" PageSize="4">
                        <Fields>
                            <asp:NumericPagerField PreviousPageText="👈" CurrentPageLabelCssClass="current" ButtonCount="8" NextPageText="👉"   />
                        </Fields>
                    </asp:DataPager>
                </div>
                <!-- .pagination -->
                <hr class="shadow">
                                <aside class="list">
                    <header>
                        <h3>ارسال پرسش</h3>
                    </header>
                    <label for="txtNameFamili" id="lblName">نام و نام خانوادگی :</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNameAndFamily" runat="server" ErrorMessage="نام و نام خانوادگی وارد شود" ValidationGroup="FAQ" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtNameAndFamily" runat="server" ErrorMessage="فارسی و صحیح وارد شود" ValidationGroup="FAQ" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" CssClass="label-danger" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\s*[ابپتثجچحخدذرزژئسشصضطظعغفق  کگلمنوهیآیيك\s]+\s*$"></asp:RegularExpressionValidator>
                    <asp:TextBox runat="server" type="text" name="name" ID="txtNameAndFamily" value="" Style="height: 8px; width: 90%; padding: 10px;" class="text-input" />
                    <%--<label for="txtEmail" id="lblEmail" style="padding-top: 15px;">ایمیل :</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtMail" runat="server" ErrorMessage="ایمیل وارد شود" ValidationGroup="FAQ" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtMail" runat="server" ErrorMessage="ایمیل نادرست" ValidationGroup="FAQ" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[\w-\.]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]{2,6}$"></asp:RegularExpressionValidator>
                <asp:TextBox runat="server" type="email" name="email" class="text-input" ID="txtMail" size="50" value="" Style="height: 8px; width: 100%; padding: 10px;" />
                <label for="txtWebsite" id="lblWebsite" style="padding-top: 15px;">وب سایت :</label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtWSite" runat="server" ErrorMessage="آدرس وبسایت نادرست" ValidationGroup="FAQ" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" Display="Dynamic" SetFocusOnError="true" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                <asp:TextBox runat="server" type="text" name="website" ID="txtWSite" placeholder="http://www.narem.ir" value="" Style="height: 8px; width: 100%; padding: 10px;" class="text-input" />
                    --%><label for="txtQuestion" id="lblQuestion" style="padding-top: 15px;">پرسش :</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtQuestion" ErrorMessage="متن پرسش وارد شود" ValidationGroup="FAQ" Style="background-color: red; color: white; margin-bottom: auto; font-size: 14px; border-radius: 4px 4px 4px 4px; padding: 2px 2px 1px 1px;" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" name="msg" ID="txtQuestion" Style="width: 90%;" class="text-input" Rows="4" TextMode="MultiLine" />
                    <br />
                    <table style="border: hidden; border-radius: 8px;">
                        <tr>
                            <th>
                                <asp:Label runat="server" ID="lblSubmitStatusFAQ" Text="" />
                            </th>
                        </tr>
                        <tr>
                            <td style="background-color: rgba(0, 0, 0, 0); direction: ltr;">
                                <telerik:RadCaptcha ID="RadCaptcha" ValidationGroup="FAQ" CaptchaTextBoxLabel="" runat="server" CaptchaImage-BackgroundColor="White"></telerik:RadCaptcha>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: rgba(0, 0, 0, 0); border: hidden;">
                                <%--                                    <button type="button" style="width: 100%;" class="button solid-button purple aligncenter" data-toggle="modal" data-target="#FAQModal">ارسال پرسش</button>--%>
                                <asp:Button runat="server" Style="" ValidationGroup="FAQ" name="submit" class="btn btn-primary" ID="btnFAQSubmit" Text="ارسال پرسش" />

                            </td>
                        </tr>
                    </table>

                </aside>

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

