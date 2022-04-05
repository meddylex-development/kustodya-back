using Kustodya.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.Contabilidades
{
    public class DepuracionesOutputModel
    {
        public IReadOnlyList<DepuracionOutputModel> depuracionOutputModel { get; set; }
        public PaginacionModel paginacion { get; set; }
        public bool aprobador { get; set; }
    }
}
