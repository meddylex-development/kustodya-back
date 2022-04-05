using Kustodya.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Incapacidades.Modelos
{
    public class DiagnosticosIncapacidadesOutputModel
    {
        public IReadOnlyList<DiagnosticoIncapacidadOutputModel> diagnosticoIncapacidadOutputModels { get; set; }
        public PaginacionModel paginacion { get; set; }
    }
}
