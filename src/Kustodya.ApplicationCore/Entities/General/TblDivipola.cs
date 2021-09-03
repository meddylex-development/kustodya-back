using Kustodya.ApplicationCore.Entities.Administracion;
using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblDivipola
    {
        public TblDivipola()
        {
            TblAccidentesTrabajoIIdubicacionSucEmpleadorNavigation = new HashSet<TblAccidentesTrabajo>();
            TblAccidentesTrabajoIIdubicacionTrabajadorNavigation = new HashSet<TblAccidentesTrabajo>();
            TblActaMensual = new HashSet<TblActaMensual>();
            TblEmpleadosIIdlugarDomicilioNavigation = new HashSet<TblEmpleados>();
            TblEmpleadosIIdlugarExpedicionNavigation = new HashSet<TblEmpleados>();
            TblEmpleadosIIdlugarNacimientoNavigation = new HashSet<TblEmpleados>();
            TblIps = new HashSet<TblIps>();
            TblSucursalesEmpresas = new HashSet<TblSucursalesEmpresas>();
        }

        public long Iddivipola { get; set; }
        public string Codigodivipola { get; set; }
        public string Idpais { get; set; }
        public string Nombrepais { get; set; }
        public string Iddepto { get; set; }
        public string Nombredepto { get; set; }
        public string Idmunicipio { get; set; }
        public string Nombremunicipio { get; set; }
        public string Nombrepoblacion { get; set; }
        public DateTime? Fechainsercion { get; set; }
        public string Usuarioinsercion { get; set; }
        public DateTime? Fechamodificacion { get; set; }
        public string Usuariomodificacion { get; set; }
        public bool BActivo { get; set; }

        public virtual ICollection<TblAccidentesTrabajo> TblAccidentesTrabajoIIdubicacionSucEmpleadorNavigation { get; set; }
        public virtual ICollection<TblAccidentesTrabajo> TblAccidentesTrabajoIIdubicacionTrabajadorNavigation { get; set; }
        public virtual ICollection<TblActaMensual> TblActaMensual { get; set; }
        public virtual ICollection<TblEmpleados> TblEmpleadosIIdlugarDomicilioNavigation { get; set; }
        public virtual ICollection<TblEmpleados> TblEmpleadosIIdlugarExpedicionNavigation { get; set; }
        public virtual ICollection<TblEmpleados> TblEmpleadosIIdlugarNacimientoNavigation { get; set; }
        public virtual ICollection<TblIps> TblIps { get; set; }
        public virtual ICollection<TblSucursalesEmpresas> TblSucursalesEmpresas { get; set; }
        public virtual ICollection<UsuarioDireccion> UsuarioDirecciones { get; set; }
    }
}
