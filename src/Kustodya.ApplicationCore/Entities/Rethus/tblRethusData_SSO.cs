using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Rethus
{
    public class tblRethusData_SSO
    {
        public int iIDSSOData { get; set; }
        public int iIDRethusQuery { get; set; }
        public string tTipoPrestacion { get; set; }
        public string tTipoLugarPrestacion { get; set; }
        public string tLugarPrestacion { get; set; }
        public string tFechaInicio { get; set; }
        public string tFechaFin { get; set; }
        public string tModalidadPrestacion { get; set; }
        public string tProgramaPrestacion { get; set; }
        public string tEntidadReportadora { get; set; }
    }
}
