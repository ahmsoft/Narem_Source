
Partial Class News
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Title = "آرشیو خبری - نارِم"
        Page.MetaDescription = "نمایش برخی از اخبار اخیرا ارسال شده شرکت نارم."
        Page.MetaKeywords = "شرکت نارم , اخبار سایت , وب سایت نارم , هوش مصنوعی , مالی و حسابداری ,  نرم افزار"
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
        Try
            Dim ltrCat = New Literal
            Dim CAT = From m In db.Categories
                      Select m Order By m.Priority Ascending, m.IDCat Ascending

            ltrCat.Text = "<aside class='list'><header><h3>دسته‌بندی‌ها<h3></header><ul>"
            For Each b In CAT
                'lblCat.ToolTip = b.CatName_Fa
                Try
                    If b.CatName_En.ToLower() = Page.RouteData.Values("CatName").ToString.Replace("-", " ") Then
                        ltrCat.Text += "<li><a style='color:White;background-color:#7baa00;padding-left:5px;padding-right:5px;border-radius:5px;font-size:15px;' href='/news/" + b.CatName_Fa.ToString.Replace(" ", "-").ToLower() + "/' title='" + b.Description_Fa + "'>" + b.CatName_Fa + "</a></li>"
                    Else

                        ltrCat.Text += "<li><a href='/news/" + b.CatName_En.ToString.Replace(" ", "-").ToLower() + "/' title='" + b.Description_Fa + "'>" + b.CatName_Fa + "</a></li>"
                    End If
                Catch ex As Exception
                    ltrCat.Text += "<li><a href='/news/" + b.CatName_En.ToString.Replace(" ", "-").ToLower() + "' title='" + b.Description_Fa + "'>" + b.CatName_Fa + "</a></li>"
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
        Catch ex As Exception
            Response.Redirect("/index")
            'Response.Write(ex.Message)
        End Try

        lblRootPageHref.InnerText = "آرشیو اخبار"
        lblRootPageHref.HRef = "/news/all/"
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

End Class
