using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblFormulariosRespuestasEncabezados
    {
        public TblFormulariosRespuestasEncabezados()
        {
            TblFormulariosRespuestas = new HashSet<TblFormulariosRespuestas>();
        }

        public int IIdformularioRespuestaEncabezado { get; set; }
        public int IIdformulario { get; set; }
        public string TDireccionIp { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblFormularios IIdformularioNavigation { get; set; }
        public virtual ICollection<TblFormulariosRespuestas> TblFormulariosRespuestas { get; set; }
    }
}
