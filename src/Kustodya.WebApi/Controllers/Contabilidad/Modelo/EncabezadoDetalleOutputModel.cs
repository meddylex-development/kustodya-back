using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Contabilidades
.Modelo
{
    public class EncabezadoDetalleOutputModel
    {
        public int Id { get; set; }
        public long FechaElaboracion { get; set; }
        public string FichaTecnica { get; set; }
        public string DescripcionFicha { get; set; }
        public int? Folios { get; set; }
        public int? Subcuenta { get; set; }
        public int? Segmento { get; set; }
        public int TotalDebito { get; set; }
        public int TotalCredito { get; set; }
        public ClaseDocumentoOutputModel ClaseDocumento { get; set; }
        public string Estado { get; set; }
        public string situacionEncontrada { get; set; }
        public string disposicionesLegales { get; set; }
        public string accionesRealizadas { get; set; }
        public string recomendaciones { get; set; }
        public string anexos { get; set; }
        public int? ElaboradoporId { get; set; }
        public int? CoordinadorId { get; set; }
        public int? GerenteId { get; set; }
        public int? InterventorId { get; set; }
        public int UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public ICollection<DetalleOutputModel> Detalles { get; set; }
    }
}
