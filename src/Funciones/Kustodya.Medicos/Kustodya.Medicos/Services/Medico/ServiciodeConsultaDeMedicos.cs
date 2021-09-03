using AutoMapper;
using ClosedXML.Excel;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.Medicos.Data;
using Kustodya.Medicos.Data.Medicos;
using Kustodya.Medicos.Models;
using Kustodya.Medicos.Services.Input;
using Kustodya.Medicos.Specifications;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Roojo.Rethus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using xMedico = Kustodya.Medicos.Data.Medico;


namespace Kustodya.Medicos.Services
{
    public class ServiciodeConsultaDeMedicos : IServicioDeConsultaDeMedicos
    {
        #region Dependency Injection
        private readonly RethusContext _context;
        private readonly IAsyncRepository<Consulta> _repoConsulta;
        public ServiciodeConsultaDeMedicos(
            IServicioRethusRoojo rethusService,
            IMapper mapper,
            IOptionsMonitor<OpcionesServicioDeConsultaDeMedicos> options,
            IServiceScopeFactory serviceScope,
            ILogger<ServiciodeConsultaDeMedicos> logger,
            RethusContext context,
            IAsyncRepository<Consulta> repoConsulta)
        {
            _options = options.CurrentValue;
            diasObsolencia = _options.DiasObsolencia;
            servicioRethusHabilitado = _options.ServicioRethusHabilitado;
            _serviceScope = serviceScope;
            //_medicoRepo = medicoRepo;
            _rethusService = rethusService;
            _mapper = mapper;
            _logger = logger;
            _context = context;
            _repoConsulta = repoConsulta;
        }

        private readonly OpcionesServicioDeConsultaDeMedicos _options;
        private readonly IServiceScopeFactory _serviceScope;
        private readonly IServicioRethusRoojo _rethusService;
        private readonly ILogger<ServiciodeConsultaDeMedicos> _logger;
        private readonly IMapper _mapper;
        private readonly int diasObsolencia;
        private readonly bool servicioRethusHabilitado;
        #endregion

