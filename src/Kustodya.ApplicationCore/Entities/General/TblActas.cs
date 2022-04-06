using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblActas
    {
        public long IIdacta { get; set; }
        public long IIdempresa { get; set; }
        public long IIdclaseActa { get; set; }
        public long IIdtipoActa { get; set; }
        public DateTime DtFechaActa { get; set; }
        public int INumeroActa { get; set; }
        public string TContenido { get; set; }
        public int IUsuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblMultivalores IIdclaseActaNavigation { get; set; }
        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblMultivalores IIdtipoActaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
