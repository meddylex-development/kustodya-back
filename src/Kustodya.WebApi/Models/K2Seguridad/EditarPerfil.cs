using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.K2Seguridad
{
    public class EditarPerfil
    {
        public int iIDPerfil { get; set; }
        public string tDescripcion { get; set; }
        public bool bActivo { get; set; }
    }
}
