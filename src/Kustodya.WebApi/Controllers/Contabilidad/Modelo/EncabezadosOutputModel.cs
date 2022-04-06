using Kustodya.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Contabilidades
.Modelo
{
    public class EncabezadosOutputModel
    {
        public IReadOnlyList<EncabezadoOutputModel> encabezadosOutputModel { get; set; }
        public PaginacionModel paginacion { get; set; }
    }
}
