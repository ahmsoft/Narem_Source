
Partial Class FAQManagement1
    Inherits System.Web.UI.Page
    Protected Sub btnUpdateMessage_Click(sender As Object, e As EventArgs) Handles btnUpdateMessage.Click
        Try
            Dim db = New LinqDBClassesDataContext
            Dim qry = From m In db.FAQms 
                      Select m Where m.IDF = Convert.ToInt32(FAQView.SelectedValue)
            For Each q In qry
                q.AskedBy_Fa = txtNameAndFamily_Fa.Text
                q.AskedBy_En = txtNameAndFamily_En.Text
                'q.NameAndFamilyFr = txtNameAndFamilyFr.Text
                'q.NameAndFamilyAr = txtNameAndFamilyAr.Text
                q.Question_Fa = txtQuestion_Fa.Text
                q.Question_En = txtQuestion_En.Text
                'q.QuestionFr = txtQuestionFr.Text
                'q.QuestionAr = txtQuestionAr.Text
                'q.PreAnswer_Fa = RadPreAnswer_Fa.Content
                'q.PreAnswer_En = RadPreAnswer_En.Content
                'q.PreAnswerFr = RadPreAnswerFr.Content
                'q.PreAnswerAr = RadPreAnswerAr.Content
                q.Answer_Fa = RadAnswer_Fa.Content
                q.Answer_En = RadAnswer_En.Content
                'q.AnswerFr = RadAnswerFr.Content
                'q.AnswerAr = RadAnswerAr.Content
                q.Keyword_Fa = txtKeyword_Fa.Text
                q.Keyword_En = txtKeyword_En.Text
                'q.KeywordFr = txtKeywordFr.Text
                'q.KeywordAr = txtKeywordAr.Text
                q.IsShow = chkIsShow.Checked
               'q.Email = txtEmail.Text
                'q.WebSite = txtWebsite.Text
                q.Priority = txtPriority.Text
                q.Moment_Fa = tarikh.Value
                q.Moment_En = txtMoment_En.Value
                dim T As Integer =0
            For Each i In txtMoment_En.Value.ToString.Split("-")
                    If T=0 Then
                    q.Year_En=Convert.ToInt16(i)
                    ElseIf T=1 Then
                    Select Case i
                        Case "January"
                            q.Month_En  = 1
                        Case "February"
                             q.Month_En = 2
                        Case "March"
                             q.Month_En = 3
                        Case "April"
                             q.Month_En = 4
                        Case "May"
                             q.Month_En = 5
                        Case "June"
                             q.Month_En = 6
                        Case "July"
                             q.Month_En = 7
                        Case "August"
                             q.Month_En = 8
                        Case "September"
                             q.Month_En = 9
                        Case "October"
                             q.Month_En = 10
                        Case "November"
                             q.Month_En = 11
                        Case "December"
                             q.Month_En = 12
                    End Select
                    ElseIf T=2 Then
                        q.Day_En=Convert.ToInt16(i)
                    End If 
                    T=T+1
                Next
            Next
            db.SubmitChanges()
            FAQView.DataBind()

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
    Protected Sub FAQView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FAQView.SelectedIndexChanged
        Dim db = New LinqDBClassesDataContext
        Try
            Dim qry = From m In db.FAQms
                      Select m Where m.IDF = Convert.ToInt32(FAQView.SelectedValue)
            For Each q In qry
                q.Seen = "دیده شده"
            Next
            db.SubmitChanges()
            FAQView.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        Try
            Dim qry = From m In db.FAQms
                      Select m
                      Where m.IDF = Convert.ToInt32(FAQView.SelectedValue)
            For Each q In qry
                txtNameAndFamily_Fa.Text = q.AskedBy_Fa 
                txtNameAndFamily_En.Text = q.AskedBy_En
                'txtNameAndFamilyFr.Text = q.NameAndFamilyFr
                'txtNameAndFamilyAr.Text = q.NameAndFamilyAr
                txtQuestion_Fa.Text = q.Question_Fa
                txtQuestion_En.Text = q.Question_En
                'txtQuestionFr.Text = q.QuestionFr
                'txtQuestionAr.Text = q.QuestionAr
                'RadPreAnswer_Fa.Content = q.PreAnswer_Fa
                'RadPreAnswer_En.Content = q.PreAnswer_En
                'RadPreAnswerFr.Content = q.PreAnswerFr
                'RadPreAnswerAr.Content = q.PreAnswerAr
                RadAnswer_Fa.Content = q.Answer_Fa
                RadAnswer_En.Content = q.Answer_En
                'RadAnswerFr.Content = q.AnswerFr
                'RadAnswerAr.Content = q.AnswerAr
                txtKeyword_Fa.Text = q.Keyword_Fa
                txtKeyword_En.Text = q.Keyword_En
                'txtKeywordFr.Text = q.KeywordFr
                'txtKeywordAr.Text = q.KeywordAr
                'txtEmail.Text = q.Email
                'txtWebsite.Text = q.WebSite
                txtPriority.Text = q.Priority
                lblMomentOld_Fa.Text = q.Moment_Fa
                lblMomentOld_En.Text = q.Moment_En
                chkIsShow.Checked = q.IsShow
                'CatDropDownList.SelectedValue
                'lblOldMoment.Text = "این پیام در زمان " + q.Moment + " توسط شما ثبت شده "
                'txtPicPost.Text = q.Pic
                'lblOldMoment.Text = "این پیام در زمان " + q.Moment + " توسط شما ثبت شده "
            Next
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnSaveNewMessage_Click(sender As Object, e As EventArgs) Handles btnSaveNewMessage.Click
        Try
            Dim db = New LinqDBClassesDataContext
            Dim q = New FAQm
            chkIsShow.Checked = q.IsShow
            q.Question_Fa = txtQuestion_Fa.Text
            q.Question_En = txtQuestion_En.Text
            'q.QuestionFr = txtQuestionFr.Text
            'q.QuestionAr = txtQuestionAr.Text
            'q.PreAnswer_Fa = RadPreAnswer_Fa.Content
            'q.PreAnswer_En = RadPreAnswer_En.Content
            'q.PreAnswerFr = RadPreAnswerFr.Content
            'q.PreAnswerAr = RadPreAnswerAr.Content
            q.Answer_Fa = RadAnswer_Fa.Content
            q.Answer_En = RadAnswer_En.Content
            'q.AnswerFr = RadAnswerFr.Content
            'q.AnswerAr = RadAnswerAr.Content
            q.Keyword_Fa = txtKeyword_Fa.Text
            q.Keyword_En = txtKeyword_En.Text
            'q.KeywordFr = txtKeywordFr.Text
            'q.KeywordAr = txtKeywordAr.Text
            'q.Email = txtEmail.Text
            'q.WebSite = txtWebsite.Text
            q.Priority = txtPriority.Text
            'q.NameAndFamily_Fa = txtNameAndFamily_Fa.Text
            'q.NameAndFamily_En = txtNameAndFamily_En.Text
            'q.NameAndFamilyFr = txtNameAndFamilyFr.Text
            'q.NameAndFamilyAr = txtNameAndFamilyAr.Text
            q.Moment_Fa = tarikh.Value
            q.Moment_En = txtMoment_En.Value
            dim T As Integer =0
            For Each i In txtMoment_En.Value.ToString.Split("-")
                    If T=0 Then
                    q.Year_En=Convert.ToInt16(i)
                    ElseIf T=1 Then
                    Select Case i
                        Case "January"
                            q.Month_En  = 1
                        Case "February"
                             q.Month_En = 2
                        Case "March"
                             q.Month_En = 3
                        Case "April"
                             q.Month_En = 4
                        Case "May"
                             q.Month_En = 5
                        Case "June"
                             q.Month_En = 6
                        Case "July"
                             q.Month_En = 7
                        Case "August"
                             q.Month_En = 8
                        Case "September"
                             q.Month_En = 9
                        Case "October"
                             q.Month_En = 10
                        Case "November"
                             q.Month_En = 11
                        Case "December"
                             q.Month_En = 12
                    End Select
                    ElseIf T=2 Then
                        q.Day_En=Convert.ToInt16(i)
                    End If 
                    T=T+1
                Next
            db.FAQms.InsertOnSubmit(q)
            db.SubmitChanges()
            FAQView.DataBind()
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
        'txtMoment_En.Value = Date_En()
        Dim lblActiveParent As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIContentPages"))
        lblActiveParent.Attributes("Class") = "treeview active"
        Dim lblActive As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIFAQs"))
        lblActive.Attributes("Class") = "treeview active"
    End Sub

    Private Sub FAQManagement1_InitComplete(sender As Object, e As EventArgs) Handles Me.InitComplete
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
