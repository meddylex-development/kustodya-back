using System;
using System.Collections.Generic;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public  class AfiliadoSinConductasContrariasAEstadoDeSaludTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                //                        |    Conductas contrarias a estado de Salud    |     Valido   |
                yield return new object[] {                       true,                         false   };
                yield return new object[] {                       false,                        true   };
            }                                                                                                  
        }
    }
}