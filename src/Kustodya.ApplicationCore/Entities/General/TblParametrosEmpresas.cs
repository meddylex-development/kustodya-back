using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblParametrosEmpresas
    {
        public short IIdparametro { get; set; }
        public string TIdentificador { get; set; }
        public string TDescripcion { get; set; }
        public string TValor { get; set; }
        public long? IIdempresa { get; set; }
    }
}
