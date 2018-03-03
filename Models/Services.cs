using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ISD.Models
{
    public class ISDServices
    {

        //sending mail to admin
        public void SendMailToAdmin(string subject,string sendTo)
        {
            string senderId = ConfigurationManager.AppSettings["mailSenderId"];
            string senderPassword = ConfigurationManager.AppSettings["mailSenderPassword"];
            if (!string.IsNullOrEmpty(senderId) && !string.IsNullOrEmpty(senderPassword))
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(sendTo);
                mail.From = new MailAddress(senderId);
                mail.Subject = subject;              
                mail.Body = "<p>Dear " + "yogi" + " <br><br><br>Thank you for sending your resume. We have received your application.<br>We will contact you shortly.<br><br><br>Regards,<br>Caliber HR team</p>";
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtpout.secureserver.net";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential
                (senderId, senderPassword);// Enter seders User name and password
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }

       
    }
}