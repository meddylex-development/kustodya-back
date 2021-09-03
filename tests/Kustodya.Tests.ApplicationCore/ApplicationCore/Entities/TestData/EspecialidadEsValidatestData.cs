using System;
using System.Collections.Generic;
using System.Text;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;
using Kustodya.ApplicationCore.Entities.MallaValidadora;

namespace Kustodya.UnitTests.ApplicationCore.Entities
{
    public class EspecialidadEsValidaTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                //                        |
                yield return new object[] { new Incapacidad { EspecialidadMedicaId = 15, Diagnostico = new Diagnostico() { EspecialidadMedicaId = 15 } }, true };
                yield return new object[] { new Incapacidad { EspecialidadMedicaId = 15, Diagnostico = new Diagnostico() { EspecialidadMedicaId = 8 } }, false };
            }
        }

        public static IEnumerable<object[]> NullDataTestData
        {
            get
            {
                //                        |
                yield return new object[] { new Incapacidad { EspecialidadMedicaId = null } };
                yield return new object[] { new Incapacidad { EspecialidadMedicaId = 15, Diagnostico = null } };
                yield return new object[] { new Incapacidad { EspecialidadMedicaId = 15, Diagnostico = new Diagnostico { EspecialidadMedicaId = null } } };
            }
        }
    }
}
