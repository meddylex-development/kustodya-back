using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.MallaValidadora
{
    public class EspecialidadMedica : BaseEntity
    {
        public string Nombre { get; set; }

        public List<Incapacidad> Incapacidades { get; set; }
        public List<Diagnostico> Diagnosticos { get; set; }
    }
}
