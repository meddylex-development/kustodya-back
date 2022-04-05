using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications
{
    public class PerfilActivoConDetalleSpec : BaseSpec<TblPerfiles>
    {
        public PerfilActivoConDetalleSpec(int id)
                : base(e => e.IIdperfil == id && e.BActivo == true)
        {
            AddInclude(p => p.TblMenuPerfiles);
        }
    }
}