        [FunctionName(nameof(GetMedicoAsync))]
        public async Task<Medico> GetMedicoAsync([OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var (consultaMedico, peticionId) = context.GetInput<(Registro, Guid)>();

            _logger.LogInformation($"ℹ Peticion: {peticionId}, Consultando Medico: '{consultaMedico.NumeroIdentificacion}'...");

            var medicoLocal = await context.CallActivityAsync<Medico>(
                            nameof(ConsultarExistenteAsync),
                                new Medico(peticionId)
                                {
                                    NumeroIdentifiacion = consultaMedico.NumeroIdentificacion,
                                    TipoIdentificacion =
                                        (Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion)
                                        Enum.Parse(
                                            typeof(Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion),
                                    consultaMedico.TipoIdentificacion.ToString())
                                }
                            );
            if (medicoLocal != null){
                return medicoLocal;
            }
            try
            {
                //if (RegistroLocalNoEsObsoleto(medicoLocal, context.CurrentUtcDateTime)) return medicoLocal;

                if (!servicioRethusHabilitado) throw new ErrorEnConsultaException();
                // Consultar servicio de Rethus
                var medicoRethus = await context.CallSubOrchestratorAsync<Medico>(
                    nameof(ServicioRethusRoojo.ConsultarUnMedicoAsync),
                    new Medico(peticionId)
                    {
                        NumeroIdentifiacion = consultaMedico.NumeroIdentificacion,
                        TipoIdentificacion =
                            (Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion)
                            Enum.Parse(
                                typeof(Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion),
                        consultaMedico.TipoIdentificacion.ToString())
                    });

                if (medicoRethus.NumeroIdentifiacion is null && medicoRethus.NumeroIdentificacion is null) return null;

                return await context.CallActivityAsync<Medico>(
                    nameof(AgregarMedico),
                    medicoRethus
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        [FunctionName("GetMedicosAsync")]
        public async Task<List<Medico>> GetMedicosAsync([OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var (medicos, peticionId, paginaActual) = context.GetInput<(List<Registro>, Guid, int)>();
            _logger.LogInformation($"ℹ Procesando pagina {paginaActual} . Petición: {peticionId}");

            var existentes = await context.CallActivityAsync<List<Medico>>(
                nameof(ConsultarExistentes),
                medicos
            );

            var obsoletos = new List<Medico>(); //FiltrarMedicosExistentes(peticionId, existentes, context.CurrentUtcDateTime);
            var vigentes = existentes; //FiltrarMedicosVigentes(peticionId, existentes, context.CurrentUtcDateTime);
            List<Medico> faltantes = new List<Medico>();
            if(existentes.Count() == 0){
                faltantes = FiltrarMedicosFaltantes(medicos, peticionId, existentes);
            }
            else{
                faltantes = FiltrarMedicosFaltantes(medicos, existentes.First().PeticionId, existentes);
            }

            _logger.LogInformation($"ℹ Procesando {medicos.Count} registros asi:\n" +
                $"  📎   Existentes {existentes.Count()}" +
                $"  ⏲  Obsoletos {obsoletos.Count()  }" +
                $"  ✅  Vigentes {vigentes.Count()    }" +
                $"  ❓   Faltantes {faltantes.Count()  }");

            List<Medico> nuevos = new List<Medico>();
            if (faltantes.Count() > 0)
                nuevos = await context.CallSubOrchestratorAsync<List<Medico>>(
                    nameof(ServicioRethusRoojo.ConsultarListaDeMedicosAsync),
                    faltantes.ToList()
                );
            
            foreach (Medico M in nuevos){
                M.CargueId = peticionId;
            }
            foreach (Medico M in existentes){
                M.CargueId = peticionId;
            }
            /*List<Medico> actualizados = new List<Medico>();
            if (obsoletos.Count() > 0)
                actualizados = await context.CallSubOrchestratorAsync<List<Medico>>(
                    nameof(ServicioRethusRoojo.ConsultarListaDeMedicosAsync),
                    obsoletos
                );
            */
            if (nuevos.Count() > 0)
                await context.CallActivityAsync<List<Medico>>(
                    nameof(AgregarMedicos),
                    nuevos
                );
            if (existentes.Count() > 0)
                await context.CallActivityAsync<List<Medico>>(
                    nameof(AgregarMedicos),
                    existentes
                );

            /*if (obsoletos.Count() > 0)
                await context.CallActivityAsync<List<Medico>>(
                    nameof(ActualizarMedicos),
                    actualizados
                );

            await context.CallActivityAsync<List<Medico>>(
                nameof(ActualizarMedicos),
                vigentes
            );*/

            //return vigentes.Concat(nuevos).Concat(actualizados).ToList();
            return vigentes.Concat(nuevos).ToList();
        }

        [FunctionName(nameof(ConsultarExistentes))]
        public async Task<IReadOnlyList<Medico>> ConsultarExistentes([ActivityTrigger] List<Medico> medicos, IBinder binder)
        {
            /*var container = Environment.GetEnvironmentVariable("CosmosDb:DefaultContainer");
            var database = Environment.GetEnvironmentVariable("CosmosDb:DatabaseName");
            var idsMedicos = medicos.Select(m => m.NumeroIdentificacion).ToList();
            var cosmosBinding = new CosmosDBAttribute(database, container)
            {
                ConnectionStringSetting = "CosmosDb:ConnectionString",
                SqlQuery = $@"
                    SELECT *
                    FROM 
                        c
                    WHERE 
                        c.Discriminator = 'Medico' 
                        AND c.TipoIdentificacion != 0
                        AND c.NumeroIdentificacion IN ('{string.Join("', '", idsMedicos)}')
                    "
            };
            var totalRegistros = binder.Bind<IEnumerable<Medico>>(cosmosBinding).ToList();

            List<Medico> existentes = new List<Medico>();
            foreach(Medico M in totalRegistros){
                if(existentes.Where(c=>c.NumeroIdentificacion == M.NumeroIdentificacion).Count() == 0){
                    existentes.Add(M);
                }else if (existentes.Where(c=>c.NumeroIdentificacion == M.NumeroIdentificacion && c.FechaCreacion < M.FechaCreacion).Count() > 0){
                    var remover = existentes.Where(c=>c.NumeroIdentificacion == M.NumeroIdentificacion && c.FechaCreacion < M.FechaCreacion).First();
                    existentes.Remove(remover);
                    existentes.Add(M);
                }
            }
            return existentes.ToList().AsReadOnly();*/
            List<Consulta> listaConsultas = new List<Consulta>();
            
            foreach(Medico M in medicos){
                TipoIdentificacionRethus? tipoidrethus = TipoIdentificacionRethus.Cédule_de_Ciudadanía;
                switch(M.TipoIdentificacion){
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
                var spec = new ConsultaRethusPorTipoIdyNumId(tipoidrethus, M.NumeroIdentificacion);
                var consultas = await _repoConsulta.ListAsync(spec);
                var consulta = consultas.OrderByDescending(c => c.Id).FirstOrDefault();
                if (consulta == null)
                    continue;
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
                listaConsultas.Add(consulta);
            }
            return _mapper.Map<List<Medico>>(listaConsultas);
            /*List<Medico> medicosExistentes = new List<Medico>();
            Data.Medicos.TiposDeDocumentoDeIdentificacion TipoId = new Data.Medicos.TiposDeDocumentoDeIdentificacion();
            foreach(Dato dato in datos){
                switch(dato.TipoIdentificacion){
                    case "CC":
                        TipoId = Data.Medicos.TiposDeDocumentoDeIdentificacion.Cédula_de_Ciudadanía;
                        break;
                    case "CE":
                        TipoId = Data.Medicos.TiposDeDocumentoDeIdentificacion.Cédula_de_Extranjería;
                        break;
                    default:
                        TipoId = Data.Medicos.TiposDeDocumentoDeIdentificacion.Cédula_de_Ciudadanía;
                        break;
                }  
                Medico M = new Medico(new Guid()){
                    NumeroIdentificacion = dato.NumeroIdentificacion,
                    TipoIdentificacion = TipoId
                };
                medicosExistentes.Add(M);
            }*/
            //return medicosExistentes;
        }

        [FunctionName(nameof(ConsultarExistenteAsync))]
        public async Task<Medico> ConsultarExistenteAsync([ActivityTrigger] Medico medico)
        {
            var Consulta = await _rethusService.ValidarExistenciaMedicoAsync(medico);
            if (Consulta == null){
                return null;
            }
            return _mapper.Map<Medico>(Consulta);
            /*var sp = _serviceScope.CreateScope().ServiceProvider;
            var _medicoRepo = sp.GetRequiredService<ICosmosDbAsyncRepository<Medico, MedicosContext>>();

            var spec = new MedicosExistenteSinErrorSpec(medico.NumeroIdentifiacion, 
            (Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion)medico.TipoIdentificacion);

            var medicos = await _medicoRepo.ListAsync(spec);
            return medicos.OrderByDescending(m => m.UltimaActualizacion).FirstOrDefault();*/
        }

        [FunctionName(nameof(ActualizarMedicos))]
        public async Task ActualizarMedicos([ActivityTrigger] List<Medico> medicos)
        {
            var sp = _serviceScope.CreateScope().ServiceProvider;
            var _medicoRepo = sp.GetRequiredService<ICosmosDbAsyncRepository<Medico, MedicosContext>>();

            await _medicoRepo.UpdateAsync(medicos);
        }

        [FunctionName(nameof(AgregarMedicos))]
        public async Task AgregarMedicos([ActivityTrigger] List<Medico> medicos)
        {
            var sp = _serviceScope.CreateScope().ServiceProvider;
            var _medicoRepo = sp.GetRequiredService<ICosmosDbAsyncRepository<Medico, MedicosContext>>();

            await _medicoRepo.AddAsync(medicos);
        }

        [FunctionName(nameof(AgregarMedico))]
        public async Task<Medico> AgregarMedico([ActivityTrigger] Medico medico)
        {
            var sp = _serviceScope.CreateScope().ServiceProvider;
            var _medicoRepo = sp.GetRequiredService<ICosmosDbAsyncRepository<Medico, MedicosContext>>();
            medico.UltimaActualizacion = DateTime.Now;

            return await _medicoRepo.AddAsync(medico);
        }

        [FunctionName(nameof(GetMedicosPorNombreAsync))]
        public async Task<List<Medico>> GetMedicosPorNombreAsync([OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var (primerNombre, primerApellido, guid) = context.GetInput<(string, string, Guid)>();
            var medicos = await context.CallActivityAsync<List<Medico>>(
                nameof(ConsultarMedicosExistentesPorNombre), new ConsultaPorNombresDTO()
                {
                    PrimerNombre = primerNombre,
                    PrimerApellido = primerApellido
                });

            if (medicos.Count > 0 && medicos.All(m => RegistroLocalNoEsObsoleto(m, context.CurrentUtcDateTime)))
                return medicos;

            medicos = await context.CallSubOrchestratorAsync<List<Medico>>(
                            nameof(_rethusService.ConsultarMedicoPorNombresAsync), 
                            (primerNombre, primerApellido)
                            );
            // var medicos = await _rethusService.ConsultarMedicoPorNombresAsync(primerNombre, primerApellido);
            // medicos.ForEach(async m => await context.CallActivityAsync(
            //     nameof(AgregarMedico),
            //     m));
            return medicos;
        }

        [FunctionName(nameof(GetMedicosPorCargueIdAsync))]
        public async Task<List<Medico>> GetMedicosPorCargueIdAsync([OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var (CargueId, id) = context.GetInput<(string, string)>();
            //_logger.LogInformation($"ℹ Procesando pagina {paginaActual} . Petición: {peticionId}");

            var MedicosCargue = await context.CallActivityAsync<List<Medico>>(
                nameof(GetMedicosPorCargueIdActivityAsync),
                CargueId
            );
            return MedicosCargue;
        }
        [FunctionName(nameof(GetExcelMedicos))]
        public byte[] GetExcelMedicos([OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var (medicos, id) = context.GetInput<(string, string)>();
            var model = JsonConvert.DeserializeObject<List<Medico>>(medicos);
            var workbook = new XLWorkbook();
            workbook.AddWorksheet("Medicos");
            var ws = workbook.Worksheet("Medicos");
            ws.Column(1).Width = 25;
            ws.Column(2).Width = 25;
            ws.Column(3).Width = 30;
            ws.Column(4).Width = 30;
            ws.Column(5).Width = 20;
            int row = 1;
            ws.Cell("A" + row.ToString()).Style.Font.Bold = true;
            ws.Cell("B" + row.ToString()).Style.Font.Bold = true;
            ws.Cell("C" + row.ToString()).Style.Font.Bold = true;
            ws.Cell("D" + row.ToString()).Style.Font.Bold = true;
            ws.Cell("E" + row.ToString()).Style.Font.Bold = true;

            ws.Cell("A" + row.ToString()).Value = "Tipo de identificación";
            ws.Cell("B" + row.ToString()).Value = "Número de identificación";
            ws.Cell("C" + row.ToString()).Value = "Nombre";
            ws.Cell("D" + row.ToString()).Value = "Apellido";
            ws.Cell("E" + row.ToString()).Value = "Profesión Ocupación";
             row ++;
            foreach (Medico item in model)
            {
                ws.Cell("A" + row.ToString()).Value = item.TipoIdentificacion.ToString().Replace("_"," ");
                ws.Cell("B" + row.ToString()).Value = item.NumeroIdentificacion;
                ws.Cell("C" + row.ToString()).Value = item.PrimerNombre + " " + item.SegundoNombre; 
                ws.Cell("D" + row.ToString()).Value = item.PrimerApellido + " " + item.SegundoApellido;
                ws.Cell("E" + row.ToString()).Value = item.Detalles == null ? "" : item.Detalles[0]?.Ocupacion;
                row++;
            }
            using (MemoryStream stream = new MemoryStream())
            {
                workbook.SaveAs(stream, new SaveOptions { EvaluateFormulasBeforeSaving = false, GenerateCalculationChain = false, ValidatePackage = false });
                return stream.ToArray();
            }

            /*using(StreamWriter sw = File.CreateText("list.csv"))
            {
                for(int i = 0; i < model.Count; i++)
                {
                    sw.WriteLine(model[i]);
                }
                return sw;
            }*/
        }


        [FunctionName(nameof(ConsultarMedicosExistentesPorNombre))]
        public async Task<List<Medico>> ConsultarMedicosExistentesPorNombre([ActivityTrigger] IDurableActivityContext context)
        {
            var sp = _serviceScope.CreateScope().ServiceProvider;
            var _medicoRepo = sp.GetRequiredService<ICosmosDbAsyncRepository<Medico, MedicosContext>>();

            var consulta = context.GetInput<ConsultaPorNombresDTO>();

            var spec = new MedicosExistenteSinErrorSpec(consulta.PrimerNombre, consulta.PrimerApellido);

            var medicos = await _medicoRepo.ListAsync(spec);
            return medicos.OrderByDescending(m => m.UltimaActualizacion).ToList();
        }

        [FunctionName(nameof(GetMedicosPorCargueIdActivityAsync))]
        public async Task<List<Medico>> GetMedicosPorCargueIdActivityAsync([ActivityTrigger] string CargueId, IBinder binder)
        {
             var sp = _serviceScope.CreateScope().ServiceProvider;
            var _medicoRepo = sp.GetRequiredService<ICosmosDbAsyncRepository<Medico, MedicosContext>>();

            var spec = new MedicosExistenteSinErrorSpec(CargueId);

            var medicos = await _medicoRepo.ListAsync(spec);
            return medicos.OrderByDescending(m => m.UltimaActualizacion).ToList();
        }
        
        #region Helpers
        private static List<Medico> FiltrarMedicosFaltantes(List<Registro> medicosInputModel, Guid peticionId, IReadOnlyList<Medico> existentes)
        {
            var listaCargue = medicosInputModel.ToList().Select(i => new Medico(peticionId)
                {
                    TipoIdentificacion = i.TipoIdentificacion,
                    NumeroIdentificacion = i.NumeroIdentificacion,
                    PeticionId = peticionId
                }).ToList();

            var faltantes = listaCargue.Where(m => !existentes.Select(d=>d.NumeroIdentificacion).Contains(m.NumeroIdentificacion)).ToList();

            return faltantes;

            /*return medicosInputModel.ToList()
                .Select(i => new Medico(peticionId)
                {
                    TipoIdentificacion = i.TipoIdentificacion,
                    NumeroIdentificacion = i.NumeroIdentificacion,
                    PeticionId = peticionId
                })
                .Where(m =>
                !existentes.Contains(m))
                .ToList();*/
        }

        private List<Medico> FiltrarMedicosVigentes(Guid peticionId, IReadOnlyList<Medico> existentes, DateTime now)
        {
            var vigentes = existentes.ToList()
                .Where(m => RegistroLocalNoEsObsoleto(m, now))
                .AsEnumerable().ToList();
            vigentes.ForEach(m => m.PeticionId = peticionId);
            return vigentes;
        }

        private List<Medico> FiltrarMedicosExistentes(Guid peticionId, IReadOnlyList<Medico> existentes, DateTime now)
        {
            var obsoletos = existentes.ToList()
                .Where(m => !RegistroLocalNoEsObsoleto(m, now))
                .AsEnumerable().ToList();
            obsoletos.ForEach(m => m.PeticionId = peticionId);
            return obsoletos;
        }

        private List<Medico> FiltrarMedicosPorCargueMasivo(IReadOnlyList<Medico> existentes, string CargueMasivoId)
        {
            var CargueMasivo = existentes.ToList()
                .Where(m => m.id.Split('|')[1] == CargueMasivoId)
                .AsEnumerable().ToList();
            return CargueMasivo;
        }
        private bool RegistroLocalNoEsObsoleto(Medico medicoLocal, DateTime now)
        {
            return !(medicoLocal is null) && medicoLocal.UltimaActualizacion >= now.AddDays(-diasObsolencia);
        }

        private async Task<Medico> RegistrarMedicoConErrorAsync(string numeroDocumento, Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion tipoIdentificacion, Medico medicoLocal, string excepcion, Guid peticionId, ICosmosDbAsyncRepository<Medico, MedicosContext> _medicoRepo)
        {
            var sp = _serviceScope.CreateScope().ServiceProvider;
            _medicoRepo = sp.GetRequiredService<ICosmosDbAsyncRepository<Medico, MedicosContext>>();
            if (medicoLocal is null)
            {
                medicoLocal = new Medico(peticionId)
                {
                    NumeroIdentifiacion = numeroDocumento,
                    TipoIdentificacion = tipoIdentificacion,
                    ErrorEnConsulta = excepcion
                };
                //medicoLocal.Peticion = new Peticion(peticionId);
                return await _medicoRepo.AddAsync(medicoLocal);
            }

            medicoLocal.PeticionId = peticionId;
            medicoLocal.NumeroIdentifiacion = numeroDocumento;
            medicoLocal.TipoIdentificacion = tipoIdentificacion;
            medicoLocal.UltimaActualizacion = DateTime.Now;
            medicoLocal.ErrorEnConsulta = excepcion;

            //await _peticionRepo.DeleteAsync(medicoLocal.Peticion);

            //medicoLocal.PeticionId = medicoLocal.Peticion.Id;
            //await _peticionRepo.AddAsync(medicoLocal.Peticion);
            //medicoLocal.PeticionId = medicoLocal.Peticion.Id;

            await _medicoRepo.UpdateAsync(medicoLocal);
            return medicoLocal;
        }

        private async Task<Medico> CrearOActualizarAsync(Medico medicoLocal, Medico medicoRethus, Guid peticionId, ICosmosDbAsyncRepository<Medico, MedicosContext> _medicoRepo)
        {
            //var sp = _serviceScope.CreateScope().ServiceProvider;
            //var _medicoRepo = sp.GetRequiredService<IAsyncRepository<Medico>>();
            // Crear
            if (medicoLocal is null)
            {
                medicoLocal = new Medico(peticionId);
                medicoLocal = _mapper.Map(medicoRethus, medicoLocal);
                medicoLocal.ErrorEnConsulta = null;
                return await _medicoRepo.AddAsync(medicoLocal);
            }

            // Actualizar
            medicoLocal.PeticionId = peticionId;
            medicoLocal = _mapper.Map(medicoRethus, medicoLocal);
            medicoLocal.ErrorEnConsulta = null;

            await _medicoRepo.UpdateAsync(medicoLocal);

            return medicoLocal;
        }

        private string GetPorcentaje(int indice, int total) => ((float)indice / total * 100).ToString("0.00") + '%';
        #endregion
    }
}
