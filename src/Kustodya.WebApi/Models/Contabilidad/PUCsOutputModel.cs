using Kustodya.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.Contabilidades
{
    public class PUCsOutputModel
    {
        public IReadOnlyList<PUCOutputModel> pucOutputModel { get; set; }
        public PaginacionModel paginacion { get; set; }
    }
}
