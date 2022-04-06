using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.Configuracion.CodigoQR
{
    public interface ICodigoQRService
    {
        string GenerateCodeQR(string data);
    }
}
