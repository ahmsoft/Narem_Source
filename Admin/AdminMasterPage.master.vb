Imports System.Collections.Generic
Partial Class Admin_AdminMasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If HttpContext.Current.User.Identity.IsAuthenticated Then
            Else
            Response.Redirect("/Login")
        End If
    End Sub
End Class

