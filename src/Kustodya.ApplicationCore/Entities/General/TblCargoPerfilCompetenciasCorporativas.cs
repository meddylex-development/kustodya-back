using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCargoPerfilCompetenciasCorporativas
    {
        public long IIdperfilCargoCompetenciasCorp { get; set; }
        public long IIdperfilCargo { get; set; }
        public long ICompetenciaCorporativa { get; set; }
        public long INivelRequerido { get; set; }
        public string TObservaciones { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblMultivalores ICompetenciaCorporativaNavigation { get; set; }
        public virtual TblCargoPerfil IIdperfilCargoNavigation { get; set; }
        public virtual TblMultivalores INivelRequeridoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
