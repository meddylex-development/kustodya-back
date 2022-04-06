using Kustodya.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Incapacidades.Modelos
{
    public class PacientesOutputModel
    {
        public IReadOnlyList<PacienteOutputModel> listaPacientes { get; set; }
        public PaginacionModel paginacion { get; set; }
    }
}
