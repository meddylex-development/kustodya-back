using Kustodya.ApplicationCore.Entities.Contabilidades;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    // 
    public class PucConCodigoSpec : BaseSpec<Puc>
    {
        public PucConCodigoSpec(string codigo, int entidadId, int? skip = 0, int? take = 10)
            : base(p => p.Eliminado == false && p.Codigo == codigo && p.Contabilidad.EntidadId == entidadId)
        {
            AddInclude(p => p.Contabilidad);
        }
    }
}