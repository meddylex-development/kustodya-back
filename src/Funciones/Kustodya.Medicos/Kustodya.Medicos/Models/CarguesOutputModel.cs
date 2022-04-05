using System.Collections.Generic;
using Kustodya.Medicos.Data;

namespace Kustodya.Medicos.Models
{
    public class CarguesOutputModel{
        public ICollection<CargueMasivo> Cargues { get; set; }
        public PaginacionModel Paginacion { get; set; }
    }
}