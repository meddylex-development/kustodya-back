using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public  class SexoAfiliadoIgualASexoDiagnosticoTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                //                        |     Incapacidad    |                   Diagnostico              | Valido |
                yield return new object[] { Sexos.Femenino     , new Diagnostico() { Sexo = Sexos.Masculino }, false };
                yield return new object[] { Sexos.Femenino     , new Diagnostico() { Sexo = Sexos.Femenino  }, true  };
            }                                                                                                  
        }
    }
}