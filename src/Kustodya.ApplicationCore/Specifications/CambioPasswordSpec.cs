using Kustodya.ApplicationCore.Entities;

namespace Kustodya.ApplicationCore.Specifications
{
    public sealed class CambioPasswordSpec : BaseSpec<TblUsuarios>
    {
        public CambioPasswordSpec(int id)
                : base(u => (u.BCambioPassword == true && u.BActivo == true && u.IIdusuario == id))
        {
            
        }
    }
}