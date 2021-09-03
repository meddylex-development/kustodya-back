using System;
using Kustodya.Core.Entities;
using Kustodya.Core.Interfaces;

namespace Kustodya.Core.Reportes.Entities
{
    public class Solicitud : BaseEntity, IAggregateRoot
    {
        private Solicitud() : base(nameof(Solicitud))
        {
        }
        
        private Solicitud(int usuarioId, int entidadId, Reporte reporte)
            : base(nameof(Solicitud))
        {
            UsuarioId = usuarioId;
            EntidadId = entidadId;
            Reporte = reporte;
            ReporteId = reporte.Id;
            Solicitado = DateTime.Now;
        }

        public int UsuarioId { get; private set; }
        public int EntidadId { get; private set; }
        public DateTime Solicitado { get; private set; }
        public bool Aprobada { get; private set; }
        public Reporte Reporte { get; private set; }
        public Guid ReporteId { get; private set; }
        public Guid WorkspaceId { get; private set; }

        internal static class Fabrica
        {
            public static Solicitud CrearAprobado(int usuarioId, int entidadId, Reporte reporte)
            {
                // TODO: Validar Entidad
                // TODO: Validar Usuario
                return new Solicitud(usuarioId, entidadId, reporte)
                {
                    Aprobada = reporte.EsHorarioValido()
                };
            }
        }
    }
}