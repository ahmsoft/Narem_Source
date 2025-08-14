Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Partial Class StudentSignup
    Inherits System.Web.UI.Page
    'Public Function GetMachinName() As String
    '    Dim strHostName As String = Dns.GetHostName()
    '    Dim ipEntry As IPHostEntry = Dns.GetHostEntry(strHostName)
    '    GetMachinName = Convert.ToString(ipEntry.HostName)
    'End Function
    'Public Function GetUser_IP() As String
    '    Dim VisitorsIPAddr As String = String.Empty
    '    If (HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR") <> "") Then
    '        VisitorsIPAddr = HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR").ToString()
    '    ElseIf (HttpContext.Current.Request.UserHostAddress.Length <> 0) Then
    '        VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress
    '    End If
    '    GetUser_IP = VisitorsIPAddr

    'End Function
    'Public Function GetMACAddress() As String
    '    Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
    '    Dim sMacAddress As String = String.Empty
    '    Dim Adapter As NetworkInterface
    '    For Each Adapter In nics

    '        If sMacAddress = String.Empty Then ' only Then Return MAC Address From first card  

    '            Dim properties As IPInterfaceProperties = Adapter.GetIPProperties()
    '            sMacAddress = Adapter.GetPhysicalAddress().ToString()
    '        End If
    '    Next
    '    GetMACAddress = sMacAddress
    'End Function
    Protected Sub btnSignup_Click(sender As Object, e As EventArgs) Handles btnSignup.Click
        Dim db = New LinqDBClassesDataContext
        Dim ENC As New AHMSECKEY()
        Dim T1 As New RayganSms()
        Dim status As Boolean
        Dim Rep As Boolean = True
        'status = T1.SendSmsMessageGetMethod("ahmsoft", ENC.Encrypt("00000110"), "50002910001080", "کاربر گرامی " + m.Name_Fa + " " + m.Family_Fa + " عزیز نام کاربری شما " + m.Username + " و رمز عبور شما " + ENC.Decrypt(m.Password) + " است. https://narem.ir ", m.Mobile1).ToString
        Try
            Dim qry = From m In db.Students
                      Select m Where (m.IDNo = Trim(txtIDNo.Text)) Or (m.Mobile1 = Trim(txtMobile.Text))
            For Each m In qry
                Session("SignupSucsses") = 0
                txtEmail.Enabled = True
                txtIDNo.Enabled = True
                txtJob.Enabled = True
                txtMobile.Enabled = True
                txtName_Fa.Enabled = True
                txtFamily_Fa.Enabled = True
                txtPass.Enabled = True
                optionLevel.Disabled = False
                btnSubmit.Enabled = True
                lblSubmitStatus.Style.Value = "color:red;"
                lblSubmitStatus.Text = "حساب کاربری شما قبلا ایجاد شده است."
                RadCaptcha.Visible = True
                btnRefresh.Visible = True
                txtSecCode.Text = ""
                txtSecCode.Visible = False
                btnSignup.Visible = False
                Rep = False
                GoTo EndPoint

            Next
            If Rep Then
                status = T1.CheckVerifyCodeWithGetMethod("ahmsoft", ENC.Encrypt("00000110"), Trim(txtMobile.Text), txtSecCode.Text)

                If status Then
                    Dim q As New Student
                    q.Name_Fa = txtName_Fa.Text
                    q.Family_Fa = txtFamily_Fa.Text
                    q.Email = txtEmail.Text
                    q.Mobile1 = txtMobile.Text
                    q.Password = ENC.Encrypt(txtPass.Text)
                    q.IDNo = txtIDNo.Text
                    q.Authoritys = "Student"
                    For i = 0 To optionLevel.Items.Count - 1
                        If optionLevel.Items(i).Selected Then
                            q.Evidence_Fa = optionLevel.Items(i).Text
                        End If
                    Next
                    q.PhotoMin = "../Students/StudentsPhotos/Client.png"
                    'q.Evidence_Fa = optionLevel.DataTextField
                    q.Job_Fa = txtJob.Text
                    db.Students.InsertOnSubmit(q)
                    db.SubmitChanges()
                    lblSubmitStatus.Style.Value = "color:green;"
                    lblSubmitStatus.Text = "انجام شد."
                    Session("SignupSucsses") = 1
                    ClientScript.RegisterStartupScript(Me.GetType(), "scriptid", "window.parent.location.href='login'", True)
                Else
                    SweetAlertSucsses("کد راستی آزمایی نادرست وارد شد.", "ایجاد حساب کاربری شما با شکست مواجه شد. دوباره تلاش کنید", "بسیار خوب", "error")
                    Session("SignupSucsses") = 0
                    txtEmail.Enabled = True
                    txtIDNo.Enabled = True
                    txtJob.Enabled = True
                    txtMobile.Enabled = True
                    txtName_Fa.Enabled = True
                    txtFamily_Fa.Enabled = True
                    txtPass.Enabled = True
                    optionLevel.Disabled = False
                    btnSubmit.Enabled = True
                    lblSubmitStatus.Style.Value = "color:red;"
                    'status = T1.SendSmsAutGetMethod("ahmsoft", ENC.Encrypt("00000110"), Trim(txtMobile.Text), "https://narem.ir")
                    lblSubmitStatus.Text = "در ورود اطلاعات خود دقت نمایید چند بار ورود اشتباه منجر به مسدودسازی IP شما خواهد شد."
                    lblSubmitStatus.Visible = True
                    RadCaptcha.Visible = True
                    btnRefresh.Visible = True
                    txtSecCode.Text = ""
                    txtSecCode.Visible = False
                    btnSignup.Visible = False
                End If
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
            lblSubmitStatus.Style.Value = "color:Orange;"
            lblSubmitStatus.Text = "ارسال نا موفق - خطا سرور."
            Session("SignupSucsses") = 0
            SweetAlertSucsses("خطا سرور", "ایجاد حساب کاربری شما با شکست مواجه شد. دوباره تلاش کنید", "بسیار خوب", "error")
            txtEmail.Enabled = True
            txtIDNo.Enabled = True
            txtPass.Enabled = True
            txtJob.Enabled = True
            txtMobile.Enabled = True
            txtName_Fa.Enabled = True
            txtFamily_Fa.Enabled = True
            optionLevel.Disabled = False
            btnSubmit.Enabled = True
            'lblSubmitStatus.Style.Value = "color:red;"
            'status = T1.SendSmsAutGetMethod("ahmsoft", ENC.Encrypt("00000110"), Trim(txtMobile.Text), "https://narem.ir")
            'lblSubmitStatus.Text = "در ورود اطلاعات خود دقت نمایید چند بار ورود اشتباه منجر به مسدودسازی IP شما خواهد شد."
            'lblSubmitStatus.Visible = True
            RadCaptcha.Visible = True
            btnRefresh.Visible = True
            txtSecCode.Visible = False
            btnSignup.Visible = False
        End Try
