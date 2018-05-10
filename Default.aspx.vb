
Imports System.Net
Imports System.Net.Mail

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub btnGonder_Click(sender As Object, e As EventArgs)
        Dim name = txtIsim.Text.Trim
        Dim soyad = txtSoyisim.Text.Trim
        Dim eMail = txtEMail.Text.Trim
        Dim mesaj = "İsim: " & name & "\nSoyisim: " & soyad & "\nMesaj: " & txtMsg.Text.Trim & "\nGönderen Mail: " & txtEMail.Text

        Dim sc As New SmtpClient()
        sc.Port = 587
        sc.Host = "smtp.gmail.com"
        sc.EnableSsl = True
        sc.UseDefaultCredentials = True

        sc.Credentials = New NetworkCredential("cetinyolyapi0623@gmail.com", "malatya440623")
        Dim Mail As New MailMessage()
        Mail.From = New MailAddress("cetinyolyapi0623@gmail.com", "Çetin Yol Yapı")
        Mail.To.Add("cetinyolyapi0623@gmail.com")
        Mail.To.Add("mail.yildirim.21@gmail.com")
        Mail.Subject = "Site Mail"
        Mail.IsBodyHtml = False
        Mail.Body = mesaj
        Try
            sc.Send(Mail)
            Response.Write("<script>alert('Mail Gönderildi.');window.location=window.location.href;</script>")

        Catch ex As Exception
            Response.Write("<script>alert('Mail Gönderilirken hata oluştu." & ex.Message & "');window.location=window.location.href;</script>")
        End Try

    End Sub
End Class
