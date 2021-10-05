using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EmployeeManagementSystem.Business.Logic.EmailLogic.BaseEmail
{
    public abstract class Email
    {
        private string _to;
        private string _subject;

        public Email(string To, string Subject)
        {
            _to = To;
            _subject = Subject;
        }

        public abstract string CreateEmailBody();

        public string GetEmailTemplate()
        {
            return File.ReadAllText(HttpContext.Current.Server.MapPath(@"~/Views/Shared/emailTemplate.html"));
        }

        public string GetEmailTemlateWithActionButton(string buttonName, string link)
        {
            var template = GetEmailTemplate();
            template = template.Replace("actionButton", "");
            template = template.Replace("{#ButtonLink}", link);
            return template.Replace("{#Buttontext}", buttonName);
        }

        public string GetEmailTemlateWithActionButtonAndHtmlContent(string buttonName, string link, string htmlContent)
        {
            var template = GetEmailTemplate();
            template = template.Replace("actionButton", "");
            template = template.Replace("Email_bodyContent", "");
            template = template.Replace("{#ButtonLink}", link);
            template = template.Replace("{#Buttontext}", buttonName);
            return template.Replace("{#emailBodyContent}", string.Format(htmlContent));
        }

        public string GetEmailTemlateWithHtmlContent(string htmlContent)
        {
            var template = GetEmailTemplate();
            template = template.Replace("Email_bodyContent", "");
            return template.Replace("{#emailBodyContent}", htmlContent);
        }

        public void SendMail()
        {
            MailMessage mc = new MailMessage("21601754@dut4life.ac.za", _to, _subject, CreateEmailBody());
            mc.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
            smtp.Timeout = 1000000;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("21601754@dut4life.ac.za", "Dut970524");
            smtp.Send(mc);
        }
    }
}
