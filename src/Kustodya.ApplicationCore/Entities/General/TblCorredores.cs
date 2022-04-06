using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCorredores
    {
        public TblCorredores()
        {
            TblEmpresasCorredores = new HashSet<TblEmpresasCorredores>();
        }

        public int IIdcorredor { get; set; }
        public string TNombre { get; set; }
        public string TCodigoExterno { get; set; }
        public long? IIdtipoIdentificacion { get; set; }
        public string TNumeroIdentificacion { get; set; }
        public int? TDigitoVerificacion { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblMultivalores IIdtipoIdentificacionNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblEmpresasCorredores> TblEmpresasCorredores { get; set; }
    }
}
