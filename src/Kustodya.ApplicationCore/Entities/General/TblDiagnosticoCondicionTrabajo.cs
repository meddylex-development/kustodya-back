using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblDiagnosticoCondicionTrabajo
    {
        public long IIdcondicionTrabajo { get; set; }
        public long IIdempresa { get; set; }
        public DateTime DtFechaDiagnostico { get; set; }
        public long IProceso { get; set; }
        public long ISucursal { get; set; }
        public long ICargo { get; set; }
        public long IActividades { get; set; }
        public long ITareas { get; set; }
        public bool IRutinarias { get; set; }
        public int IPeligrosCalificacion { get; set; }
        public int IPeligrosDescripcion { get; set; }
        public int IControlFuente { get; set; }
        public int IControlMedio { get; set; }
        public int IControlIndividuo { get; set; }
        public int IEvaluacionDeficiencia { get; set; }
        public int IEvaluacionExposicion { get; set; }
        public string TNivelProbabilidad { get; set; }
        public string TInterpretacionProbabilidad { get; set; }
        public int INivelConsecuencia { get; set; }
        public int INivelRiesgo { get; set; }
        public string TInterpretacionNivelRiesgo { get; set; }
        public string TAceptabilidadRiesgo { get; set; }
        public int INumeroExpuestos { get; set; }
        public string TPeorConsecuencia { get; set; }
        public long IRequisitoLegal { get; set; }
        public string TEliminacion { get; set; }
        public string TSustitucion { get; set; }
        public long IControlIngenieria { get; set; }
        public long IControlAdministrativo { get; set; }
        public long IElementosProteccion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblMultivalores IActividadesNavigation { get; set; }
        public virtual TblCargos ICargoNavigation { get; set; }
        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblJurisprudencias IRequisitoLegalNavigation { get; set; }
        public virtual TblSucursalesEmpresas ISucursalNavigation { get; set; }
        public virtual TblMultivalores ITareasNavigation { get; set; }
    }
}
