using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Specifications.Incapacidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Kustodya.UnitTests.ApplicationCore.Entities.IncapacidadTests
{
    public class IncapacidadInmediatamenteCorrelacionadaTests
    {
        //[Theory]
        //[IncapacidadInmediatamenteCorrelacionadaTestData]
        //public void NoRetornaReultadosSiNoHayMasIncapacidadesLosultimos30Dias(Incapacidad incapacidad)
        //{
        //    var spec = new IncapacidadInmediatamenteCorrelacionada("M889", DateTime.Now.Date);

        //    var incapacidadesDeprueba = IncapacidadInmediatamenteCorrelacionadaTestData.GetIncapacidadesDePrueba().AsQueryable();

        //    var result = IncapacidadInmediatamenteCorrelacionadaTestData.GetIncapacidadesDePrueba()
        //        .AsQueryable()
        //        .Any(spec.Criteria);

        //    Assert.False(result);
        //}

        //[Theory]
        //[IncapacidadInmediatamenteCorrelacionadaTestData]
        //public void CoincideNumeroDeIncapacidadesEsperado()
        //{

        //}

        [Theory]
        [IncapacidadInmediatamenteCorrelacionadaNullTestData]
        public void ThrowsSinDatosParaValidarException_Si_NoHaySuficientesDatosParaValidar(Incapacidad incapacidad)
        {
            bool? action() => incapacidad.DiasAcumuladosValidos();

            Assert.Equal(null, action());
        }
    }
}
