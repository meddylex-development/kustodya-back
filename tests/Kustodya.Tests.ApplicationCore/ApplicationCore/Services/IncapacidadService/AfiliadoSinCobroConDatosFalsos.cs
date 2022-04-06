using System;
using System.Collections.Generic;
using System.Text;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public class AfiliadoSinCobroConDatosFalsos
    {
        #region Dependency Injection
        private Mock<IAsyncRepository<Incapacidad>> _mockIncapacidadRepo;
        private Mock<IAsyncRepository<Afiliado>> _mockAfiliadoRepo;
        private IncapacidadService _incapacidadService;

        private string incapacidadId;
        
        private Guid afiliadoId = Guid.NewGuid();
        private Guid incapacidadNoExistenteId = Guid.NewGuid();

        public AfiliadoSinCobroConDatosFalsos()
        {
            _mockIncapacidadRepo = new Mock<IAsyncRepository<Incapacidad>>();
            _mockAfiliadoRepo = new Mock<IAsyncRepository<Afiliado>>();

            var incapacidad = new Incapacidad() { AfiliadoId = afiliadoId }; incapacidadId = incapacidad.Id.ToString();  _mockIncapacidadRepo.Setup(i => i.GetByIdAsync(incapacidad.Id.ToString())).Returns(Task.Run(() => { return incapacidad; }));
        }
        #endregion

        [Theory]
        [MemberData(nameof(AfiliadoSinCobroConDatosFalsosTestData.TestData),
            MemberType = typeof(AfiliadoSinCobroConDatosFalsosTestData))]
        public async Task Deberia_Retornar_TrueSoloSiPresentaCobroConDatosFalsos(bool? datosFalsos, bool valido)
        {
            _mockAfiliadoRepo
                .Setup(i => i.GetByIdAsync(afiliadoId))
                .Returns(Task.Run(() =>
                {
                    return new Afiliado()
                    {
                        Id = afiliadoId,
                        DatosFalsos = datosFalsos
                    };
                }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = await _incapacidadService.AfiliadoSinCobroConDatosFalsos(incapacidadId);

            Assert.Equal(valido, result);
        }

        [Fact]
        public async Task Deberia_RetornarException_SiElAfiliadoNoExiste()
        {
            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            await Assert.ThrowsAsync<AfiliadoNotFoundException>(async () => await _incapacidadService.AfiliadoSinCobroConDatosFalsos(incapacidadId));
        }

        [Fact]
        public async Task Deberia_RetornarException_SiLaIncapacidadNoExiste()
        {
            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            await Assert.ThrowsAsync<IncapacidadNotFoundException>(async () => await _incapacidadService.AfiliadoSinCobroConDatosFalsos(incapacidadNoExistenteId.ToString()));
        }

        [Fact]
        public async Task Deberia_RetornarExcepcion_SiAfiliadoNoTieneInformacion()
        {
            _mockIncapacidadRepo
                .Setup(a => a.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() => { return new Incapacidad() { AfiliadoId = afiliadoId}; }));

            _mockAfiliadoRepo
                .Setup(a => a.GetByIdAsync(afiliadoId))
                .Returns(Task.Run(() => { return new Afiliado() { Id = afiliadoId, DatosFalsos = null }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = _incapacidadService.AfiliadoSinCobroConDatosFalsos(incapacidadId);

            await Assert.ThrowsAsync<SinDatosParaValidarException>(async () => await result);
        }
    }
}
