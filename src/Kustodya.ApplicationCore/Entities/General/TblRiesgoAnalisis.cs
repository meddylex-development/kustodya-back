using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRiesgoAnalisis
    {
        public long IIdriesgoAnalisis { get; set; }
        public long IIdriesgoIdentificacion { get; set; }
        public int IIdsubtablaRiesgoProbabilidad { get; set; }
        public string TIdvalorRiesgoProbabilidad { get; set; }
        public int IIdsubtablaRiesgoImpacto { get; set; }
        public string TIdvalorRiesgoImpacto { get; set; }
        public string TEvaluacion { get; set; }
        public DateTime DtFechaInsercion { get; set; }
        public int IUsuarioInsercion { get; set; }
        public bool? BActivo { get; set; }

        public virtual TblUsuarios IUsuarioInsercionNavigation { get; set; }
    }
}
