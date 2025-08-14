Partial Class Admin_GalleryPortfManagement
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
                ElseIf m.NameAndFamily_Fa <> "" Then 'Or q.NameAndFamilyFa IsNot Nothing
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
        Dim lblActiveParent As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIPortfGallerys"))
        lblActiveParent.Attributes("Class") = "treeview active"
        Dim lblActive As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIPortfGallery"))
        lblActive.Attributes("Class") = "treeview active"
    End Sub
    Protected Sub PortfolioGallerysView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PortfolioGallerysView.SelectedIndexChanged
        Try
            Dim db = New LinqDBClassesDataContext
            Dim qry = From m In db.PortfolioGalleries
                      Select m
                      Where m.IDPG = Convert.ToInt32(PortfolioGallerysView.SelectedValue)
            For Each q In qry
                txtName_Fa.Text = q.Name_Fa
                txtName_En.Text = q.Name_En

                RadGalleryDescription_Fa.Content = q.Description_Fa
                RadGalleryDescription_En.Content = q.Description_En

                txtAddress.Text = q.SRC
                txtALT_Fa.Text = q.Alt_Fa
                txtALT_En.Text = q.Alt_En
                txtMomentNew_En.Text = Date_En()
                'tarikh.Value = q.Moment
                txtMoment_En.Value = q.Moment_En
                txtMoment_Fa.Value = q.Moment_Fa
                'lblShowGallery.Visible = True
                txtAddress.Visible = True
                'lblShowGallery.Text = "<img src='" + q.Address + "' style='width:50%;height:auto;' />"
                'q.Moment = tarikh.Value
            Next
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnInsertImageBody_Fa_Click(sender As Object, e As EventArgs) Handles btnInsertImageGalleryDescription_Fa.Click
        RadGalleryDescription_Fa.Content += "<a class='highslide' onclick='return hs.expand(this, 1 )' href='" + FileNameGalleryDescription_Fa.Text + "'><img alt='' src='" + FileNameGalleryDescription_Fa.Text + "' style='margin: 10px; box-shadow: #c8c8c8 0px 2px 4px; padding: 5px; width: 380px; float: left; height: 212px;' class='img-responsive' title='' /></a>"
        lblInsertImageState_Fa.Visible = True
    End Sub
    Protected Sub btnInsertImageBody_En_Click(sender As Object, e As EventArgs) Handles btnInsertImageGalleryDescription_En.Click
        RadGalleryDescription_En.Content += "<a class='highslide' onclick='return hs.expand(this, 1 )' href='" + FileNameGalleryDescription_En.Text + "'><img alt='' src='" + FileNameGalleryDescription_En.Text + "' style='margin: 10px; box-shadow: #c8c8c8 0px 2px 4px; padding: 5px; width: 380px; float: left; height: 212px;' class='img-responsive' title='' /></a>"
        lblInsertImageState_En.Visible = True
    End Sub
    'Protected Sub btnInsertImageBodyFr_Click(sender As Object, e As EventArgs) Handles btnInsertImageGalleryDescriptionFr.Click
    '    RadGalleryDescriptionFr.Content += "<a class='highslide' onclick='return hs.expand(this, 1 )' href='" + FileNameGalleryDescriptionFr.Text + "'><img alt='' src='" + FileNameGalleryDescriptionFr.Text + "' style='margin: 10px; box-shadow: #c8c8c8 0px 2px 4px; padding: 5px; width: 380px; float: left; height: 212px;' class='img-responsive' title='' /></a>"
    '    lblInsertImageStateFr.Visible = True
    'End Sub
    'Protected Sub btnInsertImageBodyAr_Click(sender As Object, e As EventArgs) Handles btnInsertImageGalleryDescriptionAr.Click
    '    RadGalleryDescriptionAr.Content += "<a class='highslide' onclick='return hs.expand(this, 1 )' href='" + FileNameGalleryDescriptionAr.Text + "'><img alt='' src='" + FileNameGalleryDescriptionAr.Text + "' style='margin: 10px; box-shadow: #c8c8c8 0px 2px 4px; padding: 5px; width: 380px; float: left; height: 212px;' class='img-responsive' title='' /></a>"
    '    lblInsertImageStateAr.Visible = True
    'End Sub
    Protected Sub btnUpdateGallery_Click(sender As Object, e As EventArgs) Handles btnUpdateGallery.Click
        Try
            Dim db = New LinqDBClassesDataContext
            Dim qry = From m In db.PortfolioGalleries
                      Select m Where m.IDPG = Convert.ToInt32(PortfolioGallerysView.SelectedValue)
            For Each q In qry
                q.Name_Fa = txtName_Fa.Text
                q.Name_En = txtName_En.Text
                q.Description_Fa = RadGalleryDescription_Fa.Content
                q.Description_En = RadGalleryDescription_En.Content
                q.SRC = txtAddress.Text
                q.Alt_En = txtALT_En.Text
                q.Alt_Fa = txtALT_Fa.Text
                q.Moment_Fa = txtMoment_Fa.Value
                q.Moment_En = txtMoment_En.Value
                q.IDPG = Convert.ToInt32(PortfolioGallerysView.SelectedValue)
                q.IDP = Convert.ToInt32(CoversViewPortf.SelectedValue)
                'lblShowGallery.Visible = True
            Next
            db.SubmitChanges()
            PortfolioGallerysView.DataBind()

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
    Protected Sub btnSaveNewGallery_Click(sender As Object, e As EventArgs) Handles btnSaveNewGallery.Click
        Try
            Dim db = New LinqDBClassesDataContext
            Dim q = New PortfolioGallery
            q.Name_Fa = txtName_Fa.Text
            q.Name_En = txtName_En.Text
            q.Description_Fa = RadGalleryDescription_Fa.Content
            q.Description_En = RadGalleryDescription_En.Content
            q.SRC = txtAddress.Text
            q.Alt_En = txtALT_En.Text
            q.Alt_Fa = txtALT_Fa.Text
            q.Moment_Fa = txtMoment_Fa.Value
            q.Moment_En = txtMoment_En.Value
            q.IDPG = Convert.ToInt32(PortfolioGallerysView.SelectedValue)
            q.IDP = Convert.ToInt32(CoversViewPortf.SelectedValue)
            db.PortfolioGalleries.InsertOnSubmit(q)
            db.SubmitChanges()
            PortfolioGallerysView.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
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
    Public Function Substr(InputText As String, StartIndex As Integer, Length As Integer) As String

        Return InputText.Substring(StartIndex, Length) + " ... "
    End Function
End Class
