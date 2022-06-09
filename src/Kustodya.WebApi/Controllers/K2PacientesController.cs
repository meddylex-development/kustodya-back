
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;


namespace Kustodya.WebApi.Controllers
{
    public class K2PacientesController : BaseController
    {
        private readonly IConfiguration _configuration;

        public K2PacientesController(
            IConfiguration configuration
            )
        {
            _configuration = configuration;
        }

               //InformacionPaciente
        [HttpGet]
        //[AllowAnonymous]
        public object ConsultarPaciente (int idPaciente, int numeroDocumento, int idTipoDoc)
        {
            string SProcedure = @"Pacientes.SPinformacion";
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
                    myCommand.Parameters.AddWithValue("@NumeroDocumento", (numeroDocumento != null) ? numeroDocumento : 0);
                    myCommand.Parameters.AddWithValue("@TipoDoc", (idTipoDoc != null) ? idTipoDoc : 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString1 = JsonConvert.SerializeObject(table);

            SProcedure = @"Pacientes.SPempleador";
            table = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@iIDPaciente", (idPaciente != null) ? idPaciente : 0);
                    myCommand.Parameters.AddWithValue("@NumeroDocumento", (numeroDocumento != null) ? numeroDocumento : 0);
                    myCommand.Parameters.AddWithValue("@TipoDoc", (idTipoDoc != null) ? idTipoDoc : 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString2 = JsonConvert.SerializeObject(table);


            SProcedure = @"Pacientes.SPdatosTotales";
            table = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@iIDPaciente", (idPaciente != null) ? idPaciente : 0);
                    myCommand.Parameters.AddWithValue("@NumeroDocumento", (numeroDocumento != null) ? numeroDocumento : 0);
                    myCommand.Parameters.AddWithValue("@TipoDoc", (idTipoDoc != null) ? idTipoDoc : 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString3 = JsonConvert.SerializeObject(table);



            var dataObjects = "{ informacionPacientes: " + JSONString1 + ", empleador: " + JSONString2 + " , datosTotales: " + JSONString3 + "}";
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
