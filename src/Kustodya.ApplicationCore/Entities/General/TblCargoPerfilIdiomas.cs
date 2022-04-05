using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCargoPerfilIdiomas
    {
        public long IIdcargoPerfilIdiomas { get; set; }
        public long IIdcargoPerfil { get; set; }
        public long IIdioma { get; set; }
        public long INivelLectura { get; set; }
        public long INivelEscritura { get; set; }
        public long INivelConversacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblCargoPerfil IIdcargoPerfilNavigation { get; set; }
        public virtual TblMultivalores IIdiomaNavigation { get; set; }
        public virtual TblMultivalores INivelConversacionNavigation { get; set; }
        public virtual TblMultivalores INivelEscrituraNavigation { get; set; }
        public virtual TblMultivalores INivelLecturaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
