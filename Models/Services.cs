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
        public void SendMailToAdmin(string subject,CustomerQuery query)
        {
            string senderId = ConfigurationManager.AppSettings["mailSenderId"];
            string senderPassword = ConfigurationManager.AppSettings["mailSenderPassword"];
            if (!string.IsNullOrEmpty(senderId) && !string.IsNullOrEmpty(senderPassword))
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(senderId);
                mail.From = new MailAddress(senderId);
                mail.Subject = subject;
                // mail.Body = "<p>Dear " + Name + " <br><br><br>Thank you for sending your request. We have received your query.<br>We will contact you shortly.<br><br><br>Regards,<br>ISD (Indian Steel Design) HR team</p>";
                mail.Body = "<p> Received a user query with following details : <br><br> <b>Name -  "+query.Name+ "</b><br> <b>Email -  " + query.Email + "</b><br> <b>Contact No -  " + query.PhoneNo + "</b><br> <b>Message -  " + query.Message + "</b></p>";
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtpout.secureserver.net";
                smtp.Port = 80;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                (senderId, senderPassword);// Enter seders User name and password
                //smtp.EnableSsl = true;
                smtp.Timeout = 20000;
                smtp.Send(mail);
            }
        }

       
    }
}


//MailMessage msg = new MailMessage();
//msg.Body = "fuck yeah";
//                msg.From = new MailAddress("info@indiansteeldesign.com");
//msg.To.Add("yogendra.ms95@gmail.com");


//                SmtpClient smtpClient = new SmtpClient();
//smtpClient.Host = "smtpout.secureserver.net";
//                smtpClient.Port = 80;
//               // smtpClient.EnableSsl = true;
//                smtpClient.UseDefaultCredentials = false;
//                smtpClient.Credentials =
//                 new NetworkCredential("info@indiansteeldesign.com", "Indiansteel@123");
//smtpClient.Timeout = 20000;
//                smtpClient.Send(msg);