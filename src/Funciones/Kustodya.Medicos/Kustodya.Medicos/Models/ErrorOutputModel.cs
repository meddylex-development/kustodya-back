using Kustodya.ApplicationCore.Constants;

namespace Kustodya.Medicos.Models
{
    public class ErrorOutputModel
    {
        public ErrorOutputModel(int indice, string mesaje = null, string numeroDocumento = null, TipoIdentificacion? tipoIdentificacion = null)
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