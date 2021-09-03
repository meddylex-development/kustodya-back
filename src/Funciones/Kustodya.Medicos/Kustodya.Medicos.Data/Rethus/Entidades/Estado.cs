using System;
using System.Collections.Generic;

namespace Roojo.Rethus
{
    public partial class Estados
    {
        public Estados()
        {
            Consultas = new HashSet<Consulta>();
            Tareas = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
