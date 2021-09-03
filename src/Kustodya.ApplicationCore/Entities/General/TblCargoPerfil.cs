using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCargoPerfil
    {
        public TblCargoPerfil()
        {
            TblCargoPerfilCompetenciasCorporativas = new HashSet<TblCargoPerfilCompetenciasCorporativas>();
            TblCargoPerfilCompetenciasFuncionales = new HashSet<TblCargoPerfilCompetenciasFuncionales>();
            TblCargoPerfilFuncionesAmbientales = new HashSet<TblCargoPerfilFuncionesAmbientales>();
            TblCargoPerfilFuncionesSst = new HashSet<TblCargoPerfilFuncionesSst>();
            TblCargoPerfilIdiomas = new HashSet<TblCargoPerfilIdiomas>();
            TblCargoPerfilNivelAcademico = new HashSet<TblCargoPerfilNivelAcademico>();
            TblCargoPerfilNivelAutoridad = new HashSet<TblCargoPerfilNivelAutoridad>();
            TblCargoPerfilObjetivos = new HashSet<TblCargoPerfilObjetivos>();
            TblCargoPerfilResponsabilidadSst = new HashSet<TblCargoPerfilResponsabilidadSst>();
            TblCargoPerfilResponsabilidades = new HashSet<TblCargoPerfilResponsabilidades>();
        }

        public long IIdcargoPerfil { get; set; }
        public long IIdempresa { get; set; }
        public long IIdcargo { get; set; }
        public DateTime DtFechaActualizacion { get; set; }
        public int IEdadDesde { get; set; }
        public int IEdadHasta { get; set; }
        public long? IGenero { get; set; }
        public int IExperienciaAños { get; set; }
        public bool BEstudioSeguridad { get; set; }
        public bool BVisitaDomiciliaria { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }
        public long IIdarea { get; set; }

        public virtual TblEmpresaArea IIdareaNavigation { get; set; }
        public virtual TblCargos IIdcargoNavigation { get; set; }
        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblCargoPerfilCompetenciasCorporativas> TblCargoPerfilCompetenciasCorporativas { get; set; }
        public virtual ICollection<TblCargoPerfilCompetenciasFuncionales> TblCargoPerfilCompetenciasFuncionales { get; set; }
        public virtual ICollection<TblCargoPerfilFuncionesAmbientales> TblCargoPerfilFuncionesAmbientales { get; set; }
        public virtual ICollection<TblCargoPerfilFuncionesSst> TblCargoPerfilFuncionesSst { get; set; }
        public virtual ICollection<TblCargoPerfilIdiomas> TblCargoPerfilIdiomas { get; set; }
        public virtual ICollection<TblCargoPerfilNivelAcademico> TblCargoPerfilNivelAcademico { get; set; }
        public virtual ICollection<TblCargoPerfilNivelAutoridad> TblCargoPerfilNivelAutoridad { get; set; }
        public virtual ICollection<TblCargoPerfilObjetivos> TblCargoPerfilObjetivos { get; set; }
        public virtual ICollection<TblCargoPerfilResponsabilidadSst> TblCargoPerfilResponsabilidadSst { get; set; }
        public virtual ICollection<TblCargoPerfilResponsabilidades> TblCargoPerfilResponsabilidades { get; set; }
    }
}
