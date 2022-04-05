using System.Collections.Generic;
using Kustodya.ApplicationCore.Constants;

namespace Kustodya.Medicos.Models
{
    public partial class MedicoOutputModel
    {
        public string NumeroIdentificacion { get; set; }
        public TipoIdentificacion TipoIdentificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public List<DetalleOutputModel> Detalles { get; set; }
        public List<ErrorOutputModel> Errors { get; set; }
    }
}
