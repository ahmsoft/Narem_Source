
Partial Class Search
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Title = "نتایج جستجو | شرکت نارِم"
        Page.MetaDescription = "نتایج جستجوی مطالب وب سایت شرکت نارم."
        Page.MetaKeywords = "شرکت نارم , جستجو , وب سایت نارم , هوش مصنوعی , مالی و حسابداری ,  نرم افزار"
        Dim MetaIMG As String = "<meta property='og:image' content='img/search5.png' />"
        Dim MetaTitle As String = "<meta property='og:title' content='" + Page.Title + "' />"
        Dim MetaDesc As String = "<meta property='og:description' content='" + Page.MetaDescription + "' />"
        Dim MetaNameSite As String = "<meta property='og:site_name' content='وب سایت شرکت نارم' />"
        Dim MetaBrand As String = "<meta property='og:brand' content='نارم' />"
        Dim MetaUrl As String = "<meta property='og:url' content='https://narem.ir" + Request.RawUrl + "' />"
        Dim MetaLocal As String = "<meta property='og:locale' content='fa' />"
        Dim MetaAuthor As String = "<meta property='og:article:author' content='امیرحسن مروجی' />"
        Dim MetaType As String = "<meta property='og:type' content='article' />"
        Dim MetaArticelSection As String = "<meta property='og:article:section' content='مقالات' />"
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
        Dim CounterResult As Int16 = 0
        'Dim db = New LinqDBClassesDataContext
        Dim qryMessage = From m In db.Messages
                         Select m Where m.IsShow = True And ((m.Keyword_Fa.ToLower() Like "*" + Trim(Page.RouteData.Values("Search").ToString.Replace("-", " ")).ToLower() + "*") Or (m.Message_Fa.ToLower() Like "*" + Trim(Page.RouteData.Values("Search").ToString.Replace("-", " ")).ToLower() + "*") Or (m.PreMessage_Fa.ToLower() Like "*" + Trim(Page.RouteData.Values("Search").ToString.Replace("-", " ")).ToLower() + "*"))

        For Each q In qryMessage
            Dim ltr = New Literal
            Dim ltrbr = New Literal
            Dim catString As String = "all"
            For Each catelink In q.CatName_En.Split(";")
                catString = catelink
                Exit For
            Next
            CounterResult += 1
            ltr.Text = "<div class='row' style='background-color:#ffffff;padding:20px;box-shadow: 0 2px 4px rgb(200, 200, 200); -moz-box-shadow: 0 2px 4px rgb(200, 200, 200); -webkit-box-shadow: 0 2px 4px rgb(200, 200, 200); outline: 0px; margin-top: 0px; margin-bottom: 2px;'><div class='col-sm-12 padding-fix'><h6>" + q.Moment_Fa.ToString.Remove(q.Moment_Fa.ToString.Length - 8, 8) + " نوشته شده توسط <a href='/about/" + q.WrittenBy_En.Replace(" ", "-").ToLower() + "'>" + q.WrittenBy_Fa + "</a></h5><h4 style='margin-top:-20px;'><span class='fa fa-pencil-square-o'></span> <a href='/posts/" + catString.Replace(" ", "-").ToLower() + "/" + q.Title_En.Replace(" ", "-").ToLower() + "/" + q.IDMessage.ToString + "'>" + q.Title_Fa + "</a></h2></div></div>"
            ltr.Text += "<div class='row' style='background-color:#ffffff;box-shadow: 0 2px 4px rgb(200, 200, 200); -moz-box-shadow: 0 2px 4px rgb(200, 200, 200); -webkit-box-shadow: 0 2px 4px rgb(200, 200, 200); padding: 4px; outline: 0px; margin-top: 0px; margin-bottom: 0px;'><div class='col-sm-12'> کلمات کلیدی: "
            For Each i In q.Keyword_Fa.ToString.Split(";")
                ltr.Text = ltr.Text + "<a href='/result/" + i.ToString.Replace(" ", "-") + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>" + i.ToString + "</a>"
            Next

            ltr.Text += "<a href='/posts/" + catString.Replace(" ", "-").ToLower() + "/" + q.Title_En.Replace(" ", "-").ToLower() + "/" + q.IDMessage.ToString + "' class='btn btn-info' style='float:left;margin-left:50px;'>نمایش</a></div></div><br/>"
            PostsPlaceHolder.Controls.Add(ltr)
        Next
        Dim qryNews = From m In db.News1s
                      Select m Where m.IsShow = True And ((m.Keyword_Fa.ToLower() Like "*" + Trim(Page.RouteData.Values("Search").ToString.Replace("-", " ")).ToLower() + "*") Or (m.MSG_Fa.ToLower() Like "*" + Trim(Page.RouteData.Values("Search").ToString.Replace("-", " ")).ToLower() + "*") Or (m.PreMSG_Fa.ToLower() Like "*" + Trim(Page.RouteData.Values("Search").ToString.Replace("-", " ")).ToLower() + "*"))

        For Each q In qryNews
            Dim ltr = New Literal
            Dim ltrbr = New Literal
            Dim catString As String = "all"
            For Each catelink In q.CatName_En.Split(";")
                catString = catelink
                Exit For
            Next
            CounterResult += 1
            ltr.Text = "<div class='row' style='background-color:#ffffff;padding:20px;box-shadow: 0 2px 4px rgb(200, 200, 200); -moz-box-shadow: 0 2px 4px rgb(200, 200, 200); -webkit-box-shadow: 0 2px 4px rgb(200, 200, 200); outline: 0px; margin-top: 0px; margin-bottom: 2px;'><div class='col-sm-12 padding-fix'><h6>" + q.Moment_Fa.ToString.Remove(q.Moment_Fa.ToString.Length - 8, 8) + " نوشته شده توسط <a href='/about/" + q.WrittenBy_En.Replace(" ", "-").ToLower() + "'>" + q.WrittenBy_Fa + "</a></h5><h4 style='margin-top:-20px;'><span class='fa fa-pencil-square-o'></span> <a href='/news/" + catString.Replace(" ", "-").ToLower() + "/" + q.Title_En.Replace(" ", "-").ToLower() + "/" + q.IDN.ToString + "'>" + q.Title_Fa + "</a></h2></div></div>"
            ltr.Text += "<div class='row' style='background-color:#ffffff;box-shadow: 0 2px 4px rgb(200, 200, 200); -moz-box-shadow: 0 2px 4px rgb(200, 200, 200); -webkit-box-shadow: 0 2px 4px rgb(200, 200, 200); padding: 4px; outline: 0px; margin-top: 0px; margin-bottom: 0px;'><div class='col-sm-12'> کلمات کلیدی: "
            For Each i In q.Keyword_Fa.ToString.Split(";")
                ltr.Text = ltr.Text + "<a href='/result/" + i.ToString.Replace(" ", "-") + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>" + i.ToString + "</a>"
            Next

            ltr.Text += "<a href='/news/" + catString.Replace(" ", "-").ToLower() + "/" + q.Title_En.Replace(" ", "-").ToLower() + "/" + q.IDN.ToString + "' class='btn btn-info' style='float:left;margin-left:50px;'>نمایش</a></div></div><br/>"
            PostsPlaceHolder.Controls.Add(ltr)
        Next

        Dim qryFAQ = From m In db.FAQms
                     Select m Where m.IsShow = True And ((m.Keyword_Fa.ToLower() Like "*" + Trim(Page.RouteData.Values("Search").ToString.Replace("-", " ")).ToLower() + "*") Or (m.Answer_Fa.ToLower() Like "*" + Trim(Page.RouteData.Values("Search").ToString.Replace("-", " ")).ToLower() + "*") Or (m.Answer_Fa.ToLower() Like "*" + Trim(Page.RouteData.Values("Search").ToString.Replace("-", " ")).ToLower() + "*") Or (m.Question_Fa.ToLower() Like "*" + Trim(Page.RouteData.Values("Search").ToString.Replace("-", " ")).ToLower() + "*"))

        For Each q In qryFAQ
            Dim ltr = New Literal
            Dim ltrbr = New Literal
            Dim catString As String = "all"
            For Each catelink In q.CatName_En.Split(";")
                catString = catelink
                Exit For
            Next
            CounterResult += 1
            ltr.Text = "<div class='row' style='background-color:#ffffff;padding:20px;box-shadow: 0 2px 4px rgb(200, 200, 200); -moz-box-shadow: 0 2px 4px rgb(200, 200, 200); -webkit-box-shadow: 0 2px 4px rgb(200, 200, 200); outline: 0px; margin-top: 0px; margin-bottom: 2px;'><div class='col-sm-12 padding-fix'><h6>" + q.Moment_Fa.ToString.Remove(q.Moment_Fa.ToString.Length - 8, 8) + " پرسیده شده توسط <a style='text-decoration:none;'>" + q.AskedBy_Fa + "</a></h5><h4 style='margin-top:-20px;'><span class='fa fa-question-circle'></span> <a href='/faq/" + catString.Replace(" ", "-").ToLower() + "/" + q.Question_En.Replace(" ", "-").ToLower() + "/" + q.IDF.ToString + "'>" + q.Question_Fa + "</a></h2></div></div>"
            ltr.Text += "<div class='row' style='background-color:#ffffff;box-shadow: 0 2px 4px rgb(200, 200, 200); -moz-box-shadow: 0 2px 4px rgb(200, 200, 200); -webkit-box-shadow: 0 2px 4px rgb(200, 200, 200); padding: 4px; outline: 0px; margin-top: 0px; margin-bottom: 0px;'><div class='col-sm-12'> کلمات کلیدی: "
            For Each i In q.Keyword_Fa.ToString.Split(";")
                ltr.Text = ltr.Text + "<a href='/result/" + i.ToString.Replace(" ", "-") + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>" + i.ToString + "</a>"
            Next

            ltr.Text += "<a href='/faq/" + catString.Replace(" ", "-").ToLower() + "/" + q.Question_En.Replace(" ", "-").ToLower() + "/" + q.IDF.ToString + "' class='btn btn-info' style='float:left;margin-left:50px;'>نمایش</a></div></div><br/>"
            FAQPlaceHolder.Controls.Add(ltr)
        Next
        Dim qryPages = From m In db.Pages
                       Select m Where (m.Keyword_Fa.ToLower() Like "*" + Trim(Page.RouteData.Values("Search").ToString.Replace("-", " ")).ToLower() + "*") Or (m.Body_Fa.ToLower() Like "*" + Trim(Page.RouteData.Values("Search").ToString.Replace("-", " ")).ToLower() + "*") Or (m.PageTitle_Fa.ToLower() Like "*" + Trim(Page.RouteData.Values("Search").ToString.Replace("-", " ")).ToLower() + "*")

        For Each q In qryPages
            Dim ltr = New Literal
            Dim ltrbr = New Literal
            CounterResult += 1
            ltr.Text = "<div class='row' style='background-color:#ffffff;padding:20px;box-shadow: 0 2px 4px rgb(200, 200, 200); -moz-box-shadow: 0 2px 4px rgb(200, 200, 200); -webkit-box-shadow: 0 2px 4px rgb(200, 200, 200); outline: 0px; margin-top: 0px; margin-bottom: 2px;'><div class='col-sm-12 padding-fix'><h6> صفحه‌ای با عنوان</h5><h4 style='margin-top:-20px;'><span class='fa fa-pencil-square-o'></span> <a href='/pages/" + q.PageTitle_En.Replace(" ", "-").ToLower() + "/" + q.ID.ToString + "'>" + q.PageTitle_Fa + "</a></h2></div></div>"
            ltr.Text += "<div class='row' style='background-color:#ffffff;box-shadow: 0 2px 4px rgb(200, 200, 200); -moz-box-shadow: 0 2px 4px rgb(200, 200, 200); -webkit-box-shadow: 0 2px 4px rgb(200, 200, 200); padding: 4px; outline: 0px; margin-top: 0px; margin-bottom: 0px;'><div class='col-sm-12'> کلمات کلیدی: "
            For Each i In q.Keyword_Fa.ToString.Split(";")
                ltr.Text = ltr.Text + "<a href='/result/" + i.ToString.Replace(" ", "-") + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>" + i.ToString + "</a>"
            Next
            ltr.Text += "<a href='/pages/" + q.PageTitle_En.Replace(" ", "-").ToLower() + "/" + q.ID.ToString + "' class='btn btn-info' style='float:left;margin-left:50px;'>نمایش</a></div></div><br/>"
            PagesPlaceHolder.Controls.Add(ltr)
        Next
        lblSearchCount.Text = CounterResult
        Page.MetaDescription = CounterResult.ToString + " نتیجه جستجوی مطالب برای عبارت '" + Page.RouteData.Values("Search").ToString.Replace("-", " ") + "' در وب سایت شرکت نارم."
        MetaDesc = "<meta property='og:description' content='" + Page.MetaDescription + "' />"
        litMeta.Text = MetaIMG + MetaTitle + MetaDesc + MetaNameSite + MetaBrand + MetaUrl + MetaLocal + MetaAuthor + MetaArticelSection

        lblSearchCount.Text = CounterResult

    End Sub
    Public Function Substr(InputText As String, StartIndex As Integer, Length As Integer) As String
        Return InputText.Substring(StartIndex, Length) + " ... "
    End Function

End Class
