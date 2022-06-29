using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.Negocio;
using Kustodya.ApplicationCore.Dtos.Negocio;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;



namespace Kustodya.WebApi.Controllers.Negocio
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPSController : BaseController
    {
        private readonly IIPSService _ipsService;
        private readonly ILoggerService<IPSController> _logger;
        private readonly IConfiguration _configuration;
        public IPSController(IIPSService ipsService, ILoggerService<IPSController> logger, IConfiguration configuration)
        {
            _ipsService = ipsService;
            _logger = logger;
            _configuration = configuration; 
        }

        [HttpGet("{IdIps}", Name = "GetIPSById")]
        [ProducesResponseType(typeof(IPSModel), 200)]
        public async Task<IActionResult> GetIPSById(int IdIps)
        {
            IPSModel ips = await _ipsService.GetIPSById(IdIps).ConfigureAwait(false);

            return Ok(ips);
        }
        //InformacionUsuarios
        [HttpGet]
        //[AllowAnonymous]
        public object IdUsuarioIps(int idUsuario)
        {
            string SProcedure = @"Usuarios.SPIpsUsuario";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KustodyaDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(SProcedure, myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@IdUsuario", (idUsuario != null) ? idUsuario : 0);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            var JSONString = JsonConvert.SerializeObject(table);

            return TryFormatJson(JSONString);
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
