using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblAusentismoHorasHombreTrabajadas
    {
        public long IIdhorasHombreTrabajadas { get; set; }
        public long IIdempresa { get; set; }
        public long IVigencia { get; set; }
        public string TMes { get; set; }
        public int? INumEmpleados { get; set; }
        public int? INumHorasTrabajadas { get; set; }
        public int? INumDiasTrabajados { get; set; }
        public int? INumTotalHorasExtras { get; set; }
        public int? INumTotalHorasAusentismo { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }
        public int? INumTrabajadores { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual TblEmpresasVigencia IVigenciaNavigation { get; set; }
    }
}
