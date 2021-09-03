using Kustodya.ApplicationCore.Constants;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Kustodya.WebApi.Models.General
{
    public class FileUpload
    {
        public IFormFile File { get; set; }
        public string DocumentoId { get; set; }
        public int TipoArchivoId { get; set; }
    }
}