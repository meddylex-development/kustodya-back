using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class EntidadOtro
    {
        public int Id { get; set; }
        public int EntidadId { get; set; }
        public string Categoria { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string Descripcion { get; set; }
        public Entidad Entidad { get; set; }
    }
}
