using Kustodya.ApplicationCore.Entities.Contabilidades;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class ContabilidadPaginadaConTextoSpec : BaseSpec<Kustodya.ApplicationCore.Entities.Contabilidades.Contabilidad>
    {
        public ContabilidadPaginadaConTextoSpec(string busqueda, int entidadId, int? skip = 0, int? take = 10)
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
            if (skip.HasValue || take.HasValue)
                ApplyPaging(skip.Value, take.Value);
            AddInclude(c => c.PucCreditoPorDefecto);
            AddInclude(c => c.PucDebitoPorDefecto);
            AddInclude(c => c.TipoAjustePorDefecto);
            AddInclude(c => c.ClaseDocumentoPorDefecto);
        }
    }
}