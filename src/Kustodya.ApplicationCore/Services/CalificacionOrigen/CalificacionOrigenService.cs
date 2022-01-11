using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.CalificacionOrigen;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.CalificacionOrigen;
using Kustodya.ApplicationCore.Specifications.CalificacionOrigen;
using Kustodya.BussinessLogic.Interfaces.General;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MailKit.Net.Imap;
using System.Threading;
using MailKit;
using MailKit.Search;
using System.Net;
using MimeKit;
using Renci.SshNet;

namespace Kustodya.ApplicationCore.Services.CalificacionOrigen
{
    public class CalificacionOrigenService : ICalificacionOrigenService
    {
        IAsyncRepository<Correo> _correoRepo;
        IAsyncRepository<Adjunto> _correoAdjunto;
        IAsyncRepository<Carta> _cartaAdjunto;
        IAsyncRepository<TblDivipola> _divipolaRepo;
        IAsyncRepository<Empresa> _empresaRepo;
        public CalificacionOrigenService(IAsyncRepository<Correo> correoRepo,
            IAsyncRepository<Adjunto> correoAdjunto, IAsyncRepository<Carta> cartaAdjunto,
            IAsyncRepository<TblDivipola> divipolaRepo, IAsyncRepository<Empresa> empresaRepo)
        {
            _correoRepo = correoRepo;
            _correoAdjunto = correoAdjunto;
            _cartaAdjunto = cartaAdjunto;
            _divipolaRepo = divipolaRepo;
            _empresaRepo = empresaRepo;
        }
        public async Task<IReadOnlyList<Correo>> ObtenerCorreos(Correo.EstadoCorreo estadoCorreo, string busqueda, long fechaDesde, long fechaHasta, int? pagina, int? tamanoPagina)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime dtFechaDesde = epoch.AddMilliseconds(fechaDesde);
            dtFechaDesde = new DateTime(dtFechaDesde.Year, dtFechaDesde.Month, dtFechaDesde.Day);
            DateTime dtFechaHasta = epoch.AddMilliseconds(fechaHasta);
            dtFechaHasta = new DateTime(dtFechaHasta.Year, dtFechaHasta.Month, dtFechaHasta.Day);
            dtFechaHasta = dtFechaHasta.AddDays(1);
            var spec = new CalificacionOrigenCorreosSpec(estadoCorreo, busqueda, dtFechaDesde, dtFechaHasta, (pagina - 1) * tamanoPagina, tamanoPagina);
            var correos = await _correoRepo.ListAsync(spec);
            return correos;

        }
        public async Task<string> ObtenerNombreArchivo(string guid)
        {
            var spec = new CalificacionOrigenAdjuntoSpec(guid);
            var adjunto = await _correoAdjunto.GetOneAsync(spec);
            return adjunto.NombreArchivo;
        }
        public async Task<Correo> ObtenerCorreo(int id)
        {
            var spec = new CalificacionCorreoDetalleporIdSpec(id);
            return await _correoRepo.GetOneAsync(spec);
        }
        public async Task<Carta> ObtenerModeloCarta()
        {
            return await _cartaAdjunto.GetByIdAsync(1);
        }
        public async Task GuardarCarta(string cartaTranscripcion, string formatoWebArl, int correoId)
        {
            var correo = await _correoRepo.GetByIdAsync(correoId);
            correo.CartaTranscripcion = cartaTranscripcion;
            correo.FormatoWebArl = formatoWebArl;
            correo.Estado = Correo.EstadoCorreo.Transcrito;
            correo.FechaTranscripcion = DateTime.Now;
            await _correoRepo.UpdateAsync(correo);
        }
        public async Task ActualizarAdjunto(Adjunto adjunto)
        {
            await _correoAdjunto.UpdateAsync(adjunto);
        }
        public async Task<IReadOnlyList<TblDivipola>> ObtenerDivipolas()
        {
            return await _divipolaRepo.ListAllAsync();
        }
        public async Task<byte[]> ObtenerDocumento(MemoryStream stream, Dictionary<string,string> variables, MemoryStream firmaStream)
        {
            firmaStream.Position = 0;
            stream.Position = 0;
            Carta carta = await _cartaAdjunto.GetByIdAsync(1);
            string valor = "";
            variables.TryGetValue("afp", out valor);
            carta.TextoTranscripcion = carta.TextoTranscripcion.Replace("{{afp}}", valor);
            variables.TryGetValue("cargo", out valor);
            carta.TextoTranscripcion = carta.TextoTranscripcion.Replace("{{cargo}}", valor);
            variables.TryGetValue("ciudad", out valor);
            carta.TextoTranscripcion = carta.TextoTranscripcion.Replace("{{ciudad}}", valor);
            variables.TryGetValue("contrato", out valor);
            carta.TextoTranscripcion = carta.TextoTranscripcion.Replace("{{contrato}}", valor);
            variables.TryGetValue("edad", out valor);
            carta.TextoTranscripcion = carta.TextoTranscripcion.Replace("{{edad}}", valor);
            variables.TryGetValue("empresa", out valor);
            carta.TextoTranscripcion = carta.TextoTranscripcion.Replace("{{empresa}}", valor);
            variables.TryGetValue("empresacorreo", out valor);
            carta.TextoTranscripcion = carta.TextoTranscripcion.Replace("{{empresacorreo}}", valor);
            variables.TryGetValue("enfermedadlaboral", out valor);
            carta.TextoTranscripcion = carta.TextoTranscripcion.Replace("{{enfermedadlaboral}}", valor);
            variables.TryGetValue("eps", out valor);
            carta.TextoTranscripcion = carta.TextoTranscripcion.Replace("{{eps}}", valor);
            variables.TryGetValue("fecha", out valor);
            carta.TextoTranscripcion = carta.TextoTranscripcion.Replace("{{fecha}}", valor);
            variables.TryGetValue("fechacovid", out valor);
            carta.TextoTranscripcion = carta.TextoTranscripcion.Replace("{{fechacovid}}", valor);
            variables.TryGetValue("identificacion", out valor);
            carta.TextoTranscripcion = carta.TextoTranscripcion.Replace("{{identificacion}}", valor);
            variables.TryGetValue("nombre", out valor);
            carta.TextoTranscripcion = carta.TextoTranscripcion.Replace("{{nombre}}", valor);
            variables.TryGetValue("telefono", out valor);
            carta.TextoTranscripcion = carta.TextoTranscripcion.Replace("{{telefono}}", valor);
            variables.TryGetValue("correoPaciente", out valor);
            carta.TextoTranscripcion = carta.TextoTranscripcion.Replace("{{correoPaciente}}", valor);

            carta.TextoTranscripcion = carta.TextoTranscripcion.Replace("ú", "&uacute;").Replace("á", "&aacute;").Replace("é", "&eacute;").Replace("í", "&iacute;").Replace("ó", "&oacute;").Replace("ñ", "&ntilde;");
            carta.TextoTranscripcion = carta.TextoTranscripcion.Replace("Ú", "&Uacute;").Replace("Á", "&Aacute;").Replace("É", "&Eacute;").Replace("Í", "&Iacute;").Replace("Ó", "&Oacute;").Replace("Ñ", "&Ntilde;");

            stream = AgregarTexto(stream, carta.TextoTranscripcion.Split("{{firma}}")[0] + "</body></html>", "myId1", true);
            stream = AgregarImagen(stream, firmaStream);
            stream = AgregarTexto(stream, "<html><head><style>.textosimple{font-family: 'Gill Sans MT'; font-size: 14.5}</style></head><body>" + carta.TextoTranscripcion.Split("{{firma}}")[1], "myId2", false);
            return stream.ToArray();
        }
        public async Task ActualizarCorreo(Correo correo) {
            await _correoRepo.UpdateAsync(correo);
        }
        public async Task ProcesarCorreosCalificacionOrigen() {
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
            var query = SearchQuery.DeliveredAfter(DateTime.Now.Date.AddDays(-5));
            List<LectorCorreosModel> correos = new List<LectorCorreosModel>();
            foreach (var uid in sent.Search(query, cancel.Token)) {
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
            await GuardarCorreosConsoleApp(correos);
        }
        public async Task<Dictionary<string, string>> ObtenerEmpresaDatos(string nombreEmpresa) {
            var spec = new CalificacionOrigenEmpresaPorNombre(nombreEmpresa);
            var empresa = await _empresaRepo.GetOneAsync(spec);
            Dictionary<string, string> datosEmpresa = new Dictionary<string, string>();
            if (empresa != null) { 
                datosEmpresa.Add("contrato", empresa.Contrato);
                datosEmpresa.Add("correo", empresa.Correo);
            }
            return datosEmpresa;
        }
        public async Task GuardarCorreosConsoleApp(List<LectorCorreosModel> correosModel)
        {
            PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo("win5135.site4now.net", 21, "calificacionorigen", "Meddylex123");
            var correosI = await _correoRepo.ListAllAsync();
            var correos = correosI.Where(c => c.Fecha > DateTime.Now.AddDays(-10)).Select(c => c.MessageId).ToList();
            foreach (LectorCorreosModel item in correosModel.ToList())
            {
                if (correos.Contains(item.MensajeId))
                    correosModel.Remove(item);
            }
            foreach (LectorCorreosModel item in correosModel)
            {
                Correo correo = new Correo
                {
                    MessageId = item.MensajeId,
                    De = item.De,
                    Para = item.Para,
                    CC = item.CC,
                    Asunto = item.Asunto,
                    Cuerpo = item.Cuerpo,
                    Fecha = item.Fecha,
                    Estado = Correo.EstadoCorreo.Por_Gestionar
                };
                List<Adjunto> adjuntos = new List<Adjunto>();
                foreach (LectorCorreosAdjunto itemadjunto in item.Adjuntos)
                {
                    var blockName = Guid.NewGuid();
                    SubirArchivo(itemadjunto.Contenido, blockName.ToString() + "_" + itemadjunto.NombreArchivo);
                    try
                    {
                        //Uploadfiles(connectionInfo, itemadjunto.Contenido, blockName.ToString());
                        /*CloudBlobContainer container = client.GetContainerReference("calificacionorigencorreos");
                        container.CreateIfNotExistsAsync();
                        CloudBlockBlob block = container.GetBlockBlobReference(blockName.ToString());
                        block.UploadFromStreamAsync(itemadjunto.Contenido);*/
                    }
                    catch (Exception)
                    {
                        /*throw new ErrorUploadingStreamException();*/
                    }
                    Adjunto adjunto = new Adjunto
                    {
                        NombreArchivo = itemadjunto.NombreArchivo,
                        Contenido = blockName.ToString() + "_" + itemadjunto.NombreArchivo
                    };
                    adjuntos.Add(adjunto);
                }
                correo.Adjuntos = adjuntos;
                await _correoRepo.AddAsync(correo);
            }
        }
        static MemoryStream AgregarTexto(MemoryStream stream, string texto, string altChunkId, bool primero) {
            stream.Position = 0;
            using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, true))
            {
                // Insert a new paragraph at the beginning of the
                //document.
                MainDocumentPart mainDocPart = doc.MainDocumentPart;
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(texto));
                AlternativeFormatImportPart formatImportPart = mainDocPart.AddAlternativeFormatImportPart(
                    AlternativeFormatImportPartType.Html, altChunkId);
                formatImportPart.FeedData(ms);
                AltChunk altChunk = new AltChunk();
                altChunk.Id = altChunkId;
                mainDocPart.Document.Body.Append(altChunk);
            }
            return stream;
        }
        static MemoryStream AgregarImagen(MemoryStream stream, MemoryStream firmaStream)
        {
            MemoryStream salida = new MemoryStream();
            stream.Position = 0;
            firmaStream.Position = 0;
            Spire.Doc.Document document = new Spire.Doc.Document(stream, Spire.Doc.FileFormat.Docx);
            Spire.Doc.Section section = document.Sections[0];
            Spire.Doc.Fields.DocPicture picture = document.Sections[0].Paragraphs[8].AppendPicture(firmaStream.ToArray());

            //set image's position
            //picture.HorizontalPosition = 50.0F;
            //picture.VerticalPosition = 60.0F;

            //set image's size
            picture.Width = 100;
            picture.Height = 50;
            document.SaveToStream(salida, Spire.Doc.FileFormat.Docx);
            return salida;
        }
        private void Uploadfiles(PasswordConnectionInfo connectionInfo, MemoryStream ms, string fileName)
        {
            ms.Position = 0;
            using (var sftp = new SftpClient(connectionInfo))
            {
                try
                {
                    sftp.OperationTimeout = TimeSpan.FromMinutes(2);
                    sftp.Connect();
                    var stream = ms;
                    stream.Position = 0;
                    fileName = fileName;
                    sftp.UploadFile(stream, fileName);
                }
                catch (Exception ex) {
                    var x = ex;
                }
                finally
                {
                    sftp.Disconnect();
                }
            }
        }
        private void ListarDirectorio() {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://win5135.site4now.net");
            try
            {
                request = (FtpWebRequest)WebRequest.Create("ftp://win5135.site4now.net");
                request.Method = WebRequestMethods.Ftp.ListDirectory;

                request.Credentials = new NetworkCredential("calificacionorigen", "Meddylex123");
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                //nombreArchivos = names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception ex)
            {
                throw;
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
    }
}
