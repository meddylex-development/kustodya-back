using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Dtos.Incapacidades;

namespace Kustodya.WebApi.Models.Rehabilitaciones
{
    public class DiagnosticoChrbModel
    {
        public CIE10Model Diagnostico { get; set; }
        public DateTime FechaCreacion { get; set; }
        public byte EtiologiaId { get; set; }
    }
}
