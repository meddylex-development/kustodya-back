using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Threading.Tasks;
using Kustodya.Medicos.Input;
using TinyCsvParser.Mapping;
using Kustodya.Medicos.Models;
using System.Linq;

namespace Kustodya.Medicos.Tests
{
    public class InputModelTests
    {
        [Theory]
        [InputModelTestData]
        public void CrearDesdeCsvConvertido_Deberia_Retornar(List<Input.ResultadoDeMapeo> csvConvertido)
        {
            var sut = InputModel.Fabrica.CrearDesdeCsvConvertido(csvConvertido);

            Assert.Equal(csvConvertido.Count(), sut.TotalSubido);
            Assert.Equal(5, sut.Convertibles.Count());
            Assert.Equal(5, sut.Validos.Count()); 
            Assert.Equal(3, sut.Unicos.Count());
            Assert.Equal(2, sut.DuplicadosValidosDistintos.Count());

            Assert.Contains("222222", sut.Validos.Select(v => v.NumeroIdentificacion));
            Assert.Contains("333333", sut.Validos.Select(v => v.NumeroIdentificacion));
            Assert.Contains("444444", sut.Validos.Select(v => v.NumeroIdentificacion));

            //var duplicadosUnivos = sut.Duplicados.Where(d =>
            //        sut.Validos.Contains(d))
            //        .Distinct()
            //        .Count();

            //Assert.Equal(6, sut.Duplicados.Count());
            //Assert.Equal(csvConvertido.Count, 
            //    sut.Validos.Count() + 
            //    sut.Invalidos.Count() + 
            //    sut.Duplicados.Where(d => 
            //        sut.Validos.Contains(d))
            //        .Distinct()
            //        .Count());
        }
    }
}
