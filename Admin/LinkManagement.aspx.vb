
Partial Class Admin_LinkManagement
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
        Dim lblActiveParent As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIBL"))
        lblActiveParent.Attributes("Class") = "active treeview"
        Dim lblActive As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLILinks"))
        lblActive.Attributes("Class") = "active treeview"
    End Sub
    Public Function Substr(InputText As String, StartIndex As Integer, Length As Integer) As String

        Return InputText.Substring(StartIndex, Length) + " ... "
    End Function

    Protected Sub chkHTML_CheckedChanged(sender As Object, e As EventArgs) Handles chkHTML.CheckedChanged
        If chkHTML.Checked Then
            chkHTML.Checked = True
            InfoHTML_Fa.Visible = True
            InfoHTML_En.Visible = True
            InfoLink_Fa.Visible = False
            InfoLink_En.Visible = False
            'InfoHTMLFr.Visible = True
            'InfoHTMLAr.Visible = True
            'InfoLinkFr.Visible = False
            'InfoLinkAr.Visible = False
            drpLinkTargetState.Visible = False
        Else
            chkHTML.Checked = False
            InfoHTML_Fa.Visible = False
            InfoHTML_En.Visible = False
            InfoLink_Fa.Visible = True
            InfoLink_En.Visible = True
            'InfoHTMLFr.Visible = False
            'InfoHTMLAr.Visible = False
            'InfoLinkFr.Visible = True
            'InfoLinkAr.Visible = True
            drpLinkTargetState.Visible = True
        End If
    End Sub
    Protected Sub LinkView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LinkView.SelectedIndexChanged
        Try
            Dim db = New LinqDBClassesDataContext
            Dim qry = From m In db.Links
                      Select m
                      Where m.IDL = Convert.ToInt32(LinkView.SelectedValue)
            For Each q In qry
                If q.IsHTML Then
                    chkHTML.Checked = True
                    InfoHTML_Fa.Visible = True
                    InfoHTML_En.Visible = True
                    InfoLink_Fa.Visible = False
                    InfoLink_En.Visible = False
                    'InfoHTMLFr.Visible = True
                    'InfoHTMLAr.Visible = True
                    'InfoLinkFr.Visible = False
                    'InfoLinkAr.Visible = False
                    drpLinkTargetState.Visible = False
                Else
                    chkHTML.Checked = False
                    InfoHTML_Fa.Visible = False
                    InfoHTML_En.Visible = False
                    InfoLink_Fa.Visible = True
                    InfoLink_En.Visible = True
                    'InfoHTMLFr.Visible = False
                    'InfoHTMLAr.Visible = False
                    'InfoLinkFr.Visible = True
                    'InfoLinkAr.Visible = True
                    drpLinkTargetState.Visible = True
                End If
                txtLinkName_Fa.Text = q.Name_Fa
                txtLinkAlt_Fa.Text = q.Alt_Fa
                txtLinkAddress_Fa.Text = q.Address_Fa
                txtPriorityLink.Text = q.Priority
                txtBodyHTML_Fa.Content = q.BodyHTML_Fa
                lblNotFoundBlock_Fa.Visible = False
                txtLinkName_En.Text = q.Name_En
                txtLinkAlt_En.Text = q.Alt_En
                txtLinkAddress_En.Text = q.Address_En
                txtBodyHTML_En.Content = q.BodyHTML_En
                'txtLinkNameFr.Text = q.NameFr
                'txtLinkAltFr.Text = q.AltFr
                'txtLinkAddressFr.Text = q.AddressFr
                'txtBodyHTMLFr.Content = q.BodyHTMLFr
                'txtLinkNameAr.Text = q.NameAr
                'txtLinkAltAr.Text = q.AltAr
                'txtLinkAddressAr.Text = q.AddressAr
                'txtBodyHTMLAr.Content = q.BodyHTMLAr
                drpLinkTarget.SelectedValue = q.Target
                chkHTML.Checked = q.IsHTML
                Try
                    drpBlock.SelectedValue = q.IDB
                Catch ex As Exception
                    lblNotFoundBlock_Fa.Visible = True
                End Try

            Next
        Catch ex As Exception

            Response.Write(ex.Message)

        End Try
    End Sub
    Protected Sub btnSaveNewLink_Click(sender As Object, e As EventArgs) Handles btnSaveNewLink.Click
        Try
            Dim db = New LinqDBClassesDataContext
            Dim q = New Link
            If chkHTML.Checked Then
                q.Name_Fa = "کد یا پیام"
                q.Address_Fa = "کد یا پیام"
                q.Alt_Fa = "کد یا پیام"
                q.BodyHTML_Fa = txtBodyHTML_Fa.Content
                q.Name_En = "Coded"
                q.Address_En = "Coded"
                q.Alt_En = "Coded"
                q.BodyHTML_En = txtBodyHTML_En.Content
                'q.NameFr = "کد یا پیام"
                'q.AddressFr = "کد یا پیام"
                'q.AltFr = "کد یا پیام"
                'q.BodyHTMLFr = txtBodyHTMLFr.Content
                'q.NameAr = "Coded"
                'q.AddressAr = "Coded"
                'q.AltAr = "Coded"
                'q.BodyHTMLAr = txtBodyHTML_En.Content
                q.Target = drpLinkTarget.SelectedValue

            Else
                q.Name_Fa = txtLinkName_Fa.Text
                q.Target = drpLinkTarget.SelectedValue.ToString()
                q.Address_Fa = txtLinkAddress_Fa.Text
                q.Alt_Fa = txtLinkAlt_Fa.Text
                q.Name_En = txtLinkName_En.Text
                q.Address_En = txtLinkAddress_En.Text
                q.Alt_En = txtLinkAlt_En.Text
                'q.NameFr = txtLinkNameFr.Text
                'q.AddressFr = txtLinkAddressFr.Text
                'q.AltFr = txtLinkAltFr.Text
                'q.NameAr = txtLinkNameAr.Text
                'q.AddressAr = txtLinkAddressAr.Text
                'q.AltAr = txtLinkAltAr.Text
                q.Target = drpLinkTarget.SelectedValue.ToString()

            End If
            q.IDB = drpBlock.SelectedValue
            q.Priority = txtPriorityLink.Text
            q.IsHTML = chkHTML.Checked
            db.Links.InsertOnSubmit(q)
            db.SubmitChanges()
            LinkView.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnUpdateLink_Click(sender As Object, e As EventArgs) Handles btnUpdateLink.Click
        Try
            Dim db = New LinqDBClassesDataContext
            Dim qry = From m In db.Links
                      Select m Where m.IDL = Convert.ToInt32(LinkView.SelectedValue)
            For Each q In qry
                If chkHTML.Checked Then
                    q.Name_Fa = "کد یا پیام"
                    q.Address_Fa = "کد یا پیام"
                    q.Alt_Fa = "کد یا پیام"
                    q.BodyHTML_Fa = txtBodyHTML_Fa.Content
                    q.Name_En = "Coded"
                    q.Address_En = "Coded"
                    q.Alt_En = "Coded"
                    'q.NameFr = "کد یا پیام"
                    'q.AddressFr = "کد یا پیام"
                    'q.AltFr = "کد یا پیام"
                    'q.BodyHTMLFr = txtBodyHTMLFr.Content
                    'q.NameAr = "Coded"
                    'q.AddressAr = "Coded"
                    'q.AltAr = "Coded"
                    'q.BodyHTMLAr = txtBodyHTMLAr.Content
                    q.Target = drpLinkTarget.SelectedValue
                Else
                    q.Name_Fa = txtLinkName_Fa.Text
                    q.Address_Fa = txtLinkAddress_Fa.Text
                    q.Alt_Fa = txtLinkAlt_Fa.Text
                    q.Name_En = txtLinkName_En.Text
                    q.Address_En = txtLinkAddress_En.Text
                    q.Alt_En = txtLinkAlt_En.Text
                    'q.NameFr = txtLinkNameFr.Text
                    'q.AddressFr = txtLinkAddressFr.Text
                    'q.AltFr = txtLinkAltFr.Text
                    'q.NameAr = txtLinkNameAr.Text
                    'q.AddressAr = txtLinkAddressAr.Text
                    'q.AltAr = txtLinkAltAr.Text
                    q.Target = drpLinkTarget.SelectedValue.ToString()
                End If
                q.IsHTML = chkHTML.Checked
                q.IDB = drpBlock.SelectedValue
                q.Priority = txtPriorityLink.Text
            Next
            db.SubmitChanges()
            LinkView.DataBind()

        Catch ex As Exception
            'Dim db = New LinqDBClassesDataContext
            'Dim UserTable As New FaultLog
            'MsgBox(ex.Message)
            'UserTable.ErrorMessage = ex.Message
            'UserTable.PageName = System.IO.Path.GetFileName(Request.CurrentExecutionFilePath)
            'db.FaultLogs.InsertOnSubmit(UserTable)
            'db.SubmitChanges()
            'Response.Redirect("../ErrorPage.aspx")
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnInsertImageBody_Fa_Click(sender As Object, e As EventArgs) Handles btnInsertImageBody_Fa.Click
        txtBodyHTML_Fa.Content += "<a class='highslide' onclick='return hs.expand(this, 1 )' href='" + FileNameBody_Fa.Text + "'><img alt='' src='" + FileNameBody_Fa.Text + "' style='margin: 10px; box-shadow: #c8c8c8 0px 2px 4px; padding: 5px; width: 380px; float: left; height: 212px;' class='img-responsive' title='' /></a>"
        lblInsertImageStateBody_Fa.Visible = True
    End Sub
    Protected Sub btnInsertImageBody_En_Click(sender As Object, e As EventArgs) Handles btnInsertImageBody_En.Click
        txtBodyHTML_En.Content += "<a class='highslide' onclick='return hs.expand(this, 1 )' href='" + fileNameBody_En.Text + "'><img alt='' src='" + fileNameBody_En.Text + "' style='margin: 10px; box-shadow: #c8c8c8 0px 2px 4px; padding: 5px; width: 380px; float: left; height: 212px;' class='img-responsive' title='' /></a>"
        lblInsertImageStateBody_En.Visible = True
    End Sub
    Protected Sub btnInsertMediaBody_Fa_Click(sender As Object, e As EventArgs) Handles btnInsertMediaBody_Fa.Click
        txtBodyHTML_Fa.Content += "<video width='320' height='240' controls='controls'><source src='video.mp4' type='video/mp4' /><source src='" + FileNameMediaBody_Fa.Text + "' type='video/ogg' />Your browser does not support the video element.</video>"
        lblInsertMediaStateBody_Fa.Visible = True
    End Sub
    Protected Sub btnInsertMediaBody_En_Click(sender As Object, e As EventArgs) Handles btnInsertMediaBody_En.Click
        txtBodyHTML_En.Content += "<video width='320' height='240' controls='controls'><source src='video.mp4' type='video/mp4' /><source src='" + FileNameMediaBody_En.Text + "' type='video/ogg' />Your browser does not support the video element.</video>"
        lblInsertMediaStateBody_En.Visible = True
    End Sub
    'Protected Sub btnInsertImageBodyFr_Click(sender As Object, e As EventArgs) Handles btnInsertImageBodyFr.Click
    '    txtBodyHTMLFr.Content += "<a class='highslide' onclick='return hs.expand(this, 1 )' href='" + FileNameBodyFr.Text + "'><img alt='' src='" + FileNameBodyFr.Text + "' style='margin: 10px; box-shadow: #c8c8c8 0px 2px 4px; padding: 5px; width: 380px; float: left; height: 212px;' class='img-responsive' title='' /></a>"
    '    lblInsertImageStateBodyFr.Visible = True
    'End Sub
    'Protected Sub btnInsertImageBodyAr_Click(sender As Object, e As EventArgs) Handles btnInsertImageBodyAr.Click
    '    txtBodyHTMLAr.Content += "<a class='highslide' onclick='return hs.expand(this, 1 )' href='" + fileNameBodyAr.Text + "'><img alt='' src='" + fileNameBodyAr.Text + "' style='margin: 10px; box-shadow: #c8c8c8 0px 2px 4px; padding: 5px; width: 380px; float: left; height: 212px;' class='img-responsive' title='' /></a>"
    '    lblInsertImageStateBodyAr.Visible = True
    'End Sub
    'Protected Sub btnInsertMediaBodyFr_Click(sender As Object, e As EventArgs) Handles btnInsertMediaBodyFr.Click
    '    txtBodyHTMLFr.Content += "<video width='320' height='240' controls='controls'><source src='video.mp4' type='video/mp4' /><source src='" + FileNameMediaBodyFr.Text + "' type='video/ogg' />Your browser does not support the video element.</video>"
    '    lblInsertMediaStateBodyFr.Visible = True
    'End Sub
    'Protected Sub btnInsertMediaBodyAr_Click(sender As Object, e As EventArgs) Handles btnInsertMediaBodyAr.Click
    '    txtBodyHTMLAr.Content += "<video width='320' height='240' controls='controls'><source src='video.mp4' type='video/mp4' /><source src='" + FileNameMediaBodyAr.Text + "' type='video/ogg' />Your browser does not support the video element.</video>"
    '    lblInsertMediaStateBodyAr.Visible = True
    'End Sub

End Class
