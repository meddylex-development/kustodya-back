using Kustodya.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.CalificacionOrigen.Modelos
{
    public class CorreosOutputModel
    {
        public IReadOnlyList<CorreoOutputModel> correoOutputModel { get; set; }
        public PaginacionModel paginacion { get; set; }
    }
}
