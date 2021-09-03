using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresaRiesgoValoracion
    {
        public long IIdriesgoValoracion { get; set; }
        public int IAlcanceMapa { get; set; }
        public long IIdempresa { get; set; }
        public int IValoracionRiesgo { get; set; }
        public int IIdvaloracion { get; set; }
        public string TValoracion { get; set; }
        public int? IValorInferior { get; set; }
        public int? IValorSuperior { get; set; }
        public string TColor { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
