using System;

namespace Kustodya.Core.Reportes.DTOs
{
    public class SolicitudReporteModel
    {
        public int UsuarioId { get; set; }
        public int EntidadId { get; set; }
        public Guid ReporteId { get; set; }
        public Guid WorkspaceId { get; set; }
    }
}