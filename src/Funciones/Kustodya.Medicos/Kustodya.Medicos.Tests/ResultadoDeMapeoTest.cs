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

namespace Kustodya.Medicos.Tests
{
    public class ResultadoDeMapeoTest
    {
        private IMapper mappr;
        private Registro registro;
        private CsvMappingResult<Registro> csvResult;

        public ResultadoDeMapeoTest()
        {
            mappr = new MapperConfiguration(c => c.AddProfile<MappingProfiles>()).CreateMapper();
            registro = new Registro("1111111", TipoIdentificacion.Cédula_de_ciudadanía);
            csvResult = new CsvMappingResult<Registro>() { Result = registro };
        }

        [Fact]
        public void Mapper_Deberia_MapearCorrectamente_DesdeCsvMappingresult()
        {
            // Ejecucion
            var sut = mappr.Map<ResultadoDeMapeo>(csvResult);

            // Afirmaciones
            Assert.Equal(registro, sut.Registro);
        }

        [Fact]
        public void Mapper_Deberia_MapearCorrectamente_Desde_IEnumerable_CsvMappingresult()
        {
            // Configuracion
            var csvEnumerable = new Collection<CsvMappingResult<Registro>>() { csvResult, csvResult, csvResult };

            // Ejecucion
            var sut = mappr.Map<Collection<ResultadoDeMapeo>>(csvEnumerable);

            // Afirmaciones
            Assert.Equal(registro, sut[0].Registro);
            Assert.Equal(csvEnumerable.Count, sut.Count);
        }
    }
}
