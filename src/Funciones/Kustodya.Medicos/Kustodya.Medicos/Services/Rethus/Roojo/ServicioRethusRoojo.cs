using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Kustodya.ApplicationCore.Constants;
using Roojo.Rethus;
using Kustodya.Medicos.Data;
using Kustodya.Medicos.Models;
using Kustodya.Medicos.Services.Input;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs;
using System.Linq;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.Medicos.Data.Medicos;

namespace Kustodya.Medicos.Services
{

    public class ServicioRethusRoojo : IServicioRethusRoojo
    {
        private readonly RethusContext _context;
        private readonly IAsyncRepository<Tarea> _repoTarea;
        private readonly IAsyncRepository<Consulta> _repoConsulta;
        private readonly TareaFabric _tareaFabric;
        private readonly IMapper _mapper;

        public ServicioRethusRoojo(
            IAsyncRepository<Tarea> repoTarea,
            IAsyncRepository<Consulta> repoConsulta,
            RethusContext context,
            IMapper mapper,
            TareaFabric tareaFabric)
        {
            _mapper = mapper;
            _repoTarea = repoTarea;
            _repoConsulta = repoConsulta;
            _tareaFabric = tareaFabric;
            _context = context;
        }

        [FunctionName(nameof(ConsultarUnMedicoAsync))]
        public async Task<Medico> ConsultarUnMedicoAsync([OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var medico = context.GetInput<Medico>();

            // ConsultarMedicoAsync (Servicio Rethus de Roojo)
            var tareaId = await context.CallActivityAsync<int>(
                nameof(CrearTareaIndividualParaElRobot),
                (medico.NumeroIdentifiacion, medico.TipoIdentificacion)
            );
            // Esperar que se complete la consulta polling con funcion eterna 
            await context.CallSubOrchestratorAsync<List<Medico>>(
                nameof(Data.ServicioConsultaRobot.HacerPollingAlRobot),
                tareaId);
            // Consultar médicos en DB
            var consulta = await context.CallActivityAsync<List<Medico>>(
                            nameof(Data.ServicioConsultaRobot.ConsultarMedicos),
                            (tareaId, new List<Medico> { medico }));
            // consulta.FirstOrDefault().TipoIdentificacion = ApplicationCore.Constants.TipoIdentificacion.Cédula_de_ciudadanía;
            return consulta.FirstOrDefault();
        }

        [FunctionName(nameof(ConsultarMedicoPorNombresAsync))]
        public async Task<ICollection<Medico>> ConsultarMedicoPorNombresAsync([OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var (primerNombre, primerApellido) = context.GetInput<(string, string)>();

            // ConsultarMedicoAsync (Servicio Rethus de Roojo)
            var tareaId = await context.CallActivityAsync<int>(
                nameof(CrearTareaIndividualPorNombresParaElRobot),
                (primerNombre, primerApellido)
            );
            // Esperar que se complete la consulta polling con funcion eterna 
            await context.CallSubOrchestratorAsync<List<Medico>>(
                nameof(Data.ServicioConsultaRobot.HacerPollingAlRobot),
                tareaId);
            // Contestar
            var consulta = await context.CallActivityAsync<List<Medico>>(
                            nameof(Data.ServicioConsultaRobot.ConsultarMedicosPorNombre),
                            (tareaId));
            // consulta.FirstOrDefault().TipoIdentificacion = ApplicationCore.Constants.TipoIdentificacion.Cédula_de_ciudadanía;
            return consulta;
        }

        [FunctionName(nameof(CrearTareaIndividualParaElRobot))]
        public async Task<int> CrearTareaIndividualParaElRobot([ActivityTrigger] (string, Data.Medicos.TiposDeDocumentoDeIdentificacion) context)
        {
            var (numeroIdentificacion, tipoIdentificacion) = context;
            // TODO: Generalizar transformacion de Enums
            TipoIdentificacionRethus tipoDeDocumentoRoojo = TipoIdentificacionRethus.Cédule_de_Ciudadanía;
            //TipoIdentificacionRethus tipoDeDocumentoRoojo = ((int)tipoIdentificacion) == 9 ? TipoIdentificacionRethus.Cédule_de_Ciudadanía : 0;
            switch ((int)tipoIdentificacion)
            {
                case 9:
                    tipoDeDocumentoRoojo = TipoIdentificacionRethus.Cédule_de_Ciudadanía;
                break;
                case 10:
                    tipoDeDocumentoRoojo = TipoIdentificacionRethus.Cédula_de_Extranjería;
                break;
                case 11:
                    tipoDeDocumentoRoojo = TipoIdentificacionRethus.CN_Certificado_de_Nacido_Vivo;
                break;
                case 4:
                    tipoDeDocumentoRoojo = TipoIdentificacionRethus.Nit;
                break;
                case 5:
                    tipoDeDocumentoRoojo = TipoIdentificacionRethus.Pasaporte;
                break;
                case 12:
                    tipoDeDocumentoRoojo = TipoIdentificacionRethus.PE_Permiso_Especial_de_Permanencia;
                break;
                default:
                break;
            }
            
            var tarea = Tarea.Nueva.DesdeDocumento(numeroIdentificacion, tipoDeDocumentoRoojo);

            await _repoTarea.AddAsync(tarea);

            return tarea.Id;
        }

        [FunctionName(nameof(CrearTareaIndividualPorNombresParaElRobot))]
        public async Task<int> CrearTareaIndividualPorNombresParaElRobot([ActivityTrigger] (string, string) context)
        {
            var (primerNombre, primerApellido) = context;
            // TODO: Generalizar transformacion de Enums
            var tarea = Tarea.Nueva.PorNombres(primerNombre, primerApellido);

            await _repoTarea.AddAsync(tarea);

            return tarea.Id;
        }

        [FunctionName(nameof(CrearTareaMultipleParaElRobot))]
        public async Task<int> CrearTareaMultipleParaElRobot([ActivityTrigger] ICollection<Medico> medicos)
        {
            // Crear método en fabrica para CrearDesdeListaDeMedicos
            var tarea = _tareaFabric.NuevaDesdeColeccionDeMedicos(medicos);

            await _repoTarea.AddAsync(tarea);

            return tarea.Id;
        }

        [FunctionName(nameof(ConsultarListaDeMedicosAsync))]
        public async Task<List<Medico>> ConsultarListaDeMedicosAsync([OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var medicos = context.GetInput<List<Medico>>();

            // ConsultarMedicoAsync (Servicio Rethus de Roojo)
            var tareaId = await context.CallActivityAsync<int>(
                nameof(CrearTareaMultipleParaElRobot),
                medicos
            );
            // Esperar que se complete la consulta polling con funcion eterna 
            await context.CallSubOrchestratorAsync(
                nameof(Data.ServicioConsultaRobot.HacerPollingAlRobot),
                tareaId);

            return await context.CallActivityAsync<List<Medico>>(
                nameof(Data.ServicioConsultaRobot.ConsultarMedicos),
                (tareaId, medicos)
            );
        }
        [FunctionName(nameof(ValidarExistenciaMedicoAsync))]
        public async Task<Consulta> ValidarExistenciaMedicoAsync(Medico medico){
            TipoIdentificacionRethus? tipoidrethus = TipoIdentificacionRethus.Cédule_de_Ciudadanía;
            switch(medico.TipoIdentificacion){
                case TiposDeDocumentoDeIdentificacion.Cédula_de_Extranjería:
                    tipoidrethus = TipoIdentificacionRethus.Cédula_de_Extranjería;
                    break;
                case TiposDeDocumentoDeIdentificacion.CN_Certificado_de_Nacido_Vivo:
                    tipoidrethus = TipoIdentificacionRethus.CN_Certificado_de_Nacido_Vivo;
                    break;
                case TiposDeDocumentoDeIdentificacion.Nit:
                    tipoidrethus = TipoIdentificacionRethus.Nit;
                    break;
                case TiposDeDocumentoDeIdentificacion.Pasaporte:
                    tipoidrethus = TipoIdentificacionRethus.Pasaporte;
                    break;
                case TiposDeDocumentoDeIdentificacion.PE_Permiso_Especial_de_Permanencia:
                    tipoidrethus = TipoIdentificacionRethus.PE_Permiso_Especial_de_Permanencia;
                    break;
                case TiposDeDocumentoDeIdentificacion.Resgistro_Civil:
                    tipoidrethus = TipoIdentificacionRethus.Resgistro_Civil;
                    break;
                case TiposDeDocumentoDeIdentificacion.Tarjeta_de_Identidad:
                    tipoidrethus = TipoIdentificacionRethus.Tarjeta_de_Identidad;
                    break;
                default:
                    break;
            }
            var spec = new ConsultaRethusPorTipoIdyNumId(tipoidrethus, medico.NumeroIdentifiacion);
            
            var consultas = await _repoConsulta.ListAsync(spec);
            var consulta = consultas.OrderByDescending(c => c.Id).FirstOrDefault();
            if (consulta == null)
                return consulta;
            var datos = _context.Datos.Where(c=>c.ConsultaId == consulta.Id).ToList();
            var academicos = _context.DatosAcademicos.Where(c=>c.ConsultaId == consulta.Id).ToList();
            var sanciones = _context.Sanciones.Where(c=>c.ConsultaId == consulta.Id).ToList();
            var ssos = _context.DatosSSO.Where(c=>c.ConsultaId == consulta.Id).ToList();
            
            foreach(Dato d in datos){
                consulta.Datos.Add(d);
            }
            foreach(DatoAcademico da in academicos){
                consulta.DatosAcademicos.Add(da);
            }
            foreach(Roojo.Rethus.Sancion s in sanciones){
                consulta.Sanciones.Add(s);
            }

            foreach(Roojo.Rethus.DatoSso sso in ssos){
                consulta.DatosSso.Add(sso);
            }

            //var datosspec = new ConsultaDatosPrincipalesPorId(consulta.Id);
                       /*new ConsultarDatosAcademicosPorId(ConsultaId);
                       new ConsultarSSOsPorId(ConsultaId);*/
            /*var datos = await _repoDato.ListAsync(datosspec);*/

            return consulta;
        }
        
    }
}