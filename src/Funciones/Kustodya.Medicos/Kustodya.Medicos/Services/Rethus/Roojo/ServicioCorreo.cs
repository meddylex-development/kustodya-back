using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.BussinessLogic.Interfaces.General;
using Kustodya.Medicos.Models;
using Kustodya.Medicos.Services.AzureBlob;
using Kustodya.Medicos.Specifications;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Roojo.CalificacionOrigen;


namespace Kustodya.Medicos.Services
{
    public class ServicioCorreo :IServicioCorreo
    {
        //private readonly CalificacionOrigenContext _context;
        private readonly IAsyncRepository<Correo> _repoCorreo;
        private readonly IBlobService _blobService;
        public ServicioCorreo(
            IAsyncRepository<Correo> repoCorreo,
            IBlobService blobService
            //CalificacionOrigenContext context
            )
        {
            _repoCorreo = repoCorreo;
            _blobService = blobService;
            //_context = context;
        }
        
        [FunctionName(nameof(GuardarCorreos))]
        public async Task GuardarCorreos(List<LectorCorreosModel> correosModel){
                CalificacionOrigenContext context = new CalificacionOrigenContext();

                //Obtener existentes
                var correosI = context.Correos.AsQueryable();
                var correos = correosI.Where(c=>c.Fecha > DateTime.Now.AddDays(-4)).Select(c=>c.MessageId).ToList();

                foreach(LectorCorreosModel item in correosModel.ToList()){
                    if(correos.Contains(item.MensajeId))
                        correosModel.Remove(item);
                }

            
                foreach(LectorCorreosModel item in correosModel){
                    Correo correo = new Correo{
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
                    foreach(LectorCorreosAdjunto itemadjunto in item.Adjuntos){
                        var guid = await _blobService.UploadToBlobWithNameAsync(itemadjunto.Contenido, "calificacionorigencorreos", itemadjunto.NombreArchivo);
                        Adjunto adjunto = new Adjunto{
                            NombreArchivo = itemadjunto.NombreArchivo,
                            Contenido =  guid.ToString()
                        };
                        adjuntos.Add(adjunto);
                    }
                    correo.Adjuntos = adjuntos;
                    context.Correos.Add(correo);
                }
                context.SaveChanges();
            }

        [FunctionName(nameof(GuardarCorreosConsoleApp))]
        public void GuardarCorreosConsoleApp(List<LectorCorreosModel> correosModel)
        {
            CalificacionOrigenContext context = new CalificacionOrigenContext();
                var connParsed = CloudStorageAccount.TryParse("DefaultEndpointsProtocol=https;AccountName=meddylexdev;AccountKey=BCCE0wITHORzRXnM9dJfjB9nEF4MW50haCKHBdfn6LkTWAuGuvOSpaTy6mFJStHMBR+1lCkCtQy9GrwnSiz33g==;EndpointSuffix=core.windows.net", out CloudStorageAccount account);
                //var connParsed = CloudStorageAccount.TryParse("DefaultEndpointsProtocol=https;AccountName=meddylex;AccountKey=sZVLCLJD2yz+h2C9/08tCXDsFJWxx00LZcpJgSPay8EjVCpbgKtVhN2yJxdF8ej0SI7Ng/WttAuMO0L412iXhg==;EndpointSuffix=core.windows.net", out CloudStorageAccount account);
                CloudBlobClient client = account.CreateCloudBlobClient();
            //Obtener existentes
            var correosI = context.Correos.AsQueryable();
            var correos = correosI.Where(c => c.Fecha > DateTime.Now.AddDays(-4)).Select(c => c.MessageId).ToList();

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
                    //var guid = await _blobService.UploadToBlobAsync(itemadjunto.Contenido, "calificacionorigencorreos");
                    var blockName = Guid.NewGuid();
                    try
                    {
                        CloudBlobContainer container = client.GetContainerReference("calificacionorigencorreos");
                        container.CreateIfNotExistsAsync();
                        CloudBlockBlob block = container.GetBlockBlobReference(blockName.ToString());
                        block.UploadFromStreamAsync(itemadjunto.Contenido);
                    }
                    catch (Exception)
                    {
                        throw new ErrorUploadingStreamException();
                    }
                    Adjunto adjunto = new Adjunto
                    {
                        NombreArchivo = itemadjunto.NombreArchivo,
                        Contenido = blockName.ToString()
                    };
                    adjuntos.Add(adjunto);
                }
                correo.Adjuntos = adjuntos;
                context.Correos.Add(correo);
            }
            context.SaveChanges();
        }

        [FunctionName(nameof(ObtenerArchivosPendientes))]
        public IQueryable<Adjunto> ObtenerArchivosPendientes() {
            CalificacionOrigenContext context = new CalificacionOrigenContext();
            return context.Adjuntos.Where(c => c.TextoReconocido == null);
        }

        [FunctionName(nameof(ActualizarAdjunto))]
        public void ActualizarAdjunto(Adjunto adjunto)
        {
            CalificacionOrigenContext context = new CalificacionOrigenContext();
            var existente = context.Adjuntos.Where(c => c.Id == adjunto.Id).First();
            existente.TextoReconocido = adjunto.TextoReconocido;
            context.Adjuntos.Update(existente);
            context.SaveChanges();
        }
    }
}
