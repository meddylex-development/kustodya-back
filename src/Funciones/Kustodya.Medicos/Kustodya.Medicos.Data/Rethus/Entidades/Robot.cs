using System;
using System.Collections.Generic;

namespace Roojo.Rethus
{
    public partial class Robot
    {
        public Robot()
        {
            Tareas = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string CodigoInterno { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }

        public static class Nuevo
        {
            public static Robot DePrueba()
            {
                return new Robot
                {
                    CodigoInterno = "TER2020",
                    Nombre = "Terminator",
                    Ubicacion = "Australia"
                };
            }
        }
    }
}
