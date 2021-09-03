namespace Roojo.Rethus
{
    public partial class DatoSso
    {
        public int Id { get; set; }
        public int ConsultaId { get; set; }
        public string TipoPrestacion { get; set; }
        public string TipoLugarPrestacion { get; set; }
        public string LugarPrestacion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string ModalidadPrestacion { get; set; }
        public string ProgramaPrestacion { get; set; }
        public string EntidadReportadora { get; set; }

        public static class Nuevo
        {
            public static DatoSso DePrueba(int idDeLaConsulta)
            {
                return new DatoSso
                {
                    Id = 10,
                    ConsultaId = idDeLaConsulta,
                    TipoPrestacion = "Presto SSO",
                    TipoLugarPrestacion = "Local",
                    LugarPrestacion = "COLOMBIA|META|VILLAVICENCIO",
                    FechaInicio = "1987-09-06",
                    FechaFin = "1988-09-06",
                    ModalidadPrestacion = "Prestación de Servicios Profesionales de Salud en IPS Habilitada",
                    ProgramaPrestacion = "Medicina",
                    EntidadReportadora = "COLEGIO MEDICO COLOMBIANO"
                };
            }
        }
    }
}
