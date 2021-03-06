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
    public class AfiliadoSinConductasContrariasAEstadoDeSalud
    {
        #region Dependency Injection
        private Mock<IAsyncRepository<Incapacidad>> _mockIncapacidadRepo;
        private Mock<IAsyncRepository<Afiliado>> _mockAfiliadoRepo;
        private IncapacidadService _incapacidadService;

        private string incapacidadId;
        private Guid afiliadoId = Guid.NewGuid();
        private Guid incapacidadNoExistenteId = Guid.NewGuid();
        public AfiliadoSinConductasContrariasAEstadoDeSalud()
        {
            _mockIncapacidadRepo = new Mock<IAsyncRepository<Incapacidad>>();
            _mockAfiliadoRepo = new Mock<IAsyncRepository<Afiliado>>();

            var incapacidad = new Incapacidad() { AfiliadoId = afiliadoId }; incapacidadId = incapacidad.Id.ToString();  _mockIncapacidadRepo.Setup(i => i.GetByIdAsync(incapacidad.Id.ToString())).Returns(Task.Run(() => { return incapacidad; }));
        }
        #endregion

        [Theory]
        [MemberData(nameof(AfiliadoSinConductasContrariasAEstadoDeSaludTestData.TestData),
            MemberType = typeof(AfiliadoSinConductasContrariasAEstadoDeSaludTestData))]
        public async Task Deberia_Retornar_TrueSoloSiAfiliadoPresentaConductasContrarias(bool? conductasContrarias, bool valido)
        {
            _mockAfiliadoRepo
                .Setup(i => i.GetByIdAsync(afiliadoId))
                .Returns(Task.Run(() =>
                {
                    return new Afiliado()
                    {
                        Id = afiliadoId,
                        ConductasContrarias = conductasContrarias
                    };
                }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = await _incapacidadService.AfiliadoSinConductasContrariasAEstadoDeSalud(incapacidadId);

            Assert.Equal(valido, result);
        }

        [Fact]
        public async Task Deberia_RetornarException_SiElAfiliadoNoExiste()
        {
            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            await Assert.ThrowsAsync<AfiliadoNotFoundException>(async () => await _incapacidadService.AfiliadoSinConductasContrariasAEstadoDeSalud(incapacidadId));
        }

        [Fact]
        public async Task Deberia_RetornarException_SiLaIncapacidadNoExiste()
        {
            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            await Assert.ThrowsAsync<IncapacidadNotFoundException>(async () => await _incapacidadService.AfiliadoSinConductasContrariasAEstadoDeSalud(incapacidadNoExistenteId.ToString()));
        }

        [Fact]
        public async Task Deberia_RetornarExcepcion_SiAfiliadoNoTieneInformacion()
        {
            _mockIncapacidadRepo
                .Setup(a => a.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() => { return new Incapacidad() { AfiliadoId = afiliadoId}; }));

            _mockAfiliadoRepo
                .Setup(a => a.GetByIdAsync(afiliadoId))
                .Returns(Task.Run(() => { return new Afiliado() { Id = afiliadoId, ConductasContrarias = null }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = _incapacidadService.AfiliadoSinConductasContrariasAEstadoDeSalud(incapacidadId);

            await Assert.ThrowsAsync<SinDatosParaValidarException>(async () => await result);
        }
    }
}
