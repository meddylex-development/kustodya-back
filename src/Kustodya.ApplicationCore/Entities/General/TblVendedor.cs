using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblVendedor
    {
        public long IIdvendedor { get; set; }
        public long IIdempresaGestora { get; set; }
        public long IIdtipoIdentificacion { get; set; }
        public string TNumeroIdentificacion { get; set; }
        public string TPrimerNombre { get; set; }
        public string TSegundoNombre { get; set; }
        public string TPrimerApellido { get; set; }
        public string TSegundoApellido { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresaGestora IIdempresaGestoraNavigation { get; set; }
        public virtual TblMultivalores IIdtipoIdentificacionNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
