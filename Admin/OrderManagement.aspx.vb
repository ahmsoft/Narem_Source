
Partial Class Admin_OrderManagement
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
        'txtMomentNew_En.Text = Date_En()
        Dim lblActiveParent As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIContentPages"))
        lblActiveParent.Attributes("Class") = "treeview active"
        Dim lblActive As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIMainPMs"))
        lblActive.Attributes("Class") = "treeview active"
    End Sub
    Protected Sub OrderView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles OrderView.SelectedIndexChanged
        Dim db = New LinqDBClassesDataContext
        Try
            Dim qry = From m In db.Orders
                      Select m
                      Where m.IDO = Convert.ToInt32(OrderView.SelectedValue)
            For Each q In qry
                If q.NewDesign = True Then
                    rdoNewDesign.SelectedIndex = 1
                Else
                    rdoNewDesign.SelectedIndex = 0
                End If
                If q.SPL <> "" Then
                    txtSPL.Content = q.SPL
                Else
                    txtSPL.Content = "شرکت درحال انجام مراحل ابتدایی پروژه شماست. لطفا جهت پیگیری روند پیشرفت پروژه از همینجا اقدام نمایید."
                End If
                'txtSPL.Content = q.SPL
                txtAddress.Text = q.Address
                txtCompetition.Text = q.Competition
                txtCustomers.Text = q.Customers
                tarikh.Text = q.DeadLine
                txtDescription.Text = q.Description
                txtEmail.Text = q.Email
                txtJob.Text = q.Job
                txtMobile.Text = q.Mobile
                txtNameAndFamily.Text = q.NameAndFamily
                txtNameEn.Text = q.SiteNameEn
                txtNameFa.Text = q.SiteNameFA
                txtService.Text = q.Service
                txtPossibilities.Text = q.Possibilities
                txtPurposeExistingSite.Text = q.PurposeExistingSite
                txtRequirements.Text = q.Requirements
                txtSubject.Text = q.SiteSubject
                txtSampleSite.Text = q.SampleSite
                txtStyle.Text = q.Style
                txtTel.Text = q.Tel
                txtAdvice.Text = q.Thesis
                txtSuggestedCost.Text = q.SuggestedCosts
                If q.ActiveForClient = True Then
                    drpActiveClient.SelectedIndex = 1
                    frmClientInfo.Visible = True
                    frmContra.Visible = True
                    frmProgress.Visible = True
                Else
                    drpActiveClient.SelectedIndex = 0
                    frmClientInfo.Visible = False
                    frmContra.Visible = False
                    frmProgress.Visible = False
                End If
            Next
            txtUsername.Text = ""
            txtPassword.Text = ""
            txtContraName.Text = ""
            txtContra.Content = ""
            Dim qry1 = From m In db.Clients
                       Select m
                       Where m.IDO = Convert.ToInt32(OrderView.SelectedValue)
            For Each q In qry1
                txtUsername.Text = q.Username
                txtPassword.Text = q.Password
                txtPhotoClient.Text = q.Photo
            Next
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnUpdateOrder_Click(sender As Object, e As EventArgs) Handles btnUpdateOrder.Click
        Try
            Dim db = New LinqDBClassesDataContext
            Dim qry = From m In db.Orders
                      Select m Where m.IDO = Convert.ToInt32(OrderView.SelectedValue)
            For Each q In qry
                If rdoNewDesign.SelectedIndex = 1 Then
                    q.NewDesign = True
                Else
                    q.NewDesign = False
                End If
                q.Address = txtAddress.Text
                q.Competition = txtCompetition.Text
                q.Customers = txtCustomers.Text
                q.DeadLine = tarikh.Text
                q.Description = txtDescription.Text
                q.Email = txtEmail.Text
                q.Job = txtJob.Text
                q.Mobile = txtMobile.Text
                q.NameAndFamily = txtNameAndFamily.Text
                q.SiteNameEn = txtNameEn.Text
                q.SiteNameFA = txtNameFa.Text
                q.Service = txtService.Text
                q.Possibilities = txtPossibilities.Text
                q.PurposeExistingSite = txtPurposeExistingSite.Text
                q.Requirements = txtRequirements.Text
                q.SiteSubject = txtSubject.Text
                q.SampleSite = txtSampleSite.Text
                q.Style = txtStyle.Text
                q.Tel = txtTel.Text
                q.Thesis = txtAdvice.Text
                q.SuggestedCosts = txtSuggestedCost.Text
                q.SPL = txtSPL.Content
                If drpActiveClient.SelectedIndex = 1 Then
                    q.ActiveForClient = True
                    frmClientInfo.Visible = True
                Else
                    q.ActiveForClient = False
                    frmClientInfo.Visible = False
                End If
            Next
            db.SubmitChanges()
            OrderView.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Public Function Substr(InputText As String, StartIndex As Integer, Length As Integer) As String
        Return InputText.Substring(StartIndex, Length) + " ... "
    End Function
    Protected Sub btnUpdateClient_Click(sender As Object, e As EventArgs) Handles btnUpdateClient.Click
        Try
            Dim db = New LinqDBClassesDataContext
            Dim qry = From m In db.Clients
                      Select m Where m.IDO = Convert.ToInt32(OrderView.SelectedValue)
            For Each q In qry
                q.Username = txtUsername.Text
                q.Password = txtPassword.Text
                q.Photo = txtPhotoClient.Text
            Next
            db.SubmitChanges()
            ClientView.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnCreateClient_Click(sender As Object, e As EventArgs) Handles btnCreateClient.Click
        Dim db = New LinqDBClassesDataContext
        Try
            Dim qry = From m In db.Clients
                      Select m Where (m.Username = Trim(txtUsername.Text)) Or m.IDO = Convert.ToInt32(OrderView.SelectedValue)
            For Each m In qry
                If m.Username = Trim(txtUsername.Text) Then
                    lblSubmitStatus.Text = "این پنل ورود قبلا ثبت شده."
                    Exit Try
                    'ElseIf m.IDO = Convert.ToInt32(OrderView.SelectedValue) Then
                    'lblSubmitStatus.Text = "برای این مشتری قبلا پنل ورود ثبت شده."
                End If
            Next
            Dim q As New Client
            q.Username = txtUsername.Text
            q.Password = txtPassword.Text
            q.IDO = Convert.ToInt32(OrderView.SelectedValue)
            db.Clients.InsertOnSubmit(q)
            db.SubmitChanges()
            ClientView.DataBind()
            lblSubmitStatus.Text = "ثبت شد."
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub
    Protected Sub btnUpdateOrder1_Click(sender As Object, e As EventArgs) Handles btnUpdateOrder1.Click
        btnUpdateOrder_Click(sender, e)

    End Sub
    Protected Sub btnUpdateOrder2_Click(sender As Object, e As EventArgs) Handles btnUpdateOrder2.Click
        btnUpdateOrder_Click(sender, e)
    End Sub
    Protected Sub btnUpdateContra_Click(sender As Object, e As EventArgs) Handles btnUpdateContra.Click
        Try
            Dim db = New LinqDBClassesDataContext
            Dim qry = From m In db.Contracts
                      Select m Where m.IDO = Convert.ToInt32(OrderView.SelectedValue)
            For Each q In qry
                q.Contract = txtContra.Content
                q.Title = txtContraName.Text
            Next
            db.SubmitChanges()
            ContractView.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub btnCreateContra_Click(sender As Object, e As EventArgs) Handles btnCreateContra.Click
        Try
            Dim db = New LinqDBClassesDataContext
            Dim NewContra As New Contract
            NewContra.Title = txtContraName.Text
            NewContra.IDO = Convert.ToInt32(OrderView.SelectedValue)
            NewContra.Contract = txtContra.Content
            db.Contracts.InsertOnSubmit(NewContra)
            db.SubmitChanges()
            ContractView.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub ContractView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ContractView.SelectedIndexChanged
        Dim db = New LinqDBClassesDataContext
        Try
            Dim qry = From m In db.Contracts
                      Select m
                      Where m.IDCon = Convert.ToInt32(ContractView.SelectedValue)
            For Each q In qry
                txtContraName.Text = q.Title
                txtContra.Content = q.Contract
            Next
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

End Class