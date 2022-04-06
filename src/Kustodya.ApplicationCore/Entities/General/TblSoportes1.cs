using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblSoportes1
    {
        public long IIdsoporte { get; set; }
        public long IIdjurisprudencia { get; set; }
        public int IIdplataforma { get; set; }
        public string TDirectorio { get; set; }
        public string TNombreArchivo { get; set; }
        public int ITamañoArchivo { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblJurisprudencias IIdjurisprudenciaNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
    }
}
