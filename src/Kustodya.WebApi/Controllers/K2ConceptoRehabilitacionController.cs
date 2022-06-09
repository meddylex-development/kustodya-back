using AutoMapper;
using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.Entities.Concepto;
using Kustodya.ApplicationCore.Interfaces.Incapacidades;
using Kustodya.ApplicationCore.Interfaces.Rehabilitacion;
using Kustodya.Infrastructure;
using Kustodya.WebApi.Controllers.Incapacidades.Modelos;
using Kustodya.WebApi.Models.K2Conceptos;
using Kustodya.WebApi.Models.K2Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers
{
    public class K2ConceptoRehabilitacionController : BaseController
    {
        private readonly IConceptoRehabilitacionService _conceptoRehabilitacionService;
        private readonly ICie10Service _cie10Service;
        private readonly IConfiguration _configuration;
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper2;
        private readonly MapperConfiguration _config = new MapperConfiguration(cfg => {
            cfg.AddProfile<MappingProfiles>();
            cfg.CreateMap<PacientesPorEmitir, PacienteOutputModel>();
        });

        public K2ConceptoRehabilitacionController(
            IConceptoRehabilitacionService conceptoRehabilitacionService,
            IConfiguration configuration,
            IPacienteService pacienteService,
            IMapper mapper,
            ICie10Service cie10Service
            )
        {
            _conceptoRehabilitacionService = conceptoRehabilitacionService;
            _cie10Service = cie10Service;
            _configuration = configuration;
            _pacienteService = pacienteService;
            _mapper2 = _config.CreateMapper();
        }

        //Consultar tareas
        [HttpGet]
        //[AllowAnonymous]
        public async Task<IActionResult> PendientesConceptoRehabilitacion([FromQuery] PacientesPorEmitir.EstadoConcepto? estado, [FromQuery] int usuario, [FromQuery] int tipo, [FromQuery] string busqueda = "", [FromQuery] int pagina = 1)
        {
            int cantidad = 10;
            int user = 0;
            if (tipo == 2)
            {
                user = usuario;
            }
            var listaPacientes = await _pacienteService.PacientesPorEmitir(estado, user, busqueda, (pagina - 1) * cantidad, cantidad);
            var total = await _pacienteService.PacientesPorEmitir(estado, user, busqueda, null, null);
            var listaSalida = _mapper2.Map<List<PacienteOutputModel>>(listaPacientes);

            PacientesOutputModel pacientesOutputModel = new PacientesOutputModel()
            {
                listaPacientes = listaSalida,
                paginacion = new PaginacionModel(total.Count(), pagina, cantidad)
            };
            return Ok(pacientesOutputModel);
        }

        //Consultar tareas
        [HttpGet]
        //[AllowAnonymous]
        public object ConsultarTareas(int usuario, int estado, int itemsPorPagina, int paginaActual, string busqueda)
        {
            string SProcedure = @"Conceptos.SPtareas";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@usuario", usuario);
                    myCommand.Parameters.AddWithValue("@estado", estado);
                    myCommand.Parameters.AddWithValue("@itemsPorPagina", itemsPorPagina);
                    myCommand.Parameters.AddWithValue("@paginaActual", paginaActual);
                    myCommand.Parameters.AddWithValue("@busqueda", (busqueda != null) ? busqueda : "");
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString1 = JsonConvert.SerializeObject(table);

            SProcedure = @"Conceptos.SPtareasPaginacion";
            table = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@usuario", usuario);
                    myCommand.Parameters.AddWithValue("@estado", estado);
                    myCommand.Parameters.AddWithValue("@itemsPorPagina", itemsPorPagina);
                    myCommand.Parameters.AddWithValue("@paginaActual", paginaActual);
                    myCommand.Parameters.AddWithValue("@busqueda", (busqueda != null) ? busqueda : "");
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString2 = JsonConvert.SerializeObject(table);

            SProcedure = @"Conceptos.SPtareasRegistros";
            table = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@usuario", usuario);
                    myCommand.Parameters.AddWithValue("@estado", estado);
                    myCommand.Parameters.AddWithValue("@itemsPorPagina", itemsPorPagina);
                    myCommand.Parameters.AddWithValue("@paginaActual", paginaActual);
                    myCommand.Parameters.AddWithValue("@busqueda", (busqueda != null) ? busqueda : "");
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString3 = JsonConvert.SerializeObject(table);
            var dataObjects = "{ listadoPacientes: " + JSONString1 + ", paginacion: " + JSONString2 + ", registrosEstados: " + JSONString3 + "}";
            // return dataObjects;
            // return "listadoPacientes" + JSONString1 + "paginacion" + JSONString2 + "registrosEstados" + JSONString3;
            return TryFormatJson(dataObjects);
        }

        //Consultar tareas medicos
        [HttpGet]
        //[AllowAnonymous]
        public object ConsultarTareasMedicos()
        {
            string SProcedure = @"Conceptos.SPTareasMedicos";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString = JsonConvert.SerializeObject(table);
            //return "TareasMedicos" + JSONString;
            var dataObjects = "{ TareasMedicos: " + JSONString + "}";
            return TryFormatJson(dataObjects);
        }

        private static string TryFormatJson(string str)
        {
            try
            {
                object parsedJson = JsonConvert.DeserializeObject(str);
                return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            }
            catch
            {
                // can't parse JSON, return the original string
                return str;
            }
        }

        //Crear tarea Concepto de rehabilitacion
        [HttpPost]
        [AllowAnonymous]
        public JsonResult CrearTarea(CrearTarea t)
        {
            string SProcedure = @"Conceptos.SPCrearTarea";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@PacienteId", t.PacienteId);
                    myCommand.Parameters.AddWithValue("@Prioridad", t.Prioridad);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Creacion de tarea exitosa");
        }

        //Asignar tarea Concepto de rehabilitacion
        [HttpPut]
        //[AllowAnonymous]
        public JsonResult AsignarTarea(AsignarTarea t)
        {
            string SProcedure = @"Conceptos.SPAsignarTarea";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@Id", t.Id);
                    myCommand.Parameters.AddWithValue("@UsuarioAsignadoId ", t.UsuarioAsignadoId);
                    myCommand.Parameters.AddWithValue("@Prioridad", t.Prioridad);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Asignacion de tarea exitosa");
        }

        //Reasignar tarea Concepto de rehabilitacion
        [HttpPut]
        //[AllowAnonymous]
        public JsonResult ReasignarTarea(AsignarTarea t)
        {
            string SProcedure = @"Conceptos.SPReasignarTarea";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@Id", t.Id);
                    myCommand.Parameters.AddWithValue("@UsuarioAsignadoId ", t.UsuarioAsignadoId);
                    myCommand.Parameters.AddWithValue("@Prioridad", t.Prioridad);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Reasignacion de tarea exitosa");
        }

        //Anular tarea Concepto de rehabilitacion
        [HttpPut]
        //[AllowAnonymous]
        public JsonResult AnularTarea(AnularTarea t)
        {
            string SProcedure = @"Conceptos.SPAnularTarea";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@Id", t.Id);
                    myCommand.Parameters.AddWithValue("@CausalAnulacion", t.CausalAnulacion);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Anulacion de tarea exitosa");
        }

        //Consultar Concepto
        [HttpGet("{pacienteporEmitirId:int}")]
        //[AllowAnonymous]
        public async Task<IActionResult> ConceptoRehabilitacion(int pacienteporEmitirId)
        {
            var conceptoRehabilitacion = await _conceptoRehabilitacionService.DatosConcepto(pacienteporEmitirId);
            if (conceptoRehabilitacion == null)
                return NotFound();
            var pacientePorEmitir = await _conceptoRehabilitacionService.PacientePorEmitir(pacienteporEmitirId);
            var diasAcumulados = await _conceptoRehabilitacionService.DiasAcumulados(pacientePorEmitir.PacienteId);
            var conceptosEmitidos = await _conceptoRehabilitacionService.ConceptosEmitidos(pacientePorEmitir.PacienteId, "", null, null);
            var diagnosticos = await _cie10Service.GetCie10();
            ConceptoRehabilitacionOutputModel crom = new ConceptoRehabilitacionOutputModel
            {
                ConceptoRehabilitacionId = conceptoRehabilitacion.Id,// se muestra el Id del concepto de rehabilitacion
                diasAcumulados = diasAcumulados == null ? 0 : (int)diasAcumulados,
                conceptosEmitidos = conceptosEmitidos.Count(),
                PCLCalificados = 0, //Calculado: pendiente por crear formulario
                apellidos = pacientePorEmitir.Paciente.TPrimerApellido + (pacientePorEmitir.Paciente.TSegundoApellido == null ? "" : " " + pacientePorEmitir.Paciente.TSegundoApellido),
                nombres = pacientePorEmitir.Paciente.TPrimerNombre + (pacientePorEmitir.Paciente.TSegundoNombre == null ? "" : " " + pacientePorEmitir.Paciente.TSegundoNombre),
                tipoDocumento = pacientePorEmitir.Paciente.IIdtipoDocNavigation.TDescripcion,
                numeroDocumento = pacientePorEmitir.Paciente.TNumeroDocumento,
                fechaNacimiento = pacientePorEmitir.Paciente.DtFechaNacimiento?.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,
                //fechaEmision = pacientePorEmitir.FechaEmision?.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds, cambio base de datos
                edad = pacientePorEmitir.Paciente.IEdad,
                ARL = pacientePorEmitir.Paciente.IIdarlNavigation.TNombre,
                AFP = pacientePorEmitir.Paciente.IIdafpNavigation.TNombre,
                EPS = pacientePorEmitir.Paciente.IIdepsNavigation.TNombre,
                codigoCorto = conceptoRehabilitacion.CodigoCorto,
                historiaClinica = conceptoRehabilitacion.ResumenHistoriaClinica,
                finalidadTratmamiento = Convert.ToInt32(conceptoRehabilitacion.FinalidadTratamientos),
                Farmacologico = conceptoRehabilitacion.EsFarmacologico,
                terapiaOcupacional = conceptoRehabilitacion.EsTerapiaOcupacional,
                fonoAudiologia = conceptoRehabilitacion.EsFonoaudiologia,
                quirurgico = conceptoRehabilitacion.EsQuirurgico,
                terapiaFisica = conceptoRehabilitacion.EsTerapiaFisica,
                otrosTramites = conceptoRehabilitacion.EsOtrosTratamientos,
                otrosTratamientos = conceptoRehabilitacion.DescripcionOtrosTratamientos,
                cortoPlazo = Convert.ToInt32(conceptoRehabilitacion.PlazoCorto),
                medianoPlazo = Convert.ToInt32(conceptoRehabilitacion.PlazoMediano),
                concepto = Convert.ToInt32(conceptoRehabilitacion.Concepto),
                RemisionAdministradoraFondoPension = conceptoRehabilitacion.RemisionAdministradoraFondoPension
            };

            List<DiagnosticosOutputModel> doms = new List<DiagnosticosOutputModel>();
            foreach (var item in conceptoRehabilitacion.Diagnosticos)
            {
                var diagnostico = diagnosticos.Where(c => c.IIdcie10 == item.Cie10Id).FirstOrDefault();
                DiagnosticosOutputModel dom = new DiagnosticosOutputModel
                {
                    id = item.Id,
                    CIE10Id = diagnostico.IIdcie10,
                    nombreDiagnostico = diagnostico?.TCie10 + "-" + diagnostico?.TDescripcion,
                    Etiologia = Convert.ToInt32(item.Etiologia),
                    nombreEtiologia = item.Etiologia.ToString(),
                    FechaIncapacidad = item.FechaIncapacidad.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds
                };
                doms.Add(dom);
            }
            crom.diagnosticos = doms;

            List<SecuelasOutputModel> soms = new List<SecuelasOutputModel>();
            foreach (var item in conceptoRehabilitacion.Secuelas)
            {
                SecuelasOutputModel som = new SecuelasOutputModel
                {
                    id = item.Id,
                    descripcion = item.Descripcion,
                    pronostico = Convert.ToInt32(item.Pronostico),
                    nombrePronostico = item.Pronostico.ToString(),
                    tipoSecuela = Convert.ToInt32(item.Tipo),
                    nombreTipoSecuela = item.Tipo.ToString()
                };
                soms.Add(som);
            }
            crom.secuelas = soms;
            return Ok(crom);
        }

        //Actualizar Concepto de rehabilitacion
        [HttpPut]
        //[AllowAnonymous]
        public JsonResult ActualizarConcepto(Actualizar c)
        {
            string SProcedure = @"Conceptos.SPGestionar";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@SP", 1);
                    myCommand.Parameters.AddWithValue("@Id", c.Id);
                    myCommand.Parameters.AddWithValue("@ResumenHistoriaClinica", (c.ResumenHistoriaClinica != null)? c.ResumenHistoriaClinica:"");
                    myCommand.Parameters.AddWithValue("@FinalidadTratamientos", c.FinalidadTratamientos);
                    myCommand.Parameters.AddWithValue("@EsFarmacologico", c.EsFarmacologico);
                    myCommand.Parameters.AddWithValue("@EsTerapiaOcupacional", c.EsTerapiaOcupacional);
                    myCommand.Parameters.AddWithValue("@EsFonoaudiologia", c.EsFonoaudiologia);
                    myCommand.Parameters.AddWithValue("@EsQuirurgico", c.EsQuirurgico);
                    myCommand.Parameters.AddWithValue("@EsTerapiaFisica", c.EsTerapiaFisica);
                    myCommand.Parameters.AddWithValue("@EsOtrosTratamientos", c.EsOtrosTratamientos);
                    myCommand.Parameters.AddWithValue("@DescripcionOtrosTratamientos", (c.DescripcionOtrosTratamientos != null) ? c.DescripcionOtrosTratamientos : "");
                    myCommand.Parameters.AddWithValue("@PlazoCorto", c.PlazoCorto);
                    myCommand.Parameters.AddWithValue("@PlazoMediano", c.PlazoMediano);
                    myCommand.Parameters.AddWithValue("@Concepto", c.Concepto);
                    myCommand.Parameters.AddWithValue("@RemisionAdministradoraFondoPension", (c.RemisionAdministradoraFondoPension != null) ? c.RemisionAdministradoraFondoPension : "");
                    myCommand.Parameters.AddWithValue("@Progreso", c.Progreso);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Concepto actualizado exitosamente");
        }

        //Agregar diagnostico al Concepto de rehabilitacion
        [HttpPost]
        //[AllowAnonymous]
        public JsonResult AgregarDiagnosticoConcepto(AgregarDiagnostico c)
        {
            string SProcedure = @"Conceptos.SPGestionarDiagnostico";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@SP", 1);
                    myCommand.Parameters.AddWithValue("@ConceptoRehabilitacionId", c.ConceptoRehabilitacionId);
                    myCommand.Parameters.AddWithValue("@Cie10Id", c.Cie10Id);
                    myCommand.Parameters.AddWithValue("@FechaIncapacidad", (c.FechaIncapacidad != null) ? c.FechaIncapacidad : "");
                    myCommand.Parameters.AddWithValue("@Etiologia", (c.Etiologia != null) ? c.Etiologia : "");
                    myCommand.Parameters.AddWithValue("@Id", 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Diagnostico agregado exitosamente");
        }

        //Editar diagnostico al Concepto de rehabilitacion
        [HttpPut]
        //[AllowAnonymous]
        public JsonResult EditarDiagnosticoConcepto(EditarDiagnostico c)
        {
            string SProcedure = @"Conceptos.SPGestionarDiagnostico";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@SP", 2);
                    myCommand.Parameters.AddWithValue("@ConceptoRehabilitacionId", 0);
                    myCommand.Parameters.AddWithValue("@Cie10Id", c.Cie10Id);
                    myCommand.Parameters.AddWithValue("@FechaIncapacidad", (c.FechaIncapacidad != null) ? c.FechaIncapacidad : "");
                    myCommand.Parameters.AddWithValue("@Etiologia", (c.Etiologia != null) ? c.Etiologia : "");
                    myCommand.Parameters.AddWithValue("@Id", c.Id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Diagnostico editado exitosamente");
        }

        //Eliminar diagnostico del Concepto de rehabilitacion
        [HttpDelete]
        //[AllowAnonymous]
        public JsonResult EliminarDiagnosticoConcepto(EliminarDiagnostico c)
        {
            string SProcedure = @"Conceptos.SPGestionarDiagnostico";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@SP", 3);
                    myCommand.Parameters.AddWithValue("@ConceptoRehabilitacionId", 0);
                    myCommand.Parameters.AddWithValue("@Cie10Id", 0);
                    myCommand.Parameters.AddWithValue("@FechaIncapacidad", 0);
                    myCommand.Parameters.AddWithValue("@Etiologia", 0);
                    myCommand.Parameters.AddWithValue("@Id", c.Id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Diagnostico eliminado exitosamente");
        }

        //Agregar secuela al Concepto de rehabilitacion
        [HttpPost]
        //[AllowAnonymous]
        public JsonResult AgregarSecuelaConcepto(AgregarSecuela c)
        {
            string SProcedure = @"Conceptos.SPGestionarSecuela";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@SP", 1);
                    myCommand.Parameters.AddWithValue("@ConceptoRehabilitacionId", c.ConceptoRehabilitacionId);
                    myCommand.Parameters.AddWithValue("@Tipo", c.Tipo);
                    myCommand.Parameters.AddWithValue("@Descripcion", (c.Descripcion != null) ? c.Descripcion : "");
                    myCommand.Parameters.AddWithValue("@Pronostico", c.Pronostico);
                    myCommand.Parameters.AddWithValue("@Id", 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Secuela agregada exitosamente");
        }

        //Editar secuela al Concepto de rehabilitacion
        [HttpPut]
        //[AllowAnonymous]
        public JsonResult EditarSecuelaConcepto(EditarSecuela c)
        {
            string SProcedure = @"Conceptos.SPGestionarSecuela";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@SP", 2);
                    myCommand.Parameters.AddWithValue("@ConceptoRehabilitacionId", 0);
                    myCommand.Parameters.AddWithValue("@Tipo", c.Tipo);
                    myCommand.Parameters.AddWithValue("@Descripcion", (c.Descripcion != null) ? c.Descripcion : "");
                    myCommand.Parameters.AddWithValue("@Pronostico", c.Pronostico);
                    myCommand.Parameters.AddWithValue("@Id", c.Id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Secuela editada exitosamente");
        }

        //Eliminar secuela al Concepto de rehabilitacion
        [HttpDelete]
        //[AllowAnonymous]
        public JsonResult EliminarSecuelaConcepto(EliminarSecuela c)
        {
            string SProcedure = @"Conceptos.SPGestionarSecuela";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@SP", 3);
                    myCommand.Parameters.AddWithValue("@ConceptoRehabilitacionId", 0);
                    myCommand.Parameters.AddWithValue("@Tipo", 0);
                    myCommand.Parameters.AddWithValue("@Descripcion", "");
                    myCommand.Parameters.AddWithValue("@Pronostico", 0);
                    myCommand.Parameters.AddWithValue("@Id", c.Id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Secuela eliminada exitosamente");
        }

        //Emitir Concepto de rehabilitacion
        [HttpPut]
        //[AllowAnonymous]
        public JsonResult EmitirConcepto(Emitir c)
        {
            string SProcedure = @"Conceptos.SPGestionar";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@SP", 2);
                    myCommand.Parameters.AddWithValue("@Id", c.Id);
                    myCommand.Parameters.AddWithValue("@ResumenHistoriaClinica", c.ResumenHistoriaClinica);
                    myCommand.Parameters.AddWithValue("@FinalidadTratamientos", c.FinalidadTratamientos);
                    myCommand.Parameters.AddWithValue("@EsFarmacologico", c.EsFarmacologico);
                    myCommand.Parameters.AddWithValue("@EsTerapiaOcupacional", c.EsTerapiaOcupacional);
                    myCommand.Parameters.AddWithValue("@EsFonoaudiologia", c.EsFonoaudiologia);
                    myCommand.Parameters.AddWithValue("@EsQuirurgico", c.EsQuirurgico);
                    myCommand.Parameters.AddWithValue("@EsTerapiaFisica", c.EsTerapiaFisica);
                    myCommand.Parameters.AddWithValue("@EsOtrosTratamientos", c.EsOtrosTratamientos);
                    myCommand.Parameters.AddWithValue("@DescripcionOtrosTratamientos", (c.DescripcionOtrosTratamientos != null) ? c.DescripcionOtrosTratamientos : "");
                    myCommand.Parameters.AddWithValue("@PlazoCorto", c.PlazoCorto);
                    myCommand.Parameters.AddWithValue("@PlazoMediano", c.PlazoMediano);
                    myCommand.Parameters.AddWithValue("@Concepto", c.Concepto);
                    myCommand.Parameters.AddWithValue("@RemisionAdministradoraFondoPension", c.RemisionAdministradoraFondoPension);
                    myCommand.Parameters.AddWithValue("@Progreso", c.Progreso);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Concepto emitido exitosamente");
        }

        //Notificar Concepto de rehabilitacion
        [HttpPut]
        //[AllowAnonymous]
        public JsonResult NotificarConcepto(Notificar c)
        {
            string SProcedure = @"Conceptos.SPNotificar";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@Id", c.Id);
                    myCommand.Parameters.AddWithValue("@MedioNotificacion", c.MedioNotificacion);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Notificacion de concepto exitoso");
        }
    }
}
