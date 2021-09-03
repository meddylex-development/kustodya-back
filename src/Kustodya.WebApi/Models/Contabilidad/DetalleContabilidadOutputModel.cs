using Kustodya.ApplicationCore.Entities.Contabilidades;

namespace Kustodya.WebApi.Models.Contabilidades
{
    public class DetalleContabilidadOutputModel
    {
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public bool EsContabilidadPorDefecto { get; set; }
        public string CodigoPucDebitoMovimientoPorDefecto { get; set; }
        public string CodigoPucCreditoMovimientoPorDefecto { get; set; }
        public string DescripcionMovimientoPorDefecto { get; set; }
        public string ReferenciaMovimientoPorDefecto { get; set; }
        public Puc.TiposContabilidad TipoContabilidad { get; internal set; }
    }
}