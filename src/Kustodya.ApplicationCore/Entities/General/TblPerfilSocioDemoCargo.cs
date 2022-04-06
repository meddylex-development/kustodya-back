using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPerfilSocioDemoCargo
    {
        public long IIdperfilSocioDemoCargo { get; set; }
        public long IIdperfilSocioDemo { get; set; }
        public long IIdcargo { get; set; }
        public int CantidadEmpleados { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblCargos IIdcargoNavigation { get; set; }
        public virtual TblPerfilSocioDemografico IIdperfilSocioDemoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
