using Kustodya.ApplicationCore.Entities.MallaValidadora;
using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities.MallaValidadora
{
    public partial class GrupoDiagnostico : BaseEntity
    {
        private Grupo grupo;
        private Diagnostico diagnostico;

        private GrupoDiagnostico()
        {

        }

        public GrupoDiagnostico(Diagnostico diagnostico, Grupo grupo)
        {
            Grupo = grupo;
            Diagnostico = diagnostico;
        }

        public string CodigoDelGrupo { get; private set; }
        public string CodigoDelDiagnostico { get; private set; }

        public Grupo Grupo
        {
            get => grupo; private set
            {
                CodigoDelGrupo = value.Codigo;
                grupo = value;
            }
        }

        public Diagnostico Diagnostico
        {
            get => diagnostico; private set
            {
                CodigoDelDiagnostico = value.CodigoCie10;
                diagnostico = value;
            }
        }
    }
}
