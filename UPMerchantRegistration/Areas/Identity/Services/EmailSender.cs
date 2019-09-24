using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace UPMerchantRegistration.Areas.Identity.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }
        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            int port = 587;
            //apiKey = "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";
            //var client = new SendGridClient(apiKey);
            //var msg = new SendGridMessage()
            //{
            //    //azure_ceefa318cd5ee089a902be0329f7a7fb@azure.com
            //    From = new EmailAddress("azure_ceefa318cd5ee089a902be0329f7a7fb@azure.com", "Antoine"),
            //    Subject = subject,
            //    PlainTextContent = message,
            //    HtmlContent = message

            //};
            //msg.AddTo(new EmailAddress(email));
            //// Disable click tracking. 
            //// See https://sendgrid.com/docs/User_Guide/Settings/tracking.html 

            //msg.TrackingSettings = new TrackingSettings
            //{
            //    ClickTracking = new ClickTracking { Enable = false }
            //};

            //return client.SendEmailAsync(msg);
            var client = new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                Port = port,
                Credentials = new NetworkCredential("tonidavis01@gmail.com", "salvador08")

            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress("noreply@npfportal.com")
            };
            mailMessage.To.Add(email);
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            return client.SendMailAsync(mailMessage);
        }
    }
}
