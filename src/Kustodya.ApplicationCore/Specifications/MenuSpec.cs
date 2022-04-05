using Kustodya.ApplicationCore.Entities;
using System.Linq;

namespace Kustodya.ApplicationCore.Specifications
{
    public sealed class MenuSpec : BaseSpec<TblMenu>
    {
        public MenuSpec(int IIdperfil)
                : base(u => u.TblMenuPerfiles.Any(d => d.IIdperfil == IIdperfil && d.BActivo == true) == true)
        {
            ApplyOrderBy(mp => mp.IPosicion);
        }
    }
}