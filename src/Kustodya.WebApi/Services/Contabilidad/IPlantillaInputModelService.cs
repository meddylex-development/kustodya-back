using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public interface IPlantillaInputModelService
    {
        void ValidarComodines(string texto);
    }
}
