using Kustodya.ApplicationCore.Entities.MallaValidadora;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace Kustodya.UnitTests.ApplicationCore.Entities
{
    public class DiasAcumuladosValidosTestData : DataAttribute
    {
        public static IEnumerable<object[]> NullDataTestData
        {
            get
            {
                //  Id  |   Dias Acumulados     |       Maximo de dias acumulados por diagnostico       |   Valido  |
                yield return new object[] { new Incapacidad
                    { DiasAcumulados = null, Diagnostico = new Diagnostico { DiasMaxAcumulados = 15 } }, false };
                yield return new object[] { new Incapacidad
                    { DiasAcumulados = 15, Diagnostico = null }, false };
                yield return new object[] { new Incapacidad
                    { DiasAcumulados = 15, Diagnostico = new Diagnostico { DiasMaxAcumulados = null } }, false };
            }
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        { 
            //  Id  |   Dias Acumulados     |       Maximo de dias acumulados por diagnostico       |   Valido  |
            yield return new object[] { new Incapacidad
                    { DiasAcumulados = 10, Diagnostico = new Diagnostico { DiasMaxAcumulados = 15 } }, true };
            yield return new object[] { new Incapacidad
                    { DiasAcumulados = 15, Diagnostico = new Diagnostico { DiasMaxAcumulados = 15 } }, true };
            yield return new object[] { new Incapacidad
                    { DiasAcumulados = 20, Diagnostico = new Diagnostico { DiasMaxAcumulados = 15 } }, false };
        }
    }
}
