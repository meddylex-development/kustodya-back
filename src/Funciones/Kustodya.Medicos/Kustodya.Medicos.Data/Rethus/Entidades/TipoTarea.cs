using System;
using System.Collections.Generic;

namespace Roojo.Rethus
{
    public partial class TipoTarea
    {
        public TipoTarea()
        {
            Tareas = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
