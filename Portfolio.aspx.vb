
Partial Class Portfolio
    Inherits System.Web.UI.Page
    Public Function IsMobile() As Boolean
        Dim userAgent As String = Request.ServerVariables("HTTP_USER_AGENT")
        Dim OS As New Regex("(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        Dim device As New Regex("1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        Dim device_info As String = String.Empty
        If OS.IsMatch(userAgent) Then
            device_info = OS.Match(userAgent).Groups(0).Value
        End If
        If device.IsMatch(userAgent.Substring(0, 4)) Then
            device_info += device.Match(userAgent).Groups(0).Value
        End If
        If Not String.IsNullOrEmpty(device_info) Then
            'Response.Redirect(Convert.ToString("index.aspx?device_info=") & device_info)
            'MsgBox("You are using a Mobile device. " + Request.QueryString("device_info"))
            IsMobile = True
            Exit Function
        End If
        IsMobile = False
    End Function
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Title = "نمونه الگوهای طراحی وب سایت - نارِم"
        Page.MetaDescription = "شما می‌توانید با انتخاب یک یا جند نمونه الگو از نمونه‌های موجود ما را در طراحی وب سایت اختصاصی خود یاری کنید."
        Page.MetaKeywords = "شرکت نارم , الگو , نمونه کار , وب سایت نارم , هوش مصنوعی , مالی و حسابداری ,  نرم افزار"
        Dim MetaIMG As String = "<meta property='og:image' content='/Uploads/Contents/Posts/CropFromCenter.png' />"
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

        Try
            Dim ltrMenu As Literal = Master.FindControl("ltrMasterMenu")
            Dim db = New LinqDBClassesDataContext
            Dim qryMenu = From m In db.Menus
                          Select m Order By
                                       m.IDM Descending Where m.IsShow = True
            Dim Item = New Literal
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
            Dim Cover As String = "6"
            'lblGalleryPortfolio.Text = ""
            Try
                Dim PortfolioGalley = From m In db.PortfolioGalleries
                                      Select m Where m.IDP = Request.QueryString("ID").ToString
                For Each PortfolioG In PortfolioGalley
                    ltrGalleryPortfolio.Text += "<div class='span" + Cover + "' style='background-color:white;box-shadow:rgba(0,0,0,0.3) 5px 2px;margin-bottom:5px;'><a class='highslide' onclick='return hs.expand(this, 1 )' href='" + PortfolioG.SRC + "'><img alt='" + PortfolioG.Alt_Fa + "' src='" + PortfolioG.SRC + "' style='margin: 1px; box-shadow: #c8c8c8 0px 2px 4px;' class='img-responsive' /><center><span style='padding: 0px 10px 0px 10px;border-radius: 3px;text-decoration: none;'><b>" + PortfolioG.Name_Fa + "</b></span></center></a></div>"
                    Cover = "2"

                Next
                'GalleryPlaceHolder.Controls.Add(lblPortfolioGallery)
            Catch ex As Exception
                'Response.Redirect("/index")
                Response.Write(ex.Message)
            End Try
            ltrPortfCat.Text = "<a href='#' class='active' data-filter='*'>همه</a>"
            Try
                Dim PortfolioCat = From m In db.PortfolioCats
                                   Select m
                For Each Cat In PortfolioCat
                    ltrPortfCat.Text += "<a href='#' data-filter='" + Cat.DataFilter + "'>" + Cat.CatName + "</a>"
                Next
            Catch ex As Exception
                'Response.Redirect("/index")
                Response.Write(ex.Message)
            End Try
            ltrPortfo.Text = ""
            Try
                Dim Portfolio = From m In db.Portfolios
                                Select m
                For Each Portf In Portfolio
                    Dim catString As String = "websitetype"
                    For Each catelink In Portf.CatName_En.Split(";")
                        catString = catelink.Replace(" ", "-").ToLower()
                        Exit For
                    Next
                    ltrPortfo.Text += "<div class='span3 " + Portf.CatName_En.Replace(";", " ") + " '><a target='_Blank' href='portfolio?Cat=" + catString + "&Title=" + Portf.Title_En.Replace(" ", "-").ToLower() + "&ID=" + Portf.IDP.ToString() + "' class='work'><img src='" + Portf.Image + "' width='370' height='270' alt='" + Portf.Title_Fa + "'><span class='shadow'></span><div class='bg-hover'></div><div class='work-title'><h3 class='title'>" + Portf.Title_Fa + "</h3><div class='description'>" + Portf.CatName_Fa.Replace(";", " | ") + "</div></div></a></div>"
                    If Portf.IDP = Request.QueryString("ID").ToString Then
                        ltrCatName_Fa.Text = ""
                        For Each i In Portf.CatName_Fa.Split(";")
                            ltrCatName_Fa.Text += "<span class='btn-info' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>" + i.ToString + "</span>"
                        Next
                        ltrCurrentPage.Text = "<span>" + Portf.Title_Fa + "</span>"
                        ltrIDP.Text = "<b>" + Portf.IDP.ToString + "</b>"
                        ltrTitle_Fa.Text = "<b>" + Portf.Title_Fa + "</b>"
                        ltrTitle1_Fa.Text = "<b>" + Portf.Title_Fa + "</b>"
                        ltrMoment_Fa.Text = "<b>" + Portf.Moment_Fa.ToString.Remove(Portf.Moment_Fa.ToString.Length - 8, 8) + "</b>"
                        ltrDescription_Fa.Text = "<b>" + Portf.Description_Fa + "</b>"
                        ltrKeyword_Fa.Text = ""
                        For Each i In Portf.Keyword_Fa.Split(";")
                            ltrKeyword_Fa.Text += "<a href='/result/" + i.ToString.Replace(" ", "-") + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>" + i.ToString + "</a>"
                        Next
                        ltrBtnView.Text = "<a class='btn btn' href='" + Portf.Href + "'>نمایش آنلاین</a>"
                        MetaIMG = "<meta property='og:image' content='" + Portf.Image + "' />"
                        MetaTitle = "<meta property='og:title' content='نمونه کار " + Portf.Title_Fa + "' />"
                        MetaDesc = "<meta property='og:description' content='" + Portf.MetaDescription_Fa + "' />"
                    End If
                Next
            Catch ex As Exception
                Response.Redirect("/portfolios")
                Response.Write(ex.Message)
            End Try
            lblRootPageHref.InnerText = "نمونه کارها و الگوها"
            lblRootPageHref.HRef = "/Portfolio/"

        Catch ex As Exception

            Response.Write(ex.Message)
        End Try
        litMeta.Text = MetaIMG + MetaTitle + MetaDesc + MetaNameSite + MetaBrand + MetaUrl + MetaLocal + MetaAuthor + MetaArticelSection
    End Sub

End Class
