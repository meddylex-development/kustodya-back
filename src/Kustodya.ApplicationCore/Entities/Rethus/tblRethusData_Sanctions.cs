using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Rethus
{
    public class tblRethusData_Sanctions
    {
        public int iIDSanctionData { get; set; }
        public int iIDRethusQuery { get; set; }
        public string tInstanciaEmiteFallo { get; set; }
        public string tCodTipoSancion { get; set; }
        public string tTipoSancion { get; set; }
        public string tFechaEjecucion { get; set; }
        public string tFechaInicio { get; set; }
        public string tFehaFin { get; set; }
    }
}
