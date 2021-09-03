using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using Kustodya.Medicos.Services;
using Kustodya.Medicos.Models;
using Kustodya.ApplicationCore.Entities.CalificacionOrigen;
using Kustodya.ApplicationCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LecturaCorreos
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicioCorreo _servicioCorreo = new ServicioCorreo(null, null);
            var client = new ImapClient();
            var credentials = new NetworkCredential("calificacionorigen@hotmail.com", "v6dNV9gC2YVgqWHk");
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
                string mailUid = uid.ToString();
                string mailFrom = message.From.ToString();
                string mailTo = message.To.ToString();
                string mailCc = message.Cc.ToString();
                string mailSubject = message.Subject;
                DateTime mailDate = message.Date.DateTime;
                string mailMessageId = message.MessageId;
                //string body = message.BodyParts.ToString(); 
                var body = message.BodyParts.OfType<TextPart>().FirstOrDefault()?.Text;
                LectorCorreosModel lectorCorreosModel = new LectorCorreosModel
                {
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
                    using (var stream = File.Create("fileName"))
                    {
                        if (attachment is MessagePart)
                        {
                            var part = (MessagePart)attachment;
                            part.Message.WriteTo(stream);
                            var memoryStream = new MemoryStream();
                            stream.Position = 0;
                            stream.CopyTo(memoryStream);
                            memoryStream.Position = 0;
                            //var guid = await _blobService.UploadToBlobAsync(memoryStream, "calificacionorigencorreos");
                            LectorCorreosAdjunto lectorCorreosAdjunto = new LectorCorreosAdjunto();
                            lectorCorreosAdjunto.NombreArchivo = "Archivo";
                            lectorCorreosAdjunto.Contenido = memoryStream;
                            lectorCorreosModel.Adjuntos.Add(lectorCorreosAdjunto);

                        }
                        else
                        {
                            var part = (MimePart)attachment;
                            part.Content.DecodeTo(stream);
                            var memoryStream = new MemoryStream();
                            stream.Position = 0;
                            stream.CopyTo(memoryStream);
                            memoryStream.Position = 0;
                            //var guid = await _blobService.UploadToBlobAsync(memoryStream, "calificacionorigencorreos");
                            LectorCorreosAdjunto lectorCorreosAdjunto = new LectorCorreosAdjunto();
                            lectorCorreosAdjunto.NombreArchivo = part.FileName;
                            lectorCorreosAdjunto.Contenido = memoryStream;
                            lectorCorreosModel.Adjuntos.Add(lectorCorreosAdjunto);
                        }
                    }
                }
                correos.Add(lectorCorreosModel);
            }
            _servicioCorreo.GuardarCorreosConsoleApp(correos);
        }
    }
}
