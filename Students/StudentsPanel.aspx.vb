
Imports System.IO

Partial Class StudentsPanel
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            Dim lblCommentNoReadCount As Label = Master.FindControl("lblCommentNoReadCount")
            Dim lblCommentNoReadCount1 As Label = Master.FindControl("lblCommentNoReadCount1")
            Dim lblStudentsImage As Label = Master.FindControl("lblStudentsImage")
            Dim lblStudentsImage1 As Label = Master.FindControl("lblStudentsImage1")
            Dim lblStudentsImage2 As Label = Master.FindControl("lblStudentsImage2")
            Dim lblStudentsNameFamily As Label = Master.FindControl("lblStudentsNameFamily")
            Dim lblStudentsNameFamily1 As Label = Master.FindControl("lblStudentsNameFamily1")
            Dim lblStudentsNameFamily2 As Label = Master.FindControl("lblStudentsNameFamily2")

            Dim WarningCount As Integer = 0
            Dim lblComments As Label = Master.FindControl("lblComments")
            Dim db = New LinqDBClassesDataContext
            lblStudentPanel.Text = "<div class='box box-danger'><div class='box-header with-border'><h3 class='box-title' data-widget='collapse' style='cursor:pointer;'><span style='color:red;'>* توجه *</span> لطفا تا پایان بررسی اطلاعات حساب کاربریتان، شکیبا باشید.</h3><div class='box-tools pull-right'><button type='button' class='btn btn-box-tool' data-widget='collapse'><i class='fa fa-minus'></i></button></div></div><div class='box-body'><div class='row'><div class='row'><div class='form-group col-md-12'><span class='col-md-1 control-label' style='padding:5px 15px 5px 5px;width: 100%;font-weight:bold;'>پیام پشتیبان:</span><div class='col-md-12'><p style='border-style: solid; border-color: rgb(150, 10, 10); padding: 10px; height: 100%; width: 100%;'>در حال حاضر شما تنها قادر به استفاده از <a style='background-color:rgba(0,0,0,0.1);border-radius:3px;padding:3px;' href='Explorer.aspx'>آپلود سنتر</a> هستید جهت استفاده از قابلیت‌های دیگر نیاز است تا پایان بررسی اطلاعات کاربری خود توسط پشتیبان و تایید آن شکیبا باشید.  </p></div></div></div></div><div class='box-footer'><span> جهت پیگیری این پیام شما می‌توانید در ساعات اداری با شماره تماس 09391815029 تماس حاصل فرمایید.</span></div></div></div>"
            Dim Students = From m In db.Students
                           Select m Where m.Mobile1.ToString = HttpContext.Current.User.Identity.Name.ToString
            For Each m In Students
                Dim dir_path As String = Server.MapPath("~/Students/Uploads/" + m.IDNo)
                'check if any directory exists with same name  
                If Not Directory.Exists(dir_path) Then

                    Directory.CreateDirectory(dir_path)
                End If
                lblStudentsNameFamily.Text = "<p>" + m.Name_Fa + " " + m.Family_Fa + "</p>"
                lblStudentsNameFamily1.Text = "<span class='hidden-xs'>" + m.Name_Fa + " " + m.Family_Fa + "</span>"
                lblStudentsNameFamily2.Text = "<p style='z-index: 5;color: #fff;color: rgba(255, 255, 255, 0.8);font-size: 17px;margin-top: 10px;margin: 0 0 10px;display: block;-webkit-margin-before: 1em;-webkit-margin-after: 1em;-webkit-margin-start: 0px;-webkit-margin-end: 0px;'>" + m.Name_Fa + " " + m.Family_Fa + "<br /><small>دانشجوی مقطع " + m.Evidence_Fa + " رشته‌ی " + m.Job_Fa + "</small></p>"
                'lblSPL.Text = m.SPL
                lblStudentsImage.Text = "<img src='" + m.PhotoMin + "' width='40' />"
                lblStudentsImage1.Text = "<img src='" + m.PhotoMin + "' width='25' />"
                lblStudentsImage2.Text = "<img src='" + m.PhotoMin + "' width='75' />"
            Next
            'Dim p As Integer = 0
            'Dim i As Integer = 0
            'Dim commentRow = From m In db.Comments
            '                 Select m Where m.IDClient = Convert.ToInt32(stridclient) Order By m.IDC Descending
            ''Where m.IDClient = IDClient 
            'For Each m In commentRow
            '    Dim msg As String = m.MSG
            '    If msg.Length > 20 Then
            '        msg = Substr(msg, 0, 19)
            '    End If
            '    If Trim(m.Seen) = "New" Then
            '        lblComments.Text += "<li><a href='Inbox.aspx?ID=" + m.IDC.ToString + "' style='display:block;white-space:nowrap;border-bottom:1px solid #f4f4f4;'><div class='pull-right' style='display: block;'><span class='label label-success' style='margin-right:5px;margin-left:5px;'>" + m.Seen + "</span></div><h4 style='padding: 0;margin: 0 0 0 45px;color:#444444;font-size:12px;position:relative;margin-top:10px;' >" + m.NameAndFamily + "<small style='color:#999999;font-size:9px;position:absolute;top:0;left:0;'><i class='fa fa-clock-o'></i>" + m.Date + "<br /> " + m.Time + "</small></h4><p style='font-size: 10px;color: #888888;'><br />" + msg + "</p></a></li>"
            '        i = i + 1
            '        WarningCount += 1
            '    Else
            '        lblComments.Text += "<li><a href='Inbox.aspx?ID=" + m.IDC.ToString + "' style='display:block;white-space:nowrap;border-bottom:1px solid #f4f4f4;'><div class='pull-right' style='display: block;'><span class='label label-warning' style='margin-right:5px;margin-left:5px;'>" + m.Seen + "</span></div><h4 style='padding: 0;margin: 0 0 0 45px;color:#444444;font-size:12px;position:relative;margin-top:10px;' >" + m.NameAndFamily + "<small style='color:#999999;font-size:9px;position:absolute;top:0;left:0;'><i class='fa fa-clock-o'></i>" + m.Date + "<br /> " + m.Time + "</small></h4><p style='font-size: 10px;color: #888888;' title='" + m.MSG + "'><br />" + msg + "</p></a></li>"

            '    End If
            '    p += 1
            'Next
            lblCommentCount.Text = 0
            'lblCommentCount.Text = p
            'lblCommentNoReadCount.Text = i
            'lblCommentNoReadCount1.Text = i
            ''p = 0
            'i = 0
            'Dim Orders = From m In db.Orders
            '             Select m Where m.IDO = HttpContext.Current.User.Identity.Name

            'For Each m In Orders
            '    MsgBox(m.NameAndFamily)

            'Next
            ''lblOrderCount.Text = i
            'i = 0
            'Dim Tasks = From m In db.Tasks
            '            Select m Order By m.IDT

            'For Each m In Tasks
            '    i = i + 1
            'Next
            ''lblTaskCount.Text = i
            'Dim FAQCU As Integer = 0
            'Dim FAQ = From m In db.FAQs
            '          Select m Where m.Seen = "New" Order By m.IDF

            'For Each m In FAQ
            '    FAQCU += 1
            'Next
            'lblFAQCount.Text = FAQCU
            'lblWarningCount.Text = FAQCU + WarningCount
            'lblWarningCount1.Text = lblWarningCount.Text
            'lblWarningCommentCount.Text = lblCommentNoReadCount.Text
            'Dim visitorS = From m In db.Visitors
            '               Select m
            'For Each m In visitorS
            '    'lblAllVisit.Text = m.AllVisitor
            '    'lblVis.Text = m.Today
            '    'lblToday.Text = m.Today
            'Next
            ''Dim OnlineDetails = From m In db.UsersOnlineDetails
            ''                    Select m Order By m.IDOnline Descending
            ''i = 0
            ''For Each m In OnlineDetails
            ''    lstUserOnlineDetails.Text += "<tr><td style='direction:ltr;text-align:center;'><a href='#'>" + m.DateAndTime + " </a></td><td style='direction:ltr;text-align:center;'>" + m.Platform + "</td><td style='direction:ltr;text-align:center;'><span class='label label-success'>" + m.Browser + "</span></td><td style='direction:ltr;text-align:center;'><span class='label label-info'>" + m.MachinName + "</span></td><td style='direction:ltr;text-align:center;'><div class='sparkbar' data-color='#00a65a' data-height='20'>" + m.IPAddress + "</div></td><td style='direction:ltr;text-align:center;'><a href='" + m.Page + "'><span class='label label-success'>" + m.Page + "</span></a></td></tr>"
            ''    i += 1
            ''    If i > 8 Then Exit For
            ''Next
        Catch ex As Exception
            Response.Write(ex.Message)

        End Try
        Dim lblActiveParent As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIPanel"))
        lblActiveParent.Attributes("Class") = "active treeview"
        Dim lblActive As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIStudentsPanel"))
        lblActive.Attributes("Class") = "active treeview"
        'divProgressVisC.Attributes("Style") = "width:" + Application("visToday").ToString + "%;"
    End Sub
    Public Function Substr(InputText As String, StartIndex As Integer, Length As Integer) As String

        Return InputText.Substring(StartIndex, Length) + " ... "
    End Function
End Class
