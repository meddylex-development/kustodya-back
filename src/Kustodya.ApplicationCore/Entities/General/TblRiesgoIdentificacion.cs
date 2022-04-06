using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRiesgoIdentificacion
    {
        public TblRiesgoIdentificacion()
        {
            TblRiesgoResidual = new HashSet<TblRiesgoResidual>();
        }

        public long IIdriesgoIdentificacion { get; set; }
        public long IIdempresa { get; set; }
        public long IIdproceso { get; set; }
        public string TNombreRiesgo { get; set; }
        public string TDescripcionRiesgo { get; set; }
        public int IIdsubtablaTipoRiesgo { get; set; }
        public string TIdvalorTipoRiesgo { get; set; }
        public string TDescripcionAgente { get; set; }
        public DateTime DtFechaInsercion { get; set; }
        public int IUsuarioInsercion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblEmpresaProcesos IIdprocesoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioInsercionNavigation { get; set; }
        public virtual ICollection<TblRiesgoResidual> TblRiesgoResidual { get; set; }
    }
}
