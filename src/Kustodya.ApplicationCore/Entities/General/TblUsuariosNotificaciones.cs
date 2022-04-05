using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblUsuariosNotificaciones
    {
        public short IId { get; set; }
        public string TPrimerNombre { get; set; }
        public string TSegundoNombre { get; set; }
        public string TPrimerApellido { get; set; }
        public string TSegundoApellido { get; set; }
        public string TEmail { get; set; }
        public string TNumeroCelular { get; set; }
        public string TNombreEmpresa { get; set; }
        public string TCargo { get; set; }
        public bool? BActivo { get; set; }
        public long? IIdips { get; set; }
    }
}
