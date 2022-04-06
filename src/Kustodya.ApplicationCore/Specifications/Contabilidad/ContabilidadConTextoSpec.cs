using Kustodya.ApplicationCore.Entities.Contabilidades;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class ContabilidadConTextoSpec : BaseSpec<Entities.Contabilidades.Contabilidad>
    {
        public ContabilidadConTextoSpec(string busqueda, int entidadId, int? skip = 0, int? take = 10)
            : base(c => c.Eliminado == false && 
                c.EntidadId == entidadId && (string.IsNullOrWhiteSpace(busqueda) || (
                c.Codigo.Contains(busqueda) ||
                c.CodigoPucCreditoMovimientoPorDefecto.ToString().Contains(busqueda) ||
                c.CodigoPucDebitoMovimientoPorDefecto.ToString().Contains(busqueda) ||
                c.DescripcionMovimientoPorDefecto.Contains(busqueda) ||
                c.Descripcion.Contains(busqueda) ||
                c.ReferenciaMovimientoPorDefecto.Contains(busqueda)
                )))
        {
        }
    }
}