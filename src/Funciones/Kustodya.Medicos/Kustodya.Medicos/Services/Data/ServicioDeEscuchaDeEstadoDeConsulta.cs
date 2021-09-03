using System;
using System.Threading;
using System.Threading.Tasks;
using Roojo.Rethus;
using Kustodya.Medicos.Data;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Kustodya.ApplicationCore.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Kustodya.Medicos.Data
{
    public class ServicioConsultaRobot
    {
        private readonly IAsyncRepository<Tarea> _repo;
        private readonly IMapper _mapper;
        private readonly RethusContext _context;

        public ServicioConsultaRobot(
            // IAsyncRepository<Tarea> repo,
            IMapper mapper,
            RethusContext context)
        {
            // _repo = repo;
            _mapper = mapper;
            _context = context;
        }

        [FunctionName(nameof(HacerPollingAlRobot))]
        public async Task HacerPollingAlRobot([OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            int tareaId = context.GetInput<int>();

            var tarea = await context.CallActivityAsync<Tarea>(
                nameof(ConsultarTareaFinalizada),
                tareaId);

            using var cts = new CancellationTokenSource();
            if (tarea is null)
            {
                await context.CreateTimer(context.CurrentUtcDateTime.AddMilliseconds(5000), cts.Token);
                context.ContinueAsNew(tareaId);
            }
        }

        [FunctionName(nameof(ConsultarTareaFinalizada))]
        public async Task<Tarea> ConsultarTareaFinalizada([ActivityTrigger] int tareaId)
        {
            // var spec = new TareaFinalizadaSpec(tareaId);
            // var tarea = await _repo.GetOneAsync(spec);
            var tarea = await _context.Tareas
                .Where(t => t.Id == tareaId && t.Estado == EstadosTareas.Exitoso
                    && t.Consultas.All(c => c.Estado == Consulta.Estados.Exitoso))
                .FirstOrDefaultAsync();
            return tarea;
        }

        [FunctionName(nameof(ConsultarMedicos))]
        public async Task<ICollection<Medico>> ConsultarMedicos([ActivityTrigger] (int, ICollection<Medico>) input)
        {
            var (tareaId, medicos) = input;

            // var spec = new TareaFinalizadaSpec(tareaId);
            // var tarea = await _repo.GetOneAsync(spec);
            var tarea = await _context.Tareas
                .Include(t => t.Consultas)
                .ThenInclude(t => t.Datos)
                .Where(t => t.Id == tareaId && t.Estado == EstadosTareas.Exitoso)
                .Include(t => t.Consultas)
                .ThenInclude(c => c.DatosAcademicos)
                .Include(t => t.Consultas)
                .ThenInclude(c => c.Sanciones)
                .Include(t => t.Consultas)
                .ThenInclude(c => c.DatosSso)
                .FirstOrDefaultAsync();

            var medicosConsultados = (ICollection<Medico>)_mapper.Map(
                tarea.Consultas.ToList(), medicos.ToList(), 
                typeof(List<Consulta>), typeof(List<Medico>));
                
            return medicosConsultados;
            // return _mapper.Map<ICollection<Consulta>, List<Medico>>(tarea.Consultas);
        }

        [FunctionName(nameof(ConsultarMedicosPorNombre))]
        public async Task<ICollection<Medico>> ConsultarMedicosPorNombre([ActivityTrigger] int input)
        {
            var tareaId = input;

            var tarea = await _context.Tareas
                .Where(t => 
                    t.Id == tareaId 
                    && t.Estado == EstadosTareas.Exitoso)
                .Include(t => t.Consultas)
                .ThenInclude(t => t.Datos)
                .Include(t => t.Consultas)
                .FirstOrDefaultAsync();

            var medicosConsultados = (ICollection<Medico>)_mapper.Map<List<Medico>>(
                tarea.Consultas.FirstOrDefault().Datos.ToList());
                
            return medicosConsultados;
        }
    }
}