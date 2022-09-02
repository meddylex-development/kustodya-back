using Kustodya.Shared.Wrappers;
using RestSharp;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Email;
using System.Net;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kustodya.BusinessLogic.Services.Configuracion.Email
{
    public class EmailService : IEmailService
    {
        private IConfiguration _configuration { get; set; }
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool SendEmail(SendgridEmailWrapper sendgridWrapper)
        {
            var client = new RestClient("https://api.sendgrid.com/");

            var request = new RestRequest("v3/mail/send");
            request.AddHeader("authorization", "Bearer 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");

            request.AddJsonBody(sendgridWrapper);
            request.RequestFormat = DataFormat.Json;
            request.Method = Method.POST;
            // execute the request
            var response = client.Post(request);
            var content = response.Content; // raw content as string

            return true;
        }

        public async Task<bool> SendEmailAsync(string email, string template, Dictionary<string,string> templateData)
        {
            var emailConfig = _configuration.GetSection("Email");
            string apiKey = emailConfig.GetValue<string>("SendGridApiKey");
            string recoveryUrl = emailConfig.GetValue<string>("RecoveryUrl");

            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("no-reply@kustodya.com", "Kustodya");

            var msg = MailHelper.CreateSingleTemplateEmail(
                from,
                new EmailAddress(email),
                template,
                templateData);

            var response = await client.SendEmailAsync(msg);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<bool> SendEmailListAsync(IReadOnlyList<string> emails, string template, Dictionary<string, string> templateData)
        {
            var emailConfig = _configuration.GetSection("Email");
            string apiKey = emailConfig.GetValue<string>("SendGridApiKey");
            string recoveryUrl = emailConfig.GetValue<string>("RecoveryUrl");

            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("no-reply@kustodya.com", "Kustodya");


            var msg = MailHelper.CreateSingleTemplateEmailToMultipleRecipients(
                from,
                emails.Select(e => new EmailAddress(e)).ToList(),
                template,
                templateData);

            var response = await client.SendEmailAsync(msg);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public static SendGridMessage BuildMessage(List<EmailAddress> Recipients)
        {
            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("dx@example.com", "SendGrid DX Team"));
            msg.AddTos(Recipients);
            msg.SetSubject("Testing the SendGrid C# Library");
            const string Text = "Hello World plain text!";
            msg.AddContent(MimeType.Text, Text);
            msg.AddContent(MimeType.Html, "<p>Hello World!</p>");

            return msg;
        }

        //Envia correo concepto
        public async Task SendEmailConcepto(string email, string subject, string htmlContent)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("meddylex.development@gmail.com", "Kustodya");
            var to = new EmailAddress(email);
            var plainTextContent = Regex.Replace(htmlContent, "<[^>]*>", "");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}