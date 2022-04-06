using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCargoPerfilFuncionesAmbientales
    {
        public long IIdcargoPerfilFuncionAmbi { get; set; }
        public long IIdcargoPerfil { get; set; }
        public long IFuncionAmbiental { get; set; }
        public long IPeriodicidad { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblMultivalores IFuncionAmbientalNavigation { get; set; }
        public virtual TblCargoPerfil IIdcargoPerfilNavigation { get; set; }
        public virtual TblMultivalores IPeriodicidadNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
