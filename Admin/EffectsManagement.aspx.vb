
Partial Class Admin_EffectsManagement
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim lblContactUsNoReadCount As Label = Master.FindControl("lblContactUsNoReadCount")
            Dim lblContactUsNoReadCount1 As Label = Master.FindControl("lblContactUsNoReadCount1")
            Dim lblAdminImage As Literal = Master.FindControl("lblAdminImage")
            Dim lblAdminImage1 As Literal = Master.FindControl("lblAdminImage1")
            Dim lblAdminImage2 As Literal = Master.FindControl("lblAdminImage2")
            Dim lblAdminNameFamily As Literal = Master.FindControl("lblAdminNameFamily")
            Dim lblAdminNameFamily1 As Literal = Master.FindControl("lblAdminNameFamily1")
            Dim lblAdminNameFamily2 As Literal = Master.FindControl("lblAdminNameFamily2")
            Dim lblFAQCount As Label = Master.FindControl("lblFAQCount")
            Dim lblCommentCount As Label = Master.FindControl("lblCommentCount")
            Dim lblWarningCount As Label = Master.FindControl("lblWarningCount")
            Dim lblWarningCount1 As Label = Master.FindControl("lblWarningCount1")
            Dim lblWarningContactUsCount As Label = Master.FindControl("lblWarningContactUsCount")
            Dim lblContactUss As Label = Master.FindControl("lblContactUss")
            Dim db = New LinqDBClassesDataContext
            Dim User = From m In db.Users
                       Select m Order By m.IDU
            For Each m In User
                If m.IsSupervisor = True Then
                    lblAdminImage2.Text = "<img src='/" + m.PhotoMin + "' class='img-circle' alt='User Image' />"
                    lblAdminImage1.Text = "<img src='" + m.PhotoMin + "' class='user-image' alt='User Image'>"
                    lblAdminImage.Text = "<img src='/" + m.PhotoMin + "' class='img-circle' alt='User Image' />"
                    lblAdminNameFamily.Text = m.Name_Fa + " " + m.Family_Fa + "<br/><br/>"
                    lblAdminNameFamily1.Text = m.Name_Fa + " " + m.Family_Fa
                    lblAdminNameFamily2.Text = "<p style='z-index: 5;color: #fff;color: rgba(255, 255, 255, 0.8);font-size: 17px;margin-top: 10px;margin: 0 0 10px;display: block;-webkit-margin-before: 1em;-webkit-margin-after: 1em;-webkit-margin-start: 0px;-webkit-margin-end: 0px;'>" + m.Name_Fa + " " + m.Family_Fa + "<br /><small>مدیریت کل سایت</small></p>"
                End If
            Next
            Dim WarningCount As Integer = 0
            Dim p As Integer = 0
            Dim i As Integer = 0
            Dim ContactUsRow = From m In db.ContactUs
                               Select m Order By m.IDCU Descending
            For Each m In ContactUsRow
                Dim msg As String = ""
                If m.NameAndFamily_En <> "" Then 'Or q.NameAndFamilyEn IsNot Nothing Then
                    msg = m.MSG_En
                    If msg.Length > 51 Then
                        msg = Substr(msg, 0, 51)
                    Else
                        msg = m.MSG_En
                    End If
                    If Trim(m.Seen) = "جدید" Then
                        lblContactUss.Text += "<li><a href='Inbox.aspx?ID=" + m.IDCU.ToString + "' style='display:block;white-space:nowrap;border-bottom:1px solid #f4f4f4;'><div class='pull-right' style='display: block;'><span class='label label-success' style='margin-right:5px;margin-left:5px;'>" + m.Seen + "</span></div><h4 style='padding: 0;margin: 0 0 0 45px;color:#444444;font-size:12px;position:relative;margin-top:10px;' title='" + m.MSG_En + "'>" + m.NameAndFamily_En + "<small style='color:#999999;font-size:9px;position:absolute;top:0;left:0;'><br/><i class='fa fa-clock-o'style='margin:5px;'> </i>" + m.Moment_Fa + "</small></h4><p style='direction:ltr;font-size: 10px;color: #888888;padding:15px;'title='" + m.MSG_En + "'>" + msg + "</p></a></li>"
                        i = i + 1
                        WarningCount += 1
                    Else
                        lblContactUss.Text += "<li><a href='Inbox.aspx?ID=" + m.IDCU.ToString + "' style='display:block;white-space:nowrap;border-bottom:1px solid #f4f4f4;'><div class='pull-right' style='display: block;'><span class='label label-warning' style='margin-right:5px;margin-left:5px;'>" + m.Seen + "</span></div><h4 style='padding: 0;margin: 0 0 0 45px;color:#444444;font-size:12px;position:relative;margin-top:10px;' title='" + m.MSG_En + "'>" + m.NameAndFamily_En + "<small style='color:#999999;font-size:9px;position:absolute;top:0;left:0;'><br/><i class='fa fa-clock-o'style='margin:5px;'> </i>" + m.Moment_Fa + "</small></h4><p style='direction:ltr;font-size: 10px;color: #888888;padding:15px;' title='" + m.MSG_En + "'>" + msg + "</p></a></li>"
                    End If
                ElseIf m.NameAndFamily_Fa <> "" Then 'Or q.NameAndFamily_Fa IsNot Nothing
                    msg = m.MSG_Fa
                    If msg.Length > 51 Then
                        msg = Substr(msg, 0, 51)
                    Else
                        msg = m.MSG_Fa
                    End If
                    If Trim(m.Seen) = "جدید" Then
                        lblContactUss.Text += "<li><a href='Inbox.aspx?ID=" + m.IDCU.ToString + "' style='display:block;white-space:nowrap;border-bottom:1px solid #f4f4f4;'><div class='pull-right' style='display: block;'><span class='label label-success' style='margin-right:5px;margin-left:5px;'>" + m.Seen + "</span></div><h4 style='padding: 0;margin: 0 0 0 45px;color:#444444;font-size:12px;position:relative;margin-top:10px;' title='" + m.MSG_Fa + "'>" + m.NameAndFamily_Fa + "<small style='color:#999999;font-size:9px;position:absolute;top:0;left:0;'><br/><i class='fa fa-clock-o'style='margin:5px;'> </i>" + m.Moment_Fa + "</small></h4><p style='direction:rtl;font-size: 10px;color: #888888;padding:15px;'title='" + m.MSG_Fa + "'>" + msg + "</p></a></li>"
                        i = i + 1
                        WarningCount += 1
                    Else
                        lblContactUss.Text += "<li><a href='Inbox.aspx?ID=" + m.IDCU.ToString + "' style='display:block;white-space:nowrap;border-bottom:1px solid #f4f4f4;'><div class='pull-right' style='display: block;'><span class='label label-warning' style='margin-right:5px;margin-left:5px;'>" + m.Seen + "</span></div><h4 style='padding: 0;margin: 0 0 0 45px;color:#444444;font-size:12px;position:relative;margin-top:10px;' title='" + m.MSG_Fa + "'>" + m.NameAndFamily_Fa + "<small style='color:#999999;font-size:9px;position:absolute;top:0;left:0;'><br/><i class='fa fa-clock-o'style='margin:5px;'> </i>" + m.Moment_Fa + "</small></h4><p style='direction:rtl;font-size: 10px;color: #888888;padding:15px;' title='" + m.MSG_Fa + "'>" + msg + "</p></a></li>"
                    End If

                End If
                p += 1
            Next
            lblContactUsNoReadCount.Text = i
            lblContactUsNoReadCount1.Text = i
            Dim FAQCU As Integer = 0
            Dim FAQ = From m In db.FAQms
                      Select m Where m.Seen = "جدید" Order By m.IDF
            For Each m In FAQ
                FAQCU += 1
            Next
            Dim CommentCU As Integer = 0
            Dim Comment = From m In db.Comments
                          Select m Where m.Seen = "جدید" Order By m.IDC
            For Each m In Comment
                CommentCU += 1
            Next
            lblCommentCount.Text = CommentCU
            lblFAQCount.Text = FAQCU
            lblWarningCount.Text = FAQCU + WarningCount + CommentCU
            lblWarningCount1.Text = lblWarningCount.Text
            lblWarningContactUsCount.Text = lblContactUsNoReadCount.Text
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        'txtMoment_En.Value = Date_En()
        Dim lblActiveParent As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIPortfGallerys"))
        lblActiveParent.Attributes("Class") = "treeview active"
        Dim lblActive As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIPortfCovers"))
        lblActive.Attributes("Class") = "treeview active"
    End Sub
    Protected Sub CoversViewPortf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CoversViewPortf.SelectedIndexChanged
        Try
            Dim db = New LinqDBClassesDataContext
            Dim qry = From m In db.Portfolios
                      Select m
                      Where m.IDP = Convert.ToInt32(CoversViewPortf.SelectedValue)
            For Each q In qry
                txtCat_Fa.Text = q.CatName_Fa
                txtCat_En.Text = q.CatName_En
                txtAddress.Text = q.Image
                txtKeyword_En.Text = q.Keyword_En
                txtKeyword_Fa.Text = q.Keyword_Fa
                txtTitle_En.Text = q.Title_En
                txtTitle_Fa.Text = q.Title_Fa
                txtMoment_En.Value = q.Moment_En
                tarikh.Value = q.Moment_Fa
                RadCoverDescription_En.Content = q.Description_En
                RadCoverDescription_Fa.Content = q.Description_Fa
                txtKeyword_Fa.Text = q.Keyword_Fa
                txtKeyword_En.Text = q.Keyword_En
                lblMomentOld_Fa.Text = tarikh.Value
                lblMomentOld_En.Text = Date_En()
            Next
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnInsertImageCoverDescription_Fa_Click(sender As Object, e As EventArgs) Handles btnInsertImageCoverDescription_Fa.Click
        RadCoverDescription_Fa.Content += "<a class='highslide' onclick='return hs.expand(this, 1 )' href='" + FileNameCoverDescription_Fa.Text + "'><img alt='' src='" + FileNameCoverDescription_Fa.Text + "' style='margin: 10px; box-shadow: #c8c8c8 0px 2px 4px; padding: 5px; width: 380px; float: left; height: 212px;' class='img-responsive' title='' /></a>"
        lblInsertImageState_Fa.Visible = True
    End Sub
    Protected Sub btnInsertImageCoverDescription_En_Click(sender As Object, e As EventArgs) Handles btnInsertImageCoverDescription_En.Click
        RadCoverDescription_En.Content += "<a class='highslide' onclick='return hs.expand(this, 1 )' href='" + FileNameCoverDescription_En.Text + "'><img alt='' src='" + FileNameCoverDescription_En.Text + "' style='margin: 10px; box-shadow: #c8c8c8 0px 2px 4px; padding: 5px; width: 380px; float: left; height: 212px;' class='img-responsive' title='' /></a>"
        lblInsertImageState_En.Visible = True
    End Sub
    Protected Sub btnUpdateEffect_Click(sender As Object, e As EventArgs) Handles btnUpdateEffect.Click
        Try
            Dim db = New LinqDBClassesDataContext
            Dim qry = From m In db.Portfolios
                      Select m Where m.IDP = Convert.ToInt32(CoversViewPortf.SelectedValue)
            For Each q In qry
                q.CatName_Fa = txtCat_Fa.Text
                q.CatName_En = txtCat_En.Text
                q.Image = txtAddress.Text
                q.Keyword_En = txtKeyword_En.Text
                q.Keyword_Fa = txtKeyword_Fa.Text
                q.Title_En = txtTitle_En.Text
                q.Title_Fa = txtTitle_Fa.Text
                q.Moment_En = txtMoment_En.Value
                q.Moment_Fa = tarikh.Value
                q.Description_En = RadCoverDescription_En.Content
                q.Description_Fa = RadCoverDescription_Fa.Content
                q.Keyword_Fa = txtKeyword_Fa.Text
                q.Keyword_En = txtKeyword_En.Text
            Next
            db.SubmitChanges()
            CoversViewPortf.DataBind()

        Catch ex As Exception
            'Dim db = New LinqDBClassesDataContext
            'Dim UserTable As New FaultLog
            'UserTable.ErrorMessage = ex.Message
            'UserTable.PageName = System.IO.Path.GetFileName(Request.CurrentExecutionFilePath)
            'db.FaultLogs.InsertOnSubmit(UserTable)
            'db.SubmitChanges()
            'Response.Redirect("../ErrorPage.aspx")
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnSaveNewEffect_Click(sender As Object, e As EventArgs) Handles btnSaveNewEffect.Click
        Try
            Dim db = New LinqDBClassesDataContext
            Dim q = New Portfolio
            q.CatName_Fa = txtCat_Fa.Text
            q.CatName_En = txtCat_En.Text
            q.Image = txtAddress.Text
            q.Keyword_En = txtKeyword_En.Text
            q.Keyword_Fa = txtKeyword_Fa.Text
            q.Title_En = txtTitle_En.Text
            q.Title_Fa = txtTitle_Fa.Text
            q.Moment_En = txtMoment_En.Value
            q.Moment_Fa = tarikh.Value
            q.Description_En = RadCoverDescription_En.Content
            q.Description_Fa = RadCoverDescription_Fa.Content
            q.Keyword_Fa = txtKeyword_Fa.Text
            q.Keyword_En = txtKeyword_En.Text
            db.Portfolios.InsertOnSubmit(q)
            db.SubmitChanges()
            CoversViewPortf.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Private Sub Admin_EffectsManagement_InitComplete(sender As Object, e As EventArgs) Handles Me.InitComplete
        txtMoment_En.Value = Date_En()
    End Sub

    Public Function Substr(InputText As String, StartIndex As Integer, Length As Integer) As String

        Return InputText.Substring(StartIndex, Length) + " ... "
    End Function
    Public Function Date_En() As String
        Dim M As String
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
End Class
