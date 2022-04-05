using Kustodya.ApplicationCore.Constants;

namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class UsuarioDireccion
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public long DivipolaId { get; set; }
        public Via TipoViaPrincipal { get; set; }
        public int NumeroViaPrincipal { get; set; }
        public string LetraViaPrincipal { get; set; }
        public int NumeroViaSecundaria { get; set; }
        public string LetraViaSecundaria { get; set; }
        public int DistanciaInterseccion { get; set; }
        public string Indicaciones { get; set; }
        public TblDivipola Divipola { get; set; }
        public TblUsuarios Usuario { get; set; }
    }
}