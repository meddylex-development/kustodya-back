using AutoMapper;
using Kustodya.Medicos.Input;
using Kustodya.Medicos.Models;
using Kustodya.Medicos.Services.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TinyCsvParser.Mapping;
using Xunit;
using Kustodya.ApplicationCore.Constants;
using Kustodya.Medicos.Data;
using Kustodya.Medicos.Data.Rethus;

namespace Kustodya.Medicos.Tests
{
    public class MapeoDatosSSoTest
    {
        private IMapper mapper;
        private Data.Rethus.DatoSSO datoSsoRethusDePrueba = DatoSSO.Nuevo.DePrueba(1);
        private Data.Medicos.DatoSso datoSsoMedicoDePrueba = Data.Medicos.DatoSso.Nuevo.DePrueba();

        public  MapeoDatosSSoTest()
        {
            mapper = new MapperConfiguration(c => c.AddProfile<MappingProfiles>()).CreateMapper();
        }

        [Fact]
        public void MapperDeberiaMapearDatoSso()
        {
            // Ejecucion
            var sut = mapper.Map<Data.Medicos.DatoSso>(datoSsoRethusDePrueba);

            // Afirmaciones
            AsertarQueElDatoSsoMapeadoEsIgualAlDePruebas(sut, datoSsoRethusDePrueba);
        }

        public static bool AsertarQueElDatoSsoMapeadoEsIgualAlDePruebas(Data.Medicos.DatoSso datoSsoMedico, Data.Rethus.DatoSSO datoSsoRethus)
        {
            Assert.Equal(datoSsoRethus.EntidadReportadora, datoSsoMedico.EntidadReportadora);
            Assert.Equal(datoSsoRethus.FechaFin, datoSsoMedico.FechaFin);
            Assert.Equal(datoSsoRethus.FechaInicio, datoSsoMedico.FechaInicio);
            Assert.Equal(datoSsoRethus.LugarPresentacion, datoSsoMedico.LugarPresentacion);
            Assert.Equal(datoSsoRethus.ModalidadPrestacion, datoSsoMedico.ModalidadPrestacion);
            Assert.Equal(datoSsoRethus.ProgramaPrestacion, datoSsoMedico.ProgramaPrestacion);
            Assert.Equal(datoSsoRethus.TipoLugarPrestacion, datoSsoMedico.TipoLugarPrestacion);
            Assert.Equal(datoSsoRethus.TipoPrestacion, datoSsoMedico.TipoPrestacion);

            return true;
        }
    }
}
