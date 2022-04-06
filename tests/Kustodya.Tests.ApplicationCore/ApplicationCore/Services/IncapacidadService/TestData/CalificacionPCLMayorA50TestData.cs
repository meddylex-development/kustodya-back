using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public class CalificacionPCLMayorA50TestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                //                          |   Calificacion PCL    |   Mayor a 50  |
                yield return new object[] {             40 ,                false   };
                yield return new object[] {             50 ,                false   };
                yield return new object[] {             60 ,                true    };
            }
        }
    }
}
