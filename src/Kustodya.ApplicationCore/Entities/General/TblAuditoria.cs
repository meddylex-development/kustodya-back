using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblAuditoria
    {
        public long IIdauditoria { get; set; }
        public string TFormulario { get; set; }
        public string TDescripcion { get; set; }
        public DateTime DtFechaInsercion { get; set; }
        public string TUsuarioInsercion { get; set; }
        public long? IIdempresa { get; set; }
    }
}
