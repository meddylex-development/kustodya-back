using Kustodya.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Entidades.Modelos
{
    public class EntidadesOutputModel
    {
        public IReadOnlyList<EntidadOutputModel> entidadesOutputModel { get; set; }
        public PaginacionModel paginacion { get; set; }
    }
}
