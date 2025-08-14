Imports System.Net.Http
Partial Class Login
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Title = "احراز هویت و ورود - نارِم"
        Page.MetaDescription = "با ایجاد یک حساب کاربری در وب سایت ما، شما قادر خواهید بود سریعتر با فرآیند ثبت سفارش، پشتیبانی و پرداخت هزینه اقدام کنید، چندین آدرس حمل و نقل را ذخیره کنید، سفارشات خود را در حساب خود و سایر موارد مشاهده و پیگیری کنید."
        Page.MetaKeywords = "شرکت نارم , احراز هویت , ورود , وب سایت نارم , هوش مصنوعی , مالی و حسابداری ,  نرم افزار"
        Dim MetaIMG As String = "<meta property='og:image' content='img/Login.png' />"
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
            ltrMenu.Text = Item.Text
            Item.Text = ""
            If Session("SignupSucsses") = 1 Then
                SweetAlertSucsses("راستی آزمایی انجام شد", ".حال می‌توانید وارد حساب خود شوید", "بسیار خوب", "success")
                Session("SignupSucsses") = 0
            End If
        Catch ex As Exception

            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnArival_Click(sender As Object, e As EventArgs) Handles btnArival.Click
        Dim db = New LinqDBClassesDataContext
        Dim ENC As New AHMSECKEY()
        Dim Students = From m In db.Students
                       Select m Where m.Mobile1 = txtUsername.Text And m.Password = ENC.Encrypt(txtPassword.Text)
        For Each m In Students
            'If m.IsSupervisor = True Then
            If m.Authoritys <> "" Then
                'System.Web.Security.Roles.CreateRole("Admin")
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(m.Mobile1.ToString(), chk.Checked)
            End If
        Next

        Dim Users = From m In db.Users
                    Select m Where m.Username = txtUsername.Text And m.Password = ENC.Encrypt(txtPassword.Text)
        For Each m In Users
            'If m.IsSupervisor = True Then
            If m.Authoritys <> "" Then
                'System.Web.Security.Roles.CreateRole("Admin")
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(m.Username.ToString(), chk.Checked)
            End If
        Next
        lblSubmitStatus.Text = "<b>*</b> نام کاربری یا رمز ورود نا معتبر است."
        lblSubmitStatus.Visible = True
    End Sub

    Protected Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        If Trim(Session("randomStr").ToString()) = Trim(txtCaptcha.Text.ToString()) Then
            Try
                SweetAlertSucsses("شماره قرارداد نامعتبر است", "درخواست ایجاد حساب کاربری شما، با شکست مواجه شد", "بسیار خوب", "warning")
                txtCaptcha.Text = ""
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        Else
            SweetAlertSucsses("خطا در ورود کد امنیتی", "متاسفانه درخواست ایجاد حساب کاربری شما با شکست مواجه شد", "بسیار خوب", "error")
            txtCaptcha.Text = ""
        End If
    End Sub
    Protected Sub btnForget_Click(sender As Object, e As EventArgs) Handles btnForget.Click
        Try
            If Trim(Session("randomStr").ToString()) = Trim(txtCode.Text.ToString()) Then
                Try
                    Dim db = New LinqDBClassesDataContext
                    Dim status As Boolean = False
                    Dim ENC As New AHMSECKEY()
                    Dim i As Integer = 0
                    Dim Users = From m In db.Users
                                Select m Where m.Mobile1 = txtForgetPass.Text
                    For Each m In Users
                        'Dim client = New HttpClient()

                        'Dim url = "https://raygansms.com/CheckSendCode.ashx?UserName=ahmsoft&Password=00000110&Mobile=09391815029&Code=700770"
                        'Dim Response = client.GetAsync(url).Result

                        'Dim result = Response.Content.ReadAsStringAsync().Result
                        'Dim resultCode = Long.Parse(result)
                        'Dim isSuccessful = resultCode >= 2000

                        ''Return isSuccessful;
                        ''        a = Response.Redirect("https://raygansms.com/CheckSendCode.ashx?UserName=ahmsoft&Password=00000110&Mobile=09391815029&Code=1212")
                        Dim T1 As New RayganSms()
                        status = T1.SendSmsMessageGetMethod("ahmsoft", ENC.Encrypt("00000110"), "50002910001080", "کاربر گرامی " + m.Name_Fa + " " + m.Family_Fa + " عزیز نام کاربری شما " + m.Username + " و رمز عبور شما " + ENC.Decrypt(m.Password) + " است. https://narem.ir ", m.Mobile1).ToString


                    Next
                    Dim StudentUser = From m In db.Students
                                      Select m Where m.Mobile1 = txtForgetPass.Text
                    For Each m In StudentUser
                        'Dim client = New HttpClient()

                        'Dim url = "https://raygansms.com/CheckSendCode.ashx?UserName=ahmsoft&Password=00000110&Mobile=09391815029&Code=700770"
                        'Dim Response = client.GetAsync(url).Result

                        'Dim result = Response.Content.ReadAsStringAsync().Result
                        'Dim resultCode = Long.Parse(result)
                        'Dim isSuccessful = resultCode >= 2000

                        ''Return isSuccessful;
                        ''        a = Response.Redirect("https://raygansms.com/CheckSendCode.ashx?UserName=ahmsoft&Password=00000110&Mobile=09391815029&Code=1212")
                        Dim T1 As New RayganSms()
                        status = T1.SendSmsMessageGetMethod("ahmsoft", ENC.Encrypt("00000110"), "50002910001080", "کاربر گرامی " + m.Name_Fa + " " + m.Family_Fa + " عزیز نام کاربری آموزشی شما " + m.Mobile1 + " و رمز عبور شما " + ENC.Decrypt(m.Password) + " است. https://narem.ir ", m.Mobile1).ToString
                    Next
                    If status = True Then
                        SweetAlertSucsses("ارسال شد", "بازیابی اطلاعات ورود به حساب کاربری، با موفقیت ارسال شد", "بسیار خوب", "success")
                        txtCode.Text = ""
                    Else
                        SweetAlertSucsses("با پشتیبان نارم تماس حاصل نمایید", "بازیابی اطلاعات ورود به حساب کاربری، با شکست مواجه شد", "بسیار خوب", "warning")
                    End If
                    txtCode.Text = ""
                Catch ex As Exception
                    Response.Write(ex.Message)

                End Try
            Else
                SweetAlertSucsses("خطا در ورود کد امنیتی", "بازیابی اطلاعات ورود به حساب کاربری، با شکست مواجه شد", "بسیار خوب", "error")
                txtCode.Text = ""
            End If
        Catch ex As Exception

        End Try
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
