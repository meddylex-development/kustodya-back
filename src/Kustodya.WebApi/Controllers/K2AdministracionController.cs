using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace Kustodya.WebApi.Controllers
{
    public class K2AdministracionController : BaseController
    {
        private readonly IConfiguration _configuration;
        public K2AdministracionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Consultar paises
        [HttpGet]
        //[AllowAnonymous]
        public object ConsultarPais()
        {
            string SProcedure = @"Administracion.SPCiudades";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@IDPAIS", 0);
                    myCommand.Parameters.AddWithValue("@IDDEPTO", 0);
                    myCommand.Parameters.AddWithValue("@IDMUNICIPIO", 0);
                    myCommand.Parameters.AddWithValue("@SP", 1);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var dataObjects = JsonConvert.SerializeObject(table);
            return TryFormatJson(dataObjects);
        }

        //Consultar Departamentos
        [HttpGet]
        //[AllowAnonymous]
        public object ConsultarDepartamentos(int IDPAIS)
        {
            string SProcedure = @"Administracion.SPCiudades";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@IDPAIS", IDPAIS);
                    myCommand.Parameters.AddWithValue("@IDDEPTO", 0);
                    myCommand.Parameters.AddWithValue("@IDMUNICIPIO", 0);
                    myCommand.Parameters.AddWithValue("@SP", 2);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var dataObjects = JsonConvert.SerializeObject(table);
            return TryFormatJson(dataObjects);
        }

        //Consultar Municipios
        [HttpGet]
        //[AllowAnonymous]
        public object ConsultarMunicipios(int IDPAIS, int IDDEPTO)
        {
            string SProcedure = @"Administracion.SPCiudades";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@IDPAIS", IDPAIS);
                    myCommand.Parameters.AddWithValue("@IDDEPTO", IDDEPTO);
                    myCommand.Parameters.AddWithValue("@IDMUNICIPIO", 0);
                    myCommand.Parameters.AddWithValue("@SP", 3);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var dataObjects = JsonConvert.SerializeObject(table);
            return TryFormatJson(dataObjects);
        }

        //Consultar Poblacion
        [HttpGet]
        //[AllowAnonymous]
        public object ConsultarPoblacion(int IDPAIS, int IDDEPTO, int IDMUNICIPIO)
        {
            string SProcedure = @"Administracion.SPCiudades";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@IDPAIS", IDPAIS);
                    myCommand.Parameters.AddWithValue("@IDDEPTO", IDDEPTO);
                    myCommand.Parameters.AddWithValue("@IDMUNICIPIO", IDMUNICIPIO);
                    myCommand.Parameters.AddWithValue("@SP", 4);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
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
    }
}
