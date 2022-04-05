using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCajasCompensacion
    {
        public TblCajasCompensacion()
        {
            TblEmpresasCajasCompensacion = new HashSet<TblEmpresasCajasCompensacion>();
        }

        public long IIdcajaCompensacion { get; set; }
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
        public virtual ICollection<TblEmpresasCajasCompensacion> TblEmpresasCajasCompensacion { get; set; }
    }
}
