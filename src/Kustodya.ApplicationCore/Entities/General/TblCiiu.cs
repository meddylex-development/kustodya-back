using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCiiu
    {
        public string Seccion { get; set; }
        public string Division { get; set; }
        public string Grupo { get; set; }
        public string Clase { get; set; }
        public string Descripcion { get; set; }
        public bool? EsSeccion { get; set; }
        public bool? EsDivision { get; set; }
        public bool? EsGrupo { get; set; }
        public bool? EsClase { get; set; }
        public short IId { get; set; }
    }
}
