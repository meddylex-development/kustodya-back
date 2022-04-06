using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public class AfiliadoAsistioAExamenesYValoracionesTestData
    {
       public static IEnumerable<object[]> TestData
        {
            get
            {
                //                        |    Asiste a examenes    |    Valido   |
                yield return new object[] {        false,                     false   };
                yield return new object[] {        true,                      true    };
            }                                                                                                  
        }
    }
}
