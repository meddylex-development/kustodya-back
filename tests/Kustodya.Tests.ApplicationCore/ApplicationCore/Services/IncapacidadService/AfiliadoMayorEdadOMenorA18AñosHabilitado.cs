using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Kustodya.ApplicationCore.Constants;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public class AfiliadoMayorEdadOMenorA18AñosHabilitado
    {
        #region Dependency Injection
        private readonly Mock<IAsyncRepository<Incapacidad>> _mockIncapacidadRepo;
        private readonly Mock<IAsyncRepository<Afiliado>> _mockAfiliadoRepo;
        private IncapacidadService _incapacidadService;

        private string incapacidadId;
        private const string incapacidadNoExistenteId = "45";
        private Guid afiliadoId = Guid.NewGuid();
        private Guid afiliadoNoExistenteId = Guid.NewGuid();

        public AfiliadoMayorEdadOMenorA18AñosHabilitado()
        {
            _mockIncapacidadRepo = new Mock<IAsyncRepository<Incapacidad>>();
            _mockAfiliadoRepo = new Mock<IAsyncRepository<Afiliado>>();

            var incapacidad = new Incapacidad() { AfiliadoId = afiliadoId }; incapacidadId = incapacidad.Id.ToString();  _mockIncapacidadRepo.Setup(i => i.GetByIdAsync(incapacidad.Id.ToString())).Returns(Task.Run(() => { return incapacidad; }));
        }
        #endregion

        [Theory]
        [MemberData(nameof(AfiliadoMayorEdadOMenorA18AñosHabilitadoTestData.TestData),
            MemberType = typeof(AfiliadoMayorEdadOMenorA18AñosHabilitadoTestData))]
        public async Task Deberia_RetornarTrueSoloSi_AfiliadoEsMenorde18ConPermisoTrabajo(DateTime fechaNacimiento, bool permisoTrabajo, bool incapacidadValida)
        {
            var incapacidad = new Incapacidad() { AfiliadoId = afiliadoId }; incapacidadId = incapacidad.Id.ToString();  _mockIncapacidadRepo.Setup(i => i.GetByIdAsync(incapacidad.Id.ToString())).Returns(Task.Run(() => { return incapacidad; }));

            _mockAfiliadoRepo
                .Setup(a => a.GetByIdAsync(afiliadoId))
                .Returns(Task.Run(() => { return new Afiliado() { FechaNacimiento = fechaNacimiento, PermisoTrabajo = permisoTrabajo }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = await _incapacidadService.AfiliadoMayorEdadOMenorA18AñosHabilitado(incapacidadId);

            Assert.Equal(incapacidadValida, result);
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

            await Assert.ThrowsAsync<AfiliadoNotFoundException>(async () => await _incapacidadService.AfiliadoMayorEdadOMenorA18AñosHabilitado(incapacidadId));
        }
        
        [Fact]
        public async Task Deberia_RetornarExcepcion_SiAfiliadoesMenorYNoTieneDatosPermiso()
        {
            _mockAfiliadoRepo
                .Setup(a => a.GetByIdAsync(afiliadoId))
                .Returns(Task.Run(() => { return new Afiliado() { FechaNacimiento = DateTime.Now.AddYears(-17), PermisoTrabajo = null }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = _incapacidadService.AfiliadoMayorEdadOMenorA18AñosHabilitado(incapacidadId);

            await Assert.ThrowsAsync<SinDatosParaValidarException>(async () => await result);
        }

        [Fact]
        public async Task NoDeberia_RetornarExcepcion_SiAfiliadoNoEsMenorYNoTieneDatosPermiso()
        {
            _mockAfiliadoRepo
                .Setup(a => a.GetByIdAsync(afiliadoId))
                .Returns(Task.Run(() => { return new Afiliado() { FechaNacimiento = DateTime.Now.AddYears(-18), PermisoTrabajo = null }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = await _incapacidadService.AfiliadoMayorEdadOMenorA18AñosHabilitado(incapacidadId);
        }
    }
}
