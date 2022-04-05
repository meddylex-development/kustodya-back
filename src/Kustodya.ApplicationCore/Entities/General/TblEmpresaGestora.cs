using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresaGestora
    {
        public TblEmpresaGestora()
        {
            TblVendedor = new HashSet<TblVendedor>();
        }

        public long IIdempresaGestora { get; set; }
        public long IIdtipoIdentificacion { get; set; }
        public string TNumeroIdentificacion { get; set; }
        public int? IDigitoVerificacion { get; set; }
        public string TRazonSocial { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }
        public string TUrl { get; set; }

        public virtual TblMultivalores IIdtipoIdentificacionNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblVendedor> TblVendedor { get; set; }
    }
}
