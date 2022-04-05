using Kustodya.ApplicationCore.Entities;
using System.Linq;
using System;

namespace Kustodya.ApplicationCore.Specifications.Negocio
{
    public class CargosSpec : BaseSpec<TblCargos>
    {
        public CargosSpec(string name) : base(u => u.TNombreCargo.Contains(name))
        {
        }
    }
}