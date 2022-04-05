using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Concepto
{
    public class Diagnostico
    {
        public long Id { get; set; }
        public long ConceptoRehabilitacionId { get; set; }
        public int  Cie10Id { get; set; }
        public DateTime FechaIncapacidad { get; set; }
        public TipoEtiologia Etiologia { get; set; }
        public TblCie10 Cie10 { get; set; }
        public ConceptoRehabilitacion Concepto { get; set; }

        public enum TipoEtiologia : int { 
            Autoinmune = 1,
            Congénita = 2,
            Cardiovascular = 3,
            Degenerativa = 4,
            Inflamatoria = 5,
            Mental = 6,
            Metabólica = 7,
            Neoplásica = 8,
            Traumática = 9,
            Vascular = 10
        }
        public string ObtenerDescripcion() {
            return Cie10.TCie10;
        }
    }
}
