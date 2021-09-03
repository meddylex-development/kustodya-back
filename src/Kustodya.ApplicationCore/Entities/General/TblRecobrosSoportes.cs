using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRecobrosSoportes
    {
        public int IIdrecobroSoporte { get; set; }
        public int? IIdrecobro { get; set; }
        public int? IIdsubtablaTipoSoporte { get; set; }
        public string TValorTipoSoporte { get; set; }
        public string TDirectorio { get; set; }
        public string TNombreArchivoOriginal { get; set; }
        public string TNombreArchivo { get; set; }
        public decimal? ITamanoArchivo { get; set; }
        public int? IIdusuarioCreacion { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public bool? BActivo { get; set; }
    }
}
