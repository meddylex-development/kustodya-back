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
    public class AfiliadoSinCalificacionAtel
    {
        #region Dependency Injection
        private Mock<IAsyncRepository<Incapacidad>> _mockIncapacidadRepo;
        private Mock<IAsyncRepository<Afiliado>> _mockAfiliadoRepo;
        private IncapacidadService _incapacidadService;

        private string incapacidadId;
        private const string incapacidadNoExistenteId = "45";
        private Guid afiliadoId = Guid.NewGuid();
        private Guid afiliadoNoExistente = Guid.NewGuid();

        public AfiliadoSinCalificacionAtel()
        {
            _mockIncapacidadRepo = new Mock<IAsyncRepository<Incapacidad>>();
            _mockAfiliadoRepo = new Mock<IAsyncRepository<Afiliado>>();

            var incapacidad = new Incapacidad() { AfiliadoId = afiliadoId }; incapacidadId = incapacidad.Id.ToString();  _mockIncapacidadRepo.Setup(i => i.GetByIdAsync(incapacidad.Id.ToString())).Returns(Task.Run(() => { return incapacidad; }));
        }
        #endregion

        [Theory]
        [MemberData(nameof(AfiliadoSinCalificacionAtelTestData.TestData),
            MemberType = typeof(AfiliadoSinCalificacionAtelTestData))]
        public async Task Deberia_Retornar_TrueSoloSiNoTieneCalificacionAtel(bool calificacionAtel, bool valido)
        {
            _mockIncapacidadRepo.Setup(i => i.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() =>
                {
                    return new Incapacidad()
                    {
                        AfiliadoId = afiliadoId
                    };
                }));

            _mockAfiliadoRepo.Setup(i => i.GetByIdAsync(afiliadoId))
                .Returns(Task.Run(() =>
                {
                    return new Afiliado()
                    {
                        Id = afiliadoId,
                        CalificacionAtel = calificacionAtel
                    };
                }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = await _incapacidadService.AfiliadoSinCalificacionAtel(incapacidadId);

            Assert.Equal(valido, result);
        }

        [Fact]
        public async Task Deberia_RetornarException_SiLaIncapacidadNoExiste()
        {
            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            await Assert.ThrowsAsync<IncapacidadNotFoundException>(async () => await _incapacidadService.AfiliadoSinCalificacionAtel(incapacidadNoExistenteId));
        }

        [Fact]
        public async Task Deberia_RetornarException_SiAfiliadoNoExiste()
        {
            var incapacidad = new Incapacidad() { AfiliadoId = afiliadoNoExistente };
            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            await Assert.ThrowsAsync<IncapacidadNotFoundException>(async () => await _incapacidadService.AfiliadoSinCalificacionAtel(incapacidad.Id.ToString()));
        }

        [Fact]
        public async Task Deberia_RetornarExcepcion_SiIncapacidadNoTieneInformacionParaValidar()
        {
            _mockIncapacidadRepo
                .Setup(a => a.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() => { return new Incapacidad() { AfiliadoId = afiliadoId }; }));

            _mockAfiliadoRepo.Setup(i => i.GetByIdAsync(afiliadoId))
                .Returns(Task.Run(() =>
                {
                    return new Afiliado()
                    {
                        Id = afiliadoId,
                        CalificacionAtel = null
                    };
                }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = _incapacidadService.AfiliadoSinCalificacionAtel(incapacidadId);

            await Assert.ThrowsAsync<SinDatosParaValidarException>(async () => await result);
        }
    }
}
