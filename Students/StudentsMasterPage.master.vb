Imports System.Collections.Generic
Partial Class StudentsMasterPage
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim ENC As New AHMSECKEY()
            If HttpContext.Current.User.Identity.IsAuthenticated Then
                Dim db = New LinqDBClassesDataContext
                Dim Users = From m In db.Users
                            Select m Where m.Username = HttpContext.Current.User.Identity.Name.ToString
                For Each q In Users
                    Session("Auth") = ENC.Encrypt(Trim(q.Authoritys))
                Next
                Response.Cookies("NaremAuthenticated").Value = "True"
                Response.Cookies("NaremAuthenticated").Domain = ".narem.ir"
                Response.Cookies("NaremAuthenticated").Expires = DateTime.Now.AddDays(1)
            Else
                FormsAuthentication.SignOut()
                Session.Abandon()
                FormsAuthentication.RedirectToLoginPage()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            'Response.Redirect("Login")
        End Try

    End Sub
End Class

