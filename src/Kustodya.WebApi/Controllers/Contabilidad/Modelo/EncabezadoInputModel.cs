using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Contabilidades
.Modelo
{
    public class EncabezadoInputModel
    {
        public int Id { get; set; }
        public long FechaElaboracion { get; set; }
        public string FichaTecnica { get; set; }
        public string DescripcionFicha { get; set; }
        public int? FichaTecnicaAprobada { get; set; }
        public int? Folios { get; set; }
        public string situacionEncontrada { get; set; }
        public string disposicionesLegales { get; set; }
        public string accionesRealizadas { get; set; }
        public string recomendaciones { get; set; }
        public string anexos { get; set; }
        public int? ElaboradoporId { get; set; }
        public int? CoordinadorId { get; set; }
        public int? GerenteId { get; set; }
        public int? InterventorId { get; set; }
        public ClaseDocumentoOutputModel ClaseDocumento { get; set; }
        //public EstadoComprobante Estado { get; set; }
    }
}
