using System;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.Core.Reportes.Entities;
using Kustodya.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Kustodya.Infrastructure.Reportes.Data
{
    public class ReportesSqlsRepository : EfSqlRepository<Reporte, ReportesContext>
    {
        private readonly ILogger<ReportesSqlsRepository> _logger;

        public ReportesSqlsRepository(ReportesContext dbContext, ILogger<ReportesSqlsRepository> logger) : base(dbContext)
        {
            _logger = logger;
        }

        
        public override async Task UpdateAsync(Reporte entity)
        {
            var state = _dbContext.Entry(entity.Solicitudes[0]).State;
            _logger.LogInformation($"El estado de pa primera solicitud es: {Enum.GetName(typeof(EntityState), state)}");
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}