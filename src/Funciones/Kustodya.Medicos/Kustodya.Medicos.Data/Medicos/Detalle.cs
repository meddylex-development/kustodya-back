using System;

namespace Kustodya.Medicos.Data
{
    public class Detalle : BaseEntity
    {
        public Detalle() : base(nameof(Detalle))
        {
            var guid = Guid.NewGuid();
            base.id = $"{nameof(Detalle)}|{guid}";
        }

        public string MedicoId { get; set; }
        public string TipoProgramaOrigen { get; set; }
        public string TituloObtenido { get; set; }
        public string Ocupacion { get; set; }
        public string AutorizadoParaEjercerHasta { get; set; }
        public string EntidadQueReporta { get; set; }
        public string ActoAdministrativo { get; set; }

        public static class Nuevo
        {
            public static Detalle DePrueba(Guid idDelMedico)
            {
                return new Detalle
                {
                    MedicoId = idDelMedico.ToString(),
                    TipoProgramaOrigen = "UNV",
                    TituloObtenido = "Local",
                    Ocupacion = "MEDICINA",
                    AutorizadoParaEjercerHasta = "2018-02-19",
                    ActoAdministrativo = "57964",
                    EntidadQueReporta = "COLEGIO MEDICO COLOMBIANO",
                };
            }
        }
    }
}
