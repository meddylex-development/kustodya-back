using System.Threading.Tasks;
using MimeKit;
using System.IO;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using Kustodya.WebApi.Models.K2Conceptos;
using Kustodya.WebApi.Settings;
using Kustodya.ApplicationCore.Interfaces;

namespace Kustodya.WebApi.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly IConverttoPdfService _converttoPdfService;
        public MailService(IOptions<MailSettings> mailSettings,
            IConverttoPdfService converttoPdfService)
        {
            _mailSettings = mailSettings.Value;
            _converttoPdfService = converttoPdfService;
        }

    public async Task SendEmail(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            var builder = new BodyBuilder();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = "Notificacion Concepto de Rehabilitacion nombre y cedula";
            builder.HtmlBody = CreateBody(mailRequest);
            
            var ArchivoPDF = _converttoPdfService.ConvertHtmltoPDF(builder.HtmlBody, "Concepto.pdf");
            
            builder.Attachments.Add("Notificacion1.pdf", ArchivoPDF);

            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        private string CreateBody(MailRequest m)
        {
            string body = string.Empty;
            //using (StreamReader reader = new StreamReader("./assets/MailConcepto.html"))
            //{
            //    body = reader.ReadToEnd();
            //}
            body = m.html;
            return body;
        }
    }
}
