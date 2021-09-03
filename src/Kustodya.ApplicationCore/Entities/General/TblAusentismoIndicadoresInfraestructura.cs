using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblAusentismoIndicadoresInfraestructura
    {
        public long IIdindicadorInfraestructura { get; set; }
        public long IIdempresa { get; set; }
        public long IVigencia { get; set; }
        public string TMes { get; set; }
        public int? INumHorasDisponibles { get; set; }
        public int? IRecursosFinancieros { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }
        public string TObservaciones { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual TblEmpresasVigencia IVigenciaNavigation { get; set; }
    }
}
