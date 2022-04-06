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
    public class IpsIsAdscrita
    {
        #region Dependency Injection
        private Mock<IAsyncRepository<Incapacidad>> _mockIncapacidadRepo;
        private Mock<IAsyncRepository<Afiliado>> _mockAfiliadoRepo;
        private Mock<IAsyncRepository<Ips>> _mockIpsRepo;
        private IncapacidadService _incapacidadService;

        private string incapacidadId;
        private const string incapacidadNoExistenteId = "45";
        private Guid afiliadoId = Guid.NewGuid();
        private const string ipsNit = "12376765";

        public IpsIsAdscrita()
        {
            _mockIncapacidadRepo = new Mock<IAsyncRepository<Incapacidad>>();
            _mockAfiliadoRepo = new Mock<IAsyncRepository<Afiliado>>();
            _mockIpsRepo = new Mock<IAsyncRepository<Ips>>();

            _mockIncapacidadRepo
                .Setup(i => i.GetByIdAsync(incapacidadId))
                .Returns(Task.Run(() => new Incapacidad()
                { AfiliadoId = afiliadoId, IpsNit = ipsNit }));


        }
        #endregion
        
        [Theory]
        [InlineData(Ips.Estados.Adscrita, true)]
        [InlineData(Ips.Estados.NoAdscrita, false)]
        public async Task Deberia_Retornar_EstadoIps(Ips.Estados estado, bool esAdscrita)
        {
            _mockIpsRepo
                .Setup(i => i.GetByIdAsync(ipsNit))
                .Returns(Task.Run(() => new Ips(ipsNit)
                { Estado = estado }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object,
                                                         _mockAfiliadoRepo.Object,
                                                         _mockIpsRepo.Object);

            var result = await _incapacidadService.IpsIsAdscrita(incapacidadId);

            Assert.Equal(result, esAdscrita);
        }

        [Fact]
        public async Task Deberia_RetornarException_SiLaIncapacidadNoExiste()
        {
            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            await Assert.ThrowsAsync<IncapacidadNotFoundException>(async () => await _incapacidadService.IpsIsAdscrita(incapacidadNoExistenteId));
        }

        [Fact]
        public async Task Deberia_RetornarExcepcion_SiNoHayDatosParaValidar()
        {
            _mockIpsRepo
                .Setup(a => a.GetByIdAsync(ipsNit))
                .Returns(Task.Run(() => { return new Ips(ipsNit) { Estado = null }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, _mockIpsRepo.Object);

            var result = _incapacidadService.IpsIsAdscrita(incapacidadId);

            await Assert.ThrowsAsync<SinDatosParaValidarException>(async () => await result);
        }
    }
}
