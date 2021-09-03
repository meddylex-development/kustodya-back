using System;
using System.Collections.Generic;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public  class AfiliadoSinActividadImpideSuRecuperacionTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                //                        |    En actividad que impide recuperacion      |     Valido   |
                yield return new object[] {                       true,                         false   };
                yield return new object[] {                       false,                        true    };
            }                                                                                                  
        }
    }
}