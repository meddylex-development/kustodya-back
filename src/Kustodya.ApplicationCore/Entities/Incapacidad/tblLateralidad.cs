using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Incapacidad
{
    public class tblLateralidad
    {
        public int iIDLateralidad { get; set; }
        public string tNombre { get; set; }
        public string tDescripcion { get; set; }
        public DateTime dtFechaCreacion { get; set; }
        public DateTime dtFechaFin { get; set; }
    }
}
