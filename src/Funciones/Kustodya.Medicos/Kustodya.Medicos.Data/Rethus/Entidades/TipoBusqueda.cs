using System;
using System.Collections.Generic;

namespace Roojo.Rethus
{
    public partial class TipoBusqueda
    {
        public TipoBusqueda()
        {
            Consultas = new HashSet<Consulta>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
