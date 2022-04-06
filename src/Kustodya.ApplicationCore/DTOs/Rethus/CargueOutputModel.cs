using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.DTOs.Rethus
{
    public class CargueOutputModel
    {
        public int taskId { get; set; }
        public string estado { get; set; }
        public DateTime fecha { get; set; }
        public int cantidadregistros { get; set; }
        public string nombreArchivo { get; set; }
    }   
}
