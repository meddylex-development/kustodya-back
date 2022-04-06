using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRiesgoControlValoraciones
    {
        public long IIdriesgoControlValoracion { get; set; }
        public long IIdriesgoControl { get; set; }
        public long IIdcontrolHerramienta { get; set; }
        public long IIdcontrolProcedimiento { get; set; }
        public long IIdcontrolEficacia { get; set; }
        public long IIdcontrolResponsable { get; set; }
        public long IIdcontrolFrecuencia { get; set; }
        public int ITotal { get; set; }
        public DateTime DtFechaInsercion { get; set; }
        public int IUsuarioInsercion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresaControlEficacia IIdcontrolEficaciaNavigation { get; set; }
        public virtual TblEmpresaControlFrecuencia IIdcontrolFrecuenciaNavigation { get; set; }
        public virtual TblEmpresaControlHerramientas IIdcontrolHerramientaNavigation { get; set; }
        public virtual TblEmpresaControlProcedimientos IIdcontrolProcedimientoNavigation { get; set; }
        public virtual TblEmpresaControlResponsable IIdcontrolResponsableNavigation { get; set; }
        public virtual TblRiesgoControles IIdriesgoControlNavigation { get; set; }
        public virtual TblUsuarios IUsuarioInsercionNavigation { get; set; }
    }
}
