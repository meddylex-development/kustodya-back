// TODO: Agregar interfaz a EfCore DbContext para no depender de esa tecnología
using System;
using System.Collections.Generic;
using Kustodya.Core.Entities;
using Kustodya.Core.Interfaces;

namespace Kustodya.Core.Reportes.Entities
{
    public class Reporte : BaseEntity, IAggregateRoot
    {
        private Reporte() : base(nameof(Reporte)) { }
        private Reporte(Guid id, Guid workspaceId) : base(nameof(Reporte), id)
        {
            WorkspaceId = workspaceId;
        }

        public Guid WorkspaceId { get; private set; }
        public List<Solicitud> Solicitudes { get; private set; } = new List<Solicitud>();
        //  => _solicitudes.AsReadOnly();
        // private readonly List<SolicitudDeUso> _solicitudes = new List<SolicitudDeUso>();
        public Horario Horario { get; set; } = new Horario();

        public Solicitud SolicitarUso(int usuarioId, int entidadId)
        {
            var solicitud = Entities.Solicitud.Fabrica.CrearAprobado(usuarioId, entidadId, this);
            this.Solicitudes.Add(solicitud);
            return solicitud;
        }

        public static class Fabrica
        {
            public static Reporte Crear(Guid id, Guid workspaceId)
            {
                return new Reporte(id, workspaceId);
            }
        }

        public bool EsHorarioValido()
        {
            return DateTime.Now > Horario.FechaInicio && DateTime.Now < Horario.FechaFin;
        }
    }

    public class Horario // ValueType
    {
        public DateTimeOffset FechaInicio { get; set; } = DateTime.Now.Date.AddHours(8);
        public DateTimeOffset FechaFin { get; set; } = DateTime.Now.Date.AddHours(18);
    }
}