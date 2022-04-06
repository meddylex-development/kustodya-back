using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Xunit;

namespace Kustodya.UnitTests.ApplicationCore.Entities
{
    public class EspecialidadMedicaEsValida
    {
        [Theory]
        [MemberData(nameof(EspecialidadEsValidaTestData.TestData),
            MemberType = typeof(EspecialidadEsValidaTestData))]
        public void Deberia_RetornarTrue_SoloSiElDiagnosticoTieneLaMismaEspecialidad(Incapacidad incapacidad, bool valida)
        {
            var sut = incapacidad.EspecialidadMedicaEsValida();
            Assert.Equal(valida, sut);
        }

        [Theory]
        [MemberData(nameof(EspecialidadEsValidaTestData.NullDataTestData),
            MemberType = typeof(EspecialidadEsValidaTestData))]
        public void Deberia_RetornarExcecion_SiNoTieneDatosParaValidar(Incapacidad incapacidad)
        {
            bool? action() => incapacidad.EspecialidadMedicaEsValida();
            
            Assert.Equal(null, action());
        }
    }
}
