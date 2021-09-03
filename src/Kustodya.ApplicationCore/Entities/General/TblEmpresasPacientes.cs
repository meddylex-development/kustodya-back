using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresasPacientes
    {
        public int IIdempresaPaciente { get; set; }
        public string TRazonSocial { get; set; }
        public string TNit { get; set; }
        public string TCiiun { get; set; }
        public string TDireccion { get; set; }
        public string TTelefono { get; set; }
        public string TEmail { get; set; }
    }
}
