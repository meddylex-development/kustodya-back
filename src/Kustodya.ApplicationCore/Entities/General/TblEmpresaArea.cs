using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresaArea
    {
        public TblEmpresaArea()
        {
            TblCargoPerfil = new HashSet<TblCargoPerfil>();
            TblInspeccionExtintoresDetalle = new HashSet<TblInspeccionExtintoresDetalle>();
            TblInspeccionesPrograma = new HashSet<TblInspeccionesPrograma>();
            TblInstalacionElectricaAlumbrado = new HashSet<TblInstalacionElectricaAlumbrado>();
            TblInstalacionElectricaCircuitos = new HashSet<TblInstalacionElectricaCircuitos>();
            TblInstalacionElectricaInterruptores = new HashSet<TblInstalacionElectricaInterruptores>();
            TblInstalacionElectricaTomas = new HashSet<TblInstalacionElectricaTomas>();
        }

        public long IIdempresaArea { get; set; }
        public long IIdempresa { get; set; }
        public string TNombreArea { get; set; }
        public string TCodigo { get; set; }
        public DateTime DtUsuarioCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblCargoPerfil> TblCargoPerfil { get; set; }
        public virtual ICollection<TblInspeccionExtintoresDetalle> TblInspeccionExtintoresDetalle { get; set; }
        public virtual ICollection<TblInspeccionesPrograma> TblInspeccionesPrograma { get; set; }
        public virtual ICollection<TblInstalacionElectricaAlumbrado> TblInstalacionElectricaAlumbrado { get; set; }
        public virtual ICollection<TblInstalacionElectricaCircuitos> TblInstalacionElectricaCircuitos { get; set; }
        public virtual ICollection<TblInstalacionElectricaInterruptores> TblInstalacionElectricaInterruptores { get; set; }
        public virtual ICollection<TblInstalacionElectricaTomas> TblInstalacionElectricaTomas { get; set; }
    }
}
