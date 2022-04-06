using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCargoPerfilCompetenciasFuncionales
    {
        public long IIdcargoPerfilCompetenciasFunc { get; set; }
        public long IIdcargoPerfil { get; set; }
        public long ICompetenciaFuncional { get; set; }
        public long INivelRequerido { get; set; }
        public string TObservaciones { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblMultivalores ICompetenciaFuncionalNavigation { get; set; }
        public virtual TblCargoPerfil IIdcargoPerfilNavigation { get; set; }
        public virtual TblMultivalores INivelRequeridoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
