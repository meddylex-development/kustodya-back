using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class EntidadCorreo
    {
        public int Id { get; set; }
        public int EntidadId { get; set; }
        public string Correo { get; set; }
        public string  Descripcion { get; set; }
        public Entidad Entidad { get; set; }
    }
}
