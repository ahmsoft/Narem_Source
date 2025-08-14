Imports System.IO
Imports System.Windows
Partial Class Upload
    Inherits System.Web.UI.Page

    'Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    '    Try
    '        Dim lblCommentNoReadCount As Label = Master.FindControl("lblCommentNoReadCount")
    '        Dim lblCommentNoReadCount1 As Label = Master.FindControl("lblCommentNoReadCount1")
    '        Dim lblCustomersImage As Label = Master.FindControl("lblCustomersImage")
    '        Dim lblCustomersImage1 As Label = Master.FindControl("lblCustomersImage1")
    '        Dim lblCustomersImage2 As Label = Master.FindControl("lblCustomersImage2")
    '        Dim lblCustomersNameFamily As Label = Master.FindControl("lblCustomersNameFamily")
    '        Dim lblCustomersNameFamily1 As Label = Master.FindControl("lblCustomersNameFamily1")
    '        Dim lblCustomersNameFamily2 As Label = Master.FindControl("lblCustomersNameFamily2")
    '        Dim lblFAQCount As Label = Master.FindControl("lblFAQCount")
    '        Dim lblWarningCount As Label = Master.FindControl("lblWarningCount")
    '        Dim lblWarningCount1 As Label = Master.FindControl("lblWarningCount1")
    '        Dim lblWarningCommentCount As Label = Master.FindControl("lblWarningCommentCount")
    '        Dim WarningCount As Integer = 0

    '        Dim lblComments As Label = Master.FindControl("lblComments")
    '        Dim db = New LinqDBClassesDataContext
    '        Dim User = From m In db.Users
    '                   Select m Order By m.IDU

    '        For Each m In User
    '            If m.IsSupervisor = "1" Then
    '                lblCustomersImage2.Text = "<img src='" + m.PhotoMin + "' class='user-image' style='z-index: 5;height: 90px;width: 90px;border: 3px solid;border-color: transparent;border-color: rgba(255, 255, 255, 0.2);border-radius: 50%;' alt='User Image' />"
    '                lblCustomersImage1.Text = "<img src='" + m.PhotoMin  + "' class='user-image' style='z-index: 5;height: 30px;width: 30px; border-radius: 50%;' alt='User Image' />"
    '                lblCustomersImage.Text = "<img src='" + m.PhotoMin + "' class='user-image' style='width: 100%;max-width: 45px;height: auto; border-radius: 50%;' alt='User Image' />"
    '                lblCustomersNameFamily.Text = "<p>" + m.Name_Fa + " " + m.Family_Fa + "</p>"
    '                lblCustomersNameFamily1.Text = "<span class='hidden-xs'>" + m.Name_Fa + " " + m.Family_Fa + "</span>"
    '                lblCustomersNameFamily2.Text = "<p style='z-index: 5;color: #fff;color: rgba(255, 255, 255, 0.8);font-size: 17px;margin-top: 10px;margin: 0 0 10px;display: block;-webkit-margin-before: 1em;-webkit-margin-after: 1em;-webkit-margin-start: 0px;-webkit-margin-end: 0px;'>" + m.Name_Fa + " " + m.Family_Fa + "<br /><small>مدیریت کل سایت</small></p>"
    '            End If
    '        Next
    '        Dim p As Integer = 0
    '        Dim i As Integer = 0
    '        Dim ContactUsRow = From m In db.ContactUs
    '                         Select m Order By m.IDCU Descending

    '        For Each m In ContactUsRow
    '            Dim msg As String = ""
    '            If m.NameAndFamily_En <> "" Then 'Or q.NameAndFamily_En IsNot Nothing Then
    '                msg = m.MSG_En
    '                If msg.Length > 51 Then
    '                    msg = Substr(msg, 0, 51)
    '                Else
    '                    msg = m.MSG_En
    '                End If
    '                If Trim(m.Seen) = "جدید" Then
    '                    lblContactUss.Text += "<li><a href='Inbox.aspx?ID=" + m.IDCU.ToString + "' style='display:block;white-space:nowrap;border-bottom:1px solid #f4f4f4;'><div class='pull-right' style='display: block;'><span class='label label-success' style='margin-right:5px;margin-left:5px;'>" + m.Seen + "</span></div><h4 style='padding: 0;margin: 0 0 0 45px;color:#444444;font-size:12px;position:relative;margin-top:10px;' title='" + m.MSG_En + "'>" + m.NameAndFamily_En + "<small style='color:#999999;font-size:9px;position:absolute;top:0;left:0;'><br/><i class='fa fa-clock-o'style='margin:5px;'> </i>" + m.Moment_Fa + "</small></h4><p style='direction:ltr;font-size: 10px;color: #888888;padding:15px;'title='" + m.MSG_En + "'>" + msg + "</p></a></li>"
    '                    i = i + 1
    '                    WarningCount += 1
    '                Else
    '                    lblContactUss.Text += "<li><a href='Inbox.aspx?ID=" + m.IDCU.ToString + "' style='display:block;white-space:nowrap;border-bottom:1px solid #f4f4f4;'><div class='pull-right' style='display: block;'><span class='label label-warning' style='margin-right:5px;margin-left:5px;'>" + m.Seen + "</span></div><h4 style='padding: 0;margin: 0 0 0 45px;color:#444444;font-size:12px;position:relative;margin-top:10px;' title='" + m.MSG_En + "'>" + m.NameAndFamily_En + "<small style='color:#999999;font-size:9px;position:absolute;top:0;left:0;'><br/><i class='fa fa-clock-o'style='margin:5px;'> </i>" + m.Moment_Fa + "</small></h4><p style='direction:ltr;font-size: 10px;color: #888888;padding:15px;' title='" + m.MSG_En + "'>" + msg + "</p></a></li>"
    '                End If
    '            ElseIf m.NameAndFamily_Fa <> "" Then 'Or q.NameAndFamily_Fa IsNot Nothing
    '                msg = m.MSG_Fa
    '                If msg.Length > 51 Then
    '                    msg = Substr(msg, 0, 51)
    '                Else
    '                    msg = m.MSG_Fa
    '                End If
    '                If Trim(m.Seen) = "جدید" Then
    '                    lblContactUss.Text += "<li><a href='Inbox.aspx?ID=" + m.IDCU.ToString + "' style='display:block;white-space:nowrap;border-bottom:1px solid #f4f4f4;'><div class='pull-right' style='display: block;'><span class='label label-success' style='margin-right:5px;margin-left:5px;'>" + m.Seen + "</span></div><h4 style='padding: 0;margin: 0 0 0 45px;color:#444444;font-size:12px;position:relative;margin-top:10px;' title='" + m.MSG_Fa + "'>" + m.NameAndFamily_Fa + "<small style='color:#999999;font-size:9px;position:absolute;top:0;left:0;'><br/><i class='fa fa-clock-o'style='margin:5px;'> </i>" + m.Moment_Fa + "</small></h4><p style='direction:rtl;font-size: 10px;color: #888888;padding:15px;'title='" + m.MSG_Fa + "'>" + msg + "</p></a></li>"
    '                    i = i + 1
    '                    WarningCount += 1
    '                Else
    '                    lblContactUss.Text += "<li><a href='Inbox.aspx?ID=" + m.IDCU.ToString + "' style='display:block;white-space:nowrap;border-bottom:1px solid #f4f4f4;'><div class='pull-right' style='display: block;'><span class='label label-warning' style='margin-right:5px;margin-left:5px;'>" + m.Seen + "</span></div><h4 style='padding: 0;margin: 0 0 0 45px;color:#444444;font-size:12px;position:relative;margin-top:10px;' title='" + m.MSG_Fa + "'>" + m.NameAndFamily_Fa + "<small style='color:#999999;font-size:9px;position:absolute;top:0;left:0;'><br/><i class='fa fa-clock-o'style='margin:5px;'> </i>" + m.Moment_Fa + "</small></h4><p style='direction:rtl;font-size: 10px;color: #888888;padding:15px;' title='" + m.MSG_Fa + "'>" + msg + "</p></a></li>"
    '                End If
    '            End If
    '            p += 1
    '        Next
    '        lblCommentNoReadCount.Text = i
    '        lblCommentNoReadCount1.Text = i
    '        Dim FAQCU As Integer = 0
    '        Dim FAQ = From m In db.FAQs
    '                  Select m Where m.Seen = "New" Order By m.IDF

    '        For Each m In FAQ
    '            FAQCU += 1
    '        Next
    '        lblFAQCount.Text = FAQCU
    '        lblWarningCount.Text = FAQCU + WarningCount
    '        lblWarningCount1.Text = lblWarningCount.Text
    '        lblWarningCommentCount.Text = lblCommentNoReadCount.Text
    '    Catch ex As Exception
    '        Response.Write(ex.Message)
    '    End Try
    '    Dim lblActive As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIUploads"))
    '    lblActive.Attributes("Class") = "active"
    '    Dim paths As String() = New String() {"~/Uploads/"}
    'End Sub
    Public Function Substr(InputText As String, StartIndex As Integer, Length As Integer) As String

        Return InputText.Substring(StartIndex, Length) + " ... "
    End Function
End Class
