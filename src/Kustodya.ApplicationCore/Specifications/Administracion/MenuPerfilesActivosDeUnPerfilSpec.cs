using Kustodya.ApplicationCore.Entities;

namespace Kustodya.ApplicationCore.Specifications
{
    public class MenuPerfilesActivosDeUnPerfilSpec : BaseSpec<TblMenuPerfiles>
    {
        public MenuPerfilesActivosDeUnPerfilSpec(int perfilId)
            : base(p => p.IIdperfil == perfilId)
        {

        }
    }
}