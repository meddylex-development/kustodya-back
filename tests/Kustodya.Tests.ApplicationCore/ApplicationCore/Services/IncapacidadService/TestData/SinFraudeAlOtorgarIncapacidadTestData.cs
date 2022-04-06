using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public class SinFraudeAlOtorgarIncapacidadTestData
    {
       public static IEnumerable<object[]> TestData
        {
            get
            {
                //                        |    Fraude en otorgacion    |    Valido   |
                yield return new object[] {          false,                 true     };
                yield return new object[] {          true,                  false    };
            }                                                                                                  
        }
    }
}
