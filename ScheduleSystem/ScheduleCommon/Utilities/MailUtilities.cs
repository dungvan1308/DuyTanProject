using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleCommon.Utilities
{
    public class MailUtilities
    {
        public static void Alert(string subject, string body)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(string.Format("system@sacombank.com"));
            foreach (string email in ConfigurationManager.AppSettings["MonitorUsers"].ToLower().Split(';'))
            {
                if (!string.IsNullOrEmpty(email))
                {
                    message.To.Add(email);
                }
            }
            message.Priority = MailPriority.Normal;
            message.SubjectEncoding = Encoding.UTF8;
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;
            message.Body = body;

            using (SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["SMTPHost"], int.Parse(ConfigurationManager.AppSettings["SMTPPort"])))
            {
                client.Send(message);
            }
        }
    }
}
