using Kustodya.ApplicationCore.Entities;

namespace Kustodya.ApplicationCore.Specifications.Negocio
{
    public class EPSSpec : BaseSpec<TblEps>
    {
        public EPSSpec(bool activo)
                : base(u => u.BActivo == activo)
        {
            //base.AddInclude(d => d.IIdtipoDocNavigation);
            //base.AddInclude(d => d.IIdepsNavigation);
        }

        public EPSSpec(long idEps) : base(u => u.IIdeps == idEps)
        {
        }
    }
}