using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPerfilSocioDemografico
    {
        public TblPerfilSocioDemografico()
        {
            TblPerfilSocioDemoAfp = new HashSet<TblPerfilSocioDemoAfp>();
            TblPerfilSocioDemoCargo = new HashSet<TblPerfilSocioDemoCargo>();
            TblPerfilSocioDemoEdad = new HashSet<TblPerfilSocioDemoEdad>();
            TblPerfilSocioDemoEps = new HashSet<TblPerfilSocioDemoEps>();
            TblPerfilSocioDemoEstadoCivil = new HashSet<TblPerfilSocioDemoEstadoCivil>();
            TblPerfilSocioDemoFormacionEduc = new HashSet<TblPerfilSocioDemoFormacionEduc>();
            TblPerfilSocioDemoSucursal = new HashSet<TblPerfilSocioDemoSucursal>();
            TblPerfilSocioDemoTipoVincul = new HashSet<TblPerfilSocioDemoTipoVincul>();
        }

        public long IIdperfilSocioDemografico { get; set; }
        public long IIdempresa { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblPerfilSocioDemoAfp> TblPerfilSocioDemoAfp { get; set; }
        public virtual ICollection<TblPerfilSocioDemoCargo> TblPerfilSocioDemoCargo { get; set; }
        public virtual ICollection<TblPerfilSocioDemoEdad> TblPerfilSocioDemoEdad { get; set; }
        public virtual ICollection<TblPerfilSocioDemoEps> TblPerfilSocioDemoEps { get; set; }
        public virtual ICollection<TblPerfilSocioDemoEstadoCivil> TblPerfilSocioDemoEstadoCivil { get; set; }
        public virtual ICollection<TblPerfilSocioDemoFormacionEduc> TblPerfilSocioDemoFormacionEduc { get; set; }
        public virtual ICollection<TblPerfilSocioDemoSucursal> TblPerfilSocioDemoSucursal { get; set; }
        public virtual ICollection<TblPerfilSocioDemoTipoVincul> TblPerfilSocioDemoTipoVincul { get; set; }
    }
}
