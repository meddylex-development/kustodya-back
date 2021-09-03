using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.MallaValidadora
{
    public class Grupo : BaseEntity
    {
        private Grupo()
        {

        }

        public Grupo(string Codigo)
        {
            this.Codigo = Codigo;
            this.GrupoDiagnosticos = GrupoDiagnosticos;
        }

        public string Codigo { get; set; }

        public List<GrupoDiagnostico> GrupoDiagnosticos { get; set; }
    }
}
