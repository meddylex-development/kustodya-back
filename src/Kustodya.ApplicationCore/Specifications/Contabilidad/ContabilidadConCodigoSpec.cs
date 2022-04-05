using Kustodya.ApplicationCore.Entities.Contabilidades;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class ContabilidadConCodigoSpec : BaseSpec<Entities.Contabilidades.Contabilidad>
    {
        public ContabilidadConCodigoSpec(string codigo, int entidadId, int? skip = 0, int? take = 10)
            : base(c => c.Codigo == codigo && c.EntidadId == entidadId)
        {
            AddInclude(c => c.PucCreditoPorDefecto);
            AddInclude(c => c.PucDebitoPorDefecto);
            AddInclude(c => c.ClaseDocumentoPorDefecto);
            AddInclude(c => c.TipoAjustePorDefecto);
        }
    }
}