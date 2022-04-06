using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblListaDetalle
    {
        public TblListaDetalle()
        {
            TblCieLista1Navigation = new HashSet<TblCie>();
            TblCieLista2Navigation = new HashSet<TblCie>();
            TblCieLista3Navigation = new HashSet<TblCie>();
            TblCieLista4Navigation = new HashSet<TblCie>();
            TblCieListaBeckerNavigation = new HashSet<TblCie>();
            TblCieListaCpuNavigation = new HashSet<TblCie>();
            TblCieListaCsemmNavigation = new HashSet<TblCie>();
            TblCieListaGbdNavigation = new HashSet<TblCie>();
            TblCieListaOpsNavigation = new HashSet<TblCie>();
        }

        public decimal IdListaDetalle { get; set; }
        public decimal? Lista { get; set; }
        public string Grupo { get; set; }
        public string DescripcionEsp { get; set; }
        public string Codigos { get; set; }
        public string DescripcionIng { get; set; }

        public virtual ICollection<TblCie> TblCieLista1Navigation { get; set; }
        public virtual ICollection<TblCie> TblCieLista2Navigation { get; set; }
        public virtual ICollection<TblCie> TblCieLista3Navigation { get; set; }
        public virtual ICollection<TblCie> TblCieLista4Navigation { get; set; }
        public virtual ICollection<TblCie> TblCieListaBeckerNavigation { get; set; }
        public virtual ICollection<TblCie> TblCieListaCpuNavigation { get; set; }
        public virtual ICollection<TblCie> TblCieListaCsemmNavigation { get; set; }
        public virtual ICollection<TblCie> TblCieListaGbdNavigation { get; set; }
        public virtual ICollection<TblCie> TblCieListaOpsNavigation { get; set; }
    }
}
