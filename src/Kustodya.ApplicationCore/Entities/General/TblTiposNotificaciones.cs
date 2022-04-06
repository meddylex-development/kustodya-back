using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblTiposNotificaciones
    {
        public byte Iid { get; set; }
        public string TNombre { get; set; }
        public string TDescripcion { get; set; }
        public bool? BActivo { get; set; }
    }
}
