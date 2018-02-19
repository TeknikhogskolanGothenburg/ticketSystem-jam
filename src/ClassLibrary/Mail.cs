using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using ClassLibrary;

namespace ClassLibrary
{
    public class Mail
    {
        public void SendEmail(string email, string nickName, string s)
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                var mail = new MailMessage
                {
                    From = new MailAddress("jamsweden123@gmail.com")
                };

                mail.To.Add(email);
                mail.Subject = "Thanks for your order";
                mail.Body = s;
                mail.IsBodyHtml = true;
                    
                SmtpServer.Port = 587;

                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("jamsweden123@gmail.com", "Jam123456");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception)
            {
                //ignore
            }
        }

    }
}