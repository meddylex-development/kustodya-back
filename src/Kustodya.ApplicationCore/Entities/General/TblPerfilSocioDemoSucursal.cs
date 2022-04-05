using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPerfilSocioDemoSucursal
    {
        public long IIdperfilSocioDemoSucursal { get; set; }
        public long IIdperfilSocioDemo { get; set; }
        public long IIdsucursal { get; set; }
        public int CantidadEmpleados { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblPerfilSocioDemografico IIdperfilSocioDemoNavigation { get; set; }
        public virtual TblSucursalesEmpresas IIdsucursalNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
