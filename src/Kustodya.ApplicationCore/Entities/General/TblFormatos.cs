using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblFormatos
    {
        public TblFormatos()
        {
            TblRhsi = new HashSet<TblRhsi>();
            TblRhsiactividadEconomica = new HashSet<TblRhsiactividadEconomica>();
            TblRhsiriesgos = new HashSet<TblRhsiriesgos>();
        }

        public long IIdformato { get; set; }
        public string TDescripcion { get; set; }
        public long? IIdclaseFormato { get; set; }
        public int IVersion { get; set; }
        public string TContenido { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblMultivalores IIdclaseFormatoNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblRhsi> TblRhsi { get; set; }
        public virtual ICollection<TblRhsiactividadEconomica> TblRhsiactividadEconomica { get; set; }
        public virtual ICollection<TblRhsiriesgos> TblRhsiriesgos { get; set; }
    }
}
