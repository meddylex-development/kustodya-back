using Kustodya.ApplicationCore.Dtos.General;

namespace Kustodya.WebApi.Models
{
    public class UsuarioModel
    {
        public DocumentoUsuarioModel Documento { get; set; }
        public int IId { get; set; }
        public string NombreUsuario { get; set; }
        public OcupacionModel Ocupacion { get; set; }
        public TipoDocumentoModel TipoDocumento { get; set; }
        public string TNumeroDocumento { get; set; }
    }
}