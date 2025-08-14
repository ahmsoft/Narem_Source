Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Net.Http
Imports System.Text
Public Class RayganSms
    Dim DEC As New AHMSECKEY()
    Public Function SendSmsMessageGetMethod(username As String, password As String, phoneNumber As String, messageBody As String, recNumber As String) As Boolean
        If (phoneNumber <> "") Then
            SendSmsMessageGetMethod = False
        End If

        Dim client = New HttpClient()
        'https://RayganSMS.com/SendMessageWithUrl.ashx?Username=&Password=&PhoneNumber=&MessageBody=&RecNumber=&Smsclass=1
        Dim url =
                "https://RayganSMS.com/SendMessageWithUrl.ashx" + "?UserName=" + username + "&Password=" + DEC.Decrypt(password) + "&PhoneNumber=" + phoneNumber + "&MessageBody=" + messageBody + "&RecNumber=" + recNumber + "&Smsclass=1"
        Dim response = client.GetAsync(url).Result

        Dim result = response.Content.ReadAsStringAsync().Result
        Dim resultCode = Long.Parse(result)
        Dim isSuccessful = resultCode
        SendSmsMessageGetMethod = Int16.Parse(isSuccessful) > 2000
    End Function
    Public Function SendSmsAutGetMethod(username As String, password As String, mobile As String, footer As String) As Boolean
        If (mobile <> "") Then
            SendSmsAutGetMethod = False
        End If

        Dim client = New HttpClient()
        'https://raygansms.com/AutoSendCode.ashx?UserName=&Password=&Mobile=&Footer=

        Dim url =
                "https://RayganSMS.com/AutoSendCode.ashx" + "?UserName=" + username + "&Password=" + DEC.Decrypt(password) + "&Mobile=" + mobile + "&Footer=" + footer
        Dim response = client.GetAsync(url).Result

        Dim result = response.Content.ReadAsStringAsync().Result
        Dim resultCode = Long.Parse(result)
        Dim isSuccessful = resultCode
        SendSmsAutGetMethod = Int16.Parse(isSuccessful) > 2000
    End Function
    Public Function CheckVerifyCodeWithGetMethod(username As String, password As String, mobile As String, code As String) As Boolean
        If (mobile <> "") Then
            CheckVerifyCodeWithGetMethod = False
        End If

        Dim client = New HttpClient()
        'https://raygansms.com/CheckSendCode.ashx?UserName=&Password=&Mobile=&Code=

        Dim url =
                "https://raygansms.com/CheckSendCode.ashx" + "?UserName=" + username + "&Password=" + DEC.Decrypt(password) + "&Mobile=" + mobile + "&Code=" + code
        Dim response = client.GetAsync(url).Result
        Dim result = response.Content.ReadAsStringAsync().Result
        CheckVerifyCodeWithGetMethod = Boolean.Parse(result)
    End Function
    Public Function SendSmsMessageWithPostMethod(phone As String, message As String, username As String, password As String,
             senderPhoneNumber As String) As Boolean
        If (phone <> "") Then
            SendSmsMessageWithPostMethod = False
            Return False
        End If

        Dim client = New HttpClient()

        Dim url =
                "https://RayganSMS.com/SendMessageWithUrl.ashx" + "?Username=" + username + "&Password=" + DEC.Decrypt(password) + "&PhoneNumber=" + senderPhoneNumber + "&MessageBody=" + message + "&RecNumber=" + phone + "&Smsclass=1"
        Dim response = client.GetAsync(url).Result

        Dim result = response.Content.ReadAsStringAsync().Result
        Dim resultCode = Long.Parse(result)
        Dim isSuccessful = resultCode >= 2000
        SendSmsMessageWithPostMethod = isSuccessful
    End Function
End Class
