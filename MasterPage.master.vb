
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Try
        '    If Request.QueryString("Search").ToString <> "" Then
        '        Response.Redirect("/Result?Search=" + Request.QueryString("Search").ToString)
        '    End If
        'Catch ex As Exception

        'End Try
        'Page.Title = "شرکت نارم | NAREM.IR"
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
            Dim db = New LinqDBClassesDataContext
            Dim qrySetting = From m In db.Settings
                             Select m Order By
                                          m.IDS
            Dim Item = New Literal
            For Each q In qrySetting
                ltrAddress.Text = q.Address1_Fa
                ltrCopyWrite.Text = q.CopyWrite_Fa
                ltrTel1.Text = "<a style='color:rgba(0, 0, 0, 0.8);text-decoration:none;' rel='nofollow' href='tel:" + q.TEL1 + "'>" + q.TEL1 + "</a>"
                ltrTel2.Text = "<a style='color:rgba(0, 0, 0, 0.8);text-decoration:none;' rel='nofollow' href='tel:" + q.TEL2 + "'>" + q.TEL2 + "</a>"
                ltrSocialNetworks.Text = ""
                If q.Facebook <> "" Then
                    ltrSocialNetworks.Text += "<a Class='sbtnf sbtnf-rounded color color-hover icon-facebook' href='" + q.Facebook + "'></a>"
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
                    ltrSocialNetworks.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-telegram' href='" + q.Telegram + "'><img src='../../../img/telegram.png' /></a></div>"
                End If
                If q.WhatsApp <> "" Then
                    ltrSocialNetworks.Text += "<div class='item'><a class='sbtnf sbtnf-rounded color color-hover icon-whatsapp' href='" + q.WhatsApp + "'><img src='../../../img/WhatsApp.png' /></a></div>"
                End If

            Next
            tarikh_En.Value = Date_En()
        Catch ex As Exception

        End Try
    End Sub
    Public Function Date_En() As String
        Dim M As String = 0
        Select Case Now.Month
            Case 1
                M = "January"
            Case 2
                M = "February"
            Case 3
                M = "March"
            Case 4
                M = "April"
            Case 5
                M = "May"
            Case 6
                M = "June"
            Case 7
                M = "July"
            Case 8
                M = "August"
            Case 9
                M = "September"
            Case 10
                M = "October"
            Case 11
                M = "November"
            Case 12
                M = "December"
        End Select
        Date_En = Now.Year.ToString + "-" + M + "-" + Now.Day.ToString
    End Function
    Protected Sub btnFeed_Click(sender As Object, e As EventArgs) Handles btnFeed.Click
        'Dim tarikh As HtmlInputText = Master.FindControl("tarikh")
        'Dim tarikh_En As HtmlInputText = Master.FindControl("tarikh_En")
        If Trim(Session("randomStr").ToString()) = Trim(txtCaptcha.Text.ToString()) Then
            Try
                Dim db = New LinqDBClassesDataContext
                Dim qry = From m In db.NewsLetters
                          Select m Where m.Email = txtFeed.Text
                For Each m In qry
                    'lblSubmitStatus.Text = "این ایمیل قبلا ارسال شده."
                    SweetAlertSucsses("ایمیل شما قبلا ثبت شده است", "ایمیل شما در حال حاضر در لیست خبرنامه شرکت وجود دارد", "بسیار خوب", "warning")
                    Exit Try
                Next
                Dim q = New NewsLetter
                q.Email = txtFeed.Text
                q.IsLatin = False
                q.Moment_Fa = tarikh.Value
                q.Moment_En = tarikh_En.Value
                Dim T As Integer = 0
                For Each i In tarikh_En.Value.ToString.Split("-")
                    If T = 0 Then
                        q.Year_En = Convert.ToInt16(i)
                    ElseIf T = 1 Then
                        Select Case i
                            Case "January"
                                q.Month_En = 1
                            Case "February"
                                q.Month_En = 2
                            Case "March"
                                q.Month_En = 3
                            Case "April"
                                q.Month_En = 4
                            Case "May"
                                q.Month_En = 5
                            Case "June"
                                q.Month_En = 6
                            Case "July"
                                q.Month_En = 7
                            Case "August"
                                q.Month_En = 8
                            Case "September"
                                q.Month_En = 9
                            Case "October"
                                q.Month_En = 10
                            Case "November"
                                q.Month_En = 11
                            Case "December"
                                q.Month_En = 12
                        End Select
                    ElseIf T = 2 Then
                        q.Day_En = Convert.ToInt16(i)
                    End If
                    T = T + 1
                Next
                db.NewsLetters.InsertOnSubmit(q)
                db.SubmitChanges()
                'Session("Alert") = "1"
                SweetAlertSucsses("با تشکر", "ایمیل شما با موفقیت در لیست خبرنامه شرکت ثبت شد منتظر خبرهای باشید", "بسیار خوب", "success")
                txtCaptcha.Text = ""
                'lblSubmitStatus.Style.Value = "color:#1fbf02;" 'سبز
                'lblSubmitStatus.Text = "ایمیل شما با موفقیت ارسال شد."
                'MsgBox(System.Web.HttpContext.Current.Session("Alert").ToString())
            Catch ex As Exception
                Response.Write(ex.Message)
                'lblSubmitStatus.Style.Value = "color:Orange;"
                'lblSubmitStatus.Text = "ارسال نا موفق - خطا سرور."
                'Session("Alert") = "0"

            End Try
        Else
            SweetAlertSucsses("خطا در ورود کد امنیتی", "متاسفانه درخواست ثبت ایمیل شما در خبرنامه با شکست مواجه شد", "بسیار خوب", "error")
            txtCaptcha.Text = ""
            'lblSubmitStatus.Style.Value = "color:Orange;"
            'lblSubmitStatus.Text = "کد امنیتی با دقت وارد شود."
            'Response.Redirect("#section6")
        End If
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Response.Redirect("/result/" + txtSearch.Text.Replace(" ", "-"))
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