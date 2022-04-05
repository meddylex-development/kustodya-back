using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRecobros
    {
        public TblRecobros()
        {
            TblRecobrosDocumentos = new HashSet<TblRecobrosDocumentos>();
        }

        public int IIdrecobro { get; set; }
        public long? IIdempresaOrigen { get; set; }
        public int? IIdsubtablaTipoRecobro { get; set; }
        public string TValorTipoRecobro { get; set; }
        public int? IIdtipoEmpresaDestino { get; set; }
        public int? IIdempresaDestino { get; set; }
        public int? IIddivipolaOrigen { get; set; }
        public int? IIddivipolaDestino { get; set; }
        public long? IIdrecobroEstado { get; set; }
        public DateTime? DtFechaInicioRecobro { get; set; }
        public DateTime? DtFechaFinRecobro { get; set; }
        public string TObservacionRecobro { get; set; }
        public int? IIdusuarioCreacion { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public bool? BActivo { get; set; }

        public virtual TblEmpresas IIdempresaOrigenNavigation { get; set; }
        public virtual TblRecobroEstados IIdrecobroEstadoNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioModificacionNavigation { get; set; }
        public virtual ICollection<TblRecobrosDocumentos> TblRecobrosDocumentos { get; set; }
    }
}
