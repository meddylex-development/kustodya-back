using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblDiagnosticosIncapacidades
    {
        public TblDiagnosticosIncapacidades()
        {
            InverseIIddiagnosticoCorrelacionNavigation = new HashSet<TblDiagnosticosIncapacidades>();
            TblCie10DiagnosticoIncapacidad = new HashSet<TblCie10DiagnosticoIncapacidad>();
        }

        public long IIddiagnosticoIncapacidad { get; set; }
        public Guid UiCodigoDiagnostico { get; set; }
        public string TCodigoCorto { get; set; }
        public int IIdpaciente { get; set; }
        public long IIdeps { get; set; }
        public long IIdafp { get; set; }
        public long IIdarl { get; set; }
        public long IIdips { get; set; }
        public long IIdpresuntoOrigenIncapacidad { get; set; }
        public long? IIdorigenCalificadoIncapacidad { get; set; }
        public long IIdtipoAtencion { get; set; }
        public string TTiempo { get; set; }
        public string TModo { get; set; }
        public string TLugar { get; set; }
        public string TDescripcionSintomatologica { get; set; }
        public int IDiasIncapacidad { get; set; }
        public int? IDiasAcumuladosPorroga { get; set; }
        public bool BProrroga { get; set; }
        public bool BSoat { get; set; }
        public long IIdusuarioCreador { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public DateTime DtFechaFin { get; set; }
        public long? IIddiagnosticoCorrelacion { get; set; }
        public bool? BEsTranscripcion { get; set; }
        public DateTime? DtFechaEmisionIncapacidad { get; set; }
        public string NumeroIncapacidadIpstranscripcion { get; set; }
        public int? iIDLateralidad { get; set; }

        public virtual TblAfp IIdafpNavigation { get; set; }
        public virtual TblArls IIdarlNavigation { get; set; }
        public virtual TblDiagnosticosIncapacidades IIddiagnosticoCorrelacionNavigation { get; set; }
        public virtual TblEps IIdepsNavigation { get; set; }
        public virtual TblIps IIdipsNavigation { get; set; }
        public virtual TblMultivalores IIdorigenCalificadoIncapacidadNavigation { get; set; }
        public virtual TblPacientes IIdpacienteNavigation { get; set; }
        public virtual TblMultivalores IIdpresuntoOrigenIncapacidadNavigation { get; set; }
        public virtual TblMultivalores IIdtipoAtencionNavigation { get; set; }
        public virtual ICollection<TblDiagnosticosIncapacidades> InverseIIddiagnosticoCorrelacionNavigation { get; set; }
        public virtual ICollection<TblCie10DiagnosticoIncapacidad> TblCie10DiagnosticoIncapacidad { get; set; }
    }
}
