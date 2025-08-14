
Partial Class Admin_CommentManagement
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
        Dim lblActiveParent As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIContentPages"))
        lblActiveParent.Attributes("Class") = "treeview active"
        Dim lblActive As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIMainPMs"))
        lblActive.Attributes("Class") = "treeview active"
        'txtMoment_En.Value = Date_En()
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
    Protected Sub CommentsView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CommentsView.SelectedIndexChanged
        Dim db = New LinqDBClassesDataContext
        Try
            Dim qryComments = From m In db.Comments
                              Select m Where m.IDC = Convert.ToInt32(CommentsView.SelectedValue)
            For Each q In qryComments
                Try
                    If q.Action = "Post" Then
                        Dim qryMessage = From n In db.Messages
                                         Select n Where n.IDMessage = q.IDElement
                        For Each a In qryMessage
                            Dim lbl = New Label
                            Dim lblbr = New Label
                            If a.Title_Fa <> "" Then 'Farsi
                                lbl.Text = "<hr />دیدگاه انتخابی مربوط به: <div class='row'><div class='col-sm-12 padding-fix'><h5>" + a.Moment_Fa.ToString.Remove(a.Moment_Fa.ToString.Length - 8, 8) + " نوشته شده توسط <a target='Blank' href='/Index#section2'>" + a.WrittenBy_Fa + "</a></h5><h5 style='margin-top:0;'><span class='fa fa-pencil-square-o'></span> <a target='Blank' href='\PostView?Action=Post&ID=" + a.IDMessage.ToString + "&Tag=" + a.Keyword_Fa.ToString.Replace(";", "-") + "'>" + a.Title_Fa + "</a></h5></div></div>"
                                lbl.Text += "<div class='row' ><div class='col-sm-12'> کلمات کلیدی: "
                                For Each i In a.Keyword_Fa.ToString.Split(";")
                                    lbl.Text = lbl.Text + "<a target='Blank' href='\Result?Search=" + i.ToString + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;font-size:small;'>" + i.ToString + "</a>"
                                Next
                                lbl.Text += "<a target='Blank' href='\PostView?Action=Post&ID=" + a.IDMessage.ToString + "&Tag=" + a.Keyword_Fa.ToString.Replace(";", "-") + "' class='btn btn-primary' style='float:left;margin-left:50px;'>نمایش</a></div></div><br/>"
                            ElseIf a.Title_En <> "" Then 'English
                                lbl.Text = "<hr />دیدگاه انتخابی مربوط به: <div class='row' style='direction:ltr;'><div style='margin-right:-15px;' class='col-sm-12 padding-fix'><h5>" + a.Moment_En.ToString + " Written By <a target='Blank' href='/En/Index#section2'>" + a.WrittenBy_En + "</a></h5><h5 style='margin-top:0;'><span class='fa fa-pencil-square-o'></span> <a target='Blank' href='\En\PostView?Action=Post&ID=" + a.IDMessage.ToString + "&Tag=" + a.Keyword_En.ToString.Replace(";", "-") + "'>" + a.Title_En + "</a></h5></div></div>"
                                lbl.Text += "<div class='row' style='direction:ltr;margin-left:10px;'><div class='col-sm-12'> Keywords: " '
                                For Each i In a.Keyword_En.ToString.Split(";")
                                    lbl.Text = lbl.Text + "<a target='Blank' href='\En\Result?Search=" + i.ToString + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;font-size:small;'>" + i.ToString + "</a>"
                                Next
                                lbl.Text += "<a target='Blank' href='\En\PostView?Action=Post&ID=" + a.IDMessage.ToString + "&Tag=" + a.Keyword_En.ToString.Replace(";", "-") + "' class='btn btn-primary' style='float:Right;margin-Right:50px;'>View</a></div></div><br/>"
                            End If
                            lblPM.Text = lbl.Text
                        Next

                    ElseIf q.Action = "FAQ" Then
                        Dim qryFAQ = From s In db.FAQms
                                     Select s Where s.IDF = q.IDElement
                        For Each b In qryFAQ
                            Dim lbl = New Label
                            Dim lblbr = New Label
                            If b.Question_Fa <> "" Then  'Farsi
                                lbl.Text = "<hr />دیدگاه انتخابی مربوط به: <div class='row' ><div class='col-sm-12 padding-fix'><h5>" + q.Moment_Fa.ToString.Remove(q.Moment_Fa.ToString.Length - 8, 8) + " پرسیده شده توسط <a style='text-decoration:none;'>" + q.NameAndFamily_Fa + "</a></h5><h5 style='margin-top:0;'><span class='fa fa-question-circle'></span> <a target='Blank' href='\PostView?Action=FAQ&ID=" + b.IDF.ToString + "&Tag=" + b.Keyword_Fa.ToString.Replace(";", "-") + "'>" + b.Question_Fa + "</a></h5></div></div>"
                                'End If
                                lbl.Text += "<div class='row' ><div class='col-sm-12'> کلمات کلیدی: "
                                For Each i In b.Keyword_Fa.ToString.Split(";")
                                    lbl.Text = lbl.Text + "<a target='Blank' href='\Result?Search=" + i.ToString + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;font-size:small;'>" + i.ToString + "</a>"
                                Next
                                lbl.Text += "<a target='Blank' href='\PostView?Action=FAQ&ID=" + b.IDF.ToString + "&Tag=" + b.Keyword_Fa.ToString.Replace(";", "-") + "' class='btn btn-primary' style='float:left;margin-left:50px;'>نمایش</a></div></div><br/>"
                                'FAQPlaceHolder.Controls.Add(lbl)
                            ElseIf b.Question_En <> "" Then  'English
                                lbl.Text = "<hr />دیدگاه انتخابی مربوط به: <div class='row' style='direction:ltr;'><div style='margin-right:-15px;'class='col-sm-12 padding-fix'><h5>" + q.Moment_En.ToString + " Asked By <a style='text-decoration:none;'>" + q.NameAndFamily_En + "</a></h5><h5 style='margin-top:0;'><span class='fa fa-question-circle'></span> <a target='Blank' href='\En\PostView?Action=FAQ&ID=" + b.IDF.ToString + "&Tag=" + b.Keyword_En.ToString.Replace(";", "-") + "'>" + b.Question_En + "</a></h5></div></div>"
                                'End If
                                lbl.Text += "<div class='row' style='direction:ltr;margin-left:10px;' ><div class='col-sm-12'> Keywords: "
                                For Each i In b.Keyword_En.ToString.Split(";")
                                    lbl.Text = lbl.Text + "<a target='Blank' href='\En\Result?Search=" + i.ToString + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;font-size:small;'>" + i.ToString + "</a>"
                                Next
                                lbl.Text += "<a target='Blank' href='\En\PostView?Action=FAQ&ID=" + b.IDF.ToString + "&Tag=" + b.Keyword_En.ToString.Replace(";", "-") + "' class='btn btn-primary' style='float:right;margin-left:50px;'>View</a></div></div><br/>"
                            End If
                            lblPM.Text = lbl.Text
                        Next
                    ElseIf q.Action = "Page" Then
                        Dim qryPage = From s In db.Pages
                                      Select s Where s.ID = q.IDElement
                        For Each b In qryPage
                            Dim lbl = New Label
                            Dim lblbr = New Label
                            If b.PageTitle_Fa <> "" Then  'Farsi
                                lbl.Text = "<hr />دیدگاه انتخابی مربوط به: <div class='row'><div class='col-sm-12 padding-fix'><h5 style='margin-top:5px;'><span class='fa fa-edit '></span> صفحه پویا با عنوان <a target='Blank' href='\PostView?Action=Page&ID=" + b.ID.ToString + "&Tag=" + b.Keyword_Fa.ToString.Replace(";", "-") + "'>" + b.PageTitle_Fa + "</a></h5></div></div>"
                                lbl.Text += "<div class='row' ><div class='col-sm-12'> کلمات کلیدی: "
                                For Each i In b.Keyword_Fa.ToString.Split(";")
                                    lbl.Text = lbl.Text + "<a target='Blank' href='\Result?Search=" + i.ToString + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;font-size:small;'>" + i.ToString + "</a>"
                                Next
                                lbl.Text += "<a target='Blank' href='\PostView?Action=Page&ID=" + b.ID.ToString + "&Tag=" + b.Keyword_Fa.ToString.Replace(";", "-") + "' class='btn btn-primary' style='float:left;margin-left:50px;'>نمایش</a></div></div><br/>"
                                'FAQPlaceHolder.Controls.Add(lbl)
                            ElseIf b.PageTitle_En <> "" Then  'English
                                lbl.Text = "<hr />دیدگاه انتخابی مربوط به: <div class='row' style='direction:ltr;'><div style='margin-right:-15px;' class='col-sm-12 padding-fix'><h5 style='margin-top:5px;'><span class='fa fa-edit '></span> Dynamic page titled <a target='Blank' href='\En\PostView?Action=Page&ID=" + b.ID.ToString + "&Tag=" + b.Keyword_En.ToString.Replace(";", "-") + "'>" + b.PageTitle_En + "</a></h5></div></div>"
                                lbl.Text += "<div class='row' style='direction:ltr;margin-left:10px;'><div class='col-sm-12'> Keywords: "
                                For Each i In b.Keyword_En.ToString.Split(";")
                                    lbl.Text = lbl.Text + "<a target='Blank' href='\En\Result?Search=" + i.ToString + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;font-size:small;'>" + i.ToString + "</a>"
                                Next
                                lbl.Text += "<a target='Blank' href='\En\PostView?Action=Page&ID=" + b.ID.ToString + "&Tag=" + b.Keyword_En.ToString.Replace(";", "-") + "' class='btn btn-primary' style='float:right;margin-left:50px;'>View</a></div></div><br/>"
                            End If
                            lblPM.Text = lbl.Text
                        Next
                    End If
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try
                txtComment_Fa.Text = q.MSG_Fa
                txtComment_En.Text = q.MSG_En
                txtWebsite.Value = q.WebSite
                txtEmail.Value = q.Email
                txtNameAndFamily_Fa.Text = q.NameAndFamily_Fa
                txtNameAndFamily_En.Text = q.NameAndFamily_En
                lblMomentOld_Fa.Text = q.Moment_Fa
                lblMomentOld_En.Text = q.Moment_En
                drpActive.SelectedValue = q.Active
            Next
            Try
                Dim qry = From m In db.Comments
                          Select m Where m.IDC = Convert.ToInt32(CommentsView.SelectedValue)
                For Each q In qry
                    q.Seen = "دیده شده"
                Next
                db.SubmitChanges()
                CommentsView.DataBind()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
            txtSubCommentMoment_En.Value = Date_En()
            txtSubCommentMoment_Fa.Text = tarikh.Value
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub SubCommentView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SubCommentView.SelectedIndexChanged
        Dim db = New LinqDBClassesDataContext
        Try
            Dim qrySubComments = From m In db.Comments
                                 Select m Where m.IDC = Convert.ToInt32(SubCommentView.SelectedValue)
            For Each q In qrySubComments
                txtSubComment_Fa.Text = q.MSG_Fa
                txtSubComment_En.Text = q.MSG_En
                txtSubCommentMoment_En.Value = Date_En()
                txtSubCommentMoment_Fa.Text = tarikh.Value
                lblSubCommentMoment_Fa.Text = q.Moment_Fa
                lblSubCommentMoment_En.Text = q.Moment_En
            Next
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub
    Protected Sub btnUpdateComment_Click(sender As Object, e As EventArgs) Handles btnUpdateComment.Click
        Dim db = New LinqDBClassesDataContext
        Try
            Dim qryComments = From m In db.Comments
                              Select m Where m.IDC = Convert.ToInt32(CommentsView.SelectedValue)
            For Each q In qryComments
                q.MSG_Fa = txtComment_Fa.Text
                q.MSG_En = txtComment_En.Text
                q.NameAndFamily_Fa = txtNameAndFamily_Fa.Text
                q.NameAndFamily_En = txtNameAndFamily_En.Text
                q.Email = txtEmail.Value
                q.WebSite = txtWebsite.Value
                'q.NameAndFamilyFr = txtNameAndFamilyFr.Text
                'q.NameAndFamilyAr = txtNameAndFamilyAr.Text
                q.Moment_Fa = tarikh.Value
                q.Moment_En = txtMoment_En.Value
                q.Parent = 0
                Dim T As Integer = 0
                For Each i In txtMoment_En.Value.ToString.Split("-")
                    If T = 0 Then
                        q.Year_En = Convert.ToInt16(i)
                    ElseIf T = 1 Then
                        Select Case i
                            Case "January"
                                q.Month_En = 1
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
                    ElseIf T = 2 Then
                        q.Day_En = Convert.ToInt16(i)
                    End If
                    T = T + 1
                Next
                q.Active = drpActive.SelectedValue
            Next
            db.SubmitChanges()
            CommentsView.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnUpdateSubComment_Click(sender As Object, e As EventArgs) Handles btnUpdateSubComment.Click
        Dim db = New LinqDBClassesDataContext
        Try
            Dim qrySubComments = From m In db.Comments
                                 Select m Where m.IDC = Convert.ToInt32(SubCommentView.SelectedValue)
            For Each q In qrySubComments
                q.MSG_Fa = txtSubComment_Fa.Text
                q.MSG_En = txtSubComment_En.Text
                Try
                    q.NameAndFamily_Fa = Request.Cookies("OnLineName_En").Value + " " + Request.Cookies("OlineFamily_En").Value
                    q.NameAndFamily_En = Request.Cookies("OnLineName_Fa").Value + " " + Request.Cookies("OlineFamily_Fa").Value
                    q.Email = Request.Cookies("OnLineEmail").Value
                    q.WebSite = Request.Cookies("OnLineWebSite").Value
                Catch ex As Exception
                    Dim qry1 = From m In db.Users
                               Select m Where m.Username = HttpContext.Current.User.Identity.Name.ToString()
                    For Each b In qry1
                        q.NameAndFamily_Fa = b.Name_Fa + " " + b.Family_Fa
                        q.NameAndFamily_En = b.Name_En + " " + b.Family_En
                        q.Email = b.Email
                        q.WebSite = b.Website
                    Next
                End Try
                q.Moment_Fa = txtSubCommentMoment_Fa.Text
                q.Moment_En = txtSubCommentMoment_En.Value
                q.Action = "پاسخ"
                q.Active = True
                q.Access = "All"
                q.Keyword_En = "Unknown"
                q.Keyword_Fa = "نامشخص"
                q.IDElement = "0"
                q.IsShow = True
                Dim T As Integer = 0
                For Each i In txtMoment_En.Value.ToString.Split("-")
                    If T = 0 Then
                        q.Year_En = Convert.ToInt16(i)
                    ElseIf T = 1 Then
                        Select Case i
                            Case "January"
                                q.Month_En = 1
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
                    ElseIf T = 2 Then
                        q.Day_En = Convert.ToInt16(i)
                    End If
                    T = T + 1
                Next
            Next
            db.SubmitChanges()
            CommentsView.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnSaveNewSubComment_Click(sender As Object, e As EventArgs) Handles btnSaveNewSubComment.Click
        Dim db = New LinqDBClassesDataContext
        Try
            Dim q = New Comment
            q.MSG_Fa = txtSubComment_Fa.Text
            q.MSG_En = txtSubComment_En.Text
            q.Seen = "دیده شده"
            q.Action = "پاسخ"
            q.Active = True
            q.Access = "All"
            q.Keyword_En = "Unknown"
            q.Keyword_Fa = "نامشخص"
            q.IDElement = "0"
            q.IsShow = True
            Try
                q.NameAndFamily_Fa = Request.Cookies("OnLineName_En").Value + " " + Request.Cookies("OlineFamily_En").Value
                q.NameAndFamily_En = Request.Cookies("OnLineName_Fa").Value + " " + Request.Cookies("OlineFamily_Fa").Value
                q.Email = Request.Cookies("OnLineEmail").Value
                q.WebSite = Request.Cookies("OnLineWebSite").Value
            Catch ex As Exception
                Dim qry1 = From m In db.Users
                           Select m Where m.Username = HttpContext.Current.User.Identity.Name.ToString()
                For Each b In qry1
                    q.NameAndFamily_Fa = b.Name_Fa + " " + b.Family_Fa
                    q.NameAndFamily_En = b.Name_En + " " + b.Family_En
                    q.Email = b.Email
                    q.WebSite = b.Website
                Next
            End Try
            q.Moment_Fa = txtSubCommentMoment_Fa.Text
            q.Moment_En = txtSubCommentMoment_En.Value
            Dim T As Integer = 0
            For Each i In txtMoment_En.Value.ToString.Split("-")
                If T = 0 Then
                    q.Year_En = Convert.ToInt16(i)
                ElseIf T = 1 Then
                    Select Case i
                        Case "January"
                            q.Month_En = 1
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
                ElseIf T = 2 Then
                    q.Day_En = Convert.ToInt16(i)
                End If
                T = T + 1
            Next
            q.Parent = Convert.ToInt32(CommentsView.SelectedValue)
            db.Comments.InsertOnSubmit(q)
            db.SubmitChanges()
            SubCommentView.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Private Sub Admin_CommentManagement_InitComplete(sender As Object, e As EventArgs) Handles Me.InitComplete
        txtMoment_En.Value = Date_En()
    End Sub
End Class
