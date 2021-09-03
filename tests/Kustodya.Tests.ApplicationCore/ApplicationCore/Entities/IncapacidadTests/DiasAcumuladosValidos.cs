using Kustodya.ApplicationCore.Entities.MallaValidadora;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kustodya.UnitTests.ApplicationCore.Entities.IncapacidadTests
{
    public class DiasAcumuladosValidos
    {
        [Theory]
        [DiasAcumuladosValidosTestData]
        public void EsTrue_SoloSi_DiasAcumuladosMenorOIgualADiasMaxDiagnostico(Incapacidad incapacidad, bool valido)
        {
            var sut = incapacidad.DiasAcumuladosValidos();
            Assert.Equal(valido, sut);
        }

        [Theory]
        [DiasAcumuladosValidosNullTestData]
        public void ThrowsSinDatosParaValidarException_Si_NoHaySuficientesDatosParaValidar(Incapacidad incapacidad)
        {
            bool? action() => incapacidad.DiasAcumuladosValidos();
            
            Assert.Equal(null, action());
        }
    }
}
