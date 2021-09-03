using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPerfilSocioDemoEdad
    {
        public long IIdperfilSocioDemoEdad { get; set; }
        public long IIdperfilSocioDemo { get; set; }
        public string TRangoEdad { get; set; }
        public long IIdgenero { get; set; }
        public int CantidadEmpleados { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblMultivalores IIdgeneroNavigation { get; set; }
        public virtual TblPerfilSocioDemografico IIdperfilSocioDemoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
