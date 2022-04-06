using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Contabilidades
{
    public class Segmento : BaseEntity
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
