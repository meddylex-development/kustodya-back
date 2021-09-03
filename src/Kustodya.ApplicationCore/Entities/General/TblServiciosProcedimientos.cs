using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblServiciosProcedimientos
    {
        public TblServiciosProcedimientos()
        {
            TblRecobrosUsuariosServiciosProcedimientos = new HashSet<TblRecobrosUsuariosServiciosProcedimientos>();
        }

        public int IIdservicioProcedimiento { get; set; }
        public int? IIdpais { get; set; }
        public string TCodigo { get; set; }
        public string TDescripcion { get; set; }
        public DateTime? DtFechaInsercion { get; set; }
        public int? IIdusuarioInsercion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public bool? BActivo { get; set; }

        public virtual TblUsuarios IIdusuarioInsercionNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioModificacionNavigation { get; set; }
        public virtual ICollection<TblRecobrosUsuariosServiciosProcedimientos> TblRecobrosUsuariosServiciosProcedimientos { get; set; }
    }
}
