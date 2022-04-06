using System;
using AutoMapper;
using Xunit;
using Kustodya.Homologacion.Famisanar.PerfilesDeMapeo;
using Kustodya.ApplicationCore.DTOs.MallaValidadora;
using Kustodya.ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.Homologacion.Famisanar.ModelosDeEntrada;
using Kustodya.ApplicationCore.Constants;

namespace Kustodya.UnitTests.Homologacion.Famisanar
{
    public class TestsDelPerfilDeMapeoDeLaIncapacidad
    {
        private readonly Mapper mapper;
        public TestsDelPerfilDeMapeoDeLaIncapacidad()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PerfilDeMapeoDeIncapacidad>();
                // cfg.AddProfile<AfiliadoMappingProfile>();
            });
            mapper = new Mapper(configuration);
        }

        [Fact]
        public void DeberiaMapearFechasDeNacimiento()
        {
            var incapacidad = new Kustodya.Homologacion.Famisanar.ModelosDeEntrada.IncapacidadFamisanar()
            {
                FechaNacimiento = "959436021000",
                FechaRadicación = "1558965621000",
            };

            var incapacidadInputModel = mapper.Map<ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada.IncapacidadInputModel>(incapacidad);

            Assert.Equal(new DateTime(2019, 5, 27, 14, 0, 21), incapacidadInputModel.FechaRadicacion);
        }

        [Fact]
        public void DeberiaMapearNitDeIps()
        {
            var incapacidad = new Kustodya.Homologacion.Famisanar.ModelosDeEntrada.IncapacidadFamisanar()
            {
                COD_IPS_IGE = "789456123-45"
            };

            var incapacidadInputModel = mapper.Map<ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada.IncapacidadInputModel>(incapacidad);

            Assert.Equal("789456123-45", incapacidadInputModel.IpsNit);
        }

        [Fact]
        public void DeberiaMapearProrroga()
        {
            var incapacidad = new Kustodya.Homologacion.Famisanar.ModelosDeEntrada.IncapacidadFamisanar()
            {
                PRORROGA = "Si"
            };

            var incapacidadInputModel = mapper.Map<ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada.IncapacidadInputModel>(incapacidad);

            Assert.Equal(true, incapacidadInputModel.Prorroga);
        }

        [Fact]
        public void DeberiaMapearFechaInicio()
        {
            var incapacidad = new Kustodya.Homologacion.Famisanar.ModelosDeEntrada.IncapacidadFamisanar()
            {
                FechaInicio = "959436021000"
            };

            var incapacidadInputModel = mapper.Map<ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada.IncapacidadInputModel>(incapacidad);
            //Saturday, May 27, 2000 10:00:21 AM
            Assert.Equal(new DateTime(2000, 5, 27, 14, 0, 21), incapacidadInputModel.FechaInicio);
        }

        [Fact]
        public void DeberiaMapearFechaFin()
        {
            var incapacidad = new Kustodya.Homologacion.Famisanar.ModelosDeEntrada.IncapacidadFamisanar()
            {
                FechaInicio = "959436021000",
                DIAS_APROBADOS = "2"
            };

            var incapacidadInputModel = mapper.Map<ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada.IncapacidadInputModel>(incapacidad);
            //Saturday, May 27, 2000 10:00:21 AM
            Assert.Equal(new DateTime(2000, 5, 29, 14, 0, 21, 0), incapacidadInputModel.FechaFin);
        }

        [Fact]
        public void DeberiaMapearFechaRadicacion()
        {
            var incapacidad = new Kustodya.Homologacion.Famisanar.ModelosDeEntrada.IncapacidadFamisanar()
            {
                FechaRadicación = "959436021000"
            };

            var incapacidadInputModel = mapper.Map<ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada.IncapacidadInputModel>(incapacidad);
            //Saturday, May 27, 2000 10:00:21 AM
            Assert.Equal(new DateTime(2000, 5, 27, 14, 0, 21), incapacidadInputModel.FechaRadicacion);
        }

        [Fact]
        public void DeberiaMapearTipoAfiliacionCotizante()
        {
            var incapacidad = new Kustodya.Homologacion.Famisanar.ModelosDeEntrada.IncapacidadFamisanar()
            {
                TipoAfiliación = "Cotizante"
            };

            var incapacidadInputModel = mapper.Map<ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada.IncapacidadInputModel>(incapacidad);
            //Saturday, May 27, 2000 10:00:21 AM
            Assert.Equal(Afiliado.TiposAfiliacion.Cotizante, incapacidadInputModel.Afiliado.TipoAfiliacion);
        }

        [Fact]
        public void DeberiaMapearTipoAfiliacion2doCotizante()
        {
            var incapacidad = new Kustodya.Homologacion.Famisanar.ModelosDeEntrada.IncapacidadFamisanar()
            {
                TipoAfiliación = "2do.Cotizante"
            };

            var incapacidadInputModel = mapper.Map<ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada.IncapacidadInputModel>(incapacidad);
            //Saturday, May 27, 2000 10:00:21 AM
            Assert.Equal(Afiliado.TiposAfiliacion.SegundoCotizante, incapacidadInputModel.Afiliado.TipoAfiliacion);
        }

        [Fact]
        public void DeberiaMapearEstadoDeAfiliacionEnTrueCuandoElModeloEs1()
        {
            var incapacidad = new IncapacidadFamisanar()
            {
                ESTADO_AFILIACION = "1"
            };

            var incapacidadInputModel = mapper.Map<IncapacidadInputModel>(incapacidad);
            //Saturday, May 27, 2000 10:00:21 AM
            Assert.Equal(true, incapacidadInputModel.Afiliado.Activo);
        }

        [Fact]
        public void DeberiaMapearEstadoDeAfiliacionEnFalseCuandoElModeloEs2o3()
        {
            var incapacidad = new IncapacidadFamisanar()
            {
                ESTADO_AFILIACION = "2"
            };

            var incapacidadInputModel = mapper.Map<IncapacidadInputModel>(incapacidad);
            //Saturday, May 27, 2000 10:00:21 AM
            Assert.Equal(false, incapacidadInputModel.Afiliado.Activo);

            incapacidad = new IncapacidadFamisanar()
            {
                ESTADO_AFILIACION = "3"
            };

            incapacidadInputModel = mapper.Map<IncapacidadInputModel>(incapacidad);
            //Saturday, May 27, 2000 10:00:21 AM
            Assert.Equal(false, incapacidadInputModel.Afiliado.Activo);
        }

        [Fact]
        public void DeberiaMapearSexoDelAfiliado()
        {
            var incapacidad = new IncapacidadFamisanar()
            {
                GENERO = "M"
            };

            var incapacidadInputModel = mapper.Map<IncapacidadInputModel>(incapacidad);
            //Saturday, May 27, 2000 10:00:21 AM
            Assert.Equal(Sexos.Masculino, incapacidadInputModel.Afiliado.Sexo);


            incapacidad = new IncapacidadFamisanar()
            {
                GENERO = "F"
            };

            incapacidadInputModel = mapper.Map<IncapacidadInputModel>(incapacidad);
            //Saturday, May 27, 2000 10:00:21 AM
            Assert.Equal(Sexos.Femenino, incapacidadInputModel.Afiliado.Sexo);
        }

        [Fact]
        public void DeberiaMapearIpsDeAfiliado()
        {
            var incapacidad = new IncapacidadFamisanar()
            {
                NUMERO_ID_IPS_PRIMARIA = "830.003.564-7"
            };

            var incapacidadInputModel = mapper.Map<IncapacidadInputModel>(incapacidad);
            //Saturday, May 27, 2000 10:00:21 AM
            Assert.Equal(incapacidad.NUMERO_ID_IPS_PRIMARIA, incapacidadInputModel.Afiliado.IpsNit);
        }

        [Fact]
        public void DeberiaMapearUbicacionDelAfiliado()
        {
            var incapacidad = new IncapacidadFamisanar()
            {
                AFI_MUN_DEP_CODRES = "05",
                AFI_MUN_CODRES = "001"
            };

            var incapacidadInputModel = mapper.Map<IncapacidadInputModel>(incapacidad);
            //Saturday, May 27, 2000 10:00:21 AM
            Assert.Equal("05001", incapacidadInputModel.Afiliado.CodigoDaneMunicipio);
        }

        [Fact]
        public void DeberiaMapearDiagnostico()
        {
            var incapacidad = new IncapacidadFamisanar()
            {
                DIAGNOSTICO = "A00-B99"
            };

            var incapacidadInputModel = mapper.Map<IncapacidadInputModel>(incapacidad);
            //Saturday, May 27, 2000 10:00:21 AM
            Assert.Equal("A00-B99", incapacidadInputModel.CodigoCie10);
        }

        [Fact]
        public void DeberiaMapearEstadoDeIpsNoAdscrita()
        {
            var incapacidad = new IncapacidadFamisanar()
            {
                IPS_NO_ADSCRITA = "Si"
            };

            var incapacidadInputModel = mapper.Map<IncapacidadInputModel>(incapacidad);
            //Saturday, May 27, 2000 10:00:21 AM
            Assert.Equal(Ips.Estados.NoAdscrita, incapacidadInputModel.Ips.Estado.GetValueOrDefault());
        }

        [Fact]
        public void DeberiaMapearEstadoDeIpsAdscrita()
        {
            var incapacidad = new IncapacidadFamisanar()
            {
                IPS_NO_ADSCRITA = "No"
            };

            var incapacidadInputModel = mapper.Map<IncapacidadInputModel>(incapacidad);
            //Saturday, May 27, 2000 10:00:21 AM
            Assert.Equal(Ips.Estados.Adscrita, incapacidadInputModel.Ips.Estado.GetValueOrDefault());
        }
    }
}
