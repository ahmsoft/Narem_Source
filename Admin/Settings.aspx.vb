
Partial Class Admin_Settings
    Inherits System.Web.UI.Page
    Private Sub btnUpdateSettings_Click(sender As Object, e As EventArgs) Handles btnUpdateSettings.Click
        Try
            'Dim ENC As New AHMSECKEY()
            Dim db = New LinqDBClassesDataContext
            Dim qry = From m In db.Settings
                      Select m Where m.IDS = Convert.ToInt32(SettingsView.SelectedValue)
            For Each q In qry
                q.NameSettings = txtSettingName.Text

                q.NameBrand_Fa = txtBrand_Fa.Text
                q.NameBrand_En = txtBrand_En.Text

                q.NameCorporation_Fa = txtCoName_Fa.Text
                q.NameCorporation_En = txtCoName_En.Text

                q.TitleSite_Fa = txtSiteTitle_Fa.Text
                q.TitleSite_En = txtSiteTitle_En.Text

                q.TEL1 = txtPhone1.Text
                q.TEL2 = txtPhone2.Text

                q.Address1_Fa = RadAddress1_Fa.Content
                q.Address1_En = RadAddress1_En.Content
                q.Address2_Fa = RadAddress2_Fa.Content
                q.Address2_En = RadAddress2_En.Content

                q.NameSite_Fa = txtSiteName_Fa.Text
                q.NameSite_En = txtSiteName_En.Text

                q.EmailCo = txtEmailCo.Text

                q.EmailSupport = txtEmailSupport.Text

                q.Website = txtWebsite.Text

                q.LogoImageMini = txtLogoImageMini.Text

                q.LogoImageMax = txtLogoImageMax.Text

                q.Instagram = txtInstagram.Text
                q.Telegram = txtTelegram.Text
                q.Linkedin = txtLinkedin.Text
                q.Googleplus = txtGoogleplus.Text
                q.Twitter = txtTwitter.Text
                q.Facebook = txtFacebook.Text

                q.Terms_Fa = RadTerms_Fa.Content
                q.Terms_En = RadTerms_En.Content

                q.PrivacyPolicy_Fa = RadPrivacyPolicy_Fa.Content
                q.PrivacyPolicy_En = RadPrivacyPolicy_En.Content

                q.SafePay_Fa = RadSafePay_Fa.Content
                q.SafePay_En = RadSafePay_En.Content

                q.AvatarImage = txtAvatarImage.Text

                q.About_Fa = RadAbout_Fa.Content
                q.About_En = RadAbout_En.Content

                q.Description_Fa = RadDescription_Fa.Content
                q.Description_En = RadDescription_En.Content

                q.Slogan_Fa = txtSlogan_Fa.Text
                q.Slogan_En = txtSlogan_En.Text

                q.WorkingHours_Fa = RadWorkingHours_Fa.Content
                q.WorkingHours_En = RadWorkingHours_En.Content


                q.SpecialOffers_Fa = RadSpecialOffers_Fa.Content
                q.SpecialOffers_En = RadSpecialOffers_En.Content

                q.CopyWrite_Fa = txtCopyWrite_Fa.Text
                q.CopyWrite_En = txtCopyWrite_Fa.Text

                q.Subject_Fa = txtSubject_Fa.Text
                q.Subject_En = txtSubject_En.Text

                q.Keywords_Fa = txtKeyword_Fa.Text
                q.Keywords_En = txtKeyword_En.Text

                q.CreateDay_Fa = txtCreateDay_Fa.Text
                q.CreateDay_En = txtCreateDay_En.Text
                q.CreateMonth_Fa = txtCreateMonth_Fa.Text
                q.CreateMonth_En = txtCreateMonth_En.Text
                q.CreateYear_Fa = txtCreateYear_Fa.Text
                q.CreateYear_En = txtCreateYear_En.Text

            Next
            db.SubmitChanges()
            SettingsView.DataBind()


        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnSaveNewSettings_Click(sender As Object, e As EventArgs) Handles btnSaveNewSettings.Click
        Try
            Dim db = New LinqDBClassesDataContext
            Dim q = New Setting
            q.NameSettings = txtSettingName.Text

            q.NameBrand_Fa = txtBrand_Fa.Text
            q.NameBrand_En = txtBrand_En.Text

            q.NameCorporation_Fa = txtCoName_Fa.Text
            q.NameCorporation_En = txtCoName_En.Text

            q.TitleSite_Fa = txtSiteTitle_Fa.Text
            q.TitleSite_En = txtSiteTitle_En.Text

            q.TEL1 = txtPhone1.Text
            q.TEL2 = txtPhone2.Text

            q.Address1_Fa = RadAddress1_Fa.Content
            q.Address1_En = RadAddress1_En.Content
            q.Address2_Fa = RadAddress2_Fa.Content
            q.Address2_En = RadAddress2_En.Content

            q.NameSite_Fa = txtSiteName_Fa.Text
            q.NameSite_En = txtSiteName_En.Text

            q.EmailCo = txtEmailCo.Text

            q.EmailSupport = txtEmailSupport.Text

            q.Website = txtWebsite.Text

            q.LogoImageMini = txtLogoImageMini.Text

            q.LogoImageMax = txtLogoImageMax.Text

            q.Instagram = txtInstagram.Text
            q.Telegram = txtTelegram.Text
            q.Linkedin = txtLinkedin.Text
            q.Googleplus = txtGoogleplus.Text
            q.Twitter = txtTwitter.Text
            q.Facebook = txtFacebook.Text

            q.Terms_Fa = RadTerms_Fa.Content
            q.Terms_En = RadTerms_En.Content

            q.PrivacyPolicy_Fa = RadPrivacyPolicy_Fa.Content
            q.PrivacyPolicy_En = RadPrivacyPolicy_En.Content

            q.AvatarImage = txtAvatarImage.Text

            q.About_Fa = RadAbout_Fa.Content
            q.About_En = RadAbout_En.Content

            q.Description_Fa = RadDescription_Fa.Content
            q.Description_En = RadDescription_En.Content

            q.Slogan_Fa = txtSlogan_Fa.Text
            q.Slogan_En = txtSlogan_En.Text

            q.WorkingHours_Fa = RadWorkingHours_Fa.Content
            q.WorkingHours_En = RadWorkingHours_En.Content


            q.SpecialOffers_Fa = RadSpecialOffers_Fa.Content
            q.SpecialOffers_En = RadSpecialOffers_En.Content

            q.CopyWrite_Fa = txtCopyWrite_Fa.Text
            q.CopyWrite_En = txtCopyWrite_Fa.Text

            q.Subject_Fa = txtSubject_Fa.Text
            q.Subject_En = txtSubject_En.Text

            q.Keywords_Fa = txtKeyword_Fa.Text
            q.Keywords_En = txtKeyword_En.Text

            q.CreateDay_Fa = txtCreateDay_Fa.Text
            q.CreateDay_En = txtCreateDay_En.Text
            q.CreateMonth_Fa = txtCreateMonth_Fa.Text
            q.CreateMonth_En = txtCreateMonth_En.Text
            q.CreateYear_Fa = txtCreateYear_Fa.Text
            q.CreateYear_En = txtCreateYear_En.Text

            db.Settings.InsertOnSubmit(q)
            db.SubmitChanges()
            SettingsView.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

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
    Protected Sub SettingsView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SettingsView.SelectedIndexChanged
        Try
            Dim db = New LinqDBClassesDataContext
            Dim qry = From m In db.Settings
                      Select m
                      Where m.IDS = Convert.ToInt32(SettingsView.SelectedValue)
            For Each q In qry
                txtSettingName.Text = q.NameSettings

                txtBrand_Fa.Text = q.NameBrand_Fa
                txtBrand_En.Text = q.NameBrand_En

                txtCoName_Fa.Text = q.NameCorporation_Fa
                txtCoName_En.Text = q.NameCorporation_En

                txtSiteTitle_Fa.Text = q.TitleSite_Fa
                txtSiteTitle_En.Text = q.TitleSite_En

                txtPhone1.Text = q.TEL1
                txtPhone2.Text = q.TEL2

                RadAddress1_Fa.Content = q.Address1_Fa
                RadAddress1_En.Content = q.Address1_En
                RadAddress2_Fa.Content = q.Address2_Fa
                RadAddress2_En.Content = q.Address2_En

                txtSiteName_Fa.Text = q.NameSite_Fa
                txtSiteName_En.Text = q.NameSite_En

                txtEmailCo.Text = q.EmailCo

                txtEmailSupport.Text = q.EmailSupport

                txtWebsite.Text = q.Website

                txtLogoImageMini.Text = q.LogoImageMini

                txtLogoImageMax.Text = q.LogoImageMax

                txtInstagram.Text = q.Instagram
                txtTelegram.Text = q.Telegram
                txtLinkedin.Text = q.Linkedin
                txtGoogleplus.Text = q.Googleplus
                txtTwitter.Text = q.Twitter
                txtFacebook.Text = q.Facebook

                RadTerms_Fa.Content = q.Terms_Fa
                RadTerms_En.Content = q.Terms_En

                RadSafePay_Fa.Content = q.SafePay_Fa
                RadSafePay_En.Content = q.SafePay_En

                RadPrivacyPolicy_Fa.Content = q.PrivacyPolicy_Fa
                RadPrivacyPolicy_En.Content = q.PrivacyPolicy_En

                txtAvatarImage.Text = q.AvatarImage

                RadAbout_Fa.Content = q.About_Fa
                RadAbout_En.Content = q.About_En

                RadDescription_Fa.Content = q.Description_Fa
                RadDescription_En.Content = q.Description_En

                RadMemo_Fa.Content = q.Memo_Fa
                RadMemo_En.Content = q.Memo_En

                txtSlogan_Fa.Text = q.Slogan_Fa
                txtSlogan_En.Text = q.Slogan_En

                RadWorkingHours_Fa.Content = q.WorkingHours_Fa
                RadWorkingHours_En.Content = q.WorkingHours_En

                RadSpecialOffers_Fa.Content = q.SpecialOffers_Fa
                RadSpecialOffers_En.Content = q.SpecialOffers_En

                txtCopyWrite_Fa.Text = q.CopyWrite_Fa
                txtCopyWrite_En.Text = q.CopyWrite_En

                txtSubject_Fa.Text = q.Subject_Fa
                txtSubject_En.Text = q.Subject_En

                txtKeyword_Fa.Text = q.Keywords_Fa
                txtKeyword_En.Text = q.Keywords_En

                txtCreateDay_Fa.Text = q.CreateDay_Fa
                txtCreateDay_En.Text = q.CreateDay_En
                txtCreateMonth_Fa.Text = q.CreateMonth_Fa
                txtCreateMonth_En.Text = q.CreateMonth_En
                txtCreateYear_Fa.Text = q.CreateYear_Fa
                txtCreateYear_En.Text = q.CreateYear_En
            Next
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class
