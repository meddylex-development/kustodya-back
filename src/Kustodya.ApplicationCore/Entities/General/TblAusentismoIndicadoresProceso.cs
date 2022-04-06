using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblAusentismoIndicadoresProceso
    {
        public long IIdindicadorProceso { get; set; }
        public long IIdempresa { get; set; }
        public long IVigencia { get; set; }
        public string TMes { get; set; }
        public int? INumUsuariosPrimAuxilios { get; set; }
        public int? INumUsuariosChequeoMedico { get; set; }
        public int? INumUsuariosEquipoProtPersonal { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }
        public string TObservaciones { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual TblEmpresasVigencia IVigenciaNavigation { get; set; }
    }
}
