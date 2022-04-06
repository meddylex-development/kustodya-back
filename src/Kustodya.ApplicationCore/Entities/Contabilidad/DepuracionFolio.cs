using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Contabilidades
{
    public class DepuracionFolio : BaseEntity
    { 
        public Guid DepuracionId { get; set; }
        public Guid FolioId { get; set; }
        public Folio Folio { get; set; }
        public DepuracionContable DepuracionContable { get; set; }
    }
}
