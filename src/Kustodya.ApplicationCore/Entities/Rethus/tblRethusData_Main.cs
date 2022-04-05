using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Rethus
{
    public class tblRethusData_Main
    {
        public int iIDMainData { get; set; }
        public int iIDRethusQuery { get; set; }
        public string tTipoIdentificacion { get; set; }
        public string tNrodentificacion { get; set; }
        public string tPrimerNombre { get; set; }
        public string tSegundoNombre { get; set; }
        public string tPrimerApellido { get; set; }
        public string tSegundoApellido { get; set; }
        public string tEstadoIdentificacion { get; set; }
    }
}
