using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresasTerceros
    {
        public long IId { get; set; }
        public long INit { get; set; }
        public string TRazonSocial { get; set; }
        public string TDireccion { get; set; }
        public string TObjetoSocial { get; set; }
        public short? IIdactividadEconomica { get; set; }
        public byte? IIdtipoSociedad { get; set; }

        public virtual TblActividadEconomica IIdactividadEconomicaNavigation { get; set; }
        public virtual TblTipoSociedadEmpresa IIdtipoSociedadNavigation { get; set; }
    }
}
