using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblTipoSociedadEmpresa
    {
        public TblTipoSociedadEmpresa()
        {
            TblEmpresasTerceros = new HashSet<TblEmpresasTerceros>();
        }

        public byte IId { get; set; }
        public string TNombre { get; set; }

        public virtual ICollection<TblEmpresasTerceros> TblEmpresasTerceros { get; set; }
    }
}
