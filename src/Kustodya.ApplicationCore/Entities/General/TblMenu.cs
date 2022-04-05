using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblMenu
    {
        public TblMenu()
        {
            TblMenuPerfiles = new HashSet<TblMenuPerfiles>();
        }

        public int IIdmenu { get; set; }
        public string TDescripcion { get; set; }
        public int? IIdpadre { get; set; }
        public int IPosicion { get; set; }
        public bool BActivo { get; set; }
        public string Url { get; set; }
        public int? IPosicionPadre { get; set; }
        public string Icon { get; set; }

        public bool EsReporte { get; set; }
        public Guid ReporteId { get; set; }
        public Guid ReporteGroupId { get; set; }

        public virtual ICollection<TblMenuPerfiles> TblMenuPerfiles { get; set; }
    }
}
