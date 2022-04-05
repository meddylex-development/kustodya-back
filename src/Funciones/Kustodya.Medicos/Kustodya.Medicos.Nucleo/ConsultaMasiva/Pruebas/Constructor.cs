using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kustodya.Medicos.Nucleo.PruebasConsultaMasiva
{
    public class Constructor
    {
        [Fact]
        public void Deberia_Arrojar_Excepcion_Si_No_Tiene_Registros()
        {
            // Configuración
            Func<ConsultaMasiva> sbp = () => new ConsultaMasiva(new List<Registro>());
            // Ejecución
            // Afirmación
            Assert.Throws<ArgumentException>("registros", sbp);
        }
    }
}
