
Partial Class About
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

        Try
            If Page.RouteData.Values("Search").ToString <> "" Then
                Response.Redirect("/result/" + Page.RouteData.Values("Search").ToString)
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
            'lblCat.ToolTip = b.CatName_Fa
            ltrCat.Text += "<li><a href='/posts/" + b.CatName_En.ToString.Replace(" ", "-").ToLower() + "' title='" + b.Description_Fa + "'>" + b.CatName_Fa + "</a></li>"
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
        '''''''
        Try
            Dim qry12 = From m In db.Users
                        Select m Order By m.Name_Fa Where m.Username <> "narem"
            For Each q In qry12
                For Each Auth In q.Authoritys.ToString.Split(";")
                    If Auth = "Admin" Then
                        Item.Text += "<div class='span3 employee rotation'><div class='default'><div class='image'><img src='" + q.PhotoMax + "' alt='" + q.Name_Fa + " " + q.Family_Fa + "' title='" + q.Job_Fa + "' width='270' height='270'></div><div class='description'><div class='vertical'><h3 class='name'>" + q.Name_Fa + " " + q.Family_Fa + "</h3><div class='role'>" + q.Job_Fa + "</div></div></div></div><div class='employee-hover'><h3 class='name'>" + q.Name_Fa + " " + q.Family_Fa + "</h3><div class='role'>" + q.Evidence_Fa + "</div><div class='image'><img src='" + q.PhotoMin + "' alt='" + q.Memo_Fa + "' title='" + q.Name_Fa + " " + q.Family_Fa + "' width='270' height='270'></div><div><p>" + q.Job_Fa + "</p><div class='contact'><p style='text-align:left;'><b>Email: </b><a style='color:rgba(255,255,255,0.8);text-decoration:none;' href='mailto:" + q.Email + "'>" + q.Email + "</a></p></div><div class='contact'><p style='text-align:left;direction:ltr;'><b>Phone: </b><a style='color:rgba(255,255,255,0.8);text-decoration:none;' rel='nofollow' href='tel:" + q.Mobile1 + "'>" + q.Mobile1 + "</a><br/>"
                        If q.Intrests_Fa <> "" Then
                            Item.Text += "<span style='float:right;text-align:right;direction:rtl;'><b>علاقه‌مندی: </b>" + q.Intrests_Fa + "</span>"
                        End If
                        Item.Text += "<br/><a style='color:#8ab733;' href='/about/" + q.Name_En.ToString.Replace(" ", "-").ToLower() + "-" + q.Family_En.ToString.Replace(" ", "-").ToLower() + "'>درباره ایشان بیشتر بدانید</a></p></div></div>"
                        Item.Text += "<div class='social'>"
                        'If q.Facebook <> "" Then
                        '    Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-facebook' href='" + q.Facebook + "'></a></div>"
                        'End If
                        'If q.Twitter <> "" Then
                        '    Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-twitter' href='" + q.Twitter + "'></a></div>"
                        'End If
                        'If q.Googleplus <> "" Then
                        '    Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-gplus' href='" + q.Googleplus + "'></a></div>"
                        'End If
                        If q.Linkedin <> "" Then
                            Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-linkedin' href='" + q.Linkedin + "'></a></div>"
                        End If
                        If q.Instagram <> "" Then
                            Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-instagram' href='" + q.Instagram + "'></a></div>"
                        End If
                        If q.Telegram <> "" Then
                            Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-telegram' href='" + q.Telegram + "'><img src='../img/telegram.png' /></a></div>"
                        End If
                        If q.WhatsApp <> "" Then
                            Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-whatsapp' href='" + q.WhatsApp + "'><img src='../img/WhatsApp.png' /></a></div>"
                        End If
                        Item.Text += "</div></div></div>"
                        Exit For
                    End If
                Next
            Next
            ltrAdminMember.Text = Item.Text
            Dim qry = From m In db.Users
                      Select m
                      Where (m.Username = "Narem")
            For Each q In qry
                ManagerDiv.Visible = True
                ltrTitle.Text = (q.Name_Fa + " (" + q.Family_Fa + ")").ToString
                Item.Text = "<div class='row'><div class='span4 '><div class='content-block bottom-padding frame frame-shadow-curved'><a href='#' class='icon bg circle icon-60 pull-left'><img src='" + q.PhotoMin + "' alt='" + q.Name_Fa + " " + q.Family_Fa + "'  style='border-radius:30px;' /></a><h5>اطلاعات پایه:</h5>نام شرکت: " + q.Name_Fa + "<br/>نام تجاری: " + q.Family_Fa + "<br/>تاریخ تاسیس: " + q.BirthDay_Fa.ToString + " / " + q.BirthMonth_Fa.ToString + " / " + q.BirthYear_Fa.ToString + "<br/>محل ثبت: " + q.BirthdayLocation_Fa + "<br/>شماره ثبت: " + q.GraduationDate_Fa + "<br/>نوع فعالیت: " + q.Evidence_Fa + "<br/>مرکز فعالیت: " + q.LiveLocation_Fa + "<br/>زمینه‌های تخصصی: " + q.Intrests_Fa + "<br/></div></div><div class='span5 bottom-padding'><div class='frame frame-padding frame-shadow-curved'><img src='" + q.PhotoMax + "' width='570' height='270' alt='" + q.Name_Fa + " " + q.Family_Fa + "'></div></div></div><div class='span9 content-block bottom-padding frame frame-shadow-curved'><h5>شرح حال:</h5>"
                If q.Biography_Fa <> "" Then
                    Item.Text += q.Biography_Fa
                End If
                If q.BioEdu_Fa <> "" Then
                    Item.Text += q.BioEdu_Fa
                End If
                If q.About_Fa <> "" Then
                    Item.Text += q.About_Fa
                End If
                If q.ResumeFile <> "" Then
                    Item.Text += q.ResumeFile
                End If
                Item.Text += "</div>"
                If q.BioJob_Fa <> "" Then
                    Item.Text += "<div class='span4 content-block bottom-padding frame-shadow-raised'><h5>اطلاعیه:</h5>" + q.BioJob_Fa + "</div>"
                End If
                Item.Text += "<div class='span4 rotated-box'><div class='content-block bottom-padding frame frame-shadow-lifted'><h5>اطلاعات تماس:</h5>"
                If q.Email <> "" Then
                    Item.Text += "<b>پست الکترونیکی: </b><a style='color:rgba(0,0,0,0.8);text-decoration:none;' href='mailto:" + q.Email + "'>" + q.Email + "</a><br/>"
                End If
                If q.Phone1 <> "" Then
                    Item.Text += "<b>تلفن تماس: </b><a style='color:rgba(0,0,0,0.8);text-decoration:none;' rel='nofollow' href='tel:" + q.Phone1 + "'>" + q.Phone1 + "</a><br/>"
                End If
                If q.Phone2 <> "" Then
                    Item.Text += "<b>تلفن تماس: </b><a style='color:rgba(0,0,0,0.8);text-decoration:none;' rel='nofollow' href='tel:" + q.Phone1 + "'>" + q.Phone2 + "</a><br/>"
                End If
                If q.Mobile1 <> "" Then
                    Item.Text += "<b>تلفن همراه: </b><a style='color:rgba(0,0,0,0.8);text-decoration:none;' rel='nofollow' href='tel:" + q.Mobile1 + "'>" + q.Mobile1 + "</a><br/>"
                End If
                If q.Phone2 <> "" Then
                    Item.Text += "<b>تلفن همراه: </b><a style='color:rgba(0,0,0,0.8);text-decoration:none;' rel='nofollow' href='tel:" + q.Mobile2 + "'>" + q.Mobile2 + "</a><br/>"
                End If
                Item.Text += "<div class='social'>"
                If q.Facebook <> "" Then
                    Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-facebook' href='" + q.Facebook + "'></a></div>"
                End If
                If q.Twitter <> "" Then
                    Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-twitter' href='" + q.Twitter + "'></a></div>"
                End If
                'If q.Googleplus <> "" Then
                '    Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-gplus' href='" + q.Googleplus + "'></a></div>"
                'End If
                If q.Linkedin <> "" Then
                    Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-linkedin' href='" + q.Linkedin + "'></a></div>"
                End If
                If q.Instagram <> "" Then
                    Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-instagram' href='" + q.Instagram + "'></a></div>"
                End If
                If q.Telegram <> "" Then
                    Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-telegram' href='" + q.Telegram + "'><img src='../img/telegram.png' /></a></div>"
                End If
                If q.WhatsApp <> "" Then
                    Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-whatsapp' href='" + q.WhatsApp + "'><img src='../img/WhatsApp.png' /></a></div>"
                End If
                Item.Text += "<br/><br/></div></div></div>"
                lblRootPageHref.InnerText = "درباره "
                lblRootPageHref.HRef = "/about/" + Page.RouteData.Values("Person")
                lblCurrentPage.Text = q.Name_Fa + " " + q.Family_Fa
                ltrTag.Text += ""
                For Each i In q.Keyword_Fa.ToString.Split(";")
                    ltrTag.Text += "<a href='/result/" + i.ToString.Replace(" ", "-") + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>" + i.ToString + "</a>"
                    Page.MetaKeywords += i.ToString + ","
                Next
                'Item.Text += "<a class='button small solid-button purple' style='float: left;' onclick='history.go(-1)' href='#'> بازگشت</a></div></div><br/><br/>"
                'Page.MetaDescription = q.About_Fa
                Page.Title = "درباره‌ی شرکت نارِم"
                Page.MetaDescription = "ارائه‌ی مشاوره، طراحی و توسعه سیستم‌های نرم‌افزاری مبتنی بر وب، هوش مصنوعی و ارائه دهنده خدمات سیستم‌های مالی، حسابداری و حسابرسی می‌باشد."
                Page.MetaKeywords = "شرکت نارم , درباره‌ی شرکت , وب سایت نارم , هوش مصنوعی , مالی و حسابداری ,  نرم افزار"
                MetaIMG = "<meta property='og:image' content='../FilesAdmin/CompanyMin.png' />"
                MetaTitle = "<meta property='og:title' content='" + Page.Title + "' />"
                MetaDesc = "<meta property='og:description' content='" + Page.MetaDescription + "' />"
                MetaNameSite = "<meta property='og:site_name' content='وب سایت شرکت نارم' />"
                MetaBrand = "<meta property='og:brand' content='نارم' />"
                MetaUrl = "<meta property='og:url' content='https://narem.ir" + Request.RawUrl + "' />"
                MetaLocal = "<meta property='og:locale' content='fa' />"
                MetaAuthor = "<meta property='og:article:author' content='امیرحسن مروجی' />"
                MetaType = "<meta property='og:type' content='article' />"
                MetaArticelSection = "<meta property='og:article:section' content='مقالات' />"
                litMeta.Text = MetaIMG + MetaTitle + MetaDesc + MetaNameSite + MetaBrand + MetaUrl + MetaLocal + MetaAuthor + MetaArticelSection
                Exit For
            Next
            PostViewPlaceHolder.Controls.Add(Item)

            If Page.RouteData.Values("Person").ToString <> "" Then
                Dim qry1 = From m In db.Users
                           Select m
                           Where ((m.Name_En + " " + m.Family_En).ToString = Page.RouteData.Values("Person").ToString.Replace("-", " "))
                For Each q In qry1
                    ManagerDiv.Visible = False
                    ltrTitle.Text = (q.Name_Fa + " " + q.Family_Fa).ToString
                    Item.Text = "<div class='row'><div class='span4 '><div class='content-block bottom-padding frame frame-shadow-curved'><a href='#' class='icon bg circle icon-60 pull-left'><img src='" + q.PhotoMin + "' alt='" + q.Name_Fa + " " + q.Family_Fa + "' style='border-radius:30px;' /></a><h5>اطلاعات پایه:</h5>نام و نام خانوادگی: " + q.Name_Fa + " " + q.Family_Fa + "<br/>نام کاربری: " + q.Username
                    If q.BirthDay_Fa.ToString <> "" Then
                        Item.Text += "<br/>تاریخ تولد: " + q.BirthDay_Fa.ToString + " / " + q.BirthMonth_Fa.ToString + " / " + q.BirthYear_Fa.ToString
                    End If
                    If q.BirthdayLocation_Fa <> "" Then
                        Item.Text += "<br/>محل تولد: " + q.BirthdayLocation_Fa
                    End If
                    If q.LiveLocation_Fa <> "" Then
                        Item.Text += "<br/>محل زندگی: " + q.LiveLocation_Fa
                    End If
                    If q.Evidence_Fa <> "" Then
                        Item.Text += "<br/>آخرین مدرک تحصیلی: " + q.Evidence_Fa
                    End If
                    If q.GraduationDate_Fa <> "" Then
                        Item.Text += "<br/>تاریخ ارائه مدرک تحصیلی: " + q.GraduationDate_Fa
                    End If
                    If q.GraduationLocation_Fa <> "" Then
                        Item.Text += "<br/>محل تحصیل: " + q.GraduationLocation_Fa
                    End If
                    If q.Intrests_Fa <> "" Then
                        Item.Text += "<br/>علاقه‌مندی‌ها: " + q.Intrests_Fa
                    End If
                    Item.Text += "<br/></div></div><div class='span5 bottom-padding'><div class='frame frame-padding frame-shadow-curved'><img src='" + q.PhotoMax + "' width='570' height='270' alt='" + q.Name_Fa + " " + q.Family_Fa + "'></div></div></div><div class='span9 content-block bottom-padding frame frame-shadow-curved'><h5>شرح حال:</h5>"
                    If q.Biography_Fa <> "" Then
                        Item.Text += q.Biography_Fa
                    End If
                    If q.BioEdu_Fa <> "" Then
                        Item.Text += q.BioEdu_Fa
                    End If
                    If q.About_Fa <> "" Then
                        Item.Text += q.About_Fa
                    End If
                    If q.ResumeFile <> "" Then
                        Item.Text += q.ResumeFile
                    End If
                    Item.Text += "</div>"
                    If q.BioJob_Fa <> "" Then
                        Item.Text += "<div class='span4 content-block bottom-padding frame-shadow-raised'><h5>جایگاه فعلی در شرکت:</h5>" + q.BioJob_Fa + "</div>"
                    End If
                    Item.Text += "<div class='span4 rotated-box'><div class='content-block bottom-padding frame frame-shadow-lifted'><h5>اطلاعات تماس:</h5>"
                    If q.Email <> "" Then
                        Item.Text += "<b>پست الکترونیکی: </b><a style='color:rgba(0,0,0,0.8);text-decoration:none;' href='mailto:" + q.Email + "'>" + q.Email + "</a><br/>"
                    End If
                    If q.Phone1 <> "" Then
                        Item.Text += "<b>تلفن تماس:  </b><a style='color:rgba(0,0,0,0.8);text-decoration:none;' rel='nofollow' href='tel:" + q.Phone1 + "'>" + q.Phone1 + "</a><br/>"
                    End If
                    If q.Phone2 <> "" Then
                        Item.Text += "<b>تلفن تماس:  </b><a style='color:rgba(0,0,0,0.8);text-decoration:none;' rel='nofollow' href='tel:" + q.Phone2 + "'>" + q.Phone2 + "</a><br/>"
                    End If
                    If q.Mobile1 <> "" Then
                        Item.Text += "<b>تلفن همراه:  </b><a style='color:rgba(0,0,0,0.8);text-decoration:none;' rel='nofollow' href='tel:" + q.Mobile1 + "'>" + q.Mobile1 + "</a><br/>"
                    End If
                    If q.Phone2 <> "" Then
                        Item.Text += "<b>تلفن همراه:  </b><a style='color:rgba(0,0,0,0.8);text-decoration:none;' rel='nofollow' href='tel:" + q.Mobile2 + "'>" + q.Mobile2 + "</a><br/>"
                    End If
                    Item.Text += "<br/><div class='social'>"
                    If q.Facebook <> "" Then
                        Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-facebook' href='" + q.Facebook + "'></a></div>"
                    End If
                    If q.Twitter <> "" Then
                        Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-twitter' href='" + q.Twitter + "'></a></div>"
                    End If
                    'If q.Googleplus <> "" Then
                    '    Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-gplus' href='" + q.Googleplus + "'></a></div>"
                    'End If
                    If q.Linkedin <> "" Then
                        Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-linkedin' href='" + q.Linkedin + "'></a></div>"
                    End If
                    If q.Instagram <> "" Then
                        Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-instagram' href='" + q.Instagram + "'></a></div>"
                    End If
                    If q.Telegram <> "" Then
                        Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-telegram' href='" + q.Telegram + "'><img src='../img/telegram.png' /></a></div>"
                    End If
                    If q.WhatsApp <> "" Then
                        Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-whatsapp' href='" + q.WhatsApp + "'><img src='../img/WhatsApp.png' /></a></div>"
                    End If
                    Item.Text += "<br/><br/></div></div></div>"
                    lblRootPageHref.InnerText = "درباره "
                    lblRootPageHref.HRef = "about/" + Page.RouteData.Values("Person")
                    lblCurrentPage.Text = q.Name_Fa + " " + q.Family_Fa
                    ltrTag.Text += ""
                    For Each i In q.Keyword_Fa.ToString.Split(";")
                        ltrTag.Text += "<a href='/result/" + i.ToString.Replace(" ", "-") + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>" + i.ToString + "</a>"
                        Page.MetaKeywords += i.ToString + ","
                    Next
                    'Item.Text += "<a class='button small solid-button purple' style='float: left;' onclick='history.go(-1)' href='#'> بازگشت</a></div></div><br/><br/>"
                    Page.Title = "درباره‌ی " + q.Name_Fa + " " + q.Family_Fa + " | شرکت نارِم"
                    Dim gender As String
                    If q.IsMan = True Then
                        gender = "آقای "
                    Else
                        gender = "خانم "
                    End If
                    Page.MetaDescription = gender + q.Name_Fa + " " + q.Family_Fa + " به عنوان " + q.Job_Fa + " در شرکت نارم مشغول به فعالیت هستند."
                    If q.Evidence_Fa <> "" Then
                        Page.MetaDescription += "ایشان فارغ التحصیل مقطع " + q.Evidence_Fa
                    End If
                    If q.GraduationLocation_Fa <> "" Then
                        Page.MetaDescription += " از " + q.GraduationLocation_Fa
                    End If
                    If q.GraduationDate_Fa <> "" Then
                        Page.MetaDescription += " در تاریخ " + q.GraduationDate_Fa
                    End If
                    If q.Evidence_Fa <> "" Then
                        Page.MetaDescription += " هستند. "
                    End If
                    Page.MetaKeywords = "شرکت نارم , درباره‌ی " + q.Name_Fa + " " + q.Family_Fa + " , وب سایت نارم , " + q.Evidence_Fa + ", مالی و حسابداری , نرم افزار"
                    MetaIMG = "<meta property='og:image' content='" + q.PhotoMin + "' />"
                    MetaTitle = "<meta property='og:title' content='" + Page.Title + "' />"
                    MetaDesc = "<meta property='og:description' content='" + Page.MetaDescription + "' />"
                    MetaNameSite = "<meta property='og:site_name' content='وب سایت شرکت نارم' />"
                    MetaBrand = "<meta property='og:brand' content='نارم' />"
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
            'Response.Redirect("/Index")
            'Response.Write(ex.Message)
        End Try

    End Sub
End Class
