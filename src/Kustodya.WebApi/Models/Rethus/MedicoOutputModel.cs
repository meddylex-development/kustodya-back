using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.Rethus
{
    public class MedicoOutputModel
    {
        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string RegistradoEnRethus { get; set; }
        public string EstadoIdentificacion { get; set; }
        public string TipoPrograma { get; set; }
        public List<MedicoDetalleOutputModel> Detalles { get; set; }
        public List<SancionesMedicoOutputModel> Sanciones { get; set; }
        public List<DatosSsoOutputModel> DatosSso { get; set; }
    }
}
