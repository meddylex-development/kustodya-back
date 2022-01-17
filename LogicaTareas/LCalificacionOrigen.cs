using DatosTareas;
using EAGetMail;
using EntidadesTareas;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using NucleoTareas;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransversalesTareas;

namespace LogicaTareas
{
    public class LCalificacionOrigen
    {
        private static readonly Lazy<LCalificacionOrigen> m_instance = new Lazy<LCalificacionOrigen>(() => new LCalificacionOrigen());
        private void New() { }
        public static LCalificacionOrigen Instance
        {
            get { return m_instance.Value; }
        }
        public void ProcesarCorreosCalificacionOrigen()
        {
            var client = new ImapClient();
            client.CheckCertificateRevocation = false;
            var credentials = new NetworkCredential("calificacionorigen@hotmail.com", "v6dNV9gC2YVgqWHk");
            //var uri = new Uri("imaps://imap.gmail.com");
            var uri = new Uri("imaps://imap-mail.outlook.com");
            var cancel = new CancellationTokenSource();
            //client.Connect("pop3.live.com", 995);
            client.Connect(uri, cancel.Token);
            //client.ServerCertificateValidationCallback = (s, c, h, e1) => true;
            client.Authenticate(credentials, cancel.Token);
            var personal = client.GetFolder(client.PersonalNamespaces[0]);
            var sent = client.GetFolder("inbox");
            sent.Open(FolderAccess.ReadOnly, cancel.Token);
            var query = SearchQuery.DeliveredAfter(DateTime.Now.Date.AddDays(-5));
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
                    using (var stream = File.Create(AppContext.BaseDirectory + "fileName"))
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
            //await GuardarCorreosConsoleApp(correos);
        }
        public void kustodyaco() {
            var client = new ImapClient();
            client.CheckCertificateRevocation = false;
            var credentials = new NetworkCredential("calificacionorigen@kustodya.co", "Meddylex123.");
            var cancel = new CancellationTokenSource();
            client.Connect("mail5016.site4now.net", 993, true, cancel.Token);
            client.Authenticate(credentials, cancel.Token);
            var sent = client.GetFolder("inbox");
            sent.Open(FolderAccess.ReadOnly, cancel.Token);
            var query = SearchQuery.DeliveredAfter(DateTime.Now.Date.AddDays(-5));
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
                    using (var stream = File.Create(AppContext.BaseDirectory + "fileName"))
                    {
                        if (attachment is MessagePart)
                        {
                            var part = (MessagePart)attachment;
                            part.Message.WriteTo(stream);
                            var memoryStream = new MemoryStream();
                            stream.Position = 0;
                            stream.CopyTo(memoryStream);
                            memoryStream.Position = 0;
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
                            LectorCorreosAdjunto lectorCorreosAdjunto = new LectorCorreosAdjunto();
                            lectorCorreosAdjunto.NombreArchivo = part.FileName;
                            lectorCorreosAdjunto.Contenido = memoryStream;
                            lectorCorreosModel.Adjuntos.Add(lectorCorreosAdjunto);
                        }
                    }
                }
                correos.Add(lectorCorreosModel);
            }
            GuardarCorreos(correos);
            /*MailServer oServer = new MailServer("mail5016.site4now.net", "calificacionorigen@kustodya.co", "Meddylex123.", ServerProtocol.Imap4);
            MailClient oClient = new MailClient("TryIt");

            oServer.SSLConnection = true;
            oServer.Port = 993;

            //oServer.SSLConnection = false;
            //oServer.Port = 143;

            oClient.Connect(oServer);
            MailInfo[] infos = oClient.GetMailInfos().ToArray();
            
            for (int i = 0 ; i <= infos.Length - 1; i++)
            {
                MailInfo info = infos[i];
                Mail oMail = oClient.GetMail(info);
                string mailUid = infos[i].UIDL;
                string mailFrom = oMail.From.ToString();
                string mailTo = oMail.To.ToString();
                string mailCc = oMail.Cc.ToString();
                string mailSubject = oMail.Subject;
                DateTime mailDate = oMail.ReceivedDate;
                string mailMessageId = oMail.MAPIConversationId.ToString();
                var body = oMail.TextBody;

                var count = oMail.Attachments.ToList().Count;
                for (int j = 0; j < count; j++)
                {
                    oMail.Attachments[j].SaveAs(AppContext.BaseDirectory + "fileName", true); // true for overWrite file
                }
            }*/
        }
        public void GuardarCorreos(List<LectorCorreosModel> correosModel)
        {
            IUnitOfWork unitOfWork = FabricaIoC.Contenedor.Resolver<UnitOfWork>();
            PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo("win5135.site4now.net", 21, "calificacionorigen", "Meddylex123");
            var fechaDesde = DateTime.Now.AddDays(-10);
            var correos = unitOfWork.CorreosRepository.All().Where(c => c.Fecha > fechaDesde).Select(c => c.MessageId).ToList();
            foreach (LectorCorreosModel item in correosModel.ToList())
            {
                if (correos.Contains(item.MensajeId))
                    correosModel.Remove(item);
            }
            foreach (LectorCorreosModel item in correosModel)
            {
                Correos correo = new Correos
                {
                    MessageId = item.MensajeId,
                    De = item.De,
                    Para = item.Para,
                    CC = item.CC,
                    Asunto = item.Asunto,
                    Cuerpo = item.Cuerpo,
                    Fecha = item.Fecha,
                    Estado = 1
                };
                unitOfWork.CorreosRepository.Create(correo);
                unitOfWork.CorreosRepository.SaveChanges();
                List<CorreoAdjuntos> adjuntos = new List<CorreoAdjuntos>();
                foreach (LectorCorreosAdjunto itemadjunto in item.Adjuntos)
                {
                    var blockName = Guid.NewGuid();
                    SubirArchivo(itemadjunto.Contenido, blockName.ToString() + "_" + itemadjunto.NombreArchivo);

                    CorreoAdjuntos adjunto = new CorreoAdjuntos
                    {
                        NombreArchivo = itemadjunto.NombreArchivo,
                        Contenido = blockName.ToString() + "_" + itemadjunto.NombreArchivo,
                        CorreoId = correo.Id
                    };
                    unitOfWork.CorreoAdjuntosRepository.Create(adjunto);
                    unitOfWork.CorreoAdjuntosRepository.SaveChanges();
                }
            }
        }
        private void SubirArchivo(MemoryStream ms, string nombreArchivo)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://win5135.site4now.net/" + nombreArchivo);
                request.Credentials = new NetworkCredential("calificacionorigen", "Meddylex123");
                request.Method = WebRequestMethods.Ftp.UploadFile;
                using (Stream ftpStream = request.GetRequestStream())
                {
                    ms.Position = 0;
                    ms.CopyTo(ftpStream);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void EjecutarOCR() {
            IUnitOfWork unitOfWork = FabricaIoC.Contenedor.Resolver<UnitOfWork>();
            var archivosPendientes = unitOfWork.CorreoAdjuntosRepository.All().Where(c => c.TextoReconocido == null).ToList();
            LOCREngineService lOCREngineService = new LOCREngineService();
            foreach (var item in archivosPendientes)
            {
                var extension = item.NombreArchivo.Split('.')[item.NombreArchivo.Split('.').Count() - 1];
                OCRExtractionMethodModel OCRModel;
                switch (extension.ToLower())
                {
                    case "docx":
                        string textoReconocido = "";
                        try
                        {
                            OCRModel = lOCREngineService.GetOCRTextByAzureBlobId(item.Contenido, OCRExtractionMethod.Word);
                            foreach (var sentence in OCRModel.Sentences)
                            {
                                textoReconocido = textoReconocido + " " + sentence;
                            }
                            textoReconocido = textoReconocido.Trim();
                            item.TextoReconocido = textoReconocido;
                            unitOfWork.CorreoAdjuntosRepository.Update(item);
                            unitOfWork.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            item.TextoReconocido = textoReconocido;
                            unitOfWork.CorreoAdjuntosRepository.Update(item);
                            unitOfWork.SaveChanges();
                        }
                        break;
                    case "jpg":
                        textoReconocido = "";
                        try
                        {
                            OCRModel = lOCREngineService.GetOCRTextByAzureBlobId(item.Contenido, OCRExtractionMethod.Tesseract);
                            foreach (var sentence in OCRModel.Sentences)
                            {
                                textoReconocido = textoReconocido + " " + sentence;
                            }
                            textoReconocido = textoReconocido.Trim();
                            item.TextoReconocido = textoReconocido;
                            unitOfWork.CorreoAdjuntosRepository.Update(item);
                            unitOfWork.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                        break;
                    case "jpeg":
                        textoReconocido = "";
                        try
                        {
                            OCRModel = lOCREngineService.GetOCRTextByAzureBlobId(item.Contenido, OCRExtractionMethod.Tesseract);
                            foreach (var sentence in OCRModel.Sentences)
                            {
                                textoReconocido = textoReconocido + " " + sentence;
                            }
                            textoReconocido = textoReconocido.Trim();
                            item.TextoReconocido = textoReconocido;
                            unitOfWork.CorreoAdjuntosRepository.Update(item);
                            unitOfWork.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                        break;
                    case "png":
                        textoReconocido = "";
                        if (item.TextoReconocido == null)
                        {
                            try
                            {
                                OCRModel = lOCREngineService.GetOCRTextByAzureBlobId(item.Contenido, OCRExtractionMethod.Tesseract);
                                foreach (var sentence in OCRModel.Sentences)
                                {
                                    textoReconocido = textoReconocido + " " + sentence;
                                }
                                textoReconocido = textoReconocido.Trim();
                                item.TextoReconocido = textoReconocido;
                                unitOfWork.CorreoAdjuntosRepository.Update(item);
                                unitOfWork.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                continue;
                            }
                        }
                        break;
                    case "gif":
                        textoReconocido = "";
                        if (item.TextoReconocido == null)
                        {
                            try
                            {
                                OCRModel = lOCREngineService.GetOCRTextByAzureBlobId(item.Contenido, OCRExtractionMethod.Tesseract);
                                foreach (var sentence in OCRModel.Sentences)
                                {
                                    textoReconocido = textoReconocido + " " + sentence;
                                }
                                textoReconocido = textoReconocido.Trim();
                                item.TextoReconocido = textoReconocido;
                                unitOfWork.CorreoAdjuntosRepository.Update(item);
                                unitOfWork.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                continue;
                            }
                        }
                        break;
                    case "pdf":
                        textoReconocido = "";
                        if (item.TextoReconocido == null)
                        {
                            try
                            {
                                OCRModel = lOCREngineService.GetOCRTextByAzureBlobId(item.Contenido, OCRExtractionMethod.iTextSharp);
                                foreach (var sentence in OCRModel.Sentences)
                                {
                                    textoReconocido = textoReconocido + " " + sentence;
                                }
                                textoReconocido = textoReconocido.Trim();
                                item.TextoReconocido = textoReconocido;
                                unitOfWork.CorreoAdjuntosRepository.Update(item);
                                unitOfWork.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                continue;
                            }
                        }
                        break;
                    default:
                        item.TextoReconocido = "";
                        unitOfWork.CorreoAdjuntosRepository.Update(item);
                        unitOfWork.SaveChanges();
                        break;

                }
            }
        }
        
    }
}
