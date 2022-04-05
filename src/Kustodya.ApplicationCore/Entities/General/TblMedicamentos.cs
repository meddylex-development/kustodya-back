using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblMedicamentos
    {
        public int IIdmedicamento { get; set; }
        public int IIdpais { get; set; }
        public string TExpediente { get; set; }
        public string TProducto { get; set; }
        public string TTitular { get; set; }
        public string TRegistroSanitario { get; set; }
        public DateTime? DtFechaExpedicion { get; set; }
        public DateTime? DtFechaVencimiento { get; set; }
        public string TEstadoRegistro { get; set; }
        public string TExpedienteCum { get; set; }
        public int? IConsecutivo { get; set; }
        public decimal? DCantidadCum { get; set; }
        public string TDescripcionComercial { get; set; }
        public string TEstadoCum { get; set; }
        public DateTime? DtFechaActivo { get; set; }
        public DateTime? DtFechaInactivo { get; set; }
        public string TMuestraMedica { get; set; }
        public string TUnidad { get; set; }
        public string TAtc { get; set; }
        public string TDescripcionAtc { get; set; }
        public string TViaAdministracion { get; set; }
        public string TConcentracion { get; set; }
        public string TPrincipioActivo { get; set; }
        public string TUnidadMedida { get; set; }
        public decimal? DCantidad { get; set; }
        public string TUnidadReferencia { get; set; }
        public string TFormaFarmaceutica { get; set; }
        public string TNombreRol { get; set; }
        public string TTipoRol { get; set; }
        public string TModalidad { get; set; }
        public int? IIdsubtablaInvimaEstado { get; set; }
        public string TValorInvimaEstado { get; set; }
        public int? ILlaveValidacion { get; set; }
        public int? IIdusuarioCreacion { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public bool? BActivo { get; set; }

        public virtual TblMultivalores TblMultivalores { get; set; }
    }
}
