using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class EntidadTelefono
    {
        public int Id { get; set; }
        public int EntidadId { get; set; }
        public int CodigoPais { get; set; }
        public int CodigoArea { get; set; }
        public long Numero { get; set; }
        public string Extension { get; set; }
        public string Descripcion { get; set; }
        public Entidad Entidad { get; set; }

    }
}
