
Partial Class Students_Exploer
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim db = New LinqDBClassesDataContext
        Dim Students = From m In db.Students
                       Select m Where m.Mobile1.ToString = HttpContext.Current.User.Identity.Name.ToString
        For Each m In Students
            Dim paths As String() = New String() {"~/Students/Uploads/" + m.IDNo}
            'Dim dir_path As String = Server.MapPath("~/Students/Uploads/" + m.IDNo)
            FileExplorer1.Configuration.ViewPaths = paths
            FileExplorer1.Configuration.DeletePaths = paths
            FileExplorer1.Configuration.UploadPaths = paths
        Next

    End Sub

End Class
