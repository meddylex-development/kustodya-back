using System.Linq;
using AutoMapper;
using Kustodya.Medicos.Data;
using Kustodya.Medicos.Data.Medicos;
using Roojo.Rethus;
using Kustodya.Medicos.Models;
using Xunit;

namespace Kustodya.Medicos.Tests
{
    public class MapeoDeDatoAMedico
    {
        private IMapper mapper;
        private Data.Rethus.Consulta consultaDePrueba = Consulta.Nueva.DePrueba(1);
        private Medico medicoDePrueba = Medico.Nuevo.DePrueba();

        public  MapeoDeDatoAMedico()
        {
            mapper = new MapperConfiguration(c => c.AddProfile<MappingProfiles>()).CreateMapper();
        }

        [Fact]
        public void DeberiRetornarConUnTipoDeIdentificacion()
        {
            var config = new MapperConfiguration(c => c.AddProfile(new MappingProfiles()));

            // config.AssertConfigurationIsValid();

            var mapper = config.CreateMapper();
            var medico = mapper.Map<Consulta, Medico>(Consulta.Nueva.DePrueba(100));

            Assert.Equal(medico.TipoIdentificacion, ApplicationCore.Constants.TipoIdentificacion.Cédula_Extranjeria); 
        }

        [Fact]
        public void DeberiaMapearDatoSso()
        {
            var sut = mapper.Map<Medico>(consultaDePrueba);

            Assert.Equal(sut.DatosSso.Count, 2);
            MapeoDatosSSoTest.AsertarQueElDatoSsoMapeadoEsIgualAlDePruebas(sut.DatosSso.FirstOrDefault(), Data.Rethus.DatoSso.Nuevo.DePrueba(1));
            // Assert.Equal(sut.DatosSSO, d => MapeoDatosSSoTest.AsertarQueElDatoSsoMapeadoEsIgualAlDePruebas(d, DatoSSO.Nuevo.DePrueba(1));
        }
    }
}