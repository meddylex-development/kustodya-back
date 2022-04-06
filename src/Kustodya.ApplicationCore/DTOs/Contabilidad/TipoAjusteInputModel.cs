using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.DTOs.Contabilidades
{
    public class TipoAjusteInputModel
    {
        public string Descripcion { get; set; }
        public bool EsTipoAjustePorDefecto { get; set; }
    }
}
