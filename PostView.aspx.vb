
Partial Class PostView
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim MetaIMG As String
        Dim MetaTitle As String
        Dim MetaDesc As String
        Dim MetaNameSite As String
        Dim MetaBrand As String
        Dim MetaUrl As String
        Dim MetaLocal As String
        Dim MetaAuthor As String
        Dim MetaType As String
        Dim MetaArticelSection As String
        'litMeta.Text = MetaIMG + MetaTitle + MetaDesc + MetaNameSite + MetaBrand + MetaUrl + MetaLocal + MetaAuthor + MetaArticelSection
        Try
            If (Page.RouteData.Values("Search") <> Nothing) Then
                If (Page.RouteData.Values("Search").ToString.Replace("-", " ") IsNot Nothing) Or (Page.RouteData.Values("Search").ToString.Replace("-", " ") <> "") Then
                    Response.Redirect("/result/" + Page.RouteData.Values("Search").ToString.Replace("-", " "))
                End If
            End If

        Catch ex As Exception

        End Try
        Dim Item = New Literal
        Dim ItemComment = New Literal
        Dim ltrMenu As Literal = Master.FindControl("ltrMasterMenu")
        Dim db = New LinqDBClassesDataContext
        Dim qryMenu = From m In db.Menus
                      Select m Order By
                                   m.IDM Descending Where m.IsShow = True
        Item.Text = "<ul class='nav'>"
        For Each q In qryMenu
            'Dim lblbr = New Label
            'lblbr.Text = "<p/>"

            If q.HasSub = False And q.IDSM = 0 And q.MegaMenu = False Then
                Item.Text += "<li><a href='" + q.Href.ToLower() + "'>" + q.Name_Fa + "</a></li>"
            ElseIf q.HasSub = True And q.IDSM = 0 And q.MegaMenu = False Then
                Item.Text += "<li class='parent'><a href='" + q.Href.ToLower() + "'>" + q.Name_Fa + "</a>"
                Item.Text += "<ul class='sub'>"
                Dim qrySubMenu = From m In db.Menus
                                 Select m Order By
                                              m.IDM Ascending Where m.IDSM = q.IDM And m.IsShow = True
                For Each p In qrySubMenu
                    'Item.Text += "<li><a href='" + p.Href + "'>" + p.NameFa + "</a></li>"
                    If p.HasSub = False And p.IDSM <> 0 And p.MegaMenu = False Then
                        Item.Text += "<li><a href='" + p.Href.ToLower() + "'>" + p.Name_Fa + "</a></li>"
                    ElseIf p.HasSub = True And p.IDSM <> 0 And p.MegaMenu = False Then
                        Item.Text += "<li class='parent'><a href='" + p.Href.ToLower() + "'>" + p.Name_Fa + "</a>"
                        Item.Text += "<ul class='sub'>"
                        Dim qrySub1Menu = From x In db.Menus
                                          Select x Order By
                                                       x.IDM Ascending Where x.IDSM = p.IDM And x.IsShow = True
                        For Each t In qrySub1Menu
                            If t.HasSub = False And t.IDSM <> 0 And t.MegaMenu = False Then
                                Item.Text += "<li><a href='" + t.Href.ToLower() + "'>" + t.Name_Fa + "</a></li>"
                            ElseIf t.HasSub = True And t.IDSM <> 0 And t.MegaMenu = False Then
                                Item.Text += "<li class='parent'><a href='" + t.Href.ToLower() + "'>" + t.Name_Fa + "</a>"
                                Item.Text += "<ul class='sub'>"
                                Dim qrySub2Menu = From y In db.Menus
                                                  Select y Order By
                                                               y.IDM Ascending Where y.IDSM = t.IDM And y.IsShow = True
                                For Each i In qrySub2Menu
                                    If i.HasSub = False And i.IDSM <> 0 And i.MegaMenu = False Then
                                        Item.Text += "<li><a href='" + i.Href.ToLower() + "'>" + i.Name_Fa + "</a></li>"
                                    ElseIf i.HasSub = True And i.IDSM <> 0 And i.MegaMenu = False Then
                                        Item.Text += "<li class='parent'><a href='" + i.Href.ToLower() + "'>" + i.Name_Fa + "</a>"
                                        Item.Text += "<ul class='sub'>"
                                        Dim qrySub3Menu = From z In db.Menus
                                                          Select z Order By
                                                                       z.IDM Ascending Where z.IDSM = i.IDM And z.IsShow = True
                                        For Each u In qrySub3Menu
                                            Item.Text += "<li><a href='" + t.Href.ToLower() + "'>" + t.Name_Fa + "</a></li>"
                                        Next
                                        Item.Text += "</ul></li>"
                                    End If
                                Next
                                Item.Text += "</ul></li>"
                            End If
                        Next
                        Item.Text += "</ul></li>"
                    End If
                Next
                Item.Text += "</ul></li>"
            ElseIf q.HasSub = True And q.IDSM = 0 And q.MegaMenu = True Then
                Dim qryMegaMenu = From m In db.MegaMenus
                                  Select m Order By
                                               m.IDMM Descending Where m.IDSM = q.IDM
                For Each k In qryMegaMenu
                    Item.Text += "<li class='parent megamenu'><a href='#'>" + q.Name_Fa + "</a><ul class='sub'><li class='promo-block box'><a href='" + k.Href.ToLower() + "' class='big-image'><img src='" + k.Image + "' width='240' height='434' alt='" + q.Alt_Fa + "'></a></li>"
                    Item.Text += k.Content_Fa
                Next
                Item.Text += "</ul></li>"
            End If
            'Page.MetaDescription = q.AboutSite
            'PlaceHolderMenu.Controls.Add(Item)
        Next
        Item.Text += "</ul>"
        ltrMenu.Text = Item.Text
        Item.Text = ""
        '''''''
        Dim ltrCat = New Literal
        Dim IAction As String
        Dim CAT = From m In db.Categories
                  Select m Order By m.Priority Ascending, m.IDCat Ascending

        ltrCat.Text = "<aside class='list'><header><h3>دسته‌بندی‌ها<h3></header><ul>"
        For Each b In CAT
            'ltrCat.ToolTip = b.CatName_Fa
            Try
                If Page.RouteData.Values("Action").ToString.Replace("-", " ") = "pages" Or Page.RouteData.Values("Action").ToString.Replace("-", " ") = "page" Then
                    IAction = "posts"
                Else
                    IAction = Page.RouteData.Values("Action").ToString.Replace("-", " ")
                End If
                If b.CatName_En.ToLower() = Page.RouteData.Values("CatName").ToString.Replace("-", " ") Then
                    ltrCat.Text += "<li><a style='color:White;background-color:#7baa00;padding-left:5px;padding-right:5px;border-radius:5px;font-size:15px;' href='../../../../" + IAction + "/" + b.CatName_En.ToString.Replace(" ", "-").ToLower() + "/' title='" + b.Description_Fa + "'>" + b.CatName_Fa + "</a></li>"
                Else

                    ltrCat.Text += "<li><a href='../../../../" + IAction + "/" + b.CatName_En.ToString.Replace(" ", "-").ToLower() + "/' title='" + b.Description_Fa + "'>" + b.CatName_Fa + "</a></li>"
                End If
            Catch ex As Exception
                ltrCat.Text += "<li><a href='../../../../" + IAction + "/" + b.CatName_En.ToString.Replace(" ", "-").ToLower() + "/' title='" + b.Description_Fa + "'>" + b.CatName_Fa + "</a></li>"
            End Try
        Next
        ltrCat.Text = ltrCat.Text + "</ul></aside>"
        PlaceHolderBlock.Controls.Add(ltrCat)

        Dim block = From m In db.Blocks
                    Select m Order By m.Priority Ascending, m.IDB Ascending
        Dim link = From n In db.Links
                   Select n Order By n.Priority Ascending, n.IDL Ascending

        For Each b In block
            Dim First As Boolean = True
            Dim lbl = New Label
            lbl.ToolTip = b.Name_Fa
            lbl.Text = "<aside class='list'>"
            lbl.Text += "<header><h3>" + b.Name_Fa + "<h3></header>"
            For Each l In link
                If l.IDB = b.IDB Then
                    If l.IsHTML Then
                        lbl.Text += l.BodyHTML_Fa
                    Else
                        If First Then
                            lbl.Text += "<ul>"
                            First = False
                        End If
                        lbl.Text += "<li><a href='" + l.Address_Fa.ToLower() + "' title='" + l.Alt_Fa + "' target='" + l.Target + "'>" + l.Name_Fa + "</a></li>"
                    End If
                End If
            Next
            lbl.Text = lbl.Text + "</ul></aside>"
            If b.Position = "Left" Then
                PlaceHolderBlock.Controls.Add(lbl)

            End If
        Next
        '''''''
        Try
            ItemComment.Text = "<ul class='commentlist'>"
            Dim CommentCount As Integer = 0
            Dim qryC = From m In db.Comments
                       Select m Order By
                                    m.IDElement Where (m.Active = True) And (m.IDElement = Page.RouteData.Values("ID").ToString) And (m.Parent = 0) And (m.Action.ToLower() = Page.RouteData.Values("Action").ToString.ToLower())
            For Each q In qryC
                If CommentCount = 0 Then
                    ItemComment.Text += "<hr class='shadow'><h3 class='title slim'> " + qryC.Count.ToString + " دیدگاه</h3>"
                    CommentCount += 1
                End If
                ItemComment.Text += "<li><img class='avatar' width='84' height='84' src='/img/avatar.png' alt='" + q.NameAndFamily_Fa + "'><div class='meta'><span>" + q.NameAndFamily_Fa + "</span>, <span class='time'>" + q.Moment_Fa.ToString.Remove(q.Moment_Fa.ToString.Length - 8, 8) + "</span></div><p class='description'>" + q.MSG_Fa + "</p></li>"
                Dim qrySubC = From s In db.Comments
                              Select s Order By
                                           s.IDC Where s.Parent = q.IDC And (s.IDElement = Page.RouteData.Values("ID").ToString) And s.Parent <> 0
                For Each subc In qrySubC
                    Dim imgAdmin As String = ""
                    Dim imgPhotoAdmin = From p In db.Users
                                        Select p Where (p.Name_Fa + " " + p.Family_Fa).ToString = subc.NameAndFamily_Fa
                    For Each h In imgPhotoAdmin
                        imgAdmin = h.PhotoMin.Remove(0, 2)
                        'MsgBox(imgAdmin)
                    Next
                    ItemComment.Text += "<li style='background-color:rgba(250,250,250,0.8);margin-right:30px;'><img class='avatar' width='84' height='84' src='" + imgAdmin + "' alt='" + subc.NameAndFamily_Fa + "'><div class='meta'><span>" + subc.NameAndFamily_Fa + "</span>, <span class='time'>" + subc.Moment_Fa.ToString.Remove(subc.Moment_Fa.ToString.Length - 8, 8) + "</span></div><p class='description'>" + subc.MSG_Fa + "</p></li>"
                    Dim qrySubCa = From a In db.Comments
                                   Select a Order By
                                                a.IDC Where a.Parent = subc.IDC And (a.IDElement = Page.RouteData.Values("ID").ToString) And a.Parent <> 0
                    For Each subca In qrySubCa
                        ItemComment.Text += "<li style='background-color:rgba(250,255,250,0.8);margin-right:60px;'><img class='avatar' width='84' height='84' src='/img/avatar.png' alt='" + subc.NameAndFamily_Fa + "'><div class='meta'><span>" + subc.NameAndFamily_Fa + "</span>, <span class='time'>" + subc.Moment_Fa.ToString.Remove(subc.Moment_Fa.ToString.Length - 8, 8) + "</span></div><p class='description'>" + subc.MSG_Fa + "</p></li>"
                    Next
                Next
            Next
            ItemComment.Text += "</ul>"

            CommentsViewPlaceHolder.Controls.Add(ItemComment)
            If Page.RouteData.Values("Action").ToString = "posts" Or Page.RouteData.Values("Action").ToString = "post" Then
                Dim qry = From m In db.Messages
                          Select m Order By
                                       m.IDMessage Where (m.IDMessage = Page.RouteData.Values("ID").ToString) And (m.IsShow = True)
                For Each q In qry
                    ltrTitle.Text = "<p style='direction:rtl;'>" + q.Title_Fa + "</p>"
                    Page.Title = "مطالب سایت | " + q.Title_Fa
                    Item.Text = "<article class='post'><div class='entry-content'><img alt='" + q.Title_Fa + "' src='" + q.Image + "' style='margin: 10px; padding: 5px; width: 100px; float: Left; height: 100px;border-radius:15px;' class='img-responsive' />" + q.PreMessage_Fa + q.Message_Fa + "</div><footer  id='SectionComment' class='entry-meta'><span class='autor-name'>  نویسنده  <a href='../../../about/" + q.WrittenBy_En.ToString.Replace(" ", "-").ToLower() + "'>" + q.WrittenBy_Fa + "</a></span> | <span class='time'>" + q.Moment_Fa.ToString.Remove(q.Moment_Fa.ToString.Length - 8, 8) + "</span><span class='meta'></span><span class='comments-link pull-right'><a href='#SectionComment'> دیدگاه " + qryC.Count.ToString + "</a></span><a class='btn btn-info' style='float:left;' href='../'>بازگشت</a></footer></article>"
                    ltrRoot.Text = "<li><a href='/index'>صفحه اصلی</a> <span class='divider'>/</span></li><li><a href='/posts/all/'>آرشیو مطالب سایت</a> <span class='divider'>/</span></li><li class='active'>" + "<p style='direction:rtl;'>" + q.Title_Fa + "</p>" + "</li>"
                    ltrTag.Text = ""
                    For Each i In q.Keyword_Fa.ToString.Split(";")
                        ltrTag.Text += "<a href='/result/" + i.ToString.Replace(" ", "-") + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>" + i.ToString + "</a>"
                        Page.MetaKeywords += i.ToString + ","
                    Next
                    'Item.Text += "<a class='button small solid-button purple' style='float: left;' onclick='history.go(-1)' href='#'> بازگشت</a></div></div><br/><br/>"
                    Page.MetaDescription = q.MetaDescription_Fa
                    MetaTitle = "<meta property='og:title' content='" + Page.Title + "' />"
                    MetaDesc = "<meta property='og:description' content='" + Page.MetaDescription + "' />"
                    MetaNameSite = "<meta property='og:site_name' content='وب سایت شرکت نارم' />"
                    MetaBrand = "<meta property='og:brand' content='نارم' />"
                    MetaIMG = "<meta property='og:image' content='" + q.Image + "' />"
                    MetaUrl = "<meta property='og:url' content='https://narem.ir" + Request.RawUrl + "' />"
                    MetaLocal = "<meta property='og:locale' content='fa' />"
                    MetaAuthor = "<meta property='og:article:author' content='امیرحسن مروجی' />"
                    MetaType = "<meta property='og:type' content='article' />"
                    MetaArticelSection = "<meta property='og:article:section' content='مقالات' />"
                    litMeta.Text = MetaIMG + MetaTitle + MetaDesc + MetaNameSite + MetaBrand + MetaUrl + MetaLocal + MetaAuthor + MetaArticelSection
                    Exit For
                Next
                PostViewPlaceHolder.Controls.Add(Item)
            End If
            If Page.RouteData.Values("Action").ToString = "news" Or Page.RouteData.Values("Action").ToString = "new" Then
                Dim qry = From m In db.News1s
                          Select m Order By
                                       m.IDN.ToString Where (m.IDN.ToString = Page.RouteData.Values("ID").ToString) And (m.IsShow = True)
                For Each q In qry
                    ltrTitle.Text = "<p style='direction:rtl;'>" + q.Title_Fa + "</p>"
                    Page.Title = "اخبار | " + q.Title_Fa
                    Item.Text = "<article class='post'><div class='entry-content'><img alt='" + q.Title_Fa + "' src='" + q.Pic + "' style='margin: 10px; padding: 5px; width: 100px; float: Left; height: 100px;border-radius:15px;' class='img-responsive' />" + q.PreMSG_Fa + q.MSG_Fa + "</div><footer  id='SectionComment' class='entry-meta'><span class='autor-name'>  نویسنده  <a href='../../../about/" + q.WrittenBy_En.ToString.Replace(" ", "-").ToLower() + "'>" + q.WrittenBy_Fa + "</a></span> | <span class='time'>" + q.Moment_Fa.ToString.Remove(q.Moment_Fa.ToString.Length - 8, 8) + "</span><span class='meta'></span><span class='comments-link pull-right'><a href='#SectionComment'> دیدگاه " + qryC.Count.ToString + "</a></span><a class='btn btn-info' style='float:left;' href='../'>بازگشت</a></footer></article>"
                    ltrRoot.Text = "<li><a href='/index'>صفحه اصلی</a><span class='divider'>/</span></li><li><a href='/news/all/'>آرشیو اخبار</a><span class='divider'>/</span></li><li class='active'>" + "<p style='direction:rtl;'>" + q.Title_Fa + "</p>" + "</li>"
                    ltrTag.Text = ""
                    For Each i In q.Keyword_Fa.ToString.Split(";")
                        ltrTag.Text += "<a href='/result/" + i.ToString.Replace(" ", "-") + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>" + i.ToString + "</a>"
                        Page.MetaKeywords += i.ToString + ","
                    Next
                    'Item.Text += "<a class='button small solid-button purple' style='float: left;' onclick='history.go(-1)' href='#'> بازگشت</a></div></div><br/><br/>"
                    Page.MetaDescription = q.MetaDescription_Fa
                    MetaTitle = "<meta property='og:title' content='" + Page.Title + "' />"
                    MetaDesc = "<meta property='og:description' content='" + Page.MetaDescription + "' />"
                    MetaNameSite = "<meta property='og:site_name' content='وب سایت شرکت نارم' />"
                    MetaBrand = "<meta property='og:brand' content='نارم' />"
                    MetaIMG = "<meta property='og:image' content='" + q.Pic + "' />"
                    MetaUrl = "<meta property='og:url' content='https://narem.ir" + Request.RawUrl + "' />"
                    MetaLocal = "<meta property='og:locale' content='fa' />"
                    MetaAuthor = "<meta property='og:article:author' content='امیرحسن مروجی' />"
                    MetaType = "<meta property='og:type' content='article' />"
                    MetaArticelSection = "<meta property='og:article:section' content='مقالات' />"
                    litMeta.Text = MetaIMG + MetaTitle + MetaDesc + MetaNameSite + MetaBrand + MetaUrl + MetaLocal + MetaAuthor + MetaArticelSection
                    Exit For
                Next
                PostViewPlaceHolder.Controls.Add(Item)
            End If
            If Page.RouteData.Values("Action").ToString = "page" Or Page.RouteData.Values("Action").ToString = "pages" Then
                Dim qry = From m In db.Pages
                          Select m Order By
                                       m.ID Where m.ID = Page.RouteData.Values("ID").ToString
                For Each q In qry
                    ltrTitle.Text = q.PageTitle_Fa
                    Page.Title = q.PageTitle_Fa
                    Item.Text = "<article class='post'><div class='entry-content'>" + q.Body_Fa + "</div><footer  id='SectionComment' class='entry-meta'><span class='autor-name'>  نویسنده  <a href='../../../about/" + q.WrittenBy_En.ToString.Replace(" ", "-").ToLower() + "'>" + q.WrittenBy_Fa + "</a></span> | <span class='time'>" + q.Moment_Fa.ToString.Remove(q.Moment_Fa.ToString.Length - 8, 8) + "</span><span class='meta'></span><span class='comments-link pull-right'><a href='#SectionComment'> دیدگاه " + qryC.Count.ToString + "</a></span></footer></article>"
                    ltrRoot.Text = "<li><a href='/index'>صفحه اصلی</a><span class='divider'>/</span></li><li class='active'>" + q.PageTitle_Fa + "</li>"
                    'lblRootPageHref.InnerText = "صفحه‌ها"
                    'lblRootPageHref.HRef = "/page/"
                    'lblCurrentPage.Text = q.PageTitle_Fa
                    ltrTag.Text += ""
                    For Each i In q.Keyword_Fa.ToString.Split(";")
                        ltrTag.Text += "<a href='/result/" + i.ToString.Replace(" ", "-") + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>" + i.ToString + "</a>"
                        Page.MetaKeywords += i.ToString + ","
                    Next
                    Page.MetaDescription = q.PageTitle_Fa
                    Page.MetaDescription = q.MetaDescription_Fa
                    MetaTitle = "<meta property='og:title' content='" + Page.Title + "' />"
                    MetaDesc = "<meta property='og:description' content='" + Page.MetaDescription + "' />"
                    MetaNameSite = "<meta property='og:site_name' content='وب سایت شرکت نارم' />"
                    MetaBrand = "<meta property='og:brand' content='نارم' />"
                    MetaIMG = "<meta property='og:image' content='" + q.Image + "' />"
                    MetaUrl = "<meta property='og:url' content='https://narem.ir" + Request.RawUrl + "' />"
                    MetaLocal = "<meta property='og:locale' content='fa' />"
                    MetaAuthor = "<meta property='og:article:author' content='امیرحسن مروجی' />"
                    MetaType = "<meta property='og:type' content='article' />"
                    MetaArticelSection = "<meta property='og:article:section' content='مقالات' />"
                    litMeta.Text = MetaIMG + MetaTitle + MetaDesc + MetaNameSite + MetaBrand + MetaUrl + MetaLocal + MetaAuthor + MetaArticelSection
                    Exit For
                Next
                PostViewPlaceHolder.Controls.Add(Item)
            End If
            If Page.RouteData.Values("Action").ToString = "faq" Then
                Dim qry = From m In db.FAQms
                          Select m Order By
                                       m.IDF Where m.IDF = (Page.RouteData.Values("ID").ToString) And (m.IsShow = True)
                For Each q In qry
                    ltrTitle.Text = q.Question_Fa
                    Page.Title = "پرسش و پاسخ | " + q.Question_Fa
                    Item.Text = "<article class='post'><div class='entry-content'>" + q.Answer_Fa + "</div><footer  id='SectionComment' class='entry-meta'><span class='autor-name'>  پرسیده شده توسط  " + q.AskedBy_Fa + " </span> | <span class='autor-name'>  پاسخ داده شده توسط  <a href='/about/" + q.AnswerBy_En.ToString.Replace(" ", "-").ToLower() + "'>" + q.AnswerBy_Fa + "</a></span> | <span class='time'>" + q.Moment_Fa.ToString.Remove(q.Moment_Fa.ToString.Length - 8, 8) + "</span><span class='separator'>   </span><span class='meta'></span><span class='comments-link pull-right'><a href='#SectionComment'> دیدگاه " + qryC.Count.ToString + "</a></span></footer></article>"
                    ltrRoot.Text = "<li><a href='/index'>صفحه اصلی</a> <span class='divider'>/</span></li><li><a href='/faq/all/'>پرسش‌های متداول</a> <span class='divider'>/</span></li><li class='active'>" + q.Question_Fa
                    ltrTag.Text = ""
                    For Each i In q.Keyword_Fa.ToString.Split(";")
                        ltrTag.Text += "<a href='/result/" + i.ToString.Replace(" ", "-") + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>" + i.ToString + "</a>"
                        Page.MetaKeywords += i.ToString + ","
                    Next
                    Page.MetaDescription = q.MetaDescription_Fa
                    MetaTitle = "<meta property='og:title' content='" + Page.Title + "' />"
                    MetaDesc = "<meta property='og:description' content='" + Page.MetaDescription + "' />"
                    MetaNameSite = "<meta property='og:site_name' content='وب سایت شرکت نارم' />"
                    MetaBrand = "<meta property='og:brand' content='نارم' />"
                    MetaIMG = "<meta property='og:image' content='FilesAdmin/CompanyMin.png' />"
                    MetaUrl = "<meta property='og:url' content='https://narem.ir" + Request.RawUrl + "' />"
                    MetaLocal = "<meta property='og:locale' content='fa' />"
                    MetaAuthor = "<meta property='og:article:author' content='امیرحسن مروجی' />"
                    MetaType = "<meta property='og:type' content='article' />"
                    MetaArticelSection = "<meta property='og:article:section' content='مقالات' />"
                    litMeta.Text = MetaIMG + MetaTitle + MetaDesc + MetaNameSite + MetaBrand + MetaUrl + MetaLocal + MetaAuthor + MetaArticelSection
                    Exit For
                Next
                PostViewPlaceHolder.Controls.Add(Item)
            End If

        Catch ex As Exception
            'Response.Redirect("/index")
            Response.Write(ex.Message)
        End Try

    End Sub

    Protected Sub btnCommentSubmit_Click(sender As Object, e As EventArgs) Handles btnCommentSubmit.Click
        Dim tarikh As HtmlInputText = Master.FindControl("tarikh")
        Dim tarikh_En As HtmlInputText = Master.FindControl("tarikh_En")
        If RadCaptcha1.IsValid = True Then
            Try
                Dim db = New LinqDBClassesDataContext
                Dim qry = From m In db.Comments
                          Select m Where m.NameAndFamily_Fa = txtNameFamili.Text
                For Each m In qry
                    If m.MSG_Fa = txtMessage.Text Then
                        lblSubmitStatus.Text = "این دیدگاه قبلا ارسال شده."
                        SweetAlertSucsses("دیدگاه شما قبلا ثبت شده است", "دیدگاه شما در حال حاضر در لیست انتظار وجود دارد", "بسیار خوب", "warning")

                        Exit Try
                    End If
                Next
                Dim q = New Comment
                q.MSG_Fa = txtMessage.Text
                q.Email = txtEmail.Text
                q.WebSite = txtWebsite.Text
                q.Moment_Fa = tarikh.Value
                q.Moment_En = tarikh_En.Value
                q.NameAndFamily_Fa = txtNameFamili.Text
                q.Action = Page.RouteData.Values("Action").ToString
                q.Parent = 0
                q.Access = "All"
                q.IsShow = False
                q.Active = False
                q.Seen = "جدید"
                q.Keyword_En = "Unknown"
                q.Keyword_Fa = "نامشخص"
                q.IDElement = Convert.ToInt16(Page.RouteData.Values("ID"))
                db.Comments.InsertOnSubmit(q)
                db.SubmitChanges()
                lblSubmitStatus.Style.Value = "color:#1fbf02;" 'سبز
                lblSubmitStatus.Text = "دیدگاه شما با موفقیت ارسال شد."
                SweetAlertSucsses("با تشکر", "دیدگاه شما در لیست انتظار جهت تایید، ثبت شد. منتظر تایید باشید", "بسیار خوب", "success")
            Catch ex As Exception
                Response.Write(ex.Message)
                lblSubmitStatus.Style.Value = "color:Orange;"
                lblSubmitStatus.Text = "ارسال نا موفق - خطا سرور."
                SweetAlertSucsses("خطای سرور", "ارسال ناموفق بود لطفا بعدا مجددا تلاش کنید", "بسیار خوب", "error")
            End Try
        Else
            lblSubmitStatus.Style.Value = "color:Orange;"
            SweetAlertSucsses("خطا در ورود کد امنیتی", "متاسفانه ارسال دیدگاه شما با شکست مواجه شد", "بسیار خوب", "error")
            'Response.Redirect("#section6")
        End If
    End Sub
    Public Sub SweetAlertSucsses(Title As String, plainText As String, btnText As String, Icon As String)
        ' Define the name and type of the client scripts on the page. 
        Dim csname1 As [String] = "randomtext"
        Dim cstype As Type = Me.[GetType]()
        ' Get a ClientScriptManager reference from the Page class. 
        Dim cs As ClientScriptManager = Page.ClientScript
        ' Check to see if the startup script is already registered. 
        If Not cs.IsStartupScriptRegistered(cstype, csname1) Then
            Dim cstext1 As New StringBuilder()
            cstext1.Append("<script type=text/javascript>swal({title: '" + Title + "',text: '" + plainText + "',icon: '" + Icon + "',button: '" + btnText + "',});</script>")
            'cstext1.Append(" alertsucsses11() </script>")
            cs.RegisterStartupScript(cstype, csname1, cstext1.ToString())
        End If
    End Sub

End Class
