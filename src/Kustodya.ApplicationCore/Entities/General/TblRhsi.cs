using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRhsi
    {
        public long IIdempresa { get; set; }
        public long IIdformato { get; set; }
        public DateTime DtFechaRhsi { get; set; }
        public string TNit { get; set; }
        public string TArl { get; set; }
        public string TNombreEmpresa { get; set; }
        public string TTelefono { get; set; }
        public string TPais { get; set; }
        public string TDepartamento { get; set; }
        public string TCiudad { get; set; }
        public string TDireccion { get; set; }
        public string TSucursales { get; set; }
        public string TRepresentanteLegal { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblFormatos IIdformatoNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
    }
}
