using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCie10
    {
        public TblCie10()
        {
            TblCie10DiagnosticoIncapacidad = new HashSet<TblCie10DiagnosticoIncapacidad>();
            TblCodigosCorrelacion = new HashSet<TblCodigosCorrelacion>();
        }

        public int IIdcie10 { get; set; }
        public string TCie10 { get; set; }
        public string TDescripcion { get; set; }
        public string TCapitulo { get; set; }
        public string TTituloCapitulo { get; set; }
        public string TCaracter { get; set; }
        public string TCategoria { get; set; }
        public string TCie { get; set; }
        public int IDiasMaxConsulta { get; set; }
        public int IDiasMaxAcumulados { get; set; }
        public int? IIdtipoCie { get; set; }
        public long? IIdsexo { get; set; }
 
        public virtual TblMultivalores IIdsexoNavigation { get; set; }
        public virtual TblTipoCie IIdtipoCieNavigation { get; set; }
        public virtual ICollection<TblCie10DiagnosticoIncapacidad> TblCie10DiagnosticoIncapacidad { get; set; }
        public virtual ICollection<TblCodigosCorrelacion> TblCodigosCorrelacion { get; set; }
    }
}
