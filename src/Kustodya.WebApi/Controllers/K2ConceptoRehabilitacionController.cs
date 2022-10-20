using Kustodya.WebApi.Models.K2Conceptos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Threading.Tasks;
using Kustodya.WebApi.Services;
using Microsoft.AspNetCore.Authorization;

namespace Kustodya.WebApi.Controllers
{
    public class K2ConceptoRehabilitacionController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;

        public K2ConceptoRehabilitacionController(
            IConfiguration configuration,
            IMailService mailService
            )
        {
            _configuration = configuration;
            _mailService = mailService;
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

        //Consultar selectores
        [HttpGet]
        //[AllowAnonymous]
        public object ConsultarSelectores()
        {
            string SProcedure = @"Conceptos.SPSelectores";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@iIDSubtabla", 103);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString1 = JsonConvert.SerializeObject(table);

            table = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@iIDSubtabla", 104);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString2 = JsonConvert.SerializeObject(table);

            table = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@iIDSubtabla", 105);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString3 = JsonConvert.SerializeObject(table);

            table = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@iIDSubtabla", 106);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString4 = JsonConvert.SerializeObject(table);

            table = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@iIDSubtabla", 102);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString5 = JsonConvert.SerializeObject(table);

            SProcedure = @"administracion.SPAFP";
            table = new DataTable();
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
            var JSONString6 = JsonConvert.SerializeObject(table);

            var dataObjects = "{ TiposEtiologia: " + JSONString1 + ", TiposSecuela: " + JSONString2 + ", TiposPronostico: " + JSONString3 + ", TiposFinalidadTratamiento: " + JSONString4 + ", CausalNoAplica: " + JSONString5 + ", AFP: " + JSONString6 + "}";
            return TryFormatJson(dataObjects);
        }

        //Crear tarea Concepto de rehabilitacion
        [HttpPost]
        //[AllowAnonymous]
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
                    myCommand.Parameters.AddWithValue("@iIdAFP", t.iIdAFP);
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
        public JsonResult ReasignarTarea(ReasignarTarea t)
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

        //No Aplica Tarea
        [HttpPut]
        //[AllowAnonymous]
        public JsonResult NoAplicaTarea(NoAplicaTarea t)
        {
            string SProcedure = @"Conceptos.SPNoAplicaTarea";
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
                    myCommand.Parameters.AddWithValue("@tCausalNoAplica", t.tCausalNoAplica);
                    myCommand.Parameters.AddWithValue("@iIDCausalNoAplica", t.iIDCausalNoAplica);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Asignacion de tarea no aplica con exito");
        }

        //Consultar concepto
        [HttpGet]
        //[AllowAnonymous]
        public object ConsultarConcepto(int IdTarea)
        {
            string SProcedure = @"Conceptos.SPConsultaConcepto";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@IdTarea", IdTarea);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString1 = JsonConvert.SerializeObject(table);

            SProcedure = @"Conceptos.SPConsultaDiagnosticos";
            table = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@IdTarea", IdTarea);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString2 = JsonConvert.SerializeObject(table);

            SProcedure = @"Conceptos.SPConsultaSecuelas";
            table = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@IdTarea", IdTarea);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString3 = JsonConvert.SerializeObject(table);

            SProcedure = @"Conceptos.SPConsultaEmpresa";
            table = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@IdTarea", IdTarea);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString4 = JsonConvert.SerializeObject(table);

            var dataObjects = "{ Concepto: " + JSONString1 + ", DiagnosticosConcepto: " + JSONString2 + ", SecuelasConcepto: " + JSONString3 + ", EmpleadoresConcepto: " + JSONString4 +"}";
            return TryFormatJson(dataObjects);
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
                    myCommand.Parameters.AddWithValue("@FechaIncapacidad", (c.FechaIncapacidad != null) ? c.FechaIncapacidad : 1900-01-01);
                    myCommand.Parameters.AddWithValue("@Etiologia", (c.Etiologia != null) ? c.Etiologia : 0);
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
                    myCommand.Parameters.AddWithValue("@FechaIncapacidad", (c.FechaIncapacidad != null) ? c.FechaIncapacidad : 1900-01-01);
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
        [HttpDelete("{Id:int}")]
        //[AllowAnonymous]
        public JsonResult EliminarDiagnosticoConcepto(int Id)
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
                    myCommand.Parameters.AddWithValue("@Id", Id);
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
        [HttpDelete("{Id:int}")]
        //[AllowAnonymous]
        public JsonResult EliminarSecuelaConcepto(int Id)
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
                    myCommand.Parameters.AddWithValue("@Id", Id);
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
                    myCommand.Parameters.AddWithValue("@Progreso", c.Progreso);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Concepto emitido exitosamente");
        }

        //Editar Carta Concepto de rehabilitacion
        [HttpPut]
        //[AllowAnonymous]
        public JsonResult EditarCarta(Carta c)
        {
            string SProcedure = @"Conceptos.SPGestionarCarta";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@IdConcepto", c.IdConcepto);
                    myCommand.Parameters.AddWithValue("@tAsunto", c.tAsunto);
                    myCommand.Parameters.AddWithValue("@tDireccionPaciente", c.tDireccionPaciente);
                    myCommand.Parameters.AddWithValue("@iCodigoPostal", c.iCodigoPostal);
                    myCommand.Parameters.AddWithValue("@tTelefonoPaciente", c.tTelefonoPaciente);
                    myCommand.Parameters.AddWithValue("@iIDCiudad", c.iIDCiudad);
                    myCommand.Parameters.AddWithValue("@tEmailPaciente", c.tEmailPaciente);
                    myCommand.Parameters.AddWithValue("@bNotificacionbyEmailAFP", c.bNotificacionbyEmailAFP);
                    myCommand.Parameters.AddWithValue("@bNotificacionbyPmailAFP", c.bNotificacionbyPmailAFP);
                    myCommand.Parameters.AddWithValue("@bNotificacionbyEmailPaciente", c.bNotificacionbyEmailPaciente);
                    myCommand.Parameters.AddWithValue("@bNotificacionbyPmailPaciente", c.bNotificacionbyPmailPaciente);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Edicion de la carta del concepto exitoso");
        }

        //Editar informacion empleador en el Concepto de rehabilitacion
        [HttpPut]
        //[AllowAnonymous]
        public JsonResult EditarEmpleadorConcepto(EditarEmpleador c)
        {
            string SProcedure = @"Conceptos.SPGestionarEmpleador";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@tDireccion", c.tDireccion);
                    myCommand.Parameters.AddWithValue("@iCodigoPostal", c.iCodigoPostal);
                    myCommand.Parameters.AddWithValue("@tTelefono", c.tTelefono);
                    myCommand.Parameters.AddWithValue("@iIDCiudad", c.iIDCiudad);
                    myCommand.Parameters.AddWithValue("@tEmail", c.tEmail);
                    myCommand.Parameters.AddWithValue("@iIDEmpresaPaciente", c.iIDEmpresaPaciente);
                    myCommand.Parameters.AddWithValue("@bNotificacionbyEmail", c.bNotificacionbyEmail);
                    myCommand.Parameters.AddWithValue("@bNotificacionbyPmail", c.bNotificacionbyPmail);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Empleador editado exitosamente");
        }

        //Enviar Concepto de rehabilitacion
        [HttpGet]
        [AllowAnonymous]
        public async Task EnviarConcepto(int IdConcepto)
        {
            string SProcedure = @"Conceptos.SPEnviar";
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
                    myCommand.Parameters.AddWithValue("@IdConcepto", IdConcepto);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            int CantidadEmail = table.Rows.Count;
            for (int i = 0; i < CantidadEmail; i++)
            {
                MailRequest mr = new MailRequest();
                // mr.email = table.Rows[i][0].ToString();
                mr.email = "meddylex.development@gmail.com";
                mr.nombrePaciente = table.Rows[i][1].ToString();
                mr.codigo = table.Rows[i][2].ToString();
                mr.tipoDocumento = table.Rows[i][3].ToString();
                mr.numeroDocumento = table.Rows[i][4].ToString();
                mr.nombreAFP = table.Rows[i][5].ToString();
                mr.nombreEPS = table.Rows[i][6].ToString();
                mr.pronostico = table.Rows[i][7].ToString();
                mr.conIncapacidades = table.Rows[i][8].ToString();
                try
                {
                    await _mailService.SendEmailConcepto(mr);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //Convierte en JSON
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
    }
}
