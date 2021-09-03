using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Xunit;

namespace Kustodya.UnitTests.ApplicationCore.Entities
{
    public class DiasCorrespondenConDiagnostico
    {
        [Theory]
        [MemberData(nameof(DiasCorrespondenConDiagnosticoTestData.TestData),
            MemberType = typeof(DiasCorrespondenConDiagnosticoTestData))]
        public void Deberia_RetornarTrue_SoloSiElDiagnosticoTieneLaMismaEspecialidad(Incapacidad incapacidad, bool valida)
        {
            var sut = incapacidad.DiasCorrespondenConDiagnostico();
            Assert.Equal(valida, sut);
        }

        [Theory]
        [MemberData(nameof(DiasCorrespondenConDiagnosticoTestData.NullDataTestData),
            MemberType = typeof(DiasCorrespondenConDiagnosticoTestData))]
        public void Deberia_RetornarExcepcion_SiNoTieneDatosParaValidar(Incapacidad incapacidad)
        {
            bool? action() => incapacidad.DiasCorrespondenConDiagnostico();
            Assert.Equal(null, action());
        }
    }
}
