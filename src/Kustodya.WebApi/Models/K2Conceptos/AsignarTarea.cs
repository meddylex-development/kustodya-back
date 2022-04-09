using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.K2Conceptos
{
    public class AsignarTarea
    {
        public int Id { get; set; }
        public int? UsuarioAsignadoId { get; set; }
        public int Prioridad { get; set; }
    }
}
