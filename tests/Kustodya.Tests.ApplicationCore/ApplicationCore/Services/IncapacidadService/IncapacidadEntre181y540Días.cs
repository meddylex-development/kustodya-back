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
    public class IncapacidadEntre181y540Dias
    {
        #region Dependency Injection
        private Mock<IAsyncRepository<Incapacidad>> _mockIncapacidadRepo;
        private Mock<IAsyncRepository<Afiliado>> _mockAfiliadoRepo;
        private IncapacidadService _incapacidadService;

        private string incapacidadId;
        private const string incapacidadNoExistenteId = "45";
        private Guid afiliadoId = Guid.NewGuid();
        private Guid afiliadoNoExistenteId = Guid.NewGuid();
        private const Afiliado.TiposAfiliacion cotizante = Afiliado.TiposAfiliacion.Cotizante;
        private const Afiliado.TiposAfiliacion beneficiario = Afiliado.TiposAfiliacion.Beneficiario;

        public IncapacidadEntre181y540Dias()
        {
            _mockIncapacidadRepo = new Mock<IAsyncRepository<Incapacidad>>();
            _mockAfiliadoRepo = new Mock<IAsyncRepository<Afiliado>>();

            var incapacidad = new Incapacidad() { AfiliadoId = afiliadoId }; incapacidadId = incapacidad.Id.ToString();  _mockIncapacidadRepo.Setup(i => i.GetByIdAsync(incapacidad.Id.ToString())).Returns(Task.Run(() => { return incapacidad; }));
        }
        #endregion

        [Theory]
        [MemberData(nameof(IncapacidadEntre181y540DiasTestData.TestData),
            MemberType = typeof(IncapacidadEntre181y540DiasTestData))]
        public async Task Deberia_Retornar_TrueSoloSiLaIncapacidadEstaEntr181y540Dias(DateTime fechaInicio, DateTime fechaFin, bool mayorA2Dias)
        {
            _mockIncapacidadRepo
                .Setup(i => i.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() =>
                {
                    return new Incapacidad()
                    {
                        AfiliadoId = afiliadoId,
                        FechaInicio = fechaInicio,
                        FechaFin = fechaFin
                    };
                }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = await _incapacidadService.IncapacidadEntre181y540Dias(incapacidadId);

            Assert.Equal(mayorA2Dias, result);
        }

        [Fact]
        public async Task Deberia_RetornarException_SiLaIncapacidadNoExiste()
        {
            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            await Assert.ThrowsAsync<IncapacidadNotFoundException>(async () => await _incapacidadService.IncapacidadEntre181y540Dias(incapacidadNoExistenteId));
        }

        [Fact]
        public async Task Deberia_RetornarExcepcion_SiIncapacidadNoTieneFechaInicio()
        {
            _mockIncapacidadRepo
                .Setup(a => a.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() => { return new Incapacidad() { AfiliadoId = afiliadoId, FechaInicio = null }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = _incapacidadService.IncapacidadEntre181y540Dias(incapacidadId);

            await Assert.ThrowsAsync<SinDatosParaValidarException>(async () => await result);
        }

        [Fact]
        public async Task Deberia_RetornarExcepcion_SiIncapacidadNoTieneFechaFin()
        {
            _mockIncapacidadRepo
                .Setup(a => a.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() => { return new Incapacidad() { AfiliadoId = afiliadoId, FechaFin = null }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = _incapacidadService.IncapacidadEntre181y540Dias(incapacidadId);

            await Assert.ThrowsAsync<SinDatosParaValidarException>(async () => await result);
        }
    }
}
