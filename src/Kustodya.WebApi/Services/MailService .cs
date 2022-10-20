using Kustodya.ApplicationCore.Interfaces;
using Kustodya.WebApi.Models.K2Conceptos;
using System.Threading.Tasks;
using MimeKit;
using System.IO;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;
using QRCoder;
using System.Drawing;
using System;
using System.Drawing.Imaging;
using System.Net;

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
            using (StreamReader reader = new StreamReader("./assets/concepto-rehabilitacion/plantilla-correo-01.html"))
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

            var qrcode = generateQRCode("Test");
            // body = body.Replace("{QR_CODE}", qrcode);

            string bodyHtml = body.Trim();
            bodyHtml = bodyHtml.Replace("{QR_CODE}", qrcode);

            return bodyHtml;
        }

        public string generateQRCode(string text)
        {

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData _qrCodeData = qrGenerator.CreateQrCode("http://www.kustodya.com.co", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            MemoryStream memoryStream = new MemoryStream();
            qrCodeImage.Save(memoryStream, ImageFormat.Png);

            //// converting to base64
            //memoryStream.Position = 0;
            //byte[] byteBuffer = memoryStream.ToArray();

            //memoryStream.Close();

            //string base64String = Convert.ToBase64String(byteBuffer);
            //byteBuffer = null;

            // QRCode Base64 inicial
            // QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("http://www.kustodya.com.co/#/validar-concepto/123456789", QRCodeGenerator.ECCLevel.Q);
            //Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            //string qrCodeImageAsBase64 = qrCode.GetGraphic(20);

            //...
            var imgType = Base64QRCode.ImageType.Jpeg;
            Base64QRCode qrCodeBase64 = new Base64QRCode(qrCodeData);
            string qrCodeImageAsBase64 = qrCodeBase64.GetGraphic(20, Color.Black, Color.White, true, imgType);
            var contentImgTag = $"data:image/{imgType.ToString().ToLower()};base64,{qrCodeImageAsBase64}";
            var htmlPictureTag = $"<img alt=\"Embedded QR Code\" src=\"data:image/{imgType.ToString().ToLower()};base64,{qrCodeImageAsBase64}\" width=\"150px\" />";
            memoryStream.Close();
            return htmlPictureTag;
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
            var qrcode = generateQRCode("Test");
            body = body.Replace("{QR_CODE}", qrcode);
            return body;
        }

        public async void UploadFileFtp(string file)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("win5135.site4now.net/Kustodya/assets/img");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("meddylex-001", "Meddylex123");

            // Copy the contents of the file to the request stream.
            using (FileStream fileStream = File.Open("testfile.txt", FileMode.Open, FileAccess.Read))
            {
                using (Stream requestStream = request.GetRequestStream())
                {
                    await fileStream.CopyToAsync(requestStream);
                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
                    }
                }
            }
        }
    }
}
