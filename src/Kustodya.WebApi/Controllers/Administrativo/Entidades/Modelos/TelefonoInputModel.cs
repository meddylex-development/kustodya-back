using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Entidades.Modelos
{
    public class TelefonoInputModel
    {
        public int Id { get; set; }
        public int EntidadId { get; set; }
        public int Numero { get; set; }
        public string Extension { get; set; }
        public string Descripcion { get; set; }
    }
}
