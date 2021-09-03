using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPlanAccion
    {
        public TblPlanAccion()
        {
            TblPlanAccionRazones = new HashSet<TblPlanAccionRazones>();
        }

        public long IIdplanAccion { get; set; }
        public long IIdempresa { get; set; }
        public long IIdsucursal { get; set; }
        public long IIdproceso { get; set; }
        public int IIdresponsable { get; set; }
        public DateTime DtFechaInicial { get; set; }
        public DateTime DtFechaFinal { get; set; }
        public string TDescripcion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblEmpresaProcesos IIdprocesoNavigation { get; set; }
        public virtual TblUsuarios IIdresponsableNavigation { get; set; }
        public virtual TblSucursalesEmpresas IIdsucursalNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblPlanAccionRazones> TblPlanAccionRazones { get; set; }
    }
}
