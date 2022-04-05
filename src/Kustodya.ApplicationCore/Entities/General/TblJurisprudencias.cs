using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblJurisprudencias
    {
        public TblJurisprudencias()
        {
            TblDiagnosticoCondicionTrabajo = new HashSet<TblDiagnosticoCondicionTrabajo>();
            TblEmpresaJurisprudencias = new HashSet<TblEmpresaJurisprudencias>();
            TblSoportes1 = new HashSet<TblSoportes1>();
        }

        public long IIdjurisprudencia { get; set; }
        public long IIdemisor { get; set; }
        public long ILegislacion { get; set; }
        public int INumero { get; set; }
        public int IAño { get; set; }
        public string TDescripcion { get; set; }
        public string TArticulos { get; set; }
        public string TObligacion { get; set; }
        public string TControl { get; set; }
        public int IUsuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmisores IIdemisorNavigation { get; set; }
        public virtual TblMultivalores ILegislacionNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblDiagnosticoCondicionTrabajo> TblDiagnosticoCondicionTrabajo { get; set; }
        public virtual ICollection<TblEmpresaJurisprudencias> TblEmpresaJurisprudencias { get; set; }
        public virtual ICollection<TblSoportes1> TblSoportes1 { get; set; }
    }
}
