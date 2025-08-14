Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime

Partial Class MessageManagement
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
                If m.IsSupervisor = True And m.Authoritys.Contains("Posts") Then
                    lblAdminImage2.Text = "<img src='/" + m.PhotoMin + "' class='img-circle' alt='User Image' />"
                    lblAdminImage1.Text = "<img src='" + m.PhotoMin + "' class='user-image' alt='User Image'>"
                    lblAdminImage.Text = "<img src='/" + m.PhotoMin + "' class='img-circle' alt='User Image' />"
                    lblAdminNameFamily.Text = m.Name_Fa + " " + m.Family_Fa + "<br/><br/>"
                    lblAdminNameFamily1.Text = m.Name_Fa + " " + m.Family_Fa
                    lblAdminNameFamily2.Text = "<p style='z-index: 5;color: #fff;color: rgba(255, 255, 255, 0.8);font-size: 17px;margin-top: 10px;margin: 0 0 10px;display: block;-webkit-margin-before: 1em;-webkit-margin-after: 1em;-webkit-margin-start: 0px;-webkit-margin-end: 0px;'>" + m.Name_Fa + " " + m.Family_Fa + "<br /><small>مدیریت کل سایت</small></p>"
                Else
                    Session("StayAuthority") = 1
                    Response.Redirect("/Admin/AdminPanel.aspx")
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
        txtMomentNew_En.Text = Date_En()
        Dim lblActiveParent As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIContentPages"))
        lblActiveParent.Attributes("Class") = "treeview active"
        Dim lblActive As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIMainPMs"))
        lblActive.Attributes("Class") = "treeview active"
    End Sub
    Protected Sub btnUpdateMessage_Click(sender As Object, e As EventArgs) Handles btnUpdateMessage.Click
        Try
            Dim tmpCat As String = ""
            Dim db = New LinqDBClassesDataContext
            Dim qry = From m In db.Messages
                      Select m Where m.IDMessage = Convert.ToInt32(MessageView.SelectedValue)
            For Each q In qry
                q.Title_Fa = txtTitle_Fa.Text
                q.PreMessage_Fa = RadPreMessage_Fa.Content
                q.Message_Fa = RadMessage_Fa.Content
                q.Keyword_Fa = txtKeyword_Fa.Text
                q.Title_En = txtTitle_En.Text
                q.PreMessage_En = RadPreMessage_En.Content
                q.Message_En = RadMessage_En.Content
                q.Keyword_En = txtKeyword_En.Text
                q.Image = txtMetaPic.Text
                q.MetaDescription_Fa = txtMetaDescription_Fa.Text
                q.MetaDescription_En = txtMetaDescription_En.Text
                If txtMoment_Fa.Value = "" Then
                    q.Moment_Fa = tarikh.Text
                Else
                    q.Moment_Fa = txtMoment_Fa.Value
                End If
                If txtMoment_En.Value = "" Then
                    q.Moment_En = txtMomentNew_En.Text
                Else
                    q.Moment_En = txtMoment_En.Value
                End If
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
                'q.IDCat = CatDropDownList.SelectedValue
                q.IsShow = CheckBoxIsShow.Checked
                q.Priority = txtPriority.Text
                'If chkCat_Fa.Items(0).Selected = False Then
                For i = 0 To chkCat_Fa.Items.Count - 1
                    If chkCat_Fa.Items(i).Selected = True Then
                        tmpCat += chkCat_Fa.Items(i).Value + ";"
                    End If
                Next
                'ElseIf chkCat_Fa.Items(0).Selected = True Then
                '    For i = 0 To chkCat_Fa.Items.Count - 1
                '        tmpCat += chkCat_Fa.Items(i).Value + ";"
                '    Next
                'End If

                tmpCat = tmpCat.Substring(0, tmpCat.Length - 1)
                q.CatName_Fa = tmpCat
                tmpCat = ""
                'If chkCat_En.Items(0).Selected = False Then
                For i = 0 To chkCat_En.Items.Count - 1
                    If chkCat_En.Items(i).Selected = True Then
                        tmpCat += chkCat_En.Items(i).Value + ";"
                    End If
                Next
                'ElseIf chkCat_En.Items(0).Selected = True Then
                '    For i = 0 To chkCat_En.Items.Count - 1
                '        tmpCat += chkCat_En.Items(i).Value + ";"
                '    Next
                'End If
                tmpCat = tmpCat.Substring(0, tmpCat.Length - 1)
                q.CatName_En = tmpCat
                Try
                    q.WrittenBy_En = Request.Cookies("Name_En").Value + " " + Request.Cookies("Family_En").Value
                    q.WrittenBy_Fa = Request.Cookies("Name_Fa").Value + " " + Request.Cookies("Family_Fa").Value
                Catch ex As Exception
                    Dim qry1 = From m In db.Users
                               Select m Where m.Username = HttpContext.Current.User.Identity.Name.ToString()
                    For Each b In qry1
                        q.WrittenBy_Fa = b.Name_Fa + " " + b.Family_Fa
                        q.WrittenBy_En = b.Name_En + " " + b.Family_En
                    Next
                End Try
                'q.Pic = txtPicPost.Text
            Next
            db.SubmitChanges()
            MessageView.DataBind()

        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnSaveNewMessage_Click(sender As Object, e As EventArgs) Handles btnSaveNewMessage.Click
        Try
            Dim tmpCat As String = ""
            Dim db = New LinqDBClassesDataContext
            Dim q = New Message
            q.Title_Fa = txtTitle_Fa.Text
            q.Title_En = txtTitle_En.Text
            q.PreMessage_Fa = RadPreMessage_Fa.Content
            q.PreMessage_En = RadPreMessage_En.Content
            q.Message_Fa = RadMessage_Fa.Content
            q.Message_En = RadMessage_En.Content
            q.Keyword_Fa = txtKeyword_Fa.Text
            q.Keyword_En = txtKeyword_En.Text
            q.Image = txtMetaPic.Text
            q.MetaDescription_Fa = txtMetaDescription_Fa.Text
            q.MetaDescription_En = txtMetaDescription_En.Text
            'If chkCat_Fa.Items(0).Selected = False Then
            For i = 0 To chkCat_Fa.Items.Count - 1
                If chkCat_Fa.Items(i).Selected = True Then
                    tmpCat += chkCat_Fa.Items(i).Value + ";"
                End If
            Next
            'ElseIf chkCat_Fa.Items(0).Selected = True Then
            '    For i = 0 To chkCat_Fa.Items.Count - 1
            '        tmpCat += chkCat_Fa.Items(i).Value + ";"
            '    Next
            'End If

            tmpCat = tmpCat.Substring(0, tmpCat.Length - 1)
            q.CatName_Fa = tmpCat
            tmpCat = ""
            'If chkCat_En.Items(0).Selected = False Then
            For i = 0 To chkCat_En.Items.Count - 1
                If chkCat_En.Items(i).Selected = True Then
                    tmpCat += chkCat_En.Items(i).Value + ";"
                End If
            Next
            'ElseIf chkCat_En.Items(0).Selected = True Then
            '    For i = 0 To chkCat_En.Items.Count - 1
            '        tmpCat += chkCat_En.Items(i).Value + ";"
            '    Next
            'End If
            tmpCat = tmpCat.Substring(0, tmpCat.Length - 1)
            q.CatName_En = tmpCat
            Try
                q.WrittenBy_En = Request.Cookies("Name_En").Value + " " + Request.Cookies("Family_En").Value
                q.WrittenBy_Fa = Request.Cookies("Name_Fa").Value + " " + Request.Cookies("Family_Fa").Value
            Catch ex As Exception
                Dim qry1 = From m In db.Users
                           Select m Where m.Username = HttpContext.Current.User.Identity.Name.ToString()
                For Each b In qry1
                    q.WrittenBy_Fa = b.Name_Fa + " " + b.Family_Fa
                    q.WrittenBy_En = b.Name_En + " " + b.Family_En
                Next
            End Try
            'q.CommentCount = 0
            If txtMoment_Fa.Value = "" Then
                q.Moment_Fa = tarikh.Text
            Else
                q.Moment_Fa = txtMoment_Fa.Value
            End If
            If txtMoment_En.Value = "" Then
                q.Moment_En = txtMomentNew_En.Text
            Else
                q.Moment_En = txtMoment_En.Value
            End If
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
            q.IsShow = CheckBoxIsShow.Checked
            q.Priority = txtPriority.Text
            db.Messages.InsertOnSubmit(q)
            db.SubmitChanges()
            MessageView.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub MessageView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MessageView.SelectedIndexChanged
        Try
            Dim db = New LinqDBClassesDataContext
            Dim qryMessage = From m In db.Messages
                             Select m
                             Where m.IDMessage = Convert.ToInt32(MessageView.SelectedValue)

            For Each q In qryMessage
                txtTitle_Fa.Text = q.Title_Fa
                RadPreMessage_Fa.Content = q.PreMessage_Fa
                RadMessage_Fa.Content = q.Message_Fa
                txtKeyword_Fa.Text = q.Keyword_Fa
                txtTitle_En.Text = q.Title_En
                RadPreMessage_En.Content = q.PreMessage_En
                RadMessage_En.Content = q.Message_En
                txtKeyword_En.Text = q.Keyword_En
                chkCat_Fa.ClearSelection()
                For Each i In q.CatName_Fa.ToString.Split(";")
                    For k = 0 To chkCat_Fa.Items.Count - 1
                        If chkCat_Fa.Items(k).Value = i Then
                            chkCat_Fa.Items(k).Selected = True
                        End If
                    Next
                Next
                chkCat_En.ClearSelection()
                For Each i In q.CatName_En.ToString.Split(";")
                    For k = 0 To chkCat_En.Items.Count - 1
                        If chkCat_En.Items(k).Value = i Then
                            chkCat_En.Items(k).Selected = True
                        End If
                    Next
                Next
                CheckBoxIsShow.Checked = q.IsShow
                txtPriority.Text = q.Priority
                txtMoment_Fa.Value = q.Moment_Fa
                txtMoment_En.Value = q.Moment_En
                txtMetaDescription_Fa.Text = q.MetaDescription_Fa
                txtMetaDescription_En.Text = q.MetaDescription_En
                txtMetaPic.Text = q.Image
            Next
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
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
    Protected Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        DataSourceMessage.SelectCommand = "SELECT * FROM [Message] ORDER BY Year_En DESC, Month_En DESC, Day_En DESC, Priority DESC, IDMessage DESC" 'IDCat=@IDCat  ORDER BY IDCat DESC"
    End Sub
    Protected Sub CatDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CatDropDownList.SelectedIndexChanged
        Try
            Dim db = New LinqDBClassesDataContext
            Dim qryCat = From m In db.Categories
                         Select m
                         Where m.CatName_Fa = CatDropDownList.SelectedValue
            For Each q In qryCat
                txtCatName_Fa.Text = q.CatName_Fa
                txtCatName_En.Text = q.CatName_En
                txtCatDescription_Fa.Text = q.Description_Fa
                txtCatDescription_En.Text = q.Description_En
                txtCatPriority.Text = q.Priority.ToString
                txtCatID.Text = q.IDCat
            Next
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnUpdateCat_Click(sender As Object, e As EventArgs) Handles btnUpdateCat.Click
        Try
            Dim db = New LinqDBClassesDataContext
            Dim qryCat = From m In db.Categories
                         Select m
                         Where m.IDCat = Convert.ToInt32(CatDropDownList.SelectedValue)

            For Each q In qryCat
                q.CatName_Fa = txtCatName_Fa.Text
                q.CatName_En = txtCatName_En.Text
                q.Description_Fa = txtCatDescription_Fa.Text
                q.Description_En = txtCatDescription_En.Text
                q.Priority = txtCatPriority.Text
            Next
            db.SubmitChanges()
            CatDropDownList.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnSaveNewCat_Click(sender As Object, e As EventArgs) Handles btnSaveNewCat.Click
        Try
            Dim db = New LinqDBClassesDataContext
            Dim q = New Category
            q.CatName_Fa = txtCatName_Fa.Text
            q.CatName_En = txtCatName_En.Text
            q.Description_Fa = txtCatDescription_Fa.Text
            q.Description_En = txtCatDescription_En.Text
            q.Priority = txtCatPriority.Text
            q.IDCat = Convert.ToInt32(txtCatID.Text)
            db.Categories.InsertOnSubmit(q)
            db.SubmitChanges()
            CatDropDownList.DataBind()
            CatView.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        DataSourceMessage.SelectCommand = "SELECT * FROM [Message] WHERE Moment_Fa Like '%" + txtSearch.Text + "%' OR Moment_En Like '%" + txtSearch.Text + "%' OR Title_Fa Like '%" + txtSearch.Text + "%' OR Title_En Like '%" + txtSearch.Text + "%' OR Keyword_Fa Like '%" + txtSearch.Text + "%' OR Keyword_En Like '%" + txtSearch.Text + "%'" 'IDCat=@IDCat  ORDER BY IDCat DESC"
    End Sub
    Protected Sub CatView_RowDeleted(sender As Object, e As GridViewDeletedEventArgs) Handles CatView.RowDeleted
        CatDropDownList.DataBind()

    End Sub
    Protected Sub btnInsertImagePreMessage_Fa_Click(sender As Object, e As EventArgs) Handles btnInsertImagePreMessage_Fa.Click
        RadPreMessage_Fa.Content = "<img alt='' src='" + FileNamePreMessage_Fa.Text + "' style='margin: 10px; padding: 5px; width: 380px; float: left; height: 212px;' class='img-responsive' title='' />" + RadPreMessage_Fa.Content
        RadPreMessage_Fa.Visible = True
    End Sub
    Protected Sub btnInsertImageMessage_Fa_Click(sender As Object, e As EventArgs) Handles btnInsertImageMessage_Fa.Click
        RadMessage_Fa.Content = "<img alt='' src='" + FileNameMessage_Fa.Text + "' style='margin: 10px; padding: 5px; width: 380px; float: left; height: 212px;' class='img-responsive' title='' />" + RadMessage_Fa.Content
        lblInsertImageStateMessage_Fa.Visible = True
    End Sub
    Protected Sub btnInsertImagePreMessage_En_Click(sender As Object, e As EventArgs) Handles btnInsertImagePreMessage_En.Click
        RadPreMessage_En.Content = "<img alt='' src='" + FileNamePreMessage_En.Text + "' style='margin: 10px; padding: 5px; width: 380px; float: right; height: 212px;' class='img-responsive' title='' /></a>" + RadPreMessage_En.Content
        lblInsertImageStatePreMessage_En.Visible = True
    End Sub
    Protected Sub btnInsertImageMessage_En_Click(sender As Object, e As EventArgs) Handles btnInsertImageMessage_En.Click
        RadMessage_En.Content = "<img alt='' src='" + FileNameMessage_En.Text + "' style='margin: 10px; padding: 5px; width: 380px; float: right; height: 212px;' class='img-responsive' title='' />" + RadMessage_En.Content
        lblInsertImageStateMessage_En.Visible = True
    End Sub
    Protected Sub btnInsertMediaPreMessage_En_Click(sender As Object, e As EventArgs) Handles btnInsertMediaPreMessage_En.Click
        RadPreMessage_En.Content += "<video width='320' height='240' controls='controls'><source src='video.mp4' type='video/mp4' /><source src='" + FileNameMediaPreMessage_En.Text + "' type='video/ogg' />Your browser does not support the video element.</video>"
        lblInsertMediaStatePreMessage_En.Visible = True
    End Sub
    Protected Sub btnInsertMediaPreMessage_Fa_Click(sender As Object, e As EventArgs) Handles btnInsertMediaPreMessage_Fa.Click
        RadPreMessage_Fa.Content += "<video width='320' height='240' controls='controls'><source src='video.mp4' type='video/mp4' /><source src='" + FileNameMediaPreMessage_Fa.Text + "' type='video/ogg' />Your browser does not support the video element.</video>"
        lblInsertMediaStatePreMessage_Fa.Visible = True
    End Sub
    Protected Sub btnInsertMediaMessage_Fa_Click(sender As Object, e As EventArgs) Handles btnInsertMediaMessage_Fa.Click
        RadMessage_Fa.Content += "<video width='320' height='240' controls='controls'><source src='video.mp4' type='video/mp4' /><source src='" + FileNameMediaMessage_Fa.Text + "' type='video/ogg' />Your browser does not support the video element.</video>"
        lblInsertMediaStateMessage_Fa.Visible = True
    End Sub
    Protected Sub btnInsertMediaMessage_En_Click(sender As Object, e As EventArgs) Handles btnInsertMediaMessage_En.Click
        RadMessage_En.Content += "<video width='320' height='240' controls='controls'><source src='video.mp4' type='video/mp4' /><source src='" + FileNameMediaMessage_En.Text + "' type='video/ogg' />Your browser does not support the video element.</video>"
        lblInsertMediaStateMessage_En.Visible = True
    End Sub
    Protected Sub btnSendFeed_Click(sender As Object, e As EventArgs) Handles btnSendFeed.Click
        'Try
        '    Dim db = New LinqDBClassesDataContext
        '    Dim qryMessage = From m In db.Messages
        '                     Select m
        '                     Where m.IDMessage = Convert.ToInt32(MessageView.SelectedValue)

        '    For Each q In qryMessage
        '        Dim Mailes = From n In db.NewsLetters
        '                     Select n
        '        For Each Maile In Mailes
        'Try
        '    Dim mail As New MailMessage
        '    mail.From = New MailAddress("Info@narem.ir")
        '    mail.To.Add(New MailAddress(Maile.Email.ToString))
        '    mail.Subject = q.Title_Fa.ToString
        '    'mail.Body = "<h3 style='direction:rtl;'>" + q.Title_Fa + "</h3><div style='background-color: #f5f5f5;width: 100%;margin: 0;padding: 10px 0 10px 0;direction: rtl;font-family: Tahoma;'><div style='background-color:#ffffff;width:600px;margin:auto;border-radius:15px 15px 8px 8px;border: 1px solid rgb(85, 125, 161);'><div style='background-color:rgb(85, 125, 161); width:600px;height:60px;margin:auto;border-radius:8px 8px 0px 0px;'><span style='color: #ffffff;margin:0;padding: 20px 20px;display: block;font-size: 20px;font-weight: bold;font-family: Tahoma;'> " + q.Moment_Fa + " </span></div><h4 style='padding:5px 5px 5px 5px;'>پیام دریافتی از سایت</h4><p style='text-align: justify;padding:15px 15px 15px 15px;'>" + q.Message_Fa + "<br/></p></div></div>"
        '    mail.Body = "<img src='https://ci5.googleusercontent.com/proxy/XySHurPE69idjp9H2VjVyhzxTOXiry4kY7oZkVN1wOVakk872Xu-QTyEiNFYnmP5jfzzZP6grxPTv3X1HzHhpJSLqx_70gTHIGLpNsehoTAWyOkT1EU0MoY6=s0-d-e1-ft#https://narem.ir/img/Logo.png' /><div style='direction:rtl;font-family: Yekan;'><h3>" + q.Title_Fa + "</h3>" + "<article class='post' style='direction:rtl;'><div class='entry-content'>" + q.PreMessage_Fa + q.Message_Fa + "</div><footer  id='SectionComment' class='entry-meta'><span class='autor-name'>  نویسنده  <a target='_blank' href='https://narem.ir/about/" + q.WrittenBy_En.ToString.Replace(" ", "-").ToLower() + "'>" + q.WrittenBy_Fa + "</a></span> | <span class='time'>" + q.Moment_Fa.ToString.Remove(q.Moment_Fa.ToString.Length - 8, 8) + "</span></footer></article></div>"

        '    For Each i In q.Keyword_Fa.ToString.Split(";")
        '        mail.Body += "<a href='/result/" + i.ToString.Replace(" ", "-") + "' class='btn-success' style='text-decoration:none;border-color: #00f;color:#fff;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>" + i.ToString + "</a>"
        '        Page.MetaKeywords += i.ToString + ","
        '    Next
        '    mail.IsBodyHtml = True
        '    Dim smtp As New SmtpClient
        '    smtp.Host = "javid.dnswebhost.com "
        '    smtp.Port = 25
        '    'smtp.EnableSsl = False
        '    smtp.UseDefaultCredentials = False
        '    smtp.Credentials = New NetworkCredential("Info@narem.ir", "00000110AHMSoft")
        '    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
        '    smtp.Send(mail)
        '    Exit For
        'Catch ex As Exception

        '    Response.Write(ex.Message)

        'End Try
        'Here we send the mail
        'Dim client As New Net.Mail.SmtpClient("javid.dnswebhost.com") 'your SMTP server
        '            client.UseDefaultCredentials = False

        '            Dim htmlView As AlternateView
        '            Dim imageResource As LinkedResource

        '            'Your username and password to login
        '            client.Credentials = New Net.NetworkCredential("Info@narem.ir", "00000110AHMSoft")
        '            client.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
        '            Dim Mail As New Net.Mail.MailMessage("Info@narem.ir", "ah.moravveji.edu@gmail.com")
        '            Mail.Subject = "thlocal - Username has been unblocked. "
        '            Dim msgText As New StringBuilder
        '            msgText.Append("The UserName: " + "Info@narem.ir" + ", has been unblocked. ")
        '            msgText.Append("<hr /> <br/>")
        '            msgText.Append("This is an automatic response from our server. Please do not respond to this email.               <br/>")
        '            msgText.Append("If  you would like to contact us for any reason, go to our website and click on 'Contact us'.     <br/>")
        '            msgText.Append("Thank you.                                                                                        <br/>")
        '            msgText.Append("The Support Team at                                                                               <br/> ")
        '            msgText.Append("thlocal.com ")

        ''create an alternate view for your mail
        'htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(msgText.ToString() + "<image src=cid:HDIImage>", Nothing, "text/html")

        ''Add image to HTML version
        'imageResource = New System.Net.Mail.LinkedResource((Server.MapPath("~/img/Logo.png")))

        ''Name the Resource
        'imageResource.ContentId = "HDIImage"

        '            'Add the resource to the alternate view
        '            htmlView.LinkedResources.Add(imageResource)
        '            'Add two views to message.
        '            Mail.AlternateViews.Add(htmlView)

        '            Mail.IsBodyHtml = True

        '            Try
        '                client.Send(Mail)
        '            Catch ex As Exception
        '                Response.Write(ex.Message) 'Write error message
        '                Exit Sub
        '            End Try
        'Item.Text += "<a class='button small solid-button purple' style='float: left;' onclick='history.go(-1)' href='#'> بازگشت</a></div></div><br/><br/>"
        '        Next
        '    Next
        'Catch ex As Exception
        '    Response.Write(ex.Message)
        'End Try
        Try
            Dim db = New LinqDBClassesDataContext
            Dim qryMessage = From m In db.Messages
                             Select m
                             Where m.IDMessage = Convert.ToInt32(MessageView.SelectedValue)
            For Each q In qryMessage
                Dim Mailes = From n In db.NewsLetters
                             Select n
                For Each Maile In Mailes
                    Dim htmlMessage As String = "<html><body style='background-color: #ffffff; color: #1e1e1e; font-family:tahoma, Roboto; font-size: 14px; line-height: 22px; margin: 0; padding: 0;direction:ltr;'><table width='644' cellspacing='0' cellpadding='0' border='0' style='margin: 0 auto; height: 105px;'><tr><td style='text-align: Left; vertical-align: top; padding-top: 25px;'><img src='cid:EmbeddedContent_1' alt='Logo' style='max-width:170px;' /></td><td style='padding:11px 0; text-align: Right; vertical-align: top;direction:rtl; font-family:tahoma;'><small style='display: Block; font-size: 11px; line-height: 16px; margin: 0 0 14px;'>آیا تصاویر را نمی‌بینید؟ <b> <a href='https://narem.ir/posts/" + q.Title_En.Replace(" ", "-").ToLower() + "/" + q.IDMessage.ToString() + "'>اینجا کلیک کنید...</a> </b></small><h2 style='font-weight: bold; line-height: 1.3; margin: 0;'>طراحی سایت، هوش مصنوعی، ارائه خدمات مالی و حسابداری</h2></td></tr></table><table cellspacing='0' cellpadding='0' border='0' style='margin: 0 auto; width: 100%;'><tr><td style='text-align:Right; vertical-align: top;'><hr style='border:0; border-bottom: 0 none; border-top: 1px solid #e1e1e1; margin: 0 0 35px;'></td></tr></table><h3 style='font-weight: bold; line-height: 1.3; margin: 0;direction:rtl;text-align:right;'><table width='644' cellspacing='0' cellpadding='0' border='0' style='margin: 0 auto;direction: rtl;text-align: Right;'><tr><td style='text-align: Right; vertical-align: top;'><div style='border:1px solid #e1e1e1; overflow: hidden; padding: 30px;'><div style='float:Left; width: 310px;'><h2 style='font-size:24px; font-weight: bold; line-height: 1.3; margin: 0 0 22px;'><a href='https://narem.ir/posts/" + q.Title_En.Replace(" ", "-").ToLower() + "/" + q.IDMessage.ToString() + "' style='color: #1e1e1e; text-decoration: none;'>" + q.Title_Fa + "</a></h2><p style='color #999; font-size: 12px; margin: 0 0 22px;direction:rtl;text-align:right;'>" + q.PreMessage_Fa + "<br/><a href='https://narem.ir/posts/" + q.Title_En.Replace(" ", "-").ToLower() + "/" + q.IDMessage.ToString() + "' style='margin-top:-20px;margin-bottom:10px; color: #fff; text-decoration: none; font-size: 20px; padding: 2px 10px; background-color: #1e1e1e;color:ffffff; border: 0 none; border-radius: 5px;'> بیشتر </a></p><div style='font-size 12px;'><span>"
                    For Each i In q.Keyword_Fa.ToString.Split(";")
                        htmlMessage += "<a href='https://narem.ir/result/" + i.ToString.Replace(" ", "-") + "' style='text-decoration:none;border-color: #00f;color:#fff;background-color:#00a65a;border-radius: 3px; display:inline-block; padding:2px 6px 2px 6px;margin:2px 3px 2px 3px;'>" + i.ToString + "</a>"
                    Next
                    htmlMessage += "</span><br><span style='display:Block; line-height: 1; margin: 10px 0;'><span> نوشته شده توسط <a href='https://narem.ir/about/" + q.WrittenBy_En.Replace(" ", "-").ToLower() + "'>" + q.WrittenBy_Fa + "</a></span> در " + q.Moment_Fa.ToString.Remove(q.Moment_Fa.ToString.Length - 8, 8) + "</span></div></div><div style='float: Right; padding: 55px 0 0; text-align: center;'><img src='cid:EmbeddedContent_2' alt='" + q.Title_Fa + "' style='border-radius: 15px;max-width:260px;'></div></div></td></tr></table></body></html>"
                    Dim client As SmtpClient = New SmtpClient("javid.dnswebhost.com")
                    client.Credentials = New NetworkCredential("Info@narem.ir", "00000110AHMSoft")
                    Dim msg As MailMessage = New MailMessage("شرکت نارِم Info@narem.ir", Maile.Email)
                    '// Create the HTML view
                    Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(htmlMessage, Encoding.UTF8, MediaTypeNames.Text.Html)
                    '// Create a plain text message for client that don't support HTML
                    Dim plainView As AlternateView = AlternateView.CreateAlternateViewFromString(Regex.Replace(htmlMessage, "<[^>]+?>", String.Empty), Encoding.UTF8, MediaTypeNames.Text.Plain)
                    Dim mediaType As String = MediaTypeNames.Image.Jpeg
                    Dim img As LinkedResource = New LinkedResource("D:\HostingSpaces\narem.ir\NAREM.IR\img\Logo.png", mediaType)
                    Dim imgPost As LinkedResource = New LinkedResource("D:\HostingSpaces\narem.ir\NAREM.IR" + q.Image, mediaType)
                    '// Make sure you set all these values!!!
                    img.ContentId = "EmbeddedContent_1"
                    img.ContentType.MediaType = mediaType
                    img.TransferEncoding = TransferEncoding.Base64
                    img.ContentType.Name = img.ContentId
                    img.ContentLink = New Uri("cid:" + img.ContentId)
                    htmlView.LinkedResources.Add(img)
                    imgPost.ContentId = "EmbeddedContent_2"
                    imgPost.ContentType.MediaType = mediaType
                    imgPost.TransferEncoding = TransferEncoding.Base64
                    imgPost.ContentType.Name = img.ContentId
                    imgPost.ContentLink = New Uri("cid:" + img.ContentId)
                    htmlView.LinkedResources.Add(imgPost)
                    '//////////////////////////////////////////////////////////////
                    msg.AlternateViews.Add(plainView)
                    msg.AlternateViews.Add(htmlView)
                    msg.IsBodyHtml = True
                    msg.Subject = q.Title_Fa
                    client.Send(msg)
                    Exit For
                Next
            Next
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class
