using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class TerceroporNumIdNombreyTipoSpec : BaseSpec<Tercero>
    {
        public TerceroporNumIdNombreyTipoSpec(Expression<Func<Tercero, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }
        public TerceroporNumIdNombreyTipoSpec(string busqueda, TiposPersona? tipoPersona, int? skip, int? take)
                : this(u => tipoPersona == null ? true : u.TipoPersona == tipoPersona &&
                (busqueda == null ? true : (u.PrimerNombre.ToLower() +
                (u.SegundoNombre == null ? " " : (u.SegundoNombre.Length == 0 ? " " : " " + u.SegundoNombre.ToLower() + " ")) +
                u.PrimerApellido.ToLower() +
                (u.SegundoApellido == null ? " " : (u.SegundoApellido.Length == 0 ? " " : " " + u.SegundoApellido.ToLower()))).Contains(busqueda) ||
                u.RazonSocial.ToLower().Contains(busqueda) ||
                u.NumeroId.ToLower() == busqueda.ToLower()) , skip, take)
        {
        }
    }
}
