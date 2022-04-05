using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblFormularios
    {
        public TblFormularios()
        {
            TblFormulariosRespuestasEncabezados = new HashSet<TblFormulariosRespuestasEncabezados>();
        }

        public int IIdformulario { get; set; }
        public int? IIdempresa { get; set; }
        public string TNombreFormulario { get; set; }
        public string TFormulario { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public bool BActivo { get; set; }
        public string TDirectorio { get; set; }
        public string TNombreArchivoOriginal { get; set; }
        public string TNombreArchivo { get; set; }
        public decimal? DTamanoArchivo { get; set; }

        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioModificacionNavigation { get; set; }
        public virtual ICollection<TblFormulariosRespuestasEncabezados> TblFormulariosRespuestasEncabezados { get; set; }
    }
}
