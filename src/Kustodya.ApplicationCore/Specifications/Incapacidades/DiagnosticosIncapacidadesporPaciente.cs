using Kustodya.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Incapacidades
{
    public class DiagnosticosIncapacidadesporPaciente : BaseSpec<TblDiagnosticosIncapacidades>
    {
        public DiagnosticosIncapacidadesporPaciente(int iIDPaciente)
                : base(u => u.IIdpaciente == iIDPaciente)
        {
        }
    }
}