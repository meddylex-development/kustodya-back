using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblDiagnosticoInicial
    {
        public long IIdempresa { get; set; }
        public long IIdestandar { get; set; }
        public int IVersion { get; set; }
        public DateTime DtFechaDiagnostico { get; set; }
        public string TPregunta { get; set; }
        public bool BCumple { get; set; }
        public bool BNoCumple { get; set; }
        public bool BNoAplica { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblMultivalores IIdestandarNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
    }
}
