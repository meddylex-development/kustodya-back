using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Kustodya.WebApi.Models
{
    public class ArchivoModel
    {
        public IFormFile File { get; set; }
    }
}
