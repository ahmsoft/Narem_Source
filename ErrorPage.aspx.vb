
Partial Class ErrorPage
    Inherits System.Web.UI.Page
    'TODO: صفحه نمایش خطا تنظیم شود

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Title = "صفحه مورد نظر وجود ندارد | شرکت نارِم"
        Page.MetaDescription = "آدرس صفحه‌ای که وارد نموده‌اید درحال حاضر وجود ندارد و در دسترس نمی‌باشد. لطفا آن را اصلاح و مجددا تلاش نمایید."
        Page.MetaKeywords = "شرکت نارم , خطا , وب سایت نارم , هوش مصنوعی , مالی و حسابداری ,  نرم افزار"
        Dim MetaIMG As String = "<meta property='og:image' content='img/Under-construction.png' />"
        Dim MetaTitle As String = "<meta property='og:title' content='صفحه مورد نظر وجود ندارد | شرکت نارِم' />"
        Dim MetaDesc As String = "<meta property='og:description' content='آدرس صفحه‌ای که وارد نموده‌اید درحال حاضر وجود ندارد و در دسترس نمی‌باشد. لطفا آن را اصلاح و مجددا تلاش نمایید .' />"
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
        'Page.ClientScript.RegisterStartupScript(Me.GetType(), "randomtext", "alertsucsses()", True)
        Try
            '    Dim lblLang As Label = Master.FindControl("lblLang")
            '    Dim lblLang1 As Label = Master.FindControl("lblLang1")
            '    Dim lblSearchText As Label = Master.FindControl("lblSearchText")
            '    Dim lblContactAtTheMoment As Label = Master.FindControl("lblContactAtTheMoment")
            '    Dim lblSiteName As Label = Master.FindControl("lblSiteName")
            '    Dim lblRapilyContact As Label = Master.FindControl("lblRapilyContact")
            '    Dim lblMenuTitle As Label = Master.FindControl("lblMenuTitle")
            '    Dim lblNameAndFamily As Label = Master.FindControl("lblNameAndFamily")
            '    Dim lblJob As Label = Master.FindControl("lblJob")
            '    Dim lblTagNameAndFamily As Label = Master.FindControl("lblTagNameAndFamily")
            '    Dim lblTagEmail As Label = Master.FindControl("lblTagEmail")
            '    Dim lblTagWebsite As Label = Master.FindControl("lblTagWebsite")
            '    Dim lblTagMessage As Label = Master.FindControl("lblTagMessage")
            '    Dim lblTagSocialNetwork As Label = Master.FindControl("lblTagSocialNetwork")
            '    Dim lblTagAddress As Label = Master.FindControl("lblTagAddress")
            '    Dim lblTageSocial As Label = Master.FindControl("lblTageSocial")
            '    Dim lblTagContactUs As Label = Master.FindControl("lblTagContactUs")
            '    Dim lblDisignBy As Label = Master.FindControl("lblDisignBy")
            '    lblDisignBy.Text="طراحی و توسعه توسط <a href='http://www.narem.ir'>شرکت نگار اعتبار رایان مبنا (نارم)</a>"
            '    lblTagNameAndFamily.Text ="نام و نام خانوادگی"
            '    lblTagEmail.Text="ایمیل"
            '    lblTagWebsite.Text="وب سایت"
            '    lblTagMessage.Text ="پیام"
            '    lblTagSocialNetwork.Text ="شبکه‌های اجتماعی"
            '    lblTagAddress.Text = "آدرس"
            '    lblTageSocial.Text="صفحه‌های اجتماعی"
            '    lblTagContactUs.Text="تماس با ما"
            '    lblNameAndFamily.Text = "احسان شریعتی"
            '    lblJob.Text = "فیلسوف ایرانی"
            '    lblLang.Text = "FA"
            '    lblLang1.Text = "FA"
            '    lblMenuTitle.Text = " منو "
            '    lblRapilyContact.Text = "<a href='Index#section6' class='available'><i class='ion-ios-email-outline'></i><span>ارسال سریع ایمیل به من</span></a>"
            '    lblSearchText.Text = "متن را وارد کنید و کلید enter را بزنید"
            '    lblContactAtTheMoment.Text = "همین حالا با من تماس بگیرید"
            '    lblSiteName.Text = "وب سایت رسمی احسان شریعتی"
            '    'lblState.Text = "درباره شرکت و سایت نارم"
            '    Response.Cookies("Lang").Value = ""
            '
            Dim lblMenu As Label = Master.FindControl("lblMasterMenu")
            Dim db = New LinqDBClassesDataContext
            Dim qryMenu = From m In db.Menus
                          Select m Order By
                                       m.IDM Descending Where m.IsShow = True
            Dim Item = New Label
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
            lblMenu.Text = Item.Text
        Catch ex As Exception

            Response.Write(ex.Message)
        End Try
    End Sub
End Class
