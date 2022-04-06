using Kustodya.ApplicationCore.Constants;

namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class UsuarioRedSocial
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public RedSocial TipoRedSocial { get; set; }
        public string UsuariooLink { get; set; }
        public TblUsuarios Usuario { get; set; }
    }
}