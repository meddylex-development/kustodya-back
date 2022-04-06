using Kustodya.ApplicationCore.Constants;

namespace Kustodya.WebApi.Models
{
    public class Error
    {
        public Error(int indice, string mesaje = null, string numeroDocumento = null, TipoIdentificacion? tipoIdentificacion = null)
        {
            Inidice = indice;
            NumeroDocumento = numeroDocumento;
            TipoIdentificacion = tipoIdentificacion;
            Mensaje = Mensaje;
        }

        public int Inidice { get; private set; }
        public string Mensaje { get; set; }
        public string NumeroDocumento { get; set; }
        public TipoIdentificacion? TipoIdentificacion { get; set; }
    }
}