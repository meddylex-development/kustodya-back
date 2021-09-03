using Kustodya.ApplicationCore.Entities;
using System.Linq;

namespace Kustodya.ApplicationCore.Specifications
{
    public sealed class EmpresaSpec : BaseSpec<TblEmpresas>
    {
        public EmpresaSpec(int IIdusuario)
                : base(u => u.TblUsuariosEmpresas.Any(d => d.IIdusuario == IIdusuario && d.BActivo == true) == true)
        {
            base.AddInclude(d => d.IIdtipoIdentificacionNavigation);
        }

        public EmpresaSpec(long idEmpresa) : base(u => u.IIdempresa == idEmpresa)
        {
            base.AddInclude(d => d.IIdtipoIdentificacionNavigation);
        }

        public EmpresaSpec(string nit) : base(u => u.TNumeroIdentificacion == nit)
        {
            base.AddInclude(d => d.IIdtipoIdentificacionNavigation);
        }

        public EmpresaSpec(string name, bool exact) : base(u => u.TNombreComercial.Contains(name))
        {
            base.AddInclude(d => d.IIdtipoIdentificacionNavigation);
        }
    }
}