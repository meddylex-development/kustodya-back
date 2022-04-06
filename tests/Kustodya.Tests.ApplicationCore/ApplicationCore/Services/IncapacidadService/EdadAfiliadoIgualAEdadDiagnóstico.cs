using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public class EdadAfiliadoIgualAEdadDiagnostico
    {
        #region Dependency Injection
        private Mock<IAsyncRepository<Incapacidad>> _mockIncapacidadRepo;
        private Mock<IAsyncRepository<Afiliado>> _mockAfiliadoRepo;
        private IncapacidadService _incapacidadService;

        private string incapacidadId;
        private Guid incapacidadNoExistenteId =  Guid.NewGuid();
        private Guid afiliadoId = Guid.NewGuid();
        private Guid afiliadoNoExistenteId = Guid.NewGuid();
        private const Afiliado.TiposAfiliacion cotizante = Afiliado.TiposAfiliacion.Cotizante;
        private const Afiliado.TiposAfiliacion beneficiario = Afiliado.TiposAfiliacion.Beneficiario;
        public EdadAfiliadoIgualAEdadDiagnostico()
        {
            _mockIncapacidadRepo = new Mock<IAsyncRepository<Incapacidad>>();
            _mockAfiliadoRepo = new Mock<IAsyncRepository<Afiliado>>();

            var incapacidad = new Incapacidad() { AfiliadoId = afiliadoId }; incapacidadId = incapacidad.Id.ToString();  _mockIncapacidadRepo.Setup(i => i.GetByIdAsync(incapacidad.Id.ToString())).Returns(Task.Run(() => { return incapacidad; }));
        }
        #endregion

        [Theory]
        [MemberData(nameof(EdadAfiliadoIgualAEdadDiagnosticoTestData.TestData),
            MemberType = typeof(EdadAfiliadoIgualAEdadDiagnosticoTestData))]
        public async Task Deberia_Retornar_LaIgualdadDeEdades(DateTime fechaNacimiento, Diagnostico diagnostico, bool igualdad)
        {
            _mockIncapacidadRepo
                .Setup(i => i.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() =>
                {
                    return new Incapacidad()
                    {
                        AfiliadoId = afiliadoId,
                        Diagnostico = diagnostico
                    };
                }));

            _mockAfiliadoRepo
                .Setup(a => a.GetByIdAsync(afiliadoId))
                .Returns(Task.Run(() => { return new Afiliado() { FechaNacimiento = fechaNacimiento }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = await _incapacidadService.EdadAfiliadoIgualAEdadDiagnostico(incapacidadId);

            Assert.Equal(igualdad, result);
        }

        [Fact]
        public async Task Deberia_RetornarExcepcion_SiElAfiliadoNoExiste()
        {
            _mockIncapacidadRepo
                .Setup(i => i.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() =>
                {
                    return new Incapacidad()
                    {
                        AfiliadoId = afiliadoNoExistenteId
                    };
                }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            await Assert.ThrowsAsync<AfiliadoNotFoundException>(async () => await _incapacidadService.EdadAfiliadoIgualAEdadDiagnostico(incapacidadId));
        }

        [Fact]
        public async Task Deberia_RetornarException_SiLaIncapacidadNoExiste()
        {
            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            await Assert.ThrowsAsync<IncapacidadNotFoundException>(async () => await _incapacidadService.EdadAfiliadoIgualAEdadDiagnostico(incapacidadNoExistenteId.ToString()));
        }

        [Fact]
        public async Task Deberia_RetornarExcepcion_SiIncapacidadNoTieneDatosParaValidar()
        {
            _mockAfiliadoRepo
                .Setup(a => a.GetByIdAsync(afiliadoId))
                .Returns(Task.Run(() => { return new Afiliado() { FechaNacimiento = DateTime.Now.Date }; }));

            _mockIncapacidadRepo
                .Setup(a => a.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() => { return new Incapacidad() { AfiliadoId = afiliadoId, Diagnostico = null }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = _incapacidadService.EdadAfiliadoIgualAEdadDiagnostico(incapacidadId);

            await Assert.ThrowsAsync<SinDatosParaValidarException>(async () => await result);
        }

        [Fact]
        public async Task Deberia_RetornarExcepcion_SiAfiliadoNoTieneDatosParaValidar()
        {
            _mockAfiliadoRepo
                .Setup(a => a.GetByIdAsync(afiliadoId))
                .Returns(Task.Run(() => { return new Afiliado() { FechaNacimiento = null }; }));

            _mockIncapacidadRepo
                .Setup(a => a.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() => { return new Incapacidad() { AfiliadoId = afiliadoId, Diagnostico = new Diagnostico() }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = _incapacidadService.EdadAfiliadoIgualAEdadDiagnostico(incapacidadId);

            await Assert.ThrowsAsync<SinDatosParaValidarException>(async () => await result);
        }
    }
}
