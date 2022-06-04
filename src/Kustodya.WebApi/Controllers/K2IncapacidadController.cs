using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    //[Route("api/[controller]")]
    [ApiController]
    public class K2IncapacidadController : BaseController
    {
        private readonly IConfiguration _configuration;
        public K2IncapacidadController(
            IConfiguration configuration
            )
        {
            _configuration = configuration;
        }


        //Consultar datos acumilados incapacidades
        [HttpGet]
        [AllowAnonymous]
        public object ConsultarDatos(int NumeroDocumento, int TipoDoc)
        {
            string SProcedure = @"Incapacidades.SPdatosTotales";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@NumeroDocumento", NumeroDocumento);
                    myCommand.Parameters.AddWithValue("@TipoDoc", TipoDoc);
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
        public object ConsultarDatospaciente(int NumeroDocumento, int TipoDoc)
        {
            string SProcedure = @"Incapacidades.SPdatosPaciente";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@NumeroDocumento", NumeroDocumento);
                    myCommand.Parameters.AddWithValue("@TipoDoc", TipoDoc);
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
        public object ConsultarEmpleador(int NumeroDocumento, int TipoDoc)
        {
            string SProcedure = @"Incapacidades.SPempleador";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@NumeroDocumento", NumeroDocumento);
                    myCommand.Parameters.AddWithValue("@TipoDoc", TipoDoc);
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
