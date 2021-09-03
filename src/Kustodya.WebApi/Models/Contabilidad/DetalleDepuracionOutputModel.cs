using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.Contabilidades
{
    public class DetalleDepuracionOutputModel
    {
        public long FechaElaboracion { get; set; }
        public string FichaTecnica { get; set; }    
        public string DescripcionFicha { get; set; }
        public string FichaTecnicaAprobada { get; set; }
        public int Subcuenta { get; set; }
        public Guid? SegmentoId { get; set; }
        public string Segmento { get; set; }
        public int Folios { get; set; }
        public string SituacionEncontrada { get; set; }
        public string DisposicionesLegales { get; set; }
        public string AccionesRealizadas { get; set; }
        public string Recomendaciones { get; set; }
        public string Anexos { get; set; }
        public string Elaboradopor { get; set; }
        public string Coordinador { get; set; }
        public string Gerente { get; set; }
        public string Interventor { get; set; }
        public string Estado { get; set; }
        public string ContabilidadId { get; set; }
        public string CodigoContabilidad { get; set; }
        public bool Eliminado { get; set; }
        public string ClaseDocumentoId { get; set; }
        public string ClaseDocumento { get; set; }
        public int TotalDebito { get; set; }
        public int TotalCredito { get; set; }
        public ICollection<MovimientoOutputModel> MovimientoOutputModel { get; set; }
    }
}
