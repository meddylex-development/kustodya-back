using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRecursos
    {
        public long IIdrecurso { get; set; }
        public long IIdempresa { get; set; }
        public long IIdproceso { get; set; }
        public int IIdsubtablaTipoRecurso { get; set; }
        public string TIdvalorTipoRecurso { get; set; }
        public string TDescripcion { get; set; }
        public int ICantidadValor { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblEmpresaProcesos IIdprocesoNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
    }
}
