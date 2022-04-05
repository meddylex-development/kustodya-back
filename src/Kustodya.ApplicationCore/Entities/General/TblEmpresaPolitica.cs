using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresaPolitica
    {
        public TblEmpresaPolitica()
        {
            TblEmpresaPoliticaControlCambios = new HashSet<TblEmpresaPoliticaControlCambios>();
        }

        public long IIdempresaPolitica { get; set; }
        public long IIdempresa { get; set; }
        public long IidtipoPolitica { get; set; }
        public string TPolitica { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblMultivalores IidtipoPoliticaNavigation { get; set; }
        public virtual ICollection<TblEmpresaPoliticaControlCambios> TblEmpresaPoliticaControlCambios { get; set; }
    }
}
