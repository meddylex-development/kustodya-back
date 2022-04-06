using System;
using System.Collections.Generic;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public  class IncapacidadSinDobleCobroTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                //                        |    Generando doble cobro    |     Valido   |
                yield return new object[] {            true,                   false   };
                yield return new object[] {            false,                  true    };
            }                                                                                                  
        }
    }
}