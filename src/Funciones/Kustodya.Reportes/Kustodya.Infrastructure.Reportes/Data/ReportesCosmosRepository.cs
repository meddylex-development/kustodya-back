using System.Linq;
using System.Threading.Tasks;
using Kustodya.Core.Reportes.Entities;
using Kustodya.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kustodya.Infrastructure.Reportes.Data
{
    public class ReportesCosmosRepository : EfSqlRepository<Reporte, ReportesContext>
    {
        public ReportesCosmosRepository(ReportesContext dbContext) : base(dbContext)
        {
        }

        public override async Task AddOrUpdateAsync(Reporte reporte)
        {
            foreach (var solicitud in reporte.Solicitudes)
            {
                await AddOrUpdateAsync(solicitud);
            }
            await base.AddOrUpdateAsync(reporte);
            await _dbContext.SaveChangesAsync();
            await DetachAllEntitiesAsync();
        }

        private async Task AddOrUpdateAsync(Solicitud solicitud)
        {
            var dbEntity = await _dbContext.FindAsync(typeof(Reporte), solicitud.Id);
            if (dbEntity is null)
            {
                await _dbContext.Set<Solicitud>().AddAsync(solicitud);
            }
            else
            {
                _dbContext.Entry(solicitud).State = EntityState.Modified;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task DetachAllEntitiesAsync()
        {
            var changedEntriesCopy = _dbContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
            await _dbContext.SaveChangesAsync();
        }
    }
}