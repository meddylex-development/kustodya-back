using System;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Interfaces;
using Moq;
using Xunit;

namespace Kustodya.UnitTests.ApplicationCore.Entities
{
    public class FechaInicioMenorOIgualFechaRadicacion
    {
        private string incapacidadId;
        private const string incapacidadNoExistenteId = "45";
        private Guid afiliadoId = Guid.NewGuid();

        [Theory]
        [FechaInicioMenorOIgualFechaRadicacionTestData]
        public void Deberia_Retornar_TrueSoloSiLaFechaInicioEsMenorAFechaRadicacion(Incapacidad incapacidad, bool valida)
        {
            var sut = incapacidad;
            Assert.Equal(incapacidad.FechaInicioMenorOIgualFechaRadicacion(), valida);
        }

        /*[Fact]
        public async Task Deberia_RetornarException_SiLaIncapacidadNoExiste()
        {
            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            await Assert.ThrowsAsync<IncapacidadNotFoundException>(async () => await _incapacidadService.FechaInicioMenorOIgualFechaRadicacion(incapacidadNoExistenteId));
        }

        [Fact]
        public async Task Deberia_RetornarExcepcion_SiIncapacidadNoTieneFechaInicio()
        {
            _mockIncapacidadRepo
                .Setup(a => a.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() => { return new Incapacidad() { AfiliadoId = afiliadoId, FechaInicio = null, FechaRadicacion = DateTime.Now }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = _incapacidadService.FechaInicioMenorOIgualFechaRadicacion(incapacidadId);

            await Assert.ThrowsAsync<SinDatosParaValidarException>(async () => await result);
        }

        [Fact]
        public async Task Deberia_RetornarExcepcion_SiIncapacidadNoTieneFechaRadicacion()
        {
            _mockIncapacidadRepo
                .Setup(a => a.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() => { return new Incapacidad() { AfiliadoId = afiliadoId, FechaRadicacion = null, FechaInicio = DateTime.Now }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = _incapacidadService.FechaInicioMenorOIgualFechaRadicacion(incapacidadId);

            await Assert.ThrowsAsync<SinDatosParaValidarException>(async () => await result);
        }*/
    }
}
