
Partial Class SignIn
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            If HttpContext.Current.User.Identity.IsAuthenticated Then
                Dim db = New LinqDBClassesDataContext
                Dim Users = From m In db.Users
                            Select m Where m.Username = HttpContext.Current.User.Identity.Name.ToString
                For Each q In Users
                    For Each i In q.Authoritys.ToString.Split(";")
                        If i.ToString = "Customer" Then
                            Response.Redirect("~/Customers/CustomersPanel.aspx")
                        ElseIf i.ToString = "Admin" Then
                            Response.Redirect("~/Admin/AdminPanel.aspx")
                        End If
                    Next
                Next
                Dim Students = From m In db.Students
                               Select m Where m.Mobile1 = HttpContext.Current.User.Identity.Name.ToString
                For Each q In Students
                    For Each i In q.Authoritys.ToString.Split(";")
                        If i.ToString = "Student" Then
                            Response.Redirect("~/Students/StudentsPanel.aspx")
                        End If
                    Next
                Next
            Else
                Response.Redirect("Login")
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            'Response.Redirect("Login")
        End Try

    End Sub
End Class
