using Kustodya.ApplicationCore.Entities;
using System.Linq;

namespace Kustodya.ApplicationCore.Specifications.Negocio
{
    public class IPSSpec : BaseSpec<TblIps>
    {

        public IPSSpec(int IIdeps)
                : base(u => u.TblIpssEps.Any(d => d.IIdeps == IIdeps))
        {
            //base.AddInclude(d => d.IIdtipoDocNavigation);
            //base.AddInclude(d => d.IIdepsNavigation);
        }

        public IPSSpec(long idips) : base(u => u.IIdips == idips)
        {
        }

        public IPSSpec(string centroAtencion) : base(u => u.TNombre.Equals(centroAtencion,System.StringComparison.InvariantCultureIgnoreCase))
        {

        }
    }
}