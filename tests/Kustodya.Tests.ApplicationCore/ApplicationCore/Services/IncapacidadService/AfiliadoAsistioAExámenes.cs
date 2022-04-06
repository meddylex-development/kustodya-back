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
    public class AfiliadoAsistioAExamenesYValoraciones
    {
        #region Dependency Injection
        private Mock<IAsyncRepository<Incapacidad>> _mockIncapacidadRepo;
        private Mock<IAsyncRepository<Afiliado>> _mockAfiliadoRepo;
        private IncapacidadService _incapacidadService;

        private string incapacidadId;
        private Incapacidad incapacidad;
        private const string incapacidadNoExistenteId = "45";
        private Guid afiliadoId = Guid.NewGuid();

        public AfiliadoAsistioAExamenesYValoraciones()
        {
            _mockIncapacidadRepo = new Mock<IAsyncRepository<Incapacidad>>();
            _mockAfiliadoRepo = new Mock<IAsyncRepository<Afiliado>>();
            incapacidad = new Incapacidad()
            {
                AfiliadoId = afiliadoId
            };
            incapacidadId = incapacidad.Id.ToString();
            _mockIncapacidadRepo
                .Setup(i => i.GetByIdAsync(incapacidad.Id.ToString()))
                .Returns(Task.Run(() =>
                {
                    return incapacidad;
                }));
        }
        #endregion

        [Theory]
        [MemberData(nameof(AfiliadoAsistioAExamenesYValoracionesTestData.TestData),
            MemberType = typeof(AfiliadoAsistioAExamenesYValoracionesTestData))]
        public async Task Deberia_Retornar_TrueSoloSiElAfiliadoAsisteAExamenesYValoraciones(bool asisteAExamenes, bool valido)
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
                        AsisteAExamenes = asisteAExamenes
                    };
                }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = await _incapacidadService.AfiliadoAsistioAExamenesYValoraciones(incapacidadId);

            Assert.Equal(valido, result);
        }

        [Fact]
        public async Task Deberia_RetornarException_SiLaIncapacidadNoExiste()
        {
            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            await Assert.ThrowsAsync<IncapacidadNotFoundException>(async () => await _incapacidadService.AfiliadoAsistioAExamenesYValoraciones(incapacidadNoExistenteId));
        }

        [Fact]
        public async Task Deberia_RetornarException_SiElAfiliadoNoExiste()
        {
            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            await Assert.ThrowsAsync<AfiliadoNotFoundException>(async () => await _incapacidadService.AfiliadoAsistioAExamenesYValoraciones(incapacidadId));
        }

        [Fact]
        public async Task Deberia_RetornarExcepcion_SiAfiliadoNoInformacion()
        {
            _mockIncapacidadRepo.Setup(a => a.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() => { return new Incapacidad() { AfiliadoId = afiliadoId, FechaFin = null }; }));

            _mockAfiliadoRepo.Setup(a => a.GetByIdAsync(afiliadoId))
                .Returns(Task.Run(() => { return new Afiliado() { Id = afiliadoId, AsisteAExamenes = null }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = _incapacidadService.AfiliadoAsistioAExamenesYValoraciones(incapacidadId);

            await Assert.ThrowsAsync<SinDatosParaValidarException>(async () => await result);
        }
    }
}
