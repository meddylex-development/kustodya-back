using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public class AfiliadoSinCalificacionAtelTestData
    {
       public static IEnumerable<object[]> TestData
        {
            get
            {
                //                        |    Calificacion Atel         |    Valido   |
                yield return new object[] {          true,                      false   };
                yield return new object[] {          false,                     true    };
            }                                                                                                  
        }
    }
}
