using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kustodya.UnitTests.ApplicationCore.Services;
using Xunit;

namespace Kustodya.UnitTests.ApplicationCore.Entities
{
    public class UbicacionCorrespondeConAfiliado
    {
        [Theory]
        [MemberData(nameof(UbicacionCorrespondeConAfiliadoTestData.TestData),
            MemberType = typeof(UbicacionCorrespondeConAfiliadoTestData))]
        public void Deberia_RetornarTrue_SoloSiElDiagnosticoTieneLaMismaEspecialidad(Incapacidad incapacidad, bool valida)
        {
            var sut = incapacidad.UbicacionCorresponConAfiliado();
            Assert.Equal(valida, sut);
        }

        [Theory]
        [MemberData(nameof(UbicacionCorrespondeConAfiliadoTestData.NullDataTestData),
            MemberType = typeof(UbicacionCorrespondeConAfiliadoTestData))]
        public void Deberia_RetornarExcecion_SiNoTieneDatosParaValidar(Incapacidad incapacidad)
        {
            Assert.Equal(null, incapacidad.UbicacionCorresponConAfiliado());
        }
    }
}
