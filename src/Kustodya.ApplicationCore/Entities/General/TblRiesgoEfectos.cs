using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRiesgoEfectos
    {
        public long IIdriesgoEfecto { get; set; }
        public long IIdriesgoIdentificacion { get; set; }
        public string TEfecto { get; set; }
        public DateTime DtFechaInsercion { get; set; }
        public int IUsuarioInsercion { get; set; }
        public bool? BActivo { get; set; }

        public virtual TblUsuarios IUsuarioInsercionNavigation { get; set; }
    }
}