EndPoint:
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim ENC As New AHMSECKEY()
        Dim T1 As New RayganSms()
        Dim status As Boolean
        If RadCaptcha.IsValid = True Then
            txtEmail.Enabled = False
            txtIDNo.Enabled = False
            txtJob.Enabled = False
            txtMobile.Enabled = False
            txtName_Fa.Enabled = False
            txtFamily_Fa.Enabled = False
            txtPass.Enabled = False
            optionLevel.Disabled = True
            btnSubmit.Enabled = False
            lblSubmitStatus.Style.Value = "color:green;"
            status = T1.SendSmsAutGetMethod("ahmsoft", ENC.Encrypt("00000110"), Trim(txtMobile.Text), "https://narem.ir")
            lblSubmitStatus.Text = "کد پیامک شده را وارد نمایید و تایید را بزنید."
            lblSubmitStatus.Visible = True
            RadCaptcha.Visible = False
            btnRefresh.Visible = False
            txtSecCode.Text = ""
            txtSecCode.Visible = True
            btnSignup.Visible = True
        Else
            lblSubmitStatus.Style.Value = "color:red;"
            lblSubmitStatus.Text = "کد امنیتی اشتباه وارد شد."
            lblSubmitStatus.Visible = True
            RadCaptcha.Visible = True
            txtSecCode.Visible = False
            btnSignup.Visible = False
            btnRefresh.Visible = True

        End If

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Title = "ایجاد حساب کاربری آموزشی - نارِم"
        Page.MetaDescription = "فرم ارسال درخواست سفارش طراحی وب سایت یا بهینه سازی وب سایت."
        Page.MetaKeywords = "سفارش , وب سایت , NAREM.IR , ثبت سفارش , درخواست پروژه , نارم , ثبت سفارش محصول , خدمات"
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
        'Try
        '    Dim browser As HttpBrowserCapabilities = Request.Browser
        '    Dim db = New LinqDBClassesDataContext
        '    Dim q = New UsersOnlineDetail
        '    q.Browser = browser.Browser
        '    q.Platform = browser.Platform
        '    q.DateAndTime = Now.ToLocalTime
        '    q.IPAddress = GetUser_IP()
        '    q.MachinName = GetMACAddress()
        '    q.Page = Request.CurrentExecutionFilePath
        '    db.UsersOnlineDetails.InsertOnSubmit(q)
        '    db.SubmitChanges()
        'Catch ex As Exception
        '    Response.Write(ex.Message)
        '    Dim db = New LinqDBClassesDataContext
        '    Dim UserTable As New FaultLog
        '    UserTable.PageName = System.IO.Path.GetFileName(Request.CurrentExecutionFilePath)
        '    UserTable.ErrorMessage = ex.Message
        '    db.FaultLogs.InsertOnSubmit(UserTable)
        '    db.SubmitChanges()
        'End Try
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
