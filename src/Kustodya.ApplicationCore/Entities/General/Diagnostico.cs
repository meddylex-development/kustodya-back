using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities
{
    public class Diagnostico
    {
        public long Id { get; set; }

        public string ConceptoRehabilitacionId { get; set; }
        //public ConceptoRehabilitacion ConceptoRehabilitacion { get; set; }
        public int Cie10Id { get; set; }
        public TblCie10 TblCie10 { get; set; }
        public DateTime FechaIncapacidad { get; set; }
        public Etiologias Etiologia { get; set; }
    }
}
