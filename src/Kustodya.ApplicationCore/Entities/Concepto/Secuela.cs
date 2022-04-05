using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Concepto
{
    public class Secuela
    {
        public int Id { get; set; }
        public long ConceptoRehabilitacionId { get; set; }
        public TipoSecuela Tipo { get; set; }
        public string Descripcion { get; set; }
        public TipoPronostico Pronostico { get; set; }
        public ConceptoRehabilitacion Concepto { get; set; }
        public enum TipoSecuela : int { 
            Anatómica = 1,
            Funcional = 2
        }
        public enum TipoPronostico : int
        {
            Bueno = 1,
            Regular = 2,
            Malo = 3
        }
    }
}
