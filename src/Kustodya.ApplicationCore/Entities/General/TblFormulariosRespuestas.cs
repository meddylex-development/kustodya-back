using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblFormulariosRespuestas
    {
        public int IIdformularioRespuesta { get; set; }
        public int IIdformularioRespuestaEncabezado { get; set; }
        public string TCampo { get; set; }
        public string TRespuesta { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblFormulariosRespuestasEncabezados IIdformularioRespuestaEncabezadoNavigation { get; set; }
    }
}
