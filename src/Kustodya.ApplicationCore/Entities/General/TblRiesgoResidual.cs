using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRiesgoResidual
    {
        public TblRiesgoResidual()
        {
            TblRiesgoResidualAcciones = new HashSet<TblRiesgoResidualAcciones>();
        }

        public long IIdriesgoResidual { get; set; }
        public long IIdriesgoIdentificacion { get; set; }
        public int IIdsubtablaRiesgoProbabilidad { get; set; }
        public string TIdvalorRiesgoProbabilidad { get; set; }
        public int IIdsubtablaRiesgoImpacto { get; set; }
        public string TIdvalorRiesgoImpacto { get; set; }
        public string TValoracion { get; set; }
        public int? IIdsubtablaOpcionManejo { get; set; }
        public string TIdvalorOpcionManejo { get; set; }
        public DateTime DtFechaInsercion { get; set; }
        public int IUsuarioInsercion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblRiesgoIdentificacion IIdriesgoIdentificacionNavigation { get; set; }
        public virtual TblUsuarios IUsuarioInsercionNavigation { get; set; }
        public virtual ICollection<TblRiesgoResidualAcciones> TblRiesgoResidualAcciones { get; set; }
    }
}
