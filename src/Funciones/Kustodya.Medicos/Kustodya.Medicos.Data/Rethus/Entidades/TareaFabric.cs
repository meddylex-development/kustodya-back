using System;
using System.Collections.Generic;
using System.Linq;
using Kustodya.Medicos.Data;
using Roojo.Rethus;

namespace Roojo.Rethus
{
    public class TareaFabric
    {
        private readonly IConsultasFabric _consultasFabric;

        public TareaFabric(IConsultasFabric consultasFabric)
        {
            _consultasFabric = consultasFabric;
        }

        public Tarea NuevaDesdeColeccionDeMedicos(ICollection<Medico> medicos)
        {
            var tarea = new Tarea
            {
                TipoTarea = Tarea.TiposDeTarea.Multiple,
                FechaAsignacion = DateTime.Now,
                Estado = EstadosTareas.PorHacer,
                Prioridad = 2
                // TODO: Agregar usuario creador
                // UsuarioAsignadorId = usuarioId
            };

            tarea.Consultas = medicos.Select(m => _consultasFabric.NuevaDesdeMedicoPorTipoDeIdentificacion(m)).ToList();

            return tarea;
        }
    }
}
