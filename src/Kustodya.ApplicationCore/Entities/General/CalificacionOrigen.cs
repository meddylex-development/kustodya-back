using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.General
{
    public class CalificacionOrigen
    {
        public long Id { get; set; }
        public int PacientesId { get; set; }
        public TblPacientes TblPacientes { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int TblEmpresasPacientesId { get; set; }
        public TblEmpresasPacientes TblEmpresasPacientes { get; set; }

    }
}
