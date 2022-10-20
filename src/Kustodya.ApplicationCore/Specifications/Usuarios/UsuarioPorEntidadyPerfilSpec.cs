using Kustodya.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Usuarios
{
    class UsuarioPorEntidadyPerfilSpec : BaseSpec<TblUsuarios>
    {
        public UsuarioPorEntidadyPerfilSpec(Expression<Func<TblUsuarios, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }
        public UsuarioPorEntidadyPerfilSpec(int entidadId, int? perfil, string busqueda, int? skip, int? take)
            : this(u => u.Entidades.Where(c => c.EntidadId == entidadId).Count() > 0 &&
            (perfil != null ? u.TblUsuariosPerfiles.Where(c => c.IIdperfil == perfil).Count() > 0 : true) &&
            (u.TPrimerNombre.ToLower() +
            (u.TSegundoNombre == null ? " " : (u.TSegundoNombre.Length == 0 ? " " : " " + u.TSegundoNombre.ToLower() + " ")) +
            u.TPrimerApellido.ToLower() +
            (u.TSegundoApellido == null ? " " : (u.TSegundoApellido.Length == 0 ? " " : " " + u.TSegundoApellido.ToLower()))).Contains(busqueda) ||
            u.TIdnumDoc.ToLower() == busqueda.ToLower(), skip, take)
        {
            AddInclude(c => c.Entidades);
            ApplyOrderByDescending(c => c.DtFechaCreacion);
        }
    }
}
