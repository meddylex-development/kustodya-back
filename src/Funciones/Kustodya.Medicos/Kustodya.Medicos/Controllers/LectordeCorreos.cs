using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using Ionic.Zip;
using Kustodya.Medicos.Models;
using Kustodya.Medicos.Services;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using Microsoft.Azure.WebJobs;
using MimeKit;

namespace Kustodya.Medicos.Controllers
{
    public class LectordeCorreos
    {
        private readonly IServicioCorreo _servicioCorreo;
        public LectordeCorreos(IServicioCorreo servicioCorreo)
        {
            _servicioCorreo = servicioCorreo;
        }
        
        [FunctionName(nameof(ProcesarCorreos))]
        public void ProcesarCorreos([TimerTrigger("* */10 * * * *")] TimerInfo myTimer)
        {
            //_logger.LogInformation("Inició función de procesar correos" + DateTime.Now.Date.ToShortDateString(), null);
            var client = new ImapClient();
            var credentials = new NetworkCredential("calificacionorigen@hotmail.com", "v6dNV9gC2YVgqWHk");
            //var credentials = new NetworkCredential("sandrapadillac@gmail.com", "lilapadilla1980");
            //var uri = new Uri("imaps://imap.gmail.com");
            var uri = new Uri("imaps://imap-mail.outlook.com");
            var cancel = new CancellationTokenSource();
            client.Connect(uri, cancel.Token);
            client.ServerCertificateValidationCallback = (s, c, h, e1) => true;
            client.Authenticate(credentials, cancel.Token);
            var personal = client.GetFolder(client.PersonalNamespaces[0]);
            var sent = client.GetFolder("inbox");
            sent.Open(FolderAccess.ReadOnly, cancel.Token);
            var query = SearchQuery.DeliveredAfter(DateTime.Now.Date.AddDays(-1));
            List<LectorCorreosModel> correos = new List<LectorCorreosModel>();
            foreach (var uid in sent.Search(query, cancel.Token))
            {
                var message = sent.GetMessage(uid, cancel.Token);
                /*if (!message.From.ToString().Contains("asanchez@fundaciongruposocial.co") && !message.From.ToString().Contains("lagonzalez@fundaciongruposocial.co") 
                    && !message.Subject.ToLower().Contains("caso covid"))
                    continue;*/
                string mailUid = uid.ToString();
                string mailFrom = message.From.ToString();
                string mailTo = message.To.ToString();
                string mailCc = message.Cc.ToString();
                string mailSubject = message.Subject;
                DateTime mailDate = message.Date.DateTime;
                string mailMessageId = message.MessageId;
                //string body = message.BodyParts.ToString(); 
                var body = message.BodyParts.OfType<TextPart>().FirstOrDefault ()?.Text;
                LectorCorreosModel lectorCorreosModel = new LectorCorreosModel{
                    MensajeId = mailUid,
                    De = mailFrom,
                    Para = mailTo,
                    CC = mailCc,
                    Asunto = mailSubject,
                    Cuerpo = body,
                    Fecha = mailDate,
                    Id = mailMessageId,
                };
                lectorCorreosModel.Adjuntos = new List<LectorCorreosAdjunto>();
                foreach (var attachment in message.Attachments)
                {
                    if (attachment is MessagePart)
                    {
                        var part = (MessagePart)attachment;
                        MemoryStream ms = new MemoryStream();
                        part.Message.WriteTo(ms);
                        ms.Position = 0;

                        LectorCorreosAdjunto lectorCorreosAdjunto = new LectorCorreosAdjunto();
                        lectorCorreosAdjunto.NombreArchivo = "Archivo";
                        lectorCorreosAdjunto.Contenido = ms;
                        lectorCorreosModel.Adjuntos.Add(lectorCorreosAdjunto);
                    }
                    else {
                        var ms = new MemoryStream();
                        var part = (MimePart)attachment;
                        part.Content.DecodeTo(ms);
                        ms.Position = 0;

                        //Validar si es un zip
                        if (part.FileName.EndsWith("zip"))
                        {
                            try
                            {
                                var archivos = UnZipToMemory(ms);
                                foreach (var item in archivos)
                                {
                                    LectorCorreosAdjunto lectorCorreosAdjunto = new LectorCorreosAdjunto();
                                    lectorCorreosAdjunto.NombreArchivo = item.Key;
                                    lectorCorreosAdjunto.Contenido = item.Value;
                                    lectorCorreosModel.Adjuntos.Add(lectorCorreosAdjunto);
                                }
                            }
                            catch (Exception){continue;}
                        }
                        else
                        {
                            LectorCorreosAdjunto lectorCorreosAdjunto = new LectorCorreosAdjunto();
                            lectorCorreosAdjunto.NombreArchivo = part.FileName;
                            lectorCorreosAdjunto.Contenido = ms;
                            lectorCorreosModel.Adjuntos.Add(lectorCorreosAdjunto);
                        }
                    }
                }
                correos.Add(lectorCorreosModel);
            }
            _servicioCorreo.GuardarCorreos(correos);
        }
        private static Dictionary<string, MemoryStream> UnZipToMemory(Stream LocalCatalogZip)
        {
            var result = new Dictionary<string, MemoryStream>();
            using (ZipFile zip = ZipFile.Read(LocalCatalogZip))
            {
                foreach (ZipEntry e in zip)
                {
                    MemoryStream data = new MemoryStream();
                    e.Extract(data);
                    data.Position = 0;
                    result.Add(e.FileName, data);
                }
            }

            return result;
        }
    }
}