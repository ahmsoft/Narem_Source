
Partial Class CustomersPanel
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            Dim lblCommentNoReadCount As Label = Master.FindControl("lblCommentNoReadCount")
            Dim lblCommentNoReadCount1 As Label = Master.FindControl("lblCommentNoReadCount1")
            Dim lblCustomersImage As Label = Master.FindControl("lblCustomersImage")
            Dim lblCustomersImage1 As Label = Master.FindControl("lblCustomersImage1")
            Dim lblCustomersImage2 As Label = Master.FindControl("lblCustomersImage2")
            Dim lblCustomersNameFamily As Label = Master.FindControl("lblCustomersNameFamily")
            Dim lblCustomersNameFamily1 As Label = Master.FindControl("lblCustomersNameFamily1")
            Dim lblCustomersNameFamily2 As Label = Master.FindControl("lblCustomersNameFamily2")

            Dim WarningCount As Integer = 0
            Dim lblComments As Label = Master.FindControl("lblComments")
            Dim CurrentIDO As Integer
            Dim db = New LinqDBClassesDataContext
                lblCustomerPanel.Text = "<div class='box box-danger'><div class='box-header with-border'><h3 class='box-title' data-widget='collapse' style='cursor:pointer;'><span style='color:red;'>* توجه *</span> لطفا تا پایان بررسی اطلاعات اشتراک شما، شکیبا باشید.</h3><div class='box-tools pull-right'><button type='button' class='btn btn-box-tool' data-widget='collapse'><i class='fa fa-minus'></i></button></div></div><div class='box-body'><div class='row'><div class='row'><div class='form-group col-md-12'><span class='col-md-1 control-label' style='width: 100%;'>پیام مدیر فروش شرکت:</span><div class='col-md-12'><p style='border-style: solid; border-color: rgb(150, 10, 10); padding: 10px; height: 100%; width: 100%;'>اطلاعات سفارش شما هنوز در سیستم بارگذاری نشده. لطفا تا پایان بررسی و ثبت اطلاعات شما توسط کارشناسان ما شکیبا باشید.</p></div></div></div></div><div class='box-footer'><span> جهت پیگیری این پیام شما میتوانید در ساعات اداری با شماره تماس 09391815029 تماس حاصل فرمایید.</span></div></div></div>"
            Dim Prof = From Customer In db.Users, Servises In db.Servises
                       Where Customer.Username = Servises.Username Select Customer, Servises 'HttpContext.Current.User.Identity.Name.ToString 
            For Each q In Prof
                MsgBox(q.Servises.Name_Fa.ToString)
                For Each Auth In q.Customer.Authoritys.ToString.Split(";")
                    MsgBox(Auth.ToString)
                    If Auth = "Domain" And q.Servises.Authority = "Domain" Then
                        lblCustomerPanel.Text += "<div class='box box-danger'><div class='box-header with-border'><h3 class='box-title' data-widget='collapse' style='cursor:pointer;'>اطلاعات دامنه شما.</h3><div class='box-tools pull-right'><button type='button' class='btn btn-box-tool' data-widget='collapse'><i class='fa fa-minus'></i></button></div></div>" +
                        "<div class='box-body no-padding'><table class='table table-striped'><tr><th style='width: 10px'>#</th><th>مشخصات</th><th>جزئیات</th><th style='width: 40px'>وضعیت</th></tr>" +
                        "<tr><td>1.</td><td>نام دامنه:</td><td>" + q.Servises.Name_Fa + "</td><td><span class='badge bg-green'>" + q.Servises.Status_Fa + "</span></td></tr>" +
                        "<tr><td>2.</td><td>نوع دامنه:</td><td>" + q.Servises.Deployment_Fa + "(" + q.Servises.Type_Fa + ")</td><td><span class='badge bg-yellow'>2017 Server</span></td></tr>" +
                        "<tr><td>3.</td><td>تاریخ ثبت:</td><td>" + q.Servises.MomentBuy_Fa + "</td><td><span class='badge bg-yellow'>آخرین خرید</span></td></tr>" +
                        "<tr><td>4.</td><td>تاریخ سر رسید:</td><td>" + q.Servises.MomentExp_Fa + "</td><td><span class='badge bg-yellow'>به مدت 1 سال</span></td></tr>" +
                        "<tr><td>5.</td><td>قیمت پرداخت شده:</td><td>" + q.Servises.OneYearPrice_Fa + " تومان </td><td><span class='badge bg-green'>بدون تخفیف</span></td></tr>" +
                        "<tr><td>6.</td><td>قیمت 2 ساله با تخفیف:</td><td>" + ((q.Servises.OneYearPrice_Fa * 2) - ((q.Servises.OneYearPrice_Fa * q.Servises.TwoYearPercent) / 100)).ToString + " تومان </td><td><span class='badge bg-green'>10%</span></td></tr>" +
                        "<tr><td>7.</td><td>قیمت 3 ساله با تخفیف:</td><td>" + ((q.Servises.OneYearPrice_Fa * 3) - ((q.Servises.OneYearPrice_Fa * q.Servises.ThreeYearPercent) / 100)).ToString + " تومان </td><td><span class='badge bg-green'>20%</span></td></tr>" +
                        "<tr><td>8.</td><td>مقدار حجم استفاده:</td><td><div class='progress progress-xs progress-striped active'><div class='progress-bar progress-bar-primary' style='width: 4%'></div></div></td><td><span class='badge bg-light-blue'>4% نامحدود</span></td></tr>" +
                        "</table></div></div>"
                    End If
                    If Auth = "Host" And q.Servises.Authority = "Host" Then
                        lblCustomerPanel.Text += "<div class='box box-danger'><div class='box-header with-border'><h3 class='box-title' data-widget='collapse' style='cursor:pointer;'>اطلاعات هاست شما.</h3><div class='box-tools pull-right'><button type='button' class='btn btn-box-tool' data-widget='collapse'><i class='fa fa-minus'></i></button></div></div>" +
                        "<div class='box-body no-padding'><table class='table table-striped'><tr><th style='width: 10px'>#</th><th>مشخصات</th><th>جزئیات</th><th style='width: 40px'>وضعیت</th></tr>" +
                        "<tr><td>1.</td><td>نام هاست:</td><td>" + q.Servises.Name_Fa + "</td><td><span class='badge bg-green'>" + q.Servises.Status_Fa + "</span></td></tr>" +
                        "<tr><td>2.</td><td>نوع هاست:</td><td>" + q.Servises.Deployment_Fa + "(" + q.Servises.Type_Fa + ")</td><td><span class='badge bg-yellow'>2017 Server</span></td></tr>" +
                        "<tr><td>4.</td><td>نوع پایگاه داده:</td><td>" + q.Servises.DBase_Fa + "</td><td><span class='badge bg-yellow'>2017</span></td></tr>" +
                        "<tr><td>5.</td><td>ترافیک ماهانه:</td><td>" + q.Servises.Trafic + "</td><td><span class='badge bg-green'>Unlimite</span></td></tr>" +
                        "<tr><td>6.</td><td>تاریخ ثبت:</td><td>" + q.Servises.MomentBuy_Fa + "</td><td><span class='badge bg-yellow'>آخرین خرید</span></td></tr>" +
                        "<tr><td>7.</td><td>تاریخ سر رسید:</td><td>" + q.Servises.MomentExp_Fa + "</td><td><span class='badge bg-yellow'>به مدت 1 سال</span></td></tr>" +
                        "<tr><td>8.</td><td>قیمت پرداخت شده:</td><td>" + q.Servises.OneYearPrice_Fa + " تومان </td><td><span class='badge bg-green'>بدون تخفیف</span></td></tr>" +
                        "<tr><td>9.</td><td>قیمت 2 ساله با تخفیف:</td><td>" + ((q.Servises.OneYearPrice_Fa * 2) - ((q.Servises.OneYearPrice_Fa * q.Servises.TwoYearPercent) / 100)).ToString + " تومان </td><td><span class='badge bg-green'>10%</span></td></tr>" +
                        "<tr><td>10.</td><td>قیمت 3 ساله با تخفیف:</td><td>" + ((q.Servises.OneYearPrice_Fa * 3) - ((q.Servises.OneYearPrice_Fa * q.Servises.ThreeYearPercent) / 100)).ToString + " تومان </td><td><span class='badge bg-green'>20%</span></td></tr>" +
                        "<tr><td>11.</td><td>مقدار حجم استفاده:</td><td><div class='progress progress-xs progress-striped active'><div class='progress-bar progress-bar-primary' style='width: 4%'></div></div></td><td><span class='badge bg-light-blue'>4% نامحدود</span></td></tr>" +
                        "</table></div></div>"
                    End If
                    If Auth = "Project" And q.Servises.Authority = "Project" Then
                        lblCustomerPanel.Text += "<div class='box box-primary'><div class='box-header with-border'><h3 class='box-title' data-widget='collapse' style='cursor:pointer;'>روند پیشرفت پروژه </h3><div class='box-tools pull-right'><button type='button' class='btn btn-box-tool' data-widget='collapse'><i class='fa fa-minus'></i></button></div></div>" +
                        "<div class='box-body'><div class='row'><div class='row'><div class='form-group col-md-12'><span class='col-md-1 control-label' style='width: 100%;'>پیام مدیر خط تولید شرکت:</span><div class='col-md-12'><p style='border-style: solid; border-color: rgb(98, 98, 0); padding: 10px; height: 100%; width: 100%;'>" + q.Servises.Authority + "</p>" +
                        "</div></div></div></div><div class='box-footer'><span>درحال حاضر سیستم پنل مشتری در حال توسعه می‌باشد.</span></div></div></div>"
                    End If
                Next
            Next
            Dim Order = From m In db.Orders
                        Select m Where m.IDO = CurrentIDO
            For Each m In Order
                lblCustomersNameFamily.Text = "<p>" + m.NameAndFamily + "</p>"
                lblCustomersNameFamily1.Text = "<span class='hidden-xs'>" + m.NameAndFamily + "</span>"
                lblCustomersNameFamily2.Text = "<p style='z-index: 5;color: #fff;color: rgba(255, 255, 255, 0.8);font-size: 17px;margin-top: 10px;margin: 0 0 10px;display: block;-webkit-margin-before: 1em;-webkit-margin-after: 1em;-webkit-margin-start: 0px;-webkit-margin-end: 0px;'>" + m.NameAndFamily + "<br /><small>نماینده " + m.SiteNameFA + "</small></p>"
                'lblSPL.Text = m.SPL
            Next
            Dim p As Integer = 0
            Dim i As Integer = 0
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
            lblCommentCount.Text = p
            lblCommentNoReadCount.Text = i
            lblCommentNoReadCount1.Text = i
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
            'Response.Write(ex.Message)

        End Try
        'Dim lblActiveParent As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLIPanel"))
        'lblActiveParent.Attributes("Class") = "active"
        'Dim lblActive As System.Web.UI.HtmlControls.HtmlGenericControl = (Master.FindControl("menuLICustomersPanel"))
        'lblActive.Attributes("Class") = "active"
        'divProgressVisC.Attributes("Style") = "width:" + Application("visToday").ToString + "%;"
    End Sub
    Public Function Substr(InputText As String, StartIndex As Integer, Length As Integer) As String

        Return InputText.Substring(StartIndex, Length) + " ... "
    End Function
End Class
