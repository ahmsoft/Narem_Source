
Partial Class Terms
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Title = "قوانین استفاده از وب سایت - نارِم"
        Page.MetaDescription = "بدیهی است دریافت اشتراک از سایت و دریافت هرگونه خدمات از نارم، به منزله مطالعه و قبول قوانین و مقررات مربوطه است."
        Page.MetaKeywords = "شرکت نارم , شرایط و ضوابط , وب سایت نارم , هوش مصنوعی , مالی و حسابداری ,  نرم افزار"
        Dim MetaIMG As String = "<meta property='og:image' content='FilesAdmin/CompanyMin.png' />"
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
        Try
            If (Page.RouteData.Values("Search").ToString.Replace("-", " ") IsNot Nothing) Or (Page.RouteData.Values("Search").ToString.Replace("-", " ") <> "") Then
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
        Dim ltrCat = New Literal
        Dim CAT = From m In db.Categories
                  Select m Order By m.Priority Ascending, m.IDCat Ascending

        ltrCat.Text = "<aside class='list'><header><h3>دسته‌بندی‌ها<h3></header><ul>"
        For Each b In CAT
            'ltrCat.ToolTip = b.CatName_Fa
            ltrCat.Text += "<li><a href='/posts/all/" + b.CatName_Fa.ToString.Replace(" ", "-") + "' title='" + b.Description_Fa + "'>" + b.CatName_Fa + "</a></li>"
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
            Try
                Dim qry = From m In db.Settings
                          Select m
                For Each q In qry
                    Dim qryCompany = From c In db.Users
                                     Select c Where c.Username = "narem"
                    For Each l In qryCompany
                        If Page.RouteData.Values("Type").ToString = "privacy-policy" Then
                            Page.Title = "قوانین حریم خصوصی | شرکت نارِم"
                            Page.MetaDescription = "شرکت نارم قصد دارد با شفاف سازی بیشتر در این زمینه، به کاربران سایت اطمینان دهد که تمام تلاش خود را جهت حفظ امنیت اطلاعات کاربران سایت به کار می‌برد."
                            Page.MetaKeywords = "شرکت نارم , شرایط و ضوابط , وب سایت نارم , هوش مصنوعی , مالی و حسابداری ,  نرم افزار"
                            MetaIMG = "<meta property='og:image' content='img/Login.png' />"
                            MetaTitle = "<meta property='og:title' content='قوانین حریم خصوصی | شرکت نارِم' />"
                            MetaDesc = "<meta property='og:description' content='شرکت نارم قصد دارد با شفاف سازی بیشتر در این زمینه، به کاربران سایت اطمینان دهد که تمام تلاش خود را جهت حفظ امنیت اطلاعات کاربران سایت به کار می‌برد.' />"
                            MetaNameSite = "<meta property='og:site_name' content='وب سایت شرکت نارم' />"
                            MetaBrand = "<meta property='og:brand' content='نارم' />"
                            MetaUrl = "<meta property='og:url' content='https://narem.ir" + Request.RawUrl + "' />"
                            MetaLocal = "<meta property='og:locale' content='fa' />"
                            MetaAuthor = "<meta property='og:article:author' content='امیرحسن مروجی' />"
                            MetaType = "<meta property='og:type' content='article' />"
                            MetaArticelSection = "<meta property='og:article:section' content='مقالات' />"
                            litMeta.Text = MetaIMG + MetaTitle + MetaDesc + MetaNameSite + MetaBrand + MetaUrl + MetaLocal + MetaAuthor + MetaArticelSection
                            ltrTitle.Text = "قوانین حریم خصوصی " + q.NameSite_Fa.ToString
                            Item.Text = "<div class='row'><div class='span9 '><div class='content-block bottom-padding frame frame-shadow-curved'><a class='icon bg circle icon-60 pull-left'><img src='/img/Login.png' alt='سیاست حریم خصوصی' style='border-radius:30px;' /></a><h5>" + "سیاست حفظ حریم خصوصی و استفاده از حساب کاربری در وب سایت " + q.NameSite_Fa.ToString + "</h5>"
                            Item.Text += q.PrivacyPolicy_Fa
                            Item.Text += "</div></div></div>"
                            ltrBreadCrumb.Text = "<div class='container'><ul class='breadcrumb'><li><a href='/index'>صفحه اصلی</a> <span class='divider'>/</span></li><li><a href='/terms/'>شرایط و ضوابط</a> <span class='divider'>/</span></li><li class='active'>حریم خصوصی </li></ul></div>"
                        ElseIf Page.RouteData.Values("Type").ToString = "safe-pay" Then
                            Page.Title = "پرداخت امن | شرکت نارِم"
                            Page.MetaDescription = "اطمینان خاطر از امنیت در پرداخت آنلاین، مسیر هموار‌تر و مطمئن‌تری را برای هر کسب‌وکاری می‌سازد."
                            Page.MetaKeywords = "شرکت نارم , پرداخت امن , وب سایت نارم , هوش مصنوعی , مالی و حسابداری ,  نرم افزار"
                            MetaIMG = "<meta property='og:image' content='img/Safe-Pay.png' />"
                            MetaTitle = "<meta property='og:title' content='پرداخت امن | شرکت نارِم' />"
                            MetaDesc = "<meta property='og:description' content='اطمینان خاطر از امنیت در پرداخت آنلاین، مسیر هموار‌تر و مطمئن‌تری را برای هر کسب‌وکاری می‌سازد.' />"
                            MetaNameSite = "<meta property='og:site_name' content='وب سایت شرکت نارم' />"
                            MetaBrand = "<meta property='og:brand' content='نارم' />"
                            MetaUrl = "<meta property='og:url' content='https://narem.ir" + Request.RawUrl + "' />"
                            MetaLocal = "<meta property='og:locale' content='fa' />"
                            MetaAuthor = "<meta property='og:article:author' content='امیرحسن مروجی' />"
                            MetaType = "<meta property='og:type' content='article' />"
                            MetaArticelSection = "<meta property='og:article:section' content='مقالات' />"
                            litMeta.Text = MetaIMG + MetaTitle + MetaDesc + MetaNameSite + MetaBrand + MetaUrl + MetaLocal + MetaAuthor + MetaArticelSection
                            ltrTitle.Text = "پرداخت امن " + q.NameSite_Fa.ToString
                            Item.Text = "<div class='row'><div class='span9 '><div class='content-block bottom-padding frame frame-shadow-curved'><a class='icon bg circle icon-60 pull-left'><img src='/img/Safe-Pay.png' alt='پرداخت امن' style='border-radius:30px;' /></a><h5>" + "پرداخت امن در وب سایت " + q.NameSite_Fa.ToString + "</h5>"
                            Item.Text += q.SafePay_Fa
                            Item.Text += "</div></div></div>"
                            ltrBreadCrumb.Text = "<div class='container'><ul class='breadcrumb'><li><a href='/index'>صفحه اصلی</a> <span class='divider'>/</span></li><li><a href='/terms/'>شرایط و ضوابط</a> <span class='divider'>/</span></li><li class='active'>پرداخت امن </li></ul></div>"
                        End If
                    Next

                    ltrTag.Text += ""
                    For Each i In q.Keywords_Fa.ToString.Split(";")
                        ltrTag.Text += "<a href='/result/" + i.ToString.Replace(" ", "-") + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>" + i.ToString + "</a>"
                        Page.MetaKeywords += i.ToString + ","
                    Next
                Next
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                PostViewPlaceHolder.Controls.Add(Item)
            Catch ex As Exception
                Dim qry = From m In db.Settings
                          Select m
                For Each q In qry
                    Dim qryCompany = From c In db.Users
                                     Select c Where c.Username = "NAREM"
                    For Each l In qryCompany
                        ltrTitle.Text = "شرایط و ضوابط " + q.NameSite_Fa.ToString
                        Item.Text = "<div class='row'><div class='span9 '><div class='content-block bottom-padding frame frame-shadow-curved'><a class='icon bg circle icon-60 pull-left'><img src='" + l.PhotoMin + "' alt='" + l.Name_Fa + " " + l.Family_Fa + "' style='border-radius:30px;' /></a><h5>" + "شرایط و ضوابط استفاده از وب سایت " + q.NameSite_Fa.ToString + "</h5>"
                        Item.Text += q.Terms_Fa
                        Item.Text += "</div></div></div>"
                    Next
                    'ltrCurrentPage.Text = "شرایط و ضوابط "
                    ltrBreadCrumb.Text = "<div class='container'><ul class='breadcrumb'><li><a href='/index'>صفحه اصلی</a> <span class='divider'>/</span></li><li class='active'>شرایط و ضوابط </li></ul></div>"
                    ltrTag.Text += ""
                    For Each i In q.Keywords_Fa.ToString.Split(";")
                        ltrTag.Text += "<a href='/result/" + i.ToString.Replace(" ", "-") + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>" + i.ToString + "</a>"
                        Page.MetaKeywords += i.ToString + ","
                    Next
                Next
                PostViewPlaceHolder.Controls.Add(Item)
            End Try
        Catch ex As Exception
            Response.Write(ex.Message)

        End Try
    End Sub
End Class
