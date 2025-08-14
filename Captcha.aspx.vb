
Imports System.Drawing
Imports System.Text

Partial Class Captcha
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        '//ایجاد شیء گرافیک و دیگر ملزومات
        Dim objBMP As Bitmap = New System.Drawing.Bitmap(80, 25)
        Dim objGraphics As Graphics = System.Drawing.Graphics.FromImage(objBMP)
        objGraphics.Clear(Color.White)
        objGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
        '//تنظیم فونت نوشته روی عکس
        Dim objFont As Font = New Font("Viner Hand ITC", 13, FontStyle.Bold)
        '//ساخت رشته تصادفی ۵ رقمی 
        Dim randomStr As String = ""
        Dim autoRand As Random = New Random()
        randomStr = Convert.ToString(autoRand.Next(1234567, 9999999))

        '//اضافه کردن متن در جلسه 
        Session.Add("randomStr", randomStr)

        '//نوشتن متن
        objGraphics.DrawString(randomStr, objFont, Brushes.DarkCyan, 6, 3)

        '//تنظیم نوع عکس و برگرداندن آن به عنوان خروجی
        Response.ContentType = "image/GIF"
        objBMP.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif)

        '//آزاد کردن منابع
        objFont.Dispose()
        objGraphics.Dispose()
        objBMP.Dispose()
    End Sub
End Class
