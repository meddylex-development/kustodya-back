using Microsoft.Extensions.Options;
using Kustodya.WebApi.Settings;
using Kustodya.ApplicationCore.Interfaces;
using System.Net.Mail;
using Kustodya.WebApi.Models.K2Conceptos;
using System.Threading.Tasks;
using MimeKit;
using System.Net.Mime;
using System.IO;

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

        /*
        public async Task SendEmail(MailRequest mailRequest)
        {

            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
            var builder = new BodyBuilder();
            m.From = new MailAddress(_mailSettings.Mail);
            m.To.Add(mailRequest.ToEmail);

            m.Subject = "Notificacion Concepto de Rehabilitacion nombre y cedula";

            builder.HtmlBody = CreateBody(mailRequest);
            m.Body = builder.HtmlBody;

            var ArchivoPDF = _converttoPdfService.ConvertHtmltoPDF(builder.HtmlBody, "Concepto.pdf");
            Stream stream = new MemoryStream(ArchivoPDF);
            Attachment data = new Attachment(stream, "Concepto.pdf", MediaTypeNames.Application.Pdf);
            m.Attachments.Add(data);

            sc.Host = _mailSettings.Host;
            sc.Port = _mailSettings.Port;
            sc.Credentials = new System.Net.NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            sc.EnableSsl = false;
            sc.Send(m);
        }
        */

        public async Task SendEmailConcepto(MailRequest mr)
        {

            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
            var builder = new BodyBuilder();
            m.From = new MailAddress(_mailSettings.Mail);
            m.To.Add(mr.email);

            m.Subject = "Notificacion Concepto de Rehabilitacion " + mr.nombrePaciente;

            builder.HtmlBody = CreateBody(mr);
            m.Body = builder.HtmlBody;

            //var ArchivoPDF = _converttoPdfService.ConvertHtmltoPDF(builder.HtmlBody, "Concepto.pdf");
            //Stream stream = new MemoryStream(ArchivoPDF);
            //Attachment data = new Attachment(stream, "Concepto.pdf", MediaTypeNames.Application.Pdf);
            //m.Attachments.Add(data);

            sc.Host = _mailSettings.Host;
            sc.Port = _mailSettings.Port;
            sc.Credentials = new System.Net.NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            sc.EnableSsl = false;
            sc.Send(m);
        }

        private string CreateBody(MailRequest mr)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("./assets/EmailConceptoAFP.html"))
            {
                body = reader.ReadToEnd();
            }
            body.Replace("{{##CODIGO##}}", mr.codigo);
            body.Replace("{{##NOMBRE_PACIENTE##}}", mr.nombrePaciente);
            body.Replace("{{##TIPO_DOCUMENTO##}}", mr.tipoDocumento);
            body.Replace("{{##NUMERO_DOCUMENTO##}}", mr.numeroDocumento);
            body.Replace("{{##NOMBRE_AFP##}}", mr.nombreAFP);
            body.Replace("{{##NOMBRE_EPS##}}", mr.nombreEPS);
            body.Replace("{{##PRONOSTICO##}}", mr.pronostico);
            body.Replace("{{##CON_INCAPACIDADES##}}", mr.conIncapacidades);
            return body;
        }
    }
}
