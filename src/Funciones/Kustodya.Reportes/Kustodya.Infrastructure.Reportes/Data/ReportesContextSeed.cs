using System;
using System.Threading.Tasks;
using Kustodya.Infrastructure.Reportes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Kustodya.Infrastructure.Data
{
    public class ReportesContextSeed
    {
        public static async Task SeedAsync(ReportesContext context, ILogger<ReportesContextSeed> logger, int? reintentos = 0)
        {
            int reintentarDisponibilidad = reintentos.Value;
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                if (reintentarDisponibilidad < 10)
                {
                    reintentarDisponibilidad++;
                    logger.LogError(ex.Message);
                    await SeedAsync(context, logger, reintentarDisponibilidad);
                }
                throw;
            }
        }
    }
}