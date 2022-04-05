using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Entidades.Modelos
{
    public class TelefonoOutputModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Extension { get; set; }
        public string Descripcion { get; set; }
    }
}
