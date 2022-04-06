using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.General
{
    public class DescripcionSecuelas
    {
        public long Id { get; set; }
        public string ConceptoRehabilitacionId { get; set; }
        //public ConceptoRehabilitacion ConceptoRehabilitacion { get; set; }
        public TipoSecuelas TipoSecuelas { get; set; }
        public string Descripcion { get; set; }
        public Pronosticos Pronosticos { get; set; }

    }
}
