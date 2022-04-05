using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Kustodya.ApplicationCore.Constants;
using Moq;
using Xunit;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public class SexoAfiliadoIgualASexoDiagnostico
    {
        #region Dependency Injection
        private Mock<IAsyncRepository<Incapacidad>> _mockIncapacidadRepo;
        private Mock<IAsyncRepository<Afiliado>> _mockAfiliadoRepo;
        private IncapacidadService _incapacidadService;

        private string incapacidadId;
        private const string incapacidadNoExistenteId = "45";
        private Guid afiliadoId = Guid.NewGuid();
        private Guid afiliadoNoExistenteId = Guid.NewGuid();
        
        public SexoAfiliadoIgualASexoDiagnostico()
        {
            _mockIncapacidadRepo = new Mock<IAsyncRepository<Incapacidad>>();
            _mockAfiliadoRepo = new Mock<IAsyncRepository<Afiliado>>();

            var incapacidad = new Incapacidad() { AfiliadoId = afiliadoId }; incapacidadId = incapacidad.Id.ToString();  _mockIncapacidadRepo.Setup(i => i.GetByIdAsync(incapacidad.Id.ToString())).Returns(Task.Run(() => { return incapacidad; }));
        }
        #endregion

        [Theory]
        [MemberData(nameof(SexoAfiliadoIgualASexoDiagnosticoTestData.TestData),
            MemberType = typeof(SexoAfiliadoIgualASexoDiagnosticoTestData))]
        public async Task Deberia_Retornar_LaIgualdadDeSexos(Sexos sexoIncapacidad, Diagnostico diagnostico, bool valido)
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
                .Returns(Task.Run(() => { return new Afiliado() { Sexo = sexoIncapacidad }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = await _incapacidadService.SexoAfiliadoIgualSexoDiagnostico(incapacidadId);

            Assert.Equal(result, valido);
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

            await Assert.ThrowsAsync<AfiliadoNotFoundException>(async () => await _incapacidadService.SexoAfiliadoIgualSexoDiagnostico(incapacidadId));
        }
        [Fact]
        public async Task Deberia_RetornarException_SiLaIncapacidadNoExiste()
        {
            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            await Assert.ThrowsAsync<IncapacidadNotFoundException>(async () => await _incapacidadService.SexoAfiliadoIgualSexoDiagnostico(incapacidadNoExistenteId));
        }
        [Fact]
        public async Task Deberia_RetornarExcepcion_SiAfiliadoNoTieneDatosParaValidar()
        {
            _mockIncapacidadRepo
                .Setup(a => a.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() => { return new Incapacidad() { AfiliadoId = afiliadoId }; }));

            _mockAfiliadoRepo
                .Setup(a => a.GetByIdAsync(afiliadoId))
                .Returns(Task.Run(() => { return new Afiliado { Id = afiliadoId, Sexo = null }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = _incapacidadService.SexoAfiliadoIgualSexoDiagnostico(incapacidadId);

            await Assert.ThrowsAsync<SinDatosParaValidarException>(async () => await result);
        }
        [Fact]
        public async Task Deberia_RetornarExcepcion_SiLaIncapacidadNoTieneDatosParaValidar()
        {
            _mockIncapacidadRepo
                .Setup(a => a.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() => { return new Incapacidad() { AfiliadoId = afiliadoId }; }));

            _mockAfiliadoRepo
                .Setup(a => a.GetByIdAsync(afiliadoId))
                .Returns(Task.Run(() => { return new Afiliado { Id = afiliadoId, Sexo = Sexos.Masculino }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = _incapacidadService.SexoAfiliadoIgualSexoDiagnostico(incapacidadId);

            await Assert.ThrowsAsync<SinDatosParaValidarException>(async () => await result);
        }
    }
}
