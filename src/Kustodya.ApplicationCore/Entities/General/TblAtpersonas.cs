using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblAtpersonas
    {
        public long IIdpersona { get; set; }
        public long IIdaccidenteTrabajo { get; set; }
        public int IIdsubtablaTipoPersona { get; set; }
        public string TValorTipoPersona { get; set; }
        public string TNombre { get; set; }
        public string TCargo { get; set; }
        public bool BLicenciaSo { get; set; }
        public string TNumeroLicSo { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblAccidentesTrabajo IIdaccidenteTrabajoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
