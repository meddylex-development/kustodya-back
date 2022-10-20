using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.K2Conceptos
{
    public class Carta
    {
        public int IdConcepto { get; set; }
        public string tAsunto { get; set; }
        public string tDireccionPaciente { get; set; }
        public int iCodigoPostal { get; set; }
        public string tTelefonoPaciente { get; set; }
        public int iIDCiudad { get; set; }
        public string tEmailPaciente { get; set; }
        public Boolean bNotificacionbyEmailAFP { get; set; }
        public Boolean bNotificacionbyPmailAFP { get; set; }
        public Boolean bNotificacionbyEmailPaciente { get; set; }
        public Boolean bNotificacionbyPmailPaciente { get; set; }
    }
}
