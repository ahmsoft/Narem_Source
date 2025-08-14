
Partial Class ContactUs
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Title = "پل‌های ارتباط با شرکت نارِم"
        Page.MetaDescription = "ساعات کاری و معرفی روش‌های برقراری تماس با شرکت نارم، بصورت حضوری و غیر حضوری"
        Page.MetaKeywords = "شرکت نارم , تماس با ما , وب سایت نارم , هوش مصنوعی , مالی و حسابداری ,  نرم افزار"
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
                                            Item.Text += "<li><a href='" + t.Href + "'>" + t.Name_Fa + "</a></li>"
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
        'Try
        '    If Request.QueryString("Search").ToString <> "" Then
        '        Response.Redirect("/Result?Search=" + Request.QueryString("Search").ToString)
        '    End If
        'Catch ex As Exception

        'End Try
        Try
            Dim qrySetting = From m In db.Settings
                             Select m Order By
                                          m.IDS
            For Each q In qrySetting
                ltrAddress.Text = q.Address1_Fa
                'lblCopyWrite.Text =q.CopyWrite_Fa
                ltrWorkingHours.Text = q.WorkingHours_Fa
                ltrTel1.Text = "<a style='color:rgba(0, 0, 0, 0.8);text-decoration:none;' rel='nofollow' href='tel:" + q.TEL1 + "'>" + q.TEL1 + "</a>"
                ltrTel2.Text = "<a style='color:rgba(0, 0, 0, 0.8);text-decoration:none;' rel='nofollow' href='tel:" + q.TEL2 + "'>" + q.TEL2 + "</a>"
                If q.Facebook <> "" Then
                    ltrSocialNetworks.Text += "<a class='sbtnf sbtnf-rounded color color-hover icon-facebook' href='" + q.Facebook + "'></a>"
                End If
                If q.Twitter <> "" Then
                    ltrSocialNetworks.Text += "<a class='sbtnf sbtnf-rounded color color-hover icon-twitter' href='" + q.Twitter + "'></a>"
                End If
                'If q.Googleplus <> "" Then
                '    ltrSocialNetworks.Text += "<a class='sbtnf sbtnf-rounded color color-hover icon-gplus' href='" + q.Googleplus + "'></a>"
                'End If
                If q.Linkedin <> "" Then
                    ltrSocialNetworks.Text += "<a class='sbtnf sbtnf-rounded color color-hover icon-linkedin' href='" + q.Linkedin + "'></a>"
                End If
                If q.Instagram <> "" Then
                    ltrSocialNetworks.Text += "<a class='sbtnf sbtnf-rounded color color-hover icon-instagram' href='" + q.Instagram + "'></a>"
                End If
                If q.Telegram <> "" Then
                    ltrSocialNetworks.Text += "<a class='sbtnf sbtnf-rounded color color-hover icon-telegram' href='" + q.Telegram + "'><img src='../img/telegram.png' /></a>"
                End If
                If q.WhatsApp <> "" Then
                    ltrSocialNetworks.Text += "<a class='sbtnf sbtnf-rounded color color-hover icon-whatsapp' href='" + q.WhatsApp + "'><img src='../img/WhatsApp.png' /></a>"
                End If

            Next
        Catch ex As Exception

        End Try
    End Sub

End Class
