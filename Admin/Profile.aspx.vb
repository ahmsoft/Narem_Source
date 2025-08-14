
Partial Class Admin_Profile
    Inherits System.Web.UI.Page

    Private Sub btnUpdateProfile_Click(sender As Object, e As EventArgs) Handles btnUpdateProfile.Click
        Try
            Dim ENC As New AHMSECKEY()
            Dim db = New LinqDBClassesDataContext
            Dim qry = From m In db.Users
                      Select m Where m.IDU = Convert.ToInt32(UserView.SelectedValue)
            For Each q In qry
                'q.Password = txtPassword.Text
                q.Phone1 = txtPhone1.Text
                'q.Phone2 = txtPhone2.Text
                q.Address1_Fa = RadAddress1.Content
                'q.Address2 = RadAddress2.Content
                q.Mobile1 = txtMobile1.Text
                'q.Mobile2 = txtMobile2.Text
                q.Email = txtEmail.Text
                q.Website = txtWebsite.Text
                q.PhotoMin = txtPhotoMin.Text
                q.PhotoMax = txtPhotoMax.Text
                q.Instagram = txtInstagram.Text
                q.Telegram = txtTelegram.Text
                q.Linkedin = txtLinkedin.Text
                q.Googleplus = txtGoogleplus.Text
                q.Twitter = txtTwitter.Text
                q.Facebook = txtFacebook.Text
                q.Biography_Fa = RadBiography_Fa.Content
                q.Biography_En = RadBiography_En.Content
                'q.BiographyFr = RadBiographyFr.Content
                'q.BiographyAr = RadBiographyAr.Content
                'q.ResumeFile = txtResumeFile.Text
                'q.About_Fa = txtResumeFile.Text
                'q.About_En = RadAbout_En.Content
                q.Job_Fa = txtJob_Fa.Text
                q.Job_En = txtJob_En.Text
                'q.JobFr = txtJobFr.Text
                'q.JobAr = txtJobAr.Text
                If txtOPassword.Text=ENC.Decrypt(q.Password) Then
                    q.Password = ENC.Encrypt(txtPassword.Text)
                    lblValidOldPass.Visible=False
                    ChangePassword.Attributes("class")="box box-danger collapsed-box"
                    Else 
                    lblValidOldPass.Visible=True
                    ChangePassword.Attributes("class")="box box-danger"
                End If
                'q.BioEdu_Fa = RadBioEdu_Fa.Content
                'q.BioEdu_En = RadBioEdu_En.Content
                'q.BioJob_Fa = RadBioJob_Fa.Content
                'q.BioJob_En = RadBioJob_En.Content
            Next
            db.SubmitChanges()
            UserView.DataBind()


        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    'Protected Sub btnSaveNewProfile_Click(sender As Object, e As EventArgs) Handles btnSaveNewProfile.Click
    '    Try
    '        Dim db = New LinqDBClassesDataContext
    '        Dim q = New User
    '        q.Password = txtPassword.Text
    '        q.Phone1 = txtPhone1.Text
    '        q.Phone2 = txtPhone2.Text
    '        q.Address1 = RadAddress1.Content
    '        q.Address2 = RadAddress2.Content
    '        q.Mobile1 = txtMobile1.Text
    '        q.Mobile2 = txtMobile2.Text
    '        q.Email = txtEmail.Text
    '        q.Website = txtWebsite.Text
    '        q.PhotoMin = txtPhotoMin.Text
    '        q.PhotoMax = txtPhotoMax.Text
    '        q.Instagram = txtInstagram.Text
    '        q.Telegram = txtTelegram.Text
    '        q.Linkedin = txtLinkedin.Text
    '        q.Googleplus = txtGoogleplus.Text
    '        q.Twitter = txtTwitter.Text
    '        q.Facebook = txtFacebook.Text
    '        q.Biography_Fa = RadBiography_Fa.Content
    '        q.Biography_En = RadBiography_En.Content
    '        q.ResumeFile = txtResumeFile.Text
    '        q.About_Fa = txtResumeFile.Text 
    '        q.About_En = RadAbout_En.Content
    '        q.Job_Fa = txtJob_Fa.Text
    '        q.Job_En = txtJob_En.Text
    '        q.BioEdu_Fa = RadBioEdu_Fa.Content
    '        q.BioEdu_En = RadBioEdu_En.Content
    '        q.BioJob_Fa = RadBioJob_Fa.Content
    '        q.BioJob_En = RadBioJob_En.Content

    '        db.Users.InsertOnSubmit(q)
    '        db.SubmitChanges()
    '        UserView.DataBind()
    '    Catch ex As Exception
    '        Response.Write(ex.Message)
    '    End Try
    'End Sub

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
                If m.NameAndFamily_En <> "" Then 'Or q.NameAndFamily_En IsNot Nothing Then
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
                'ElseIf m.NameAndFamilyFr <> "" Then 'Or q.NameAndFamilyFr IsNot Nothing
                '    msg = m.MSGFr
                '    If msg.Length > 51 Then
                '        msg = Substr(msg, 0, 51)
                '    Else
                '        msg = m.MSGFr
                '    End If
                '    If Trim(m.Seen) = "جدید" Then
                '        lblContactUss.Text += "<li><a href='Inbox.aspx?ID=" + m.IDCU.ToString + "' style='display:block;white-space:nowrap;border-bottom:1px solid #f4f4f4;'><div class='pull-right' style='display: block;'><span class='label label-success' style='margin-right:5px;margin-left:5px;'>" + m.Seen + "</span></div><h4 style='padding: 0;margin: 0 0 0 45px;color:#444444;font-size:12px;position:relative;margin-top:10px;' title='" + m.MSGFr + "'>" + m.NameAndFamilyFr + "<small style='color:#999999;font-size:9px;position:absolute;top:0;left:0;'><br/><i class='fa fa-clock-o'style='margin:5px;'> </i>" + m.Moment_Fa + "</small></h4><p style='direction:ltr;font-size: 10px;color: #888888;padding:15px;'title='" + m.MSGFr + "'>" + msg + "</p></a></li>"
                '        i = i + 1
                '        WarningCount += 1
                '    Else
                '        lblContactUss.Text += "<li><a href='Inbox.aspx?ID=" + m.IDCU.ToString + "' style='display:block;white-space:nowrap;border-bottom:1px solid #f4f4f4;'><div class='pull-right' style='display: block;'><span class='label label-warning' style='margin-right:5px;margin-left:5px;'>" + m.Seen + "</span></div><h4 style='padding: 0;margin: 0 0 0 45px;color:#444444;font-size:12px;position:relative;margin-top:10px;' title='" + m.MSGFr + "'>" + m.NameAndFamilyFr + "<small style='color:#999999;font-size:9px;position:absolute;top:0;left:0;'><br/><i class='fa fa-clock-o'style='margin:5px;'> </i>" + m.Moment_Fa + "</small></h4><p style='direction:ltr;font-size: 10px;color: #888888;padding:15px;' title='" + m.MSGFr + "'>" + msg + "</p></a></li>"
                '    End If
                'ElseIf m.NameAndFamilyAr <> "" Then 'Or q.NameAndFamilyAr IsNot Nothing
                '    msg = m.MSGAr
                '    If msg.Length > 51 Then
                '        msg = Substr(msg, 0, 51)
                '    Else
                '        msg = m.MSGAr
                '    End If
                '    If Trim(m.Seen) = "جدید" Then
                '        lblContactUss.Text += "<li><a href='Inbox.aspx?ID=" + m.IDCU.ToString + "' style='display:block;white-space:nowrap;border-bottom:1px solid #f4f4f4;'><div class='pull-right' style='display: block;'><span class='label label-success' style='margin-right:5px;margin-left:5px;'>" + m.Seen + "</span></div><h4 style='padding: 0;margin: 0 0 0 45px;color:#444444;font-size:12px;position:relative;margin-top:10px;' title='" + m.MSGAr + "'>" + m.NameAndFamilyAr + "<small style='color:#999999;font-size:9px;position:absolute;top:0;left:0;'><br/><i class='fa fa-clock-o'style='margin:5px;'> </i>" + m.Moment_Fa + "</small></h4><p style='direction:rtl;font-size: 10px;color: #888888;padding:15px;'title='" + m.MSGAr + "'>" + msg + "</p></a></li>"
                '        i = i + 1
                '        WarningCount += 1
                '    Else
                '        lblContactUss.Text += "<li><a href='Inbox.aspx?ID=" + m.IDCU.ToString + "' style='display:block;white-space:nowrap;border-bottom:1px solid #f4f4f4;'><div class='pull-right' style='display: block;'><span class='label label-warning' style='margin-right:5px;margin-left:5px;'>" + m.Seen + "</span></div><h4 style='padding: 0;margin: 0 0 0 45px;color:#444444;font-size:12px;position:relative;margin-top:10px;' title='" + m.MSGAr + "'>" + m.NameAndFamilyAr + "<small style='color:#999999;font-size:9px;position:absolute;top:0;left:0;'><br/><i class='fa fa-clock-o'style='margin:5px;'> </i>" + m.Moment_Fa + "</small></h4><p style='direction:rtl;font-size: 10px;color: #888888;padding:15px;' title='" + m.MSGAr + "'>" + msg + "</p></a></li>"
                '    End If
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
    End Sub
    Public Function Substr(InputText As String, StartIndex As Integer, Length As Integer) As String

        Return InputText.Substring(StartIndex, Length) + " ... "
    End Function
    Protected Sub UserView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UserView.SelectedIndexChanged
        Try
            Dim db = New LinqDBClassesDataContext
            Dim qry = From m In db.Users
                      Select m
                      Where m.IDU = Convert.ToInt32(UserView.SelectedValue)
            For Each q In qry
                txtPassword.Text = q.Password
                txtPhone1.Text = q.Phone1
                'txtPhone2.Text = q.Phone2
                RadAddress1.Content = q.Address1_Fa
                'RadAddress2.Content = q.Address2
                txtMobile1.Text = q.Mobile1
                'txtMobile2.Text = q.Mobile2
                txtEmail.Text = q.Email
                txtWebsite.Text = q.Website
                txtPhotoMin.Text = q.PhotoMin
                txtPhotoMax.Text = q.PhotoMax
                txtInstagram.Text = q.Instagram
                txtTelegram.Text = q.Telegram
                txtLinkedin.Text = q.Linkedin
                txtGoogleplus.Text = q.Googleplus
                txtTwitter.Text = q.Twitter
                txtFacebook.Text = q.Facebook
                RadBiography_Fa.Content = q.Biography_Fa
                RadBiography_En.Content = q.Biography_En
                'RadBiographyFr.Content = q.BiographyFr
                'RadBiographyAr.Content = q.BiographyAr
                'txtResumeFile.Text = q.ResumeFile
                'txtResumeFile.Text = q.About_Fa
                'RadAbout_En.Content = q.About_En
                txtJob_Fa.Text = q.Job_Fa
                txtJob_En.Text = q.Job_En
                'txtJobFr.Text = q.JobFr
                'txtJobAr.Text = q.JobAr
                'RadBioEdu_Fa.Content = q.BioEdu_Fa
                'RadBioEdu_En.Content = q.BioEdu_En
                'RadBioJob_Fa.Content = q.BioJob_Fa
                'RadBioJob_En.Content = q.BioJob_En
            Next
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class
