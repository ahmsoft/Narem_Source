
Partial Class FAQ
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Title = "پرسش‌های متداول"
        Page.MetaDescription = "مشاهده‌ی پاسخ به برخی از سوالات متداول مشتریان، همچنین شما می‌توانید پرسش خود را مطرح و برای ما ارسال نمایید ."
        Page.MetaKeywords = "شرکت نارم , پرسش‌های متداول , وب سایت نارم , هوش مصنوعی , مالی و حسابداری ,  نرم افزار"
        Dim MetaIMG As String = "<meta property='og:image' content='../../img/FAQ.png' />"
        Dim MetaTitle As String = "<meta property='og:title' content='" + Page.Title + "' />"
        Dim MetaDesc As String = "<meta property='og:description' content='" + Page.MetaDescription + "' />"
        Dim MetaNameSite As String = "<meta property='og:site_name' content='وب سایت شرکت نارم' />"
        Dim MetaBrand As String = "<meta property='og:brand' content='نارم' />"
        Dim MetaUrl As String = "<meta property='og:url' content='https://narem.ir" + Request.RawUrl + "' />"
        Dim MetaLocal As String = "<meta property='og:locale' content='fa' />"
        Dim MetaAuthor As String = "<meta property='og:article:author' content='امیرحسن مروجی' />"
        Dim MetaType As String = "<meta property='og:type' content='article' />"
        Dim MetaArticelSection As String = "<meta property='og:article:section' content='مقالات' />"
        litMeta.Text = MetaIMG + MetaTitle + MetaDesc + MetaNameSite + MetaBrand + MetaUrl + MetaLocal + MetaAuthor + MetaArticelSection
        'TODO:مسیردهی کامل شود
        Try
            If Page.RouteData.Values("Search").ToString.Replace("-", " ") <> "" Then
                Response.Redirect("/result/" + Page.RouteData.Values("Search").ToString.Replace("-", " "))
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
        Try
            Dim ltrCat = New Literal
            Dim CAT = From m In db.Categories
                      Select m Order By m.Priority Ascending, m.IDCat Ascending

            ltrCat.Text = "<aside class='list'><header><h3>دسته‌بندی‌ها</h3></header><ul>"
            For Each b In CAT
                'lblCat.ToolTip = b.CatName_Fa
                Try
                    If b.CatName_En.ToLower() = Page.RouteData.Values("CatName").ToString.Replace("-", " ") Then
                        ltrCat.Text += "<li><a style='color:White;background-color:#7baa00;padding-left:5px;padding-right:5px;border-radius:5px;font-size:15px;' href='/faq/" + b.CatName_En.ToString.Replace(" ", "-").ToLower() + "/' title='" + b.Description_Fa + "'>" + b.CatName_Fa + "</a></li>"
                    Else

                        ltrCat.Text += "<li><a href='/faq/" + b.CatName_En.ToString.Replace(" ", "-").ToLower() + "/' title='" + b.Description_Fa + "'>" + b.CatName_Fa + "</a></li>"
                    End If
                Catch ex As Exception
                    ltrCat.Text += "<li><a href='/faq/" + b.CatName_En.ToString.Replace(" ", "-").ToLower() + "/' title='" + b.Description_Fa + "'>" + b.CatName_Fa + "</a></li>"
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
                            lbl.Text += "<li><a href='" + l.Address_Fa + "' title='" + l.Alt_Fa + "' target='" + l.Target + "'>" + l.Name_Fa + "</a></li>"
                        End If
                    End If
                Next
                lbl.Text = lbl.Text + "</ul></aside>"
                If b.Position = "Left" Then
                    PlaceHolderBlock.Controls.Add(lbl)

                End If
            Next
        Catch ex As Exception
            Response.Redirect("/index")
            'Response.Write(ex.Message)
        End Try

        lblRootPageHref.InnerText = "پرسش‌های متداول"
        lblRootPageHref.HRef = "/faq/all/"
        Try
            If Page.RouteData.Values("CatName").ToString() = "" Then
                lblCurrentPage.Text = "همه"
            Else
                Dim CAT = From m In db.Categories
                          Select m Where m.CatName_En.ToLower() = Page.RouteData.Values("CatName").ToString.Replace("-", " ")

                For Each b In CAT
                    'lblCat.ToolTip = b.CatName_Fa
                    lblCurrentPage.Text = b.CatName_Fa
                Next
            End If
        Catch ex As Exception
            lblCurrentPage.Text = "همه"
        End Try

    End Sub
    Protected Sub btnFAQSubmit_Click(sender As Object, e As EventArgs) Handles btnFAQSubmit.Click
        Dim tarikh As HtmlInputText = Master.FindControl("tarikh")
        Dim tarikh_En As HtmlInputText = Master.FindControl("tarikh_En")
        If RadCaptcha.IsValid = True Then
            Try
                Dim db = New LinqDBClassesDataContext
                Dim qry = From m In db.FAQms
                          Select m Where m.AskedBy_Fa = txtNameAndFamily.Text
                For Each m In qry
                    If m.Question_Fa = txtQuestion.Text Then
                        lblSubmitStatusFAQ.Text = "این پرسش قبلا ارسال شده."
                        SweetAlertSucsses("پرسش شما قبلا ثبت شده است", "پرسش شما در حال حاضر در لیست انتظار وجود دارد", "بسیار خوب", "warning")
                        Exit Try
                    End If
                Next
                Dim q = New FAQm

                q.Question_Fa = txtQuestion.Text
                q.Priority = 1
                'q.WebSite = txtWSite.Text
                q.Moment_Fa = tarikh.Value
                q.Moment_En = tarikh_En.Value
                q.AskedBy_Fa = txtNameAndFamily.Text
                'q.Action = Page.RouteData.Values("Action").ToString
                'q.Parent = 0
                'q.Access = "All"
                q.IsShow = False
                'q.Active = False
                q.Seen = "جدید"
                'q.IDElement = Convert.ToInt16(Page.RouteData.Values("ID"))
                db.FAQms.InsertOnSubmit(q)
                db.SubmitChanges()
                lblSubmitStatusFAQ.Style.Value = "color:#1fbf02;" 'سبز
                lblSubmitStatusFAQ.Text = "پرسش شما با موفقیت ارسال شد."
                SweetAlertSucsses("با تشکر", "پرسش شما در لیست انتظار جهت پاسخ، ثبت شد. منتظر پاسخ باشید", "بسیار خوب", "success")
            Catch ex As Exception
                Response.Write(ex.Message)
                lblSubmitStatusFAQ.Style.Value = "color:Orange;"
                lblSubmitStatusFAQ.Text = "ارسال نا موفق - خطا سرور."
                SweetAlertSucsses("خطای سرور", "ارسال ناموفق بود لطفا بعدا مجددا تلاش کنید", "بسیار خوب", "error")
            End Try
        Else
            lblSubmitStatusFAQ.Style.Value = "color:Orange;"
            lblSubmitStatusFAQ.Text = "کد امنیتی با دقت وارد شود."
            SweetAlertSucsses("خطا در ورود کد امنیتی", "متاسفانه ارسال پرسش شما با شکست مواجه شد", "بسیار خوب", "error")
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
