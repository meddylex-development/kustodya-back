using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPerfilSocioDemoTipoVincul
    {
        public long IIdperfilSocioDemoTipoVincul { get; set; }
        public long IIdperfilSocioDemo { get; set; }
        public long IIdtipoVinculacion { get; set; }
        public int CantidadEmpleados { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblPerfilSocioDemografico IIdperfilSocioDemoNavigation { get; set; }
        public virtual TblMultivalores IIdtipoVinculacionNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
