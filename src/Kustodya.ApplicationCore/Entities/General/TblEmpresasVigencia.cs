using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresasVigencia
    {
        public TblEmpresasVigencia()
        {
            TblAusentismoHorasHombreTrabajadas = new HashSet<TblAusentismoHorasHombreTrabajadas>();
            TblAusentismoIndicadoresInfraestructura = new HashSet<TblAusentismoIndicadoresInfraestructura>();
            TblAusentismoIndicadoresProceso = new HashSet<TblAusentismoIndicadoresProceso>();
            TblAusentismoIndiceAccidentalidad = new HashSet<TblAusentismoIndiceAccidentalidad>();
            TblAusentismoIndiceEnfermedadProfesional = new HashSet<TblAusentismoIndiceEnfermedadProfesional>();
            TblAusentismoPrevalenciaIncidencia = new HashSet<TblAusentismoPrevalenciaIncidencia>();
            TblInspecciones = new HashSet<TblInspecciones>();
            TblInspeccionesPrograma = new HashSet<TblInspeccionesPrograma>();
        }

        public long IIdempresaVigencia { get; set; }
        public long IIdempresa { get; set; }
        public int IVigencia { get; set; }
        public DateTime DtFechaDesde { get; set; }
        public DateTime DtFechaHasta { get; set; }
        public long? IIdestadoVigencia { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblMultivalores IIdestadoVigenciaNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblAusentismoHorasHombreTrabajadas> TblAusentismoHorasHombreTrabajadas { get; set; }
        public virtual ICollection<TblAusentismoIndicadoresInfraestructura> TblAusentismoIndicadoresInfraestructura { get; set; }
        public virtual ICollection<TblAusentismoIndicadoresProceso> TblAusentismoIndicadoresProceso { get; set; }
        public virtual ICollection<TblAusentismoIndiceAccidentalidad> TblAusentismoIndiceAccidentalidad { get; set; }
        public virtual ICollection<TblAusentismoIndiceEnfermedadProfesional> TblAusentismoIndiceEnfermedadProfesional { get; set; }
        public virtual ICollection<TblAusentismoPrevalenciaIncidencia> TblAusentismoPrevalenciaIncidencia { get; set; }
        public virtual ICollection<TblInspecciones> TblInspecciones { get; set; }
        public virtual ICollection<TblInspeccionesPrograma> TblInspeccionesPrograma { get; set; }
    }
}
