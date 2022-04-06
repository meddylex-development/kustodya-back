using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Usuarios.Modelos
{
    public class CiudadOutputModel
    {
        public int Id { get; set; }
        public int PaisId { get; set; }
        public int DeptoId { get; set; }
        public int MunicipioId { get; set; }
        public string Ciudad { get; set; }
    }
}
