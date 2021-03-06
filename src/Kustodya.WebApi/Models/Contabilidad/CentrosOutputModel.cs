using Kustodya.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.Contabilidades
{
    public class CentrosOutputModel
    {
        public IReadOnlyList<CentroOutputModel> centroOutputModel { get; set; }
        public PaginacionModel paginacion { get; set; }
    }
}
