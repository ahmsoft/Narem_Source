
Partial Class NewsManagement
    Inherits System.Web.UI.Page
    Protected Sub btnUpdateNews_Click(sender As Object, e As EventArgs) Handles btnUpdateNews.Click
        Try
            Dim tmpCat As String = ""
            Dim db = New LinqDBClassesDataContext
            Dim qry = From m In db.News1s
                      Select m Where m.IDN = Convert.ToInt32(NewsView.SelectedValue)
            For Each q In qry
                q.Title_Fa = txtTitle_Fa.Text
                q.PreMSG_Fa = RadPreMSG_Fa.Content
                q.MSG_Fa = RadMSG_Fa.Content
                q.Keyword_Fa = txtKeyword_Fa.Text
                q.Title_En = txtTitle_En.Text
                q.PreMSG_En = RadPreMSG_En.Content
                q.MSG_En = RadMSG_En.Content
                q.Keyword_En = txtKeyword_En.Text
                q.Pic = txtMetaPic.Text
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
            NewsView.DataBind()

        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnSaveNewNews_Click(sender As Object, e As EventArgs) Handles btnSaveNewNews.Click
        Try
            Dim tmpCat As String = ""
            Dim db = New LinqDBClassesDataContext
            Dim q = New News1
            q.Title_Fa = txtTitle_Fa.Text
            q.Title_En = txtTitle_En.Text
            q.PreMSG_Fa = RadPreMSG_Fa.Content
            q.PreMSG_En = RadPreMSG_En.Content
            q.MSG_Fa = RadMSG_Fa.Content
            q.MSG_En = RadMSG_En.Content
            q.Keyword_Fa = txtKeyword_Fa.Text
            q.Keyword_En = txtKeyword_En.Text
            q.Pic = txtMetaPic.Text
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
            db.News1s.InsertOnSubmit(q)
            db.SubmitChanges()
            NewsView.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub NewsView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles NewsView.SelectedIndexChanged
        Try
            Dim db = New LinqDBClassesDataContext
            Dim qryMessage = From m In db.News1s
                             Select m
                             Where m.IDN = Convert.ToInt32(NewsView.SelectedValue)

            For Each q In qryMessage
                TxtTitle_Fa.Text = q.Title_Fa
                RadPreMSG_Fa.Content = q.PreMSG_Fa
                RadMSG_Fa.Content = q.MSG_Fa
                txtKeyword_Fa.Text = q.Keyword_Fa
                txtTitle_En.Text = q.Title_En
                RadPreMSG_En.Content = q.PreMSG_En
                RadMSG_En.Content = q.MSG_En
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
                txtMetaPic.Text = q.Pic
            Next
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
        Dim lblActive As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIMainNews"))
        lblActive.Attributes("Class") = "treeview active"
    End Sub
    Public Function Substr(InputText As String, StartIndex As Integer, Length As Integer) As String

        Return InputText.Substring(StartIndex, Length) + " ... "
    End Function

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
        DataSourceNews.SelectCommand = "SELECT * FROM [Message] WHERE Moment_Fa Like '%" + txtSearch.Text + "%' OR Moment_En Like '%" + txtSearch.Text + "%' OR Title_Fa Like '%" + txtSearch.Text + "%' OR Title_En Like '%" + txtSearch.Text + "%' OR Keyword_Fa Like '%" + txtSearch.Text + "%' OR Keyword_En Like '%" + txtSearch.Text + "%'" 'IDCat=@IDCat  ORDER BY IDCat DESC"
    End Sub
    Protected Sub CatView_RowDeleted(sender As Object, e As GridViewDeletedEventArgs) Handles CatView.RowDeleted
        CatDropDownList.DataBind()

    End Sub
    Protected Sub btnInsertImagePreMessage_Fa_Click(sender As Object, e As EventArgs) Handles btnInsertImagePreMessage_Fa.Click
        RadPreMSG_Fa.Content += "<a class='highslide' onclick='return hs.expand(this, 1 )' href='" + FileNamePreMessage_Fa.Text + "'><img alt='' src='" + FileNamePreMessage_Fa.Text + "' style='margin: 10px; box-shadow: #c8c8c8 0px 2px 4px; padding: 5px; width: 380px; float: left; height: 212px;' class='img-responsive' title='' /></a>"
        lblInsertImageStatePreMessage_Fa.Visible = True
    End Sub
    Protected Sub btnInsertImageMessage_Fa_Click(sender As Object, e As EventArgs) Handles btnInsertImageMessage_Fa.Click
        RadMSG_Fa.Content += "<a class='highslide' onclick='return hs.expand(this, 1 )' href='" + FileNameMessage_Fa.Text + "'><img alt='' src='" + FileNameMessage_Fa.Text + "' style='margin: 10px; box-shadow: #c8c8c8 0px 2px 4px; padding: 5px; width: 380px; float: left; height: 212px;' class='img-responsive' title='' /></a>"
        lblInsertImageStateMessage_Fa.Visible = True
    End Sub
    Protected Sub btnInsertImagePreMessage_En_Click(sender As Object, e As EventArgs) Handles btnInsertImagePreMessage_En.Click
        RadPreMSG_En.Content += "<a class='highslide' onclick='return hs.expand(this, 1 )' href='" + FileNamePreMessage_En.Text + "'><img alt='' src='" + FileNamePreMessage_En.Text + "' style='margin: 10px; box-shadow: #c8c8c8 0px 2px 4px; padding: 5px; width: 380px; float: left; height: 212px;' class='img-responsive' title='' /></a>"
        lblInsertImageStatePreMessage_En.Visible = True
    End Sub
    Protected Sub btnInsertImageMessage_En_Click(sender As Object, e As EventArgs) Handles btnInsertImageMessage_En.Click
        RadMSG_En.Content += "<a class='highslide' onclick='return hs.expand(this, 1 )' href='" + FileNameMessage_En.Text + "'><img alt='' src='" + FileNameMessage_En.Text + "' style='margin: 10px; box-shadow: #c8c8c8 0px 2px 4px; padding: 5px; width: 380px; float: left; height: 212px;' class='img-responsive' title='' /></a>"
        lblInsertImageStateMessage_En.Visible = True
    End Sub
    Protected Sub btnInsertMediaPreMessage_En_Click(sender As Object, e As EventArgs) Handles btnInsertMediaPreMessage_En.Click
        RadPreMSG_En.Content += "<video width='320' height='240' controls='controls'><source src='video.mp4' type='video/mp4' /><source src='" + FileNameMediaPreMessage_En.Text + "' type='video/ogg' />Your browser does not support the video element.</video>"
        lblInsertMediaStatePreMessage_En.Visible = True
    End Sub
    Protected Sub btnInsertMediaPreMessage_Fa_Click(sender As Object, e As EventArgs) Handles btnInsertMediaPreMessage_Fa.Click
        RadPreMSG_Fa.Content += "<video width='320' height='240' controls='controls'><source src='video.mp4' type='video/mp4' /><source src='" + FileNameMediaPreMessage_Fa.Text + "' type='video/ogg' />Your browser does not support the video element.</video>"
        lblInsertMediaStatePreMessage_Fa.Visible = True
    End Sub
    Protected Sub btnInsertMediaMessage_Fa_Click(sender As Object, e As EventArgs) Handles btnInsertMediaMessage_Fa.Click
        RadMSG_Fa.Content += "<video width='320' height='240' controls='controls'><source src='video.mp4' type='video/mp4' /><source src='" + FileNameMediaMessage_Fa.Text + "' type='video/ogg' />Your browser does not support the video element.</video>"
        lblInsertMediaStateMessage_Fa.Visible = True
    End Sub
    Protected Sub btnInsertMediaMessage_En_Click(sender As Object, e As EventArgs) Handles btnInsertMediaMessage_En.Click
        RadMSG_En.Content += "<video width='320' height='240' controls='controls'><source src='video.mp4' type='video/mp4' /><source src='" + FileNameMediaMessage_En.Text + "' type='video/ogg' />Your browser does not support the video element.</video>"
        lblInsertMediaStateMessage_En.Visible = True
    End Sub

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
        DataSourceNews.SelectCommand = "SELECT * FROM [Message] ORDER BY IDMessage DESC" 'IDCat=@IDCat  ORDER BY IDCat DESC"
    End Sub
End Class
