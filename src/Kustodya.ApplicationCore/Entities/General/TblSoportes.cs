using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblSoportes
    {
        public long IIdsoporte { get; set; }
        public long IIdempresa { get; set; }
        public int IIdplataforma { get; set; }
        public long IIdclaseSoporte { get; set; }
        public long IIddocumento { get; set; }
        public long IIdtipoDocumento { get; set; }
        public string TDirectorio { get; set; }
        public string TNombreArchivo { get; set; }
        public int ITamañoArchivo { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblMultivalores IIdclaseSoporteNavigation { get; set; }
        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblMultivalores IIdtipoDocumentoNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
    }
}
