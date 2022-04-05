using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Rethus
{
    public class tblRethusData_Academic
    {
        public int iIDAcademicData { get; set; }
        public int iIDRethusQuery { get; set; }
        public string tTipoPrograma { get; set; }
        public string tOrigenObtencionTitulo { get; set; }
        public string tProfesionOcupacion { get; set; }
        public string tFechaInicioEjercerActoAdmin { get; set; }
        public string tActoAdministrativo { get; set; }
        public string tEntidadReportadora { get; set; }
    }
}
