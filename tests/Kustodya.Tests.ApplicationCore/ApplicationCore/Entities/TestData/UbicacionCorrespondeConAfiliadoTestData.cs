using System;
using System.Collections.Generic;
using System.Text;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Entities.MallaValidadora;

namespace Kustodya.UnitTests.ApplicationCore.Entities
{
    public class UbicacionCorrespondeConAfiliadoTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                //                        |
                yield return new object[] { new Incapacidad { Ips = new Ips("123456") { CodigoDaneMunicipio = "123456" }, Afiliado = new Afiliado { CodigoDaneMunicipio = "123456" } }, true };
                yield return new object[] { new Incapacidad { Ips = new Ips("123456") { CodigoDaneMunicipio = "123456" }, Afiliado = new Afiliado { CodigoDaneMunicipio = "789456" } }, false };
            }
        }

        public static IEnumerable<object[]> NullDataTestData
        {
            get
            {
                //                        |
                yield return new object[] { new Incapacidad { 
                    Ips = null, 
                    Afiliado = new Afiliado { CodigoDaneMunicipio = "0024" } } };
                yield return new object[] { new Incapacidad { 
                    Ips = new Ips("123456") { CodigoDaneMunicipio = null }, 
                    Afiliado = new Afiliado { CodigoDaneMunicipio = "0024" } } };
                yield return new object[] { new Incapacidad { 
                    Ips = new Ips("123456") { CodigoDaneMunicipio = "789456" } , 
                    Afiliado = new Afiliado { CodigoDaneMunicipio = null } } };
                yield return new object[] { new Incapacidad { 
                    Ips = new Ips("123456") { CodigoDaneMunicipio = "789456" } ,
                    Afiliado = null } };
            }
        }
    }
}
