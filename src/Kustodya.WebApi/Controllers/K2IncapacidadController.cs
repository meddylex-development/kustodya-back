using Kustodya.WebApi.Models.K2Incapacidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace Kustodya.WebApi.Controllers
{
    public class K2IncapacidadController : BaseController
    {
        private readonly IConfiguration _configuration;
        public K2IncapacidadController(
        IConfiguration configuration
        )
        {
            _configuration = configuration;
        }

        //Crear Incapacidad
        [HttpPost]
        //[AllowAnonymous]
        public object CrearIncapacidad(CrearIncapacidad i)
        {
            string SProcedure = @"Incapacidades.SPCrearIncapacidad";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@iIDIPS", i.iIDIPS);
                    myCommand.Parameters.AddWithValue("@iIDPaciente", i.iIDPaciente);
                    myCommand.Parameters.AddWithValue("@dtFechaInicioAfeccion", i.dtFechaInicioAfeccion);
                    myCommand.Parameters.AddWithValue("@iIDTipoAtencion", i.iIDTipoAtencion);
                    myCommand.Parameters.AddWithValue("@iIDTipoAfeccion", i.iIDTipoAfeccion);
                    myCommand.Parameters.AddWithValue("@bSOAT", i.bSOAT);
                    myCommand.Parameters.AddWithValue("@tJustificacionDiasAcumulados ", i.tJustificacionDiasAdicionales);
                    myCommand.Parameters.AddWithValue("@iIDPais ", i.iIDPais);
                    myCommand.Parameters.AddWithValue("@iIDDepartamento ", i.iIDDepartamento);
                    myCommand.Parameters.AddWithValue("@iIDPresuntoOrigenIncapacidad", i.iIDPresuntoOrigenIncapacidad);
                    myCommand.Parameters.AddWithValue("@tPalabrasClave", i.tPalabrasClave);
                    myCommand.Parameters.AddWithValue("@tDescripcionAcontecimientos", i.tDescripcion);
                    myCommand.Parameters.AddWithValue("@iIDCiudad", i.iIDCiudad);
                    myCommand.Parameters.AddWithValue("@tDireccionGenerada", i.tDireccion);
                    myCommand.Parameters.AddWithValue("@tBarrio", i.tBarrio);
                    myCommand.Parameters.AddWithValue("@iIDCie10", i.iIDDiagnosticoCorrelacion);
                    myCommand.Parameters.AddWithValue("@iIDLateralidad", i.iIDLateralidad);
                    myCommand.Parameters.AddWithValue("@tDescripcionSintomatologica", i.tDescripcionSintomatologica);
                    myCommand.Parameters.AddWithValue("@bProrroga", i.bProrroga);
                    myCommand.Parameters.AddWithValue("@iDiasIncapacidad", i.iDiasIncapacidad);
                    myCommand.Parameters.AddWithValue("@tJustificacion", i.tJustificacion);
                    myCommand.Parameters.AddWithValue("@iIDUsuarioCreador", i.iIDUsuarioCreador);
                    myCommand.Parameters.AddWithValue("@bEsTranscripcion", i.bEsTranscripcion);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            // return new JsonResult("Creacion de incapacidad exitosa");
            //var JSONString = JsonConvert.SerializeObject(table);
            //return JSONString; 
            var dataObjects = JsonConvert.SerializeObject(table);
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

        //Consultar datos acumilados incapacidades
        [HttpGet]
        [AllowAnonymous]
        public object ConsultarDatos(int NumeroDocumento, int TipoDoc, int idPaciente)
        {
            string SProcedure = @"Pacientes.SPdatosTotales";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@iIDPaciente", (idPaciente != null) ? idPaciente : 0);
                    myCommand.Parameters.AddWithValue("@NumeroDocumento", (NumeroDocumento != null) ? NumeroDocumento : 0);
                    myCommand.Parameters.AddWithValue("@TipoDoc", (TipoDoc != null) ? TipoDoc : 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            object JSONString = null;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }

        //Consultar datos de paciente
        [HttpGet]
        [AllowAnonymous]
        public object ConsultarDatospaciente(int NumeroDocumento, int TipoDoc, int idPaciente)
        {
            string SProcedure = @"Pacientes.SPInformacion";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@iIDPaciente", (idPaciente != null) ? idPaciente : 0);
                    myCommand.Parameters.AddWithValue("@NumeroDocumento", (NumeroDocumento != null) ? NumeroDocumento : 0);
                    myCommand.Parameters.AddWithValue("@TipoDoc", (TipoDoc != null) ? TipoDoc : 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            object JSONString = null;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }

        //Consultar empleador
        [HttpGet]
        [AllowAnonymous]
        public object ConsultarEmpleador(int NumeroDocumento, int TipoDoc, int idPaciente)
        {
            string SProcedure = @"Pacientes.SPempleador";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@iIDPaciente", (idPaciente != null) ? idPaciente : 0);
                    myCommand.Parameters.AddWithValue("@NumeroDocumento", (NumeroDocumento != null) ? NumeroDocumento : 0);
                    myCommand.Parameters.AddWithValue("@TipoDoc", (TipoDoc != null) ? TipoDoc : 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            object JSONString = null;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }

        //Agregar diagnostico al Concepto de rehabilitacion
        [HttpPost]
        //[AllowAnonymous]
        public JsonResult AgregarSintomaIncapacidad(AgregarSintomaIncapacidad c)
        {
            string SProcedure = @"K2Incapacidad.SPAgregarSintoma";
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
                    myCommand.Parameters.AddWithValue("@IdIncapacidad", c.iIDDiagnosticoIncapacidad);
                    myCommand.Parameters.AddWithValue("@Cie10Id", c.iIDCIE10);
                    myCommand.Parameters.AddWithValue("@iIDSintomas", 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Sintoma agregado exitosamente");
        }
        //Agregar diagnostico al Concepto de rehabilitacion
        [HttpPost]
        //[AllowAnonymous]
        public JsonResult AgregarSignoIncapacidad(AgregarSignoIncapacidad c)
        {
            string SProcedure = @"K2Incapacidad.SPAgregarSigno";
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
                    myCommand.Parameters.AddWithValue("@IdIncapacidad", c.iIDDiagnosticoIncapacidad);
                    myCommand.Parameters.AddWithValue("@Cie10Id", c.iIDCIE10);
                    myCommand.Parameters.AddWithValue("@iIDSignos", 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Signo agregado exitosamente");
        }

    }
}
