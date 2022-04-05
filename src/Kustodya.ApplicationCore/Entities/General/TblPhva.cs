using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPhva
    {
        public long IIdphva { get; set; }
        public long IIdempresa { get; set; }
        public long IIdproceso { get; set; }
        public int IIdsubtablaTipoPhva { get; set; }
        public string TIdvalorTipoPhva { get; set; }
        public string TActividad { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblEmpresaProcesos IIdprocesoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
