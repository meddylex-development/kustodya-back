using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblClasificacionRiesgos
    {
        public TblClasificacionRiesgos()
        {
            TblEmpresaProcesoRiesgos = new HashSet<TblEmpresaProcesoRiesgos>();
        }

        public long IIdclasificacionRiesgo { get; set; }
        public int IIdarea { get; set; }
        public string TNombreArea { get; set; }
        public int IIdtipoRiesgo { get; set; }
        public string TNombreRiesgo { get; set; }
        public int IIdriesgo { get; set; }
        public string TRiesgo { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblEmpresaProcesoRiesgos> TblEmpresaProcesoRiesgos { get; set; }
    }
}
