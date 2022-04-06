using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCie
    {
        public TblCie()
        {
            TblCiedetalle = new HashSet<TblCiedetalle>();
        }

        public decimal IdCie { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public decimal? Actualizacion { get; set; }
        public string Modificacion { get; set; }
        public bool? Asterisco { get; set; }
        public decimal? Sexo { get; set; }
        public decimal? LimiteInferiorEscala { get; set; }
        public decimal? LimiteInferiorTiempo { get; set; }
        public decimal? LimiteSuperiorEscala { get; set; }
        public decimal? LimiteSuperiorTiempo { get; set; }
        public bool? Trivial { get; set; }
        public bool? NoDefuncion { get; set; }
        public bool? Fetal { get; set; }
        public decimal? Lista1 { get; set; }
        public decimal? Lista2 { get; set; }
        public decimal? Lista3 { get; set; }
        public decimal? Lista4 { get; set; }
        public decimal? ListaGbd { get; set; }
        public decimal? ListaBecker { get; set; }
        public decimal? ListaOps { get; set; }
        public decimal? ListaCpu { get; set; }
        public decimal? OpcionA { get; set; }
        public decimal? OpcionB { get; set; }
        public decimal? OpcionC { get; set; }
        public decimal? ListaCsemm { get; set; }

        public virtual TblListaDetalle Lista1Navigation { get; set; }
        public virtual TblListaDetalle Lista2Navigation { get; set; }
        public virtual TblListaDetalle Lista3Navigation { get; set; }
        public virtual TblListaDetalle Lista4Navigation { get; set; }
        public virtual TblListaDetalle ListaBeckerNavigation { get; set; }
        public virtual TblListaDetalle ListaCpuNavigation { get; set; }
        public virtual TblListaDetalle ListaCsemmNavigation { get; set; }
        public virtual TblListaDetalle ListaGbdNavigation { get; set; }
        public virtual TblListaDetalle ListaOpsNavigation { get; set; }
        public virtual ICollection<TblCiedetalle> TblCiedetalle { get; set; }
    }
}
