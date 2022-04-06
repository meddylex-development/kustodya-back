using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public class SinPresuntaAlteracionOFraudeTestData
    {
       public static IEnumerable<object[]> TestData
        {
            get
            {
                //                        |    Alteracion o fraude    |    Valido   |
                yield return new object[] {          false,                 true   };
                yield return new object[] {          true,                  false    };
            }                                                                                                  
        }
    }
}
