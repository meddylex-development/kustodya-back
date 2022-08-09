using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.K2Conceptos
{
    public class Carta
    {
        public int Id { get; set; }
        public int IdAfp { get; set; }
        public string tAsunto { get; set; }
        public string tDireccionPaciente { get; set; }
        public string tTelefonoPaciente { get; set; }
        public int iIDCiudad { get; set; }
        public string tEmailPaciente { get; set; }
        public DateTime FechaNotificacion { get; set; }
        public int MedioNotificacion { get; set; }
    }
}
