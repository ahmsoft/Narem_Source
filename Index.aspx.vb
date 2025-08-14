Imports System.Text.RegularExpressions

Partial Class Index
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
        Page.Title = "شرکت طراحی سایت - نارم"
        Page.MetaDescription = "میزبانی و طراحی انواع وب سایت، سیستم‌های هوش مصنوعی، ارائه خدمات مالی و حسابداری از جمله فعالیت‌های شرکت نارم می‌باشد."
        Page.MetaKeywords = "شرکت نارم , طراحی سایت , میزبانی وب , هاستیگ , وب سایت نارم , هوش مصنوعی , مالی و حسابداری ,  نرم افزار"
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
            If (Page.RouteData.Values("Search") <> Nothing) Then
                If (Page.RouteData.Values("Search").ToString.Replace("-", " ") IsNot Nothing) Or (Page.RouteData.Values("Search").ToString.Replace("-", " ") <> "") Then
                    Response.Redirect("/result/" + Page.RouteData.Values("Search").ToString.Replace("-", " "))
                End If
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
            '    lblHomePage.Text = Item.Text
            Dim qryPortfolios = From m In db.Portfolios
                                Select m Order By
                                                m.IDP Ascending
            ltrBanners.Text = "<h4 style='text-align:right;direction:rtl;padding:60px 30px 10px 5px;'>برخی از نمونه کارهای طراحی وب سایت شرکت نارم</h4><div class='banner-set load'><div class='container'><div class='banners'>"
            For Each q In qryPortfolios
                Dim catString As String = "websitetype"
                For Each catelink In q.CatName_En.Split(";")
                    catString = catelink.Replace(" ", "-").ToLower()
                    Exit For
                Next
                'TODO: برای کتگوری حلقه Foreach بذارید.
                Item.Text += "<a target='_self' href='portfolio?Cat=" + catString + "&Title=" + q.Title_En.Replace(" ", "-").ToLower() + "&ID=" + q.IDP.ToString() + "' class='banner'><img src='" + q.Image + "' width='253' height='158' alt='" + q.Title_Fa + "'><h2 class='title'>" + q.Title_Fa + "</h2><div class='description'>" + q.Description_Fa + "</div></a>"
            Next
            ltrBanners.Text += Item.Text + "</div><!-- .banners --><div class='clearfix'></div></div><div class='nav-box'><div class='container'><a class='prev' href='#'><i class='icon-arrow-left'></i></a><div class='pagination switches'></div><a class='next' href='#'><i class='icon-arrow-right'></i></a></div></div></div>"
            Item.Text = ""
            Dim c As Integer = 0
            Dim coc As Integer = 0
            If IsMobile() = False Then
                Item.Text = "<div class='carousel-box load overflow' data-carousel-pagination='true' data-carousel-nav='false' data-carousel-one='true'><div class='title-box'><a class='next' href='#'><svg version='1.1' xmlns='http//www.w3.org/2000/svg' xmlns:xlink='http//www.w3.org/1999/xlink' x='0px' y='0px'width='9px' height='16px' viewBox='0 0 9 16' enable-background='New 0 0 9 16' xml:space='preserve'><polygon fill-rule='evenodd' clip-rule='evenodd' fill='#fcfcfc' points='1,0.001 0,1.001 7,8 0,14.999 1,15.999 9,8 ' /></svg></a><a class='prev' href='#'><svg version='1.1' xmlns='http//www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' x='0px' y='0px'width='9px' height='16px' viewBox='0 0 9 16' enable-background='New 0 0 9 16' xml:space='preserve'><polygon fill-rule='evenodd' clip-rule='evenodd' fill='#fcfcfc' points='8,15.999 9,14.999 2,8 9,1.001 8,0.001 0,8 ' /></svg></a><h2 class='title'>آخرین اخبار</h2><a href='/news/all/' class='btn btn-inverse' style='text-align Left();'>آرشیو اخبار <i class='icon-arrow-right icon-white'></i></a></div><div class='clearfix'></div><div class='row' style='text-align Right(); direction: rtl;'><div class='carousel no-responsive'><div class='post span6'>"
                Dim qry = From m In db.News1s
                          Select m Order By m.Year_En Descending, m.Month_En Descending, m.Day_En Descending
                                       , m.Priority Descending, m.IDN Descending Where (m.IsShow = True) And (m.Title_Fa <> "")
                For Each q In qry
                    'Dim lblbr = New Label
                    'lblbr.Text = "<p/>"
                    Dim qryComment = From p In db.Comments
                                     Select p Where (p.IsShow = True) And (p.Action = "news") And (p.Active = True) And p.IDElement = q.IDN
                    For Each j In qryComment
                        coc += 1
                    Next
                    Dim catString As String = "all"
                    For Each catelink In q.CatName_En.Split(";")
                        catString = catelink
                        Exit For
                    Next
                    Item.Text += "<h2 class='entry-title'><a href='/news/" + catString.Replace(" ", "-").ToLower() + "/" + q.Title_En.Replace(" ", "-").ToLower() + "/" + q.IDN.ToString() + "'>" + q.Title_Fa + "</a></h2><div class='entry-content'><a class='highslide' onclick='return hs.expand(this, 1 )' href='" + q.Pic.ToLower() + "'><img class='image img-circle appear-animation rotateIn appear-animation-visible' style='width:60px;height:60px;float:right;padding:0px;' src='" + q.Pic.ToLower() + "' alt='" + q.Title_Fa + "' title='" + q.WrittenBy_Fa + "' data-appear-animation='rotateIn'></a><a href='/news/" + catString.Replace(" ", "-").ToLower() + "/" + q.Title_En.Replace(" ", "-").ToLower() + "/" + q.IDN.ToString() + "' style='text-decoration:none;color:#1e1e1e;'>" + q.PreMSG_Fa + "</div></a><div class='entry-meta'><span class='autor-name'>نوشته شده توسط " + q.WrittenBy_Fa + "</span> در <span class='time'>" + q.Moment_Fa.ToString.Remove(q.Moment_Fa.ToString.Length - 8, 8) + "</span><span class='separator'> | </span><span class='desktopItem'><a href='/news/" + catString.Replace(" ", "-").ToLower() + "/" + q.Title_En.Replace(" ", "-").ToLower() + "/" + q.IDN.ToString() + "' style='text-decoration:none;border-color: #00f;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>ادامه مطلب و ثبت دیدگاه</a></span>"
                    '<span class='separator'> | </span><div class='field field-name-field-category field-type-taxonomy-term-reference field-label-hidden'>
                    Item.Text += "</span><span class='comments-link pull-left'><a>" + coc.ToString + " بازخورد</a></span>"
                    Item.Text += "<br><hr/><span class='meta desktopItem'>برچسب‌ها: "
                    For Each i In q.Keyword_Fa.ToString.Split(";")
                        Item.Text = Item.Text + "<a href='/result/" + i.ToString.Replace(" ", "-").ToLower() + "' class='btn-info' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>" + i.ToString + "</a> "
                        Page.MetaKeywords += i.ToString + ","
                    Next
                    Item.Text += "</div>"
                    'Page.MetaDescription = q.AboutSite
                    c += 1
                    If c = 3 Then
                        Exit For
                    Else
                        Item.Text += "</div><div class='post span6'>"
                    End If
                Next
                ltrNews.Text = Item.Text + "</div></div></div><div class='clearfix'></div><div class='pagination switches'></div></div>"
            ElseIf IsMobile() = True Then
                c = 0
                Item.Text = "<div class='title-box'><a href='/news/all/' class='btn btn-inverse' style='text-align Left();'>آرشیو خبری <i class='icon-arrow-right icon-white'></i></a><h2 class='title'>آخرین اخبار</h2></div><ul class='latest-posts'>"
                Dim qry = From m In db.News1s
                          Select m Order By m.Year_En Descending, m.Month_En Descending, m.Day_En Descending
                                       , m.Priority Descending, m.IDN Descending Where (m.IsShow = True) And (m.Title_Fa <> "")
                For Each q In qry
                    'Dim lblbr = New Label
                    'lblbr.Text = "<p/>"
                    Dim qryComment = From p In db.Comments
                                     Select p Where (p.IsShow = True) And (p.Action = "news") And (p.Active = True) And p.IDElement = q.IDN
                    For Each j In qryComment
                        coc += 1
                    Next
                    Dim catString As String = "all"
                    For Each catelink In q.CatName_En.Split(";")
                        catString = catelink
                        Exit For
                    Next
                    Item.Text += "<li class='ahm-hover'><a class='highslide' onclick='return hs.expand(this, 1 )' href='" + q.Pic + "'><img class='image img-circle' style='width:60px;height:60px;' src='" + q.Pic + "' alt='" + q.WrittenBy_Fa + "' title='' data-appear-animation='rotateIn'></a><div class='meta'><span>منتشر شده توسط <a href='/about/narem'>" + "شرکت نارم" + "</a></span> در <span class='time'>" + q.Moment_Fa.ToString.Remove(q.Moment_Fa.ToString.Length - 8, 8) + "</span></div><div class='description'><a href='/news/" + catString.ToString().ToLower() + "/" + q.Title_En.ToString().Replace(" ", "-").ToLower() + "/" + q.IDN.ToString() + "'>" + q.Title_Fa + "</a></div></li>"
                    'Page.MetaDescription = q.AboutSite
                    c += 1
                    If c = 3 Then
                        Exit For
                    End If
                Next
                ltrNews.Text = Item.Text + "</ul>"
            End If
            Item.Text = ""
            Dim qryFAQ = From m In db.FAQms
                         Select m Order By m.Year_En Descending, m.Month_En Descending, m.Day_En Descending
                                   , m.Priority Descending, m.IDF Descending Where m.IsShow = True And (m.Question_Fa <> "")

            'lblFAQ.Text = "<div class='container'>"
            c = 0
            For Each q In qryFAQ
                'Dim lblbr = New Label
                'lblbr.Text = "<p/>"
                If c < 1 Then
                    Item.Text += "<div class='accordion no-bg some-accordion' id='accordion" + q.IDF.ToString + "'><div class='accordion-group active'><div class='accordion-heading'><a class='accordion-toggle' data-toggle='collapse' data-parent='#accordion" + q.IDF.ToString + "' href='#collapse" + q.IDF.ToString + "'>" + q.Question_Fa + "</a></div><div id='collapse" + q.IDF.ToString + "' class='accordion-body collapse in'><div class='accordion-inner'>" + q.Answer_Fa + "</div></div></div></div>"

                Else
                    Item.Text += "<div class='accordion no-bg some-accordion' id='accordion" + q.IDF.ToString + "'><div class='accordion-group'><div class='accordion-heading'><a class='accordion-toggle' data-toggle='collapse' data-parent='#accordion" + q.IDF.ToString + "' href='#collapse" + q.IDF.ToString + "'>" + q.Question_Fa + "</a></div><div id='collapse" + q.IDF.ToString + "' class='accordion-body collapse'><div class='accordion-inner'>" + q.Answer_Fa + "</div></div></div></div>"

                End If
                c += 1
                If c = 5 Then
                    Exit For
                End If
            Next
            ltrFAQ.Text = Item.Text
            Item.Text = ""
            'Dim qry1 = From m In db.Users
            '           Select m Order By m.Name_Fa Where m.Username <> "narem"
            'For Each q In qry1
            '    For Each Auth In q.Authoritys.ToString.Split(";")
            '        If Auth = "Admin" Then
            '            Item.Text += "<div class='span3 employee rotation'><div class='default'><div class='image'><img src='" + q.PhotoMax + "' alt='" + q.Name_Fa + " " + q.Family_Fa + "' title='" + q.Job_Fa + "' width='270' height='270'></div><div class='description'><div class='vertical'><h3 class='name'>" + q.Name_Fa + " " + q.Family_Fa + "</h3><div class='role'>" + q.Job_Fa + "</div></div></div></div><div class='employee-hover'><h3 class='name'>" + q.Name_Fa + " " + q.Family_Fa + "</h3><div class='role'>" + q.Evidence_Fa + "</div><div class='image'><img src='" + q.PhotoMin + "' alt='" + q.Memo_Fa + "' title='" + q.Name_Fa + " " + q.Family_Fa + "' width='270' height='270'></div><div><p>" + q.Job_Fa + "</p><div class='contact'><p style='text-align:left;'><b>Email: </b><a style='color:rgba(255,255,255,0.8);text-decoration:none;' href='mailto:" + q.Email + "'>" + q.Email + "</a></p></div><div class='contact'><p style='text-align:left;direction:ltr;'><b>Phone: </b><a style='color:rgba(255,255,255,0.8);text-decoration:none;' rel='nofollow' href='tel:" + q.Mobile1 + "'>" + q.Mobile1 + "</a><br/>"
            '            If q.Intrests_Fa <> "" Then
            '                Item.Text += "<span style='float:right;text-align:right;direction:rtl;'><b>علاقه‌مندی: </b>" + q.Intrests_Fa + "</span>"
            '            End If
            '            Item.Text += "<br/><a style='color:#8ab733;' href='/about/" + q.Name_En.ToString.Replace(" ", "-").ToLower() + "-" + q.Family_En.ToString.Replace(" ", "-").ToLower() + "'>درباره ایشان بیشتر بدانید</a></p></div></div>"
            '            Item.Text += "<div class='social'>"
            '            'If q.Facebook <> "" Then
            '            '    Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-facebook' href='" + q.Facebook + "'></a></div>"
            '            'End If
            '            'If q.Twitter <> "" Then
            '            '    Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-twitter' href='" + q.Twitter + "'></a></div>"
            '            'End If
            '            'If q.Googleplus <> "" Then
            '            '    Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-gplus' href='" + q.Googleplus + "'></a></div>"
            '            'End If
            '            If q.Linkedin <> "" Then
            '                Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-linkedin' href='" + q.Linkedin + "'></a></div>"
            '            End If
            '            If q.Instagram <> "" Then
            '                Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-instagram' href='" + q.Instagram + "'></a></div>"
            '            End If
            '            If q.Telegram <> "" Then
            '                Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-telegram' href='" + q.Telegram + "'><img src='../img/telegram.png' /></a></div>"
            '            End If
            '            If q.WhatsApp <> "" Then
            '                Item.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-whatsapp' href='" + q.WhatsApp + "'><img src='../img/WhatsApp.png' /></a></div>"
            '            End If
            '            Item.Text += "</div></div></div>"
            '            Exit For
            '        End If
            '    Next
            'Next
            'ltrAdminMember.Text = Item.Text
            Item.Text = ""
            Dim qryMessage = From m In db.Messages
                             Select m Order By m.Year_En Descending, m.Month_En Descending, m.Day_En Descending, m.Priority Descending, m.IDMessage Descending Where m.IsShow = True And (m.Title_Fa <> "")

            'lblFAQ.Text = "<div class='container'>"
            c = 0
            Dim Cat As String = ""
            For Each q In qryMessage
                'Dim lblbr = New Label
                'lblbr.Text = "<p/>"
                For Each catm In q.CatName_En.Split(";")
                    If catm.ToString() <> "all" Then
                        Cat = catm.ToString.Replace(" ", "-")
                        Exit For
                    Else

                    End If
                Next
                Dim qryUsersIcon = From n In db.Users
                                   Select n Where (n.Name_Fa + " " + n.Family_Fa) = q.WrittenBy_Fa
                For Each k In qryUsersIcon

                    Item.Text += "<li class='ahm-hover'><a class='highslide' onclick='return hs.expand(this, 1 )' href='" + q.Image + "'><img class='image img-circle' style='width:60px;height:60px;' src='../../" + q.Image + "' alt='" + k.Name_Fa + " " + k.Family_Fa + "' title='' data-appear-animation='rotateIn'></a><div class='meta'><span>ارسال شده توسط<a href='/about/" + k.Name_En.ToString.Replace(" ", "-").ToLower() + "-" + k.Family_En.ToString.Replace(" ", "-").ToLower() + "'> " + k.Name_Fa + " " + k.Family_Fa + "</a></span> در <span class='time'>" + q.Moment_Fa.ToString.Remove(q.Moment_Fa.ToString.Length - 8, 8) + "</span></div><div class='description'><a href='/posts/" + Cat.ToString().ToLower() + "/" + q.Title_En.ToString().Replace(" ", "-").ToLower() + "/" + q.IDMessage.ToString() + "'>" + q.Title_Fa + "</a></div></li>"
                Next
                c += 1
                If c = 3 Then
                    Exit For
                End If
            Next
            ltrLastPost.Text = Item.Text + "<br/>"
        Catch ex As Exception

            Response.Write(ex.Message)
        End Try
    End Sub
End Class
