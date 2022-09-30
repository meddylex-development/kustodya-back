using Kustodya.ApplicationCore.Interfaces;
using Kustodya.WebApi.Models.K2Conceptos;
using System.Threading.Tasks;
using MimeKit;
using System.IO;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;

namespace Kustodya.WebApi.Services
{
    public class MailService : IMailService
    {
        private readonly IConverttoPdfService _converttoPdfService;
        private readonly IConfiguration _configuration;

        public MailService(
            IConverttoPdfService converttoPdfService,
            IConfiguration configuration)
        {
            _converttoPdfService = converttoPdfService;
            _configuration = configuration;
        }

        public async Task SendEmailConcepto(MailRequest mr)
        {
            var apikey = _configuration.GetSection("SENDGRID_API_KEY").Value;
            var client = new SendGridClient(apikey);
            var from = new EmailAddress(_configuration.GetSection("EMAIL_FROM").Value, "Kustodya");
            var to = new EmailAddress(mr.email, mr.nombreAFP);
            var subject = "Notificacion Concepto de Rehabilitacion "+ mr.nombrePaciente;
            var builder = new BodyBuilder();
            builder.HtmlBody = CreateBody(mr);
            var htmlContent = builder.HtmlBody;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);
            byte[] data = _converttoPdfService.ConvertHtmltoPDF(builder.HtmlBody, "Concepto.pdf");
            if (data != null)
            {
                var file = new SendGrid.Helpers.Mail.Attachment()
                {
                    Type = "application/pdf",
                    Filename = "Concepto.pdf",
                    Content = System.Convert.ToBase64String(data),
                    Disposition = "attachment"
                };
                msg.AddAttachment(file);
            }
            var response = await client.SendEmailAsync(msg);
        }

        private string CreateBody(MailRequest mr)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("./assets/EmailConceptoAFP.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{CODIGO}", mr.codigo);
            body = body.Replace("{NOMBRE_PACIENTE}", mr.nombrePaciente);
            body = body.Replace("{TIPO_DOCUMENTO}", mr.tipoDocumento);
            body = body.Replace("{NUMERO_DOCUMENTO}", mr.numeroDocumento);
            body = body.Replace("{NOMBRE_AFP}", mr.nombreAFP);
            body = body.Replace("{NOMBRE_EPS}", mr.nombreEPS);
            body = body.Replace("{PRONOSTICO}", mr.pronostico);
            body = body.Replace("{CON_INCAPACIDADES}", mr.conIncapacidades);
            return body;
        }
    }
}
