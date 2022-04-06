using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEps
    {
        public TblEps()
        {
            TblAccidentesTrabajo = new HashSet<TblAccidentesTrabajo>();
            TblDiagnosticosIncapacidades = new HashSet<TblDiagnosticosIncapacidades>();
            TblEmpleados = new HashSet<TblEmpleados>();
            TblIpssEps = new HashSet<TblIpssEps>();
            TblPacientes = new HashSet<TblPacientes>();
            TblPerfilSocioDemoEps = new HashSet<TblPerfilSocioDemoEps>();
        }

        public long IIdeps { get; set; }
        public string TNombre { get; set; }
        public string TCodigoExterno { get; set; }
        public long? IIdtipoIdentificacion { get; set; }
        public string TNumeroIdentificacion { get; set; }
        public int? TDigitoVerificacion { get; set; }
        public string TPathLogo { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblMultivalores IIdtipoIdentificacionNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblAccidentesTrabajo> TblAccidentesTrabajo { get; set; }
        public virtual ICollection<TblDiagnosticosIncapacidades> TblDiagnosticosIncapacidades { get; set; }
        public virtual ICollection<TblEmpleados> TblEmpleados { get; set; }
        public virtual ICollection<TblIpssEps> TblIpssEps { get; set; }
        public virtual ICollection<TblPacientes> TblPacientes { get; set; }
        public virtual ICollection<TblPerfilSocioDemoEps> TblPerfilSocioDemoEps { get; set; }
    }
}
