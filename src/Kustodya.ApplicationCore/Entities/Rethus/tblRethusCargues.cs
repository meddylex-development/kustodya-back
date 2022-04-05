using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Rethus
{
    public class tblRethusCargues
    {
        public int iIDCargue { get; set; }
        public int iIDTask { get; set; }
        public string tNombreArchivo { get; set; }
        public DateTime dtFechaCreacion { get; set; }
    }
}
