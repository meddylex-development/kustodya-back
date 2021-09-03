using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresaPoliticaControlCambios
    {
        public long IIdempresaPoliticaControlCambio { get; set; }
        public long? IIdempresaPolitica { get; set; }
        public DateTime? DtFechaCambio { get; set; }
        public int? IIdusuario { get; set; }
        public string TDescripcionCambio { get; set; }
        public int? IVersion { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public int? IIdusuarioCreacion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public bool? BActivo { get; set; }

        public virtual TblEmpresaPolitica IIdempresaPoliticaNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioModificacionNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioNavigation { get; set; }
    }
}
