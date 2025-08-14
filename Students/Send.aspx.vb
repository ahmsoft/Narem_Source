
Partial Class Students_Send
    Inherits System.Web.UI.Page
    Protected Sub btnSaveNewMessage_Click(sender As Object, e As EventArgs) Handles btnSaveNewMessage.Click
        'Try
        '    Dim tmpCat As String = ""
        '    Dim db = New LinqDBClassesDataContext
        '    Dim q = New StdMessage
        '    q.Title = txtTitle.Text
        '    'q.Moment_Fa = tar
        '    q.MSG = RadMessage.Content
        '    'If chkCat_Fa.Items(0).Selected = False Then
        '    For i = 0 To chkCat_Fa.Items.Count - 1
        '        If chkCat_Fa.Items(i).Selected = True Then
        '            tmpCat += chkCat_Fa.Items(i).Value + ";"
        '        End If
        '    Next
        '    'ElseIf chkCat_Fa.Items(0).Selected = True Then
        '    '    For i = 0 To chkCat_Fa.Items.Count - 1
        '    '        tmpCat += chkCat_Fa.Items(i).Value + ";"
        '    '    Next
        '    'End If

        '    tmpCat = tmpCat.Substring(0, tmpCat.Length - 1)
        '    q.CatName_Fa = tmpCat
        '    tmpCat = ""
        '    'If chkCat_En.Items(0).Selected = False Then
        '    For i = 0 To chkCat_En.Items.Count - 1
        '        If chkCat_En.Items(i).Selected = True Then
        '            tmpCat += chkCat_En.Items(i).Value + ";"
        '        End If
        '    Next
        '    'ElseIf chkCat_En.Items(0).Selected = True Then
        '    '    For i = 0 To chkCat_En.Items.Count - 1
        '    '        tmpCat += chkCat_En.Items(i).Value + ";"
        '    '    Next
        '    'End If
        '    tmpCat = tmpCat.Substring(0, tmpCat.Length - 1)
        '    q.CatName_En = tmpCat
        '    Try
        '        q.WrittenBy_En = Request.Cookies("Name_En").Value + " " + Request.Cookies("Family_En").Value
        '        q.WrittenBy_Fa = Request.Cookies("Name_Fa").Value + " " + Request.Cookies("Family_Fa").Value
        '    Catch ex As Exception
        '        Dim qry1 = From m In db.Users
        '                   Select m Where m.Username = HttpContext.Current.User.Identity.Name.ToString()
        '        For Each b In qry1
        '            q.WrittenBy_Fa = b.Name_Fa + " " + b.Family_Fa
        '            q.WrittenBy_En = b.Name_En + " " + b.Family_En
        '        Next
        '    End Try
        '    'q.CommentCount = 0
        '    If txtMoment_Fa.Value = "" Then
        '        q.Moment_Fa = tarikh.Text
        '    Else
        '        q.Moment_Fa = txtMoment_Fa.Value
        '    End If
        '    If txtMoment_En.Value = "" Then
        '        q.Moment_En = txtMomentNew_En.Text
        '    Else
        '        q.Moment_En = txtMoment_En.Value
        '    End If
        '    Dim T As Integer = 0
        '    For Each i In txtMoment_En.Value.ToString.Split("-")
        '        If T = 0 Then
        '            q.Year_En = Convert.ToInt16(i)
        '        ElseIf T = 1 Then
        '            Select Case i
        '                Case "January"
        '                    q.Month_En = 1
        '                Case "February"
        '                    q.Month_En = 2
        '                Case "March"
        '                    q.Month_En = 3
        '                Case "April"
        '                    q.Month_En = 4
        '                Case "May"
        '                    q.Month_En = 5
        '                Case "June"
        '                    q.Month_En = 6
        '                Case "July"
        '                    q.Month_En = 7
        '                Case "August"
        '                    q.Month_En = 8
        '                Case "September"
        '                    q.Month_En = 9
        '                Case "October"
        '                    q.Month_En = 10
        '                Case "November"
        '                    q.Month_En = 11
        '                Case "December"
        '                    q.Month_En = 12
        '            End Select
        '        ElseIf T = 2 Then
        '            q.Day_En = Convert.ToInt16(i)
        '        End If
        '        T = T + 1
        '    Next
        '    q.IsShow = CheckBoxIsShow.Checked
        '    q.Priority = txtPriority.Text
        '    db.Messages.InsertOnSubmit(q)
        '    db.SubmitChanges()
        '    MessageView.DataBind()
        'Catch ex As Exception
        '    Response.Write(ex.Message)
        'End Try
    End Sub

End Class
