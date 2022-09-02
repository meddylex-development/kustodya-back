using Kustodya.ApplicationCore.Interfaces.Configuracion.Email;
using Kustodya.Shared.Wrappers;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
/using Kustodya.BusinessLogic.Services.Configuracion.Email;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.Medicos.Services
{
    public class EmailService : IEmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public bool SendEmail(SendgridEmailWrapper sendgridWrapper) => throw new System.NotImplementedException();
        public Task<bool> SendEmailAsync(string email, string template, Dictionary<string, string> templateData)
        {
            return Task.Run(() => true);
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
            return true;
        }
    }
}