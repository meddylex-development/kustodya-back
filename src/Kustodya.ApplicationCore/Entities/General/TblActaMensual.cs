using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblActaMensual
    {
        public TblActaMensual()
        {
            TblActaMensualCompromisos = new HashSet<TblActaMensualCompromisos>();
            TblActaMensualParticipantes = new HashSet<TblActaMensualParticipantes>();
        }

        public long IIdactaMensual { get; set; }
        public long IIdempresa { get; set; }
        public long IIdclaseActa { get; set; }
        public int INumeroActa { get; set; }
        public DateTime DtFechaActa { get; set; }
        public long IIdubicacion { get; set; }
        public TimeSpan DtHoraInicio { get; set; }
        public TimeSpan DtHoraFin { get; set; }
        public long ITipoReunion { get; set; }
        public bool BVerificacionQuorum { get; set; }
        public bool BAprobacionActaAnt { get; set; }
        public string TObjetivos { get; set; }
        public string TTemas { get; set; }
        public DateTime DtFechaProximaReunion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblMultivalores IIdclaseActaNavigation { get; set; }
        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblDivipola IIdubicacionNavigation { get; set; }
        public virtual TblMultivalores ITipoReunionNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblActaMensualCompromisos> TblActaMensualCompromisos { get; set; }
        public virtual ICollection<TblActaMensualParticipantes> TblActaMensualParticipantes { get; set; }
    }
}
