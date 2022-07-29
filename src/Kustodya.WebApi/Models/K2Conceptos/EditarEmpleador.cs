using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.K2Conceptos
{
    public class EditarEmpleador
    {
        public string tDireccion { get; set; }
        public string tTelefono { get; set; }
        public int iIDCiudad { get; set; }
        public string tEmail { get; set; }
        public int iIDEmpresaPaciente { get; set; }
    }
}
