using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Entities.Administracion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Administracion
{
    public class EntidadPorTipoidyNumIdyNombreCompaniaSpec : BaseSpec<Entidad>
    {
        
        public EntidadPorTipoidyNumIdyNombreCompaniaSpec(TipoIdentificacion tipoId, string numId, string nombreCompania)
                : base(u => (u.TipoId == tipoId  && u.NumeroId == numId && u.NombreCompania == nombreCompania))
        {
        }
    }
}
