using AutoMapper;
using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.Entities.Concepto;
using Kustodya.ApplicationCore.Interfaces.Incapacidades;
using Kustodya.WebApi.Controllers.Incapacidades.Modelos;
using Kustodya.WebApi.Models.K2Conceptos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers
{
    //[ApiController]
    public class K2ConceptoRehabilitacionController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper2;
        private readonly MapperConfiguration _config = new MapperConfiguration(cfg => {
            cfg.AddProfile<MappingProfiles>();
            cfg.CreateMap<PacientesPorEmitir, PacienteOutputModel>();
        });

        public K2ConceptoRehabilitacionController(IConfiguration configuration, IPacienteService pacienteService, IMapper mapper)
        {
            _configuration = configuration;
            _pacienteService = pacienteService;
            _mapper2 = _config.CreateMapper();
        }

        //Select PacientesPorEmitir
        [HttpGet]
        //[AllowAnonymous]
        public async Task<IActionResult> PendientesConceptoRehabilitacion([FromQuery] PacientesPorEmitir.EstadoConcepto? estado, [FromQuery] string busqueda = "", [FromQuery] int pagina = 1)
        {
            int cantidad = 10;
            var listaPacientes = await _pacienteService.PacientesPorEmitir(estado, busqueda, (pagina - 1) * cantidad, cantidad);
            var total = await _pacienteService.PacientesPorEmitir(estado, busqueda, null, null);
            var listaSalida = _mapper2.Map<List<PacienteOutputModel>>(listaPacientes);

            PacientesOutputModel pacientesOutputModel = new PacientesOutputModel()
            {
                listaPacientes = listaSalida,
                paginacion = new PaginacionModel(total.Count(), pagina, cantidad)
            };
            return Ok(pacientesOutputModel);
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
                    myCommand.Parameters.AddWithValue("@CausalAnulacion ", t.CausalAnulacion);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Anulacion de tarea exitosa");
        }

        //Emitir Concepto de rehabilitacion
        [HttpPut]
        //[AllowAnonymous]
        public JsonResult EmitirConcepto(Emitir c)
        {
            string SProcedure = @"Conceptos.SPEmitir";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@SP", c.SP);
                    myCommand.Parameters.AddWithValue("@Id", c.Id);
                    myCommand.Parameters.AddWithValue("@ResumenHistoriaClinica", c.ResumenHistoriaClinica);
                    myCommand.Parameters.AddWithValue("@FinalidadTratamientos", c.FinalidadTratamientos);
                    myCommand.Parameters.AddWithValue("@EsFarmacologico", c.EsFarmacologico);
                    myCommand.Parameters.AddWithValue("@EsTerapiaOcupacional", c.EsTerapiaOcupacional);
                    myCommand.Parameters.AddWithValue("@EsFonoaudiologia", c.EsFonoaudiologia);
                    myCommand.Parameters.AddWithValue("@EsQuirurgico", c.EsQuirurgico);
                    myCommand.Parameters.AddWithValue("@EsTerapiaFisica", c.EsTerapiaFisica);
                    myCommand.Parameters.AddWithValue("@EsOtrosTratamientos", c.EsOtrosTratamientos);
                    myCommand.Parameters.AddWithValue("@DescripcionOtrosTratamientos", c.DescripcionOtrosTratamientos);
                    myCommand.Parameters.AddWithValue("@PlazoCorto", c.PlazoCorto);
                    myCommand.Parameters.AddWithValue("@PlazoMediano", c.PlazoMediano);
                    myCommand.Parameters.AddWithValue("@Concepto", c.Concepto);
                    myCommand.Parameters.AddWithValue("@RemisionAdministradoraFondoPension", c.RemisionAdministradoraFondoPension);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Concepto gestionado exitosamente");
        }
        
        //Asignar diagnostico al Concepto de rehabilitacion
        [HttpPost]
        //[AllowAnonymous]
        public JsonResult AsignarDiagnosticoConcepto(AsignarDiagnostico c)
        {
            string SProcedure = @"Conceptos.SPAsignarDiagnostico";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@SP", c.SP);
                    myCommand.Parameters.AddWithValue("@ConceptoRehabilitacionId", c.ConceptoRehabilitacionId);
                    myCommand.Parameters.AddWithValue("@Cie10Id", c.Cie10Id);
                    myCommand.Parameters.AddWithValue("@FechaIncapacidad", c.FechaIncapacidad);
                    myCommand.Parameters.AddWithValue("@Etiologia", c.Etiologia);
                    myCommand.Parameters.AddWithValue("@Id", c.Id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Diagnostico gestionado exitosamente");
        }

        //Asignar secuela al Concepto de rehabilitacion
        [HttpPost]
        //[AllowAnonymous]
        public JsonResult AsignarSecuelaConcepto(AsignarSecuela c)
        {
            string SProcedure = @"Conceptos.SPAsignarSecuela";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@SP", c.SP);
                    myCommand.Parameters.AddWithValue("@ConceptoRehabilitacionId", c.ConceptoRehabilitacionId);
                    myCommand.Parameters.AddWithValue("@Tipo", c.Tipo);
                    myCommand.Parameters.AddWithValue("@Descripcion", c.Descripcion);
                    myCommand.Parameters.AddWithValue("@Pronostico", c.Pronostico);
                    myCommand.Parameters.AddWithValue("@Id", c.Id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Secuela gestionada exitosamente");
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
