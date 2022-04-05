using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCargoPerfilNivelAcademico
    {
        public long IIdcargoPerfilNivAcad { get; set; }
        public long IIdcargoPerfil { get; set; }
        public long IIdnivelAcademico { get; set; }
        public long ICarrera { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblCargoPerfil IIdcargoPerfilNavigation { get; set; }
        public virtual TblMultivalores IIdnivelAcademicoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
