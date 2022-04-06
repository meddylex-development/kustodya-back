using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPerfilSocioDemoEstadoCivil
    {
        public long IIdperfilSocioDemoEstadoCivil { get; set; }
        public long IIdperfilSocioDemo { get; set; }
        public long IIdestadoCivil { get; set; }
        public int CantidadEmpleados { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblMultivalores IIdestadoCivilNavigation { get; set; }
        public virtual TblPerfilSocioDemografico IIdperfilSocioDemoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
