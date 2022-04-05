using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public class FechaInicioMenorOIgualFechaRadicacion
    {
        #region Dependency Injection
        private Mock<IAsyncRepository<Incapacidad>> _mockIncapacidadRepo;
        private Mock<IAsyncRepository<Afiliado>> _mockAfiliadoRepo;
        private IncapacidadService _incapacidadService;

        private string incapacidadId;
        private const string incapacidadNoExistenteId = "45";
        private Guid afiliadoId = Guid.NewGuid();

        public FechaInicioMenorOIgualFechaRadicacion()
        {
            _mockIncapacidadRepo = new Mock<IAsyncRepository<Incapacidad>>();
            _mockAfiliadoRepo = new Mock<IAsyncRepository<Afiliado>>();

            var incapacidad = new Incapacidad() { AfiliadoId = afiliadoId }; incapacidadId = incapacidad.Id.ToString();  _mockIncapacidadRepo.Setup(i => i.GetByIdAsync(incapacidad.Id.ToString())).Returns(Task.Run(() => { return incapacidad; }));
        }
        #endregion

        [Theory]
        [MemberData(nameof(FechaInicioMenorOIgualFechaRadicacionTestData.TestData),
            MemberType = typeof(FechaInicioMenorOIgualFechaRadicacionTestData))]
        public async Task Deberia_Retornar_TrueSoloSiLaFechaInicioEsMenorAFechaRadicacion(DateTime fechaInicio, DateTime fechaRadicacion, bool fechainicioMayorARadicacion)
        {
            _mockIncapacidadRepo
                .Setup(i => i.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() =>
                {
                    return new Incapacidad()
                    {
                        AfiliadoId = afiliadoId,
                        FechaInicio = fechaInicio,
                        FechaRadicacion = fechaRadicacion
                    };
                }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = await _incapacidadService.FechaInicioMenorOIgualFechaRadicacion(incapacidadId);

            Assert.Equal(fechainicioMayorARadicacion, result);
        }

        [Fact]
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
        }
    }
}
