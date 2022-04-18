using Kustodya.ApplicationCore.Entities.Concepto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Incapacidades.Modelos
{
    public class PacienteOutputModel
    {
        public int idpacienteporemitir { get; set; }
        public int idPaciente { get; set; }
        public string numeroIdentificacion { get; set; }
        public long fechaAsignacion { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public string codigoCorto { get; set; }
        public DateTime FechaCreacion { get; set; } //se agrega nuevo
        public int DiasIncapacidad { get; set; } 
        public int GrupoIncapacidad { get; set; } 
        public int Prioridad { get; set; } //se agrega nuevo
        public string CausalAnulacion { get; set; } //se agrega nuevo
        public DateTime? FechaAnulacion { get; set; } //se agrega nuevo
        public int? UsuarioAsignadoId { get; set; } //se agrega nuevo
        public DateTime? FechaModificacion { get; set; } //se agrega nuevo
        public int Progreso { get; set; } //se agrega nuevo
        public DateTime? FechaEmision { get; set; } 
        public DateTime? FechaNotificacion { get; set; } //se agrega nuevo
    }
}
