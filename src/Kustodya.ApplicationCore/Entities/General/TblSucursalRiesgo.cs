using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblSucursalRiesgo
    {
        public long IIdsucursal { get; set; }
        public long IIdclaseRiesgo { get; set; }
        public int IIdcodigoRiesgo { get; set; }
        public bool BActivo { get; set; }

        public virtual TblMultivalores IIdclaseRiesgoNavigation { get; set; }
        public virtual TblSucursalesEmpresas IIdsucursalNavigation { get; set; }
    }
}
