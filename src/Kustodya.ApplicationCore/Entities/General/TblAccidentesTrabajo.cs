using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblAccidentesTrabajo
    {
        public TblAccidentesTrabajo()
        {
            TblAtanalisisCausas = new HashSet<TblAtanalisisCausas>();
            TblAtequiposProteccion = new HashSet<TblAtequiposProteccion>();
            TblAtinformacionSuceso = new HashSet<TblAtinformacionSuceso>();
            TblAtmedidasAccionesCorrectivas = new HashSet<TblAtmedidasAccionesCorrectivas>();
            TblAtmedidasSeguridad = new HashSet<TblAtmedidasSeguridad>();
            TblAtpartesAfectadas = new HashSet<TblAtpartesAfectadas>();
            TblAtpersonas = new HashSet<TblAtpersonas>();
        }

        public long IIdaccidenteTrabajo { get; set; }
        public long IIdempresa { get; set; }
        public DateTime DtFechaInvestigacion { get; set; }
        public long IIdtipoEvento { get; set; }
        public string TNombreEmpresa { get; set; }
        public long IIdactividadEconomica { get; set; }
        public long IIdtipoIdentificacion { get; set; }
        public string TNumeroIdentificacion { get; set; }
        public long IIdtipoVinculador { get; set; }
        public string TSucursalEmpleador { get; set; }
        public long IIdubicacionSucEmpleador { get; set; }
        public string TSucursalTrabajador { get; set; }
        public string TSucursalTrabajadorDireccion { get; set; }
        public string TSucursalTrabajadorTelefono { get; set; }
        public string TSucursalTrabajadorFax { get; set; }
        public string TSucursalTrabajadorZona { get; set; }
        public long IIdubicacionTrabajador { get; set; }
        public long IIdtrabajador { get; set; }
        public long IIdepstrabajador { get; set; }
        public string TTipoIdentificacionTrab { get; set; }
        public string TNumIdentiTrab { get; set; }
        public long IIdtipoVinculaciontrab { get; set; }
        public long IIdcargoTrab { get; set; }
        public string TOcupacionHabitualTrab { get; set; }
        public string TJornadaHabitualTrab { get; set; }
        public string TCodigoOcupacionHabTrab { get; set; }
        public int IOcupacionHabMeses { get; set; }
        public int IOcupacionHabDias { get; set; }
        public int ISalario { get; set; }
        public DateTime DtFechaEvento { get; set; }
        public long IJornada { get; set; }
        public int ITiempoTranscurrAntesEvento { get; set; }
        public bool BInvolucraTrabajador { get; set; }
        public bool BInvolucraPropiedad { get; set; }
        public bool BInvolucraMedioAmb { get; set; }
        public string TDescripcionSuceso { get; set; }
        public bool BTrabajadorLaborHabitual { get; set; }
        public bool BTrabajadorinduccionSaludOcup { get; set; }
        public bool BTrabajadorEntrenamCargo { get; set; }
        public bool BTrabajadorRecibAtencMed { get; set; }
        public bool BTrabajadorElementoProtec { get; set; }
        public long IIdipsantendio { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }
        public string TObservacionesInvestigacion { get; set; }

        public virtual TblMultivalores IIdactividadEconomicaNavigation { get; set; }
        public virtual TblCargos IIdcargoTrabNavigation { get; set; }
        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblEps IIdepstrabajadorNavigation { get; set; }
        public virtual TblMultivalores IIdtipoEventoNavigation { get; set; }
        public virtual TblMultivalores IIdtipoIdentificacionNavigation { get; set; }
        public virtual TblMultivalores IIdtipoVinculaciontrabNavigation { get; set; }
        public virtual TblMultivalores IIdtipoVinculadorNavigation { get; set; }
        public virtual TblEmpleados IIdtrabajadorNavigation { get; set; }
        public virtual TblDivipola IIdubicacionSucEmpleadorNavigation { get; set; }
        public virtual TblDivipola IIdubicacionTrabajadorNavigation { get; set; }
        public virtual TblMultivalores IJornadaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblAtanalisisCausas> TblAtanalisisCausas { get; set; }
        public virtual ICollection<TblAtequiposProteccion> TblAtequiposProteccion { get; set; }
        public virtual ICollection<TblAtinformacionSuceso> TblAtinformacionSuceso { get; set; }
        public virtual ICollection<TblAtmedidasAccionesCorrectivas> TblAtmedidasAccionesCorrectivas { get; set; }
        public virtual ICollection<TblAtmedidasSeguridad> TblAtmedidasSeguridad { get; set; }
        public virtual ICollection<TblAtpartesAfectadas> TblAtpartesAfectadas { get; set; }
        public virtual ICollection<TblAtpersonas> TblAtpersonas { get; set; }
    }
}
