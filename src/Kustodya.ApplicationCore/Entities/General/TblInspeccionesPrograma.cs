using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblInspeccionesPrograma
    {
        public long IIdinspeccionPrograma { get; set; }
        public long IIdempresa { get; set; }
        public long IIdvigencia { get; set; }
        public long IIdarea { get; set; }
        public DateTime DtFechaInspeccion { get; set; }
        public int IIdsubtablaTipoInspeccion { get; set; }
        public string TIdvalorTipoInspeccion { get; set; }
        public bool BTipoResponsable { get; set; }
        public long IIdresponsable { get; set; }
        public long IIdtarea { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresaArea IIdareaNavigation { get; set; }
        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblTareas IIdtareaNavigation { get; set; }
        public virtual TblEmpresasVigencia IIdvigenciaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
