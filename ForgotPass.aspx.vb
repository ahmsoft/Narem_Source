
Partial Class ForgotPass
    Inherits System.Web.UI.Page
    Protected Sub btnForget_Click(sender As Object, e As EventArgs) Handles btnForget.Click
        If Trim(Session("randomStr").ToString()) = Trim(txtCode.Text.ToString()) Then
            Try
                SweetAlertSucsses("شماره تلفن همراه نامعتبر است", "بازیابی اطلاعات ورود به حساب کاربری، با شکست مواجه شد", "بسیار خوب", "warning")
                txtCode.Text = ""
            Catch ex As Exception
                Response.Write(ex.Message)

            End Try
        Else
            SweetAlertSucsses("خطا در ورود کد امنیتی", "بازیابی اطلاعات ورود به حساب کاربری، با شکست مواجه شد", "بسیار خوب", "error")
            txtCode.Text = ""
        End If
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
