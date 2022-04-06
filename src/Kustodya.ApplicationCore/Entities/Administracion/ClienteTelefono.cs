using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class ClienteTelefono
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int CodigoPais { get; set; }
        public int CodigoArea { get; set; }
        public int Numero { get; set; }
        public string Extension { get; set; }
        public string Descripcion { get; set; }
        public Cliente Cliente { get; set; }
    }
}
