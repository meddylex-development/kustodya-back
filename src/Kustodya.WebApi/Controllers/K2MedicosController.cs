
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;


namespace Kustodya.WebApi.Controllers
{
    public class K2MedicosController : BaseController
    {
        private readonly IConfiguration _configuration;

        public K2MedicosController(
            IConfiguration configuration
            )
        {
            _configuration = configuration;
        }

               //InformacionUsuarios
        [HttpGet]
        //[AllowAnonymous]
        public object ConsultarUsuarios (int idUsuario, string numeroDocumento, int idTipoDoc, int esMedico)
        {
            string SProcedure = @"Medicos.SPinformacion";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@iidUsuario", (idUsuario != null) ? idUsuario : 0);
                    myCommand.Parameters.AddWithValue("@NumeroDocumento", (numeroDocumento != null) ? numeroDocumento : "");
                    myCommand.Parameters.AddWithValue("@TipoDoc", (idTipoDoc != null) ? idTipoDoc : 0);
                    myCommand.Parameters.AddWithValue("@EsMedico", (esMedico != null) ? esMedico : 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString1 = JsonConvert.SerializeObject(table);

          SProcedure = @"Medicos.SPDatosAcademicos";
            table = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@iidUsuario", (idUsuario != null) ? idUsuario : 0);
                    myCommand.Parameters.AddWithValue("@NumeroDocumento", (numeroDocumento != null) ? numeroDocumento : "");
                    myCommand.Parameters.AddWithValue("@TipoDoc", (idTipoDoc != null) ? idTipoDoc : 0);
                    myCommand.Parameters.AddWithValue("@EsMedico", (esMedico != null) ? esMedico : 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString2 = JsonConvert.SerializeObject(table);


            SProcedure = @"Medicos.SPSso";
            table = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@iidUsuario", (idUsuario != null) ? idUsuario : 0);
                    myCommand.Parameters.AddWithValue("@NumeroDocumento", (numeroDocumento != null) ? numeroDocumento : "");
                    myCommand.Parameters.AddWithValue("@TipoDoc", (idTipoDoc != null) ? idTipoDoc : 0);
                    myCommand.Parameters.AddWithValue("@EsMedico", (esMedico != null) ? esMedico : 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString3 = JsonConvert.SerializeObject(table);

            SProcedure = @"Medicos.SPSanciones";
            table = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@iidUsuario", (idUsuario != null) ? idUsuario : 0);
                    myCommand.Parameters.AddWithValue("@NumeroDocumento", (numeroDocumento != null) ? numeroDocumento : "");
                    myCommand.Parameters.AddWithValue("@TipoDoc", (idTipoDoc != null) ? idTipoDoc : 0);
                    myCommand.Parameters.AddWithValue("@EsMedico", (esMedico != null) ? esMedico : 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString4 = JsonConvert.SerializeObject(table);



            var dataObjects = "{ informacionUsuarios: " + JSONString1 + ", datosAcademicos: " + JSONString2 + " , servicioSocialObligatorio: " + JSONString3 + ", Sanciones: " + JSONString4 + "}";
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
