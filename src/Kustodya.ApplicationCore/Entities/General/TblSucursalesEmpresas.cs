using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblSucursalesEmpresas
    {
        public TblSucursalesEmpresas()
        {
            TblDiagnosticoCondicionTrabajo = new HashSet<TblDiagnosticoCondicionTrabajo>();
            TblEmpleados = new HashSet<TblEmpleados>();
            TblPerfilSocioDemoSucursal = new HashSet<TblPerfilSocioDemoSucursal>();
            TblPlanAccion = new HashSet<TblPlanAccion>();
            TblSucursalRiesgo = new HashSet<TblSucursalRiesgo>();
        }

        public long IIdsucursal { get; set; }
        public long IIdempresa { get; set; }
        public string TCodigo { get; set; }
        public string TSigla { get; set; }
        public string TNombre { get; set; }
        public long IIdubicacion { get; set; }
        public string TDireccion { get; set; }
        public string TEmail { get; set; }
        public string TTelefono { get; set; }
        public string TTelefono2 { get; set; }
        public string TFax { get; set; }
        public long? IIdestado { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int? IIdusuarioModifiacion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblMultivalores IIdestadoNavigation { get; set; }
        public virtual TblDivipola IIdubicacionNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblDiagnosticoCondicionTrabajo> TblDiagnosticoCondicionTrabajo { get; set; }
        public virtual ICollection<TblEmpleados> TblEmpleados { get; set; }
        public virtual ICollection<TblPerfilSocioDemoSucursal> TblPerfilSocioDemoSucursal { get; set; }
        public virtual ICollection<TblPlanAccion> TblPlanAccion { get; set; }
        public virtual ICollection<TblSucursalRiesgo> TblSucursalRiesgo { get; set; }
    }
}
