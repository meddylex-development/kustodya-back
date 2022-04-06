using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.DTOs.Rethus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.Rethus
{
    public class CarguesOutputModel
    {
        public IReadOnlyList<CargueOutputModel> cargueOutputModels { get; set; }
        public PaginacionModel paginacion { get; set; }
    }
}
