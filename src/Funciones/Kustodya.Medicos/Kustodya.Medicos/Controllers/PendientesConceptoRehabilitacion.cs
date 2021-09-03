using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Kustodya.Medicos.Controllers
{
    public class PendientesConceptoRehabilitacion
    {
        public PendientesConceptoRehabilitacion(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PendientesConceptoRehabilitacion>();
        }
        private readonly ILogger _logger;

        [FunctionName(nameof(GeneracionPendientesConceptoRehabilitacion))]
        public void GeneracionPendientesConceptoRehabilitacion([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer, [DurableClient] IDurableClient durableClient, IBinder binder)
        {
            _logger.LogInformation($"ℹ Inicio Ejecución Pendientes Concepto Rehabilitación");
            var connectionString = Environment.GetEnvironmentVariable("SqlDb:ConnectionString");
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("exec usp_GenerarPacientePorEmitir",sqlConnection);
            try{
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }catch(Exception ex){
                _logger.LogInformation($"ℹ Error en la ejecución de Pendientes Concepto Rehabilitación");
                sqlConnection.Close();
            }
            return;
        }
    }
}