using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class ClienteCorreo
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int Correo { get; set; }
        public int Descripcion { get; set; }
        public Cliente Cliente { get; set; }

    }
}
