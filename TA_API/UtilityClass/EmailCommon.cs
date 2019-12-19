using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TA_API.UtilityClass
{
    public class EmailCommon
    {
        public static bool SendEmail(EmailModel emailmodel)
        {
            try
            {

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = true;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("exstream85@gmail.com", "Exstream@123");
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("exstream85@gmail.com");
                mailMessage.To.Add(emailmodel.Email);
                mailMessage.Body = emailmodel.body;
                mailMessage.Subject = emailmodel.subject;
                mailMessage.IsBodyHtml = true;
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
