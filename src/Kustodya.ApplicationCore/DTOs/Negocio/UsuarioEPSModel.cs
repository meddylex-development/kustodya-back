using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.DTOs.Negocio
{
    public class UsuarioEPSModel
    {
        public int UsuarioId { get; set; }
        public long EpsId { get; set; }
        public long IpsId { get; set; }
    }
}
