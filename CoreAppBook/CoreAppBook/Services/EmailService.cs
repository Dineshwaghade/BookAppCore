using CoreAppBook.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CoreAppBook.Services
{
    public class EmailService : IEmailService
    {
        private const string templatePath = @"EmailTemplate/{0}.html";
        private readonly SMTPConfigModel _smtpconfig;

        public EmailService(IOptions<SMTPConfigModel> smtpconfig)
        {
            _smtpconfig = smtpconfig.Value;
        }
        public async Task SendTestEmail(UserEmailOptions userEmailOptions)
        {
            userEmailOptions.Subject = UpdatePlaceholder("Hello {{Username}} this is tes email",userEmailOptions.Placeholder);
            userEmailOptions.Body = UpdatePlaceholder(GetEmailBody("TestEmail"), userEmailOptions.Placeholder);
            await SendEmail(userEmailOptions);
        }
        public async Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions)
        {
            userEmailOptions.Subject = UpdatePlaceholder("Hello {{Username}} confirm your email id", userEmailOptions.Placeholder);
            userEmailOptions.Body = UpdatePlaceholder(GetEmailBody("EmailConfirmation"), userEmailOptions.Placeholder);
            await SendEmail(userEmailOptions);
        }
        private async Task SendEmail(UserEmailOptions userEmailOptions)
        {
            MailMessage mail = new MailMessage()
            {
                Subject = userEmailOptions.Subject,
                Body = userEmailOptions.Body,
                From = new MailAddress(_smtpconfig.SenderAddress, _smtpconfig.SenderDisplayName),
                IsBodyHtml = _smtpconfig.IsBodyHTML
            };
            foreach (var toemail in userEmailOptions.ToEmails)
            {
                mail.To.Add(toemail);
            }
            NetworkCredential networkCredential = new NetworkCredential(_smtpconfig.Username, _smtpconfig.Password);
            SmtpClient smtpClient = new SmtpClient()
            {
                Host = _smtpconfig.Host,
                Port = _smtpconfig.Port,
                EnableSsl = _smtpconfig.EnableSSL,
                UseDefaultCredentials = _smtpconfig.UseDefaultCredentials,
                Credentials = networkCredential
            };
            mail.BodyEncoding = System.Text.Encoding.Default;
            await smtpClient.SendMailAsync(mail);
        }
        private string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, templateName));
            return body;
        }
        private string UpdatePlaceholder(string text, List<KeyValuePair<string,string>> keyvaluepair)
        {
            if(!string.IsNullOrEmpty(text) && keyvaluepair!=null)
            {
                foreach (var placeholder in keyvaluepair)
                {
                    if (text.Contains(placeholder.Key))
                    {
                        text = text.Replace(placeholder.Key, placeholder.Value);
                    }
                }

            }
            return text;
        }
    }
}
