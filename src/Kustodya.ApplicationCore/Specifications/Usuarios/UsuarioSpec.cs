using Kustodya.ApplicationCore.Entities;

namespace Kustodya.ApplicationCore.Specifications
{
    public sealed class UsuarioSpec : BaseSpec<TblUsuarios>
    {
        public UsuarioSpec(string user, string password)
                : base(u => (u.TUsuario.ToLower() == user.ToLower() || u.TEmail.ToLower() == user.ToLower()) && u.TClave == password && u.BActivo == true)
        {
            base.AddInclude(u => u.TblUsuariosPerfiles);
        }
        public UsuarioSpec(int iduser): base (u=>u.IIdusuario == iduser) { 
        
        }
    }
}