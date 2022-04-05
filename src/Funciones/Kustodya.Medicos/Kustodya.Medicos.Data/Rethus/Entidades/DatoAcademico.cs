using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Roojo.Rethus
{
    public partial class DatoAcademico
    {
        public int Id { get; set; }
        public int? ConsultaId { get; set; }
        public string TipoPrograma { get; set; }
        public string OrigenObtencionTitulo { get; set; }
        public string ProfesionOcupacion { get; set; }
        public string FechaInicioEjercerActoAdmin { get; set; }
        public string ActoAdministrativo { get; set; }
        public string EntidadReportadora { get; set; }

        // [JsonIgnore]
        // public virtual Consulta Consulta { get; set; }

        public static class Nuevo
        {
            public static DatoAcademico DePrueba(int idDeLaConsulta)
            {
                return new DatoAcademico
                {
                    Id = 100,
                    ConsultaId = idDeLaConsulta,
                    TipoPrograma = "UNV",
                    OrigenObtencionTitulo = "Local",
                    ProfesionOcupacion = "Maestro Jedi",
                    FechaInicioEjercerActoAdmin = "2018-02-19",
                    ActoAdministrativo = "31106",
                    EntidadReportadora = "Alto Concilio Jedi"
                };
            }
        }
    }
}
