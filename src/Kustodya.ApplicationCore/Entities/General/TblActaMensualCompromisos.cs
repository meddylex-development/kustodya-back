using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblActaMensualCompromisos
    {
        public TblActaMensualCompromisos()
        {
            TblActaMensualCompromisoActividades = new HashSet<TblActaMensualCompromisoActividades>();
        }

        public long IIdactaMensualCompromisos { get; set; }
        public long IIdempresa { get; set; }
        public long IIdactaMensual { get; set; }
        public int IUsuarioAsignado { get; set; }
        public string TDescripcion { get; set; }
        public DateTime DtFechaInicio { get; set; }
        public DateTime DtFechaCompromiso { get; set; }
        public long IEstado { get; set; }
        public long? IActaConfirmacion { get; set; }
        public DateTime? DtFechaConfirmacion { get; set; }
        public int? IUsuarioConfirmacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblActaMensual IActaConfirmacionNavigation { get; set; }
        public virtual TblMultivalores IEstadoNavigation { get; set; }
        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioAsignadoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioConfirmacionNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblActaMensualCompromisoActividades> TblActaMensualCompromisoActividades { get; set; }
    }
}
