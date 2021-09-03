using System.Threading.Tasks;
using AutoMapper;
using Xunit;
using Kustodya.Homologacion.Famisanar;
using Kustodya.Homologacion.Famisanar.PerfilesDeMapeo;
using Kustodya.ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Kustodya.UnitTests.Homologacion.Famisanar
{
    public class Homologar
    {
        private readonly Mapper mapper;

        public Homologar()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<PerfilDeMapeoDeIncapacidad>());
            mapper = new Mapper(configuration);
        }

        [Theory]
        [DatosDePruebaDeHomologacion]
        public void DeberiaHomologarUnaPaginaDeIncapacidadesDeFamisanar(string pagina, Kustodya.ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada.IncapacidadInputModel inputModelEsperado)
        {
            var logger = new LoggerFactory();
            var sut = new ServicioDeHomologacion(null, mapper, logger, null);

            var modelo = sut.Homologar(pagina).FirstOrDefault();

            Assert.Equal(inputModelEsperado.Afiliado.FechaNacimiento, modelo.Afiliado.FechaNacimiento);
            Assert.Equal(inputModelEsperado.FechaAfiliacion, modelo.FechaAfiliacion);
            Assert.Equal(inputModelEsperado.Afiliado.TipoAfiliacion, modelo.Afiliado.TipoAfiliacion);
            Assert.Equal(inputModelEsperado.FechaInicio, modelo.FechaInicio);
            Assert.Equal(inputModelEsperado.FechaRadicacion, modelo.FechaRadicacion);
            Assert.Equal(inputModelEsperado.IpsNit, modelo.IpsNit);
        }
    }
}