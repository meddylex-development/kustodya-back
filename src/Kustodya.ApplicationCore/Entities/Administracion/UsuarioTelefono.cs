namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class UsuarioTelefono
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string CodigoPais { get; set; }
        public string CodigoArea { get; set; }
        public long Numero { get; set; }
        public string Extension { get; set; }
        public string Descripcion { get; set; }
        public TblUsuarios Usuario { get; set; }
    }
}