using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblIps
    {
        public TblIps()
        {
            TblDiagnosticosIncapacidades = new HashSet<TblDiagnosticosIncapacidades>();
            TblIpssEps = new HashSet<TblIpssEps>();
        }

        public long IIdips { get; set; }
        public string TNombre { get; set; }
        public string TCodigoExterno { get; set; }
        public long? IIdtipoIdentificacion { get; set; }
        public string TNumeroIdentificacion { get; set; }
        public int? TDigitoVerificacion { get; set; }
        public long ITipoIps { get; set; }
        public string TPathLogo { get; set; }
        public long? IIdubicacion { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }
        public long? ICodigoHabilitacion { get; set; }
        public string TDireccion { get; set; }
        public string TEmail { get; set; }
        public string TTelefono { get; set; }

        public virtual TblMultivalores IIdtipoIdentificacionNavigation { get; set; }
        public virtual TblDivipola IIdubicacionNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual TblMultivalores ITipoIpsNavigation { get; set; }
        public virtual ICollection<TblDiagnosticosIncapacidades> TblDiagnosticosIncapacidades { get; set; }
        public virtual ICollection<TblIpssEps> TblIpssEps { get; set; }
    }
}
