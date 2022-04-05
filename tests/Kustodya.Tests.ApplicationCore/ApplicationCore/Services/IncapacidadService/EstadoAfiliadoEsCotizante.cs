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
    public class EstadoAfiliadoEsCotizante
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
        public EstadoAfiliadoEsCotizante()
        {
            _mockIncapacidadRepo = new Mock<IAsyncRepository<Incapacidad>>();
            _mockAfiliadoRepo = new Mock<IAsyncRepository<Afiliado>>();

            var incapacidad = new Incapacidad() { AfiliadoId = afiliadoId }; incapacidadId = incapacidad.Id.ToString();  _mockIncapacidadRepo.Setup(i => i.GetByIdAsync(incapacidad.Id.ToString())).Returns(Task.Run(() => { return incapacidad; }));
        }
        #endregion

        [Theory]
        [InlineData(cotizante, true)]
        [InlineData(beneficiario, false)]
        public async Task Deberia_Retornar_ElTipoDeCotizacion(Afiliado.TiposAfiliacion tipoAfiliacion, bool esCotizante)
        {
            _mockAfiliadoRepo
                .Setup(a => a.GetByIdAsync(afiliadoId))
                .Returns(Task.Run(() => { return new Afiliado() { TipoAfiliacion = tipoAfiliacion }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = await _incapacidadService.AfiliadoEsCotizante(incapacidadId);

            Assert.Equal(result, esCotizante);
        }

        [Fact]
        public async Task Deberia_RetornarExcepcion_SiElAfiliadoNoExiste()
        {
            // Configuracion
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

            // Ejecucion

            // Verificacion
            await Assert.ThrowsAsync<AfiliadoNotFoundException>(async () => await _incapacidadService.AfiliadoEsCotizante(incapacidadId));
        }

        [Fact]
        public async Task Deberia_RetornarException_SiLaIncapacidadNoExiste()
        {
            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            await Assert.ThrowsAsync<IncapacidadNotFoundException>(async () => await _incapacidadService.AfiliadoEsCotizante(incapacidadNoExistenteId));
        }
    
        [Fact]
        public async Task Deberia_RetornarExcepcion_SiNoHayDatosParaValidar()
        {
            _mockAfiliadoRepo
                .Setup(a => a.GetByIdAsync(afiliadoId))
                .Returns(Task.Run(() => { return new Afiliado() { TipoAfiliacion = null }; }));

            _incapacidadService = new IncapacidadService(_mockIncapacidadRepo.Object, _mockAfiliadoRepo.Object, null);

            var result = _incapacidadService.AfiliadoEsCotizante(incapacidadId);

            await Assert.ThrowsAsync<SinDatosParaValidarException>(async () => await result);
        }
    }
}
