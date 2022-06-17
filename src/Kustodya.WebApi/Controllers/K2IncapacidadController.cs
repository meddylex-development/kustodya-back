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
        public JsonResult CrearIncapacidad(CrearIncapacidad i)
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
                    myCommand.Parameters.AddWithValue("@bPregunta1 ", i.bPregunta1);
                    myCommand.Parameters.AddWithValue("@bPregunta2 ", i.bPregunta2);
                    myCommand.Parameters.AddWithValue("@bPregunta3 ", i.bPregunta3);
                    myCommand.Parameters.AddWithValue("@bPregunta4 ", i.bPregunta4);
                    myCommand.Parameters.AddWithValue("@bPregunta5 ", i.bPregunta5);
                    myCommand.Parameters.AddWithValue("@iIDPresuntoOrigenIncapacidad", i.iIDPresuntoOrigenIncapacidad);
                    myCommand.Parameters.AddWithValue("@tPalabrasClave", i.tPalabrasClave);
                    myCommand.Parameters.AddWithValue("@tDescripcion", i.tDescripcion);
                    myCommand.Parameters.AddWithValue("@iIDCiudad", i.iIDCiudad);
                    myCommand.Parameters.AddWithValue("@tDireccion", i.tDireccion);
                    myCommand.Parameters.AddWithValue("@tBarrio", i.tBarrio);
                    myCommand.Parameters.AddWithValue("@iIDDiagnosticoCorrelacion", i.iIDDiagnosticoCorrelacion);
                    myCommand.Parameters.AddWithValue("@iIDLateralidad", i.iIDLateralidad);
                    myCommand.Parameters.AddWithValue("@tDescripcionSintomatologica", i.tDescripcionSintomatologica);
                    myCommand.Parameters.AddWithValue("@bProrroga", i.bProrroga);
                    myCommand.Parameters.AddWithValue("@iDiasIncapacidad", i.iDiasIncapacidad);
                    myCommand.Parameters.AddWithValue("@tJustificacion", i.tJustificacion);
                    myCommand.Parameters.AddWithValue("@iIDUsuarioCreador", i.iIDUsuarioCreador);
                    myCommand.Parameters.AddWithValue("@bAuditoria", i.bAuditoria);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Creacion de incapacidad exitosa");
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
                    myCommand.Parameters.AddWithValue("@TipoDoc", (TipoDoc != null) ? TipoDoc : 0); myReader = myCommand.ExecuteReader();
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


    }
}
