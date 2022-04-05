using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblAusentismoIndiceAccidentalidad
    {
        public long IIdindiceAccidentalidad { get; set; }
        public long IIdempresa { get; set; }
        public long IVigencia { get; set; }
        public string TMes { get; set; }
        public int? INumCasos { get; set; }
        public int? INumDiasPerdidos { get; set; }
        public int? INumDiasCargados { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }
        public string TObservaciones { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual TblEmpresasVigencia IVigenciaNavigation { get; set; }
    }
}
