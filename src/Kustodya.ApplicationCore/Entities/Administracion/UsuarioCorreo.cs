namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class UsuarioCorreo : BaseEntity
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Correo { get; set; }
        public string Descripcion { get; set; }
        public TblUsuarios Usuario { get; set;}
    }
}