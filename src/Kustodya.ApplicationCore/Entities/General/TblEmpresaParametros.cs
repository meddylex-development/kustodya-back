using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresaParametros
    {
        public long IIdempresaParametro { get; set; }
        public long IIdempresa { get; set; }
        public int IIdcampo { get; set; }
        public string TDescripcion { get; set; }
        public string TTipo { get; set; }
        public int? IValor { get; set; }
        public DateTime? DtFecha { get; set; }
        public string TTexto { get; set; }
        public int IUsuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
