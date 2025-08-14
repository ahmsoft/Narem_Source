Imports System.Security.Cryptography
Imports Microsoft.VisualBasic

Public Class AHMSECKEY
    Public Function Encrypt(plainText As String) As String
        Dim b As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(plainText + "NAREM.IR")
        Dim encrypted As String = Convert.ToBase64String(b)
        Encrypt = encrypted
    End Function

    Public Function Decrypt(Password As String) As String
        Dim b As Byte()
        Dim decrypted As String
        Try
            b = Convert.FromBase64String(Password)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b)
        Catch ex As Exception
            decrypted = ""
        End Try
        Try
            Decrypt = decrypted.ToString.Substring(0, decrypted.Length - 8)
        Catch ex As Exception
            Decrypt = "Error"
        End Try
    End Function
End Class
