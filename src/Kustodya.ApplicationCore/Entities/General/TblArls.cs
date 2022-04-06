using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblArls
    {
        public TblArls()
        {
            TblDiagnosticosIncapacidades = new HashSet<TblDiagnosticosIncapacidades>();
            TblEmpleados = new HashSet<TblEmpleados>();
            TblEmpresasArls = new HashSet<TblEmpresasArls>();
            TblPacientes = new HashSet<TblPacientes>();
        }

        public long IIdarl { get; set; }
        public string TNombre { get; set; }
        public string TCodigoExterno { get; set; }
        public long? IIdtipoIdentificacion { get; set; }
        public string TNumeroIdentificacion { get; set; }
        public int? TDigitoVerificacion { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblMultivalores IIdtipoIdentificacionNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblDiagnosticosIncapacidades> TblDiagnosticosIncapacidades { get; set; }
        public virtual ICollection<TblEmpleados> TblEmpleados { get; set; }
        public virtual ICollection<TblEmpresasArls> TblEmpresasArls { get; set; }
        public virtual ICollection<TblPacientes> TblPacientes { get; set; }
    }
}
