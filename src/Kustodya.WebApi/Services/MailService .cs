using Kustodya.ApplicationCore.Interfaces;
using Kustodya.WebApi.Models.K2Conceptos;
using System.Threading.Tasks;
using MimeKit;
using System.IO;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

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

            var templateDiagnosticoConcepto = buildFile(mr, 1);
            var templateCartaConcepto = buildFile(mr, 2);
            var templateTest = buildFile(mr, 3);


            // byte[] data = _converttoPdfService.ConvertHtmltoPDF(templateDiagnosticoConcepto, "Diagnostico-concepto-rehabilitacion-" + mr.codigo + ".pdf");
            // byte[] data = _converttoPdfService.ConvertHtmltoPDF(templateCartaConcepto, "Carta-concepto-rehabilitacion-" + mr.codigo + ".pdf");
            byte[] data = _converttoPdfService.ConvertHtmltoPDF(templateTest, "Carta-concepto-rehabilitacion-" + mr.codigo + ".pdf");
            if (data != null)
            {
                var file = new SendGrid.Helpers.Mail.Attachment()
                {
                    Type = "application/pdf",
                    Filename = "Carta-concepto-rehabilitacion-" + mr.codigo + ".pdf",
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
            // using (StreamReader reader = new StreamReader("./assets/EmailConceptoAFP.html"))
            using (StreamReader reader = new StreamReader("./assets/concepto-rehabilitacion/correo-concepto-rehabilitacion.html"))
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


        private string buildFile(MailRequest mr, int typeTemplate)
        {
            string body = string.Empty;
            var template = "";
            switch (typeTemplate) {
                case 1:
                    // Template concepto de rehabilitacion
                    template = "./assets/concepto-rehabilitacion/Concepto-rehabilitacion.html";
                    break;
                case 2:
                    // Template carta concepto de rehabilitacion
                    template = "./assets/concepto-rehabilitacion/carta-concepto-rehabilitacion-1.html";
                    break;
                case 3:
                    // Template carta concepto de rehabilitacion
                    template = "./assets/concepto-rehabilitacion/test.html";
                    break;
            }


            // using (StreamReader reader = new StreamReader("./assets/EmailConceptoAFP.html"))
            using (StreamReader reader = new StreamReader(template))
            {
                body = reader.ReadToEnd();
            }
            //body = body.Replace("{CODIGO}", mr.codigo);
            //body = body.Replace("{NOMBRE_PACIENTE}", mr.nombrePaciente);
            //body = body.Replace("{TIPO_DOCUMENTO}", mr.tipoDocumento);
            //body = body.Replace("{NUMERO_DOCUMENTO}", mr.numeroDocumento);
            //body = body.Replace("{NOMBRE_AFP}", mr.nombreAFP);
            //body = body.Replace("{NOMBRE_EPS}", mr.nombreEPS);
            //body = body.Replace("{PRONOSTICO}", mr.pronostico);
            //body = body.Replace("{CON_INCAPACIDADES}", mr.conIncapacidades);
            return body;
        }
    }
}
