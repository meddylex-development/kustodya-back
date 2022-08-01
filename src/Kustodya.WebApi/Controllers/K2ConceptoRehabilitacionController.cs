﻿using AutoMapper;
using Kustodya.ApplicationCore.Entities.Concepto;
using Kustodya.ApplicationCore.Interfaces.Incapacidades;
using Kustodya.ApplicationCore.Interfaces.Rehabilitacion;
using Kustodya.WebApi.Controllers.Incapacidades.Modelos;
using Kustodya.WebApi.Models.K2Conceptos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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

        public K2ConceptoRehabilitacionController(
            IConceptoRehabilitacionService conceptoRehabilitacionService,
            IConfiguration configuration,
            ICie10Service cie10Service
            )
        {
            _conceptoRehabilitacionService = conceptoRehabilitacionService;
            _cie10Service = cie10Service;
            _configuration = configuration;
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

        //Consultar selectores
        [HttpGet]
        //[AllowAnonymous]
        public object ConsultarSelectores(int iIDSubtabla)
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

            SProcedure = @"Conceptos.SPSelectores";
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

            SProcedure = @"Conceptos.SPSelectores";
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
            SProcedure = @"Conceptos.SPSelectores";
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

            var dataObjects = "{ TiposEtiologia: " + JSONString1 + ", TiposSecuela: " + JSONString2 + ", TiposPronostico: " + JSONString3 + ", TiposFinalidadTratamiento: " + JSONString4 + "}";
            return TryFormatJson(dataObjects);
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
                    myCommand.Parameters.AddWithValue("@RemisionAdministradoraFondoPension", (c.RemisionAdministradoraFondoPension != null) ? c.RemisionAdministradoraFondoPension : "");
                    myCommand.Parameters.AddWithValue("@Progreso", c.Progreso);
                    myCommand.Parameters.AddWithValue("@IdAfp", c.IdAfp);
                    myCommand.Parameters.AddWithValue("@tAsunto ", c.tAsunto);
                    myCommand.Parameters.AddWithValue("@tDireccionPaciente", c.tDireccionPaciente);
                    myCommand.Parameters.AddWithValue("@tTelefonoPaciente", c.tTelefonoPaciente);
                    myCommand.Parameters.AddWithValue("@iIDCiudad", c.iIDCiudad);
                    myCommand.Parameters.AddWithValue("@tEmailPaciente ", c.tEmailPaciente);
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
                    myCommand.Parameters.AddWithValue("@tTelefono", c.tTelefono);
                    myCommand.Parameters.AddWithValue("@iIDCiudad", c.iIDCiudad);
                    myCommand.Parameters.AddWithValue("@tEmail", c.tEmail);
                    myCommand.Parameters.AddWithValue("@iIDEmpresaPaciente", c.iIDEmpresaPaciente);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Empleador editado exitosamente");
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
                    myCommand.Parameters.AddWithValue("@IdAfp", c.IdAfp);
                    myCommand.Parameters.AddWithValue("@tAsunto ", c.tAsunto);
                    myCommand.Parameters.AddWithValue("@tDireccionPaciente", c.tDireccionPaciente);
                    myCommand.Parameters.AddWithValue("@tTelefonoPaciente", c.tTelefonoPaciente);
                    myCommand.Parameters.AddWithValue("@iIDCiudad", c.iIDCiudad);
                    myCommand.Parameters.AddWithValue("@tEmailPaciente ", c.tEmailPaciente);

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
