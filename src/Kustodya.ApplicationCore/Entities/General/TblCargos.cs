using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCargos
    {
        public TblCargos()
        {
            TblAccidentesTrabajo = new HashSet<TblAccidentesTrabajo>();
            TblAsignacion = new HashSet<TblAsignacion>();
            TblCargoPerfil = new HashSet<TblCargoPerfil>();
            TblDiagnosticoCondicionTrabajo = new HashSet<TblDiagnosticoCondicionTrabajo>();
            TblEmpleados = new HashSet<TblEmpleados>();
            TblIndicadoresDetalleIIdresponsableAnalisisNavigation = new HashSet<TblIndicadoresDetalle>();
            TblIndicadoresDetalleIIdresponsableInformacionNavigation = new HashSet<TblIndicadoresDetalle>();
            TblPerfilSocioDemoCargo = new HashSet<TblPerfilSocioDemoCargo>();
            TblProcedimientos = new HashSet<TblProcedimientos>();
        }

        public long IIdcargo { get; set; }
        public long IIdempresa { get; set; }
        public string TNombreCargo { get; set; }
        public string TDescripcion { get; set; }
        public bool BRepresentanteLegal { get; set; }
        public long? IIdjefe { get; set; }
        public int IIdusuarioCreador { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public DateTime? DtUsuarioModificacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreadorNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioModificacionNavigation { get; set; }
        public virtual ICollection<TblAccidentesTrabajo> TblAccidentesTrabajo { get; set; }
        public virtual ICollection<TblAsignacion> TblAsignacion { get; set; }
        public virtual ICollection<TblCargoPerfil> TblCargoPerfil { get; set; }
        public virtual ICollection<TblDiagnosticoCondicionTrabajo> TblDiagnosticoCondicionTrabajo { get; set; }
        public virtual ICollection<TblEmpleados> TblEmpleados { get; set; }
        public virtual ICollection<TblIndicadoresDetalle> TblIndicadoresDetalleIIdresponsableAnalisisNavigation { get; set; }
        public virtual ICollection<TblIndicadoresDetalle> TblIndicadoresDetalleIIdresponsableInformacionNavigation { get; set; }
        public virtual ICollection<TblPerfilSocioDemoCargo> TblPerfilSocioDemoCargo { get; set; }
        public virtual ICollection<TblProcedimientos> TblProcedimientos { get; set; }
    }
}
